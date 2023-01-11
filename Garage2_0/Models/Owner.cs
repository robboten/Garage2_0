using System.Text.Json.Serialization;

namespace Garage2_0.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FullName { get { return FirstName + " " + LastName; }  } 
        [JsonIgnore]
        public ICollection<Vehicle>? Vehicle { get; set; }
    }
}
