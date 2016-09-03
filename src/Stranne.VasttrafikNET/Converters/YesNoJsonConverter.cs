using System;
using Newtonsoft.Json;

namespace Stranne.VasttrafikNET.Converters
{
    internal class YesNoJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue((bool) value ? "yes" : "no");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(bool);
        }

        public override bool CanRead => false;
    }
}
