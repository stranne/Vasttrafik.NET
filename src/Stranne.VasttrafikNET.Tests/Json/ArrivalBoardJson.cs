namespace Stranne.VasttrafikNET.Tests.Json
{
    public static class ArrivalBoardJson
    {
        public const string Json = @"
{
  ""ArrivalBoard"":
  {
    ""noNamespaceSchemaLocation"": ""http: //api.vasttrafik.se/v1/hafasRestArrivalBoard.xsd"",
    ""servertime"": ""21:50"",
    ""serverdate"": ""2016-07-16"",
    ""Arrival"":
    [
      {
        ""name"": ""Spårvagn 2"",
        ""sname"": ""2"",
        ""type"": ""TRAM"",
        ""stopid"": ""9022014001950003"",
        ""stop"": ""Centralstationen, Göteborg"",
        ""time"": ""16:50"",
        ""date"": ""2016-07-16"",
        ""journeyid"": ""9015014500204078"",
        ""origin"": ""Frölunda"",
        ""track"": ""C"",
        ""fgColor"": ""#fff014"",
        ""bgColor"": ""#00394d"",
        ""stroke"": ""Solid"",
        ""JourneyDetailRef"":
        {
          ""ref"": ""http://api.vasttrafik.se/bin/rest.exe/v1/journeyDetail?ref=748710%2F275948%2F848764%2F174814%2F80%3Fdate%3D2016-07-16%26station_evaId%3D1950003%26station_type%3Ddep%26authKey%3Def187f08-6bb5-454f-a1d3-d9293dc12991%26format%3Djson%26""
        }
      },
      {
        ""name"": ""SVART EXPRESS"",
        ""sname"": ""SVAR"",
        ""type"": ""BUS"",
        ""stopid"": ""9022014001950011"",
        ""stop"": ""Centralstationen, Göteborg"",
        ""time"": ""16:50"",
        ""date"": ""2016-07-16"",
        ""journeyid"": ""9015014521100644"",
        ""origin"": ""Amhult"",
        ""track"": ""K"",
        ""fgColor"": ""#000000"",
        ""bgColor"": ""#ffffff"",
        ""stroke"": ""Solid"",
        ""accessibility"": ""wheelChair"",
        ""JourneyDetailRef"":
        {
          ""ref"": ""http://api.vasttrafik.se/bin/rest.exe/v1/journeyDetail?ref=28509%2F27666%2F251016%2F116017%2F80%3Fdate%3D2016-07-16%26station_evaId%3D1950011%26station_type%3Ddep%26authKey%3Def187f08-6bb5-454f-a1d3-d9293dc12991%26format%3Djson%26""
        }
      },
      {
        ""name"": ""SVART EXPRESS"",
        ""sname"": ""SVAR"",
        ""type"": ""BUS"",
        ""stopid"": ""9022014004945004"",
        ""stop"": ""Nordstan, Göteborg"",
        ""time"": ""16:50"",
        ""date"": ""2016-07-16"",
        ""journeyid"": ""9015014521100644"",
        ""origin"": ""Amhult"",
        ""track"": ""D"",
        ""fgColor"": ""#000000"",
        ""bgColor"": ""#ffffff"",
        ""stroke"": ""Solid"",
        ""accessibility"": ""wheelChair"",
        ""JourneyDetailRef"":
        {
          ""ref"": ""http://api.vasttrafik.se/bin/rest.exe/v1/journeyDetail?ref=578484%2F210991%2F472736%2F43552%2F80%3Fdate%3D2016-07-16%26station_evaId%3D4945004%26station_type%3Ddep%26authKey%3Def187f08-6bb5-454f-a1d3-d9293dc12991%26format%3Djson%26""
        }
      },
      {
        ""name"": ""VÄSTTÅGEN"",
        ""sname"": ""TÅG"",
        ""type"": ""VAS"",
        ""stopid"": ""9022014008000010"",
        ""stop"": ""Göteborg C, Göteborg"",
        ""time"": ""16:50"",
        ""date"": ""2016-07-16"",
        ""journeyid"": ""9015014133103666"",
        ""origin"": ""Älvängen"",
        ""fgColor"": ""#00A5DC"",
        ""bgColor"": ""#ffffff"",
        ""stroke"": ""Solid"",
        ""JourneyDetailRef"":
        {
          ""ref"": ""http://api.vasttrafik.se/bin/rest.exe/v1/journeyDetail?ref=483735%2F185050%2F231500%2F45500%2F80%3Fdate%3D2016-07-16%26station_evaId%3D8000010%26station_type%3Ddep%26authKey%3Def187f08-6bb5-454f-a1d3-d9293dc12991%26format%3Djson%26""
        }
      },
      {
        ""name"": ""Spårvagn 2"",
        ""sname"": ""2"",
        ""type"": ""TRAM"",
        ""stopid"": ""9022014001950001"",
        ""stop"": ""Centralstationen, Göteborg"",
        ""time"": ""16:51"",
        ""date"": ""2016-07-16"",
        ""journeyid"": ""9015014500204077"",
        ""origin"": ""Mölndal"",
        ""track"": ""A"",
        ""fgColor"": ""#fff014"",
        ""bgColor"": ""#00394d"",
        ""stroke"": ""Solid"",
        ""JourneyDetailRef"":
        {
          ""ref"": ""http://api.vasttrafik.se/bin/rest.exe/v1/journeyDetail?ref=702918%2F253010%2F766880%2F149136%2F80%3Fdate%3D2016-07-16%26station_evaId%3D1950001%26station_type%3Ddep%26authKey%3Def187f08-6bb5-454f-a1d3-d9293dc12991%26format%3Djson%26""
        }
      }
    ]
  }
}
";
    }
}
