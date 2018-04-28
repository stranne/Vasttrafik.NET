using System;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner.Enums;

namespace Stranne.VasttrafikNET.ApiModels.CommuterParking
{
    /// <summary>
    /// Departure from parking area.
    /// </summary>
    public class DestinationDeparture
    {
        /// <summary>
        /// Departure name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Related stop areas
        /// </summary>
        public StopArea StopArea { get; set; }

        /// <summary>
        /// Departure time, HH:mm
        /// </summary>
        public string DepartureTime { get; set; }

        /// <summary>
        /// Type of the departing journey
        /// </summary>
        public JourneyType Type { get; set; } // TODO

        /// <summary>
        /// Short name of the leg
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Departs in minutes
        /// </summary>
        public int DepartsInMinutes { get; set; }

        /// <summary>
        /// Arrival time, HH:mm
        /// </summary>
        public string ArrivalTime { get; set; }

        /// <summary>
        /// Destination
        /// </summary>
        public Destination Destination { get; set; }
    }
}