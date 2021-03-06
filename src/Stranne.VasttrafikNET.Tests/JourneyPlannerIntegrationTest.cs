﻿using System;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner;
using Stranne.VasttrafikNET.Exceptions;
using Stranne.VasttrafikNET.Models;
using Xunit;
using System.Linq;
using Stranne.VasttrafikNET.Tests.Jsons;

namespace Stranne.VasttrafikNET.Tests
{
    [Trait("Area", "Integration")]
    public class JourneyPlannerIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void GetDepartureBoard()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/bin/rest.exe/v2/departureBoard?date=2016-07-16&time=16:50&id=0000000800000022&format=json";
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.DepartureBoard);
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
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.ArrivalBoard);
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
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.Geometry);
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
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.JourneyDetail);
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
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.JourneyDetailError);
            var sut = GetJourneyPlannerService();

            var actual = Assert.ThrowsAny<ServerException>(() => sut.GetJourneyDetail(new JourneyDetailReference
            {
                Reference = "http://api.vasttrafik.se/bin/rest.exe/v1/journeyDetail?ref=748710%2F275948%2F848764%2F174814%2F80%3Fdate%3D2016-07-16%26station_evaId%3D1950003%26station_type%3Ddep%26authKey%3Def187f08-6bb5-454f-a1d3-d9293dc12991%26format%3Djson%26"
            }));
            
            Assert.Equal("TI001 traininfoError", actual.Name);
            Assert.Equal("No trip journey information available.", actual.Description);
            Assert.Equal("TI001 traininfoError: No trip journey information available.", actual.Message);
        }

        [Fact]
        public void GetLiveMap()
        {
            const string absoluteUrl = "https://reseplanerare.vasttrafik.se/bin/help.exe/eny?tpl=livemap&L=vs_livemap&maxx=12037610&maxy=57745560&minx=11863889&miny=57653098&onlyRealtime=no&format=json";
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.LiveMap);
            var sut = GetJourneyPlannerService();

            var actual = sut.GetLiveMap(11.863889, 12.037610, 57.653098, 57.745560, false);

            VerifyNetworkMock();
            Assert.Equal(9, actual.Vehicles.Count());
        }

        [Fact]
        public void GetLocationNearbyAddress()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/bin/rest.exe/v2/location.nearbyaddress?format=json";
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.LocationNearbyAddress);
            var sut = GetJourneyPlannerService();

            var actual = sut.GetLocationNearbyAddress(new Coordinate(57.705686, 11.963654));

            VerifyNetworkMock();
            Assert.Equal(1, actual.CoordLocation.Count());
        }

        [Fact]
        public void GetLocationNerbyStops()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/bin/rest.exe/v2/location.nearbystops?maxDist=500&maxNo=3&originCoordLat=57.705686&originCoordLong=11.963654&format=json";
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.LocationNearbyStops);
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
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.LocationAllStops);
            var sut = GetJourneyPlannerService();

            var actual = sut.GetLocationAllStops();

            VerifyNetworkMock();
            Assert.NotNull(actual.StopLocation);
        }

        [Fact]
        public void GetLocationName()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/bin/rest.exe/v2/location.name?input=Centralstationen&format=json";
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.LocationName);
            var sut = GetJourneyPlannerService();

            var actual = sut.GetLocationName("Centralstationen");

            VerifyNetworkMock();
            Assert.Equal(3, actual.CoordLocation.Count());
        }

        [Fact]
        public void GetSystemInfo()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/bin/rest.exe/v2/systeminfo?format=json";
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.SystemInfo);
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
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.Trip);
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
            var sut = new JourneyPlannerService(Key, Secret);
            sut.Dispose();
        }
    }
}