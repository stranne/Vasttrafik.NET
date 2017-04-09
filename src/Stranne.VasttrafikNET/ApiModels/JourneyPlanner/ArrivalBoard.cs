using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Extensions;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    internal class ArrivalBoard
    {
        [JsonProperty("Arrival")]
        public IEnumerable<Arrival> Arrivals { get; set; }

        [JsonProperty]
        internal string ServerTime { get; set; }

        [JsonProperty]
        internal string ServerDate { get; set; }

        public DateTimeOffset ServerDateTime => $"{ServerDate} {ServerTime}".ToDateTimeOffset();

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            if (Arrivals == null) Arrivals = new List<Arrival>();
        }
    }
}
