using System;
using Stranne.VasttrafikNET.Extensions;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.Extensions
{
    [Trait("Area", "Extension")]
    public class StringExtensionTest
    {
        [Theory]
        [InlineData("abc", "abc")]
        [InlineData("abcDef", "abcDef")]
        [InlineData("Abc", "abc")]
        [InlineData("AbcDef", "abcDef")]
        [InlineData("Abc def Ghi", "abcDefGhi")]
        [InlineData("123 456", "123456")]
        [InlineData("123abC", "123abC")]
        [InlineData("A12!", "a12!")]
        public void ToCamelCase(string value, string expected)
        {
            var actual = value.ToCamelCase();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("abc", "YWJj")]
        [InlineData("AbcDef", "QWJjRGVm")]
        [InlineData("123", "MTIz")]
        [InlineData("123abC", "MTIzYWJD")]
        [InlineData("A12!", "QTEyIQ==")]
        [InlineData("abcdefghijklmnopqrstuvwxyzåäöABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖ123456789!\"#¤%&/()=?+", "YWJjZGVmZ2hpamtsbW5vcHFyc3R1dnd4eXrDpcOkw7ZBQkNERUZHSElKS0xNTk9QUVJTVFVWV1hZWsOFw4TDljEyMzQ1Njc4OSEiI8KkJSYvKCk9Pys=")]
        public void ToBase64(string value, string expected)
        {
            var actual = value.ToBase64();
            Assert.Equal(expected, actual);
        }

        public static TheoryData DateTimeOffsetTheoryData => new TheoryData<string, DateTimeOffset>
        {
            {
                "2020-01-01 12:00", new DateTimeOffset(2020, 1, 1, 12, 0, 0, new TimeSpan(1, 0, 0))
            },
            {
                "2020-06-01 12:00", new DateTimeOffset(2020, 6, 1, 12, 0, 0, new TimeSpan(2, 0, 0))
            }
        };

        [Theory, MemberData(nameof(DateTimeOffsetTheoryData))]
        public void ToDateTimeOffset(string value, DateTimeOffset expected)
        {
            var actual = value.ToDateTimeOffset();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(DateTimeOffsetTheoryData))]
        [InlineData(null, null)]
        [InlineData("", null)]
        [InlineData("ABC", null)]
        public void ToDateTimeOffsetNullable(string value, DateTimeOffset? expected)
        {
            var actual = value.ToDateTimeOffsetNullable();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(null, "property1", typeof(ArgumentNullException))]
        [InlineData("", "property2", typeof(ArgumentException))]
        [InlineData("     ", "property3", typeof(ArgumentException))]
        public void ThrowIfNullOrWhiteSpace_Throws(string value, string propertyName, Type exceptionType)
        {
            var exception = (ArgumentException)Assert.Throws(exceptionType, () => value.ThrowIfNullOrWhiteSpace(propertyName));

            Assert.Equal(propertyName, exception.ParamName);
        }

        [Theory]
        [InlineData("Abc123", "property4")]
        public void ThrowIfNullOrWhiteSpace_NuExceptions(string value, string propertyName)
        {
            var actual = value.ThrowIfNullOrWhiteSpace(propertyName);
            Assert.Equal(actual, value);
        }
    }
}
