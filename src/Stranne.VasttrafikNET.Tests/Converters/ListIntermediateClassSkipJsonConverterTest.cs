using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner;
using Stranne.VasttrafikNET.Converters;
using Xunit;

namespace Stranne.VasttrafikNET.Tests.Converters
{
    [Trait("Area", "Converter")]
    public class ListIntermediateClassSkipJsonConverterTest
    {
        [Fact]
        public void CanWriteJson()
        {
            Assert.False(new ListIntermediateClassSkipJsonConverter().CanWrite);
        }

        [Fact]
        public void WriteJson()
        {
            Assert.Throws<NotImplementedException>(() => new ListIntermediateClassSkipJsonConverter().WriteJson(null, null, null));
        }

        [Fact]
        public void ReadJsonList()
        {
            const string value = @"{
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
            }";

            var actual = JsonConvert.DeserializeObject<IEnumerable<Note>>(value, new ListIntermediateClassSkipJsonConverter()).ToList();

            Assert.Equal(2, actual.Count);
            Assert.Equal("1", actual.First().Priority);
            Assert.Equal("2", actual.Last().Priority);
        }

        [Fact]
        public void ReadJsonObject()
        {
            const string value = @"{
              ""Note"":
              {
                ""key"": ""disruption-message"",
                ""severity"": ""low"",
                ""priority"": ""1"",
                ""$"": ""Linje 4, 7, 9 och 11, kör efter Centralstationen via Olskrokstorget, Redbergsplatsen och Ejdergatan till Gamlestadstorget och omvänt på grund av ett spårarbete. Detta beräknas pågå den 25 juli klockan 04:00 till 7 augusti klockan 04:00. Räkna med längre restid på sträckan. För mer information se Trafikläge på vasttrafik.se eller i appen Reseplaneraren.""
              }
            }";

            var actual = JsonConvert.DeserializeObject<IEnumerable<Note>>(value, new ListIntermediateClassSkipJsonConverter()).ToList();

            Assert.Equal(1, actual.Count);
            Assert.Equal("1", actual.First().Priority);
        }
    }
}
