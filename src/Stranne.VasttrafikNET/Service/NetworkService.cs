using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Stranne.VasttrafikNET.Exceptions;
using Stranne.VasttrafikNET.Extensions;
using Stranne.VasttrafikNET.Models;

namespace Stranne.VasttrafikNET.Service
{
    internal class NetworkService : IDisposable
    {
        private static readonly Uri VtBaseUrl = new Uri("https://api.vasttrafik.se/");

        private const string VtTokenUrl = "token?grant_type=client_credentials&scope={0}&format=json";

        private static readonly ConcurrentDictionary<string, Token> Tokens = new ConcurrentDictionary<string, Token>();

        private readonly string _key;

        private readonly string _secret;

        internal string DeviceId { private get; set; }

        internal virtual HttpClient HttpClient { get; set; } = new HttpClient
        {
            BaseAddress = VtBaseUrl
        };

        public NetworkService(string vtKey, string vtSecret, string vtDeviceId)
        {
            vtKey.ThrowIfNullOrWhiteSpace(nameof(vtKey));
            _key = vtKey;

            vtSecret.ThrowIfNullOrWhiteSpace(nameof(vtSecret));
            _secret = vtSecret;

            if (vtDeviceId == null)
                vtDeviceId = Guid.NewGuid().ToString();
            DeviceId = vtDeviceId;
        }

        public async Task<string> DownloadStringAsync(string absoluteUrl)
        {
            var response = await GetHttpResponseMessage(absoluteUrl);
            var json = await response.Content.ReadAsStringAsync();
            ThrowIfServerErrors(json);

            return json;
        }

        public async Task<Stream> DownloadStreamAsync(string absoluteUrl)
        {
            var response = await GetHttpResponseMessage(absoluteUrl);
            var stream = await response.Content.ReadAsStreamAsync();
            return stream;
        }

        private async Task<HttpResponseMessage> GetHttpResponseMessage(string absoluteUrl)
        {
            var connectionAttempts = 0;
            while (connectionAttempts < 2)
            {
                var token = await GetToken();

                var httpRequestMessage = new HttpRequestMessage
                {
                    RequestUri = new Uri(VtBaseUrl, absoluteUrl),
                    Method = HttpMethod.Get
                };
                httpRequestMessage.Headers.Authorization = AuthenticationHeaderValue.Parse($"Bearer {token.AccessToken}");

                var response = await HttpClient.SendAsync(httpRequestMessage);

                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        Tokens[DeviceId] = null;
                        connectionAttempts++;
                        continue;
                    }

                    throw new NetworkException
                    {
                        StatusCode = response.StatusCode,
                        Content = response.Content == null
                            ? null
                            : await response.Content.ReadAsStringAsync(),
                        RequestUri = httpRequestMessage.RequestUri
                    };
                }

                return response;
            }

            throw new AuthenticationException();
        }

        private async Task<Token> GetToken()
        {
            Tokens.TryGetValue(DeviceId, out Token token);

            if (IsTokenValid(token))
                return token;

            token = await CreateToken(_key, _secret, DeviceId);
            Tokens.AddOrUpdate(DeviceId, token, (d, t) => token);
            return token;
        }

        internal virtual bool IsTokenValid(Token token)
        {
            return token?.IsValid() == true;
        }

        private async Task<Token> CreateToken(string key, string secret, string deviceId)
        {
            var base64 = $"{key}:{secret}".ToBase64();

            var httpRequestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(VtBaseUrl, string.Format(VtTokenUrl, deviceId)),
                Method = HttpMethod.Post
            };
            httpRequestMessage.Headers.Authorization = AuthenticationHeaderValue.Parse($"Basic {base64}");

            var response = await HttpClient.SendAsync(httpRequestMessage);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new AuthenticationException();
                }

                throw new NetworkException
                {
                    StatusCode = response.StatusCode,
                    Content = response.Content == null
                        ? null
                        : await response.Content.ReadAsStringAsync(),
                    RequestUri = httpRequestMessage.RequestUri
                };
            }

            var json = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<Token>(json);

            return token;
        }

        private static void ThrowIfServerErrors(string json)
        {
            var jToken = JToken.Parse(json);
            if (jToken.Type != JTokenType.Object)
                return;

            jToken = jToken.First.First;
            
            if (jToken.Type != JTokenType.Object ||
                jToken["error"] == null)
                return;

            throw new ServerException
            {
                Name = jToken["error"].Value<string>(),
                Description = jToken["errorText"].Value<string>()
            };
        }

        public void Dispose()
        {
            HttpClient.Dispose();
        }
    }
}
