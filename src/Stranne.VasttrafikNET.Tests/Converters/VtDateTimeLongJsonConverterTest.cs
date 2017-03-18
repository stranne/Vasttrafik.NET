using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Converters;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.Converters
{
    [Trait("Area", "Converter")]
    public class VtDateTimeLongJsonConverterTest
    {
        [Fact]
        public void WriteJson()
        {
            var value = new DateTime(2016, 8, 1, 9, 30, 15);

            var actual = JsonConvert.SerializeObject(value, new VtDateTimeLongJsonConverter());

            Assert.Equal("20160801093015", actual);
        }

        [Fact]
        public void CanReadJson()
        {
            Assert.False(new VtDateTimeLongJsonConverter().CanRead);
        }

        [Fact]
        public void ReadJson()
        {
            Assert.Throws<NotImplementedException>(() => new VtDateTimeLongJsonConverter().ReadJson(null, null, null, null));
        }
    }
}
