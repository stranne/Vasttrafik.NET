using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Converters;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// Time table data
    /// </summary>
    public class TimeTableData
    {
        /// <summary>
        /// Creation date of timetable
        /// </summary>
        [JsonConverter(typeof(VtDateTimeJsonConverter))]
        public DateTimeOffset CreationDate { get; set; }
    }
}