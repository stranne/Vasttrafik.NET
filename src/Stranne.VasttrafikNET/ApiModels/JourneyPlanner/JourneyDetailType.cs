using Newtonsoft.Json;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner.Enums;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// Journey type
    /// </summary>
    public class JourneyDetailType
    {
        /// <summary>
        /// Journey type
        /// </summary>
        public JourneyType Type { get; set; }

        /// <summary>
        /// Type is used from stop index. Stop index is the index of all stops for a specific line.
        /// </summary>
        /// <example>0</example>
        [JsonProperty("routeIdxFrom")]
        public int RouteIndexFrom { get; set; }

        /// <summary>
        /// Type is used to stop index. Stop index is the index of all stops for a specific line.
        /// </summary>
        /// <example>31</example>
        [JsonProperty("routeIdxTo")]
        public int RouteIndexTo { get; set; }
    }
}