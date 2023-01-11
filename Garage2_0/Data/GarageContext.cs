using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage2_0.Models;

namespace Garage2_0.Data
{
    public class GarageContext : DbContext
    {
        public GarageContext (DbContextOptions<GarageContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicle { get; set; } = default!;

        public DbSet<Owner> Owner { get; set; } = default!;

       // protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
           // base.OnModelCreating(modelBuilder);
            //await SeedData.InitAsync(db);
            //Seeder.Init();

            //modelBuilder.Entity<Owner>().HasData(Seeder.Owners);

            //modelBuilder
                //.Entity<TypeDb>()
                //.HasData(Seeder.Types);

            //modelBuilder
            //    .UsingEntity(j=>j
            //    .ToTable("BrandDb")
            //    .Entity<BrandDb>()
            //    .HasData(Seeder.Brands));

            //modelBuilder.Entity<Vehicle>().HasData(Seeder.Vehicles);

            //modelBuilder.Entity<Vehicle>()
            //    .HasMany(v => v.Owner)
            //    .WithMany(v => v.Vehicle);
        //}

        //public DbSet<GarageSettings> GarageSettings { get; set; } = default!;
    }
}
