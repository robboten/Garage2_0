namespace Garage2_0.Models
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> AllVehicles { get; }

        Vehicle? GetVehicleByRegNr(string regNr);
        DateTime GetCheckoutPrice(string regNr);

        IEnumerable<Vehicle> SearchVehicles(string searchQuery);
    }
}