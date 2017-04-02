using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner.Enums;
using Stranne.VasttrafikNET.Converters;
using Stranne.VasttrafikNET.Extensions;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// Trip stop
    /// </summary>
    public class TripStop
    {
        /// <summary>
        /// Route index of a stop/station. Can be used as a reference of the stop/station in a <see cref="IJourneyPlannerService.GetJourneyDetailAsync(JourneyDetailReference)"/> response
        /// </summary>
        [JsonProperty("routeIdx")]
        public string RouteIndex { get; set; }

        /// <summary>
        /// True if departure/arrival at this stop is cancelled
        /// </summary>
        public bool Cancelled { get; set; }

        /// <summary>
        /// Type of location
        /// </summary>
        [JsonProperty("type")]
        public LocationType LocationType { get; set; }

        /// <summary>
        /// List of notes related, if any
        /// </summary>
        [JsonConverter(typeof(ListIntermediateClassSkipJsonConverter))]
        public IEnumerable<Note> Notes { get; set; }

        /// <summary>
        /// ID of this stop
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Track information, if available
        /// </summary>
        public string Track { get; set; }

        /// <summary>
        /// Realtime track information, if available
        /// </summary>
        [JsonProperty("rtTrack")]
        public string RealtimeTrack { get; set; }

        [JsonProperty]
        internal string RtDate { get; set; }

        [JsonProperty]
        internal string RtTime { get; set; }

        [JsonProperty]
        internal string Date { get; set; }

        [JsonProperty]
        internal string Time { get; set; }

        [JsonProperty]
        internal string Directtime { get; set; }

        [JsonProperty]
        internal string Directdate { get; set; }

        /// <summary>
        /// Contains the name of the location
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateTime => $"{Date} {Time}".ToDateTime();

        /// <summary>
        /// Realtime
        /// </summary>
        public DateTime? RealtimeDateTime => $"{RtDate} {RtTime}".ToDateTimeNullable();

        /// <summary>
        /// Based on the direct travel time
        /// </summary>
        public DateTime? DirectDateTime => $"{Directdate} {Directtime}".ToDateTimeNullable();

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            if (Notes == null) Notes = new List<Note>();
        }
    }
}