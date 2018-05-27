namespace Stranne.VasttrafikNET.ApiModels.TrafficSituations
{
    /// <summary>
    /// Direction.
    /// </summary>
    public class DirectionApiModel
    {
        /// <summary>
        /// Name of the direction. Example data: "Kungälv - Göteborg - Mölnlycke".
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Global unique identifier for the line direction. Example data: 9014014620510000.
        /// </summary>
        public string Gid { get; set; }

        /// <summary>
        /// Line direction code. For internal use only. Example data: 1, 2.
        /// </summary>
        public int DirectionCode { get; set; }
    }
}