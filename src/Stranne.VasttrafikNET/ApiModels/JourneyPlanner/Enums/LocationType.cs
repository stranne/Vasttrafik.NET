namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner.Enums
{
    /// <summary>
    /// Type of location
    /// </summary>
    public enum LocationType
    {
        /// <summary>
        /// Address
        /// </summary>
        Address = 1,
        /// <summary>
        /// Point of interest
        /// </summary>
        PointOfInterest = 2,
        /// <summary>
        /// Stop or station, only avalible in <see cref="TripStop.LocationType"/>
        /// </summary>
        StopOrStation = 3
    }
}