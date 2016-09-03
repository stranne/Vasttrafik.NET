using Newtonsoft.Json;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// Journey Detail Color
    /// </summary>
    public class JourneyDetailColor
    {
        /// <summary>
        /// Foreground color
        /// </summary>
        [JsonProperty("fgColor")]
        public string ForegroundColor { get; set; }

        /// <summary>
        /// Background color
        /// </summary>
        [JsonProperty("bgColor")]
        public string BackgroundColor { get; set; }

        /// <summary>
        /// Stroke
        /// </summary>
        public string Stroke { get; set; }
    }
}