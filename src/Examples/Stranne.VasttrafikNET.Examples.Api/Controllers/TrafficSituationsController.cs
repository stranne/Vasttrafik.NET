using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stranne.VasttrafikNET.ApiModels.TrafficSituations;

namespace Stranne.VasttrafikNET.Examples.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TrafficSituationsController : Controller
    {
        private readonly ITrafficSituationsService _trafficSituationsService;

        public TrafficSituationsController(ITrafficSituationsService trafficSituationsService)
        {
            _trafficSituationsService = trafficSituationsService;
        }

        [HttpGet]
        [Produces(typeof(TrafficSituationApiModel))]
        [Route("StationNumber")]
        public async Task<IActionResult> StationNumber(string stationNumber)
        {
            return Ok(await _trafficSituationsService.ForStationNumberAsync(stationNumber));
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<TrafficSituationApiModel>))]
        [Route("StopPoint")]
        public async Task<IActionResult> StopPoint(string stopPointGid)
        {
            return Ok(await _trafficSituationsService.ForStopPointAsync(stopPointGid));
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<TrafficSituationApiModel>))]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(await _trafficSituationsService.AllAsync());
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<TrafficSituationApiModel>))]
        [Route("Line")]
        public async Task<IActionResult> Line(string lineGid)
        {
            return Ok(await _trafficSituationsService.ForLineAsync(lineGid));
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<TrafficSituationApiModel>))]
        [Route("Journey")]
        public async Task<IActionResult> Journey(string journeyGid)
        {
            return Ok(await _trafficSituationsService.ForJourneyAsync(journeyGid));
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<TrafficSituationApiModel>))]
        [Route("StopArea")]
        public async Task<IActionResult> StopArea(string stopAreaGid)
        {
            return Ok(await _trafficSituationsService.ForStopAreaAsync(stopAreaGid));
        }
    }
}
