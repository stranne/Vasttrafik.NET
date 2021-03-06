﻿namespace Stranne.VasttrafikNET.ApiModels.CommuterParking
{
    /// <summary>
    /// Parking type
    /// </summary>
    public class ParkingType
    {
        /// <summary>
        /// Name, e.g. CARPARK or SMARTCARPARK.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Number
        /// </summary>
        public int Number { get; set; }
    }
}