using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Converters;
using Stranne.VasttrafikNET.Models.Enums;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.Converters
{
    [Trait("Area", "Converter")]
    public class BikeCriterionJsonConverterTest
    {
        [Theory]
        [InlineData(BikeCriterion.DedicatedBikeRoads, "D")]
        [InlineData(BikeCriterion.FastRoute, "F")]
        [InlineData((BikeCriterion)int.MaxValue, "")]
        public void WriteJson(BikeCriterion value, string expected)
        {
            var actual = JsonConvert.SerializeObject(value, new BikeCriterionJsonConverter());

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void CanReadJson()
        {
            Assert.False(new BikeCriterionJsonConverter().CanRead);
        }

        [Fact]
        public void ReadJson()
        {
            Assert.Throws<NotImplementedException>(() => new BikeCriterionJsonConverter().ReadJson(null, null, null, null));
        }
    }
}
