using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Stranne.VasttrafikNET.Exceptions;
using Stranne.VasttrafikNET.Models;
using Stranne.VasttrafikNET.Service;
using Stranne.VasttrafikNET.Tests.Helpers;
using Stranne.VasttrafikNET.Tests.Jsons;
using Xunit;

namespace Stranne.VasttrafikNET.Tests
{
    public class NetworkServiceTest : BaseIntegrationTest
    {
        private const string AbsoluteUrl = "https://api.vasttrafik.se/bin/rest.exe/v2/arrivalBoard?id=0000000800000022&date=2016-07-16&time=16:50&format=json";
        private readonly JsonFile _jsonFile = JsonFile.ArrivalBoard;

        [Fact]
        public async Task MainRequestBadGateway()
        {
            const string content = "Bad gateway";
            var mock = SetUpNetworkServiceMock(AbsoluteUrl, _jsonFile);
            mock.Setup(x => x.IsTokenValid(It.IsAny<Token>())).Returns<Token>(token => token != null);
            HttpMessageHandler = new MockHttpMessageHandler
            {
                SendAsyncAction = (httpRequestMessage, cancellationToken) =>
                {
                    var uri = httpRequestMessage.RequestUri;
                    if (!CompareUri(uri, TokenAbsoluteUrl))
                    {
                        return new HttpResponseMessage
                        {
                            StatusCode = HttpStatusCode.BadGateway,
                            Content = new StringContent(content)
                        };
                    }

                    return new HttpResponseMessage
                    {
                        Content = new StringContent(GetDefaultToken())
                    };
                }
            };
            mock.SetupProperty(x => x.HttpClient, new HttpClient(HttpMessageHandler));
            var sut = mock.Object;

            var exception = await Assert.ThrowsAsync<NetworkException>(() => sut.DownloadStringAsync(AbsoluteUrl));

            HttpMessageHandler.VerifyRequest(AbsoluteUrl, HttpMethod.Get);
            HttpMessageHandler.VerifyRequest(TokenAbsoluteUrl, HttpMethod.Post, 0, 1);
            Assert.Equal(HttpStatusCode.BadGateway, exception.StatusCode);
            Assert.Equal(content, exception.Content);
        }

        [Fact]
        public async Task MainRequestBadGatewayEmptyResponse()
        {
            var mock = SetUpNetworkServiceMock(AbsoluteUrl, _jsonFile);
            mock.Setup(x => x.IsTokenValid(It.IsAny<Token>())).Returns<Token>(token => token != null);
            HttpMessageHandler = new MockHttpMessageHandler
            {
                SendAsyncAction = (httpRequestMessage, cancellationToken) =>
                {
                    var uri = httpRequestMessage.RequestUri;
                    if (!CompareUri(uri, TokenAbsoluteUrl))
                    {
                        return new HttpResponseMessage
                        {
                            StatusCode = HttpStatusCode.BadGateway
                        }; 
                    }

                    return new HttpResponseMessage
                    {
                        Content = new StringContent(GetDefaultToken())
                    };
                }
            };
            mock.SetupProperty(x => x.HttpClient, new HttpClient(HttpMessageHandler));
            var sut = mock.Object;

            var exception = await Assert.ThrowsAsync<NetworkException>(() => sut.DownloadStringAsync(AbsoluteUrl));

            HttpMessageHandler.VerifyRequest(AbsoluteUrl, HttpMethod.Get);
            HttpMessageHandler.VerifyRequest(TokenAbsoluteUrl, HttpMethod.Post, 0, 1);
            Assert.Equal(HttpStatusCode.BadGateway, exception.StatusCode);
        }

        [Fact]
        public async Task MainRequestNotFoundResponse()
        {
            var mock = SetUpNetworkServiceMock(AbsoluteUrl, _jsonFile);
            mock.Setup(x => x.IsTokenValid(It.IsAny<Token>())).Returns<Token>(token => token != null);
            HttpMessageHandler = new MockHttpMessageHandler
            {
                SendAsyncAction = (httpRequestMessage, cancellationToken) =>
                {
                    var uri = httpRequestMessage.RequestUri;
                    if (!CompareUri(uri, TokenAbsoluteUrl))
                    {
                        return new HttpResponseMessage
                        {
                            StatusCode = HttpStatusCode.NotFound
                        };
                    }

                    return new HttpResponseMessage
                    {
                        Content = new StringContent(GetDefaultToken())
                    };
                }
            };
            mock.SetupProperty(x => x.HttpClient, new HttpClient(HttpMessageHandler));
            var sut = mock.Object;

            var actual = await sut.DownloadStringAsync(AbsoluteUrl);

            HttpMessageHandler.VerifyRequest(AbsoluteUrl, HttpMethod.Get);
            HttpMessageHandler.VerifyRequest(TokenAbsoluteUrl, HttpMethod.Post, 0, 1);
            Assert.Null(actual);
        }

        [Fact]
        public async Task TokenNotFound()
        {
            var mock = SetUpNetworkServiceMock(AbsoluteUrl, _jsonFile);
            mock.Setup(x => x.IsTokenValid(It.IsAny<Token>())).Returns(false);
            mock.SetupProperty(x => x.HttpClient, new HttpClient(new MockHttpMessageHandler
            {
                SendAsyncAction = (httpRequestMessage, cancellationToken) => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent(GetDefaultToken())
                }
            }));
            var sut = mock.Object;

            var exception = await Assert.ThrowsAsync<NetworkException>(() => sut.DownloadStringAsync(AbsoluteUrl));

            HttpMessageHandler.VerifyRequest(AbsoluteUrl, HttpMethod.Get, 0);
            HttpMessageHandler.VerifyRequest(TokenAbsoluteUrl, HttpMethod.Post, 0, 1);
            Assert.Equal(HttpStatusCode.NotFound, exception.StatusCode);
            Assert.Equal(TokenAbsoluteUrl, exception.RequestUri.AbsoluteUri);
            Assert.Equal(GetDefaultToken(), exception.Content);
        }

        [Fact]
        public async Task TokenNotFoundEmptyResponse()
        {
            var mock = SetUpNetworkServiceMock(AbsoluteUrl, _jsonFile);
            mock.Setup(x => x.IsTokenValid(It.IsAny<Token>())).Returns(false);
            mock.SetupProperty(x => x.HttpClient, new HttpClient(new MockHttpMessageHandler
            {
                SendAsyncAction = (httpRequestMessage, cancellationToken) => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound
                }
            }));
            var sut = mock.Object;

            var exception = await Assert.ThrowsAsync<NetworkException>(() => sut.DownloadStringAsync(AbsoluteUrl));

            HttpMessageHandler.VerifyRequest(AbsoluteUrl, HttpMethod.Get, 0);
            HttpMessageHandler.VerifyRequest(TokenAbsoluteUrl, HttpMethod.Post, 0, 1);
            Assert.Equal(HttpStatusCode.NotFound, exception.StatusCode);
            Assert.Equal(TokenAbsoluteUrl, exception.RequestUri.AbsoluteUri);
            Assert.Equal(null, exception.Content);
        }

        [Fact]
        public async Task ReplaceTokenIfNotValid()
        {
            var mock = SetUpNetworkServiceMock(AbsoluteUrl, _jsonFile);
            mock.Setup(x => x.IsTokenValid(It.IsAny<Token>())).Returns(false);
            var sut = mock.Object;

            await sut.DownloadStringAsync(AbsoluteUrl);
            await sut.DownloadStringAsync(AbsoluteUrl);

            HttpMessageHandler.VerifyRequest(AbsoluteUrl, HttpMethod.Get, 2);
            HttpMessageHandler.VerifyRequest(TokenAbsoluteUrl, HttpMethod.Post, 2);
        }

        [Fact]
        public async Task SingleTokenAquireOnMultipleRequests()
        {
            var mock = SetUpNetworkServiceMock(AbsoluteUrl, _jsonFile);
            mock.Setup(x => x.IsTokenValid(It.IsAny<Token>())).Returns<Token>(token => token != null);
            var sut = mock.Object;

            await sut.DownloadStringAsync(AbsoluteUrl);
            await sut.DownloadStringAsync(AbsoluteUrl);

            HttpMessageHandler.VerifyRequest(AbsoluteUrl, HttpMethod.Get, 2);
            HttpMessageHandler.VerifyRequest(TokenAbsoluteUrl, HttpMethod.Post, 0, 1);
        }

        [Fact]
        public async Task UniqueTokenOnMultipleDeviceId()
        {
            var firstTokenAbsoluteUrl = TokenAbsoluteUrl;
            const string secondTokenAbsoluteUrl = "https://api.vasttrafik.se/token?grant_type=client_credentials&scope=device_SomethingElse&format=json";
            var mock = SetUpNetworkServiceMock(AbsoluteUrl, _jsonFile);
            mock.Setup(x => x.IsTokenValid(It.IsAny<Token>())).Returns<Token>(token => token != null);
            var sut = mock.Object;

            await sut.DownloadStringAsync(AbsoluteUrl);
            sut = mock.Object;
            sut.DeviceId = "SomethingElse";
            TokenAbsoluteUrl = secondTokenAbsoluteUrl;
            await sut.DownloadStringAsync(AbsoluteUrl);

            HttpMessageHandler.VerifyRequest(AbsoluteUrl, HttpMethod.Get, 2);
            HttpMessageHandler.VerifyRequest(firstTokenAbsoluteUrl, HttpMethod.Post, 0, 1);
            HttpMessageHandler.VerifyRequest(secondTokenAbsoluteUrl, HttpMethod.Post);
        }

        [Fact]
        public async Task Unauthorized()
        {
            const string tokenName = nameof(UnauthorizedWithToken);
            TokenAbsoluteUrl = string.Format(TokenAbsoluteUrlTemplate, tokenName);
            var mock = SetUpNetworkServiceMock(AbsoluteUrl, _jsonFile, tokenName);
            mock.Setup(x => x.IsTokenValid(It.IsAny<Token>())).Returns<Token>(token => false);
            HttpMessageHandler = new MockHttpMessageHandler
            {
                SendAsyncAction = (httpRequestMessage, cancellationToken) => new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = new StringContent("Unauthorized")
                }
            };
            mock.SetupProperty(x => x.HttpClient, new HttpClient(HttpMessageHandler));
            var sut = mock.Object;

            var execption = await Assert.ThrowsAsync<AuthenticationException>(async () => await sut.DownloadStringAsync(AbsoluteUrl));

            HttpMessageHandler.VerifyRequest(AbsoluteUrl, HttpMethod.Get, 0);
            HttpMessageHandler.VerifyRequest(TokenAbsoluteUrl, HttpMethod.Post);
            Assert.Equal("Authentication failed with Västtrafik's servers. Verify Key and Secret are correct and that the application has access to the API in question.", execption.Message);
        }

        [Fact]
        public async Task UnauthorizedEmpty()
        {
            const string tokenName = nameof(UnauthorizedEmpty);
            TokenAbsoluteUrl = string.Format(TokenAbsoluteUrlTemplate, tokenName);
            var mock = SetUpNetworkServiceMock(AbsoluteUrl, _jsonFile, tokenName);
            mock.Setup(x => x.IsTokenValid(It.IsAny<Token>())).Returns<Token>(token => false);
            HttpMessageHandler = new MockHttpMessageHandler
            {
                SendAsyncAction = (httpRequestMessage, cancellationToken) => new HttpResponseMessage(HttpStatusCode.Unauthorized)
            };
            mock.SetupProperty(x => x.HttpClient, new HttpClient(HttpMessageHandler));
            var sut = mock.Object;

            var execption = await Assert.ThrowsAsync<AuthenticationException>(async () => await sut.DownloadStringAsync(AbsoluteUrl));

            HttpMessageHandler.VerifyRequest(AbsoluteUrl, HttpMethod.Get, 0);
            HttpMessageHandler.VerifyRequest(TokenAbsoluteUrl, HttpMethod.Post);
            Assert.Equal("Authentication failed with Västtrafik's servers. Verify Key and Secret are correct and that the application has access to the API in question.", execption.Message);
        }

        [Fact]
        public async Task UnauthorizedWithToken()
        {
            var mock = SetUpNetworkServiceMock(AbsoluteUrl, _jsonFile);
            mock.Setup(x => x.IsTokenValid(It.IsAny<Token>())).Returns<Token>(token => token != null);
            HttpMessageHandler = new MockHttpMessageHandler
            {
                SendAsyncAction = (httpRequestMessage, cancellationToken) =>
                {
                    var responseMessage = new HttpResponseMessage
                    {
                        Content = new StringContent(GetDefaultToken())
                    };

                    var uri = httpRequestMessage.RequestUri;
                    if (!CompareUri(uri, TokenAbsoluteUrl))
                        responseMessage.StatusCode = HttpStatusCode.Unauthorized;

                    return responseMessage;
                }
            };
            mock.SetupProperty(x => x.HttpClient, new HttpClient(HttpMessageHandler));
            var sut = mock.Object;

            var execption = await Assert.ThrowsAsync<AuthenticationException>(async () => await sut.DownloadStringAsync(AbsoluteUrl));

            HttpMessageHandler.VerifyRequest(AbsoluteUrl, HttpMethod.Get, 2);
            HttpMessageHandler.VerifyRequest(TokenAbsoluteUrl, HttpMethod.Post, 1, 2);
            Assert.Equal("Authentication failed with Västtrafik's servers. Verify Key and Secret are correct and that the application has access to the API in question.", execption.Message);
        }
        
        [Fact]
        public async Task TokenJustExpiredOnServer()
        {
            var mock = SetUpNetworkServiceMock(AbsoluteUrl, _jsonFile);
            mock.Setup(x => x.IsTokenValid(It.IsAny<Token>())).Returns<Token>(token => token != null);
            var firstTry = true;
            HttpMessageHandler = new MockHttpMessageHandler
            {
                SendAsyncAction = (httpRequestMessage, cancellationToken) =>
                {
                    var responseMessage = new HttpResponseMessage
                    {
                        Content = new StringContent(GetDefaultToken())
                    };

                    var uri = httpRequestMessage.RequestUri;
                    if (!CompareUri(uri, TokenAbsoluteUrl))
                    {
                        if (firstTry)
                            responseMessage.StatusCode = HttpStatusCode.Unauthorized;
                        else
                            responseMessage = new HttpResponseMessage
                            {
                                Content = new StringContent(FileHelper.GetJson(_jsonFile))
                            };

                        firstTry = false;
                    }

                    return responseMessage;
                }
            };
            mock.SetupProperty(x => x.HttpClient, new HttpClient(HttpMessageHandler));
            var sut = mock.Object;

            var actual = await sut.DownloadStringAsync(AbsoluteUrl);

            HttpMessageHandler.VerifyRequest(AbsoluteUrl, HttpMethod.Get, 2);
            HttpMessageHandler.VerifyRequest(TokenAbsoluteUrl, HttpMethod.Post, 1, 2);
            Assert.Equal(actual, FileHelper.GetJson(_jsonFile));
        }

        [Fact]
        public async Task EmptyResponse()
        {
            var mock = SetUpNetworkServiceMock(AbsoluteUrl, _jsonFile);
            mock.Setup(x => x.IsTokenValid(It.IsAny<Token>())).Returns<Token>(token => token != null);
            HttpMessageHandler = new MockHttpMessageHandler
            {
                SendAsyncAction = (httpRequestMessage, cancellationToken) =>
                {
                    var responseMessage = new HttpResponseMessage
                    {
                        Content = new StringContent(GetDefaultToken())
                    };

                    var uri = httpRequestMessage.RequestUri;
                    if (!CompareUri(uri, TokenAbsoluteUrl))
                    {
                        responseMessage = new HttpResponseMessage
                        {
                            Content = new StringContent("")
                        };
                    }

                    return responseMessage;
                }
            };
            mock.SetupProperty(x => x.HttpClient, new HttpClient(HttpMessageHandler));
            var sut = mock.Object;

            var actual = await sut.DownloadStringAsync(AbsoluteUrl);

            HttpMessageHandler.VerifyRequest(AbsoluteUrl, HttpMethod.Get, 1);
            HttpMessageHandler.VerifyRequest(TokenAbsoluteUrl, HttpMethod.Post, 0, 1);
            Assert.Equal(actual, "");
        }

        [Fact]
        public async Task RootObjectListResponse()
        {
            const string json = "{ List: [] }";
            var mock = SetUpNetworkServiceMock(AbsoluteUrl, json);
            var sut = mock.Object;

            var actual = await sut.DownloadStringAsync(AbsoluteUrl);

            Assert.Equal(json, actual);
        }

        [Fact]
        public void TokenIsValid()
        {
            var token = new Token
            {
                ExpiresIn = 3600
            };
            var sut = new NetworkService(Key, Secret, DeviceId);

            var actual = sut.IsTokenValid(token);

            Assert.True(actual);
        }

        [Fact]
        public void TokenExpired()
        {
            var token = new Token
            {
                ExpiresIn = 0
            };
            var sut = new NetworkService(Key, Secret, DeviceId);

            var actual = sut.IsTokenValid(token);

            Assert.False(actual);
        }

        [Fact]
        public void NoToken()
        {
            var sut = new NetworkService(Key, Secret, DeviceId);

            var actual = sut.IsTokenValid(null);

            Assert.False(actual);
        }

        private string GetDefaultToken() => FileHelper.GetJson(JsonFile.DefaultToken);
    }
}
