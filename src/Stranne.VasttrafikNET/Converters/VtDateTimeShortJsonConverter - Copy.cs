using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Extensions;

namespace Stranne.VasttrafikNET.Converters
{
    internal class VtDateTimeMediumJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(((DateTimeOffset)value).ConvertToVasttrafikTimeZone().ToString("yyyyMMddHHmm"));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTimeOffset?) || objectType == typeof(DateTimeOffset);
        }

        public override bool CanRead => false;
    }
}
