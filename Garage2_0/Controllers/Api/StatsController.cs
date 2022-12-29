using Garage2_0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Garage2_0.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly IVehicleRepository vehicleRepository;
        private readonly IOptions<MySettings> settings;

        public StatsController(IVehicleRepository vehicleRepository, IOptions<MySettings> settings)
        {
            this.vehicleRepository = vehicleRepository;
            this.settings = settings;
        }

        [HttpGet]
        //[Route("stats")]
        public IActionResult GetStats()
        {
            var stats = new GarageStatistics();
            var allVehicles = vehicleRepository.AllVehicles;

            stats.TotalVehicles = allVehicles.Count();
            stats.TotalSlots = settings.Value.ParkingSlots;
            stats.AvailableSlots = settings.Value.ParkingSlots - stats.TotalVehicles;

            stats.TotalWheels = allVehicles.Sum(p => p.Wheels);

            var totaltime = allVehicles.Sum(v => DateTime.Now.Subtract(v.TimeOfArrival).TotalHours);
            stats.TotalIncome = Math.Round(totaltime * settings.Value.PricePerHour);

            //add number of each vehicle

            string jsonString = JsonSerializer.Serialize(stats);
            return Ok(jsonString);
        }
    }


}


