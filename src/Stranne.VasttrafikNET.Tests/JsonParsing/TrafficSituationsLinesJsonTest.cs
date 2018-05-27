using System;
using System.Collections.Generic;
using Stranne.VasttrafikNET.ApiModels.TrafficSituations;
using Stranne.VasttrafikNET.ApiModels.TrafficSituations.Enum;
using Stranne.VasttrafikNET.Tests.Jsons;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.JsonParsing
{
    public class TrafficSituationsLinesJsonTest : BaseJsonTest
    {
        public TrafficSituationsLinesJsonTest()
            : base(JsonFile.TrafficSituationsLines)
        { }

        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "", 1 },
            { "[0].SituationNumber", "RT1193381" },
            { "[0].CreationTime", new DateTimeOffset(2018, 5, 16, 6, 10, 39, 283, new TimeSpan(2, 0, 0)) },
            { "[0].StartTime", new DateTimeOffset(2018, 3, 30, 16, 6, 0, new TimeSpan(2, 0, 0)) },
            { "[0].EndTime", new DateTimeOffset(2018, 6, 30, 23, 59, 0, new TimeSpan(2, 0, 0)) },
            { "[0].Severity", TrafficSituationSeverity.Normal },
            { "[0].Title", "Linje 82 och 758 stannar inte vid Fältspatsgatan i båda riktningar." },
            { "[0].Description", "Närmaste hållplats är Olof Asklunds gata. Detta gäller från 20 november klockan 09:00 och tillsvidare." },
            { "[0].AffectedStopPoints", 0 },
            { "[0].AffectedLines", 1 },
            { "[0].AffectedLines[0].Gid", "9011014508200000" },
            { "[0].AffectedLines[0].Name", null },
            { "[0].AffectedLines[0].TechnicalNumber", 5082 },
            { "[0].AffectedLines[0].Designation", "82" },
            { "[0].AffectedLines[0].DefaultTransportModeCode", "bus" },
            { "[0].AffectedLines[0].TransportAuthorityCode", "vt" },
            { "[0].AffectedLines[0].TransportAuthorityName", "Västtrafik" },
            { "[0].AffectedLines[0].TextColor", "FFFFFF" },
            { "[0].AffectedLines[0].BackgroundColor", "00A5DC" },
            { "[0].AffectedLines[0].Directions", 2 },
            { "[0].AffectedLines[0].Directions[0].Gid", "9014014508210000" },
            { "[0].AffectedLines[0].Directions[0].DirectionCode", 1 },
            { "[0].AffectedLines[0].Directions[0].Name", "Marklandsgatan - Brottkärr" },
            { "[0].AffectedLines[0].Directions[1].Gid", "9014014508220000" },
            { "[0].AffectedLines[0].Directions[1].DirectionCode", 2 },
            { "[0].AffectedLines[0].Directions[1].Name", "Brottkärr - Marklandsgatan" },
            { "[0].AffectedLines[0].Municipalities", 1 },
            { "[0].AffectedLines[0].Municipalities[0].MunicipalityNumber", 1480 },
            { "[0].AffectedLines[0].Municipalities[0].MunicipalityName", "Göteborg" },
            { "[0].AffectedLines[0].AffectedStopPointGids", 0 },
            { "[0].AffectedJourneys", 0 }
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void TrafficSituationsLinesJsonParsing(string property, object expected)
        {
            TestValue<IEnumerable<TrafficSituationApiModel>>(property, expected);
        }
    }
}
