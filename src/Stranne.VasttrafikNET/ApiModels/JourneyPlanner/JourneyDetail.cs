using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Extensions;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// Journey detail
    /// </summary>
    public class JourneyDetail
    {
        /// <summary>
        /// List of stops
        /// </summary>
        [JsonProperty("Stop")]
        public IEnumerable<Stop> Stops { get; set; }

        /// <summary>
        /// Geometry reference
        /// </summary>
        [JsonProperty("geometryRef")]
        public GeometryReference GeometryReference { get; set; }

        /// <summary>
        /// List of journey names throughout journey
        /// </summary>
        [JsonProperty("JourneyName")]
        public IEnumerable<JourneyName> JourneyNames { get; set; }

        /// <summary>
        /// List of journey types throughout journey
        /// </summary>
        [JsonProperty("JourneyType")]
        public IEnumerable<JourneyDetailType> JourneyTypes { get; set; }

        /// <summary>
        /// Color
        /// </summary>
        public JourneyDetailColor Color { get; set; }

        /// <summary>
        /// List of journey ids throughout journey
        /// </summary>
        [JsonProperty("JourneyId")]
        public IEnumerable<JourneyId> JourneyIds { get; set; }

        /// <summary>
        /// Notes related to jorney, if any
        /// </summary>
        public IEnumerable<JourneyDetailNote> Notes { get; set; }

        /// <summary>
        /// List of direction through outjourney
        /// </summary>
        public IEnumerable<JourneyDetailDirection> Direction { get; set; }

        [JsonProperty]
        internal string ServerTime { get; set; }

        [JsonProperty]
        internal string ServerDate { get; set; }
        
        internal DateTime ServerDateTime => $"{ServerDate} {ServerTime}".ToDateTime();

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            if (Stops == null) Stops = new List<Stop>();
            if (JourneyNames == null) JourneyNames = new List<JourneyName>();
            if (JourneyTypes == null) JourneyTypes = new List<JourneyDetailType>();
            if (JourneyIds == null) JourneyIds = new List<JourneyId>();
            if (Notes == null) Notes = new List<JourneyDetailNote>();
            if (Direction == null) Direction = new List<JourneyDetailDirection>();
        }
    }
}
