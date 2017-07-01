using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Extensions;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    internal class TripList
    {
        [JsonProperty]
        internal string Serverdate { get; set; }

        [JsonProperty]
        internal string Servertime { get; set; }
        
        public DateTimeOffset ServerDateTime => $"{Serverdate} {Servertime}".ToDateTimeOffset();
        
        [JsonProperty("Trip")]
        public IEnumerable<Trip> Trips { get; set; }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            if (Trips == null) Trips = new List<Trip>();
        }
    }
}