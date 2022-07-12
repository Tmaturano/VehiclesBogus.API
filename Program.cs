using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using VehiclesBogus.API.Data;
using VehiclesBogus.API.Enums;
using VehiclesBogus.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Vehicles API",
            Description = "Query for vehicles using .NET 6 + Bogus + Minimal APIs",
            Version = "v1",
            Contact = new OpenApiContact()
            {
                Name = "Thiago Maturana",
                Url = new Uri("https://github.com/tmaturano"),
            },
            License = new OpenApiLicense()
            {
                Name = "MIT",
                Url = new Uri("http://opensource.org/licenses/MIT"),
            }
        });
});

builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "VehiclesBogusAPI v1");
    });
}

app.UseHttpsRedirection();

app.MapGet("/vehicle/{type}", [AllowAnonymous] (int type, IVehicleRepository repository) =>
{
    if (!Enum.IsDefined(typeof(VehicleType), type))
        return Results.BadRequest("Vehicle type is invalid");

    var vehicleType = (VehicleType)type;
    return Results.Ok(vehicleType switch
    {
        VehicleType.Car => new List<dynamic>(repository.GetCars()),
        VehicleType.Motorcycle => new List<dynamic>(repository.GetMotorCycles()),
        VehicleType.Truck => new List<dynamic>(repository.GetTrucks()),
        _ => new List<dynamic>(),
    });

}).Produces<IEnumerable<dynamic>>(StatusCodes.Status200OK)
  .Produces<IEnumerable<dynamic>>(StatusCodes.Status404NotFound)
  .WithName("GetVehiclesByType")
  .WithTags("Vehicle");

app.Run();