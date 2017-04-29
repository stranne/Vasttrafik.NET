using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner.Enums;
using Stranne.VasttrafikNET.Tests.Json;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.JsonParsing
{
    public class DepartureBoardJsonTest : BaseJsonTest
    {
        protected override string Json => DepartureBoardJson.Json;

        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "DepartureBoard.ServerDateTime", new DateTimeOffset(2016, 7, 16, 16, 48, 0, new TimeSpan(2, 0, 0)) },
            { "DepartureBoard.Departures", 5 },
            { "DepartureBoard.Departures[0].Name", "Spårvagn 2" },
            { "DepartureBoard.Departures[0].ShortName", "2" },
            { "DepartureBoard.Departures[0].Type", JourneyType.Boat },
            { "DepartureBoard.Departures[0].StopId", "9022014001950003" },
            { "DepartureBoard.Departures[0].Stop", "Centralstationen, Göteborg" },
            { "DepartureBoard.Departures[0].DateTime", new DateTimeOffset(2016, 7, 16, 16, 50, 0, new TimeSpan(2, 0, 0)) },
            { "DepartureBoard.Departures[0].Minutes", 0 },
            { "DepartureBoard.Departures[0].RealtimeDateTime", null },
            { "DepartureBoard.Departures[0].RealtimeMinutes", null },
            { "DepartureBoard.Departures[0].JourneyId", "9015014500204078" },
            { "DepartureBoard.Departures[0].Direction", "Frölunda" },
            { "DepartureBoard.Departures[0].Track", "C" },
            { "DepartureBoard.Departures[0].RealtimeTrack", null },
            { "DepartureBoard.Departures[0].ForegroundColor", "#fff014" },
            { "DepartureBoard.Departures[0].BackgroundColor", "#00394d" },
            { "DepartureBoard.Departures[0].Stroke", "Solid" },
            { "DepartureBoard.Departures[0].Booking", false },
            { "DepartureBoard.Departures[0].Night", false },
            { "DepartureBoard.Departures[0].Accessibility", null },
            { "DepartureBoard.Departures[0].JourneyDetailReference.Reference", "http://api.vasttrafik.se/bin/rest.exe/v1/journeyDetail?ref=748710%2F275948%2F848764%2F174814%2F80%3Fdate%3D2016-07-16%26station_evaId%3D1950003%26station_type%3Ddep%26authKey%3Def187f08-6bb5-454f-a1d3-d9293dc12991%26format%3Djson%26" },

            { "DepartureBoard.Departures[1].Name", "SVART EXPRESS" },
            { "DepartureBoard.Departures[1].ShortName", "SVAR" },
            { "DepartureBoard.Departures[1].Type", JourneyType.Taxi },
            { "DepartureBoard.Departures[1].StopId", "9022014001950011" },
            { "DepartureBoard.Departures[1].Stop", "Centralstationen, Göteborg" },
            { "DepartureBoard.Departures[1].DateTime", new DateTimeOffset(2016, 7, 16, 16, 50, 0, new TimeSpan(2, 0, 0)) },
            { "DepartureBoard.Departures[1].Minutes", 0 },
            { "DepartureBoard.Departures[1].RealtimeDateTime", null },
            { "DepartureBoard.Departures[1].RealtimeMinutes", null },
            { "DepartureBoard.Departures[1].JourneyId", "9015014521100644" },
            { "DepartureBoard.Departures[1].Direction", "Amhult" },
            { "DepartureBoard.Departures[1].Track", "K" },
            { "DepartureBoard.Departures[1].RealtimeTrack", null },
            { "DepartureBoard.Departures[1].ForegroundColor", "#000000" },
            { "DepartureBoard.Departures[1].BackgroundColor", "#ffffff" },
            { "DepartureBoard.Departures[1].Stroke", "Solid" },
            { "DepartureBoard.Departures[1].Booking", false },
            { "DepartureBoard.Departures[1].Night", false },
            { "DepartureBoard.Departures[1].Accessibility", Accessibility.WheelChair },
            { "DepartureBoard.Departures[1].JourneyDetailReference.Reference", "http://api.vasttrafik.se/bin/rest.exe/v1/journeyDetail?ref=28509%2F27666%2F251016%2F116017%2F80%3Fdate%3D2016-07-16%26station_evaId%3D1950011%26station_type%3Ddep%26authKey%3Def187f08-6bb5-454f-a1d3-d9293dc12991%26format%3Djson%26" },
            
            { "DepartureBoard.Departures[2].Name", "SVART EXPRESS" },
            { "DepartureBoard.Departures[2].ShortName", "SVAR" },
            { "DepartureBoard.Departures[2].Type", JourneyType.Walk },
            { "DepartureBoard.Departures[2].StopId", "9022014004945004" },
            { "DepartureBoard.Departures[2].Stop", "Nordstan, Göteborg" },
            { "DepartureBoard.Departures[2].DateTime", new DateTimeOffset(2016, 7, 16, 16, 50, 0, new TimeSpan(2, 0, 0)) },
            { "DepartureBoard.Departures[2].Minutes", 0 },
            { "DepartureBoard.Departures[2].RealtimeDateTime", null },
            { "DepartureBoard.Departures[2].RealtimeMinutes", null },
            { "DepartureBoard.Departures[2].JourneyId", "9015014521100644" },
            { "DepartureBoard.Departures[2].Direction", "Amhult" },
            { "DepartureBoard.Departures[2].Track", "D" },
            { "DepartureBoard.Departures[2].RealtimeTrack", null },
            { "DepartureBoard.Departures[2].ForegroundColor", "#000000" },
            { "DepartureBoard.Departures[2].BackgroundColor", "#ffffff" },
            { "DepartureBoard.Departures[2].Stroke", "Solid" },
            { "DepartureBoard.Departures[2].Booking", false },
            { "DepartureBoard.Departures[2].Night", false },
            { "DepartureBoard.Departures[2].Accessibility", Accessibility.WheelChair },
            { "DepartureBoard.Departures[2].JourneyDetailReference.Reference", "http://api.vasttrafik.se/bin/rest.exe/v1/journeyDetail?ref=578484%2F210991%2F472736%2F43552%2F80%3Fdate%3D2016-07-16%26station_evaId%3D4945004%26station_type%3Ddep%26authKey%3Def187f08-6bb5-454f-a1d3-d9293dc12991%26format%3Djson%26" },

            { "DepartureBoard.Departures[3].Name", "VÄSTTÅGEN" },
            { "DepartureBoard.Departures[3].ShortName", "TÅG" },
            { "DepartureBoard.Departures[3].Type", JourneyType.Bike },
            { "DepartureBoard.Departures[3].StopId", "9022014008000010" },
            { "DepartureBoard.Departures[3].Stop", "Göteborg C, Göteborg" },
            { "DepartureBoard.Departures[3].DateTime", new DateTimeOffset(2016, 7, 16, 16, 50, 0, new TimeSpan(2, 0, 0)) },
            { "DepartureBoard.Departures[3].Minutes", 0 },
            { "DepartureBoard.Departures[3].RealtimeDateTime", null },
            { "DepartureBoard.Departures[3].RealtimeMinutes", null },
            { "DepartureBoard.Departures[3].JourneyId", "9015014133103666" },
            { "DepartureBoard.Departures[3].Direction", "Älvängen" },
            { "DepartureBoard.Departures[3].Track", null },
            { "DepartureBoard.Departures[3].RealtimeTrack", null },
            { "DepartureBoard.Departures[3].ForegroundColor", "#00A5DC" },
            { "DepartureBoard.Departures[3].BackgroundColor", "#ffffff" },
            { "DepartureBoard.Departures[3].Stroke", "Solid" },
            { "DepartureBoard.Departures[3].Booking", false },
            { "DepartureBoard.Departures[3].Night", false },
            { "DepartureBoard.Departures[3].Accessibility", null },
            { "DepartureBoard.Departures[3].JourneyDetailReference.Reference", "http://api.vasttrafik.se/bin/rest.exe/v1/journeyDetail?ref=483735%2F185050%2F231500%2F45500%2F80%3Fdate%3D2016-07-16%26station_evaId%3D8000010%26station_type%3Ddep%26authKey%3Def187f08-6bb5-454f-a1d3-d9293dc12991%26format%3Djson%26" },

            { "DepartureBoard.Departures[4].Name", "Spårvagn 2" },
            { "DepartureBoard.Departures[4].ShortName", "2" },
            { "DepartureBoard.Departures[4].Type", JourneyType.Car },
            { "DepartureBoard.Departures[4].StopId", "9022014001950001" },
            { "DepartureBoard.Departures[4].Stop", "Centralstationen, Göteborg" },
            { "DepartureBoard.Departures[4].DateTime", new DateTimeOffset(2016, 7, 16, 16, 51, 0, new TimeSpan(2, 0, 0)) },
            { "DepartureBoard.Departures[4].Minutes", 0 },
            { "DepartureBoard.Departures[4].RealtimeDateTime", null },
            { "DepartureBoard.Departures[4].RealtimeMinutes", null },
            { "DepartureBoard.Departures[4].JourneyId", "9015014500204077" },
            { "DepartureBoard.Departures[4].Direction", "Mölndal" },
            { "DepartureBoard.Departures[4].Track", "A" },
            { "DepartureBoard.Departures[4].RealtimeTrack", null },
            { "DepartureBoard.Departures[4].ForegroundColor", "#fff014" },
            { "DepartureBoard.Departures[4].BackgroundColor", "#00394d" },
            { "DepartureBoard.Departures[4].Stroke", "Solid" },
            { "DepartureBoard.Departures[4].Booking", false },
            { "DepartureBoard.Departures[4].Night", false },
            { "DepartureBoard.Departures[4].Accessibility", null },
            { "DepartureBoard.Departures[4].JourneyDetailReference.Reference", "http://api.vasttrafik.se/bin/rest.exe/v1/journeyDetail?ref=702918%2F253010%2F766880%2F149136%2F80%3Fdate%3D2016-07-16%26station_evaId%3D1950001%26station_type%3Ddep%26authKey%3Def187f08-6bb5-454f-a1d3-d9293dc12991%26format%3Djson%26" }
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void DepartureBoardJsonParsing(string property, object expected)
        {
            TestValue<DepartureBoardRoot>(property, expected);
        }

        [Fact]
        public void DepartureBoardOnDeserialized()
        {
            JsonConvert.DeserializeObject<DepartureBoard>("{}");
        }
    }
}
