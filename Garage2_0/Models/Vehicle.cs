using System;
using System.ComponentModel.DataAnnotations;

namespace Garage2_0.Models
{
    public class Vehicle
    {
        //Vissa input vill vi inte att användaren skall kunna skriva hur de vill i fritext. Inte för långa
        //namn.Inga minus värden på antal hjul osv.
        public int Id { get; set; }

        [MaxLength(10)]
        [MinLength(0)]
        public Color Color { get; set; }

        [MaxLength(10)]
        [MinLength(0)]
        public Brand Brand { get; set; } //

        public VehicleType VehicleType { get; set; } //buss bil cykel osv?

        [Range(0,6)]
        public int Wheels { get; set; }

        [MaxLength(8)]
        [MinLength(0)]
        public string RegistrationNr { get; set; } = string.Empty;

        [MaxLength(10)]
        [MinLength(0)]
        public string Model { get; set; }
        DateTime TimeOfArrival { get; set; }
    }
}