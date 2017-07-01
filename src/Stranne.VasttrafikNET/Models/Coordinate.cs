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

        /// <summary>
        /// Create a new coordinate.
        /// </summary>
        public Coordinate()
        {
        }

        /// <summary>
        /// Create a coordinate with latitude and longitude pre defined.
        /// </summary>
        /// <param name="latitude">Latitude in WGS84 decimal form</param>
        /// <param name="longitude">Longitude in WGS84 decimal form</param>
        public Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}