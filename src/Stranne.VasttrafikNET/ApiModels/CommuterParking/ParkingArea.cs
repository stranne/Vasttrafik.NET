using System.Collections.Generic;

namespace Stranne.VasttrafikNET.ApiModels.CommuterParking
{
    /// <summary>
    /// Parking area
    /// </summary>
    public class ParkingArea
    {
        /// <summary>
        /// Name of parking area
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Related stop areas
        /// </summary>
        public IEnumerable<StopArea> StopAreas { get; set; }

        /// <summary>
        /// Id of parking area
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Related parking lots
        /// </summary>
        public IEnumerable<ParkingLot> ParkingLots { get; set; }
    }
}
