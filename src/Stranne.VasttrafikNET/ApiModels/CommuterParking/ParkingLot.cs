using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stranne.VasttrafikNET.ApiModels.CommuterParking
{
    /// <summary>
    /// Parking lot
    /// </summary>
    public class ParkingLot
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Parking types
        /// </summary>
        [JsonProperty("parkingType")]
        public IEnumerable<ParkingType> ParkingTypes { get; set; }

        /// <summary>
        /// Total number of parking spaces
        /// </summary>
        public int TotalCapacity { get; set; }

        /// <summary>
        /// Total number of currently free parking spaces, if avalible
        /// </summary>
        public int? FreeSpaces { get; set; }

        /// <summary>
        /// Latitude for parking lot
        /// </summary>
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude for parking lot
        /// </summary>
        [JsonProperty("lon")]
        public double Longitude { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Parking cameras. Numbered 1 and up depending on how many the parking lot has, if any
        /// </summary>
        public IEnumerable<ParkingCamera> ParkingCameras { get; set; }

        /// <summary>
        /// Restricted by barrier
        /// </summary>
        public bool IsRestrictedByBarrier { get; set; }
    }
}