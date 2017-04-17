using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Stranne.VasttrafikNET.Tests
{
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        private readonly object _requestsLock = new object();

        private readonly Dictionary<KeyValuePair<string, HttpMethod>, int> _requests = new Dictionary<KeyValuePair<string, HttpMethod>, int>();

        public Func<HttpRequestMessage, CancellationToken, HttpResponseMessage> SendAsyncAction { get; set; }
        
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            SaveRequest(request);
            return await Task.FromResult(SendAsyncAction.Invoke(request, cancellationToken));
        }

        private void SaveRequest(HttpRequestMessage request)
        {
            var key = new KeyValuePair<string, HttpMethod>(request.RequestUri.AbsoluteUri, request.Method);
            lock (_requestsLock)
            {
                if (_requests.TryGetValue(key, out int requestedTimes))
                {
                    _requests[key] = ++requestedTimes;
                }
                else
                {
                    _requests.Add(key, 1);
                }
            }
        }

        public void VerifyRequest(string absoluteUrl, HttpMethod httpMethod, int expectedRequestedTimes = 1)
        {
            VerifyRequest(absoluteUrl, httpMethod, expectedRequestedTimes, expectedRequestedTimes);
        }

        public void VerifyRequest(string absoluteUrl, HttpMethod httpMethod, int expectedRequestedTimesMin, int expectedRequestedTimesMax)
        {
            var key = new KeyValuePair<string, HttpMethod>(absoluteUrl, httpMethod);
            _requests.TryGetValue(key, out int requestedTimes);

            if (expectedRequestedTimesMin == expectedRequestedTimesMax)
                Assert.True(expectedRequestedTimesMin == requestedTimes, $"Expected {expectedRequestedTimesMin} calls but found {requestedTimes} calls for request {httpMethod.Method} {absoluteUrl}");
            else
                Assert.True(expectedRequestedTimesMin <= requestedTimes && expectedRequestedTimesMax >= requestedTimes, $"Expected between {expectedRequestedTimesMin} and {expectedRequestedTimesMax} calls but found {requestedTimes} calls for request {httpMethod.Method} {absoluteUrl}");
        }
    }
}
