using Stranne.VasttrafikNET.ApiModels.JourneyPlanner;
using Stranne.VasttrafikNET.Tests.Json;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.JsonParsing
{
    public class GemoetryJsonTest : BaseJsonTest
    {
        protected override string Json => GeometryJson.Json;

        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "Geometry.Itineraries", 0 },
            { "Geometry.Points", 3 },
            { "Geometry.Points[0].Latitude", 57.728726 },
            { "Geometry.Points[0].Longitude", 11.752137 },
            { "Geometry.Points[0].Index", null },
            { "Geometry.Points[0].Altitude", null },
            { "Geometry.Points[1].Latitude", 57.728806 },
            { "Geometry.Points[1].Longitude", 11.752173 },
            { "Geometry.Points[1].Index", null },
            { "Geometry.Points[1].Altitude", null },
            { "Geometry.Points[2].Latitude", 57.728923 },
            { "Geometry.Points[2].Longitude", 11.752803 },
            { "Geometry.Points[2].Index", null },
            { "Geometry.Points[2].Altitude", null }
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void GeometryJsonParsing(string property, object expected)
        {
            TestValue<GeometryRoot>(property, expected);
        }
    }
}
