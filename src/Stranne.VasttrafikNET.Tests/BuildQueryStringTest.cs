using System;
using Stranne.VasttrafikNET.Exceptions;
using Stranne.VasttrafikNET.Models;
using Stranne.VasttrafikNET.Models.Enums;
using Stranne.VasttrafikNET.Service;
using Xunit;
using System.Reflection;

namespace Stranne.VasttrafikNET.Tests
{
    [Trait("Area", "Service")]
    public class BuildQueryStringTest
    {
        [Fact]
        public void BoardOptionsPropertyExcludeDr()
        {
            var boardOptions = new BoardOptions
            {
                Id = "0000000800000022",
                DateTime = new DateTimeOffset(2020, 1, 1, 12, 0, 0, new TimeSpan(1, 0, 0)),
                ExcludeDr = true
            };

            var expected = $"?date=2020-01-01&time=12:00&excludeDr=1&id=0000000800000022&format=json";

            var actual = BaseHandlingService.BuildParameterString(boardOptions);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(nameof(BoardOptions.MaxDeparturesPerLine), 100, "maxDeparturesPerLine=100")]
        [InlineData(nameof(BoardOptions.NeedJorneyDetail), false, "needJorneyDetail=0")]
        [InlineData(nameof(BoardOptions.UseBoat), false, "useBoat=0")]
        [InlineData(nameof(BoardOptions.UseBus), false, "useBus=0")]
        [InlineData(nameof(BoardOptions.UseLongDistanceTrain), false, "useLDTrain=0")]
        [InlineData(nameof(BoardOptions.UseRegionalTrain), false, "useRegTrain=0")]
        [InlineData(nameof(BoardOptions.UseTram), false, "useTram=0")]
        [InlineData(nameof(BoardOptions.UseVasttagen), false, "useVas=0")]
        public void BoardOptionsProperty(string propertyName, object value, string expectedQuery)
        {
            var boardOptions = new BoardOptions
            {
                Id = "0000000800000022",
                DateTime = new DateTimeOffset(2020, 1, 1, 12, 0, 0, new TimeSpan(1, 0, 0))
            };
            typeof(BoardOptions).GetProperty(propertyName).SetValue(boardOptions, value, null);

            var expected = $"?date=2020-01-01&time=12:00&id=0000000800000022&{expectedQuery}&format=json";

            var actual = BaseHandlingService.BuildParameterString(boardOptions);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BoardOptionsRequiredProperties()
        {
            var boardOptions = new BoardOptions
            {
                Id = "0000000800000022",
                DateTime = new DateTimeOffset(2020, 1, 1, 12, 0, 0, new TimeSpan(1, 0, 0))
            };

            const string expected = "?date=2020-01-01&time=12:00&id=0000000800000022&format=json";

            var actual = BaseHandlingService.BuildParameterString(boardOptions);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BoardOptionsTimespan()
        {
            var boardOptions = new BoardOptions
            {
                Id = "0000000800000022",
                DateTime = new DateTimeOffset(2020, 1, 1, 12, 0, 0, new TimeSpan(1, 0, 0)),
                TimeSpan = new TimeSpan(1, 30, 5)
            };

            const string expected = "?date=2020-01-01&time=12:00&id=0000000800000022&timeSpan=90&format=json";

            var actual = BaseHandlingService.BuildParameterString(boardOptions);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BoardOptionsMissingRequiredProperties()
        {
            var exception = Assert.Throws<MissingRequiredParameterException>(() => BaseHandlingService.BuildParameterString(new BoardOptions()));
            Assert.Contains("Id", exception.MissingParameters);
            Assert.Equal("Missing the required parameters: Id", exception.Message);
        }

        [Fact]
        public void LiveMapOptionsRequiredProperties()
        {
            var boardOptions = new LiveMapOptions
            {
                Minx = 1,
                Maxx = 2,
                Miny = 3,
                Maxy = 4,
                OnlyRealtime = true
            };

            const string expected = "?maxx=2&maxy=4&minx=1&miny=3&onlyRealtime=yes&format=json";

            var actual = BaseHandlingService.BuildParameterString(boardOptions);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LiveMapOptionsMissingRequiredProperties()
        {
            var exception = Assert.Throws<MissingRequiredParameterException>(() => BaseHandlingService.BuildParameterString(new LiveMapOptions()));
            Assert.Contains("Maxy", exception.MissingParameters);
            Assert.Contains("Maxy", exception.MissingParameters);
            Assert.Contains("Minx", exception.MissingParameters);
            Assert.Contains("Miny", exception.MissingParameters);
            Assert.Contains("OnlyRealtime", exception.MissingParameters);
            Assert.Equal("Missing the required parameters: Maxx, Maxy, Minx, Miny, OnlyRealtime", exception.Message);
        }

        [Fact]
        public void LocationNearbyStopsOptionRequiredProperties()
        {
            var options = new LocationNearbyStopsOptions
            {
                OriginCoordinate = new Coordinate
                {
                    Latitude = 57.705686,
                    Longitude = 11.963654
                }
            };

            const string expected = "?originCoordLat=57.705686&originCoordLong=11.963654&format=json";

            var actual = BaseHandlingService.BuildParameterString(options);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(nameof(LocationNearbyStopsOptions.MaxNo), 20, "maxNo=20")]
        [InlineData(nameof(LocationNearbyStopsOptions.MaxDist), 1000, "maxDist=1000")]
        public void LocationNearbyStopsOptionProperty(string propertyName, object value, string expectedQuery)
        {
            var options = new LocationNearbyStopsOptions
            {
                OriginCoordinate = new Coordinate
                {
                    Latitude = 57.705686,
                    Longitude = 11.963654
                }
            };
            typeof(LocationNearbyStopsOptions).GetProperty(propertyName).SetValue(options, value, null);

            var expected = $"?{expectedQuery}&originCoordLat=57.705686&originCoordLong=11.963654&format=json";

            var actual = BaseHandlingService.BuildParameterString(options);
            Assert.Equal(expected, actual);
        }

        public static TheoryData TripOptionsParameters => new TheoryData<string, object, string>
        {
            {
                nameof(TripOptions.AdditionalChangeTime), 100, "additionalChangeTime=100"
            },
            {
                nameof(TripOptions.BikeCriterion), BikeCriterion.DedicatedBikeRoads, "bikeCriterion=D"
            },
            {
                nameof(TripOptions.BikeCriterion), BikeCriterion.FastRoute, "bikeCriterion=F"
            },
            {
                nameof(TripOptions.BikeProfile), BikeProfile.Easy, "bikeProfile=E"
            },
            {
                nameof(TripOptions.BikeProfile), BikeProfile.Normal, "bikeProfile=N"
            },
            {
                nameof(TripOptions.BikeProfile), BikeProfile.Powerful, "bikeProfile=P"
            },
            {
                nameof(TripOptions.DestCoordinate), new Coordinate
                {
                    Latitude = 57.705686,
                    Longitude = 11.963654
                }, "destCoordLat=57.705686&destCoordLong=11.963654"
            },
            {
                nameof(TripOptions.DestId), "9021014001950000", "destId=9021014001950000"
            },
            {
                nameof(TripOptions.DestCoordName), "Centralstationen, Göteborg", "destCoordName=Centralstationen, Göteborg"
            },
            {
                nameof(TripOptions.DestMedicalCon), true, "destMedicalCon=1"
            },
            {
                nameof(TripOptions.DestWalk), false, "destWalk=0"
            },
            {
                nameof(TripOptions.DisregardDefaultChangeMargin), true, "disregardDefaultChangeMargin=1"
            },
            {
                nameof(TripOptions.ExcludeDr), true, "excludeDr=1"
            },
            {
                nameof(TripOptions.LowFloor), true, "lowFloor=1"
            },
            {
                nameof(TripOptions.MaxBikeDist), 5000, "maxBikeDist=5000"
            },
            {
                nameof(TripOptions.MaxCarDist), 10000, "maxCarDist=10000"
            },
            {
                nameof(TripOptions.MaxChanges), 3, "maxChanges=3"
            },
            {
                nameof(TripOptions.MaxWalkDist), 150, "maxWalkDist=150"
            },
            {
                nameof(TripOptions.NeedGeo), true, "needGeo=1"
            },
            {
                nameof(TripOptions.NeedItinerary), true, "needItinerary=1"
            },
            {
                nameof(TripOptions.NeedJourneyDetail), false, "needJourneyDetail=0"
            },
            {
                nameof(TripOptions.NumTrips), 5, "numTrips=5"
            },
            {
                nameof(TripOptions.OnlyBike), true, "onlyBike=1"
            },
            {
                nameof(TripOptions.OnlyCar), true, "onlyCar=1"
            },
            {
                nameof(TripOptions.OnlyWalk), true, "onlyWalk=1"
            },
            {
                nameof(TripOptions.OriginBike), true, "originBike=1"
            },
            {
                nameof(TripOptions.OriginCar), true, "originCar=1"
            },
            {
                nameof(TripOptions.OriginCarWithParking), true, "originCarWithParking=1"
            },
            {
                nameof(TripOptions.OriginMedicalCon), true, "originMedicalCon=1"
            },
            {
                nameof(TripOptions.OriginCoordinate), new Coordinate
                {
                    Latitude = 57.705686,
                    Longitude = 11.963654
                }, "originCoordLat=57.705686&originCoordLong=11.963654"
            },
            {
                nameof(TripOptions.OriginId), "9021014001950000", "originId=9021014001950000"
            },
            {
                nameof(TripOptions.OriginCoordName), "Centralstationen, Göteborg", "originCoordName=Centralstationen, Göteborg"
            },
            {
                nameof(TripOptions.OriginWalk), false, "originWalk=0"
            },
            {
                nameof(TripOptions.RampOrLift), true, "rampOrLift=1"
            },
            {
                nameof(TripOptions.SearchForArrival), true, "searchForArrival=1"
            },
            {
                nameof(TripOptions.StrollerSpace), true, "strollerSpace=1"
            },
            {
                nameof(TripOptions.UseBoat), false, "useBoat=0"
            },
            {
                nameof(TripOptions.UseBus), false, "useBus=0"
            },
            {
                nameof(TripOptions.UseLdTrain), false, "useLDTrain=0"
            },
            {
                nameof(TripOptions.UseMedical), true, "useMedical=1"
            },
            {
                nameof(TripOptions.UsePt), false, "usePt=0"
            },
            {
                nameof(TripOptions.UseRegTrain), false, "useRegTrain=0"
            },
            {
                nameof(TripOptions.UseTram), false, "useTram=0"
            },
            {
                nameof(TripOptions.UseVas), false, "useVas=0"
            },
            {
                nameof(TripOptions.WalkSpeed), "120", "walkSpeed=120"
            },
            {
                nameof(TripOptions.WheelChairSpace), true, "wheelChairSpace=1"
            }
        };

        [Theory, MemberData(nameof(TripOptionsParameters))]
        public void TripOptionsProperty(string propertyName, object value, string expectedQuery)
        {
            var options = new TripOptions();
            typeof(TripOptions).GetProperty(propertyName).SetValue(options, value, null);

            var expected = $"?{expectedQuery}&format=json";

            var actual = BaseHandlingService.BuildParameterString(options);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LocationNearbyStopsOptionMissingRequiredProperties()
        {
            var exception = Assert.Throws<MissingRequiredParameterException>(() => BaseHandlingService.BuildParameterString(new LocationNearbyStopsOptions()));
            Assert.Contains("OriginCoordinate", exception.MissingParameters);
            Assert.Equal("Missing the required parameters: OriginCoordinate", exception.Message);
        }

        public static TheoryData ParkingOptionsParameters => new TheoryData<string, object, string>
        {
            {
                nameof(ParkingOptions.StopArea), "9021014016710000", "stopArea=9021014016710000"
            },
            {
                nameof(ParkingOptions.Municipality), "Ale", "municipality=Ale"
            },
            {
                nameof(ParkingOptions.Coordinate), new CoordinateSerializeable
                {
                    Latitude = 57.705686,
                    Longitude = 11.963654
                }, "lat=57.705686&lon=11.963654"
            },
            {
                nameof(ParkingOptions.Distance), 2000, "dist=2000"
            },
            {
                nameof(ParkingOptions.Max), 25, "max=25"
            }
        };

        [Theory, MemberData(nameof(ParkingOptionsParameters))]
        public void ParkingOptionsProperty(string propertyName, object value, string expectedQuery)
        {
            var options = new ParkingOptions();
            typeof(ParkingOptions).GetProperty(propertyName).SetValue(options, value, null);

            var expected = $"?{expectedQuery}&format=json";

            var actual = BaseHandlingService.BuildParameterString(options);
            Assert.Equal(expected, actual);
        }
    }
}
