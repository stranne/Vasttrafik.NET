using System;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner;
using Stranne.VasttrafikNET.Tests.Json;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.JsonParsing
{
    public class SystemInfoJsonTest : BaseJsonTest
    {
        protected override string Json => SystemInfoJson.Json;

        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "SystemInfo.TimetableInfo.TimetablePeriod.DateBegin", new DateTimeOffset(2016, 6, 1, 0, 0, 0, new TimeSpan(2, 0, 0)) },
            { "SystemInfo.TimetableInfo.TimetablePeriod.DateEnd", new DateTimeOffset(2016, 10, 29, 0, 0, 0, new TimeSpan(2, 0, 0)) },
            { "SystemInfo.TimetableInfo.TimeTableData.CreationDate", new DateTimeOffset(2016, 7, 31, 0, 0, 0, new TimeSpan(2, 0, 0)) }
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void SystemInfoJsonParsing(string property, object expected)
        {
            TestValue<SystemInfoRoot>(property, expected);
        }
    }
}
