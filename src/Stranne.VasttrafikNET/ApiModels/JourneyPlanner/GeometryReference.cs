using Newtonsoft.Json;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// Geometry referense
    /// </summary>
    public class GeometryReference
    {
        /// <summary>
        /// Reference
        /// </summary>
        [JsonProperty("ref")]
        public string Reference { get; set; }
    }
}