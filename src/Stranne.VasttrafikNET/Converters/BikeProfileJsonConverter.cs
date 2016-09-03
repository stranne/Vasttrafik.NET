using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Models.Enums;

namespace Stranne.VasttrafikNET.Converters
{
    internal class BikeProfileJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            switch ((BikeProfile) value)
            {
                case BikeProfile.Easy:
                    writer.WriteRawValue("E");
                    break;
                case BikeProfile.Normal:
                    writer.WriteRawValue("N");
                    break;
                case BikeProfile.Powerful:
                    writer.WriteRawValue("P");
                    break;
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(BikeProfile);
        }

        public override bool CanRead => false;
    }
}
