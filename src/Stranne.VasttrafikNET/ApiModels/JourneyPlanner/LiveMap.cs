using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// List vehicles within a rectangular area
    /// </summary>
    public class LiveMap
    {
        /// <summary>
        /// Right border (longitude), max x, of the bounding box in WGS84
        /// </summary>
        [JsonProperty("maxX")]
        public double LongitudeMax { get; set; }

        /// <summary>
        /// Upper border (latitude), max y, of the bounding box in WGS84
        /// </summary>
        [JsonProperty("maxY")]
        public double LatitudeMax { get; set; }

        /// <summary>
        /// Left border (longitude), min x, of the bounding box in WGS84
        /// </summary>
        [JsonProperty("minX")]
        public double LongitudeMin { get; set; }

        /// <summary>
        /// Lower border (latitude), min y, of the bounding box in WGS84
        /// </summary>
        [JsonProperty("minY")]
        public double LatitudeMin { get; set; }

        /// <summary>
        /// List of vehicles
        /// </summary>
        public IEnumerable<Vehicle> Vehicles { get; set; }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            if (Vehicles == null) Vehicles = new List<Vehicle>();
        }
    }
}
