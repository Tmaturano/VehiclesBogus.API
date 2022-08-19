using System.ComponentModel;

namespace VehiclesBogus.API.Enums
{
    public enum CarType
    {
        [Description("Micro")]
        Micro,
        [Description("Sedan")]
        Sedan,
        [Description("Hatchback")]
        Hatchback,
        [Description("Coupe")]
        Coupe,
        [Description("Muscle")]
        Muscle,
        [Description("Sport")]
        Sport,
        [Description("SUV")]
        SUV,
        [Description("Crossover")]
        Crossover,
        [Description("Pickup")]
        Pickup,
        [Description("Van")]
        Van
    }
}
