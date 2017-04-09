using System;
using Stranne.VasttrafikNET.Attributes;

namespace Stranne.VasttrafikNET.Models
{
    /// <summary>
    /// Search parameters for departure boards and arrival boards
    /// </summary>
    public class BoardOptions
    {
        /// <summary>
        /// Stop id, required
        /// </summary>
        [Parameter(required: true)]
        public string Id { get; set; }

        /// <summary>
        /// Date and time, default is current date and time
        /// </summary>
        [Parameter(required: true)]
        public DateTimeOffset DateTime { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// Stop id in order to get only departures of vehicles with a specified direction
        /// </summary>
        [Parameter]
        public string Direction { get; set; }

        /// <summary>
        /// Trips with Västtågen, true by default
        /// </summary>
        [Parameter(defaultValue: true, parameterName: "useVas")]
        public bool UseVasttagen { get; set; } = true;

        /// <summary>
        /// Trips with long distance trains, true by default
        /// </summary>
        [Parameter(defaultValue: true, parameterName: "useLDTrain")]
        public bool UseLongDistanceTrain { get; set; } = true;

        /// <summary>
        /// Trips with regional trains, true by default
        /// </summary>
        [Parameter(defaultValue: true, parameterName: "useRegTrain")]
        public bool UseRegionalTrain { get; set; } = true;

        /// <summary>
        /// Trips with buses, true by default
        /// </summary>
        [Parameter(defaultValue: true)]
        public bool UseBus { get; set; } = true;

        /// <summary>
        /// Trips with boats, true by default
        /// </summary>
        [Parameter(defaultValue: true)]
        public bool UseBoat { get; set; } = true;

        /// <summary>
        /// Trips with trams, true by default
        /// </summary>
        [Parameter(defaultValue: true)]
        public bool UseTram { get; set; } = true;

        /// <summary>
        /// Journeys which require tel. registration, false by default
        /// </summary>
        [Parameter(defaultValue: false)]
        public bool ExcludeDr { get; set; } = false;

        /// <summary>
        /// To get the next departures in a specified TimeSpan of up to 24 hours. Can be combined with <see cref="MaxDeparturesPerLine"/>. If this property is not set, the result will contain the next 20 departures
        /// </summary>
        [Parameter]
        public TimeSpan? TimeSpan { get; set; } = null;

        /// <summary>
        /// If <see cref="TimeSpan"/> is set you can further reduce the number of returned journeys by adding this parameter,
        /// which will cause only the given number of journeys for every combination of line and direction.
        /// </summary>
        [Parameter]
        public int? MaxDeparturesPerLine { get; set; } = null;

        /// <summary>
        /// Include reference URL for the journey detail service in response, true by default
        /// </summary>
        [Parameter(defaultValue: true)]
        public bool NeedJorneyDetail { get; set; } = true;
    }
}
