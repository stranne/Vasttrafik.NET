using System;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner.Enums;
using Stranne.VasttrafikNET.Tests.Json;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.JsonParsing
{
    public class JourneyDetailJsonTest : BaseJsonTest
    {
        protected override string Json => JourneyDetailJson.Json;

        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "JourneyDetail.Stops", 32 },
            { "JourneyDetail.Stops[0].Name", "Hornkamsgatan, Göteborg" },
            { "JourneyDetail.Stops[0].Id", "9022014003215001" },
            { "JourneyDetail.Stops[0].Latitude", 57.728726 },
            { "JourneyDetail.Stops[0].Longitude", 11.752137 },
            { "JourneyDetail.Stops[0].RouteIndex", "0" },
            { "JourneyDetail.Stops[0].ArrivalDateTime", null },
            { "JourneyDetail.Stops[0].RtArrivalDateTime", null },
            { "JourneyDetail.Stops[0].DepartureDateTime", new DateTime(2016, 7, 16, 16, 22, 0) },
            { "JourneyDetail.Stops[0].RtDepartureDateTime", null },
            { "JourneyDetail.Stops[0].Track", "A" },
            { "JourneyDetail.Stops[0].RtTrack", null },

            { "JourneyDetail.Stops[1].Name", "Lönnrunan, Göteborg" },
            { "JourneyDetail.Stops[1].Id", "9022014004655001" },
            { "JourneyDetail.Stops[1].Latitude", 57.729588 },
            { "JourneyDetail.Stops[1].Longitude", 11.760911 },
            { "JourneyDetail.Stops[1].RouteIndex", "1" },
            { "JourneyDetail.Stops[1].ArrivalDateTime", new DateTime(2016, 7, 16, 16, 22, 0) },
            { "JourneyDetail.Stops[1].RtArrivalDateTime", null },
            { "JourneyDetail.Stops[1].DepartureDateTime", new DateTime(2016, 7, 16, 16, 22, 0) },
            { "JourneyDetail.Stops[1].RtDepartureDateTime", null },
            { "JourneyDetail.Stops[1].Track", "A" },
            { "JourneyDetail.Stops[1].RtTrack", null },

            { "JourneyDetail.Stops[2].Name", "Runslingan, Göteborg" },
            { "JourneyDetail.Stops[2].Id", "9022014005506001" },
            { "JourneyDetail.Stops[2].Latitude", 57.730928 },
            { "JourneyDetail.Stops[2].Longitude", 11.762691 },
            { "JourneyDetail.Stops[2].RouteIndex", "2" },
            { "JourneyDetail.Stops[2].ArrivalDateTime", new DateTime(2016, 7, 16, 16, 23, 0) },
            { "JourneyDetail.Stops[2].RtArrivalDateTime", null },
            { "JourneyDetail.Stops[2].DepartureDateTime", new DateTime(2016, 7, 16, 16, 23, 0) },
            { "JourneyDetail.Stops[2].RtDepartureDateTime", null },
            { "JourneyDetail.Stops[2].Track", "A" },
            { "JourneyDetail.Stops[2].RtTrack", null },

            { "JourneyDetail.Color.ForegroundColor", "#ffdd00" },
            { "JourneyDetail.Color.BackgroundColor", "#00394d" },
            { "JourneyDetail.Color.Stroke", "Solid" },

            { "JourneyDetail.GeometryReference.Reference", "http://api.vasttrafik.se/bin/rest.exe/v1/geometry?ref=926976%2F339484%2F664224%2F23125%2F80%26authKey%3Def187f08-6bb5-454f-a1d3-d9293dc12991%26format%3Djson%26" },

            { "JourneyDetail.JourneyNames", 2 },
            { "JourneyDetail.JourneyNames[0].Name", "Bus GUL" },
            { "JourneyDetail.JourneyNames[0].RouteIndexFrom", 0 },
            { "JourneyDetail.JourneyNames[0].RouteIndexTo", 20 },
            { "JourneyDetail.JourneyNames[1].Name", "Bus GUL" },
            { "JourneyDetail.JourneyNames[1].RouteIndexFrom", 20 },
            { "JourneyDetail.JourneyNames[1].RouteIndexTo", 31 },
            
            { "JourneyDetail.JourneyTypes", 2 },
            { "JourneyDetail.JourneyTypes[0].Type", JourneyType.Bus },
            { "JourneyDetail.JourneyTypes[0].RouteIndexFrom", 0 },
            { "JourneyDetail.JourneyTypes[0].RouteIndexTo", 20 },
            { "JourneyDetail.JourneyTypes[1].Type", JourneyType.Bus },
            { "JourneyDetail.JourneyTypes[1].RouteIndexFrom", 20 },
            { "JourneyDetail.JourneyTypes[1].RouteIndexTo", 31 },

            { "JourneyDetail.JourneyIds", 1 },
            { "JourneyDetail.JourneyIds[0].Id", "9015014521200668" },
            { "JourneyDetail.JourneyIds[0].RouteIndexFrom", 0 },
            { "JourneyDetail.JourneyIds[0].RouteIndexTo", 31 },

            { "JourneyDetail.Direction", 2 },
            { "JourneyDetail.Direction[0].Name", "Jonsered via Partille centrum" },
            { "JourneyDetail.Direction[0].RouteIndexFrom", 0 },
            { "JourneyDetail.Direction[0].RouteIndexTo", 20 },
            { "JourneyDetail.Direction[1].Name", "Jonsered" },
            { "JourneyDetail.Direction[1].RouteIndexFrom", 20 },
            { "JourneyDetail.Direction[1].RouteIndexTo", 31 }
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void JourneyDetailJsonParsing(string property, object expected)
        {
            TestValue<JourneyDetailRoot>(property, expected);
        }
    }
}
