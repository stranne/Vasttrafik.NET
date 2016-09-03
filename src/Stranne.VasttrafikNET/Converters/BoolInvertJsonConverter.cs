using System;
using Newtonsoft.Json;

namespace Stranne.VasttrafikNET.Converters
{
    internal class BoolInvertJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return reader.Value.ToString() != "True";
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(bool);
        }

        public override bool CanWrite => false;
    }
}
