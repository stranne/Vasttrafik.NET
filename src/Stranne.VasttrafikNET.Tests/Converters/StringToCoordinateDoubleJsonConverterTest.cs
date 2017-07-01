using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Converters;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.Converters
{
    [Trait("Area", "Converter")]
    public class StringToCoordinateDoubleJsonConverterTest
    {
        [Fact]
        public void CanWriteJson()
        {
            Assert.False(new StringToCoordinateDoubleJsonConverter().CanWrite);
        }

        [Theory]
        [InlineData("0", 0d)]
        [InlineData("11230000", 11.23d)]
        public void ReadJson(string value, double expected)
        {
            var actual = JsonConvert.DeserializeObject<double>(value, new StringToCoordinateDoubleJsonConverter());

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WriteJson()
        {
            Assert.Throws<NotImplementedException>(() => new StringToCoordinateDoubleJsonConverter().WriteJson(null, null, null));
        }
    }
}
