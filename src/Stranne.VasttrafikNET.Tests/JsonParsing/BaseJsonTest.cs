using System.Collections;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Stranne.VasttrafikNET.Service;
using Xunit;
using System.Reflection;
using System.Linq;
using Stranne.VasttrafikNET.Tests.Helpers;
using Stranne.VasttrafikNET.Tests.Jsons;

namespace Stranne.VasttrafikNET.Tests.JsonParsing
{
    public abstract class BaseJsonTest
    {
        protected BaseJsonTest(JsonFile jsonFile)
        {
            JsonFile = jsonFile;
        }

        private JsonFile JsonFile { get; }
        private static JsonSerializerSettings JsonSerializerSettings => new JourneyPlannerHandlingService("Key", "Secret", "DeviceId").JsonSerializerSettings;

        protected void TestValue<T>(string property, object expected)
        {
            var json = FileHelper.GetJson(JsonFile);
            var sut = JsonConvert.DeserializeObject<T>(json, JsonSerializerSettings);

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
            var steps = Regex.Split(property, @"\[|\]\.?|\.")
                .Where(step => !string.IsNullOrWhiteSpace(step));
            var currentProperty = sut;
            foreach (var step in steps)
            {
                if (int.TryParse(step, out int arrayIndex))
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
