using VehiclesBogus.API.Enums;

namespace VehiclesBogus.API.Models
{
    public class Car : Vehicle 
    {
        public Transmission Transmission { get; init; }
        public CarType CarType { get; init; }        
    }
}
