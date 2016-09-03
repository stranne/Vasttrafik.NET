using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner.Enums;
using Stranne.VasttrafikNET.Converters;
using Stranne.VasttrafikNET.Models;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// Specifies a part of a <see cref="Trip"/> with a single means of transportation between two points
    /// </summary>
    public class Leg
    {
        /// <summary>
        /// Foregroundcolor of this line
        /// </summary>
        [JsonProperty("fgColor")]
        public string ForegroundColor { get; set; }

        /// <summary>
        /// True if this journey needs to be booked
        /// </summary>
        public bool Booking { get; set; } = false;

        /// <summary>
        /// Direction information
        /// </summary>
        public string Direction { get; set; }

        /// <summary>
        /// Used in <see cref="IJourneyPlannerService.GetJourneyDetailAsync(JourneyPlanner.JourneyDetailReference)"/>
        /// to aquire <see cref="JourneyDetail"/>
        /// </summary>
        [JsonProperty("journeyDetailRef")]
        public JourneyDetailReference JourneyDetailReference { get; set; }

        /// <summary>
        /// True if this journey is cancelled
        /// </summary>
        public bool Cancelled { get; set; } = false;

        /// <summary>
        /// Energy use
        /// </summary>
        public float? Kcal { get; set; }

        /// <summary>
        /// Leg starting stop
        /// </summary>
        public TripStop Origin { get; set; }

        /// <summary>
        /// Short name of the leg
        /// </summary>
        public string Sname { get; set; }

        /// <summary>
        /// Type of the leg
        /// </summary>
        public JourneyType Type { get; set; }

        /// <summary>
        /// Used in <see cref="IJourneyPlannerService.GetGeometryAsync(JourneyPlanner.GeometryReference)"/> to aquire <see cref="Geometry"/>.
        /// In order to get a value other than <c>null</c> you need to set <see cref="TripOptions.NeedGeo"/> to <c>true</c>.
        /// </summary>
        [JsonProperty("geometryRef")]
        public GeometryReference GeometryReference { get; set; }

        /// <summary>
        /// Backgroundcolor of this line
        /// </summary>
        [JsonProperty("BgColor")]
        public string BackgroundColor { get; set; }

        /// <summary>
        /// List of related notes, if any
        /// </summary>
        [JsonConverter(typeof(ListIntermediateClassSkipJsonConverter))]
        public IEnumerable<Note> Notes { get; set; }

        /// <summary>
        /// ID of the journey
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Stroke style of this line
        /// </summary>
        public string Stroke { get; set; }

        /// <summary>
        /// False if this journey is not reachable due to delay of the feeder
        /// </summary>
        [JsonConverter(typeof(BoolInvertJsonConverter))]
        public bool Reachable { get; set; } = true;

        /// <summary>
        /// Name of the leg
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// True if this journey is a night journey
        /// </summary>
        public bool Night { get; set; } = false;

        /// <summary>
        /// Leg ending stop
        /// </summary>
        public TripStop Destination { get; set; }

        /// <summary>
        /// Percentage of the route that is made up of bike roads
        /// </summary>
        public float? PercentBikeRoad { get; set; }

        /// <summary>
        /// Accessibility on this leg of the trip
        /// </summary>
        public Accessibility Accessibility { get; set; }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            if (Notes == null) Notes = new List<Note>();
        }
    }
}