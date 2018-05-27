using System;
using Stranne.VasttrafikNET.ApiModels.TrafficSituations;
using Stranne.VasttrafikNET.ApiModels.TrafficSituations.Enum;
using Stranne.VasttrafikNET.Tests.Jsons;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.JsonParsing
{
    public class TrafficSituationJsonTest : BaseJsonTest
    {
        public TrafficSituationJsonTest()
            : base(JsonFile.TrafficSituation)
        { }

        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "SituationNumber", "RT1193380" },
            { "CreationTime", new DateTimeOffset(2018, 5, 16, 6, 10, 39, 282, new TimeSpan(2, 0, 0)) },
            { "StartTime", new DateTimeOffset(2018, 4, 30, 16, 6, 0, new TimeSpan(2, 0, 0)) },
            { "EndTime", new DateTimeOffset(2018, 5, 30, 23, 59, 0, new TimeSpan(2, 0, 0)) },
            { "Severity", TrafficSituationSeverity.Severe },
            { "Title", "Linje 82 och 758 stannar inte vid Fältspatsgatan i båda riktningar." },
            { "Description", "Närmaste hållplats är Olof Asklunds gata. Detta gäller från 20 november klockan 09:00 och tillsvidare." },
            { "AffectedStopPoints", 0 },
            { "AffectedLines", 1 },
            { "AffectedLines[0].Gid", "9011014508200000" },
            { "AffectedLines[0].Name", null },
            { "AffectedLines[0].TechnicalNumber", 5082 },
            { "AffectedLines[0].Designation", "82" },
            { "AffectedLines[0].DefaultTransportModeCode", "bus" },
            { "AffectedLines[0].TransportAuthorityCode", "vt" },
            { "AffectedLines[0].TransportAuthorityName", "Västtrafik" },
            { "AffectedLines[0].TextColor", "FFFFFF" },
            { "AffectedLines[0].BackgroundColor", "00A5DC" },
            { "AffectedLines[0].Directions", 2 },
            { "AffectedLines[0].Directions[0].Gid", "9014014508210000" },
            { "AffectedLines[0].Directions[0].DirectionCode", 1 },
            { "AffectedLines[0].Directions[0].Name", "Marklandsgatan - Brottkärr" },
            { "AffectedLines[0].Directions[1].Gid", "9014014508220000" },
            { "AffectedLines[0].Directions[1].DirectionCode", 2 },
            { "AffectedLines[0].Directions[1].Name", "Brottkärr - Marklandsgatan" },
            { "AffectedLines[0].Municipalities", 1 },
            { "AffectedLines[0].Municipalities[0].MunicipalityNumber", 1480 },
            { "AffectedLines[0].Municipalities[0].MunicipalityName", "Göteborg" },
            { "AffectedLines[0].AffectedStopPointGids", 0 },
            { "AffectedJourneys", 0 }
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void TrafficSituationJsonParsing(string property, object expected)
        {
            TestValue<TrafficSituationApiModel>(property, expected);
        }
    }
}
