using Stranne.VasttrafikNET.Models;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// Stop location
    /// </summary>
    public class StopLocation : AbstractLocation
    {
        /// <summary>
        /// This ID can either be used as <see cref="BoardOptions.Id"/> in <see cref="IJourneyPlannerService.GetArrivalBoardAsync(BoardOptions)"/> or 
        /// <see cref="IJourneyPlannerService.GetDepartureBoardAsync(BoardOptions)"/> methods, as <see cref="TripOptions.OriginId"/> or
        /// <see cref="TripOptions.DestId"/> in <see cref="IJourneyPlannerService.GetTripAsync(TripOptions)"/> method
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// This value specifies some kind of importance of this stop. The more traffic at this stop the higher the weight.
        /// The range is between 0 and 32767. This attribute is only contained in the <see cref="IJourneyPlannerService.GetLocationAllStopsAsync"/> method
        /// </summary>
        public decimal? Weight { get; set; }

        /// <summary>
        /// Track information, if available. Can be null when refering to a stop in general, compare to a stop's specific track.
        /// </summary>
        public string Track { get; set; }
    }
}