﻿namespace Stranne.VasttrafikNET.Tests.Json
{
    public static class LocationNearbyStopsJson
    {
        public const string Json = @"
{
  ""LocationList"":
  {
    ""noNamespaceSchemaLocation"": ""http://api.vasttrafik.se/v1/hafasRestLocation.xsd"",
    ""servertime"": ""15:20"",
    ""serverdate"": ""2016-07-31"",
    ""StopLocation"":
    [
      {
        ""name"": ""Domkyrkan, Göteborg"",
        ""id"": ""9022014002130001"",
        ""lat"": ""57.704455"",
        ""lon"": ""11.963636"",
        ""track"": ""A""
      },
      {
        ""name"": ""Domkyrkan, Göteborg"",
        ""id"": ""9021014002130000"",
        ""lat"": ""57.704302"",
        ""lon"": ""11.963699""
      },
      {
        ""name"": ""Domkyrkan, Göteborg"",
        ""id"": ""9022014002130002"",
        ""lat"": ""57.704131"",
        ""lon"": ""11.963761"",
        ""track"": ""B""
      }
    ]
  }
}
";
    }
}
