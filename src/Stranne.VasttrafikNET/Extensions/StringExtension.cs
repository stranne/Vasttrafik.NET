using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Stranne.VasttrafikNET.Extensions
{
    internal static class StringExtension
    {
        private static readonly Regex DateTimeStringRegex = new Regex(@"^[0-9]{4}-[0-1][0-9]-[0-3][0-9] [0-23][0-9]\:[0-6][0-9]$");

        public static string ToCamelCase(this string value)
        {
            value = Regex.Replace(value, @"^\p{L}", s => s.ToString().ToLower());
            value = Regex.Replace(value, @"\s\p{L}", s => s.ToString().ToUpper());
            return Regex.Replace(value, @"\s", s => "");
        }

        public static string ToBase64(this string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }

        public static DateTimeOffset ToDateTimeOffset(this string value)
        {
            var dateTimeOffset = DateTimeOffset.ParseExact(value, "yyyy-MM-dd HH:mm", new CultureInfo("en-US"));
            return dateTimeOffset.AddVasttrafikTimeSpan();
        }

        public static DateTimeOffset? ToDateTimeOffsetNullable(this string value)
        {
            if (value == null || !DateTimeStringRegex.Match(value).Success)
                return null;

            return value.ToDateTimeOffset();
        }

        public static string ThrowIfNullOrWhiteSpace(this string value, string propertyName)
        {
            if (value == null)
                throw new ArgumentNullException(propertyName);

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("String can't be empty", propertyName);

            return value;
        }
    }
}
