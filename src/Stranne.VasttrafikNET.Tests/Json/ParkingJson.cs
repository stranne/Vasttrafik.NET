﻿namespace Stranne.VasttrafikNET.Tests.Json
{
    public static class ParkingJson
    {
        public const string Json = @"
[
  {
    ""Id"": 209,
    ""Name"": ""Radiomotet"",
    ""StopAreas"":
    [
      {
        ""Gid"": 9021014005421000,
        ""Name"": ""Radiomotet"",
        ""Municipality"": ""Göteborg""
      }
    ],
    ""ParkingLots"":
    [
      {
        ""Id"": 6090,
        ""Name"": ""Radiomotet-P1"",
        ""Lat"": 57.6486003,
        ""Lon"": 11.9335886,
        ""TotalCapacity"": 134,
        ""FreeSpaces"": 129,
        ""IsRestrictedByBarrier"": false,
        ""ParkingType"":
        {
          ""Number"": 2,
          ""Name"": ""SMARTCARPARK""
        },
        ""ParkingCameras"":
        [
          {
            ""Id"": 1
          },
          {
            ""Id"": 2
          }
        ]
      }
    ]
  }
]
";
    }
}