using Stranne.VasttrafikNET.ApiModels.CommuterParking;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner.Enums;
using Stranne.VasttrafikNET.Tests.Jsons;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.JsonParsing
{
    public class ParkingJsonTest : BaseJsonTest
    {
        public ParkingJsonTest()
            : base(JsonFile.Parking)
        { }

        public static TheoryData TestParameters => new TheoryData<string, object>
        {
            { "Id", 209L },
            { "Name", "Radiomotet" },
            { "StopAreas", 2 },
            { "StopAreas[0].Gid", 9021014002525000 },
            { "StopAreas[0].Name", "Frölunda Smedja" },
            { "StopAreas[0].Municipality", "Göteborg" },
            { "StopAreas[1].Gid", 9021014005421000 },
            { "StopAreas[1].Name", "Radiomotet" },
            { "StopAreas[1].Municipality", "Göteborg" },

            { "ParkingLots", 3 },
            { "ParkingLots[0].Id", 6090 },
            { "ParkingLots[0].Name", "Radiomotet-P1" },
            { "ParkingLots[0].Latitude", 57.6485713 },
            { "ParkingLots[0].Longitude", 11.933876099999999 },
            { "ParkingLots[0].TotalCapacity", 134 },
            { "ParkingLots[0].FreeSpaces", 131 },
            { "ParkingLots[0].IsRestrictedByBarrier", false },
            { "ParkingLots[0].ParkingTypes", 1 },
            { "ParkingLots[0].ParkingTypes[0].Name", "SMARTCARPARK" },
            { "ParkingLots[0].ParkingTypes[0].Number", 2 },
            { "ParkingLots[0].ParkingCameras", 2 },
            { "ParkingLots[0].ParkingCameras[0].Id", 1 },
            { "ParkingLots[0].ParkingCameras[1].Id", 2 },

            { "ParkingLots[1].Id", 10120 },
            { "ParkingLots[1].Name", "Radiomotet-P2" },
            { "ParkingLots[1].Latitude", 57.6475794 },
            { "ParkingLots[1].Longitude", 11.9330043 },
            { "ParkingLots[1].TotalCapacity", 12 },
            { "ParkingLots[1].IsRestrictedByBarrier", false },
            { "ParkingLots[1].ParkingTypes", 1 },
            { "ParkingLots[1].ParkingTypes[0].Name", "CARPARK" },
            { "ParkingLots[1].ParkingTypes[0].Number", 1 },
            { "ParkingLots[1].ParkingCameras", 0 },

            { "ParkingLots[2].Id", 10130 },
            { "ParkingLots[2].Name", "Radiomotet-P3" },
            { "ParkingLots[2].Latitude", 57.6465677 },
            { "ParkingLots[2].Longitude", 11.9353863 },
            { "ParkingLots[2].TotalCapacity", 40 },
            { "ParkingLots[2].IsRestrictedByBarrier", false },
            { "ParkingLots[2].ParkingTypes", 1 },
            { "ParkingLots[2].ParkingTypes[0].Name", "CARPARK" },
            { "ParkingLots[2].ParkingTypes[0].Number", 1 },
            { "ParkingLots[2].ParkingCameras", 0 },

            { "Departures", 6 },
            { "Departures[0].Name", "Blå express" },
            { "Departures[0].ShortName", "BLÅ" },
            { "Departures[0].Type", JourneyType.Bus },
            { "Departures[0].DepartureTime", "22:10" },
            { "Departures[0].DepartsInMinutes", 5 },
            { "Departures[0].ArrivalTime", "22:29" },
            { "Departures[0].StopArea.Gid", 9022014005421000 },
            { "Departures[0].StopArea.Name", "Radiomotet" },
            { "Departures[0].StopArea.Municipality", "Göteborg" },
            { "Departures[0].Destination.Id", "9022014001950010" },
            { "Departures[0].Destination.Name", "Centralstationen, Göteborg" },

            { "Departures[1].Name", "Rosa express" },
            { "Departures[1].ShortName", "ROSA" },
            { "Departures[1].Type", JourneyType.Bus },
            { "Departures[1].DepartureTime", "22:26" },
            { "Departures[1].DepartsInMinutes", 21 },
            { "Departures[1].ArrivalTime", "22:40" },
            { "Departures[1].StopArea.Gid", 9022014005421000 },
            { "Departures[1].StopArea.Name", "Radiomotet" },
            { "Departures[1].StopArea.Municipality", "Göteborg" },
            { "Departures[1].Destination.Id", "9022014004945004" },
            { "Departures[1].Destination.Name", "Nordstan, Göteborg" },

            { "Departures[2].Name", "Blå express" },
            { "Departures[2].ShortName", "BLÅ" },
            { "Departures[2].Type", JourneyType.Bus },
            { "Departures[2].DepartureTime", "22:39" },
            { "Departures[2].DepartsInMinutes", 34 },
            { "Departures[2].ArrivalTime", "22:58" },
            { "Departures[2].StopArea.Gid", 9022014005421000 },
            { "Departures[2].StopArea.Name", "Radiomotet" },
            { "Departures[2].StopArea.Municipality", "Göteborg" },
            { "Departures[2].Destination.Id", "9022014001950010" },
            { "Departures[2].Destination.Name", "Centralstationen, Göteborg" },

            { "Departures[3].Name", "Rosa express" },
            { "Departures[3].ShortName", "ROSA" },
            { "Departures[3].Type", JourneyType.Bus },
            { "Departures[3].DepartureTime", "22:41" },
            { "Departures[3].DepartsInMinutes", 36 },
            { "Departures[3].ArrivalTime", "23:00" },
            { "Departures[3].StopArea.Gid", 9022014005421000 },
            { "Departures[3].StopArea.Name", "Radiomotet" },
            { "Departures[3].StopArea.Municipality", "Göteborg" },
            { "Departures[3].Destination.Id", "9022014004945004" },
            { "Departures[3].Destination.Name", "Nordstan, Göteborg" },

            { "Departures[4].Name", "Rosa express" },
            { "Departures[4].ShortName", "ROSA" },
            { "Departures[4].Type", JourneyType.Bus },
            { "Departures[4].DepartureTime", "23:01" },
            { "Departures[4].DepartsInMinutes", 56 },
            { "Departures[4].ArrivalTime", "23:20" },
            { "Departures[4].StopArea.Gid", 9022014005421000 },
            { "Departures[4].StopArea.Name", "Radiomotet" },
            { "Departures[4].StopArea.Municipality", "Göteborg" },
            { "Departures[4].Destination.Id", "9022014004945004" },
            { "Departures[4].Destination.Name", "Nordstan, Göteborg" },

            { "Departures[5].Name", "Blå express" },
            { "Departures[5].ShortName", "BLÅ" },
            { "Departures[5].Type", JourneyType.Bus },
            { "Departures[5].DepartureTime", "23:08" },
            { "Departures[5].DepartsInMinutes", 63 },
            { "Departures[5].ArrivalTime", "23:28" },
            { "Departures[5].StopArea.Gid", 9022014005421000 },
            { "Departures[5].StopArea.Name", "Radiomotet" },
            { "Departures[5].StopArea.Municipality", "Göteborg" },
            { "Departures[5].Destination.Id", "9022014001950010" },
            { "Departures[5].Destination.Name", "Centralstationen, Göteborg" }
        };

        [Theory, MemberData(nameof(TestParameters))]
        public void ParkingJsonParsing(string property, object expected)
        {
            TestValue<ParkingArea>(property, expected);
        }
    }
}
