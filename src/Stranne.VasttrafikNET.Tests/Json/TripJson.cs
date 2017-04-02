namespace Stranne.VasttrafikNET.Tests.Json
{
    public static class TripJson
    {
        public const string Json = @"
{
  ""TripList"":
  {
    ""noNamespaceSchemaLocation"": ""http://api.vasttrafik.se/v1/hafasRestTrip.xsd"",
    ""servertime"": ""20:30"",
    ""serverdate"": ""2016-07-31"",
    ""Trip"":
    [
      {
        ""Leg"":
        {
          ""name"": ""Spårvagn 2"",
          ""sname"": ""2"",
          ""type"": ""TRAM"",
          ""id"": ""9015014500204112"",
          ""direction"": ""Frölunda via Järntorget"",
          ""fgColor"": ""#fff014"",
          ""bgColor"": ""#00394d"",
          ""stroke"": ""Solid"",
          ""accessibility"": ""wheelChair"",
          ""Origin"":
          {
            ""name"": ""Mölndal centrum, Mölndal"",
            ""type"": ""ST"",
            ""id"": ""9022014012110001"",
            ""routeIdx"": ""0"",
            ""time"": ""20:32"",
            ""date"": ""2016-07-31"",
            ""track"": ""A"",
            ""rtTime"": ""20:32"",
            ""rtDate"": ""2016-07-31"",
            ""$"": ""\n""
          },
          ""Destination"":
          {
            ""name"": ""Centralstationen, Göteborg"",
            ""type"": ""ST"",
            ""id"": ""9022014001950003"",
            ""routeIdx"": ""13"",
            ""cancelled"": ""true"",
            ""time"": ""20:50"",
            ""date"": ""2016-07-31"",
            ""track"": ""C"",
            ""rtTime"": ""20:50"",
            ""rtDate"": ""2016-07-31"",
            ""Notes"":
            {
              ""Note"":
              [
                {
                  ""key"": ""disruption-message"",
                  ""severity"": ""low"",
                  ""priority"": ""1"",
                  ""$"": ""Linje 4, 7, 9 och 11, kör efter Centralstationen via Olskrokstorget, Redbergsplatsen och Ejdergatan till Gamlestadstorget och omvänt på grund av ett spårarbete. Detta beräknas pågå den 25 juli klockan 04:00 till 7 augusti klockan 04:00. Räkna med längre restid på sträckan. För mer information se Trafikläge på vasttrafik.se eller i appen Reseplaneraren.""
                },
                {
                  ""key"": ""disruption-message"",
                  ""severity"": ""low"",
                  ""priority"": ""2"",
                  ""$"": ""Linje 4, 8 och 9, ingen spårvagnstrafik sträckan Gamlestadstorget - Angered och omvänt på grund av ett spårarbete. Buss 4E och 8E ersätter på sträckan. Detta beräknas pågå från 25 juli klockan 04:00 till 7 augusti klockan 04:00. För mer information se Trafikläge på vasttrafik.se eller i appen Reseplaneraren.""
                }
              ]
            }
          },
          ""JourneyDetailRef"":
          {
            ""ref"": ""https://api.vasttrafik.se/bin/rest.exe/v2/journeyDetail?ref=924501%2F336535%2F458390%2F78978%2F80%3Fdate%3D2016-07-31%26station_evaId%3D12110001%26station_type%3Ddep%26format%3Djson%26""
          }
        }
      },
      {
        ""Leg"":
        {
          ""name"": ""Spårvagn 4"",
          ""sname"": ""4"",
          ""type"": ""TRAM"",
          ""id"": ""9015014500404109"",
          ""direction"": ""Angered via Redbergsplatsen"",
          ""fgColor"": ""#14823c"",
          ""bgColor"": ""#ffffff"",
          ""stroke"": ""Solid"",
          ""accessibility"": ""wheelChair"",
          ""booking"": ""true"",
          ""night"": ""true"",
          ""Origin"":
          {
            ""name"": ""Mölndal centrum, Mölndal"",
            ""type"": ""ST"",
            ""id"": ""9022014012110001"",
            ""routeIdx"": ""0"",
            ""time"": ""20:37"",
            ""date"": ""2016-07-31"",
            ""track"": ""A"",
            ""rtTime"": ""20:38"",
            ""rtDate"": ""2016-07-31"",
            ""$"": ""\n""
          },
          ""Destination"":
          {
            ""name"": ""Centralstationen, Göteborg"",
            ""type"": ""ST"",
            ""id"": ""9022014001950001"",
            ""routeIdx"": ""15"",
            ""time"": ""20:58"",
            ""date"": ""2016-07-31"",
            ""track"": ""A"",
            ""rtTime"": ""20:57"",
            ""rtDate"": ""2016-07-31"",
            ""Notes"":
            {
              ""Note"":
              [
                {
                  ""key"": ""disruption-message"",
                  ""severity"": ""low"",
                  ""priority"": ""1"",
                  ""$"": ""Linje 4, 7, 9 och 11, kör efter Centralstationen via Olskrokstorget, Redbergsplatsen och Ejdergatan till Gamlestadstorget och omvänt på grund av ett spårarbete. Detta beräknas pågå den 25 juli klockan 04:00 till 7 augusti klockan 04:00. Räkna med längre restid på sträckan. För mer information se Trafikläge på vasttrafik.se eller i appen Reseplaneraren.""
                },
                {
                  ""key"": ""disruption-message"",
                  ""severity"": ""low"",
                  ""priority"": ""2"",
                  ""$"": ""Linje 4, 8 och 9, ingen spårvagnstrafik sträckan Gamlestadstorget - Angered och omvänt på grund av ett spårarbete. Buss 4E och 8E ersätter på sträckan. Detta beräknas pågå från 25 juli klockan 04:00 till 7 augusti klockan 04:00. För mer information se Trafikläge på vasttrafik.se eller i appen Reseplaneraren.""
                }
              ]
            }
          },
          ""JourneyDetailRef"":
          {
            ""ref"": ""https://api.vasttrafik.se/bin/rest.exe/v2/journeyDetail?ref=356286%2F147173%2F856806%2F309644%2F80%3Fdate%3D2016-07-31%26station_evaId%3D12110001%26station_type%3Ddep%26format%3Djson%26""
          }
        }
      },
      {
        ""Leg"":
        {
          ""name"": ""Spårvagn 2"",
          ""sname"": ""2"",
          ""type"": ""TRAM"",
          ""id"": ""9015014500204114"",
          ""direction"": ""Frölunda via Järntorget"",
          ""fgColor"": ""#fff014"",
          ""bgColor"": ""#00394d"",
          ""stroke"": ""Solid"",
          ""kcal"": ""50"",
          ""reachable"": ""False"",
          ""percentBikeRoad"": ""70"",
          ""accessibility"": ""wheelChair"",
          ""Origin"":
          {
            ""name"": ""Mölndal centrum, Mölndal"",
            ""type"": ""ST"",
            ""id"": ""9022014012110001"",
            ""routeIdx"": ""0"",
            ""time"": ""20:47"",
            ""date"": ""2016-07-31"",
            ""track"": ""A"",
            ""rtTrack"": ""A"",
            ""rtTime"": ""20:47"",
            ""rtDate"": ""2016-07-31"",
            ""time"": ""20:47"",
            ""directtime"": ""20:47"",
            ""directdate"": ""2016-07-31"",
            ""$"": ""\n""
          },
          ""Destination"":
          {
            ""name"": ""Centralstationen, Göteborg"",
            ""type"": ""ST"",
            ""id"": ""9022014001950003"",
            ""routeIdx"": ""13"",
            ""time"": ""21:05"",
            ""date"": ""2016-07-31"",
            ""track"": ""C"",
            ""rtTrack"": ""C"",
            ""rtTime"": ""21:05"",
            ""rtDate"": ""2016-07-31"",
            ""Notes"":
            {
              ""Note"":
                {
                    ""key"": ""disruption-message"",
                    ""severity"": ""low"",
                    ""priority"": ""1"",
                    ""$"": ""Linje 4, 7, 9 och 11, kör efter Centralstationen via Olskrokstorget, Redbergsplatsen och Ejdergatan till Gamlestadstorget och omvänt på grund av ett spårarbete. Detta beräknas pågå den 25 juli klockan 04:00 till 7 augusti klockan 04:00. Räkna med längre restid på sträckan. För mer information se Trafikläge på vasttrafik.se eller i appen Reseplaneraren.""
                }
            }
          },
          ""JourneyDetailRef"":
          {
            ""ref"": ""https://api.vasttrafik.se/bin/rest.exe/v2/journeyDetail?ref=65313%2F50139%2F387298%2F171885%2F80%3Fdate%3D2016-07-31%26station_evaId%3D12110001%26station_type%3Ddep%26format%3Djson%26""
          }
        }
      }
    ]
  }
}
";
    }
}
