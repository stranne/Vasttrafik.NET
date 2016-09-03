using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Extensions;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    internal class DepartureBoard
    {
        [JsonProperty("Departure")]
        public IEnumerable<Departure> Departures { get; set; }

        public string Error { get; set; }

        [JsonProperty]
        internal string ServerTime { get; set; }

        [JsonProperty]
        internal string ServerDate { get; set; }

        public DateTime ServerDateTime => $"{ServerDate} {ServerTime}".ToDateTime();

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            if (Departures == null) Departures = new List<Departure>();
        }
    }
}
