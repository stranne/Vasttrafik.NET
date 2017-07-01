using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Converters;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.Converters
{
    [Trait("Area", "Converter")]
    public class StringTointJsonConverterTest
    {
        [Fact]
        public void CanWriteJson()
        {
            Assert.False(new StringToIntJsonConverter().CanWrite);
        }

        [Theory]
        [InlineData("0", 0)]
        public void ReadJson(string value, int expected)
        {
            var actual = JsonConvert.DeserializeObject<int>(value, new StringToIntJsonConverter());

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WriteJson()
        {
            Assert.Throws<NotImplementedException>(() => new StringToIntJsonConverter().WriteJson(null, null, null));
        }
    }
}
