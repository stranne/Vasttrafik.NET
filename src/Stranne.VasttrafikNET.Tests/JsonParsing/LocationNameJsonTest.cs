using System;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner.Enums;
using Stranne.VasttrafikNET.Tests.Json;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.JsonParsing
{
    public class LocationNameJsonTest : BaseJsonTest
    {
        protected override JsonFile JsonFile => JsonFile.LocationName;

        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "LocationList.ServerDateTime", new DateTimeOffset(2016, 7, 31, 18, 30, 0, new TimeSpan(2, 0, 0)) },
            { "LocationList.CoordLocation", 3 },
            { "LocationList.CoordLocation[0].Name", "Pressbyrån, Centralstationen Entrehallen" },
            { "LocationList.CoordLocation[0].Index", "2" },
            { "LocationList.CoordLocation[0].Latitude", 57.708725 },
            { "LocationList.CoordLocation[0].Longitude", 11.972993 },
            { "LocationList.CoordLocation[0].LocationType", LocationType.PointOfInterest },

            { "LocationList.CoordLocation[1].Name", "Pressbyrån, Centralstationen spår 1" },
            { "LocationList.CoordLocation[1].Index", "3" },
            { "LocationList.CoordLocation[1].Latitude", 57.709021 },
            { "LocationList.CoordLocation[1].Longitude", 11.972643 },
            { "LocationList.CoordLocation[1].LocationType", LocationType.PointOfInterest },

            { "LocationList.CoordLocation[2].Name", "Pressbyrån, Centralstationen spår 7-8" },
            { "LocationList.CoordLocation[2].Index", "4" },
            { "LocationList.CoordLocation[2].Latitude", 57.709021 },
            { "LocationList.CoordLocation[2].Longitude", 11.972643 },
            { "LocationList.CoordLocation[2].LocationType", LocationType.PointOfInterest },

            { "LocationList.StopLocation", 3 },
            { "LocationList.StopLocation[0].Name", "Centralstationen, Göteborg" },
            { "LocationList.StopLocation[0].Id", "9021014001950000" },
            { "LocationList.StopLocation[0].Index", "1" },
            { "LocationList.StopLocation[0].Latitude", 57.707898 },
            { "LocationList.StopLocation[0].Longitude", 11.973740 },
            { "LocationList.StopLocation[0].Weight", null },
            { "LocationList.StopLocation[0].Track", null },

            { "LocationList.StopLocation[1].Name", "MÖLNDAL STATION/CENTRUM" },
            { "LocationList.StopLocation[1].Id", "0000000800000002" },
            { "LocationList.StopLocation[1].Index", "7" },
            { "LocationList.StopLocation[1].Latitude", 57.656129 },
            { "LocationList.StopLocation[1].Longitude", 12.017014 },
            { "LocationList.StopLocation[1].Weight", null },
            { "LocationList.StopLocation[1].Track", null },

            { "LocationList.StopLocation[2].Name", "Kabelstationen, Falköping" },
            { "LocationList.StopLocation[2].Id", "9021014041107000" },
            { "LocationList.StopLocation[2].Index", "8" },
            { "LocationList.StopLocation[2].Latitude", 58.235286 },
            { "LocationList.StopLocation[2].Longitude", 13.547877 },
            { "LocationList.StopLocation[2].Weight", null },
            { "LocationList.StopLocation[2].Track", null }
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void LocationNameJsonParsing(string property, object expected)
        {
            TestValue<LocationRoot>(property, expected);
        }
    }
}
