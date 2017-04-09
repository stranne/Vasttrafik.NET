using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Converters;
using Stranne.VasttrafikNET.Models.Enums;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.Converters
{
    [Trait("Area", "Converter")]
    public class BikeProfileJsonConverterTest
    {
        [Theory]
        [InlineData(BikeProfile.Easy, "E")]
        [InlineData(BikeProfile.Normal, "N")]
        [InlineData(BikeProfile.Powerful, "P")]
        [InlineData((BikeProfile)int.MaxValue, "")]
        public void WriteJson(BikeProfile value, string expected)
        {
            var actual = JsonConvert.SerializeObject(value, new BikeProfileJsonConverter());

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanReadJson()
        {
            Assert.False(new BikeProfileJsonConverter().CanRead);
        }

        [Fact]
        public void ReadJson()
        {
            Assert.Throws<NotImplementedException>(() => new BikeProfileJsonConverter().ReadJson(null, null, null, null));
        }
    }
}
