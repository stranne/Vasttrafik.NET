using System;
using System.Collections.Generic;
using Stranne.VasttrafikNET.ApiModels.TrafficSituations;
using Stranne.VasttrafikNET.ApiModels.TrafficSituations.Enum;
using Stranne.VasttrafikNET.Tests.Jsons;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.JsonParsing
{
    public class TrafficSituationsJourneiesJsonTest : BaseJsonTest
    {
        public TrafficSituationsJourneiesJsonTest()
            : base(JsonFile.TrafficSituationsJourneies)
        { }

        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "", 1 },
            { "[0].SituationNumber", "RT1292472" },
            { "[0].CreationTime", new DateTimeOffset(2018, 5, 22, 8, 6, 58, 60, new TimeSpan(2, 0, 0)) },
            { "[0].StartTime", new DateTimeOffset(2018, 5, 18, 8, 5, 0, new TimeSpan(2, 0, 0)) },
            { "[0].EndTime", new DateTimeOffset(2018, 5, 30, 13, 50, 0, new TimeSpan(2, 0, 0)) },
            { "[0].Severity", TrafficSituationSeverity.Slight },
            { "[0].Title", "Västtåg, körs med olika fordonstyp från Uddevalla mot Borås klockan 13:17 (tåg 3831)." },
            { "[0].Description", "Vi byter fordon från Grästorp mot Borås. Orsaken är växelfel." },
            { "[0].AffectedStopPoints", 4 },
            { "[0].AffectedStopPoints[0].Gid", "9022014021120003" },
            { "[0].AffectedStopPoints[0].Name", "Uddevalla central (tåg)" },
            { "[0].AffectedStopPoints[0].ShortName", "Uddevalla C tåg" },
            { "[0].AffectedStopPoints[0].StopAreaGid", "9021014021120000" },
            { "[0].AffectedStopPoints[0].StopAreaName", "Uddevalla central (tåg)" },
            { "[0].AffectedStopPoints[0].StopAreaShortName", "Uddevalla C tåg" },
            { "[0].AffectedStopPoints[0].MunicipalityName", "Uddevalla" },
            { "[0].AffectedStopPoints[0].MunicipalityNumber", 1485 },
            { "[0].AffectedStopPoints[1].Gid", "9022014080800003" },
            { "[0].AffectedStopPoints[1].Name", "Öxnered station (tåg)" },
            { "[0].AffectedStopPoints[1].ShortName", "Öxnered stn" },
            { "[0].AffectedStopPoints[1].StopAreaGid", "9021014080800000" },
            { "[0].AffectedStopPoints[1].StopAreaName", "Öxnered station (tåg)" },
            { "[0].AffectedStopPoints[1].StopAreaShortName", "Öxnered stn" },
            { "[0].AffectedStopPoints[1].MunicipalityName", "Vänersborg" },
            { "[0].AffectedStopPoints[1].MunicipalityNumber", 1487 },
            { "[0].AffectedStopPoints[2].Gid", "9022014080802001" },
            { "[0].AffectedStopPoints[2].Name", "Vänersborg central" },
            { "[0].AffectedStopPoints[2].ShortName", "Vänersborg C" },
            { "[0].AffectedStopPoints[2].StopAreaGid", "9021014080802000" },
            { "[0].AffectedStopPoints[2].StopAreaName", "Vänersborg central" },
            { "[0].AffectedStopPoints[2].StopAreaShortName", "Vänersborg C" },
            { "[0].AffectedStopPoints[2].MunicipalityName", "Vänersborg" },
            { "[0].AffectedStopPoints[2].MunicipalityNumber", 1487 },
            { "[0].AffectedStopPoints[3].Gid", "9022014080801002" },
            { "[0].AffectedStopPoints[3].Name", "Vargön station" },
            { "[0].AffectedStopPoints[3].ShortName", "Vargön station" },
            { "[0].AffectedStopPoints[3].StopAreaGid", "9021014080801000" },
            { "[0].AffectedStopPoints[3].StopAreaName", "Vargön station" },
            { "[0].AffectedStopPoints[3].StopAreaShortName", "Vargön station" },
            { "[0].AffectedStopPoints[3].MunicipalityName", "Vänersborg" },
            { "[0].AffectedStopPoints[3].MunicipalityNumber", 1487 },
            { "[0].AffectedLines", 0 },
            { "[0].AffectedJourneys", 1 },
            { "[0].AffectedJourneys[0].Gid", "9015014167103831" },
            { "[0].AffectedJourneys[0].Line.Gid", "9011014167100000" },
            { "[0].AffectedJourneys[0].Line.Name", "Västtågen" },
            { "[0].AffectedJourneys[0].Line.TechnicalNumber", 1671 },
            { "[0].AffectedJourneys[0].Line.Designation", "TÅG" },
            { "[0].AffectedJourneys[0].Line.DefaultTransportModeCode", "train" },
            { "[0].AffectedJourneys[0].Line.TransportAuthorityCode", "vt" },
            { "[0].AffectedJourneys[0].Line.TransportAuthorityName", "Västtrafik" },
            { "[0].AffectedJourneys[0].Line.TextColor", "FFFFFF" },
            { "[0].AffectedJourneys[0].Line.BackgroundColor", "00A5DC" },
            { "[0].AffectedJourneys[0].Line.Directions", 2 },
            { "[0].AffectedJourneys[0].Line.Directions[0].Gid", "9014014167110000" },
            { "[0].AffectedJourneys[0].Line.Directions[0].DirectionCode", 1 },
            { "[0].AffectedJourneys[0].Line.Directions[0].Name", "Uddevalla - Borås - Varberg" },
            { "[0].AffectedJourneys[0].Line.Directions[1].Gid", "9014014167120000" },
            { "[0].AffectedJourneys[0].Line.Directions[1].DirectionCode", 2 },
            { "[0].AffectedJourneys[0].Line.Directions[1].Name", "Varberg - Borås - Uddevalla" },
            { "[0].AffectedJourneys[0].Line.Municipalities", 8 },
            { "[0].AffectedJourneys[0].Line.Municipalities[0].MunicipalityNumber", 1470 },
            { "[0].AffectedJourneys[0].Line.Municipalities[0].MunicipalityName", "Vara" },
            { "[0].AffectedJourneys[0].Line.Municipalities[1].MunicipalityNumber", 1463 },
            { "[0].AffectedJourneys[0].Line.Municipalities[1].MunicipalityName", "Mark" },
            { "[0].AffectedJourneys[0].Line.Municipalities[2].MunicipalityNumber", 1466 },
            { "[0].AffectedJourneys[0].Line.Municipalities[2].MunicipalityName", "Herrljunga" },
            { "[0].AffectedJourneys[0].Line.Municipalities[3].MunicipalityNumber", 1487 },
            { "[0].AffectedJourneys[0].Line.Municipalities[3].MunicipalityName", "Vänersborg" },
            { "[0].AffectedJourneys[0].Line.Municipalities[4].MunicipalityNumber", 1490 },
            { "[0].AffectedJourneys[0].Line.Municipalities[4].MunicipalityName", "Borås" },
            { "[0].AffectedJourneys[0].Line.Municipalities[5].MunicipalityNumber", 1383 },
            { "[0].AffectedJourneys[0].Line.Municipalities[5].MunicipalityName", "Varberg" },
            { "[0].AffectedJourneys[0].Line.Municipalities[6].MunicipalityNumber", 1485 },
            { "[0].AffectedJourneys[0].Line.Municipalities[6].MunicipalityName", "Uddevalla" },
            { "[0].AffectedJourneys[0].Line.Municipalities[7].MunicipalityNumber", 1444 },
            { "[0].AffectedJourneys[0].Line.Municipalities[7].MunicipalityName", "Grästorp" },
            { "[0].AffectedJourneys[0].Line.AffectedStopPointGids", 4 },
            { "[0].AffectedJourneys[0].Line.AffectedStopPointGids[0]", "9022014021120003" },
            { "[0].AffectedJourneys[0].Line.AffectedStopPointGids[1]", "9022014080800003" },
            { "[0].AffectedJourneys[0].Line.AffectedStopPointGids[2]", "9022014080802001" },
            { "[0].AffectedJourneys[0].Line.AffectedStopPointGids[3]", "9022014080801002" }
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void TrafficSituationsJourniesJsonParsing(string property, object expected)
        {
            TestValue<IEnumerable<TrafficSituationApiModel>>(property, expected);
        }
    }
}
