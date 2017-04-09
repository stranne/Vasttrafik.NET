using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Converters;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.Converters
{
    [Trait("Area", "Converter")]
    public class VtDateTimeJsonConverterTest
    {
        [Fact]
        public void CanWriteJson()
        {
            Assert.False(new VtDateTimeJsonConverter().CanWrite);
        }

        [Fact]
        public void WriteJson()
        {
            Assert.Throws<NotImplementedException>(() => new VtDateTimeJsonConverter().WriteJson(null, null, null));
        }

        [Fact]
        public void ReadJson()
        {
            const string value = @"{
              ""$"": ""2016-06-01""
            }";

            var actual = JsonConvert.DeserializeObject<DateTimeOffset>(value, new VtDateTimeJsonConverter());

            Assert.Equal(new DateTimeOffset(2016, 6, 1, 0, 0, 0, new TimeSpan(2, 0, 0)), actual);
        }
    }
}
