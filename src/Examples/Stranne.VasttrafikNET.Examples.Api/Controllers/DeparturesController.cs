using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Stranne.VasttrafikNET.Examples.Api.Models;
using Stranne.VasttrafikNET.Models;

namespace Stranne.VasttrafikNET.Examples.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DeparturesController : Controller
    {
        private readonly IJourneyPlannerService _journeyPlannerService;
        private readonly IMapper _mapper;

        public DeparturesController(IJourneyPlannerService journeyPlannerService, IMapper mapper)
        {
            _journeyPlannerService = journeyPlannerService;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<DepartureEntry>))]
        [Route("{stopId}")]
        public async Task<IActionResult> Get(string stopId)
        {
            var departures = await _journeyPlannerService.GetDepartureBoardAsync(new BoardOptions
            {
                Id = stopId,
                TimeSpan = new TimeSpan(1, 0, 0),
                MaxDeparturesPerLine = 2
            });

            return Ok(_mapper.Map<IEnumerable<DepartureEntry>>(departures));
        }
    }
}
