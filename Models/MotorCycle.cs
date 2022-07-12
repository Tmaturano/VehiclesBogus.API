using VehiclesBogus.API.Enums;

namespace VehiclesBogus.API.Models
{
    public class MotorCycle : Vehicle 
    {
        public int CubicCentimeters { get; init; }
        public MotorCycleType MotorCycleType { get; init; }        
    }
}
