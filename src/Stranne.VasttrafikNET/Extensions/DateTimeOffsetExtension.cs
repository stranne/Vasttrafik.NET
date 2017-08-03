using System;
using System.Runtime.InteropServices;

namespace Stranne.VasttrafikNET.Extensions
{
    internal static class DateTimeOffsetExtension
    {
        public static TimeSpan GetVasttrafikTimeOffset(this DateTimeOffset dateTimeOffset)
        {
            return TimeZoneInfo.FindSystemTimeZoneById(GetTimeZoneName()).GetUtcOffset(dateTimeOffset);
        }

        public static DateTimeOffset AddVasttrafikTimeSpan(this DateTimeOffset dateTimeOffset)
        {
            var timeOffset = dateTimeOffset.GetVasttrafikTimeOffset();
            return new DateTimeOffset(dateTimeOffset.DateTime, timeOffset);
        }

        public static DateTimeOffset ConvertToVasttrafikTimeZone(this DateTimeOffset dateTimeOffset)
        {
            return TimeZoneInfo.ConvertTime(dateTimeOffset, TimeZoneInfo.FindSystemTimeZoneById(GetTimeZoneName()));
        }

        private static string GetTimeZoneName() {
            var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            return isWindows
                ? "W. Europe Standard Time"
                : "Europe/Stockholm";
        }
    }
}
