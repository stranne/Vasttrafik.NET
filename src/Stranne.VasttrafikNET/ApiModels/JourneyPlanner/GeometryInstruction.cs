using Newtonsoft.Json;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// Geometry Instruction
    /// </summary>
    public class GeometryInstruction
    {
        /// <summary>
        /// Distance
        /// </summary>
        [JsonProperty("dist")]
        public string Distance { get; set; }

        /// <summary>
        /// Point Index
        /// </summary>
        [JsonProperty("PointIdx")]
        public string PointIndex { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }
    }
}