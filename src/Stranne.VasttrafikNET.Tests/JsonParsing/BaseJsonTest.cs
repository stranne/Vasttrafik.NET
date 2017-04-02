using System.Collections;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Service;
using Xunit;
using System.Reflection;
using System.Linq;

namespace Stranne.VasttrafikNET.Tests.JsonParsing
{
    public abstract class BaseJsonTest
    {
        protected abstract string Json { get; }
        private static JsonSerializerSettings JsonSerializerSettings => new JourneyPlannerHandlingService("Key", "Secret", "DeviceId").JsonSerializerSettings;

        protected void TestValue<T>(string property, object expected)
        {
            var sut = JsonConvert.DeserializeObject<T>(Json, JsonSerializerSettings);

            var actual = GetValue(sut, property);

            if (actual is IList && expected is int)
            {
                var count = actual.GetType().GetProperty("Count").GetValue(actual);
                Assert.Equal(expected, count);
                return;
            }

            Assert.Equal(expected, actual);
        }

        private static object GetValue(object sut, string property)
        {
            var steps = Regex.Split(property, @"\[|\]\.|\.")
                .Where(step => !string.IsNullOrWhiteSpace(step));
            var currentProperty = sut;
            foreach (var step in steps)
            {
                int arrayIndex;
                if (int.TryParse(step, out arrayIndex))
                {
                    currentProperty = currentProperty.GetType().GetProperty("Item").GetValue(currentProperty, new object[] { arrayIndex });
                    continue;
                }

                currentProperty = currentProperty.GetType().GetProperty(step, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(currentProperty);
            }

            return currentProperty;
        }
    }
}
