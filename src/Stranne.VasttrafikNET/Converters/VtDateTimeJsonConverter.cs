using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Stranne.VasttrafikNET.Converters
{
    internal class VtDateTimeJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var data = JObject.Load(reader);
            return data.First.First.Value<DateTime>();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        public override bool CanWrite => false;
    }
}
