using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner;
using Stranne.VasttrafikNET.Models;

namespace Stranne.VasttrafikNET
{
    /// <summary>
    /// Provides access to Västtrafik journey planner
    /// </summary>
    public interface IJourneyPlannerService
    {
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetArrivalBoard"]'/>
        Task<IEnumerable<Arrival>> GetArrivalBoardAsync(BoardOptions boardOptions);
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetArrivalBoard"]'/>
        IEnumerable<Arrival> GetArrivalBoard(BoardOptions boardOptions);
        
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetDepartureBoard"]'/>
        Task<IEnumerable<Departure>> GetDepartureBoardAsync(BoardOptions boardOptions);
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetDepartureBoard"]'/>
        IEnumerable<Departure> GetDepartureBoard(BoardOptions boardOptions);
        
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetGeometry"]'/>
        Task<Geometry> GetGeometryAsync(GeometryReference geometryRef);
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetGeometry"]'/>
        Geometry GetGeometry(GeometryReference geometryRef);
        
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetJourneyDetail"]'/>
        Task<JourneyDetail> GetJourneyDetailAsync(JourneyDetailReference journeyDetailRef);
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetJourneyDetail"]'/>
        JourneyDetail GetJourneyDetail(JourneyDetailReference journeyDetailRef);
        
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetLiveMap"]'/>
        Task<LiveMap> GetLiveMapAsync(double longitudeMin, double longitudeMax, double latitudeMin, double latitudeMax, bool onlyRealtime);
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetLiveMap"]'/>
        LiveMap GetLiveMap(double longitudeMin, double longitudeMax, double latitudeMin, double latitudeMax, bool onlyRealtime);
        
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetLocationNearbyAddress"]'/>
        Task<LocationList> GetLocationNearbyAddressAsync(Coordinate coordinate);
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetLocationNearbyAddress"]'/>
        LocationList GetLocationNearbyAddress(Coordinate coordinate);
        
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetLocationNearbyStops"]'/>
        Task<LocationList> GetLocationNearbyStopsAsync(Coordinate coordinate, int? maxNo = null, int? maxDist = null);
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetLocationNearbyStops"]'/>
        LocationList GetLocationNearbyStops(Coordinate coordinate, int? maxNo = null, int? maxDist = null);
        
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetLocationAllStops"]'/>
        Task<LocationList> GetLocationAllStopsAsync();
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetLocationAllStops"]'/>
        LocationList GetLocationAllStops();
        
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetLocationName"]'/>
        Task<LocationList> GetLocationNameAsync(string input);
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetLocationName"]'/>
        LocationList GetLocationName(string input);

        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetSystemInfo"]'/>
        Task<SystemInfo> GetSystemInfoAsync();
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetSystemInfo"]'/>
        SystemInfo GetSystemInfo();
        
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetTrip"]'/>
        Task<IEnumerable<Trip>> GetTripAsync(TripOptions tripOptions);
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetTrip"]'/>
        IEnumerable<Trip> GetTrip(TripOptions tripOptions);
    }
}
