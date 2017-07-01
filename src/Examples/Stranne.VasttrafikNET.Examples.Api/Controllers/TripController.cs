using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner;
using Stranne.VasttrafikNET.Models;

namespace Stranne.VasttrafikNET.Examples.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TripController : Controller
    {
        private readonly IJourneyPlannerService _journeyPlannerService;

        public TripController(IJourneyPlannerService journeyPlannerService)
        {
            _journeyPlannerService = journeyPlannerService;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<Trip>))]
        [Route("Trip")]
        public async Task<IActionResult> GetTrip(TripOptions options)
        {
            return Ok(await _journeyPlannerService.GetTripAsync(options));
        }

        [HttpGet]
        [Produces(typeof(JourneyDetail))]
        [Route("JourneyDetail")]
        public async Task<IActionResult> GetJourneyDetail(JourneyDetailReference journeyDetailReference)
        {
            return Ok(await _journeyPlannerService.GetJourneyDetailAsync(journeyDetailReference));
        }
    }
}
