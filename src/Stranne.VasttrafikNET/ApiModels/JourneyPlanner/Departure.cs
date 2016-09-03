namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// Departure from stop
    /// </summary>
    public class Departure : BoardEntry
    {
        /// <summary>
        /// Direction information
        /// </summary>
        public string Direction { get; set; }
    }
}