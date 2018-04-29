using System;
using System.IO;
using System.Net.Http;
using System.Text;
using Stranne.VasttrafikNET.Models;
using Xunit;
using System.Linq;
using Stranne.VasttrafikNET.Tests.Jsons;

namespace Stranne.VasttrafikNET.Tests
{
    public class CommuterParkingIntegrationTest : BaseIntegrationTest
    {
        [Fact]
        public void GetForecastFullTime()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/spp/v3/forecastFullTime/5560/20180427?format=json";
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.ForecastFullTime);
            var sut = GetCommuterParkingService();

            var actual = sut.GetForecastFullTime(5560, new DateTimeOffset(2018, 4, 27, 0, 0, 0, new TimeSpan(2, 0, 0)));

            VerifyNetworkMock();
            Assert.Equal(new DateTimeOffset(2018, 4, 27, 7, 15, 0, new TimeSpan(2, 0, 0)), actual);
        }

        [Fact]
        public void GetParkings()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/spp/v3/parkings?format=json";
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.Parkings);
            var sut = GetCommuterParkingService();

            var actual = sut.GetParkings(new ParkingOptions());

            VerifyNetworkMock();
            Assert.Equal(2, actual.Count());
        }

        [Fact]
        public void GetParking()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/spp/v3/parkings/209?format=json";
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.Parking);
            var sut = GetCommuterParkingService();

            var actual = sut.GetParkings(209);

            VerifyNetworkMock();
            Assert.Equal(209, actual.Id);
        }

        [Fact]
        public void GetForecastAvailability()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/spp/v3/forecastAvailability/5560/201804291230?format=json";
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.ForecastAvailability);
            var sut = GetCommuterParkingService();

            var actual = sut.GetForecastAvailability(5560, new DateTimeOffset(2018, 4, 29, 12, 30, 0, new TimeSpan(2, 0, 0)));

            VerifyNetworkMock();
            Assert.Equal(45, actual);
        }

        [Fact]
        public void GetHistoricalAvailability()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/spp/v3/historicalAvailability/209/20160801080000/20160801090000?format=json";
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.HistoricalAvailability);
            var sut = GetCommuterParkingService();

            var actual = sut.GetHistoricalAvailability(209, new DateTimeOffset(2016, 8, 1, 8, 0, 0, new TimeSpan(2, 0, 0)), new DateTimeOffset(2016, 8, 1, 9, 0, 0, new TimeSpan(2, 0, 0)));

            VerifyNetworkMock();
            Assert.Equal(5, actual.Count());
        }

        [Fact]
        public void GetAvailableCapacity()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/spp/v3/availableCapacity/6030?format=json";
            SetUpNetworkServiceMock(absoluteUrl, JsonFile.AvailableCapacity);
            var sut = GetCommuterParkingService();

            var actual = sut.GetAvailableCapacity(6030);

            VerifyNetworkMock();
            Assert.Equal(50, actual);
        }

        [Fact]
        public void GetAvailableCapacityNull()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/spp/v3/availableCapacity/203?format=json";
            SetUpNetworkServiceMock(absoluteUrl);
            var sut = GetCommuterParkingService();

            var actual = sut.GetAvailableCapacity(203);

            VerifyNetworkMock();
            Assert.Null(actual);
        }

        [Fact]
        public void GetParkingImage()
        {
            const string absoluteUrl = "https://api.vasttrafik.se/spp/v3/parkingImages/6030/1?format=json";
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
