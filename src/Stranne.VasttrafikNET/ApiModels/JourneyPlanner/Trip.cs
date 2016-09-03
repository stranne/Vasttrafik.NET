using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner.Enums;

namespace Stranne.VasttrafikNET.ApiModels.JourneyPlanner
{
    /// <summary>
    /// Trip
    /// </summary>
    public class Trip
    {
        /// <summary>
        /// Contains details for trip
        /// </summary>
        [JsonProperty("leg")]
        public IEnumerable<Leg> Legs { get; set; }

        /// <summary>
        /// IMPORTANT NOTE: journeys that are presented when the default change margin has been
        /// disregarded are not covered by Västtrafiks travel warranty (Swedish: förseningsersättning)
        /// </summary>
        public bool TravelWarrenty { get; set; } = true;

        /// <summary>
        /// The state indicates if the trip is still possible to ride based on the current realtime situation
        /// </summary>
        public bool Valid { get; set; } = true;

        /// <summary>
        /// The type indicates whether this is an original connection or an realtime alternative
        /// </summary>
        public bool Alternative { get; set; } = false;

        /// <summary>
        /// Type of trip
        /// </summary>
        public TripType? Type { get; set; }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            if (Legs == null) Legs = new List<Leg>();
        }
    }
}
