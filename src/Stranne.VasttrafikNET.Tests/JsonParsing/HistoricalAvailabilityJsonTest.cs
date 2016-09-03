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
            { "[0].DateTime", TimeZoneInfo.ConvertTime(new DateTime(2016, 8, 1, 8, 0, 0), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time")) },
            { "[0].FreeSpaces",79 },
            { "[1].DateTime", TimeZoneInfo.ConvertTime(new DateTime(2016, 8, 1, 8, 15, 0), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time")) },
            { "[1].FreeSpaces", 78 },
            { "[2].DateTime", TimeZoneInfo.ConvertTime(new DateTime(2016, 8, 1, 8, 30, 0), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time")) },
            { "[2].FreeSpaces", 71 },
            { "[3].DateTime", TimeZoneInfo.ConvertTime(new DateTime(2016, 8, 1, 8, 45, 0), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time")) },
            { "[3].FreeSpaces", 70 },
            { "[4].DateTime", TimeZoneInfo.ConvertTime(new DateTime(2016, 8, 1, 9, 0, 0), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time")) },
            { "[4].FreeSpaces", 67 }
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void HistoricalAvailabilityJsonParsing(string property, object expected)
        {
            TestValue<IEnumerable<HistoricalAvailability>>(property, expected);
        }
    }
}
