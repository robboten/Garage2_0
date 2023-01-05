using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage2_0.Models
{
    public class Vehicle
    {
        //Vissa input vill vi inte att användaren skall kunna skriva hur de vill i fritext. Inte för långa
        //namn.Inga minus värden på antal hjul osv.
        public int Id { get; set; }

        [Required]
        [Display(Name = "Time Of Arrival")]
        public DateTime TimeOfArrival { get; set; }

        [NotMapped]
        [Display(Name = "Time Parked (hours)")]
        public int HoursParked {
            get{ return (int)DateTime.Now.Subtract(TimeOfArrival).TotalHours; }
        }

        [Required]
        [Display(Name = "Registration Number")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "{0} length must be between {2} and {1} characters.")]
        public string RegistrationNr { get; set; } = string.Empty;

        [Display(Name = "Vehicle Type")]
        public VehicleType VehicleType { get; set; }

        public Color Color { get; set; }

        public Brand Brand { get; set; } 

        //public int BrandDbId { get; set; }

        public BrandDb? BrandDb { get; set; } 

        [Range(0,16, ErrorMessage = "{0} length must be between {1} and {2}.")]
        public int Wheels { get; set; }

        //public int TypeDbId { get; set; }
        public TypeDb? TypeDb { get; set; } 


        [StringLength(10, MinimumLength = 0, ErrorMessage = "{0} length must be between {2} and {1} characters.")]
        public string? Model { get; set; }
    }
}