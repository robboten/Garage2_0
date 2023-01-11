using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Garage2_0.Data;
using Garage2_0.Models;
using System.Configuration;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<GarageContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GarageContext") ?? throw new InvalidOperationException("Connection string 'GarageContext' not found.")));

builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews()
     .AddJsonOptions(options =>
     {
         options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
     });

//Bind a settings class to the configuration
builder.Services.Configure<MySettings>(options => builder.Configuration.GetSection("MySettings").Bind(options));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<GarageContext>();

    db.Database.EnsureDeleted();
    db.Database.Migrate();

    try
    {
        await SeedData.InitAsync(db);
    }
    catch (Exception e)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(string.Join(" ", e.Message));
        //throw
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//var dataText = System.IO.File.ReadAllText(@"Data/SeedData.json");
//DbInitializer.Seeder(dataText, app);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Vehicles}/{action=Index}/{id?}");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();



//Hello :)