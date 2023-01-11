using Garage2_0.Data;
using Garage2_0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NuGet.Configuration;
using System.Diagnostics;
using System.IO.Pipelines;

namespace Garage2_0.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<MySettings> _settings;
        private readonly ILogger<HomeController> _logger;
        private readonly GarageContext _context;
        public HomeController(GarageContext context, ILogger<HomeController> logger, IOptions<MySettings> settings)
        {
            _logger = logger;
            _settings = settings;
            _context = context;
        }


        //[HttpGet("search")]
        //[Route("api")]
        //[Produces("application/json")]
        //public async Task<IActionResult> Search()
        //{
        //    try
        //    {
        //        string term = HttpContext.Request.Query["term"].ToString();

        //        //        if (!string.IsNullOrEmpty(term))
        //        //      {
        //        var vehicles = _context.Vehicle.Where(v => v.RegistrationNr.Contains(term)).Select(v => v.RegistrationNr.ToList());
        //        return new JsonResult(vehicles);
        //        //          }

        //    }
        //    catch { return BadRequest(); }
        //}

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Details(string registrationNr)
        {
            Vehicle? vehicle = _context.Vehicle.Where(v => v.RegistrationNr == registrationNr).FirstOrDefault();
            if (vehicle == null)
            {
                return NotFound();
            }
            else
            {
                return PartialView("_VehicleModalPartial", vehicle);
            }
        }

        public IActionResult Privacy()
        {
            var model = _context.Vehicle.ToList();

            return View(model);
        }

        public IActionResult StatsWidget()
        {
            var statsModel = new GarageStatistics();
            var allVehicles = _context.Vehicle.ToList();

            statsModel.TotalVehicles = allVehicles.Count;
            statsModel.TotalSlots = _settings.Value.ParkingSlots;

            statsModel.TotalWheels = allVehicles.Sum(p => p.Wheels);

            var totaltime = allVehicles.Sum(v => DateTime.Now.Subtract(v.TimeOfArrival).TotalHours);
            statsModel.TotalIncome = Math.Round(totaltime * _settings.Value.PricePerHour);

            return PartialView("_StatsWidget",statsModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}