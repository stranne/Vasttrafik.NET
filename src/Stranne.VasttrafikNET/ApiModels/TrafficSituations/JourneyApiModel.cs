using Newtonsoft.Json;

namespace Stranne.VasttrafikNET.ApiModels.TrafficSituations
{
    /// <summary>
    /// Journey.
    /// </summary>
    public class JourneyApiModel
    {
        /// <summary>
        /// Global unique identifier for the journey. Example data: 9015014620500001.
        /// </summary>
        public string Gid { get; set; }

        /// <summary>
        /// Reference to a <see cref="LineApiModel"/>.
        /// </summary>
        public LineApiModel Line { get; set; }
    }
}