using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Converters;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.Converters
{
    [Trait("Area", "Converter")]
    public class VtDirectionJsonConverterTest
    {
        [Fact]
        public void CanWriteJson()
        {
            Assert.False(new VtDirectionJsonConverter().CanWrite);
        }

        [Theory]
        [InlineData("0", 0d)]
        [InlineData("1", 11.25d)]
        [InlineData("16", 180d)]
        [InlineData("31", 348.75d)]
        public void ReadJson(string value, double expected)
        {
            var actual = JsonConvert.DeserializeObject<double>(value, new VtDirectionJsonConverter());

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WriteJson()
        {
            Assert.Throws<NotImplementedException>(() => new VtDirectionJsonConverter().WriteJson(null, null, null));
        }
    }
}
