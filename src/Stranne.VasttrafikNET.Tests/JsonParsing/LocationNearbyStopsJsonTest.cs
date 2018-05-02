using Stranne.VasttrafikNET.ApiModels.JourneyPlanner;
using Stranne.VasttrafikNET.Tests.Jsons;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.JsonParsing
{
    public class LocationNearbyStopsJsonTest : BaseJsonTest
    {
        public LocationNearbyStopsJsonTest()
            : base(JsonFile.LocationNearbyStops)
        { }

        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "LocationList.CoordLocation", 0 },
            { "LocationList.StopLocation", 3 },
            { "LocationList.StopLocation[0].Name", "Domkyrkan, Göteborg" },
            { "LocationList.StopLocation[0].Id", "9022014002130001" },
            { "LocationList.StopLocation[0].Index", null },
            { "LocationList.StopLocation[0].Latitude", 57.704455 },
            { "LocationList.StopLocation[0].Longitude", 11.963636 },
            { "LocationList.StopLocation[0].Weight", null },
            { "LocationList.StopLocation[0].Track", "A" },

            { "LocationList.StopLocation[1].Name", "Domkyrkan, Göteborg" },
            { "LocationList.StopLocation[1].Id", "9021014002130000" },
            { "LocationList.StopLocation[1].Index", null },
            { "LocationList.StopLocation[1].Latitude", 57.704302 },
            { "LocationList.StopLocation[1].Longitude", 11.963699 },
            { "LocationList.StopLocation[1].Weight", null },
            { "LocationList.StopLocation[1].Track", null },

            { "LocationList.StopLocation[2].Name", "Domkyrkan, Göteborg" },
            { "LocationList.StopLocation[2].Id", "9022014002130002" },
            { "LocationList.StopLocation[2].Index", null },
            { "LocationList.StopLocation[2].Latitude", 57.704131 },
            { "LocationList.StopLocation[2].Longitude", 11.963761 },
            { "LocationList.StopLocation[2].Weight", null },
            { "LocationList.StopLocation[2].Track", "B" }
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void LocationNearbyStopsJsonParsing(string property, object expected)
        {
            TestValue<LocationRoot>(property, expected);
        }
    }
}
