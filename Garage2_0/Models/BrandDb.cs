using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Garage2_0.Models
{
    public class BrandDb
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Brand")]
        public string Name { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<Vehicle>? Vehicles { get; set; }
    }
}
