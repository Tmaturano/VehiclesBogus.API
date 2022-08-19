using VehiclesBogus.API.Models;

namespace VehiclesBogus.API.DTOs
{
    public class MotorCycleDto : Vehicle
    {
        public int CubicCentimeters { get; init; }
        public string MotorCycleType { get; init; }
    }
}
