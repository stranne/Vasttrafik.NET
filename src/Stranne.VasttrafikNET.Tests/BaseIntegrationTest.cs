using System;
using System.Net;
using System.Net.Http;
using System.Threading;
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
        
        private string AbsoluteUrl { get; set; }
        protected MockHttpMessageHandler HttpMessageHandler { get; set; }

        internal void VerifyNetworkMock()
        {
            HttpMessageHandler.VerifyRequest(AbsoluteUrl, HttpMethod.Get);
            HttpMessageHandler.VerifyRequest(TokenAbsoluteUrl, HttpMethod.Post);
        }

        internal Mock<NetworkService> SetUpNetworkServiceMock(string absoluteUrl, string json)
        {
            return SetUpNetworkServiceMock(absoluteUrl, new StringContent(json));
        }

        internal Mock<NetworkService> SetUpNetworkServiceMock(string absoluteUrl, HttpContent mainContent)
        {
            return SetUpNetworkServiceMock(absoluteUrl, new HttpResponseMessage
            {
                Content = mainContent
            });
        }

        internal JourneyPlannerService GetJourneyPlannerService()
        {
            return new JourneyPlannerService(VtKey, VtSecret)
            {
                JourneyPlannerHandlingService = { NetworkService = CreateNetworkService() }
            };
        }

        internal CommuterParkingService GetCommuterParkingService()
        {
            return new CommuterParkingService(VtKey, VtSecret)
            {
                CommuterParkingHandlingService = { NetworkService = CreateNetworkService() }
            };
        }

        internal NetworkService CreateNetworkService() => new NetworkService(VtKey, VtSecret, VtDeviceId)
            {
                HttpClient = new HttpClient(HttpMessageHandler)
            };

        private Mock<NetworkService> SetUpNetworkServiceMock(string absoluteUrl, HttpResponseMessage mainResponseMessage)
        {
            AbsoluteUrl = absoluteUrl;

            HttpMessageHandler = new MockHttpMessageHandler
            {
                SendAsyncAction = (httpRequestMessage, cancellationToken) =>
                {
                    var uri = httpRequestMessage.RequestUri;
                    HttpResponseMessage responseMessage = null;
                    if (CompareUri(uri, TokenAbsoluteUrl) && httpRequestMessage.Method == HttpMethod.Post)
                        responseMessage = new HttpResponseMessage
                        {
                            Content = new StringContent(DefaultTokenJson.Json)
                        };
                    else if (CompareUri(uri, absoluteUrl) && httpRequestMessage.Method == HttpMethod.Get)
                        responseMessage = mainResponseMessage;
                    else
                        throw new ArgumentException(
                            $"Incorrect url; expected: {absoluteUrl}, actual: {uri.AbsoluteUri}");

                    return responseMessage;
                }
            };

            var mockNetworkService = new Mock<NetworkService>(VtKey, VtSecret, VtDeviceId);
            mockNetworkService.SetupProperty(networkService => networkService.HttpClient, new HttpClient(HttpMessageHandler));

            return mockNetworkService;
        }

        internal static bool CompareUri(Uri uri, string absoluteUrl)
        {
            return Uri.Compare(uri, new Uri(absoluteUrl),
                       UriComponents.AbsoluteUri, UriFormat.SafeUnescaped,
                       StringComparison.OrdinalIgnoreCase) == 0;
        }

        protected static HttpRequestMessage ItIsHttpRequestMessage(string absoluteUrl, HttpMethod httpMethod)
        {
            return It.Is<HttpRequestMessage>(httpRequestMessage => CompareUri(httpRequestMessage.RequestUri, absoluteUrl) && httpRequestMessage.Method == httpMethod);
        }
    }
}
