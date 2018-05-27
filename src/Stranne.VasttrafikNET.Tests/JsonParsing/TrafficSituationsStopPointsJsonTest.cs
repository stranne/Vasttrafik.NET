using System;
using System.Collections.Generic;
using Stranne.VasttrafikNET.ApiModels.TrafficSituations;
using Stranne.VasttrafikNET.ApiModels.TrafficSituations.Enum;
using Stranne.VasttrafikNET.Tests.Jsons;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.JsonParsing
{
    public class TrafficSituationsStopPointsJsonTest : BaseJsonTest
    {
        public TrafficSituationsStopPointsJsonTest()
            : base(JsonFile.TrafficSituationsStopPoints)
        { }

        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "", 2 },
            { "[0].SituationNumber", "RT1270614" },
            { "[0].CreationTime", new DateTimeOffset(2018, 5, 16, 6, 10, 39, 1, new TimeSpan(2, 0, 0)) },
            { "[0].StartTime", new DateTimeOffset(2018, 4, 16, 15, 27, 0, new TimeSpan(2, 0, 0)) },
            { "[0].EndTime", new DateTimeOffset(2018, 12, 8, 22, 0, 0, new TimeSpan(1, 0, 0)) },
            { "[0].Severity", TrafficSituationSeverity.Severe },
            { "[0].Title", "Västtågen Säffle station - Öxnered station, flera inställda avgångar." },
            { "[0].Description", "Bussar ersätter. Detta gäller från 5 mars klockan 04:00 till 8 december klockan 22:00. Information om inställda avgångar och ersättningsbussar finns på vasttrafik.se. Orsaken är banarbete." },
            { "[0].AffectedStopPoints", 5 },
            { "[0].AffectedStopPoints[0].Gid", "9022014016200002" },
            { "[0].AffectedStopPoints[0].Name", "Bohus station" },
            { "[0].AffectedStopPoints[0].ShortName", "Bohus station" },
            { "[0].AffectedStopPoints[0].StopAreaGid", "9021014016200000" },
            { "[0].AffectedStopPoints[0].StopAreaName", "Bohus station" },
            { "[0].AffectedStopPoints[0].StopAreaShortName", "Bohus station" },
            { "[0].AffectedStopPoints[0].MunicipalityName", "Ale" },
            { "[0].AffectedStopPoints[0].MunicipalityNumber", 1440 },
            { "[0].AffectedStopPoints[1].Gid", "9022014016200003" },
            { "[0].AffectedStopPoints[1].Name", "Bohus station" },
            { "[0].AffectedStopPoints[1].ShortName", "Bohus station" },
            { "[0].AffectedStopPoints[1].StopAreaGid", "9021014016200000" },
            { "[0].AffectedStopPoints[1].StopAreaName", "Bohus station" },
            { "[0].AffectedStopPoints[1].StopAreaShortName", "Bohus station" },
            { "[0].AffectedStopPoints[1].MunicipalityName", "Ale" },
            { "[0].AffectedStopPoints[1].MunicipalityNumber", 1440 },
            { "[0].AffectedLines", 0 },
            { "[0].AffectedJourneys", 0 }
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void TrafficSituationsStopPointsJsonParsing(string property, object expected)
        {
            TestValue<IEnumerable<TrafficSituationApiModel>>(property, expected);
        }
    }
}
