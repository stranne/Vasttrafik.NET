using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Stranne.VasttrafikNET.Attributes;
using Stranne.VasttrafikNET.Converters;
using Stranne.VasttrafikNET.Exceptions;
using Stranne.VasttrafikNET.Extensions;
using Stranne.VasttrafikNET.Models;

namespace Stranne.VasttrafikNET.Service
{
    internal abstract class BaseHandlingService : IDisposable
    {
        protected abstract string ApiPathUrl { get; }

        public NetworkService NetworkService { get; set; }

        internal readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            Converters = new JsonConverter[]
            {
                new BoolJsonConverter(),
                new SingleListJsonConverter(),
                new LocationTypeJsonConverter(),
                new JourneyTypeJsonConverter()
            },
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        protected BaseHandlingService(string vtKey, string vtSecret, string vtDeviceId)
        {
            NetworkService = new NetworkService(vtKey, vtSecret, vtDeviceId);
        }

        public async Task<T> GetAsync<T>(string featureUrl, object parameters)
        {
            var isFeatureUrlAbsolute = featureUrl.StartsWith("https://");
            var skipQueryStringQuestionMark = featureUrl.Contains("?");
            var absolutePathUrl = $"{(isFeatureUrlAbsolute ? "" : ApiPathUrl)}{featureUrl}{BuildParameterString(parameters, skipQueryStringQuestionMark)}";
            return await GetAsyncAbsolute<T>(absolutePathUrl);
        }

        public async Task<T> GetAsync<T>(string featureUrl)
        {
            return await GetAsyncAbsolute<T>($"{ApiPathUrl}{featureUrl}");
        }

        public async Task<T> GetAsyncAbsolute<T>(string absolutePathUrl)
        {
            if (typeof(T) == typeof(Stream))
                return (dynamic)await NetworkService.DownloadStreamAsync(absolutePathUrl);

            var json = await NetworkService.DownloadStringAsync(absolutePathUrl);
            if (json == null)
                return default(T);

            var data = JsonConvert.DeserializeObject<T>(json, JsonSerializerSettings);
            return data;
        }

        public static string BuildParameterString(object parameters, bool skipQueryStringQuestionMark = false)
        {
            var queryParameters = new Dictionary<string, string>();
            var pathParameters = new Dictionary<int, string>();
            var missingParameters = new List<string>();

            var properties = parameters?.GetType().GetRuntimeProperties() ?? new PropertyInfo[0];
            foreach (var property in properties.OrderBy(property => property.Name))
            {
                var parameterAttribute = property.GetCustomAttribute<ParameterAttribute>();
                if (parameterAttribute == null)
                    continue;

                var defaultValue = parameterAttribute.DefaultValue;
                var actualValue = property.GetValue(parameters);

                var parameterName = parameterAttribute.ParameterName ?? property.Name.ToCamelCase();

                if (parameterAttribute.Required && (
                        actualValue == null ||
                        (
                            property.PropertyType == typeof(DateTimeOffset) &&
                            Equals(actualValue, new DateTimeOffset())
                        )
                    ))
                {
                    missingParameters.Add(property.Name);
                    continue;
                }

                if (Equals(defaultValue, actualValue))
                    continue;

                var jsonConverterAttribute = property.GetCustomAttribute<JsonConverterAttribute>();
                if (jsonConverterAttribute != null)
                    actualValue = JsonConvert.SerializeObject(actualValue, (JsonConverter)Activator.CreateInstance(jsonConverterAttribute.ConverterType));

                if (!parameterAttribute.QueryString)
                {
                    pathParameters.Add(parameterAttribute.Order, actualValue.ToString());
                    continue;
                }

                if (property.PropertyType == typeof(bool))
                    actualValue = (bool)actualValue ? 1 : 0;
                else if (property.PropertyType == typeof(double?))
                    actualValue = ((double?)actualValue).Value.ToString(new CultureInfo("en-US"));
                else if (property.PropertyType == typeof(DateTimeOffset) || property.PropertyType == typeof(DateTimeOffset?))
                {
                    var dateTimeOffset = ((DateTimeOffset)actualValue).ConvertToVasttrafikTimeZone();
                    queryParameters.Add("date", dateTimeOffset.ToString("yyyy-MM-dd"));
                    queryParameters.Add("time", dateTimeOffset.ToString("HH:mm"));
                    continue;
                }
                else if (property.PropertyType == typeof(TimeSpan?))
                    actualValue = (int)Math.Round(((TimeSpan)actualValue).TotalMinutes);
                else if (property.PropertyType == typeof(Coordinate))
                {
                    if (parameterName == "coordinate")
                    {
                        queryParameters.Add("lat", ((Coordinate)actualValue).Latitude.ToString(new CultureInfo("en-US")));
                        queryParameters.Add("lon", ((Coordinate)actualValue).Longitude.ToString(new CultureInfo("en-US")));
                        continue;
                    }
                    parameterName = parameterName.Substring(0, parameterName.IndexOf("Coordinate", StringComparison.Ordinal));
                    queryParameters.Add($"{parameterName}CoordLat", ((Coordinate)actualValue).Latitude.ToString(new CultureInfo("en-US")));
                    queryParameters.Add($"{parameterName}CoordLong", ((Coordinate)actualValue).Longitude.ToString(new CultureInfo("en-US")));
                    continue;
                }

                queryParameters.Add(parameterName, actualValue.ToString());
            }

            if (missingParameters.Any())
                throw new MissingRequiredParameterException(missingParameters);

            queryParameters.Add("format", "json");

            var pathUrl = string.Join("", pathParameters.OrderBy(pair => pair.Key).Select(pair => $"/{pair.Value}"));
            var queryUrl = $"{(skipQueryStringQuestionMark ? "" : "?")}{string.Join("&", queryParameters.Select(queryParameter => $"{queryParameter.Key}={queryParameter.Value}"))}";
            return $"{pathUrl}{queryUrl}";
        }

        public void Dispose()
        {
            NetworkService.Dispose();
        }
    }
}
