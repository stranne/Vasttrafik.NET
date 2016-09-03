namespace Stranne.VasttrafikNET.Models
{
    /// <summary>
    /// Describes a coordinate in WGS84 decimal
    /// </summary>
    public class Coordinate
    {
        /// <summary>
        /// Latitude in WGS84 decimal form
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude in WGS84 decimal form
        /// </summary>
        public double Longitude { get; set; }
    }
}