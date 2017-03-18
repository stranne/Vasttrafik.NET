using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Converters;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.Converters
{
    [Trait("Area", "Converter")]
    public class BoolInvertJsonConverterTest
    {
        [Fact]
        public void CanWriteJson()
        {
            Assert.False(new BoolInvertJsonConverter().CanWrite);
        }

        [Fact]
        public void WriteJson()
        {
            Assert.Throws<NotImplementedException>(() => new BoolInvertJsonConverter().WriteJson(null, null, null));
        }

        [Theory]
        [InlineData("true", false)]
        [InlineData("false", true)]
        public void ReadJson(string value, bool expected)
        {
            var actual = JsonConvert.DeserializeObject<bool>(value, new BoolInvertJsonConverter());

            Assert.Equal(expected, actual);
        }
    }
}
