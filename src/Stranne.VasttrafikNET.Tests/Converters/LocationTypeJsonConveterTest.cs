using Newtonsoft.Json;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner.Enums;
using Stranne.VasttrafikNET.Converters;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.Converters
{
    [Trait("Area", "Converter")]
    public class LocationTypeJsonConveterTest
    {
        [Fact]
        public void WriteJson()
        {
            Assert.False(new LocationTypeJsonConverter().CanWrite);
        }

        [Theory]
        [InlineData(@"""ADR""", LocationType.Address)]
        [InlineData(@"""ST""", LocationType.StopOrStation)]
        [InlineData(@"""POI""", LocationType.PointOfInterest)]
        public void ReadJson(string value, LocationType expected)
        {
            var actual = JsonConvert.DeserializeObject<LocationType>(value, new LocationTypeJsonConverter());

            Assert.Equal(expected, actual);
        }
    }
}
