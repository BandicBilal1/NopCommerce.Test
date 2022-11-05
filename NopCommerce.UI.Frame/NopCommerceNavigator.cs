using NopCommerce.Core;
using NopCommerce.Core.Interfaces;
using Pages;

namespace NopCommerce.UI.Frame;
public class NopCommerceNavigator : BasePage, INavigator
{
    public NopCommerceNavigator(WebExecutionTool executionTool) : base(executionTool)
    {

    }

    /// <summary>
    /// Navigates to Home page of application
    /// </summary>
    /// <returns></returns>
    public HomePage GoToHomePage()
    {
        Browser.GoTo(StaticUrls.HomePageUrl);

        return new HomePage(Browser).WaitForPage();
    }
}
