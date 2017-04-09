using System;
using System.Collections.Generic;
using Stranne.VasttrafikNET.ApiModels.CommuterParking;
using Stranne.VasttrafikNET.Tests.Json;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.JsonParsing
{
    public class HistoricalAvailabilityJsonTest :  BaseJsonTest
    {
        protected override string Json => HistoricalAvailabilityJson.Json;

        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "", 5 },
            { "[0].DateTime", new DateTimeOffset(2016, 8, 1, 8, 0, 0, new TimeSpan(2, 0, 0)) },
            { "[0].FreeSpaces",79 },
            { "[1].DateTime", new DateTimeOffset(2016, 8, 1, 8, 15, 0, new TimeSpan(2, 0, 0)) },
            { "[1].FreeSpaces", 78 },
            { "[2].DateTime", new DateTimeOffset(2016, 8, 1, 8, 30, 0, new TimeSpan(2, 0, 0)) },
            { "[2].FreeSpaces", 71 },
            { "[3].DateTime", new DateTimeOffset(2016, 8, 1, 8, 45, 0, new TimeSpan(2, 0, 0)) },
            { "[3].FreeSpaces", 70 },
            { "[4].DateTime", new DateTimeOffset(2016, 8, 1, 9, 0, 0, new TimeSpan(2, 0, 0)) },
            { "[4].FreeSpaces", 67 }
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void HistoricalAvailabilityJsonParsing(string property, object expected)
        {
            TestValue<IEnumerable<HistoricalAvailability>>(property, expected);
        }
    }
}
