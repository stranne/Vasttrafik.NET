using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// List vehicles within a rectangular area
    /// </summary>
    public class LiveMap
    {
        internal string Time { get; set; }
        
        /// <summary>
        /// Right border (longitude) of the bounding box in WGS84
        /// </summary>
        public double MaxX { get; set; }

        /// <summary>
        /// Upper border (latitude) of the bounding box in WGS84
        /// </summary>
        public double MaxY { get; set; }

        /// <summary>
        /// Left border (longitude) of the bounding box in WGS84
        /// </summary>
        public double MinX { get; set; }

        /// <summary>
        /// Lower border (latitude) of the bounding box in WGS84
        /// </summary>
        public double MinY { get; set; }

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
