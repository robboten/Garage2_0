using System;
using System.ComponentModel.DataAnnotations;

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

        [Range(0,16)]
        public int Wheels { get; set; }

        [Required]
        [MaxLength(8)]
        [MinLength(0)]
        public string RegistrationNr { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Model { get; set; }

        [Required]
        DateTime TimeOfArrival { get; set; }
    }
}