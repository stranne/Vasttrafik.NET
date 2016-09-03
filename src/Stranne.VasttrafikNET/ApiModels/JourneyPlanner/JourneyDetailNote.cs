using Newtonsoft.Json;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// Journey note
    /// </summary>
    public class JourneyDetailNote
    {
        /// <summary>
        /// Journey note text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Note is valid from stop index. Stop index is the index of all stops for a specific line.
        /// </summary>
        /// <example>0</example>
        [JsonProperty("routeIdxFrom")]
        public string RouteIndexFrom { get; set; }

        /// <summary>
        /// Note is valid used to stop index. Stop index is the index of all stops for a specific line.
        /// </summary>
        /// <example>31</example>
        [JsonProperty("routeIdxTo")]
        public string RouteIndexTo { get; set; }
    }
}