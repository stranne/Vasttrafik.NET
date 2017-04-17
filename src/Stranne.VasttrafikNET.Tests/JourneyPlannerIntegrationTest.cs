using System;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner;
using Stranne.VasttrafikNET.Exceptions;
using Stranne.VasttrafikNET.Models;
using Stranne.VasttrafikNET.Tests.Json;
using Xunit;
using System.Linq;

namespace Stranne.VasttrafikNET.Tests
{
    [Trait("Area", "Integration")]
    public class JourneyPlannerIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void GetDepartureBoard()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/bin/rest.exe/v2/departureBoard?date=2016-07-16&time=16:50&id=0000000800000022&format=json";
            SetUpNetworkServiceMock(absoluteUrl, DepartureBoardJson.Json);
            var sut = GetJourneyPlannerService();
            var boardOptions = new BoardOptions
            {
                Id = "0000000800000022",
                DateTime = new DateTimeOffset(2016, 7, 16, 9, 50, 0, new TimeSpan(-5, 0, 0))
            };

            var actual = sut.GetDepartureBoard(boardOptions).ToList();

            VerifyNetworkMock();
            Assert.Equal(5, actual.Count);
            Assert.Equal(2, actual.First().Minutes);
        }

        [Fact]
        public void GetArrivalBoard()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/bin/rest.exe/v2/arrivalBoard?date=2016-07-16&time=16:50&id=0000000800000022&format=json";
            SetUpNetworkServiceMock(absoluteUrl, ArrivalBoardJson.Json);
            var sut = GetJourneyPlannerService();
            var boardOptions = new BoardOptions
            {
                Id = "0000000800000022",
                DateTime = new DateTimeOffset(2016, 7, 16, 16, 50, 0, new TimeSpan(2, 0, 0))
            };

            var actual = sut.GetArrivalBoard(boardOptions).ToList();

            VerifyNetworkMock();
            Assert.Equal(5, actual.Count);
            Assert.Equal(2, actual.First().Minutes);
        }

        [Fact]
        public void GetGeometry()
        {
            const string absoluteUrl = "http://api.vasttrafik.se/bin/rest.exe/v1/geometry?ref=926976%2F339484%2F664224%2F23125%2F80%26authKey%3Def187f08-6bb5-454f-a1d3-d9293dc12991%26format%3Djson%26";
            SetUpNetworkServiceMock(absoluteUrl, GeometryJson.Json);
            var sut = GetJourneyPlannerService();

            var actual = sut.GetGeometry(new GeometryReference
            {
                Reference = "http://api.vasttrafik.se/bin/rest.exe/v1/geometry?ref=926976%2F339484%2F664224%2F23125%2F80%26authKey%3Def187f08-6bb5-454f-a1d3-d9293dc12991%26format%3Djson%26"
            });

            VerifyNetworkMock();
            Assert.Equal(3, actual.Points.Count());
        }

        [Fact]
        public void GetJourneyDetail()
        {
            const string absoluteUrl = "http://api.vasttrafik.se/bin/rest.exe/v1/journeyDetail?ref=748710%2F275948%2F848764%2F174814%2F80%3Fdate%3D2016-07-16%26station_evaId%3D1950003%26station_type%3Ddep%26authKey%3Def187f08-6bb5-454f-a1d3-d9293dc12991%26format%3Djson%26";
            SetUpNetworkServiceMock(absoluteUrl, JourneyDetailJson.Json);
            var sut = GetJourneyPlannerService();

            var actual = sut.GetJourneyDetail(new JourneyDetailReference
            {
                Reference = "http://api.vasttrafik.se/bin/rest.exe/v1/journeyDetail?ref=748710%2F275948%2F848764%2F174814%2F80%3Fdate%3D2016-07-16%26station_evaId%3D1950003%26station_type%3Ddep%26authKey%3Def187f08-6bb5-454f-a1d3-d9293dc12991%26format%3Djson%26"
            });

            VerifyNetworkMock();
            Assert.Equal(32, actual.Stops.Count());
        }

        [Fact]
        public void GetJourneyDetailFailed()
        {
            const string absoluteUrl = "http://api.vasttrafik.se/bin/rest.exe/v1/journeyDetail?ref=748710%2F275948%2F848764%2F174814%2F80%3Fdate%3D2016-07-16%26station_evaId%3D1950003%26station_type%3Ddep%26authKey%3Def187f08-6bb5-454f-a1d3-d9293dc12991%26format%3Djson%26";
            SetUpNetworkServiceMock(absoluteUrl, JourneyDetailErrorJson.Json);
            var sut = GetJourneyPlannerService();

            var actual = Assert.ThrowsAny<AggregateException>(() => sut.GetJourneyDetail(new JourneyDetailReference
            {
                Reference = "http://api.vasttrafik.se/bin/rest.exe/v1/journeyDetail?ref=748710%2F275948%2F848764%2F174814%2F80%3Fdate%3D2016-07-16%26station_evaId%3D1950003%26station_type%3Ddep%26authKey%3Def187f08-6bb5-454f-a1d3-d9293dc12991%26format%3Djson%26"
            }));

            Assert.NotNull(actual.InnerException);
            Assert.IsType(typeof(ServerException), actual.InnerException);
            Assert.Equal("TI001 traininfoError", ((ServerException)actual.InnerException).Name);
            Assert.Equal("No trip journey information available.", ((ServerException)actual.InnerException).Description);
            Assert.Equal("TI001 traininfoError: No trip journey information available.", ((ServerException)actual.InnerException).Message);
        }

        [Fact]
        public void GetLiveMap()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/bin/rest.exe/v2/livemap?maxx=12044663&maxy=57685421&minx=11913214&miny=57721867&onlyRealtime=no&format=json";
            SetUpNetworkServiceMock(absoluteUrl, LiveMapJson.Json);
            var sut = GetJourneyPlannerService();

            var actual = sut.GetLiveMap(11.913214, 12.044663, 57.721867, 57.685421, false);

            VerifyNetworkMock();
            Assert.Equal(2, actual.Vehicles.Count());
        }

        [Fact]
        public void GetLocationNearbyAddress()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/bin/rest.exe/v2/location.nearbyaddress?format=json";
            SetUpNetworkServiceMock(absoluteUrl, LocationNearbyAddressJson.Json);
            var sut = GetJourneyPlannerService();

            var actual = sut.GetLocationNearbyAddress(new Coordinate
            {
                Latitude = 57.705686,
                Longitude = 11.963654
            });

            VerifyNetworkMock();
            Assert.Equal(1, actual.CoordLocation.Count());
        }

        [Fact]
        public void GetLocationNerbyStops()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/bin/rest.exe/v2/location.nearbystops?maxDist=500&maxNo=3&originCoordLat=57.705686&originCoordLong=11.963654&format=json";
            SetUpNetworkServiceMock(absoluteUrl, LocationNearbyStopsJson.Json);
            var sut = GetJourneyPlannerService();

            var actual = sut.GetLocationNearbyStops(new Coordinate
            {
                Latitude = 57.705686,
                Longitude = 11.963654
            }, 3, 500);

            VerifyNetworkMock();
            Assert.Equal(3, actual.StopLocation.Count());
        }

        [Fact]
        public void GetLocationAllStops()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/bin/rest.exe/v2/location.allstops?format=json";
            SetUpNetworkServiceMock(absoluteUrl, LocationAllStopsJson.Json);
            var sut = GetJourneyPlannerService();

            var actual = sut.GetLocationAllStops();

            VerifyNetworkMock();
            Assert.NotNull(actual.StopLocation);
        }

        [Fact]
        public void GetLocationName()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/bin/rest.exe/v2/location.name?input=Centralstationen&format=json";
            SetUpNetworkServiceMock(absoluteUrl, LocationNameJson.Json);
            var sut = GetJourneyPlannerService();

            var actual = sut.GetLocationName("Centralstationen");

            VerifyNetworkMock();
            Assert.Equal(3, actual.CoordLocation.Count());
        }

        [Fact]
        public void GetSystemInfo()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/bin/rest.exe/v2/systeminfo?format=json";
            SetUpNetworkServiceMock(absoluteUrl, SystemInfoJson.Json);
            var sut = GetJourneyPlannerService();

            var actual = sut.GetSystemInfo();

            VerifyNetworkMock();
            Assert.Equal(new DateTimeOffset(2016, 6, 1, 0, 0, 0, new TimeSpan(2, 0, 0)), actual.TimetableInfo.TimetablePeriod.DateBegin);
            Assert.Equal(new DateTimeOffset(2016, 10, 29, 0, 0, 0, new TimeSpan(2, 0, 0)), actual.TimetableInfo.TimetablePeriod.DateEnd);
            Assert.Equal(new DateTimeOffset(2016, 7, 31, 0, 0, 0, new TimeSpan(2, 0, 0)), actual.TimetableInfo.TimeTableData.CreationDate);
        }

        [Fact]
        public void GetTrip()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/bin/rest.exe/v2/trip?destId=9021014001950000&originId=0000000800000002&format=json";
            SetUpNetworkServiceMock(absoluteUrl, TripJson.Json);
            var sut = GetJourneyPlannerService();

            var actual = sut.GetTrip(new TripOptions
            {
                OriginId = "0000000800000002",
                DestId = "9021014001950000"
            });

            VerifyNetworkMock();
            Assert.Equal(3, actual.Count());
        }

        [Fact]
        public void Dispose()
        {
            var sut = new JourneyPlannerService(VtKey, VtSecret);
            sut.Dispose();
        }
    }
}
