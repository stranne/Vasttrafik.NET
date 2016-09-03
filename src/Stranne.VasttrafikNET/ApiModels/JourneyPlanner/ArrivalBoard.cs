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

        public string Error { get; set; }

        [JsonProperty]
        internal string ServerTime { get; set; }

        [JsonProperty]
        internal string ServerDate { get; set; }

        public DateTime ServerDateTime => $"{ServerDate} {ServerTime}".ToDateTime();

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            if (Arrivals == null) Arrivals = new List<Arrival>();
        }
    }
}
