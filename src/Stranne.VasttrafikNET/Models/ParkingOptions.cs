using Stranne.VasttrafikNET.ApiModels.CommuterParking;
using Stranne.VasttrafikNET.Attributes;

namespace Stranne.VasttrafikNET.Models
{
    /// <summary>
    /// Search parameters for <see cref="ParkingArea"/>
    /// </summary>
    public class ParkingOptions
    {
        /// <summary>
        /// Global identifier (GID) of stop area
        /// </summary>
        [Parameter]
        public string StopArea { get; set; }

        /// <summary>
        /// Return only <see cref="ParkingArea"/> in the specified municipality
        /// </summary>
        [Parameter]
        public string Municipality { get; set; }

        /// <summary>
        /// Coordinates to search near
        /// </summary>
        [Parameter]
        public Coordinate Coordinate { get; set; }

        /// <summary>
        /// Distance in km from the coordinate given. Use a value equal or greater than 5. Västtrafik's servers seams to have a problem with a lower value.
        /// </summary>
        [Parameter("dist")]
        public int? Distance { get; set; }

        /// <summary>
        /// Maximum number of <see cref="ParkingArea"/> to return
        /// </summary>
        [Parameter]
        public int? Max { get; set; }
    }
}