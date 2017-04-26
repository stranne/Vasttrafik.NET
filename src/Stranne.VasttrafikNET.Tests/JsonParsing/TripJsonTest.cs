using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner.Enums;
using Stranne.VasttrafikNET.Tests.Json;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.JsonParsing
{
    public class TripJsonTest : BaseJsonTest
    {
        protected override string Json => TripJson.Json;

        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "TripList.ServerDateTime", new DateTimeOffset(2016, 7, 31, 20, 30, 0, new TimeSpan(2, 0, 0)) },
            { "TripList.Trips", 3 },
            { "TripList.Trips[0].TravelWarrenty", true },
            { "TripList.Trips[0].Alternative", false },
            { "TripList.Trips[0].Type", null },
            { "TripList.Trips[0].Valid", true },
            { "TripList.Trips[0].Legs", 1 },
            { "TripList.Trips[0].Legs[0].ForegroundColor", "#fff014" },
            { "TripList.Trips[0].Legs[0].Booking", false },
            { "TripList.Trips[0].Legs[0].Direction", "Frölunda via Järntorget" },
            { "TripList.Trips[0].Legs[0].JourneyDetailReference.Reference", "https://api.vasttrafik.se/bin/rest.exe/v2/journeyDetail?ref=924501%2F336535%2F458390%2F78978%2F80%3Fdate%3D2016-07-31%26station_evaId%3D12110001%26station_type%3Ddep%26format%3Djson%26" },
            { "TripList.Trips[0].Legs[0].Cancelled", true },
            { "TripList.Trips[0].Legs[0].Kcal", null },
            { "TripList.Trips[0].Legs[0].Sname", "2" },
            { "TripList.Trips[0].Legs[0].Type", JourneyType.Tram },
            { "TripList.Trips[0].Legs[0].GeometryReference", null },
            { "TripList.Trips[0].Legs[0].BackgroundColor", "#00394d" },
            { "TripList.Trips[0].Legs[0].Notes", 0 },
            { "TripList.Trips[0].Legs[0].Id", "9015014500204112" },
            { "TripList.Trips[0].Legs[0].Stroke", "Solid" },
            { "TripList.Trips[0].Legs[0].Reachable", true },
            { "TripList.Trips[0].Legs[0].Name", "Spårvagn 2" },
            { "TripList.Trips[0].Legs[0].Night", false },
            { "TripList.Trips[0].Legs[0].PercentBikeRoad", null },
            { "TripList.Trips[0].Legs[0].Accessibility", Accessibility.WheelChair },

            { "TripList.Trips[0].Legs[0].Origin.RouteIndex", "0" },
            { "TripList.Trips[0].Legs[0].Origin.Cancelled", false },
            { "TripList.Trips[0].Legs[0].Origin.Track", "A" },
            { "TripList.Trips[0].Legs[0].Origin.RealtimeTrack", null },
            { "TripList.Trips[0].Legs[0].Origin.LocationType", LocationType.StopOrStation },
            { "TripList.Trips[0].Legs[0].Origin.Notes", 0 },
            { "TripList.Trips[0].Legs[0].Origin.Id","9022014012110001"  },
            { "TripList.Trips[0].Legs[0].Origin.Name", "Mölndal centrum, Mölndal" },
            { "TripList.Trips[0].Legs[0].Origin.DateTime", new DateTimeOffset(2016, 7, 31, 20, 32, 0, new TimeSpan(2, 0, 0)) },
            { "TripList.Trips[0].Legs[0].Origin.RealtimeDateTime", new DateTimeOffset(2016, 7, 31, 20, 32, 0, new TimeSpan(2, 0, 0)) },
            { "TripList.Trips[0].Legs[0].Origin.DirectDateTime", null },
            
            { "TripList.Trips[0].Legs[0].Destination.RouteIndex", "13" },
            { "TripList.Trips[0].Legs[0].Destination.Cancelled", true },
            { "TripList.Trips[0].Legs[0].Destination.Track", "C" },
            { "TripList.Trips[0].Legs[0].Destination.RealtimeTrack", null },
            { "TripList.Trips[0].Legs[0].Destination.LocationType", LocationType.StopOrStation },
            { "TripList.Trips[0].Legs[0].Destination.Notes", 2 },

            { "TripList.Trips[0].Legs[0].Destination.Notes[0].Key", "disruption-message" },
            { "TripList.Trips[0].Legs[0].Destination.Notes[0].Severity", NoteSeverity.Low },
            { "TripList.Trips[0].Legs[0].Destination.Notes[0].Priority", "1" },
            { "TripList.Trips[0].Legs[0].Destination.Notes[0].Message", "Linje 4, 7, 9 och 11, kör efter Centralstationen via Olskrokstorget, Redbergsplatsen och Ejdergatan till Gamlestadstorget och omvänt på grund av ett spårarbete. Detta beräknas pågå den 25 juli klockan 04:00 till 7 augusti klockan 04:00. Räkna med längre restid på sträckan. För mer information se Trafikläge på vasttrafik.se eller i appen Reseplaneraren." },

            { "TripList.Trips[0].Legs[0].Destination.Notes[1].Key", "disruption-message" },
            { "TripList.Trips[0].Legs[0].Destination.Notes[1].Severity", NoteSeverity.Low },
            { "TripList.Trips[0].Legs[0].Destination.Notes[1].Priority", "2" },
            { "TripList.Trips[0].Legs[0].Destination.Notes[1].Message", "Linje 4, 8 och 9, ingen spårvagnstrafik sträckan Gamlestadstorget - Angered och omvänt på grund av ett spårarbete. Buss 4E och 8E ersätter på sträckan. Detta beräknas pågå från 25 juli klockan 04:00 till 7 augusti klockan 04:00. För mer information se Trafikläge på vasttrafik.se eller i appen Reseplaneraren." },

            { "TripList.Trips[0].Legs[0].Destination.Id","9022014001950003"  },
            { "TripList.Trips[0].Legs[0].Destination.Name", "Centralstationen, Göteborg" },
            { "TripList.Trips[0].Legs[0].Destination.DateTime", new DateTimeOffset(2016, 7, 31, 20, 50, 0, new TimeSpan(2, 0, 0)) },
            { "TripList.Trips[0].Legs[0].Destination.RealtimeDateTime", new DateTimeOffset(2016, 7, 31, 20, 50, 0, new TimeSpan(2, 0, 0)) },
            { "TripList.Trips[0].Legs[0].Destination.DirectDateTime", null },
            
            { "TripList.Trips[1].TravelWarrenty", true },
            { "TripList.Trips[1].Alternative", false },
            { "TripList.Trips[1].Type", null },
            { "TripList.Trips[1].Valid", true },
            { "TripList.Trips[1].Legs", 1 },
            { "TripList.Trips[1].Legs[0].ForegroundColor", "#14823c" },
            { "TripList.Trips[1].Legs[0].Booking", true },
            { "TripList.Trips[1].Legs[0].Night", true },
            { "TripList.Trips[1].Legs[0].Direction", "Angered via Redbergsplatsen" },
            { "TripList.Trips[1].Legs[0].JourneyDetailReference.Reference", "https://api.vasttrafik.se/bin/rest.exe/v2/journeyDetail?ref=356286%2F147173%2F856806%2F309644%2F80%3Fdate%3D2016-07-31%26station_evaId%3D12110001%26station_type%3Ddep%26format%3Djson%26" },
            { "TripList.Trips[1].Legs[0].Cancelled", false },
            { "TripList.Trips[1].Legs[0].Kcal", null },
            { "TripList.Trips[1].Legs[0].Sname", "4" },
            { "TripList.Trips[1].Legs[0].Type", JourneyType.Tram },
            { "TripList.Trips[1].Legs[0].GeometryReference", null },
            { "TripList.Trips[1].Legs[0].BackgroundColor", "#ffffff" },
            { "TripList.Trips[1].Legs[0].Notes", 0 },
            { "TripList.Trips[1].Legs[0].Id", "9015014500404109" },
            { "TripList.Trips[1].Legs[0].Stroke", "Solid" },
            { "TripList.Trips[1].Legs[0].Reachable", true },
            { "TripList.Trips[1].Legs[0].Name", "Spårvagn 4" },
            { "TripList.Trips[1].Legs[0].PercentBikeRoad", null },
            { "TripList.Trips[1].Legs[0].Accessibility", Accessibility.WheelChair },

            { "TripList.Trips[1].Legs[0].Origin.RouteIndex", "0" },
            { "TripList.Trips[1].Legs[0].Origin.Cancelled", false },
            { "TripList.Trips[1].Legs[0].Origin.Track", "A" },
            { "TripList.Trips[1].Legs[0].Origin.RealtimeTrack", null },
            { "TripList.Trips[1].Legs[0].Origin.LocationType", LocationType.StopOrStation },
            { "TripList.Trips[1].Legs[0].Origin.Notes", 0 },
            { "TripList.Trips[1].Legs[0].Origin.Id","9022014012110001"  },
            { "TripList.Trips[1].Legs[0].Origin.Name", "Mölndal centrum, Mölndal" },
            { "TripList.Trips[1].Legs[0].Origin.DateTime", new DateTimeOffset(2016, 7, 31, 20, 37, 0, new TimeSpan(2, 0, 0)) },
            { "TripList.Trips[1].Legs[0].Origin.RealtimeDateTime", new DateTimeOffset(2016, 7, 31, 20, 38, 0, new TimeSpan(2, 0, 0)) },
            { "TripList.Trips[1].Legs[0].Origin.DirectDateTime", null },

            { "TripList.Trips[1].Legs[0].Destination.RouteIndex", "15" },
            { "TripList.Trips[1].Legs[0].Destination.Cancelled", false },
            { "TripList.Trips[1].Legs[0].Destination.Track", "A" },
            { "TripList.Trips[1].Legs[0].Destination.RealtimeTrack", null },
            { "TripList.Trips[1].Legs[0].Destination.LocationType", LocationType.StopOrStation },
            { "TripList.Trips[1].Legs[0].Destination.Notes", 2 },

            { "TripList.Trips[1].Legs[0].Destination.Notes[0].Key", "disruption-message" },
            { "TripList.Trips[1].Legs[0].Destination.Notes[0].Severity", NoteSeverity.Low },
            { "TripList.Trips[1].Legs[0].Destination.Notes[0].Priority", "1" },
            { "TripList.Trips[1].Legs[0].Destination.Notes[0].Message", "Linje 4, 7, 9 och 11, kör efter Centralstationen via Olskrokstorget, Redbergsplatsen och Ejdergatan till Gamlestadstorget och omvänt på grund av ett spårarbete. Detta beräknas pågå den 25 juli klockan 04:00 till 7 augusti klockan 04:00. Räkna med längre restid på sträckan. För mer information se Trafikläge på vasttrafik.se eller i appen Reseplaneraren." },

            { "TripList.Trips[1].Legs[0].Destination.Notes[1].Key", "disruption-message" },
            { "TripList.Trips[1].Legs[0].Destination.Notes[1].Severity", NoteSeverity.Low },
            { "TripList.Trips[1].Legs[0].Destination.Notes[1].Priority", "2" },
            { "TripList.Trips[1].Legs[0].Destination.Notes[1].Message", "Linje 4, 8 och 9, ingen spårvagnstrafik sträckan Gamlestadstorget - Angered och omvänt på grund av ett spårarbete. Buss 4E och 8E ersätter på sträckan. Detta beräknas pågå från 25 juli klockan 04:00 till 7 augusti klockan 04:00. För mer information se Trafikläge på vasttrafik.se eller i appen Reseplaneraren." },

            { "TripList.Trips[1].Legs[0].Destination.Id","9022014001950001"  },
            { "TripList.Trips[1].Legs[0].Destination.Name", "Centralstationen, Göteborg" },
            { "TripList.Trips[1].Legs[0].Destination.DateTime", new DateTimeOffset(2016, 7, 31, 20, 58, 0, new TimeSpan(2, 0, 0)) },
            { "TripList.Trips[1].Legs[0].Destination.RealtimeDateTime", new DateTimeOffset(2016, 7, 31, 20, 57, 0, new TimeSpan(2, 0, 0)) },
            { "TripList.Trips[1].Legs[0].Destination.DirectDateTime", null },
            
            { "TripList.Trips[2].TravelWarrenty", false },
            { "TripList.Trips[2].Alternative", true },
            { "TripList.Trips[2].Type", TripType.Walk },
            { "TripList.Trips[2].Valid", false },
            { "TripList.Trips[2].Legs", 1 },
            { "TripList.Trips[2].Legs[0].ForegroundColor", "#fff014" },
            { "TripList.Trips[2].Legs[0].Booking", false },
            { "TripList.Trips[2].Legs[0].Direction", "Frölunda via Järntorget" },
            { "TripList.Trips[2].Legs[0].JourneyDetailReference.Reference", "https://api.vasttrafik.se/bin/rest.exe/v2/journeyDetail?ref=65313%2F50139%2F387298%2F171885%2F80%3Fdate%3D2016-07-31%26station_evaId%3D12110001%26station_type%3Ddep%26format%3Djson%26" },
            { "TripList.Trips[2].Legs[0].Cancelled", false },
            { "TripList.Trips[2].Legs[0].Kcal", 50f },
            { "TripList.Trips[2].Legs[0].PercentBikeRoad", 70f },
            { "TripList.Trips[2].Legs[0].Sname", "2" },
            { "TripList.Trips[2].Legs[0].Type", JourneyType.Tram },
            { "TripList.Trips[2].Legs[0].GeometryReference.Reference", "ABC" },
            { "TripList.Trips[2].Legs[0].BackgroundColor", "#00394d" },
            { "TripList.Trips[2].Legs[0].Notes", 1 },

            { "TripList.Trips[2].Legs[0].Notes[0].Key", "disruption-message" },
            { "TripList.Trips[2].Legs[0].Notes[0].Severity", NoteSeverity.Low },
            { "TripList.Trips[2].Legs[0].Notes[0].Priority", "1" },
            { "TripList.Trips[2].Legs[0].Notes[0].Message", "Linje 4, 7, 9 och 11, kör efter Centralstationen via Olskrokstorget, Redbergsplatsen och Ejdergatan till Gamlestadstorget och omvänt på grund av ett spårarbete. Detta beräknas pågå den 25 juli klockan 04:00 till 7 augusti klockan 04:00. Räkna med längre restid på sträckan. För mer information se Trafikläge på vasttrafik.se eller i appen Reseplaneraren." },


            { "TripList.Trips[2].Legs[0].Id", "9015014500204114" },
            { "TripList.Trips[2].Legs[0].Stroke", "Solid" },
            { "TripList.Trips[2].Legs[0].Reachable", true },
            { "TripList.Trips[2].Legs[0].Name", "Spårvagn 2" },
            { "TripList.Trips[2].Legs[0].Night", false },
            { "TripList.Trips[2].Legs[0].Accessibility", Accessibility.WheelChair },

            { "TripList.Trips[2].Legs[0].Origin.RouteIndex", "0" },
            { "TripList.Trips[2].Legs[0].Origin.Cancelled", false },
            { "TripList.Trips[2].Legs[0].Origin.Track", "A" },
            { "TripList.Trips[2].Legs[0].Origin.RealtimeTrack", "A" },
            { "TripList.Trips[2].Legs[0].Origin.LocationType", LocationType.StopOrStation },
            { "TripList.Trips[2].Legs[0].Origin.Notes", 0 },
            { "TripList.Trips[2].Legs[0].Origin.Id","9022014012110001"  },
            { "TripList.Trips[2].Legs[0].Origin.Name", "Mölndal centrum, Mölndal" },
            { "TripList.Trips[2].Legs[0].Origin.DateTime", new DateTimeOffset(2016, 7, 31, 20, 47, 0, new TimeSpan(2, 0, 0)) },
            { "TripList.Trips[2].Legs[0].Origin.RealtimeDateTime", new DateTimeOffset(2016, 7, 31, 20, 47, 0, new TimeSpan(2, 0, 0)) },
            { "TripList.Trips[2].Legs[0].Origin.DirectDateTime", new DateTimeOffset(2016, 7, 31, 20, 47, 0, new TimeSpan(2, 0, 0)) },

            { "TripList.Trips[2].Legs[0].Destination.RouteIndex", "13" },
            { "TripList.Trips[2].Legs[0].Destination.Cancelled", false },
            { "TripList.Trips[2].Legs[0].Destination.Track", "C" },
            { "TripList.Trips[2].Legs[0].Destination.RealtimeTrack", "C" },
            { "TripList.Trips[2].Legs[0].Destination.LocationType", LocationType.StopOrStation },
            { "TripList.Trips[2].Legs[0].Destination.Notes", 1 },

            { "TripList.Trips[2].Legs[0].Destination.Notes[0].Key", "disruption-message" },
            { "TripList.Trips[2].Legs[0].Destination.Notes[0].Severity", NoteSeverity.Low },
            { "TripList.Trips[2].Legs[0].Destination.Notes[0].Priority", "1" },
            { "TripList.Trips[2].Legs[0].Destination.Notes[0].Message", "Linje 4, 7, 9 och 11, kör efter Centralstationen via Olskrokstorget, Redbergsplatsen och Ejdergatan till Gamlestadstorget och omvänt på grund av ett spårarbete. Detta beräknas pågå den 25 juli klockan 04:00 till 7 augusti klockan 04:00. Räkna med längre restid på sträckan. För mer information se Trafikläge på vasttrafik.se eller i appen Reseplaneraren." },

            { "TripList.Trips[2].Legs[0].Destination.Id","9022014001950003"  },
            { "TripList.Trips[2].Legs[0].Destination.Name", "Centralstationen, Göteborg" },
            { "TripList.Trips[2].Legs[0].Destination.DateTime", new DateTimeOffset(2016, 7, 31, 21, 5, 0, new TimeSpan(2, 0, 0)) },
            { "TripList.Trips[2].Legs[0].Destination.RealtimeDateTime", new DateTimeOffset(2016, 7, 31, 21, 5, 0, new TimeSpan(2, 0, 0)) },
            { "TripList.Trips[2].Legs[0].Destination.DirectDateTime", null }
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void TripJsonParsing(string property, object expected)
        {
            TestValue<TripRoot>(property, expected);
        }

        [Fact]
        public void TripOnDeserialized()
        {
            JsonConvert.DeserializeObject<Trip>("{}");
            JsonConvert.DeserializeObject<TripList>("{}");
        }
    }
}
