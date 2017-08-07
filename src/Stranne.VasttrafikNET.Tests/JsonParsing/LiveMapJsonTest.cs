using Newtonsoft.Json;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner.Enums;
using Stranne.VasttrafikNET.Tests.Json;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.JsonParsing
{
    public class LiveMapJsonTest : BaseJsonTest
    {
        protected override JsonFile JsonFile => JsonFile.LiveMap;

        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "LiveMap.LongitudeMin", 11863889d },
            { "LiveMap.LongitudeMax", 12037610d },
            { "LiveMap.LatitudeMin", 57653098d },
            { "LiveMap.LatitudeMax", 57745560d },

            { "LiveMap.Vehicles", 9 },
            { "LiveMap.Vehicles[0].LineColor", "#00A5DC" },
            { "LiveMap.Vehicles[0].ProdClass", JourneyType.Bus },
            { "LiveMap.Vehicles[0].BackgroundColor", "#ffffff" },
            { "LiveMap.Vehicles[0].Direction", 281.25d },
            { "LiveMap.Vehicles[0].Name", "Bus 84" },
            { "LiveMap.Vehicles[0].Gid", "9015014508400654" },
            { "LiveMap.Vehicles[0].Delay", 1 },
            { "LiveMap.Vehicles[0].Latitude", 57.669738d },
            { "LiveMap.Vehicles[0].Longitude", 11.937055d },

            { "LiveMap.Vehicles[1].LineColor", "#00A5DC" },
            { "LiveMap.Vehicles[1].ProdClass", JourneyType.Bus },
            { "LiveMap.Vehicles[1].BackgroundColor", "#ffffff" },
            { "LiveMap.Vehicles[1].Direction", 78.75d },
            { "LiveMap.Vehicles[1].Name", "Bus 99" },
            { "LiveMap.Vehicles[1].Gid", "9015014509900693" },
            { "LiveMap.Vehicles[1].Delay", 1 },
            { "LiveMap.Vehicles[1].Latitude", 57.672912d },
            { "LiveMap.Vehicles[1].Longitude", 11.894203d },

            { "LiveMap.Vehicles[2].LineColor", "#00b6f1" },
            { "LiveMap.Vehicles[2].ProdClass", JourneyType.Bus },
            { "LiveMap.Vehicles[2].BackgroundColor", "#ffffff" },
            { "LiveMap.Vehicles[2].Direction", 236.25d },
            { "LiveMap.Vehicles[2].Name", "Bus 60" },
            { "LiveMap.Vehicles[2].Gid", "9015014506000947" },
            { "LiveMap.Vehicles[2].Delay", 1 },
            { "LiveMap.Vehicles[2].Latitude", 57.708383d },
            { "LiveMap.Vehicles[2].Longitude", 12.012222d },

            { "LiveMap.Vehicles[3].LineColor", "#00b6f1" },
            { "LiveMap.Vehicles[3].ProdClass", JourneyType.Bus },
            { "LiveMap.Vehicles[3].BackgroundColor", "#ffffff" },
            { "LiveMap.Vehicles[3].Direction", 213.75d },
            { "LiveMap.Vehicles[3].Name", "Bus 60" },
            { "LiveMap.Vehicles[3].Gid", "9015014506000945" },
            { "LiveMap.Vehicles[3].Delay", 1 },
            { "LiveMap.Vehicles[3].Latitude", 57.697416d },
            { "LiveMap.Vehicles[3].Longitude", 11.950511d },

            { "LiveMap.Vehicles[4].LineColor", "#00A5DC" },
            { "LiveMap.Vehicles[4].ProdClass", JourneyType.Bus },
            { "LiveMap.Vehicles[4].BackgroundColor", "#ffffff" },
            { "LiveMap.Vehicles[4].Direction", 135d },
            { "LiveMap.Vehicles[4].Name", "Bus 300" },
            { "LiveMap.Vehicles[4].Gid", "9015014230000713" },
            { "LiveMap.Vehicles[4].Delay", 8 },
            { "LiveMap.Vehicles[4].Latitude", 57.686422d },
            { "LiveMap.Vehicles[4].Longitude", 12.010577d },

            { "LiveMap.Vehicles[5].LineColor", "#00A5DC" },
            { "LiveMap.Vehicles[5].ProdClass", JourneyType.Bus },
            { "LiveMap.Vehicles[5].BackgroundColor", "#ffffff" },
            { "LiveMap.Vehicles[5].Direction", 270d },
            { "LiveMap.Vehicles[5].Name", "Bus 753" },
            { "LiveMap.Vehicles[5].Gid", "9015014575300662" },
            { "LiveMap.Vehicles[5].Delay", 1 },
            { "LiveMap.Vehicles[5].Latitude", 57.681496d },
            { "LiveMap.Vehicles[5].Longitude", 11.965101d },

            { "LiveMap.Vehicles[6].LineColor", "#00A5DC" },
            { "LiveMap.Vehicles[6].ProdClass", JourneyType.Bus },
            { "LiveMap.Vehicles[6].BackgroundColor", "#ffffff" },
            { "LiveMap.Vehicles[6].Direction", 337.5d },
            { "LiveMap.Vehicles[6].Name", "Bus 753" },
            { "LiveMap.Vehicles[6].Gid", "9015014575300660" },
            { "LiveMap.Vehicles[6].Delay", 1 },
            { "LiveMap.Vehicles[6].Latitude", 57.661226d },
            { "LiveMap.Vehicles[6].Longitude", 12.027953d },

            { "LiveMap.Vehicles[7].LineColor", "#00A5DC" },
            { "LiveMap.Vehicles[7].ProdClass", JourneyType.Bus },
            { "LiveMap.Vehicles[7].BackgroundColor", "#ffffff" },
            { "LiveMap.Vehicles[7].Direction", 326.25d },
            { "LiveMap.Vehicles[7].Name", "Bus 753" },
            { "LiveMap.Vehicles[7].Gid", "9015014575300663" },
            { "LiveMap.Vehicles[7].Delay", 0 },
            { "LiveMap.Vehicles[7].Latitude", 57.697623d },
            { "LiveMap.Vehicles[7].Longitude", 11.983682d },

            { "LiveMap.Vehicles[8].LineColor", "#00A5DC" },
            { "LiveMap.Vehicles[8].ProdClass", JourneyType.Bus },
            { "LiveMap.Vehicles[8].BackgroundColor", "#ffffff" },
            { "LiveMap.Vehicles[8].Direction", 22.5d },
            { "LiveMap.Vehicles[8].Name", "Bus 58" },
            { "LiveMap.Vehicles[8].Gid", "9015014535800680" },
            { "LiveMap.Vehicles[8].Delay", 0 },
            { "LiveMap.Vehicles[8].Latitude", 57.710567d },
            { "LiveMap.Vehicles[8].Longitude", 11.984581d }
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
