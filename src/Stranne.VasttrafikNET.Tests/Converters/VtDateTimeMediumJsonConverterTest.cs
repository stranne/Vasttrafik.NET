using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Converters;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.Converters
{
    [Trait("Area", "Converter")]
    public class VtDateTimeMediumJsonConverterTest
    {
        public static TheoryData TestParameters => new TheoryData<DateTimeOffset, object>
        {
            {new DateTimeOffset(2016, 8, 1, 9, 30, 15, new TimeSpan(2, 0, 0)), "201608010930"},
            {new DateTimeOffset(2016, 8, 1, 9, 30, 15, new TimeSpan(-5, 0, 0)), "201608011630"}
        };

        [Theory]
        [MemberData(nameof(TestParameters))]
        public void WriteJson(DateTimeOffset dateTimeOffset, string expected)
        {
            var actual = JsonConvert.SerializeObject(dateTimeOffset, new VtDateTimeMediumJsonConverter());

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanReadJson()
        {
            Assert.False(new VtDateTimeMediumJsonConverter().CanRead);
        }

        [Fact]
        public void ReadJson()
        {
            Assert.Throws<NotImplementedException>(
                () => new VtDateTimeMediumJsonConverter().ReadJson(null, null, null, null));
        }
    }
}
