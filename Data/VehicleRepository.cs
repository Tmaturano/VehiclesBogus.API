using Bogus;
using VehiclesBogus.API.Enums;
using VehiclesBogus.API.Models;
using Bogus.Extensions.Canada;

namespace VehiclesBogus.API.Data
{
    public interface IVehicleRepository
    {
        public List<Car> GetCars();
        public List<MotorCycle> GetMotorCycles();
        public List<Truck> GetTrucks();
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

        //public List<Vehicle> GetAll(VehicleType vehicleType)
        //{
        //    return vehicleType switch
        //    {
        //        VehicleType.Car => new List<Vehicle>(GetCars()),
        //        VehicleType.Motorcycle => new List<Vehicle>(GetMotorCycles()),
        //        VehicleType.Truck => new List<Vehicle>(GetTrucks()),
        //        _ => new List<Vehicle>(),
        //    };
        //}

        public List<Car> GetCars()
        {           
            _logger.LogInformation($"Generating {_vehicleNumbers} vehicle(s) data...");

            var owners = new Faker<Owner>(_language).StrictMode(true)
                .RuleFor(p => p.Name, f => f.Person.FullName)
                .RuleFor(p => p.Sin, f => f.Person.Sin())
                .RuleFor(c => c.Email, (f, c) => f.Person.Email);

            return new Faker<Car>(_language).StrictMode(true)
                .RuleFor(p => p.Model, f => f.Vehicle.Model())
                .RuleFor(p => p.Manufacturer, f => f.Vehicle.Manufacturer())
                .RuleFor(p => p.HorsePower, f => f.Random.Int())
                .RuleFor(p => p.CarType, f => f.PickRandom<CarType>())
                .RuleFor(p => p.Color, f => f.Commerce.Color())
                .RuleFor(p => p.Transmission, f => f.PickRandom<Transmission>())
                .RuleFor(p => p.VehicleType, VehicleType.Car)
                .RuleFor(p => p.Weight, f => f.Vehicle.Random.Decimal())
                .RuleFor(p => p.Year, f => f.Date.Past().Year)
                .RuleFor(p => p.Owner, f => owners.Generate())
                .Generate(_vehicleNumbers);
        }

        public List<MotorCycle> GetMotorCycles()
        {
            var _vehicleNumbers = Convert.ToInt32(_configuration["vehicleNumbers"]);
            var _language = _configuration["lang"];
            _logger.LogInformation($"Generating {_vehicleNumbers} vehicle(s) data...");

            var owners = new Faker<Owner>(_language).StrictMode(true)
                .RuleFor(p => p.Name, f => f.Person.FullName)
                .RuleFor(p => p.Sin, f => f.Person.Sin())
                .RuleFor(c => c.Email, (f, c) => f.Person.Email);

            return new Faker<MotorCycle>(_language).StrictMode(true)
                .RuleFor(p => p.Model, f => f.Vehicle.Model())
                .RuleFor(p => p.Manufacturer, f => f.Vehicle.Manufacturer())
                .RuleFor(p => p.HorsePower, f => f.Random.Int())
                .RuleFor(p => p.MotorCycleType, f => f.PickRandom<MotorCycleType>())
                .RuleFor(p => p.Color, f => f.Commerce.Color())
                .RuleFor(p => p.VehicleType, VehicleType.Motorcycle)
                .RuleFor(p => p.Weight, f => f.Vehicle.Random.Decimal())
                .RuleFor(p => p.Year, f => f.Date.Past().Year)
                .RuleFor(p => p.CubicCentimeters, f => f.Random.Int())
                .RuleFor(p => p.Owner, f => owners.Generate())
                .Generate(_vehicleNumbers);
        }

        public List<Truck> GetTrucks()
        {
            var _vehicleNumbers = Convert.ToInt32(_configuration["vehicleNumbers"]);
            var _language = _configuration["lang"];
            _logger.LogInformation($"Generating {_vehicleNumbers} vehicle(s) data...");

            var owners = new Faker<Owner>(_language).StrictMode(true)
                .RuleFor(p => p.Name, f => f.Person.FullName)
                .RuleFor(p => p.Sin, f => f.Person.Sin())
                .RuleFor(c => c.Email, (f, c) => f.Person.Email);

            return new Faker<Truck>(_language).StrictMode(true)
                .RuleFor(p => p.Model, f => f.Vehicle.Model())
                .RuleFor(p => p.Manufacturer, f => f.Vehicle.Manufacturer())
                .RuleFor(p => p.HorsePower, f => f.Random.Int())
                .RuleFor(p => p.TruckType, f => f.PickRandom<TruckType>())
                .RuleFor(p => p.Color, f => f.Commerce.Color())
                .RuleFor(p => p.VehicleType, VehicleType.Truck)
                .RuleFor(p => p.Weight, f => f.Vehicle.Random.Decimal())
                .RuleFor(p => p.Year, f => f.Date.Past().Year)
                .RuleFor(p => p.Axles, f => f.Random.Int())
                .RuleFor(p => p.Owner, f => owners.Generate())
                .Generate(_vehicleNumbers);
        }
    }
}
