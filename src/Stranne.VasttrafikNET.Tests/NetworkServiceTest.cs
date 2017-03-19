using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Stranne.VasttrafikNET.Exceptions;
using Stranne.VasttrafikNET.Models;
using Stranne.VasttrafikNET.Tests.Json;
using Xunit;

namespace Stranne.VasttrafikNET.Tests
{
    public class NetworkServiceTest : BaseIntegrationTest
    {
        private const string AbsoluteUrl = "https://api.vasttrafik.se/bin/rest.exe/v2/arrivalBoard?id=0000000800000022&date=2016-07-16&time=16:50&format=json";
        private const string Json = ArrivalBoardJson.Json;

        [Fact]
        public async Task TokenNotFound()
        {
            var mock = GetNetworkServiceMock(AbsoluteUrl, Json);
            mock.Setup(x => x.IsTokenValid(It.IsAny<Token>())).Returns(false);
            mock.Setup(x => x.SendAsync(It.IsAny<HttpClient>(), It.IsAny<HttpRequestMessage>()))
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound
                });
            var sut = mock.Object;

            var exception = await Assert.ThrowsAsync<NetworkException>(() => sut.DownloadStringAsync(AbsoluteUrl));

            mock.Verify(x => x.SendAsync(It.IsAny<HttpClient>(), GetHttpRequestMessage(AbsoluteUrl, HttpMethod.Get)), Times.Never);
            mock.Verify(x => x.SendAsync(It.IsAny<HttpClient>(), GetHttpRequestMessage(TokenAbsoluteUrl, HttpMethod.Post)), Times.AtMostOnce);
            Assert.Equal(HttpStatusCode.NotFound, exception.StatusCode);
            Assert.Equal(TokenAbsoluteUrl, exception.RequestUri.AbsoluteUri);
            Assert.Equal(null, exception.Content);
        }

        [Fact]
        public async Task MainRequestBadGateway()
        {
            var mock = GetNetworkServiceMock(AbsoluteUrl, Json);
            mock.Setup(x => x.IsTokenValid(It.IsAny<Token>())).Returns<Token>(token => token != null);
            mock.Setup(x => x.SendAsync(It.IsAny<HttpClient>(), It.IsAny<HttpRequestMessage>()))
                .Returns<HttpClient, HttpRequestMessage>((httpClient, httpRequestMessage) =>
                {
                    var responseMessage = new HttpResponseMessage
                    {
                        Content = new StringContent(DefaultTokenJson.Json)
                    };

                    var uri = httpRequestMessage.RequestUri;
                    if (!CompareUri(uri, TokenAbsoluteUrl))
                        responseMessage.StatusCode = HttpStatusCode.BadGateway;

                    return Task.FromResult(responseMessage);
                });
            var sut = mock.Object;

            var exception = await Assert.ThrowsAsync<NetworkException>(() => sut.DownloadStringAsync(AbsoluteUrl));

            mock.Verify(x => x.SendAsync(It.IsAny<HttpClient>(), GetHttpRequestMessage(AbsoluteUrl, HttpMethod.Get)), Times.Once);
            mock.Verify(x => x.SendAsync(It.IsAny<HttpClient>(), GetHttpRequestMessage(TokenAbsoluteUrl, HttpMethod.Post)), Times.AtMostOnce);
            Assert.Equal(HttpStatusCode.BadGateway, exception.StatusCode);
        }

        [Fact]
        public async Task ReplaceTokenIfNotValid()
        {
            var mock = GetNetworkServiceMock(AbsoluteUrl, Json);
            mock.Setup(x => x.IsTokenValid(It.IsAny<Token>())).Returns(false);
            var sut = mock.Object;

            await sut.DownloadStringAsync(AbsoluteUrl);
            await sut.DownloadStringAsync(AbsoluteUrl);

            mock.Verify(x => x.SendAsync(It.IsAny<HttpClient>(), GetHttpRequestMessage(AbsoluteUrl, HttpMethod.Get)), Times.Exactly(2));
            mock.Verify(x => x.SendAsync(It.IsAny<HttpClient>(), GetHttpRequestMessage(TokenAbsoluteUrl, HttpMethod.Post)), Times.Exactly(2));
        }

        [Fact]
        public async Task SingleTokenAquireOnMultipleRequests()
        {
            var mock = GetNetworkServiceMock(AbsoluteUrl, Json);
            mock.Setup(x => x.IsTokenValid(It.IsAny<Token>())).Returns<Token>(token => token != null);
            var sut = mock.Object;

            await sut.DownloadStringAsync(AbsoluteUrl);
            await sut.DownloadStringAsync(AbsoluteUrl);

            mock.Verify(x => x.SendAsync(It.IsAny<HttpClient>(), GetHttpRequestMessage(AbsoluteUrl, HttpMethod.Get)), Times.Exactly(2));
            mock.Verify(x => x.SendAsync(It.IsAny<HttpClient>(), GetHttpRequestMessage(TokenAbsoluteUrl, HttpMethod.Post)), Times.AtMostOnce);
        }

        [Fact]
        public async Task UniqueTokenOnMultipleDeviceId()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/bin/rest.exe/v2/arrivalBoard?id=0000000800000022&date=2016-07-16&time=16:50&format=json";
            var firstTokenAbsoluteUrl = TokenAbsoluteUrl;
            const string secondTokenAbsoluteUrl = "https://api.vasttrafik.se/token?grant_type=client_credentials&scope=SomethingElse&format=json";
            var mock = GetNetworkServiceMock(absoluteUrl, Json);
            mock.Setup(x => x.IsTokenValid(It.IsAny<Token>())).Returns<Token>(token => token != null);
            var sut = mock.Object;

            await sut.DownloadStringAsync(absoluteUrl);
            sut = mock.Object;
            sut.DeviceId = "SomethingElse";
            TokenAbsoluteUrl = secondTokenAbsoluteUrl;
            await sut.DownloadStringAsync(absoluteUrl);

            mock.Verify(x => x.SendAsync(It.IsAny<HttpClient>(), GetHttpRequestMessage(absoluteUrl, HttpMethod.Get)), Times.Exactly(2));
            mock.Verify(x => x.SendAsync(It.IsAny<HttpClient>(), GetHttpRequestMessage(firstTokenAbsoluteUrl, HttpMethod.Post)), Times.AtMostOnce);
            mock.Verify(x => x.SendAsync(It.IsAny<HttpClient>(), GetHttpRequestMessage(secondTokenAbsoluteUrl, HttpMethod.Post)), Times.Once);
        }

        [Fact]
        public async Task UnauthorizedWithToken()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/bin/rest.exe/v2/arrivalBoard?id=0000000800000022&date=2016-07-16&time=16:50&format=json";
            var mock = GetNetworkServiceMock(absoluteUrl, new HttpResponseMessage(HttpStatusCode.Unauthorized));
            mock.Setup(x => x.IsTokenValid(It.IsAny<Token>())).Returns<Token>(token => token != null);
            var sut = mock.Object;

            var execption = await Assert.ThrowsAsync<AuthenticationException>(async () => await sut.DownloadStringAsync(absoluteUrl));

            mock.Verify(
                x => x.SendAsync(
                    It.IsAny<HttpClient>(),
                    GetHttpRequestMessage(TokenAbsoluteUrl, HttpMethod.Post)),
                Times.Between(1, 2, Range.Inclusive));
            mock.Verify(
                x => x.SendAsync(
                    It.IsAny<HttpClient>(),
                    GetHttpRequestMessage(absoluteUrl, HttpMethod.Get)),
                Times.Exactly(2));
            Assert.Equal("Authentication failed with Västtrafik's servers. Verify Key and Secret are correct and that the application has access to the API in question.", execption.Message);
        }
    }
}
