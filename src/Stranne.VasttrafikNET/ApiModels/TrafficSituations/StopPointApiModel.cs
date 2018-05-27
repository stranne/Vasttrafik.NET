namespace Stranne.VasttrafikNET.ApiModels.TrafficSituations
{
    /// <summary>
    /// Stop point.
    /// </summary>
    public class StopPointApiModel
    {
        /// <summary>
        /// Stop area short name. Example data: "Öxnered stn".
        /// </summary>
        public string StopAreaShortName { get; set; }

        /// <summary>
        /// Stop area name. Example data: "Öxnered station (tåg)".
        /// </summary>
        public string StopAreaName { get; set; }

        /// <summary>
        /// Global unique identifier for the stop area. Example data: 9021014080800000.
        /// </summary>
        public string StopAreaGid { get; set; }

        /// <summary>
        /// Stop point name. Example data: "Öxnered station (tåg)".
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Global unique identifier for the stop point. Example data: 9022014003310004.
        /// </summary>
        public string Gid { get; set; }

        /// <summary>
        /// Stop point short name. Example data: "Öxnered stn".
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Number of the municipality in which the stop point is located. Example data : 1402.
        /// </summary>
        public int MunicipalityNumber { get; set; }

        /// <summary>
        /// Name of the municipality in which the stop point is located. Example data: "Partille".
        /// </summary>
        public string MunicipalityName { get; set; }
    }
}