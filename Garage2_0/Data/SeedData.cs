using Microsoft.EntityFrameworkCore;
using Bogus;
using Bogus.DataSets;
using Garage2_0.Models;

namespace Garage2_0.Data
{
    public class SeedData
    {
        private static List<Owner> owners = new();
        private static List<TypeDb> vehicleTypes = new();
        private static List<BrandDb> brands = new();

        public static async Task InitAsync(GarageContext db)
        {
            if (await db.Vehicle.AnyAsync()) return;

            vehicleTypes = GenerateVehicleTypes();
            brands = GenerateVehicleBrands();

            owners = GenerateOwners(20);

            var vehicles = GenerateVehicles2(25);

            await db.AddRangeAsync(vehicleTypes);
            await db.AddRangeAsync(brands);
            await db.AddRangeAsync(owners);
            await db.AddRangeAsync(vehicles);
            await db.SaveChangesAsync();
        }

        private static List<TypeDb> GenerateVehicleTypes()
        {
            var list = new List<TypeDb>
            {
                new TypeDb{ Name = "Car"},
                new TypeDb{ Name = "Motorcycle"},
                new TypeDb{ Name = "Bus"},
                new TypeDb{ Name = "Bicycle"},
            };

            return list;
        }

        private static List<Owner> GenerateOwners(int amount)
        {
            var faker = new Faker<Owner>("sv")
                .UseSeed(1020)
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName());

            var owners = faker.Generate(amount);

            return owners;
        }

        private static List<BrandDb> GenerateVehicleBrands()
        {
            var faker = new Faker<BrandDb>()
                .UseSeed(1020)
                .RuleFor(u => u.Name, f => f.Vehicle.Manufacturer());

            var brands = faker.Generate(10)
                .GroupBy(b => b.Name)
                .Select(b => b.First());

            return brands.ToList();
        }

        private static IEnumerable<Models.Vehicle> GenerateVehicles2(int nrOfVehicles)
        {
            var rnd = new Random();

            var faker = new Faker<Models.Vehicle>()
                .StrictMode(false)
                .UseSeed(3040)
                .RuleFor(v => v.Model, f => f.Vehicle.Model())
                .RuleFor(v => v.TimeOfArrival, f => f.Date.Recent())
                .RuleFor(v => v.Wheels, f => 4)
                .RuleFor(v => v.Color, f => (Color)f.Random.Number(0, 6))
                .RuleFor(v => v.TypeDb, f => f.PickRandom(vehicleTypes))
                .RuleFor(v => v.RegistrationNr, f => f.Random.Replace("???###"))
                .RuleFor(v => v.BrandDb, f => brands[rnd.Next(0, brands.Count)])
                .RuleFor(v => v.Owner, f => f.PickRandom(owners, f.Random.Number(1, 3)).ToList())
                ;

            var fakes = faker.Generate(nrOfVehicles);

            return fakes;
        }
    }
}
