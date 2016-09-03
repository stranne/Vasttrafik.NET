using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Models.Enums;

namespace Stranne.VasttrafikNET.Converters
{
    internal class BikeCriterionJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            switch ((BikeCriterion)value)
            {
                case BikeCriterion.DedicatedBikeRoads:
                    writer.WriteRawValue("D");
                    break;
                case BikeCriterion.FastRoute:
                    writer.WriteRawValue("F");
                    break;
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(BikeCriterion);
        }

        public override bool CanRead => false;
    }
}
