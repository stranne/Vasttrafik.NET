using System;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner.Enums;
using Stranne.VasttrafikNET.Tests.Json;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.JsonParsing
{
    public class LocationNearbyAddressJsonTest : BaseJsonTest
    {
        protected override string Json => LocationNearbyAddressJson.Json;

        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "LocationList.StopLocation", 0 },
            { "LocationList.CoordLocation", 1 },
            { "LocationList.CoordLocation[0].Name", "Södra Hamngatan 11, 411 14 Göteborg" },
            { "LocationList.CoordLocation[0].Index", null },
            { "LocationList.CoordLocation[0].Latitude", 57.705686 },
            { "LocationList.CoordLocation[0].Longitude", 11.963654 },
            { "LocationList.CoordLocation[0].LocationType", LocationType.Address }
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void LocationNearbyAddressJsonParsing(string property, object expected)
        {
            TestValue<LocationRoot>(property, expected);
        }
    }
}
