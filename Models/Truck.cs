using VehiclesBogus.API.Enums;

namespace VehiclesBogus.API.Models
{
    public class Truck : Vehicle 
    {
        public int Axles { get; init; }
        public TruckType TruckType { get; init; }        
    }
}
