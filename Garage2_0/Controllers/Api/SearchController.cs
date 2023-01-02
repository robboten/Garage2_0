using Garage2_0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Drawing.Text;

namespace Garage2_0.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IVehicleRepository vehicleRepository;
        private readonly IOptions<MySettings> settings;

        public SearchController(IVehicleRepository vehicleRepository, IOptions<MySettings> settings)
        {
            this.vehicleRepository = vehicleRepository;
            this.settings = settings;
        }

        [HttpGet]
        public IActionResult GetVehicles() {
            var allVehicles = vehicleRepository.AllVehicles;
            return Ok(allVehicles);
        }

        [HttpGet("{regNr}")]
        public IActionResult GetVehicleByRegNr(string regNr) 
        {
            var vehicle = vehicleRepository.GetVehicleByRegNr(regNr);
            return Ok(vehicle);
        }

        [HttpGet]
        [Route("checkout/{regNr}")]
        public IActionResult GetCheckoutPrice(string regNr)
        {
            var date = vehicleRepository.GetCheckoutPrice(regNr);
            var time = DateTime.Now.Subtract(date);
            double price = time.TotalHours*settings.Value.PricePerHour;
            
            return Ok(Math.Round(price));
        }

    }
}
