using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.ApiModels.TrafficSituations.Enum;

namespace Stranne.VasttrafikNET.Converters
{
    internal class TrafficSituationsSeverityJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString().ToLower();

            switch (value)
            {
                case "slight":
                    return TrafficSituationSeverity.Slight;
                case "normal":
                    return TrafficSituationSeverity.Normal;
                case "severe":
                    return TrafficSituationSeverity.Severe;
                default:
                    throw new ArgumentException($"{nameof(TrafficSituationSeverity)} value {value} isn't recognized.");
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TrafficSituationSeverity);
        }

        public override bool CanWrite => false;
    }
}
