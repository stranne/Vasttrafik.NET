using System;
using System.Net.Http;
using Moq;
using Stranne.VasttrafikNET.Service;
using Stranne.VasttrafikNET.Tests.Json;

namespace Stranne.VasttrafikNET.Tests
{
    public class BaseIntegrationTest
    {
        protected const string Key = "Key";
        protected const string Secret = "Secret";
        protected const string DeviceId = "Test";

        protected const string TokenAbsoluteUrlTemplate = "https://api.vasttrafik.se/token?grant_type=client_credentials&scope=device_{0}&format=json";
        protected string TokenAbsoluteUrl = string.Format(TokenAbsoluteUrlTemplate, DeviceId);
        
        private string AbsoluteUrl { get; set; }
        protected MockHttpMessageHandler HttpMessageHandler { get; set; }
        
        internal JourneyPlannerService GetJourneyPlannerService()
        {
            return new JourneyPlannerService(Key, Secret)
            {
                JourneyPlannerHandlingService = { NetworkService = CreateNetworkService() }
            };
        }

        internal CommuterParkingService GetCommuterParkingService()
        {
            return new CommuterParkingService(Key, Secret)
            {
                CommuterParkingHandlingService = { NetworkService = CreateNetworkService() }
            };
        }

        private NetworkService CreateNetworkService() => new NetworkService(Key, Secret, DeviceId)
        {
            HttpClient = new HttpClient(HttpMessageHandler)
        };

        internal void VerifyNetworkMock()
        {
            HttpMessageHandler.VerifyRequest(AbsoluteUrl, HttpMethod.Get);
            HttpMessageHandler.VerifyRequest(TokenAbsoluteUrl, HttpMethod.Post, 0, 1);
        }

        internal Mock<NetworkService> SetUpNetworkServiceMock(string absoluteUrl, string json, string deviceId = DeviceId)
        {
            return SetUpNetworkServiceMock(absoluteUrl, new StringContent(json), deviceId);
        }

        internal Mock<NetworkService> SetUpNetworkServiceMock(string absoluteUrl, HttpContent mainContent, string deviceId = DeviceId)
        {
            return SetUpNetworkServiceMock(absoluteUrl, new HttpResponseMessage
            {
                Content = mainContent
            }, deviceId);
        }

        private Mock<NetworkService> SetUpNetworkServiceMock(string absoluteUrl, HttpResponseMessage mainResponseMessage, string deviceId = DeviceId)
        {
            AbsoluteUrl = absoluteUrl;

            HttpMessageHandler = new MockHttpMessageHandler
            {
                SendAsyncAction = (httpRequestMessage, cancellationToken) =>
                {
                    var uri = httpRequestMessage.RequestUri;
                    HttpResponseMessage responseMessage;
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

            var mockNetworkService = new Mock<NetworkService>(Key, Secret, deviceId);
            mockNetworkService.SetupProperty(networkService => networkService.HttpClient, new HttpClient(HttpMessageHandler));

            return mockNetworkService;
        }

        internal static bool CompareUri(Uri uri, string absoluteUrl)
        {
            return Uri.Compare(uri,
                       new Uri(absoluteUrl),
                       UriComponents.AbsoluteUri, UriFormat.SafeUnescaped,
                       StringComparison.OrdinalIgnoreCase) == 0;
        }
    }
}
