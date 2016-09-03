using Newtonsoft.Json;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// Journey Detail Reference
    /// </summary>
    public class JourneyDetailReference
    {
        /// <summary>
        /// Reference
        /// </summary>
        [JsonProperty("ref")]
        public string Reference { get; set; }
    }
}