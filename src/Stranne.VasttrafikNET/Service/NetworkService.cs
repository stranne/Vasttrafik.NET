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

        private const string VtTokenUrl = "token?grant_type=client_credentials&scope=device_{0}&format=json";

        private static readonly ConcurrentDictionary<string, Token> Tokens = new ConcurrentDictionary<string, Token>();

        private readonly string _key;

        private readonly string _secret;

        internal string DeviceId { private get; set; }

        internal virtual HttpClient HttpClient { get; set; } = new HttpClient
        {
            BaseAddress = VtBaseUrl
        };

        public NetworkService(string key, string secret, string deviceId)
        {
            key.ThrowIfNullOrWhiteSpace(nameof(key));
            _key = key;

            secret.ThrowIfNullOrWhiteSpace(nameof(secret));
            _secret = secret;

            if (deviceId == null)
                deviceId = Guid.NewGuid().ToString();
            DeviceId = deviceId;
        }

        public async Task<string> DownloadStringAsync(string absolutePath)
        {
            var response = await GetHttpResponseMessage(absolutePath);
            var json = await response.Content.ReadAsStringAsync();
            ThrowIfServerErrors(json);

            return json;
        }

        public async Task<Stream> DownloadStreamAsync(string absolutePath)
        {
            var response = await GetHttpResponseMessage(absolutePath);
            var stream = await response.Content.ReadAsStreamAsync();
            return stream;
        }

        private async Task<HttpResponseMessage> GetHttpResponseMessage(string absolutePath)
        {
            var connectionAttempts = 0;
            var absoluteUri = absolutePath.StartsWith("https://")
                ? new Uri(absolutePath)
                : new Uri(VtBaseUrl, absolutePath);
            while (connectionAttempts < 2)
            {
                var token = await GetToken();

                var httpRequestMessage = new HttpRequestMessage
                {
                    RequestUri = absoluteUri,
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
            if (string.IsNullOrWhiteSpace(json))
                return;

            var token = JToken.Parse(json);
            if (token.Type != JTokenType.Object)
                return;

            token = token.First.First;
            
            if (token.Type != JTokenType.Object ||
                token["error"] == null)
                return;

            throw new ServerException
            {
                Name = token["error"].Value<string>(),
                Description = token["errorText"].Value<string>()
            };
        }

        public void Dispose()
        {
            HttpClient.Dispose();
        }
    }
}
