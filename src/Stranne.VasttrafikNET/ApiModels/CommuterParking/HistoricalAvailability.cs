using System;
using Newtonsoft.Json;

namespace Stranne.VasttrafikNET.ApiModels.CommuterParking
{
    /// <summary>
    /// Record of parking availability history
    /// </summary>
    public class HistoricalAvailability
    {
        /// <summary>
        /// Date and time of record
        /// </summary>
        [JsonProperty("Date")]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Number of free parking spaces
        /// </summary>
        public int FreeSpaces { get; set; }
    }
}