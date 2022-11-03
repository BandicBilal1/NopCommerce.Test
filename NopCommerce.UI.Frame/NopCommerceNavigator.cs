using NopCommerce.Core.Interfaces;
using Pages;

namespace NopCommerce.UI.Frame;
public class NopCommerceNavigator : BasePage, INavigator
{
    public NopCommerceNavigator(IExecutionTool executionTool) : base(executionTool)
    {

    }

    public HomePage GoToHomePage()
    {
        ExecutionTool.GoTo(StaticUrls.HomePageUrl);
        return new HomePage(ExecutionTool);
    }
}
