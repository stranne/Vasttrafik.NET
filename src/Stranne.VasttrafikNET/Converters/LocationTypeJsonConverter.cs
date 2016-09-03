using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner.Enums;

namespace Stranne.VasttrafikNET.Converters
{
    internal class LocationTypeJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
                return null;

            switch (reader.Value.ToString().ToUpper())
            {
                case "ADR":
                    return LocationType.Address;
                case "POI":
                    return LocationType.PointOfInterest;
                case "ST":
                    return LocationType.StopOrStation;
            }

            throw new ArgumentException();
        }

        public override bool CanConvert(Type objectType)
        {
            return
                objectType == typeof(LocationType) ||
                objectType == typeof(LocationType?);
        }

        public override bool CanWrite => false;
    }
}
