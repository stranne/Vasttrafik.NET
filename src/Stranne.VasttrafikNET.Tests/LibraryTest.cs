using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Stranne.VasttrafikNET.ApiModels.CommuterParking;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner.Enums;
using Stranne.VasttrafikNET.Exceptions;
using Stranne.VasttrafikNET.Models;
using Stranne.VasttrafikNET.Models.Enums;
using Xunit;

namespace Stranne.VasttrafikNET.Tests
{
    [Trait("Area", "library")]
    public class LibraryTest
    {
        private readonly IEnumerable<Type> _publicClasses = new List<Type>
        {
            typeof(JourneyPlannerService),
            typeof(IJourneyPlannerService),
            typeof(CommuterParkingService),
            typeof(ICommuterParkingService),
            typeof(BoardOptions),
            typeof(Coordinate),
            typeof(ParkingOptions),
            typeof(TripOptions),

            typeof(BikeCriterion),
            typeof(BikeProfile),

            typeof(HistoricalAvailability),
            typeof(ParkingArea),
            typeof(ParkingCamera),
            typeof(ParkingLot),
            typeof(ParkingType),
            typeof(StopArea),

            typeof(AbstractLocation),
            typeof(Arrival),
            typeof(BoardEntry),
            typeof(CoordLocation),
            typeof(Departure),
            typeof(Geometry),
            typeof(GeometryInstruction),
            typeof(GeometryPoint),
            typeof(GeometryReference),
            typeof(JourneyDetail),
            typeof(JourneyDetailColor),
            typeof(JourneyDetailDirection),
            typeof(JourneyDetailNote),
            typeof(JourneyDetailReference),
            typeof(JourneyDetailType),
            typeof(JourneyId),
            typeof(JourneyName),
            typeof(Leg),
            typeof(LiveMap),
            typeof(LocationList),
            typeof(Note),
            typeof(Stop),
            typeof(StopLocation),
            typeof(SystemInfo),
            typeof(TimeTableData),
            typeof(TimeTableInfo),
            typeof(TimeTablePeriod),
            typeof(Trip),
            typeof(TripStop),
            typeof(Vehicle),

            typeof(Accessibility),
            typeof(JourneyType),
            typeof(LocationType),
            typeof(NoteSeverity),
            typeof(TripType),

            typeof(AuthenticationException),
            typeof(MissingRequiredParameterException),
            typeof(NetworkException),
            typeof(ServerException)
        };

        [Fact]
        public void VerifyPublicClasses()
        {
            var expected = new List<Type>(_publicClasses);

            var vasttrafikNetAssembly = typeof(JourneyPlannerService).GetTypeInfo().Assembly;
            var actual = vasttrafikNetAssembly.GetTypes()
                .Where(type => type.GetTypeInfo().IsPublic)
                .ToList();

            Assert.True(!expected.Except(actual).Any() && expected.Count == actual.Count);
        }
    }
}
