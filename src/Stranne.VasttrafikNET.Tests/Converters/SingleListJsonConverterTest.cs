using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner;
using Stranne.VasttrafikNET.Converters;
using System.Linq;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.Converters
{
    [Trait("Area", "Converter")]
    public class SingleListJsonConverterTest
    {
        [Fact]
        public void CanWriteJson()
        {
            Assert.False(new SingleListJsonConverter().CanWrite);
        }

        [Fact]
        public void WriteJson()
        {
            Assert.Throws<NotImplementedException>(() => new SingleListJsonConverter().WriteJson(null, null, null));
        }

        [Theory]
        [InlineData(@"{
    ""coordLocation"": {
        ""name"": ""Name1""
    }
}", 1, "Name1")]
        [InlineData(@"{
    ""coordLocation"": [
        {
            ""name"": ""Name2""
        }
    ]
}", 1, "Name2")]
        [InlineData(@"{
    ""coordLocation"": [
        {
            ""name"": ""Name3""
        },
        {
            ""name"": ""Name4""
        },
        {
            ""name"": ""Name5""
        }
    ]
}", 3, "Name3")]
        public void ReadJson(string json, int expectedLocations, string expectedName)
        {
            var actual = JsonConvert.DeserializeObject<LocationList>(json, new SingleListJsonConverter());

            Assert.NotNull(actual);
            Assert.NotNull(actual.CoordLocation);
            Assert.Equal(expectedLocations, actual.CoordLocation.Count());
            Assert.Equal(expectedName, actual.CoordLocation.First().Name);
        }
    }
}
