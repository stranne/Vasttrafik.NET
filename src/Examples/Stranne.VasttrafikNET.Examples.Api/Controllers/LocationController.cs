using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stranne.VasttrafikNET.ApiModels.JourneyPlanner;
using Stranne.VasttrafikNET.Models;

namespace Stranne.VasttrafikNET.Examples.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class LocationController : Controller
    {
        private readonly IJourneyPlannerService _journeyPlannerService;

        public LocationController(IJourneyPlannerService journeyPlannerService)
        {
            _journeyPlannerService = journeyPlannerService;
        }

        [HttpGet]
        [Produces(typeof(LocationList))]
        [Route("NearbyAddress")]
        public async Task<IActionResult> GetNerbyAddress(Coordinate coordinate)
        {
            return Ok(await _journeyPlannerService.GetLocationNearbyAddressAsync(coordinate));
        }

        [HttpGet]
        [Produces(typeof(LocationList))]
        [Route("NearbyStops")]
        public async Task<IActionResult> GetNearbyStops(Coordinate coordinate, int? maxNo, int? maxDist)
        {
            return Ok(await _journeyPlannerService.GetLocationNearbyStopsAsync(coordinate, maxNo, maxDist));
        }

        [HttpGet]
        [Produces(typeof(LocationList))]
        [Route("Name")]
        public async Task<IActionResult> SearchWithName(string input)
        {
            return Ok(await _journeyPlannerService.GetLocationNameAsync(input));
        }

        [HttpGet]
        [Produces(typeof(LocationList))]
        [Route("AllStops")]
        public async Task<IActionResult> GetAllStops()
        {
            return Ok(await _journeyPlannerService.GetLocationAllStopsAsync());
        }

        [HttpGet]
        [Produces(typeof(Geometry))]
        [Route("Geometry")]
        public async Task<IActionResult> GetGeometry(GeometryReference geometryReference)
        {
            return Ok(await _journeyPlannerService.GetGeometryAsync(geometryReference));
        }

        [HttpGet]
        [Produces(typeof(LiveMap))]
        [Route("LiveMap")]
        public async Task<IActionResult> GetLiveMap(double longitudeMin, double longitudeMax, double latitudeMin, double latitudeMax, bool onlyRealtime)
        {
            return Ok(await _journeyPlannerService.GetLiveMapAsync(longitudeMin, longitudeMax, latitudeMin, latitudeMax, onlyRealtime));
        }
    }
}
