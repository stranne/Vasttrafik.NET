using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Stranne.VasttrafikNET.ApiModels.TrafficSituations.Enum;

namespace Stranne.VasttrafikNET.ApiModels.TrafficSituations
{
    /// <summary>
    /// A traffic situation.
    /// </summary>
    public class TrafficSituationApiModel
    {
        /// <summary>
        /// Date and time when the traffic situation started, or is expected to start.
        /// </summary>
        public DateTimeOffset StartTime { get; set; }

        /// <summary>
        /// List of affected <see cref="LineApiModel"/>.
        /// </summary>
        public IEnumerable<LineApiModel> AffectedLines { get; set; }

        /// <summary>
        /// Brief description of the traffic situation. Example data: "Linje X, hållplats HPL är tillfälligt indragen mot DEST/HPL på grund av X."
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// List of affected <see cref="StopPointApiModel"/>.
        /// </summary>
        public IEnumerable<StopPointApiModel> AffectedStopPoints { get; set; }

        /// <summary>
        /// Detailed description of the traffic situation. Example data: "Närmaste hållplats är HPL och HPL. (Detta beräknas pågå från DATUM klockan HH:MM till DATUM klockan HH:MM.)"
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The severity of the traffic situation.
        /// </summary>
        public TrafficSituationSeverity Severity { get; set; }

        /// <summary>
        /// Date and time when the traffic situation was reported.
        /// </summary>
        public DateTimeOffset CreationTime { get; set; }

        /// <summary>
        /// Date and time when the traffic situation ended, or is expected to end.
        /// </summary>
        public DateTimeOffset EndTime { get; set; }

        /// <summary>
        /// List of <see cref="JourneyApiModel"/>.
        /// </summary>
        public IEnumerable<JourneyApiModel> AffectedJourneys { get; set; }

        /// <summary>
        /// Traffic situation number. Example data: "2001186014".
        /// </summary>
        public string SituationNumber { get; set; }
    }
}
