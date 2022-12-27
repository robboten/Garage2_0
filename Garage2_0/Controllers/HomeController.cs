using Garage2_0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

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

        public HomeController(ILogger<HomeController> logger, IOptions<MySettings> settings)
        {
            _logger = logger;
            _settings = settings;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}