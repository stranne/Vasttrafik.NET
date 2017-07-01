using Stranne.VasttrafikNET.Tests.Json;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.JsonParsing
{
    public class AvailableCapacityJsonTest : BaseJsonTest
    {
        protected override JsonFile JsonFile => JsonFile.AvailableCapacity;

        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "", 50 }
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void AvailableCapacityJsonParsing(string property, object expected)
        {
            TestValue<int>(property, expected);
        }
    }
}
