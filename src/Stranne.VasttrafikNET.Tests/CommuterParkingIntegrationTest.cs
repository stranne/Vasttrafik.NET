using System;
using System.IO;
using System.Net.Http;
using System.Text;
using Stranne.VasttrafikNET.Models;
using Stranne.VasttrafikNET.Tests.Json;
using Xunit;
using System.Linq;

namespace Stranne.VasttrafikNET.Tests
{
    public class CommuterParkingIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void GetParkings()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/spp/v2/parkings?format=json";
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.Parkings);
            var sut = GetCommuterParkingService();

            var actual = sut.GetParkings(new ParkingOptions());

            VerifyNetworkMock();
            Assert.Equal(2, actual.Count());
        }

        [Fact]
        public void GetParking()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/spp/v2/parkings/209?format=json";
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.Parking);
            var sut = GetCommuterParkingService();

            var actual = sut.GetParkings(209);

            VerifyNetworkMock();
            Assert.Equal(209, actual.Id);
        }

        [Fact]
        public void GetHistoricalAvailability()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/spp/v2/historicalAvailability/209/20160801080000/20160801090000?format=json";
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.HistoricalAvailability);
            var sut = GetCommuterParkingService();

            var actual = sut.GetHistoricalAvailability(209, new DateTimeOffset(2016, 8, 1, 8, 0, 0, new TimeSpan(2, 0, 0)), new DateTimeOffset(2016, 8, 1, 9, 0, 0, new TimeSpan(2, 0, 0)));

            VerifyNetworkMock();
            Assert.Equal(5, actual.Count());
        }

        [Fact]
        public void GetAvailableCapacity()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/spp/v2/availableCapacity/6030?format=json";
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.AvailableCapacity);
            var sut = GetCommuterParkingService();

            var actual = sut.GetAvailableCapacity(6030);

            VerifyNetworkMock();
            Assert.Equal(50, actual);
        }

        [Fact]
        public void GetParkingImage()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/spp/v2/parkingImages/6030/1?format=json";
            const string streamContent = "stream content";
            SetUpNetworkServiceMock(absoluteUrl, new StreamContent(new MemoryStream(Encoding.UTF8.GetBytes(streamContent))));
            var sut = GetCommuterParkingService();

            var actual = sut.GetParkingImage(6030, 1);

            VerifyNetworkMock();
            Assert.Equal(streamContent, new StreamReader(actual).ReadToEnd());
        }

        [Fact]
        public void Dispose()
        {
            var sut = new CommuterParkingService(Key, Secret);
            sut.Dispose();
        }
    }
}
