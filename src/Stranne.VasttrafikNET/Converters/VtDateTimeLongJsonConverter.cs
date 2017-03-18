using System;
using Newtonsoft.Json;

namespace Stranne.VasttrafikNET.Converters
{
    internal class VtDateTimeLongJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(((DateTime)value).ToString("yyyyMMddHHmmss"));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime?) || objectType == typeof(DateTime);
        }

        public override bool CanRead => false;
    }
}
