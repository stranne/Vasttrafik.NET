using System;
using System.Runtime.InteropServices;
using Stranne.VasttrafikNET.Extensions;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.Extensions
{
    public class DateTimeOffsetTest
    {
        public static TheoryData GetVasttrafikTimeOffsetTheoryData => new TheoryData<DateTimeOffset, TimeSpan>
        {
            { new DateTimeOffset(2020, 1, 1, 12, 0, 0, new TimeSpan(0, 0, 0)), new TimeSpan(1, 0, 0) },
            { new DateTimeOffset(2020, 6, 1, 12, 0, 0, new TimeSpan(-5, 0, 0)), new TimeSpan(2, 0, 0) }
        };
        
        [Theory, MemberData(nameof(GetVasttrafikTimeOffsetTheoryData))]
        public void GetVasttrafikTimeOffset(DateTimeOffset dateTimeOffset, TimeSpan expected)
        {
            var actual = dateTimeOffset.GetVasttrafikTimeOffset();
            Assert.Equal(expected, actual);
        }
        
        public static TheoryData AddVasttrafikTimeSpanTheoryData => new TheoryData<DateTimeOffset, DateTimeOffset>
        {
            { new DateTimeOffset(2020, 1, 1, 12, 0, 0, new TimeSpan(0, 0, 0)), new DateTimeOffset(2020, 1, 1, 12, 0, 0, new TimeSpan(1, 0, 0)) },
            { new DateTimeOffset(2020, 6, 1, 12, 0, 0, new TimeSpan(0, 0, 0)), new DateTimeOffset(2020, 6, 1, 12, 0, 0, new TimeSpan(2, 0, 0)) }
        };
        
        [Theory, MemberData(nameof(AddVasttrafikTimeSpanTheoryData))]
        public void AddVasttrafikTimeSpan(DateTimeOffset dateTimeOffset, DateTimeOffset expected)
        {
            var actual = dateTimeOffset.AddVasttrafikTimeSpan();
            Assert.Equal(expected, actual);
        }
        
        public static TheoryData GetVasttrafikTimeZoneTheoryData => new TheoryData<DateTimeOffset, DateTimeOffset>
        {
            { new DateTimeOffset(2020, 1, 1, 12, 0, 0, new TimeSpan(-5, 0, 0)), new DateTimeOffset(2020, 1, 1, 18, 0, 0, new TimeSpan(1, 0, 0)) },
            { new DateTimeOffset(2020, 6, 1, 12, 0, 0, new TimeSpan(-5, 0, 0)), new DateTimeOffset(2020, 6, 1, 19, 0, 0, new TimeSpan(2, 0, 0)) }
        };

        [Theory, MemberData(nameof(GetVasttrafikTimeZoneTheoryData))]
        public void GetVasttrafikTimeZone(DateTimeOffset dateTimeOffset, DateTimeOffset expected)
        {
            var actual = dateTimeOffset.ConvertToVasttrafikTimeZone();
            Assert.Equal(expected, actual);
        }


        public static TheoryData GetTimeZoneNameTheoryData => new TheoryData<bool, string>
        {
            { true, "W. Europe Standard Time" },
            { false, "Europe/Stockholm" }
        };

        [Theory, MemberData(nameof(GetTimeZoneNameTheoryData))]
        public void GetTimeZoneName(bool isWindows, string expected)
        {
            var actual = DateTimeOffsetExtension.GetTimeZoneName(isWindows);

            Assert.Equal(expected, actual);
        }
    }
}
