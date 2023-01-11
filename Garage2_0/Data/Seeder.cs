using Bogus;
using Garage2_0.Models;
using System.Collections.Generic;

namespace Garage2_0.Data
{
    public static class Seeder
    {
        public static Faker<Owner> OwnerFaker = null!;
        public static Faker<Vehicle> VehicleFaker = null!;
        public static void Init()
        {
            //faker = new Faker();
            const int numToSeed = 40;

            Types = GenerateVehicleTypes();
            Brands = GenerateVehicleBrands();

            Owners = GenerateOwners(20);

            Vehicles = GenerateVehicles2(25);

            //var ownerIds = 1;
            //OwnerFaker = new Faker<Owner>()
            //   .StrictMode(false)
            //   .UseSeed(3344)
            //   .RuleFor(d => d.Id, f => ownerIds++)
            //   .RuleFor(d => d.FirstName, f => f.Name.FirstName());

            //Owners = OwnerFaker.Generate(numToSeed);

            //VehicleFaker

            //var vehicleIds = 1;
            //VehicleFaker = new Faker<Vehicle>()
            //   .StrictMode(false)
            //   .UseSeed(3344)
            //    .RuleFor(v => v.Id, f => vehicleIds++)
            //    .RuleFor(v => v.Model, f => f.Vehicle.Model())
            //    .RuleFor(v => v.TimeOfArrival, f => f.Date.Recent())
            //    .RuleFor(v => v.Wheels, f => 4)
            //    .RuleFor(v => v.Color, f => (Color)f.Random.Number(0, 6))
            //    .RuleFor(v => v.TypeDb, f => f.PickRandom(TypeDb))
            //    .RuleFor(v => v.RegistrationNr, f => f.Random.Replace("???###"))
            //    //.RuleFor(v => v.BrandDb, f => vehicleBrands[rnd.Next(0, vehicleBrands.Count)])
            //    //.RuleFor(v => v.Owner, f => owner.Generate(3).ToList())
            //    // .RuleFor(v => v.OwnerId, f => f.PickRandom(owners).Id))
            //    ;


            //Vehicles = VehicleFaker.Generate(numToSeed);
        }

        private static List<TypeDb> GenerateVehicleTypes()
        {
            var list = new List<TypeDb>
            {
                new TypeDb{ TypeDbId=1,Name = "Car"},
                new TypeDb{TypeDbId=2, Name = "Motorcycle"},
                new TypeDb{TypeDbId=3, Name = "Bus"},
                new TypeDb{TypeDbId=4, Name = "Bicycle"},
            };
            return list;
        }

        private static List<Owner> GenerateOwners(int amount)
        {
            var startId = 1;
            var faker = new Faker<Owner>()
                .RuleFor(v => v.Id, f => startId++)
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName());

            var owners = faker.Generate(amount);

            return owners;
        }

        private static List<BrandDb> GenerateVehicleBrands()
        {
            var startId = 1;
            var faker = new Faker<BrandDb>()
                .RuleFor(v => v.Id, f => startId++)
                .RuleFor(u => u.Name, f => f.Vehicle.Manufacturer());

            var brands = faker.Generate(10)
                .GroupBy(b => b.Name)
                .Select(b => b.First());

            return brands.ToList();
        }

        private static List<Models.Vehicle> GenerateVehicles2(int nrOfVehicles)
        {
            var rnd = new Random();
            var startId = 1;

            var faker = new Faker<Models.Vehicle>()
                .StrictMode(false)
                .UseSeed(3344)
                .RuleFor(v => v.Id, f => startId++)
                .RuleFor(v => v.Model, f => f.Vehicle.Model())
                .RuleFor(v => v.TimeOfArrival, f => f.Date.Recent())
                .RuleFor(v => v.Wheels, f => 4)
                .RuleFor(v => v.Color, f => (Color)f.Random.Number(0, 6))
                .RuleFor(v => v.TypeDb, f => f.PickRandom(Types))
                .RuleFor(v => v.RegistrationNr, f => f.Random.Replace("???###"))
                .RuleFor(v => v.BrandDb, f => Brands[rnd.Next(0, Brands.Count)])
                .RuleFor(v => v.Owner, f => f.PickRandom(Owners, f.Random.Number(1, 3)).ToList())
                ;

            var fakes = faker.Generate(nrOfVehicles);

            return fakes.ToList();
        }

        public static List<Owner> Owners { get; set; }
        public static List<Vehicle> Vehicles { get; set; }
        public static List<TypeDb> Types { get; set; }
        public static List<BrandDb> Brands { get; set; }

    }
}
