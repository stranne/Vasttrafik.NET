using Newtonsoft.Json;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// Abstract class used by <see cref="CoordLocation"/> and <see cref="StopLocation"/>
    /// </summary>
    public abstract class AbstractLocation
    {
        /// <summary>
        /// The WGS84 longitude
        /// </summary>
        [JsonProperty("lon")]
        public double Longitude { get; set; }

        /// <summary>
        /// This index can be used to reorder the <see cref="StopLocation"/> and <see cref="CoordLocation"/> response to their correct order.
        /// This property is only contained in the <see cref="IJourneyPlannerService.GetLocationNameAsync(string)"/> method. The location with <see cref="Index"/>=1 is the best fitting location.
        /// </summary>
        [JsonProperty("idx")]
        public string Index { get; set; }

        /// <summary>
        /// Contains the output name of the address or point of interest
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The WGS84 latitude
        /// </summary>
        [JsonProperty("lat")]
        public double Latitude { get; set; }
    }
}