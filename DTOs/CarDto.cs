using VehiclesBogus.API.Models;

namespace VehiclesBogus.API.DTOs
{
    public class CarDto : Vehicle
    {
        public string Transmission { get; init; }
        public string CarType { get; init; }
    }
}
