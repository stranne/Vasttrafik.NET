using System.Collections.Generic;
using System.Runtime.Serialization;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner;

namespace Stranne.VasttrafikNET.ApiModels.TrafficSituations
{
    /// <summary>
    /// Line.
    /// </summary>
    public class LineApiModel
    {
        /// <summary>
        /// List of <see cref="DirectionApiModel"/>.
        /// </summary>
        public List<DirectionApiModel> Directions { get; set; }

        /// <summary>
        /// Name of the transport authority responsible for operating the line. Example data: "Västtrafik".
        /// </summary>
        public string TransportAuthorityName { get; set; }

        /// <summary>
        /// Line text color. Example data: "FFFFFF".
        /// </summary>
        public string TextColor { get; set; }

        /// <summary>
        /// A code incicating the transport authority responsible for operating the line. Example data: "vt".
        /// </summary>
        public string TransportAuthorityCode { get; set; }

        /// <summary>
        /// Transport mode of the line. Example data: "bus", "tram", "train", "taxi", "ferry".
        /// </summary>
        public string DefaultTransportModeCode { get; set; }

        /// <summary>
        /// Internally used number of the line. Example data: 6205.
        /// </summary>
        public int TechnicalNumber { get; set; }

        /// <summary>
        /// Line background color. Example data: "F03A43".
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// Name of the line. Example data: "Grön express".
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Designation of the line. Example data: "GRÖN", "4".
        /// </summary>
        public string Designation { get; set; }

        /// <summary>
        /// Global unique identifier for the line. Example data: 9011014620500000.
        /// </summary>
        public string Gid { get; set; }

        /// <summary>
        /// List of municipalities.
        /// </summary>
        public IEnumerable<MunicipalityApiModel> Municipalities { get; set; }

        /// <summary>
        /// List of affected stop points global identifiers.
        /// </summary>
        public IEnumerable<string> AffectedStopPointGids { get; set; }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            if (Directions == null) Directions = new List<DirectionApiModel>();
            if (Directions == null) Municipalities = new List<MunicipalityApiModel>();
            if (AffectedStopPointGids == null) AffectedStopPointGids = new List<string>();
        }
    }
}