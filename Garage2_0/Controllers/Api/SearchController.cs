using AutoMapper;
using Garage2_0.Dtos;
using Garage2_0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Garage2_0.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : Controller
    {
        private readonly IVehicleRepository vehicleRepository;
        private readonly IOptions<MySettings> settings;
        private readonly IMapper mapper;

        public SearchController(IVehicleRepository vehicleRepository, IOptions<MySettings> settings, IMapper mapper)
        {
            this.vehicleRepository = vehicleRepository;
            this.settings = settings;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetVehicles()
        {
            var allVehicles = vehicleRepository.AllVehicles;
            var vehicleDtos = mapper.Map<List<VehicleDto>>(allVehicles);
            return Ok(vehicleDtos);
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
            double price = time.TotalHours * settings.Value.PricePerHour;

            return Ok(Math.Round(price));
        }


        [HttpGet]
        [Produces("application/json")]
        [Route("[action]")]
        public async Task<IActionResult> RegSearch(string term)
        {
            try
            {
                //string term = HttpContext.Request.Query["term"].ToString();

        //        if (!string.IsNullOrEmpty(term))
          //      {
                    var vehicles = vehicleRepository.SearchVehicles(term).Select(v=>new { name=v.RegistrationNr,value= v.RegistrationNr });
                    return Ok(vehicles);
      //          }

            }
            catch { return BadRequest(); }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SearchVehicles([FromBody] string searchQuery)
        {
            IEnumerable<Vehicle> vehicles = new List<Vehicle>();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                vehicles = vehicleRepository.SearchVehicles(searchQuery);
            }
            //return new JsonResult(vehicles);
            return PartialView("_SearchHitsPartial", vehicles);
        }

    }
}
