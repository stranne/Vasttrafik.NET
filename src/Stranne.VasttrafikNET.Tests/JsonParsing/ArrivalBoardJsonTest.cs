using System;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner.Enums;
using Stranne.VasttrafikNET.Tests.Json;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.JsonParsing
{
    public class ArrivalBoardJsonTest : BaseJsonTest
    {
        protected override string Json => ArrivalBoardJson.Json;

        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "ArrivalBoard.Arrivals", 5 },
            { "ArrivalBoard.Arrivals[0].Name", "Spårvagn 2" },
            { "ArrivalBoard.Arrivals[0].ShortName", "2" },
            { "ArrivalBoard.Arrivals[0].Type", JourneyType.Tram },
            { "ArrivalBoard.Arrivals[0].StopId", "9022014001950003" },
            { "ArrivalBoard.Arrivals[0].Stop", "Centralstationen, Göteborg" },
            { "ArrivalBoard.Arrivals[0].DateTime", new DateTime(2016, 7, 16, 16, 50, 0) },
            { "ArrivalBoard.Arrivals[0].Minutes", 0 },
            { "ArrivalBoard.Arrivals[0].RealtimeDateTime", null },
            { "ArrivalBoard.Arrivals[0].RealtimeMinutes", null },
            { "ArrivalBoard.Arrivals[0].JourneyId", "9015014500204078" },
            { "ArrivalBoard.Arrivals[0].Origin", "Frölunda" },
            { "ArrivalBoard.Arrivals[0].Track", "C" },
            { "ArrivalBoard.Arrivals[0].RealtimeTrack", null },
            { "ArrivalBoard.Arrivals[0].ForegroundColor", "#fff014" },
            { "ArrivalBoard.Arrivals[0].BackgroundColor", "#00394d" },
            { "ArrivalBoard.Arrivals[0].Stroke", "Solid" },
            { "ArrivalBoard.Arrivals[0].Booking", false },
            { "ArrivalBoard.Arrivals[0].Night", false },
            { "ArrivalBoard.Arrivals[0].Accessibility", null },
            { "ArrivalBoard.Arrivals[0].JourneyDetailReference.Reference", "http://api.vasttrafik.se/bin/rest.exe/v1/journeyDetail?ref=748710%2F275948%2F848764%2F174814%2F80%3Fdate%3D2016-07-16%26station_evaId%3D1950003%26station_type%3Ddep%26authKey%3Def187f08-6bb5-454f-a1d3-d9293dc12991%26format%3Djson%26" },

            { "ArrivalBoard.Arrivals[1].Name", "SVART EXPRESS" },
            { "ArrivalBoard.Arrivals[1].ShortName", "SVAR" },
            { "ArrivalBoard.Arrivals[1].Type", JourneyType.Bus },
            { "ArrivalBoard.Arrivals[1].StopId", "9022014001950011" },
            { "ArrivalBoard.Arrivals[1].Stop", "Centralstationen, Göteborg" },
            { "ArrivalBoard.Arrivals[1].DateTime", new DateTime(2016, 7, 16, 16, 50, 0) },
            { "ArrivalBoard.Arrivals[1].Minutes", 0 },
            { "ArrivalBoard.Arrivals[1].RealtimeDateTime", null },
            { "ArrivalBoard.Arrivals[1].RealtimeMinutes", null },
            { "ArrivalBoard.Arrivals[1].JourneyId", "9015014521100644" },
            { "ArrivalBoard.Arrivals[1].Origin", "Amhult" },
            { "ArrivalBoard.Arrivals[1].Track", "K" },
            { "ArrivalBoard.Arrivals[1].RealtimeTrack", null },
            { "ArrivalBoard.Arrivals[1].ForegroundColor", "#000000" },
            { "ArrivalBoard.Arrivals[1].BackgroundColor", "#ffffff" },
            { "ArrivalBoard.Arrivals[1].Stroke", "Solid" },
            { "ArrivalBoard.Arrivals[1].Booking", false },
            { "ArrivalBoard.Arrivals[1].Night", false },
            { "ArrivalBoard.Arrivals[1].Accessibility", Accessibility.WheelChair },
            { "ArrivalBoard.Arrivals[1].JourneyDetailReference.Reference", "http://api.vasttrafik.se/bin/rest.exe/v1/journeyDetail?ref=28509%2F27666%2F251016%2F116017%2F80%3Fdate%3D2016-07-16%26station_evaId%3D1950011%26station_type%3Ddep%26authKey%3Def187f08-6bb5-454f-a1d3-d9293dc12991%26format%3Djson%26" },

            { "ArrivalBoard.Arrivals[2].Name", "SVART EXPRESS" },
            { "ArrivalBoard.Arrivals[2].ShortName", "SVAR" },
            { "ArrivalBoard.Arrivals[2].Type", JourneyType.Bus },
            { "ArrivalBoard.Arrivals[2].StopId", "9022014004945004" },
            { "ArrivalBoard.Arrivals[2].Stop", "Nordstan, Göteborg" },
            { "ArrivalBoard.Arrivals[2].DateTime", new DateTime(2016, 7, 16, 16, 50, 0) },
            { "ArrivalBoard.Arrivals[2].Minutes", 0 },
            { "ArrivalBoard.Arrivals[2].RealtimeDateTime", null },
            { "ArrivalBoard.Arrivals[2].RealtimeMinutes", null },
            { "ArrivalBoard.Arrivals[2].JourneyId", "9015014521100644" },
            { "ArrivalBoard.Arrivals[2].Origin", "Amhult" },
            { "ArrivalBoard.Arrivals[2].Track", "D" },
            { "ArrivalBoard.Arrivals[2].RealtimeTrack", null },
            { "ArrivalBoard.Arrivals[2].ForegroundColor", "#000000" },
            { "ArrivalBoard.Arrivals[2].BackgroundColor", "#ffffff" },
            { "ArrivalBoard.Arrivals[2].Stroke", "Solid" },
            { "ArrivalBoard.Arrivals[2].Booking", false },
            { "ArrivalBoard.Arrivals[2].Night", false },
            { "ArrivalBoard.Arrivals[2].Accessibility", Accessibility.WheelChair },
            { "ArrivalBoard.Arrivals[2].JourneyDetailReference.Reference", "http://api.vasttrafik.se/bin/rest.exe/v1/journeyDetail?ref=578484%2F210991%2F472736%2F43552%2F80%3Fdate%3D2016-07-16%26station_evaId%3D4945004%26station_type%3Ddep%26authKey%3Def187f08-6bb5-454f-a1d3-d9293dc12991%26format%3Djson%26" },

            { "ArrivalBoard.Arrivals[3].Name", "VÄSTTÅGEN" },
            { "ArrivalBoard.Arrivals[3].ShortName", "TÅG" },
            { "ArrivalBoard.Arrivals[3].Type", JourneyType.Vasttagen },
            { "ArrivalBoard.Arrivals[3].StopId", "9022014008000010" },
            { "ArrivalBoard.Arrivals[3].Stop", "Göteborg C, Göteborg" },
            { "ArrivalBoard.Arrivals[3].DateTime", new DateTime(2016, 7, 16, 16, 50, 0) },
            { "ArrivalBoard.Arrivals[3].Minutes", 0 },
            { "ArrivalBoard.Arrivals[3].RealtimeDateTime", null },
            { "ArrivalBoard.Arrivals[3].RealtimeMinutes", null },
            { "ArrivalBoard.Arrivals[3].JourneyId", "9015014133103666" },
            { "ArrivalBoard.Arrivals[3].Origin", "Älvängen" },
            { "ArrivalBoard.Arrivals[3].Track", null },
            { "ArrivalBoard.Arrivals[3].RealtimeTrack", null },
            { "ArrivalBoard.Arrivals[3].ForegroundColor", "#00A5DC" },
            { "ArrivalBoard.Arrivals[3].BackgroundColor", "#ffffff" },
            { "ArrivalBoard.Arrivals[3].Stroke", "Solid" },
            { "ArrivalBoard.Arrivals[3].Booking", false },
            { "ArrivalBoard.Arrivals[3].Night", false },
            { "ArrivalBoard.Arrivals[3].Accessibility", null },
            { "ArrivalBoard.Arrivals[3].JourneyDetailReference.Reference", "http://api.vasttrafik.se/bin/rest.exe/v1/journeyDetail?ref=483735%2F185050%2F231500%2F45500%2F80%3Fdate%3D2016-07-16%26station_evaId%3D8000010%26station_type%3Ddep%26authKey%3Def187f08-6bb5-454f-a1d3-d9293dc12991%26format%3Djson%26" },

            { "ArrivalBoard.Arrivals[4].Name", "Spårvagn 2" },
            { "ArrivalBoard.Arrivals[4].ShortName", "2" },
            { "ArrivalBoard.Arrivals[4].Type", JourneyType.Tram },
            { "ArrivalBoard.Arrivals[4].StopId", "9022014001950001" },
            { "ArrivalBoard.Arrivals[4].Stop", "Centralstationen, Göteborg" },
            { "ArrivalBoard.Arrivals[4].DateTime", new DateTime(2016, 7, 16, 16, 51, 0) },
            { "ArrivalBoard.Arrivals[4].Minutes", 0 },
            { "ArrivalBoard.Arrivals[4].RealtimeDateTime", null },
            { "ArrivalBoard.Arrivals[4].RealtimeMinutes", null },
            { "ArrivalBoard.Arrivals[4].JourneyId", "9015014500204077" },
            { "ArrivalBoard.Arrivals[4].Origin", "Mölndal" },
            { "ArrivalBoard.Arrivals[4].Track", "A" },
            { "ArrivalBoard.Arrivals[4].RealtimeTrack", null },
            { "ArrivalBoard.Arrivals[4].ForegroundColor", "#fff014" },
            { "ArrivalBoard.Arrivals[4].BackgroundColor", "#00394d" },
            { "ArrivalBoard.Arrivals[4].Stroke", "Solid" },
            { "ArrivalBoard.Arrivals[4].Booking", false },
            { "ArrivalBoard.Arrivals[4].Night", false },
            { "ArrivalBoard.Arrivals[4].Accessibility", null },
            { "ArrivalBoard.Arrivals[4].JourneyDetailReference.Reference", "http://api.vasttrafik.se/bin/rest.exe/v1/journeyDetail?ref=702918%2F253010%2F766880%2F149136%2F80%3Fdate%3D2016-07-16%26station_evaId%3D1950001%26station_type%3Ddep%26authKey%3Def187f08-6bb5-454f-a1d3-d9293dc12991%26format%3Djson%26" }
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void ArrivalBoardJsonParsing(string property, object expected)
        {
            TestValue<ArrivalBoardRoot>(property, expected);
        }
    }
}
