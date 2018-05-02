using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner;
using Stranne.VasttrafikNET.Tests.Jsons;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.JsonParsing
{
    public class GemoetryJsonTest : BaseJsonTest
    {
        public GemoetryJsonTest()
            : base(JsonFile.Geometry)
        { }

        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "Geometry.ServerDateTime", new DateTimeOffset(2016, 8, 4, 20, 21, 0, new TimeSpan(2, 0, 0)) },
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
            { "Geometry.Points[2].Index", "2" },
            { "Geometry.Points[2].Altitude", 750 },
            { "Geometry.Itineraries", 1 },
            { "Geometry.Itineraries[0].Distance", "500" },
            { "Geometry.Itineraries[0].PointIndex", "1" },
            { "Geometry.Itineraries[0].Value", "A" }
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void GeometryJsonParsing(string property, object expected)
        {
            TestValue<GeometryRoot>(property, expected);
        }

        [Fact]
        public void GeometryOnDeserialized()
        {
            JsonConvert.DeserializeObject<Geometry>("{}");
        }
    }
}
