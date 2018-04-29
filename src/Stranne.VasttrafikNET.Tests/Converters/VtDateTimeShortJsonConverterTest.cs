using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Converters;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.Converters
{
    [Trait("Area", "Converter")]
    public class VtDateTimeShortJsonConverterTest
    {
        public static TheoryData TestParameters => new TheoryData<DateTimeOffset, object>
        {
            { new DateTimeOffset(2016, 8, 1, 9, 30, 15, new TimeSpan(2, 0, 0)), "20160801" },
            { new DateTimeOffset(2016, 8, 1, 9, 30, 15, new TimeSpan(-5, 0, 0)), "20160801" }
        };

        [Theory]
        [MemberData(nameof(TestParameters))]
        public void WriteJson(DateTimeOffset dateTimeOffset, string expected)
        {
            var actual = JsonConvert.SerializeObject(dateTimeOffset, new VtDateTimeShortJsonConverter());

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanReadJson()
        {
            Assert.False(new VtDateTimeShortJsonConverter().CanRead);
        }

        [Fact]
        public void ReadJson()
        {
            Assert.Throws<NotImplementedException>(() => new VtDateTimeShortJsonConverter().ReadJson(null, null, null, null));
        }
    }
}
