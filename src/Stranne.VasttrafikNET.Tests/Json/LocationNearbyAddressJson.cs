namespace Stranne.VasttrafikNET.Tests.Json
{
    public static class LocationNearbyAddressJson
    {
        public const string Json = @"
{
  ""LocationList"":
  {
    ""noNamespaceSchemaLocation"": ""http://api.vasttrafik.se/v1/hafasRestLocation.xsd"",
    ""servertime"": ""19:21"",
    ""serverdate"": ""2016-07-30"",
    ""CoordLocation"":
    {
      ""name"": ""Södra Hamngatan 11, 411 14 Göteborg"",
      ""lat"": ""57.705686"",
      ""lon"": ""11.963654"",
      ""type"": ""ADR""
    }
  }
}
";
    }
}
