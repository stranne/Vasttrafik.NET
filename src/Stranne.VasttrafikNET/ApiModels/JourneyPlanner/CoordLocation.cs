using Newtonsoft.Json;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner.Enums;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// A location refering to an address or point of interest
    /// </summary>
    public class CoordLocation : AbstractLocation
    {
        /// <summary>
        /// Type of location
        /// </summary>
        [JsonProperty("type")]
        public LocationType LocationType { get; set; }
    }
}