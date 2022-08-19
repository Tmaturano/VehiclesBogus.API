using VehiclesBogus.API.Models;

namespace VehiclesBogus.API.DTOs
{
    public class TruckDto : Vehicle
    {
        public int Axles { get; init; }
        public string TruckType { get; init; }
    }
}
