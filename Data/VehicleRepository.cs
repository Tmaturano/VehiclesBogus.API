using Bogus;
using Bogus.Extensions.Canada;
using VehiclesBogus.API.DTOs;
using VehiclesBogus.API.Enums;
using VehiclesBogus.API.Extensions;
using VehiclesBogus.API.Models;

namespace VehiclesBogus.API.Data
{
    public interface IVehicleRepository
    {
        public List<CarDto> GetCars();
        public List<MotorCycleDto> GetMotorCycles();
        public List<TruckDto> GetTrucks();
    }

    public class VehicleRepository : IVehicleRepository
    {
        private readonly ILogger<IVehicleRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _language;
        private readonly int _vehicleNumbers;

        public VehicleRepository(
            ILogger<IVehicleRepository> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _vehicleNumbers = Convert.ToInt32(_configuration["vehicleNumbers"]);
            _language = _configuration["lang"];
        }      

        public List<CarDto> GetCars()
        {           
            _logger.LogInformation($"Generating {_vehicleNumbers} vehicle(s) data...");

            var owners = new Faker<Owner>(_language).StrictMode(true)
                .RuleFor(p => p.Name, f => f.Person.FullName)
                .RuleFor(p => p.Sin, f => f.Person.Sin())
                .RuleFor(c => c.Email, (f, c) => f.Person.Email);

            return new Faker<CarDto>(_language).StrictMode(true)
                .RuleFor(p => p.Model, f => f.Vehicle.Model())
                .RuleFor(p => p.Manufacturer, f => f.Vehicle.Manufacturer())
                .RuleFor(p => p.HorsePower, f => f.Random.Int(80, 1000))
                .RuleFor(p => p.CarType, f => f.PickRandom<CarType>().GetEnumDescription())
                .RuleFor(p => p.Color, f => f.Commerce.Color())
                .RuleFor(p => p.Transmission, f => f.PickRandom<Transmission>().GetEnumDescription())
                .RuleFor(p => p.VehicleType, VehicleType.Car)
                .RuleFor(p => p.Weight, f => f.Vehicle.Random.Decimal(700, 2000))
                .RuleFor(p => p.Year, f => f.Date.Past().Year)
                .RuleFor(p => p.Owner, f => owners.Generate())
                .Generate(_vehicleNumbers);
        }

        public List<MotorCycleDto> GetMotorCycles()
        {
            var _vehicleNumbers = Convert.ToInt32(_configuration["vehicleNumbers"]);
            var _language = _configuration["lang"];
            _logger.LogInformation($"Generating {_vehicleNumbers} vehicle(s) data...");

            var owners = new Faker<Owner>(_language).StrictMode(true)
                .RuleFor(p => p.Name, f => f.Person.FullName)
                .RuleFor(p => p.Sin, f => f.Person.Sin())
                .RuleFor(c => c.Email, (f, c) => f.Person.Email);

            return new Faker<MotorCycleDto>(_language).StrictMode(true)
                .RuleFor(p => p.Model, f => f.Vehicle.Model())
                .RuleFor(p => p.Manufacturer, f => f.Vehicle.Manufacturer())
                .RuleFor(p => p.HorsePower, f => f.Random.Int(100, 500))
                .RuleFor(p => p.MotorCycleType, f => f.PickRandom<MotorCycleType>().GetEnumDescription())
                .RuleFor(p => p.Color, f => f.Commerce.Color())
                .RuleFor(p => p.VehicleType, VehicleType.Motorcycle)
                .RuleFor(p => p.Weight, f => f.Vehicle.Random.Decimal(100, 700))
                .RuleFor(p => p.Year, f => f.Date.Past().Year)
                .RuleFor(p => p.CubicCentimeters, f => f.Random.Int())
                .RuleFor(p => p.Owner, f => owners.Generate())
                .Generate(_vehicleNumbers);
        }

        public List<TruckDto> GetTrucks()
        {
            var _vehicleNumbers = Convert.ToInt32(_configuration["vehicleNumbers"]);
            var _language = _configuration["lang"];
            _logger.LogInformation($"Generating {_vehicleNumbers} vehicle(s) data...");

            var owners = new Faker<Owner>(_language).StrictMode(true)
                .RuleFor(p => p.Name, f => f.Person.FullName)
                .RuleFor(p => p.Sin, f => f.Person.Sin())
                .RuleFor(c => c.Email, (f, c) => f.Person.Email);

            return new Faker<TruckDto>(_language).StrictMode(true)
                .RuleFor(p => p.Model, f => f.Vehicle.Model())
                .RuleFor(p => p.Manufacturer, f => f.Vehicle.Manufacturer())
                .RuleFor(p => p.HorsePower, f => f.Random.Int(100, 500))
                .RuleFor(p => p.TruckType, f => f.PickRandom<TruckType>().GetEnumDescription())
                .RuleFor(p => p.Color, f => f.Commerce.Color())
                .RuleFor(p => p.VehicleType, VehicleType.Truck)
                .RuleFor(p => p.Weight, f => f.Vehicle.Random.Decimal(1000, 4000))
                .RuleFor(p => p.Year, f => f.Date.Past().Year)
                .RuleFor(p => p.Axles, f => f.Random.Int())
                .RuleFor(p => p.Owner, f => owners.Generate())
                .Generate(_vehicleNumbers);
        }
    }
}
