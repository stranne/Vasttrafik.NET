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
            var type = reader.Value.ToString().ToUpper();

            if (type == "VAS")
                return JourneyType.Vasttagen;
            if (type == "LLT")
                return JourneyType.LongDistanceTrain;
            if (type == "REG")
                return JourneyType.RegionalTrain;
            if (type == "BUS")
                return JourneyType.Bus;
            if (type == "BOAT")
                return JourneyType.Boat;
            if (type == "TRAM")
                return JourneyType.Tram;
            if (type == "TAXI")
                return JourneyType.Taxi;
            if (type == "WALK")
                return JourneyType.Walk;
            if (type == "BIKE")
                return JourneyType.Bike;
            if (type == "CAR")
                return JourneyType.Car;

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
