using Newtonsoft.Json;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// Journey name.
    /// </summary>
    public class JourneyName
    {
        /// <summary>
        /// Journey name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name is used from stop index. Stop index is the index of all stops for a specific line.
        /// </summary>
        /// <example>0</example>
        [JsonProperty("routeIdxFrom")]
        public int RouteIndexFrom { get; set; }

        /// <summary>
        /// Name is used to stop index. Stop index is the index of all stops for a specific line.
        /// </summary>
        /// <example>31</example>
        [JsonProperty("routeIdxTo")]
        public int RouteIndexTo { get; set; }
    }
}