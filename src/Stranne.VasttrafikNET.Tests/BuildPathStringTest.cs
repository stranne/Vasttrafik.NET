using System;
using Stranne.VasttrafikNET.Models;
using Stranne.VasttrafikNET.Service;
using Xunit;

namespace Stranne.VasttrafikNET.Tests
{
    public class BuildPathStringTest
    {
        [Fact]
        public void SinglePath()
        {
            var options = new CommuterParkingOptions
            {
                Id = 1
            };

            var actual = BaseHandlingService.BuildParameterString(options);

            Assert.Equal("/1?format=json", actual);
        }

        [Fact]
        public void MultiplePath()
        {
            var options = new CommuterParkingOptions
            {
                Id = 1,
                To = new DateTimeOffset(2016, 8, 1, 9, 0, 0, new TimeSpan(2, 0, 0)),
                From = new DateTimeOffset(2016, 8, 1, 8, 0, 0, new TimeSpan(2, 0, 0))
            };

            var actual = BaseHandlingService.BuildParameterString(options);

            Assert.Equal("/1/20160801080000/20160801090000?format=json", actual);
        }
    }
}
