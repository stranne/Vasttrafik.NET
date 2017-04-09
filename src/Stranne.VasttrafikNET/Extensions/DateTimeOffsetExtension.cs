using System;

namespace Stranne.VasttrafikNET.Extensions
{
    internal static class DateTimeOffsetExtension
    {
        private const string TimeZoneName = "W. Europe Standard Time";

        public static TimeSpan GetVasttrafikTimeOffset(this DateTimeOffset dateTimeOffset)
        {
            return TimeZoneInfo.FindSystemTimeZoneById(TimeZoneName).GetUtcOffset(dateTimeOffset);
        }

        public static DateTimeOffset AddVasttrafikTimeSpan(this DateTimeOffset dateTimeOffset)
        {
            var timeOffset = dateTimeOffset.GetVasttrafikTimeOffset();
            return new DateTimeOffset(dateTimeOffset.DateTime, timeOffset);
        }

        public static DateTimeOffset ConvertToVasttrafikTimeZone(this DateTimeOffset dateTimeOffset)
        {
            return TimeZoneInfo.ConvertTime(dateTimeOffset, TimeZoneInfo.FindSystemTimeZoneById(TimeZoneName));
        }
    }
}
