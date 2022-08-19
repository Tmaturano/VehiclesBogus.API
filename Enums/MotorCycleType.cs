using System.ComponentModel;

namespace VehiclesBogus.API.Enums
{
    public enum MotorCycleType
    {
        [Description("Scooter")]
        Scooter,
        [Description("Cross")]
        Cross,
        [Description("Sportbike")]
        Sportbike,
        [Description("Classic")]
        Classic,
        [Description("Chopper")]
        Chopper,
        [Description("Touring")]
        Touring,
        [Description("Scrambler")]
        Scrambler
    }
}
