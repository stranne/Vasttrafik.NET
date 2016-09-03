namespace Stranne.VasttrafikNET.ApiModels.CommuterParking
{
    /// <summary>
    /// Stop or station within a <see cref="ParkingArea"/>
    /// </summary>
    public class StopArea
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Municipality where the stop or station is located
        /// </summary>
        public string Municipality { get; set; }

        /// <summary>
        /// Stop id
        /// </summary>
        public long Gid { get; set; }
    }
}