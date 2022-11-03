using NopCommerce.Core.Enums;

namespace NopCommerce.Core;
public static class Configuration
{
    public static readonly DriverType DriverType = DriverType.Chrome;
    public static int NumberOfThreads = 3;

    private static DriverType GetRandomDriverType()
    {
        var driverTypes = Enum.GetValues(typeof(DriverType));
        var random = new Random();

        var randomDriverType = (DriverType)(driverTypes.GetValue(random.Next(driverTypes.Length)) ?? throw new InvalidOperationException());

        return randomDriverType;
    }
}
