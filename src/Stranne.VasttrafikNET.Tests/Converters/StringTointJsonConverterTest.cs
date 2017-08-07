using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Converters;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.Converters
{
    [Trait("Area", "Converter")]
    public class StringToIntJsonConverterTest
    {
        [Fact]
        public void CanWriteJson()
        {
            Assert.False(new StringToIntJsonConverter().CanWrite);
        }

        [Theory]
        [InlineData("0", 0)]
        [InlineData("2147483647", int.MaxValue)]
        [InlineData("-2147483648", int.MinValue)]
        public void ReadJson(string value, int expected)
        {
            var actual = JsonConvert.DeserializeObject<int>(value, new StringToIntJsonConverter());

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("ABC")]
        [InlineData("12,3")]
        public void IllegalReadValue(string value)
        {
            Assert.Throws<JsonReaderException>(() => JsonConvert.DeserializeObject<int>(value, new StringToIntJsonConverter()));
        }

        [Theory]
        [InlineData("2147483648")]
        [InlineData("-2147483649")]
        public void IllegalReadNumber(string value)
        {
            Assert.Throws<OverflowException>(() => JsonConvert.DeserializeObject<int>(value, new StringToIntJsonConverter()));
        }

        [Fact]
        public void WriteJson()
        {
            Assert.Throws<NotImplementedException>(() => new StringToIntJsonConverter().WriteJson(null, null, null));
        }
    }
}
