using Newtonsoft.Json;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner.Enums;
using Stranne.VasttrafikNET.Tests.Json;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.JsonParsing
{
    public class LiveMapJsonTest : BaseJsonTest
    {
        protected override string Json => LiveMapJson.Json;

        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "LiveMap.MinX", 11913214d },
            { "LiveMap.MaxX", 12044663d },
            { "LiveMap.MinY", 57721867d },
            { "LiveMap.MaxY", 57685421d },

            { "LiveMap.Vehicles", 2 },
            { "LiveMap.Vehicles[0].LineColor", "#000000" },
            { "LiveMap.Vehicles[0].ProdClass", JourneyType.Vasttagen },
            { "LiveMap.Vehicles[0].BackgroundColor", "#ffffff" },
            { "LiveMap.Vehicles[0].Direction", 0 },
            { "LiveMap.Vehicles[0].Name", "" },
            { "LiveMap.Vehicles[0].Gid", "" },
            { "LiveMap.Vehicles[0].Delay", 0 },
            { "LiveMap.Vehicles[0].Y", 0d },
            { "LiveMap.Vehicles[0].X", 0d },

            { "LiveMap.Vehicles[1].LineColor", "#000000" },
            { "LiveMap.Vehicles[1].ProdClass", JourneyType.Bus },
            { "LiveMap.Vehicles[1].BackgroundColor", "#ffffff" },
            { "LiveMap.Vehicles[1].Direction", 1 },
            { "LiveMap.Vehicles[1].Name", "" },
            { "LiveMap.Vehicles[1].Gid", "" },
            { "LiveMap.Vehicles[1].Delay", 3 },
            { "LiveMap.Vehicles[1].Y", 0d },
            { "LiveMap.Vehicles[1].X", 0d }
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void LiveMapJsonParsing(string property, object expected)
        {
            TestValue<LiveMapRoot>(property, expected);
        }

        [Fact]
        public void LiveMapOnDeserialized()
        {
            JsonConvert.DeserializeObject<LiveMap>("{}");
        }
    }
}
