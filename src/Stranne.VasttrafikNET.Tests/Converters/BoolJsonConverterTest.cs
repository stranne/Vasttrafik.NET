using Newtonsoft.Json;
using Stranne.VasttrafikNET.Converters;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.Converters
{
    [Trait("Area", "Converter")]
    public class BoolJsonConverterTest
    {
        [Theory]
        [InlineData(false, "0")]
        [InlineData(true, "1")]
        public void WriteJson(bool value, string expected)
        {
            var actual = JsonConvert.SerializeObject(value, new BoolJsonConverter());

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("0", false)]
        [InlineData("1", true)]
        public void ReadJson(string value, bool expected)
        {
            var actual = JsonConvert.DeserializeObject<bool>(value, new BoolJsonConverter());

            Assert.Equal(expected, actual);
        }
    }
}
