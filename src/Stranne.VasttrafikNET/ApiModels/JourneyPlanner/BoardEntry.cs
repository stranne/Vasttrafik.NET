using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner.Enums;
using Stranne.VasttrafikNET.Extensions;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// An entry for either <see cref="Arrival"/> or <see cref="Departure"/> from a stop
    /// </summary>
    public abstract class BoardEntry
    {
        /// <summary>
        /// Journey details reference
        /// </summary>
        [JsonProperty("journeyDetailRef")]
        public JourneyDetailReference JourneyDetailReference { get; set; }

        /// <summary>
        /// Name of the departing journey
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Short name of the leg
        /// </summary>
        [JsonProperty("sname")]
        public string ShortName { get; set; }

        /// <summary>
        /// Type of the departing journey
        /// </summary>
        public JourneyType Type { get; set; }

        /// <summary>
        /// Contains the name of the stop/station
        /// </summary>
        public string Stop { get; set; }

        /// <summary>
        /// Contains the id of the stop/station
        /// </summary>
        public string StopId { get; set; }

        /// <summary>
        /// Contains the id of the journey
        /// </summary>
        public string JourneyId { get; set; }

        [JsonProperty]
        internal string Time { get; set; }

        [JsonProperty]
        internal string Date { get; set; }

        /// <summary>
        /// Timetable
        /// </summary>
        public DateTimeOffset DateTime => $"{Date} {Time}".ToDateTimeOffset();

        /// <summary>
        /// Timetable in minutes
        /// </summary>
        public int Minutes { get; set; }

        /// <summary>
        /// Track information, if available
        /// </summary>
        public string Track { get; set; }

        [JsonProperty]
        internal string RtTime { get; set; }

        [JsonProperty]
        internal string RtDate { get; set; }

        /// <summary>
        /// Realtime date, if available
        /// </summary>
        public DateTimeOffset? RealtimeDateTime => $"{RtDate} {RtTime}".ToDateTimeOffsetNullable();

        /// <summary>
        /// Realtime minutes, if avalible
        /// </summary>
        public int? RealtimeMinutes { get; set; }

        /// <summary>
        /// Realtime track information, if available
        /// </summary>
        [JsonProperty("rtTrack")]
        public string RealtimeTrack { get; set; }

        /// <summary>
        /// True if this journey needs to be booked
        /// </summary>
        public bool Booking { get; set; } = false;

        /// <summary>
        /// True if this journey is a night journey
        /// </summary>
        public bool Night { get; set; } = false;

        /// <summary>
        /// Foregroundcolor of this line
        /// </summary>
        [JsonProperty("fgColor")]
        public string ForegroundColor { get; set; }

        /// <summary>
        /// Backgroundcolor of this line
        /// </summary>
        [JsonProperty("bgColor")]
        public string BackgroundColor { get; set; }

        /// <summary>
        /// Stroke style of this line
        /// </summary>
        public string Stroke { get; set; }

        /// <summary>
        /// Describes accessibility of vehicle
        /// </summary>
        public Accessibility? Accessibility { get; set; }
    }
}