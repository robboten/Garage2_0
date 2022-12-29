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

        //public DbSet<GarageSettings> GarageSettings { get; set; } = default!;
    }
}
