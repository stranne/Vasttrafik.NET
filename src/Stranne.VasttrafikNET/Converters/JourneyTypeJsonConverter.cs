using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner.Enums;

namespace Stranne.VasttrafikNET.Converters
{
    internal class JourneyTypeJsonConverter : JsonConverter
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
                case "VAS":
                    return JourneyType.Vasttagen;
                case "LLT":
                    return JourneyType.LongDistanceTrain;
                case "REG":
                    return JourneyType.RegionalTrain;
                case "BUS":
                    return JourneyType.Bus;
                case "BOAT":
                    return JourneyType.Boat;
                case "TRAM":
                    return JourneyType.Tram;
                case "TAXI":
                    return JourneyType.Taxi;
                case "WALK":
                    return JourneyType.Walk;
                case "BIKE":
                    return JourneyType.Bike;
                case "CAR":
                    return JourneyType.Car;
            }

            throw new ArgumentException();
        }

        public override bool CanConvert(Type objectType)
        {
            return
                objectType == typeof(JourneyType) ||
                objectType == typeof(JourneyType?);
        }

        public override bool CanWrite => false;
    }
}
