using Garage2_0.Data;
using Microsoft.Extensions.Options;

namespace Garage2_0.Models
{
    public class GarageStatistics
    {
        //private readonly IOptions<MySettings> settings;
        //public GarageStatistics(IOptions<MySettings> settings) {
        //    this.settings = settings;
        //}

        public int TotalWheels { get; set; }
        public int TotalVehicles { get; set; }
        public double TotalIncome { get; set; }

        //add number of each vehicle


    }
}
