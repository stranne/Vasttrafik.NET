using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner;
using Stranne.VasttrafikNET.Models;

namespace Stranne.VasttrafikNET.Examples.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SystemInfoController : Controller
    {
        private readonly IJourneyPlannerService _journeyPlannerService;

        public SystemInfoController(IJourneyPlannerService journeyPlannerService)
        {
            _journeyPlannerService = journeyPlannerService;
        }

        [HttpGet]
        [Produces(typeof(SystemInfo))]
        [Route("SystemInfo")]
        public async Task<IActionResult> GetSystemInfo()
        {
            return Ok(await _journeyPlannerService.GetSystemInfoAsync());
        }
    }
}
