using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Converters;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.Converters
{
    [Trait("Area", "Converter")]
    public class YesNoJsonConverterTest
    {
        [Theory]
        [InlineData(false, "no")]
        [InlineData(true, "yes")]
        public void WriteJson(bool value, string expected)
        {
            var actual = JsonConvert.SerializeObject(value, new YesNoJsonConverter());

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanReadJson()
        {
            Assert.False(new YesNoJsonConverter().CanRead);
        }

        [Fact]
        public void ReadJson()
        {
            Assert.Throws<NotImplementedException>(() => new YesNoJsonConverter().ReadJson(null, null, null, null));
        }
    }
}
