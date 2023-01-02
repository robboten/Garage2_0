using Garage2_0.Controllers;
using Garage2_0.Data;
using Garage2_0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Garage2_0.Components
{
    public class WidgetStats1 : ViewComponent
    {
        private readonly IOptions<MySettings> _settings;
        private readonly GarageContext _context;

        public WidgetStats1(GarageContext context, IOptions<MySettings> settings)
        {
            _settings = settings;
            _context = context;
        }
        public IViewComponentResult Invoke(string viewName = "")
        {

            var statsModel = new GarageStatistics();
            var allVehicles = _context.Vehicle.ToList();

            statsModel.TotalVehicles = allVehicles.Count;
            statsModel.TotalSlots = _settings.Value.ParkingSlots;

            statsModel.TotalWheels = allVehicles.Sum(p => p.Wheels);

            var totaltime = allVehicles.Sum(v => DateTime.Now.Subtract(v.TimeOfArrival).TotalHours);
            statsModel.TotalIncome = Math.Round(totaltime * _settings.Value.PricePerHour);

            if(!string.IsNullOrEmpty(viewName))
            {
                return View(viewName,statsModel);
            }
            return View(statsModel);
        }
    }
}
