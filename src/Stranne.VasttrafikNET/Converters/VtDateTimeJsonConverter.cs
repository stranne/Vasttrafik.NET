using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Stranne.VasttrafikNET.Extensions;

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
            var dateTimeOffset = new DateTimeOffset(data.First.First.Value<DateTime>());
            return dateTimeOffset.AddVasttrafikTimeSpan();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTimeOffset);
        }

        public override bool CanWrite => false;
    }
}
