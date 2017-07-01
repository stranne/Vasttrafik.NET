using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner;
using Stranne.VasttrafikNET.Models;

namespace Stranne.VasttrafikNET.Examples.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BoardController : Controller
    {
        private readonly IJourneyPlannerService _journeyPlannerService;

        public BoardController(IJourneyPlannerService journeyPlannerService)
        {
            _journeyPlannerService = journeyPlannerService;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<Arrival>))]
        [Route("Arrivals")]
        public async Task<IActionResult> GetArrivals(BoardOptions boardOptions)
        {
            return Ok(await _journeyPlannerService.GetArrivalBoardAsync(boardOptions));
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<Departure>))]
        [Route("Departures")]
        public async Task<IActionResult> GetDeparture(BoardOptions boardOptions)
        {
            return Ok(await _journeyPlannerService.GetDepartureBoardAsync(boardOptions));
        }
    }
}
