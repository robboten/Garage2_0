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

        [Display(Name = "Vehicle Type")]
        public VehicleType VehicleType { get; set; }

        [Range(0,16, ErrorMessage = "{0} length must be between {1} and {2}.")]
        public int Wheels { get; set; }

        [Required]
        [Display(Name = "Registration Number")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "{0} length must be between {2} and {1} characters.")]
        public string RegistrationNr { get; set; } = string.Empty;

        [StringLength(10, MinimumLength = 0, ErrorMessage = "{0} length must be between {2} and {1} characters.")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Time Of Arrival")]
        public DateTime TimeOfArrival { get; set; }
    }
}