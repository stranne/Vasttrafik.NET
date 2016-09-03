using Newtonsoft.Json;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// Journey id
    /// </summary>
    public class JourneyId
    {
        /// <summary>
        /// Journey id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// <see cref="JourneyId"/> is used from stop index
        /// </summary>
        /// <example>0</example>
        [JsonProperty("routeIdxFrom")]
        public int RouteIndexFrom { get; set; }

        /// <summary>
        /// <see cref="JourneyId"/> is used to stop index
        /// </summary>
        /// <example>31</example>
        [JsonProperty("routeIdxTo")]
        public int RouteIndexTo { get; set; }
    }
}