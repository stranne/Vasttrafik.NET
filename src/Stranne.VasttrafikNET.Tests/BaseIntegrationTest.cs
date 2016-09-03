using System;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Stranne.VasttrafikNET.Service;
using Stranne.VasttrafikNET.Tests.Json;

namespace Stranne.VasttrafikNET.Tests
{
    public class BaseIntegrationTest
    {
        protected const string VtKey = "Key";
        protected const string VtSecret = "Secret";
        private const string VtDeviceId = "Test";

        protected string TokenAbsoluteUrl = $"https://api.vasttrafik.se/token?grant_type=client_credentials&scope={VtDeviceId}&format=json";
        
        internal void VerifyNetworkMock(Mock<NetworkService> mock, string absoluteUrl)
        {
            mock.Verify(x => x.SendAsync(It.IsAny<HttpClient>(), GetHttpRequestMessage(absoluteUrl, HttpMethod.Get)), Times.Once);
            mock.Verify(x => x.SendAsync(It.IsAny<HttpClient>(), GetHttpRequestMessage(TokenAbsoluteUrl, HttpMethod.Post)), Times.Once);
        }

        internal Mock<NetworkService> GetNetworkServiceMock(string absoluteUrl, string json)
        {
            return GetNetworkServiceMock(absoluteUrl, new StringContent(json));
        }

        internal Mock<NetworkService> GetNetworkServiceMock(string absoluteUrl, HttpContent mainContent)
        {
            var mock = new Mock<NetworkService>(VtKey, VtSecret, VtDeviceId) { CallBase = true };

            mock.Setup(x => x.SendAsync(It.IsAny<HttpClient>(), It.IsAny<HttpRequestMessage>())).Returns<HttpClient, HttpRequestMessage>(
                (httpClient, httpRequestMessage) =>
                {
                    var uri = httpRequestMessage.RequestUri;
                    HttpContent content = null;
                    if (CompareUri(uri, TokenAbsoluteUrl) && httpRequestMessage.Method == HttpMethod.Post)
                        content = new StringContent(DefaultTokenJson.Json);

                    if (CompareUri(uri, absoluteUrl) && httpRequestMessage.Method == HttpMethod.Get)
                        content = mainContent;

                    if (content == null)
                        throw new ArgumentException($"Incorrect url; expected: {absoluteUrl}, actual: {uri.AbsoluteUri}");

                    return Task.FromResult(
                        new HttpResponseMessage
                        {
                            Content = content
                        });
                });

            return mock;
        }

        protected static bool CompareUri(Uri uri, string absoluteUrl)
        {
            return Uri.Compare(uri, new Uri(absoluteUrl),
                       UriComponents.AbsoluteUri, UriFormat.SafeUnescaped,
                       StringComparison.OrdinalIgnoreCase) == 0;
        }

        protected static HttpRequestMessage GetHttpRequestMessage(string absoluteUrl, HttpMethod httpMethod)
        {
            return It.Is<HttpRequestMessage>(httpRequestMessage => CompareUri(httpRequestMessage.RequestUri, absoluteUrl) && httpRequestMessage.Method == httpMethod);
        }
    }
}
