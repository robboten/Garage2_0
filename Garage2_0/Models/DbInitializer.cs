using Garage2_0.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NuGet.Configuration;
using System.Numerics;

namespace Garage2_0.Models
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            GarageContext garageContext= applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<GarageContext>();

            garageContext.Database.EnsureCreated();

            if(!garageContext.Vehicle.Any())
            {

            }

            garageContext.SaveChanges();
        }
        public static void Seeder(string jsonData, IApplicationBuilder applicationBuilder)
        {
            GarageContext garageContext = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<GarageContext>();

            garageContext.Database.EnsureCreated();

            List<Vehicle>? vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(jsonData, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" });

            Console.WriteLine("test");
            Console.WriteLine(vehicles);

            if (!garageContext.Vehicle.Any())
            {
                garageContext.AddRange(vehicles);
            }

            garageContext.SaveChanges();
        }
    }
}
