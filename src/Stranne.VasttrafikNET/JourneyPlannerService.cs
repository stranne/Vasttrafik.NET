using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner;
using Stranne.VasttrafikNET.Models;
using Stranne.VasttrafikNET.Service;
using System.Linq;

namespace Stranne.VasttrafikNET
{
    /// <summary>
    /// Provides access to Västtrafik journey planner
    /// </summary>
    public class JourneyPlannerService : IJourneyPlannerService, IDisposable
    {
        internal JourneyPlannerHandlingService JourneyPlannerHandlingService { get; }

        /// <summary>
        /// Initializes a new instance of the Journey Planner Service
        /// </summary>
        /// <param name="key">Key to Västtrafik API</param>
        /// <param name="secret">Secret to Västtrafik API</param>
        /// <param name="deviceId">Device id, unique id/name per device</param>
        public JourneyPlannerService(string key, string secret, string deviceId = null)
        {
            JourneyPlannerHandlingService = new JourneyPlannerHandlingService(key, secret, deviceId);
        }

        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetArrivalBoard"]'/>
        public async Task<IEnumerable<Arrival>> GetArrivalBoardAsync(BoardOptions boardOptions)
        {
            var arrivalBoardRoot = await JourneyPlannerHandlingService.GetAsync<ArrivalBoardRoot>("/arrivalBoard", boardOptions);
            return arrivalBoardRoot.ArrivalBoard.Arrivals.Select(arrival =>
            {
                arrival.Minutes = (arrival.DateTime - arrivalBoardRoot.ArrivalBoard.ServerDateTime).Minutes;
                arrival.RealtimeMinutes = arrival.RealtimeDateTime == null
                    ? null as int?
                    : (arrival.RealtimeDateTime.Value - arrivalBoardRoot.ArrivalBoard.ServerDateTime).Minutes;
                return arrival;
            });
        }
        
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetArrivalBoard"]'/>
        public IEnumerable<Arrival> GetArrivalBoard(BoardOptions boardOptions)
        {
            return GetArrivalBoardAsync(boardOptions).GetAwaiter().GetResult();
        }
        
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetDepartureBoard"]'/>
        public async Task<IEnumerable<Departure>> GetDepartureBoardAsync(BoardOptions boardOptions)
        {
            var departureBoardRoot = await JourneyPlannerHandlingService.GetAsync<DepartureBoardRoot>("/departureBoard", boardOptions);
            return departureBoardRoot.DepartureBoard.Departures.Select(departure =>
            {
                departure.Minutes = (departure.DateTime - departureBoardRoot.DepartureBoard.ServerDateTime).Minutes;
                departure.RealtimeMinutes = departure.RealtimeDateTime == null
                    ? null as int?
                    : (departure.RealtimeDateTime.Value - departureBoardRoot.DepartureBoard.ServerDateTime).Minutes;
                return departure;
            });
        }
        
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetDepartureBoard"]'/>
        public IEnumerable<Departure> GetDepartureBoard(BoardOptions boardOptions)
        {
            return GetDepartureBoardAsync(boardOptions).GetAwaiter().GetResult();
        }
        
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetGeometry"]'/>
        public async Task<Geometry> GetGeometryAsync(GeometryReference geometryRef)
        {
            var geometryRoot = await JourneyPlannerHandlingService.GetAsync<GeometryRoot>(geometryRef.Reference);
            return geometryRoot.Geometry;
        }
        
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetGeometry"]'/>
        public Geometry GetGeometry(GeometryReference geometryRef)
        {
            return GetGeometryAsync(geometryRef).GetAwaiter().GetResult();
        }
        
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetJourneyDetail"]'/>
        public async Task<JourneyDetail> GetJourneyDetailAsync(JourneyDetailReference journeyDetailRef)
        {
            var journeyDetailRoot = await JourneyPlannerHandlingService.GetAsync<JourneyDetailRoot>(journeyDetailRef.Reference);
            return journeyDetailRoot.JourneyDetail;
        }
        
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetJourneyDetail"]'/>
        public JourneyDetail GetJourneyDetail(JourneyDetailReference journeyDetailRef)
        {
            return GetJourneyDetailAsync(journeyDetailRef).GetAwaiter().GetResult();
        }
        
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetLiveMap"]'/>
        public async Task<LiveMap> GetLiveMapAsync(double longitudeMin, double longitudeMax, double latitudeMin, double latitudeMax, bool onlyRealtime)
        {
            var options = new LiveMapOptions
            {
                Minx = longitudeMin * 1000000,
                Maxx = longitudeMax * 1000000,
                Miny = latitudeMin * 1000000,
                Maxy = latitudeMax * 1000000,
                OnlyRealtime = onlyRealtime
            };
            var liveMap = (await JourneyPlannerHandlingService.GetAsync<LiveMapRoot>("https://reseplanerare.vasttrafik.se/bin/help.exe/eny?tpl=livemap&L=vs_livemap&", options)).LiveMap;
            liveMap.LongitudeMax /= 1000000;
            liveMap.LatitudeMax /= 1000000;
            liveMap.LongitudeMin /= 1000000;
            liveMap.LatitudeMin /= 1000000;
            return liveMap;
        }
        
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetLiveMap"]'/>
        public LiveMap GetLiveMap(double longitudeMin, double longitudeMax, double latitudeMin, double latitudeMax, bool onlyRealtime)
        {
            return GetLiveMapAsync(longitudeMin, longitudeMax, latitudeMin, latitudeMax, onlyRealtime).GetAwaiter().GetResult();
        }

        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetLocationNearbyAddress"]'/>
        public async Task<LocationList> GetLocationNearbyAddressAsync(Coordinate coordinate)
        {
            var locationRoot = await JourneyPlannerHandlingService.GetAsync<LocationRoot>("/location.nearbyaddress", coordinate);
            return locationRoot.LocationList;
        }
        
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetLocationNearbyAddress"]'/>
        public LocationList GetLocationNearbyAddress(Coordinate coordinate)
        {
            return GetLocationNearbyAddressAsync(coordinate).GetAwaiter().GetResult();
        }

        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetLocationNearbyStops"]'/>
        public async Task<LocationList> GetLocationNearbyStopsAsync(Coordinate coordinate, int? maxNo = null, int? maxDist = null)
        {
            var options = new LocationNearbyStopsOptions
            {
                OriginCoordinate = coordinate,
                MaxNo = maxNo,
                MaxDist = maxDist
            };
            var locationRoot = await JourneyPlannerHandlingService.GetAsync<LocationRoot>("/location.nearbystops", options);
            return locationRoot.LocationList;
        }
        
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetLocationNearbyStops"]'/>
        public LocationList GetLocationNearbyStops(Coordinate coordinate, int? maxNo = null, int? maxDist = null)
        {
            return GetLocationNearbyStopsAsync(coordinate, maxNo, maxDist).GetAwaiter().GetResult();
        }

        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetLocationAllStops"]'/>
        public async Task<LocationList> GetLocationAllStopsAsync()
        {
            var locationRoot = await JourneyPlannerHandlingService.GetAsync<LocationRoot>("/location.allstops", null);
            return locationRoot.LocationList;
        }
        
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetLocationAllStops"]'/>
        public LocationList GetLocationAllStops()
        {
            return GetLocationAllStopsAsync().GetAwaiter().GetResult();
        }

        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetLocationName"]'/>
        public async Task<LocationList> GetLocationNameAsync(string input)
        {
            var options = new LocationNameOptions
            {
                Input = input
            };
            var locationRoot = await JourneyPlannerHandlingService.GetAsync<LocationRoot>("/location.name", options);
            return locationRoot.LocationList;
        }

        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetLocationName"]'/>
        public LocationList GetLocationName(string input)
        {
            return GetLocationNameAsync(input).GetAwaiter().GetResult();
        }
        
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetSystemInfo"]'/>
        public async Task<SystemInfo> GetSystemInfoAsync()
        {
            var systemInfoRoot = await JourneyPlannerHandlingService.GetAsync<SystemInfoRoot>("/systeminfo", null);
            return systemInfoRoot.SystemInfo;
        }
        
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetSystemInfo"]'/>
        public SystemInfo GetSystemInfo()
        {
            return GetSystemInfoAsync().GetAwaiter().GetResult();
        }
        
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetTrip"]'/>
        public async Task<IEnumerable<Trip>> GetTripAsync(TripOptions tripOptions)
        {
            var tripRoot = await JourneyPlannerHandlingService.GetAsync<TripRoot>("/trip", tripOptions);
            return tripRoot.TripList.Trips;
        }
        
        /// <include file='JourneyPlannerDocs.xml' path='/Docs/Member[@name="GetTrip"]'/>
        public IEnumerable<Trip> GetTrip(TripOptions tripOptions)
        {
            return GetTripAsync(tripOptions).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            JourneyPlannerHandlingService.Dispose();
        }
    }
}
