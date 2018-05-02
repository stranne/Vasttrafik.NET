using System.IO;
using Stranne.VasttrafikNET.Tests.Jsons;

namespace Stranne.VasttrafikNET.Tests.Helpers
{
    public static class FileHelper
    {
        public static string GetJson(JsonFile jsonFile)
        {
            var fileName = $"{jsonFile}.json";
            var json = File.ReadAllText($@"Jsons/{fileName}");
            return json;
        }
    }
}
