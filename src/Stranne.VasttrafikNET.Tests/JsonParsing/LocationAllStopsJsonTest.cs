using System;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner;
using Stranne.VasttrafikNET.Tests.Json;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.JsonParsing
{
    public class LocationAllStopsJsonTest : BaseJsonTest
    {
        protected override string Json => LocationAllStopsJson.Json;

        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "LocationList.CoordLocation", 0 },
            { "LocationList.StopLocation", 3 },
            { "LocationList.StopLocation[0].Name", "Långegärde, Strömstad" },
            { "LocationList.StopLocation[0].Id", "9021014026420000" },
            { "LocationList.StopLocation[0].Index", null },
            { "LocationList.StopLocation[0].Latitude", 58.891462 },
            { "LocationList.StopLocation[0].Longitude", 11.007759 },
            { "LocationList.StopLocation[0].Weight", 53m },
            { "LocationList.StopLocation[0].Track", null },

            { "LocationList.StopLocation[1].Name", "Långegärde, Strömstad" },
            { "LocationList.StopLocation[1].Id", "9022014026420001" },
            { "LocationList.StopLocation[1].Index", null },
            { "LocationList.StopLocation[1].Latitude", 58.891462 },
            { "LocationList.StopLocation[1].Longitude", 11.007759 },
            { "LocationList.StopLocation[1].Weight", 53m },
            { "LocationList.StopLocation[1].Track", "A" },

            { "LocationList.StopLocation[2].Name", "Västra bryggan, Strömstad" },
            { "LocationList.StopLocation[2].Id", "9021014026421000" },
            { "LocationList.StopLocation[2].Index", null },
            { "LocationList.StopLocation[2].Latitude", 58.893080 },
            { "LocationList.StopLocation[2].Longitude", 11.009988 },
            { "LocationList.StopLocation[2].Weight", 574m },
            { "LocationList.StopLocation[2].Track", null }
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void LocationAllStopsJsonParsing(string property, object expected)
        {
            TestValue<LocationRoot>(property, expected);
        }
    }
}
