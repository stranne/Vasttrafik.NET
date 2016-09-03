using Newtonsoft.Json;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// Journey direction
    /// </summary>
    public class JourneyDetailDirection
    {
        /// <summary>
        /// <see cref="JourneyDetailDirection"/> is used from stop index
        /// </summary>
        /// <example>0</example>
        [JsonProperty("routeIdxFrom")]
        public int RouteIndexFrom { get; set; }

        /// <summary>
        /// <see cref="JourneyDetailDirection"/> is used to stop index
        /// </summary>
        /// <example>31</example>
        [JsonProperty("routeIdxTo")]
        public int RouteIndexTo { get; set; }

        /// <summary>
        /// Journey direction name
        /// </summary>
        [JsonProperty("$")]
        public string Name { get; set; }
    }
}