using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.ApiModels.TrafficSituations.Enum;
using Stranne.VasttrafikNET.Converters;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.Converters
{
    [Trait("Area", "Converter")]
    public class TrafficSituationsSeverityJsonConverterTest
    {
        [Fact]
        public void CanWriteJson()
        {
            Assert.False(new BoolInvertJsonConverter().CanWrite);
        }

        [Fact]
        public void WriteJson()
        {
            Assert.Throws<NotImplementedException>(() => new TrafficSituationsSeverityJsonConverter().WriteJson(null, null, null));
        }

        [Theory]
        [InlineData(@"""slight""", TrafficSituationSeverity.Slight)]
        [InlineData(@"""normal""", TrafficSituationSeverity.Normal)]
        [InlineData(@"""severe""", TrafficSituationSeverity.Severe)]
        public void ReadJson(string value, TrafficSituationSeverity expected)
        {
            var actual = JsonConvert.DeserializeObject<TrafficSituationSeverity>(value, new TrafficSituationsSeverityJsonConverter());

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReadUnsupportedJson()
        {
            var actual = Assert.Throws<ArgumentException>(() => JsonConvert.DeserializeObject<TrafficSituationSeverity>("404", new TrafficSituationsSeverityJsonConverter()));

            Assert.Equal("TrafficSituationSeverity value 404 isn't recognized.", actual.Message);
        }
    }
}
