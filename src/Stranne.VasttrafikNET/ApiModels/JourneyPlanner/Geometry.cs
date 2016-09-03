using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Converters;
using Stranne.VasttrafikNET.Extensions;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// Describes a road map for a route
    /// </summary>
    public class Geometry
    {
        /// <summary>
        /// List of coordinates which the route passes through, can be used to plot route on map
        /// </summary>
        [JsonConverter(typeof(ListIntermediateClassSkipJsonConverter))]
        public IEnumerable<GeometryPoint> Points { get; set; }

        /// <summary>
        /// Itineraries
        /// </summary>
        [JsonProperty("itinerary")]
        public IEnumerable<GeometryInstruction> Itineraries { get; set; }

        [JsonProperty]
        internal string Serverdate { get; set; }

        [JsonProperty]
        internal string Servertime { get; set; }
        
        internal DateTime ServerDateTime => $"{Serverdate} {Servertime}".ToDateTime();

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            if (Points == null) Points = new List<GeometryPoint>();
            if (Itineraries == null) Itineraries = new List<GeometryInstruction>();
        }
    }
}
