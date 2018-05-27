using System;
using System.Collections.Generic;
using Stranne.VasttrafikNET.ApiModels.TrafficSituations;
using Stranne.VasttrafikNET.ApiModels.TrafficSituations.Enum;
using Stranne.VasttrafikNET.Tests.Jsons;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.JsonParsing
{
    public class TrafficSituationsStopAreasJsonTest : BaseJsonTest
    {
        public TrafficSituationsStopAreasJsonTest()
            : base(JsonFile.TrafficSituationsStopAreas)
        { }

        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "", 1 },
            { "[0].SituationNumber", "RT1134469" },
            { "[0].CreationTime", new DateTimeOffset(2018, 5, 16, 6, 10, 39, 63, new TimeSpan(2, 0, 0)) },
            { "[0].StartTime", new DateTimeOffset(2018, 3, 21, 14, 43, 0, new TimeSpan(1, 0, 0)) },
            { "[0].EndTime", new DateTimeOffset(2018, 6, 15, 12, 0, 0, new TimeSpan(2, 0, 0)) },
            { "[0].Severity", TrafficSituationSeverity.Slight },
            { "[0].Title", "Västtåg förstärks med buss från Vara resecentrum mot Framnäs City klockan 07:16 (tåg 3356)." },
            { "[0].Description", "Förstärkningsbuss går från Vara resecentrum klockan 07:20 direkt till Framnäs City. Tåget förstärks på grund av många resande." },
            { "[0].AffectedStopPoints", 2 },
            { "[0].AffectedStopPoints[0].Gid", "9022014037386001" },
            { "[0].AffectedStopPoints[0].Name", "Framnäs city" },
            { "[0].AffectedStopPoints[0].ShortName", "Framnäs city" },
            { "[0].AffectedStopPoints[0].StopAreaGid", "9021014037386000" },
            { "[0].AffectedStopPoints[0].StopAreaName", "Framnäs city" },
            { "[0].AffectedStopPoints[0].StopAreaShortName", "Framnäs city" },
            { "[0].AffectedStopPoints[0].MunicipalityName", "Lidköping" },
            { "[0].AffectedStopPoints[0].MunicipalityNumber", 1494 },
            { "[0].AffectedStopPoints[1].Gid", "9022014040010002" },
            { "[0].AffectedStopPoints[1].Name", "Vara resecentrum (tåg)" },
            { "[0].AffectedStopPoints[1].ShortName", "Vara resecentrum" },
            { "[0].AffectedStopPoints[1].StopAreaGid", "9021014040010000" },
            { "[0].AffectedStopPoints[1].StopAreaName", "Vara resecentrum (tåg)" },
            { "[0].AffectedStopPoints[1].StopAreaShortName", "Vara resecentrum" },
            { "[0].AffectedStopPoints[1].MunicipalityName", "Vara" },
            { "[0].AffectedStopPoints[1].MunicipalityNumber", 1470 },
            { "[0].AffectedLines", 0 },
            { "[0].AffectedJourneys", 0 }
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void TrafficSituationsStopAreasJsonParsing(string property, object expected)
        {
            TestValue<IEnumerable<TrafficSituationApiModel>>(property, expected);
        }
    }
}
