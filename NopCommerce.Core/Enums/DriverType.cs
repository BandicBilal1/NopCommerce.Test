using NopCommerce.Core.CustomAttributes;

namespace NopCommerce.Core.Enums;
public enum DriverType
{
    [Text("Chrome")]
    Chrome,
    [Text("Firefox")]
    Firefox,
    [Text("InternetExplorer")]
    InternetExplorer,
    [Text("Edge")]
    Edge
}
