using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Stranne.VasttrafikNET.Examples.Api.Models;
using Stranne.VasttrafikNET.Models;

namespace Stranne.VasttrafikNET.Examples.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class StopsController : Controller
    {
        private readonly IJourneyPlannerService _journeyPlannerService;
        private readonly IMapper _mapper;

        public StopsController(IJourneyPlannerService journeyPlannerService, IMapper mapper)
        {
            _journeyPlannerService = journeyPlannerService;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<StopEntry>))]
        [Route("{searchTerm}")]
        public async Task<IActionResult> Get(string searchTerm)
        {
            var stops = await _journeyPlannerService.GetLocationNameAsync(searchTerm);

            return Ok(_mapper.Map<IEnumerable<StopEntry>>(stops.StopLocation));
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<StopEntry>))]
        [Route("{latitude}/{longitude}")]
        public async Task<IActionResult> Get(double latitude, double longitude)
        {
            var stops = await _journeyPlannerService.GetLocationNearbyStopsAsync(new Coordinate(latitude, longitude));

            return Ok(_mapper.Map<IEnumerable<StopEntry>>(stops.StopLocation));
        }
    }
}
