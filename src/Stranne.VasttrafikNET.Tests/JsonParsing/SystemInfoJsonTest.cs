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
            { "SystemInfo.TimetableInfo.TimetablePeriod.DateBegin", new DateTime(2016, 6, 1) },
            { "SystemInfo.TimetableInfo.TimetablePeriod.DateEnd", new DateTime(2016, 10, 29) },
            { "SystemInfo.TimetableInfo.TimeTableData.CreationDate", new DateTime(2016, 7, 31) }
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void SystemInfoJsonParsing(string property, object expected)
        {
            TestValue<SystemInfoRoot>(property, expected);
        }
    }
}
