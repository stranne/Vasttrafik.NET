using System;
using Newtonsoft.Json;

namespace Stranne.VasttrafikNET.Converters
{
    internal class VtDirectionJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return double.Parse(reader.Value.ToString()) * 11.25d;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(double);
        }

        public override bool CanWrite => false;
    }
}
