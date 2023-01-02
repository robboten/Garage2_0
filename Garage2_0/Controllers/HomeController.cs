using Garage2_0.Data;
using Garage2_0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.IO.Pipelines;

namespace Garage2_0.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<MySettings> _settings;
        
        //Constructor 
        //public HomeController(IOptions<MySettings> settings)
        //{
        //    _settings = settings.Value;
        //    // _settings.StringSetting == "My Value";
        //}

        private readonly ILogger<HomeController> _logger;
        private readonly GarageContext _context;
        public HomeController(GarageContext context, ILogger<HomeController> logger, IOptions<MySettings> settings)
        {
            _logger = logger;
            _settings = settings;
            _context = context;
        }

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}