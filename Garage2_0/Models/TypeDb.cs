using Bogus.DataSets;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Garage2_0.Models
{
    public class TypeDb
    {
        public int TypeDbId { get; set; }
        [Display(Name = "Type")]
        public string Name { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
