using VehiclesBogus.API.Enums;

namespace VehiclesBogus.API.Models
{
    public abstract class Vehicle
    {
        public VehicleType VehicleType { get; set; }
        public string? Model { get; init; }
        public string? Color { get; init; }
        public string? Manufacturer { get; init; }
        public int Year { get; init; } 
        public int HorsePower { get; init; }
        public decimal Weight { get; init; }
        public Owner? Owner { get; init; } 
    }
}
