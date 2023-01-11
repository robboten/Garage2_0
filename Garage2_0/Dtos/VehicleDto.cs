using Bogus.DataSets;
using Garage2_0.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Garage2_0.Dtos
{
    public class VehicleDto
    {
        [Display(Name = "Registration Number")]
        public string RegistrationNr { get; set; } = string.Empty;

        [Display(Name = "Time Of Arrival")]
        public DateTime TimeOfArrival { get; set; }

        public Color Color { get; set; }

        public int Wheels { get; set; }

        public TypeDb? TypeDb { get; set; }

       // public string TypeName { get { return TypeDb.Name; }  } 

        public string? Model { get; set; }
    }
}
