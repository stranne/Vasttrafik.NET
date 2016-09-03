namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// Arrival to stop
    /// </summary>
    public class Arrival : BoardEntry
    {
        /// <summary>
        /// Starting stop
        /// </summary>
        public string Origin { get; set; }
    }
}