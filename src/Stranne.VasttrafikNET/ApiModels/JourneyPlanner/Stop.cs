using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Extensions;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// Stop
    /// </summary>
    public class Stop
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Route Idx
        /// </summary>
        [JsonProperty("routeIdx")]
        public string RouteIndex { get; set; }

        /// <summary>
        /// Stop id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Stop longitude
        /// </summary>
        [JsonProperty("lon")]
        public double Longitude { get; set; }

        /// <summary>
        /// Stop latitude
        /// </summary>
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        
        [JsonProperty]
        internal string DepTime { get; set; }

        [JsonProperty]
        internal string DepDate { get; set; }

        /// <summary>
        /// Departure datetime
        /// </summary>
        public DateTime? DepartureDateTime => $"{DepDate} {DepTime}".ToDateTimeNullable();
                                                              
        [JsonProperty]
        internal string ArrTime { get; set; }

        [JsonProperty]
        internal string ArrDate { get; set; }

        /// <summary>
        /// Arrival datetime
        /// </summary>
        public DateTime? ArrivalDateTime => $"{ArrDate} {ArrTime}".ToDateTimeNullable();

        /// <summary>
        /// Track
        /// </summary>
        public string Track { get; set; }

        [JsonProperty]
        internal string RtDepTime { get; set; }

        [JsonProperty]
        internal string RtDepDate { get; set; }

        /// <summary>
        /// Real time departure datetime
        /// </summary>
        public DateTime? RtDepartureDateTime => $"{RtDepDate} {RtDepDate}".ToDateTimeNullable();

        [JsonProperty]
        internal string RtArrTime { get; set; }

        [JsonProperty]
        internal string RtArrDate { get; set; }

        /// <summary>
        /// Real time arrival datetime
        /// </summary>
        public DateTime? RtArrivalDateTime => $"{RtArrDate} {RtArrTime}".ToDateTimeNullable();

        /// <summary>
        /// Real time track
        /// </summary>
        public string RtTrack { get; set; }
    }
}