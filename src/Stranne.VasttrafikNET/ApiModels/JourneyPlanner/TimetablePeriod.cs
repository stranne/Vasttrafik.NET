﻿using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Converters;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// Time table period
    /// </summary>
    public class TimeTablePeriod
    {
        /// <summary>
        /// Begin of timetable
        /// </summary>
        [JsonConverter(typeof(VtDateTimeJsonConverter))]
        public DateTime DateBegin { get; set; }

        /// <summary>
        /// End of timetable
        /// </summary>
        [JsonConverter(typeof(VtDateTimeJsonConverter))]
        public DateTime DateEnd { get; set; }
    }
}