using Newtonsoft.Json;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner.Enums;
using Stranne.VasttrafikNET.Converters;

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
        /// Direction of the vehicle described in angle 0-360.
        /// </summary>
        [JsonConverter(typeof(VtDirectionJsonConverter))]
        public double Direction { get; set; }

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
        [JsonConverter(typeof(StringToIntJsonConverter))]
        public int Delay { get; set; }

        /// <summary>
        /// Y coordinate (latitude) of the position in WGS84
        /// </summary>
        [JsonConverter(typeof(StringToCoordinateDoubleJsonConverter))]
        public double Y { get; set; }

        /// <summary>
        /// X coordinate (longitude) of the position in WGS84
        /// </summary>
        [JsonConverter(typeof(StringToCoordinateDoubleJsonConverter))]
        public double X { get; set; }
    }
}