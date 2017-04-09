using Newtonsoft.Json;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// List of coordinates route passes through
    /// </summary>
    public class GeometryPoint
    {
        /// <summary>
        /// Latitude
        /// </summary>
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        [JsonProperty("lon")]
        public double Longitude { get; set; }

        /// <summary>
        /// Index
        /// </summary>
        [JsonProperty("Idx")]
        public string Index { get; set; }

        /// <summary>
        /// Altitude
        /// </summary>
        public int? Altitude { get; set; }
    }
}