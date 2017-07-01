using System;
using Newtonsoft.Json;

namespace Stranne.VasttrafikNET.Converters
{
    internal class StringToIntJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return int.Parse(reader.Value.ToString());
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(int);
        }

        public override bool CanWrite => false;
    }
}
