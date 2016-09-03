using System.Collections.Generic;
using Stranne.VasttrafikNET.ApiModels.CommuterParking;
using Stranne.VasttrafikNET.Tests.Json;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.JsonParsing
{
    public class ParkingsJsonTest : BaseJsonTest
    {
        protected override string Json => ParkingsJson.Json;

        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "", 2 },
            { "[0].Id", 203L },
            { "[0].Name", "Albotorget" },
            { "[0].StopAreas", 1 },
            { "[0].StopAreas[0].Gid", 9021014016710000 },
            { "[0].StopAreas[0].Name", "Albotorget" },
            { "[0].StopAreas[0].Municipality", "Ale" },
            { "[0].ParkingLots", 1 },
            { "[0].ParkingLots[0].Id", 6030 },
            { "[0].ParkingLots[0].Name", "Albotorget-P1" },
            { "[0].ParkingLots[0].Latitude", 57.9838704 },
            { "[0].ParkingLots[0].Longitude", 12.2107835 },
            { "[0].ParkingLots[0].TotalCapacity", 50 },
            { "[0].ParkingLots[0].FreeSpaces", null },
            { "[0].ParkingLots[0].IsRestrictedByBarrier", false },
            { "[0].ParkingLots[0].ParkingTypes", 1 },
            { "[0].ParkingLots[0].ParkingTypes[0].Name", "CARPARK" },
            { "[0].ParkingLots[0].ParkingTypes[0].Number", 1 },
            { "[0].ParkingLots[0].ParkingCameras", null },
            
            { "[1].Id", 143L },
            { "[1].Name", "Alingsås station" },
            { "[1].StopAreas", 1 },
            { "[1].StopAreas[0].Gid", 9021014017510000 },
            { "[1].StopAreas[0].Name", "Alingsås station" },
            { "[1].StopAreas[0].Municipality", "Alingsås" },
            { "[1].ParkingLots", 1 },
            { "[1].ParkingLots[0].Id", 5430 },
            { "[1].ParkingLots[0].Name", "Alingsås station-P1" },
            { "[1].ParkingLots[0].Latitude", 57.9273777 },
            { "[1].ParkingLots[0].Longitude", 12.528758 },
            { "[1].ParkingLots[0].TotalCapacity", 365 },
            { "[1].ParkingLots[0].FreeSpaces", null },
            { "[1].ParkingLots[0].IsRestrictedByBarrier", false },
            { "[1].ParkingLots[0].ParkingTypes", 1 },
            { "[1].ParkingLots[0].ParkingTypes[0].Name", "CARPARK" },
            { "[1].ParkingLots[0].ParkingTypes[0].Number", 1 },
            { "[1].ParkingLots[0].ParkingCameras", null }
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void ParkingsJsonParsing(string property, object expected)
        {
            TestValue<IEnumerable<ParkingArea>>(property, expected);
        }
    }
}
