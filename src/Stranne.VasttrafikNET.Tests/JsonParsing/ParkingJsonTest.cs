using System.Collections.Generic;
using Stranne.VasttrafikNET.ApiModels.CommuterParking;
using Stranne.VasttrafikNET.Tests.Json;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.JsonParsing
{
    public class ParkingJsonTest : BaseJsonTest
    {
        protected override string Json => ParkingJson.Json;

        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "", 1 },
            { "[0].Id", 209L },
            { "[0].Name", "Radiomotet" },
            { "[0].StopAreas", 1 },
            { "[0].StopAreas[0].Gid", 9021014005421000 },
            { "[0].StopAreas[0].Name", "Radiomotet" },
            { "[0].StopAreas[0].Municipality", "Göteborg" },
            { "[0].ParkingLots", 1 },
            { "[0].ParkingLots[0].Id", 6090 },
            { "[0].ParkingLots[0].Name", "Radiomotet-P1" },
            { "[0].ParkingLots[0].Latitude", 57.6486003 },
            { "[0].ParkingLots[0].Longitude", 11.9335886 },
            { "[0].ParkingLots[0].TotalCapacity", 134 },
            { "[0].ParkingLots[0].FreeSpaces", 129 },
            { "[0].ParkingLots[0].IsRestrictedByBarrier", false },
            { "[0].ParkingLots[0].ParkingTypes", 1 },
            { "[0].ParkingLots[0].ParkingTypes[0].Name", "SMARTCARPARK" },
            { "[0].ParkingLots[0].ParkingTypes[0].Number", 2 },
            { "[0].ParkingLots[0].ParkingCameras", 2 },
            { "[0].ParkingLots[0].ParkingCameras[0].Id", 1 },
            { "[0].ParkingLots[0].ParkingCameras[1].Id", 2 }
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void ParkingJsonParsing(string property, object expected)
        {
            TestValue<IEnumerable<ParkingArea>>(property, expected);
        }
    }
}
