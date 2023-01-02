using Garage2_0.Data;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace Garage2_0.Models
{
    public class GarageStatistics
    {
        //how to get settings in here?
        [Display(Name = "Parking slots in total")]
        public int TotalSlots { get; set; }

        [Display(Name = "Number of parked vehicles")]
        public int TotalVehicles { get; set; }

        [Display(Name = "Parking slots available")]
        public int AvailableSlots { get { return TotalSlots - TotalVehicles; } }

        [Display(Name = "Generated income")]
        public double TotalIncome { get; set; }

        [Display(Name = "Sum of all wheels")]
        public int TotalWheels { get; set; }








        public GarageStatistics() { }


        //add number of each vehicle


    }
}
