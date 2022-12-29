using Garage2_0.Data;
using Microsoft.Extensions.Options;

namespace Garage2_0.Models
{
    public class GarageStatistics
    {
        //how to get settings in here?

        public int TotalWheels { get; set; }
        public int TotalVehicles { get; set; }
        public double TotalIncome { get; set; }

        public int TotalSlots { get; set; }

        public int AvailableSlots { get; set; }
        public GarageStatistics() { }


        //add number of each vehicle


    }
}
