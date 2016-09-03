namespace Stranne.VasttrafikNET.Tests.Json
{
    public static class JourneyDetailErrorJson
    {
        public const string Json = @"
{
  ""JourneyDetail"":
  {
    ""noNamespaceSchemaLocation"": ""http://api.vasttrafik.se/v1/hafasRestJourneyDetail.xsd"",
    ""error"": ""TI001 traininfoError"",
    ""errorText"": ""No trip journey information available."",
    ""$"": """"
  }
}
";
    }
}
