using System;
using System.Linq;
using Xunit;
using Stranne.VasttrafikNET.Tests.Jsons;

namespace Stranne.VasttrafikNET.Tests
{
    public class TrafficSituationsIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void GetForStationNumber()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/ts/v1/traffic-situations/RT1193380";
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.TrafficSituation);
            var sut = GetTrafficSituationsService();

            var actual = sut.ForStationNumber("RT1193380");

            VerifyNetworkMock();
            Assert.Equal("RT1193380", actual.SituationNumber);
        }

        [Fact]
        public void GetForStopPoint()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/ts/v1/traffic-situations/stoppoint/9022014016200002";
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.TrafficSituationsStopPoints);
            var sut = GetTrafficSituationsService();

            var actual = sut.ForStopPoint("9022014016200002");

            VerifyNetworkMock();
            Assert.Equal(2, actual.Count());
        }

        [Fact]
        public void GetAll()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/ts/v1/traffic-situations";
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.TrafficSituations);
            var sut = GetTrafficSituationsService();

            var actual = sut.All();

            VerifyNetworkMock();
            Assert.Equal(5, actual.Count());
        }

        [Fact]
        public void GetForLine()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/ts/v1/traffic-situations/line/9011014508200000";
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.TrafficSituationsLines);
            var sut = GetTrafficSituationsService();

            var actual = sut.ForLine("9011014508200000");

            VerifyNetworkMock();
            Assert.Equal(1, actual.Count());
        }

        [Fact]
        public void GetForJourney()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/ts/v1/traffic-situations/journey/9015014167103831";
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.TrafficSituationsJourneies);
            var sut = GetTrafficSituationsService();

            var actual = sut.ForJourney("9015014167103831");

            VerifyNetworkMock();
            Assert.Equal(1, actual.Count());
        }

        [Fact]
        public void GetForStopArea()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/ts/v1/traffic-situations/stoparea/9021014037386000";
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.TrafficSituationsStopAreas);
            var sut = GetTrafficSituationsService();

            var actual = sut.ForStopArea("9021014037386000");

            VerifyNetworkMock();
            Assert.Equal(1, actual.Count());
        }

        [Fact]
        public void Dispose()
        {
            var sut = new TrafficSituationsService(Key, Secret);
            sut.Dispose();
        }
    }
}
