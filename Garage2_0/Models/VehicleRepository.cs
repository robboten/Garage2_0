using Garage2_0.Data;

namespace Garage2_0.Models
{
    public class VehicleRepository : IVehicleRepository
    {
        public readonly GarageContext garageContext;

        public VehicleRepository(GarageContext garageContext)
        {
            this.garageContext = garageContext; 
        }

        public IEnumerable<Vehicle> AllVehicles { get { return garageContext.Vehicle; } }

        public Vehicle? GetVehicleByRegNr(string regNr) => garageContext.Vehicle.FirstOrDefault(p => p.RegistrationNr == regNr);

        public DateTime GetCheckoutPrice(string regNr) => garageContext.Vehicle.FirstOrDefault(p => p.RegistrationNr == regNr).TimeOfArrival;

    }
 
}
