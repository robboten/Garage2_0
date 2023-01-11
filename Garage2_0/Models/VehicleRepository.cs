using Garage2_0.Data;
using Microsoft.EntityFrameworkCore;
using System.IO.Pipelines;

namespace Garage2_0.Models
{
    public class VehicleRepository : IVehicleRepository
    {
        public readonly GarageContext garageContext;

        public VehicleRepository(GarageContext garageContext)
        {
            this.garageContext = garageContext;
        }
        public IEnumerable<Vehicle> AllVehicles
        {
            get
            {
                return garageContext.Vehicle
                    .Include(v => v.Owner)
                    .Include(v => v.BrandDb)
                    .Include(v => v.TypeDb)
                    .ToList();
            }
        }

        public Vehicle? GetVehicleByRegNr(string regNr) => garageContext.Vehicle
            .Include(v => v.Owner)
            .Include(v => v.BrandDb)
            .Include(v => v.TypeDb)
            .FirstOrDefault(p => p.RegistrationNr == regNr);

        public DateTime GetCheckoutPrice(string regNr) => garageContext.Vehicle
            .Include(v => v.Owner)
            .Include(v => v.BrandDb)
            .Include(v => v.TypeDb)
            .FirstOrDefault(p => p.RegistrationNr == regNr).TimeOfArrival;

        public IEnumerable<Vehicle> SearchVehicles(string searchQuery)
        {
            return garageContext.Vehicle
                .Include(v => v.Owner)
                .Include(v => v.BrandDb)
                .Include(v => v.TypeDb)
                .Where(v => v.RegistrationNr.Contains(searchQuery))
                ;
        }
    }

}
