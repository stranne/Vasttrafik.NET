using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stranne.VasttrafikNET.ApiModels.CommuterParking;
using Stranne.VasttrafikNET.Models;

namespace Stranne.VasttrafikNET.Examples.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CommuterParkingController : Controller
    {
        private readonly ICommuterParkingService _commuterParkingService;

        public CommuterParkingController(ICommuterParkingService commuterParkingService)
        {
            _commuterParkingService = commuterParkingService;
        }

        [HttpGet]
        [Produces(typeof(DateTimeOffset?))]
        [Route("ForecastFullTime/{id}/{dateString}")]
        public async Task<IActionResult> GetForecastFullTime(int id, string dateString)
        {
            var date = DateTimeOffset.Parse(dateString);
            return Ok(await _commuterParkingService.GetForecastFullTimeAsync(id, date));
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<ParkingArea>))]
        [Route("")]
        public async Task<IActionResult> GetParkings(ParkingOptions options)
        {
            return Ok(await _commuterParkingService.GetParkingsAsync(options));
        }

        [HttpGet]
        [Produces(typeof(ParkingArea))]
        [Route("{id}")]
        public async Task<IActionResult> GetParking(int id)
        {
            return Ok(await _commuterParkingService.GetParkingsAsync(id));
        }

        [HttpGet]
        [Produces(typeof(int?))]
        [Route("ForecastAvailability/{id}/{dateString}")]
        public async Task<IActionResult> GetForecastAvailability(int id, string dateString)
        {
            var timestamp = DateTimeOffset.Parse(dateString);
            return Ok(await _commuterParkingService.GetForecastAvailabilityAsync(id, timestamp));
        }

        [HttpGet]
        [Produces(typeof(int))]
        [Route("AvailableCapacity/{id}")]
        public async Task<IActionResult> GetAvailableCapacity(int id)
        {
            return Ok(await _commuterParkingService.GetAvailableCapacityAsync(id));
        }

        [HttpGet]
        [Produces(typeof(HistoricalAvailability))]
        [Route("HistoricalAvailability/{id}")]
        public async Task<IActionResult> GetHistoricalAvailability(int id, DateTimeOffset from, DateTimeOffset to)
        {
            return Ok(await _commuterParkingService.GetHistoricalAvailabilityAsync(id, from, to));
        }
        
        [HttpGet]
        [Produces(typeof(Stream))]
        [Route("Camera/{id}/{cameraId}")]
        public async Task<IActionResult> GetParkingImage(int id, int cameraId)
        {
            return Ok(await _commuterParkingService.GetParkingImageAsync(id, cameraId));
        }
    }
}
