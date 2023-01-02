using System.ComponentModel.DataAnnotations;

namespace Garage2_0.Models
{
    public class ReceiptViewModel
    {
        [Display(Name = "Registration number")]
        public string RegNr { get; set; }
        [Display(Name = "Time of arrival")]
        public DateTime TimeOfArrival { get; set; }
        [Display(Name = "Time of departure")]
        public DateTime TimeOfDeparture { get
            {
                return DateTime.Now;
            } }
        [Display(Name = "Total time (hours)")]
        public double TotalTime { get; set; }
        //public double TotalTime { get
        //    {
        //        return (int)TotalTime;
        //    }
        //    set { TotalTime = value; }
        //}
        [Display(Name = "Price (kr)")]
        public double Price { get; set; }

    }
}
