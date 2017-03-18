using System;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner.Enums;
using Stranne.VasttrafikNET.Converters;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.Converters
{
    [Trait("Area", "Converter")]
    public class JourneyTypeJsonConverterTest
    {
        [Fact]
        public void CanWriteJson()
        {
            Assert.False(new JourneyTypeJsonConverter().CanWrite);
        }

        [Fact]
        public void WriteJson()
        {
            Assert.Throws<NotImplementedException>(() => new JourneyTypeJsonConverter().WriteJson(null, null, null));
        }

        [Theory]
        [InlineData(@"""Vas""", JourneyType.Vasttagen)]
        [InlineData(@"""Llt""", JourneyType.LongDistanceTrain)]
        [InlineData(@"""Reg""", JourneyType.RegionalTrain)]
        [InlineData(@"""Bus""", JourneyType.Bus)]
        [InlineData(@"""Boat""", JourneyType.Boat)]
        [InlineData(@"""Tram""", JourneyType.Tram)]
        [InlineData(@"""Taxi""", JourneyType.Taxi)]
        [InlineData(@"""Walk""", JourneyType.Walk)]
        [InlineData(@"""Bike""", JourneyType.Bike)]
        [InlineData(@"""Car""", JourneyType.Car)]
        public void ReadJson(string value, JourneyType expected)
        {
            var actual = JsonConvert.DeserializeObject<JourneyType>(value, new JourneyTypeJsonConverter());

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(@"""Unknown""")]
        public void ReadJsonUnknown(string value)
        {
            Assert.Throws<ArgumentException>(() => JsonConvert.DeserializeObject<JourneyType>(value, new JourneyTypeJsonConverter()));
        }
    }
}
