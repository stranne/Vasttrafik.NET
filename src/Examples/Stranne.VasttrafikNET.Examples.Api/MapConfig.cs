using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner;
using Stranne.VasttrafikNET.Examples.Api.Models;

namespace Stranne.VasttrafikNET.Examples.Api
{
    public class MapConfig : Profile
    {
        public MapConfig()
        {
            CreateMap<StopLocation, StopEntry>();

            CreateMap<IEnumerable<Departure>, IEnumerable<DepartureEntry>>()
                .ConvertUsing(departures => departures
                            .GroupBy(
                                departure =>
                                    new
                                    {
                                        departure.ShortName,
                                        departure.Direction,
                                        Track = departure.RealtimeTrack ?? departure.Track
                                    })
                            .Select(departureGroup =>
                            {
                                var departureList = departureGroup
                                    .OrderBy(dg => dg.RealtimeDateTime ?? dg.DateTime)
                                    .Take(2)
                                    .ToArray();

                                var nextDeparture = departureList[0].Minutes;
                                var secondDeparture = departureList.Length >= 2
                                    ? departureList[1].Minutes
                                    : null as int?;

                                return new DepartureEntry
                                {
                                    ShortName = departureGroup.Key.ShortName,
                                    Direction = departureGroup.Key.Direction,
                                    Track = departureGroup.Key.Track,
                                    NextDeparture = nextDeparture,
                                    SecondDeparture = secondDeparture
                                };
                            }));
        }
    }
}
