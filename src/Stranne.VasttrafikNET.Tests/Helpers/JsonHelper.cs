using System.IO;
using Stranne.VasttrafikNET.Tests.Json;

namespace Stranne.VasttrafikNET.Tests.Helpers
{
    public static class JsonHelper
    {
        public static string GetJson(JsonFile jsonFile)
        {
            var fileName = $"{jsonFile}.json";
            var json = File.ReadAllText($@"Json\{fileName}");
            return json;
        }
    }
}
