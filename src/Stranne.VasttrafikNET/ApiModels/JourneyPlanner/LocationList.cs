using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Extensions;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// List stops and coordinates
    /// </summary>
    public class LocationList
    {
        [JsonProperty]
        internal string Serverdate { get; set; }

        [JsonProperty]
        internal string Servertime { get; set; }
        
        internal DateTimeOffset ServerDateTime => $"{Serverdate} {Servertime}".ToDateTimeOffset();
        
        /// <summary>
        /// List of stops or stations
        /// </summary>
        public IEnumerable<StopLocation> StopLocation { get; set; }

        /// <summary>
        /// List of addresses or points of interest
        /// </summary>
        public IEnumerable<CoordLocation> CoordLocation { get; set; }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            if (StopLocation == null) StopLocation = new List<StopLocation>();
            if (CoordLocation == null) CoordLocation = new List<CoordLocation>();
        }
    }
}
