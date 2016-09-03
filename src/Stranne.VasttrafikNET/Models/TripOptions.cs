using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner;
using Stranne.VasttrafikNET.Attributes;
using Stranne.VasttrafikNET.Converters;
using Stranne.VasttrafikNET.Models.Enums;

namespace Stranne.VasttrafikNET.Models
{
    /// <summary>
    /// Search parameters for trip
    /// </summary>
    public class TripOptions
    {
        /// <summary>
        /// Origin stop id
        /// </summary>
        [Parameter]
        public string OriginId { get; set; } = null;

        /// <summary>
        /// Origin center coordinate in the WGS84 
        /// </summary>
        [Parameter]
        public Coordinate OriginCoordinate { get; set; } = null;

        /// <summary>
        /// Name of the address at the specified origin coordinate
        /// </summary>
        [Parameter]
        public string OriginCoordName { get; set; } = null;

        /// <summary>
        /// Destination stop id
        /// </summary>
        [Parameter]
        public string DestId { get; set; }

        /// <summary>
        /// Destination center coordinate in the WGS84
        /// </summary>
        [Parameter]
        public Coordinate DestCoordinate { get; set; }

        /// <summary>
        /// Name of the address at the specified destination coordinate	
        /// </summary>
        [Parameter]
        public string DestCoordName { get; set; }

        /// <summary>
        /// Via stop/station id	
        /// </summary>
        [Parameter]
        public string ViaId { get; set; }

        /// <summary>
        /// Date and time of the trip
        /// </summary>
        [Parameter]
        public DateTime? DateTime { get; set; }

        /// <summary>
        /// <see cref="DateTime"/> is not the departure time but the latest time to arrive at the destination, false by default
        /// </summary>
        [Parameter(defaultValue: false)]
        public bool SearchForArrival { get; set; } = false;

        /// <summary>
        /// Trips with Västtågen, true by default
        /// </summary>
        [Parameter(defaultValue: true)]
        public bool UseVas { get; set; } = true;

        /// <summary>
        /// Trips with long distance trains, true by default
        /// </summary>
        [Parameter(defaultValue: true, parameterName: "useLDTrain")]
        public bool UseLdTrain { get; set; } = true;

        /// <summary>
        /// Trips with regional trains, true by default
        /// </summary>
        [Parameter(defaultValue: true)]
        public bool UseRegTrain { get; set; } = true;

        /// <summary>
        /// Trips with buses, true by default
        /// </summary>
        [Parameter(defaultValue: true)]
        public bool UseBus { get; set; } = true;

        /// <summary>
        /// Medical transport lines trips with buses, false by default
        /// </summary>
        [Parameter(defaultValue: false)]
        public bool UseMedical { get; set; } = false;

        /// <summary>
        /// Medical transport connections from the origin, false by default
        /// </summary>
        [Parameter(defaultValue: false)]
        public bool OriginMedicalCon { get; set; } = false;

        /// <summary>
        /// Medical transport connections from the destination, false by default
        /// </summary>
        [Parameter(defaultValue: false)]
        public bool DestMedicalCon { get; set; } = false;

        /// <summary>
        /// Trips where at least one wheelchair space is present in the vehicle, false by default
        /// </summary>
        [Parameter(defaultValue: false)]
        public bool WheelChairSpace { get; set; } = false;

        /// <summary>
        /// Trips with space for stroller, baby carriage or rollator in the vehicle, false by default
        /// </summary>
        [Parameter(defaultValue: false)]
        public bool StrollerSpace { get; set; } = false;

        /// <summary>
        /// Trips where the vehicle is equipped with a low floor section, but not necessarily a ramp or lift, false by default
        /// </summary>
        [Parameter(defaultValue: false)]
        public bool LowFloor { get; set; } = false;

        /// <summary>
        /// Trips where the vehicle is equipped with ramp or lift that allows fully barrier-free boarding and alighting, false by default
        /// </summary>
        [Parameter(defaultValue: false)]
        public bool RampOrLift { get; set; } = false;

        /// <summary>
        /// Trips with boats, true by default
        /// </summary>
        [Parameter(defaultValue: true)]
        public bool UseBoat { get; set; } = true;

        /// <summary>
        /// Trips with trams, true by default
        /// </summary>
        [Parameter(defaultValue: true)]
        public bool UseTram { get; set; } = true;

        /// <summary>
        /// Trips with public transportation, true by default
        /// </summary>
        [Parameter(defaultValue: true)]
        public bool UsePt { get; set; } = true;

        /// <summary>
        /// Exclude journeys which require tel. registration, false by default
        /// </summary>
        [Parameter(defaultValue: false)]
        public bool ExcludeDr { get; set; } = false;

        /// <summary>
        /// Maximum walking distance from/to the coordinate in meters	
        /// </summary>
        [Parameter]
        public int? MaxWalkDist { get; set; } = null;

        /// <summary>
        /// Walking speed given in percent of normal speed, true by default
        /// </summary>
        [Parameter]
        public string WalkSpeed { get; set; } = null;

        /// <summary>
        /// Trips with walks from/to origin coordinates, true by default
        /// </summary>
        [Parameter(defaultValue: true)]
        public bool OriginWalk { get; set; } = true;

        /// <summary>
        /// Trips with walks from/to destination coordinates, true by default
        /// </summary>
        [Parameter(defaultValue: true)]
        public bool DestWalk { get; set; } = true;

        /// <summary>
        /// Walk-only trips, false by default
        /// </summary>
        [Parameter(defaultValue: false)]
        public bool OnlyWalk { get; set; } = false;

        /// <summary>
        /// Trips with a bike ride from the origin to a nearby stop, where the journey continues using public transport, false by default
        /// </summary>
        [Parameter(defaultValue: false)]
        public bool OriginBike { get; set; } = false;


        /// <summary>
        /// Maximum biking distance from/to the coordinate in meters	
        /// </summary>
        [Parameter]
        public int? MaxBikeDist { get; set; } = null;

        /// <summary>
        /// Optimize for either the fastest route or a route that is made up of a larger percentage of bike road,
        /// where <c>FastRoute</c> is used to indicate tha fastest route with mimimized travel time, and
        /// <c>DedicatedBikeRoads</c> is used to indicate dedicated bike roads to maximize use of bike roads.	
        /// </summary>
        [JsonConverter(typeof(BikeCriterionJsonConverter))]
        [Parameter]
        public BikeCriterion? BikeCriterion { get; set; } = null;

        /// <summary>
        /// Determines the altitude profile of the route, based on a setting for how fast the user can bike when
        /// it is steep, where <c>Easy</c> is used to indicate easy with minimized steepnes, <c>Normal</c> is used
        /// to indicate normal, and <c>Powerful</c> is used to indicate powerful to allow more steepness.	
        /// </summary>
        [JsonConverter(typeof(BikeProfileJsonConverter))]
        [Parameter]
        public BikeProfile? BikeProfile { get; set; } = null;

        /// <summary>
        /// Bike-only trips, false by default
        /// </summary>
        [Parameter(defaultValue: false)]
        public bool OnlyBike { get; set; } = false;

        /// <summary>
        /// Trips where customer travels by car from the origin and is dropped off at a stop to
        /// continue the trip using public transport, false by default
        /// </summary>
        [Parameter(defaultValue: false)]
        public bool OriginCar { get; set; } = false;

        /// <summary>
        /// Trips where the customer travels by car from the origin, parks at a commuter
        /// parking and walks to a nearby stop to continue the trip using public transport, false by default
        /// </summary>
        [Parameter(defaultValue: false)]
        public bool OriginCarWithParking { get; set; } = false;

        /// <summary>
        /// Maximum car distance from/to the coordinate in meters
        /// </summary>
        [Parameter]
        public int? MaxCarDist { get; set; } = null;

        /// <summary>
        /// Car-only trips, false by default
        /// </summary>
        [Parameter(defaultValue: false)]
        public bool OnlyCar { get; set; } = false;

        /// <summary>
        /// Maximum number of changes in the trip
        /// </summary>
        [Parameter]
        public int? MaxChanges { get; set; } = null;

        /// <summary>
        /// To prolong the minimal change times in minutes between the public transport legs of the returned journeys	
        /// </summary>
        [Parameter]
        public int? AdditionalChangeTime { get; set; } = null;

        /// <summary>
        /// To ignore the default change margin, false by default
        /// </summary>
        [Parameter(defaultValue: false)]
        public bool DisregardDefaultChangeMargin { get; set; } = false;

        /// <summary>
        /// Include <see cref="Leg.JourneyDetailReference"/> in
        /// <see cref="IJourneyPlannerService.GetTripAsync(TripOptions)"/> method response, true by default
        /// </summary>
        [Parameter(defaultValue: true)]
        public bool NeedJourneyDetail { get; set; } = true;

        /// <summary>
        /// Include <see cref="Leg.GeometryReference"/> in
        /// <see cref="IJourneyPlannerService.GetTripAsync(TripOptions)"/> method response, false by default
        /// </summary>
        [Parameter(defaultValue: false)]
        public bool NeedGeo { get; set; } = false;

        /// <summary>
        /// Include <see cref="Geometry.Itineraries"/> in <see cref="Leg.GeometryReference"/> response, false by default
        /// </summary>
        /// <example>
        /// If <see cref="Geometry.Itineraries"/> is desired, it must first be specified here and it will
        /// then be included in the <see cref="Leg.GeometryReference"/> request which in turn is used in
        /// <see cref="IJourneyPlannerService.GetGeometryAsync(GeometryReference)"/> to aquire the
        /// <see cref="Geometry"/> object which contains the <see cref="Geometry.Itineraries"/> property
        /// </example>
        [Parameter(defaultValue: false)]
        public bool NeedItinerary { get; set; } = false;

        /// <summary>
        /// The number of trips in the returned result	
        /// </summary>
        [Parameter]
        public int? NumTrips { get; set; } = null;
    }
}
