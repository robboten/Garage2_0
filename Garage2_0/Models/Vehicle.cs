using System;

namespace Garage2_0.Models
{
    public class Vehicle
    {
        //Vissa input vill vi inte att användaren skall kunna skriva hur de vill i fritext. Inte för långa
        //namn.Inga minus värden på antal hjul osv.
        public int Id { get; set; }
        public Color Color { get; set; }
        public Brand Brand { get; set; } //
        public VehicleType VehicleType { get; set; } //buss bil cykel osv?
        public int Wheels { get; set; }
        public string RegistrationNr { get; set; } = string.Empty;
        public string Model { get; set; }
        DateTime TimeOfArrival { get; set; }
    }
}