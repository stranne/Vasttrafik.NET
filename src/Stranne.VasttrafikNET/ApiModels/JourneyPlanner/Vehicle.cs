using Newtonsoft.Json;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner.Enums;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// Vehicle
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Line color of the journey
        /// </summary>
        [JsonProperty("lcolor")]
        public string LineColor { get; set; }

        /// <summary>
        /// Journey type
        /// </summary>
        public JourneyType ProdClass { get; set; }

        /// <summary>
        /// Background color of the journey
        /// </summary>
        [JsonProperty("bcolor")]
        public string BackgroundColor { get; set; }

        /// <summary>
        /// Direction of the vehicle. This is a value between 0 and 31 which is describing a direction vector.
        /// </summary>
        public int Direction { get; set; }

        /// <summary>
        /// Journey name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Service global identifier
        /// </summary>
        public string Gid { get; set; }

        /// <summary>
        /// Current delay of the vehicle in minutes
        /// </summary>
        public int Delay { get; set; }

        /// <summary>
        /// Y coordinate (latitude) of the position in WGS84
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// X coordinate (longitude) of the position in WGS84
        /// </summary>
        public double X { get; set; }
    }
}