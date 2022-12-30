﻿using Garage2_0.Data;
using Garage2_0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Garage2_0.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly GarageContext _context;

        private readonly IOptions<MySettings> settings;
        public VehiclesController(GarageContext context, IOptions<MySettings> settings)
        {
            _context = context;
            this.settings = settings;
        }

        // GET: PaginatedList<Vehicle>
        public async Task<IActionResult> Index(int? pageNumber)
        {
            int pageSize = 5;

            var model = _context.Vehicle;


            return View(await PaginatedList<Vehicle>.CreateAsync(model, pageNumber ?? 1, pageSize));
            // For more details about Pagination, see https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/sort-filter-page?view=aspnetcore-7.0

            //return _context.Vehicle != null ? 
            //              View(await _context.Vehicle.ToListAsync()) :
            //              Problem("Entity set 'GarageContext.Vehicle'  is null.");
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vehicle == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Color,Brand,VehicleType,Wheels,RegistrationNr,Model")] Vehicle vehicle)
        {
            vehicle.TimeOfArrival = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vehicle == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Color,Brand,VehicleType,Wheels,RegistrationNr,Model")] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vehicle == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            if (_context.Vehicle == null)
            {
                return Problem("Entity set 'GarageContext.Vehicle'  is null.");
            }
            var vehicle = await _context.Vehicle.FindAsync(id);

            var receipt = new ReceiptViewModel();
            //{
            //    RegNr = vehicle.RegistrationNr,
            //    TimeOfArrival = vehicle.TimeOfArrival,


            //};
            receipt.RegNr = vehicle.RegistrationNr;
            receipt.TimeOfArrival = vehicle.TimeOfArrival;
            var totalTime = DateTime.Now.Subtract(vehicle.TimeOfArrival).TotalHours;
            var price = totalTime * settings.Value.PricePerHour;
            receipt.TotalTime = Math.Round(totalTime);
            receipt.Price = Math.Round(price, 2);


            if (vehicle != null)
            {
                _context.Vehicle.Remove(vehicle);
            }

            await _context.SaveChangesAsync();
            return View(nameof(DeleteConfirmed), receipt);
            //return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return (_context.Vehicle?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
