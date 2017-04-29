using System;
using System.Net.Http;
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

        protected const string TokenAbsoluteUrlTemplate = "https://api.vasttrafik.se/token?grant_type=client_credentials&scope={0}&format=json";
        protected string TokenAbsoluteUrl = string.Format(TokenAbsoluteUrlTemplate, VtDeviceId);


        private string AbsoluteUrl { get; set; }
        protected MockHttpMessageHandler HttpMessageHandler { get; set; }
        
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

        private NetworkService CreateNetworkService() => new NetworkService(VtKey, VtSecret, VtDeviceId)
        {
            HttpClient = new HttpClient(HttpMessageHandler)
        };

        internal void VerifyNetworkMock()
        {
            HttpMessageHandler.VerifyRequest(AbsoluteUrl, HttpMethod.Get);
            HttpMessageHandler.VerifyRequest(TokenAbsoluteUrl, HttpMethod.Post);
        }

        internal Mock<NetworkService> SetUpNetworkServiceMock(string absoluteUrl, string json, string vtDeviceId = VtDeviceId)
        {
            return SetUpNetworkServiceMock(absoluteUrl, new StringContent(json), vtDeviceId);
        }

        internal Mock<NetworkService> SetUpNetworkServiceMock(string absoluteUrl, HttpContent mainContent, string vtDeviceId = VtDeviceId)
        {
            return SetUpNetworkServiceMock(absoluteUrl, new HttpResponseMessage
            {
                Content = mainContent
            }, vtDeviceId);
        }

        private Mock<NetworkService> SetUpNetworkServiceMock(string absoluteUrl, HttpResponseMessage mainResponseMessage, string vtDeviceId = VtDeviceId)
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

            var mockNetworkService = new Mock<NetworkService>(VtKey, VtSecret, vtDeviceId);
            mockNetworkService.SetupProperty(networkService => networkService.HttpClient, new HttpClient(HttpMessageHandler));

            return mockNetworkService;
        }

        internal static bool CompareUri(Uri uri, string absoluteUrl)
        {
            return Uri.Compare(uri, new Uri(absoluteUrl),
                       UriComponents.AbsoluteUri, UriFormat.SafeUnescaped,
                       StringComparison.OrdinalIgnoreCase) == 0;
        }
    }
}
