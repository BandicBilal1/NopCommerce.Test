using NopCommerce.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NopCommerce.UI.Frame.Extensions;
public static class SeleniumExtensions
{
    public static void WaitForPageToLoad(this IWebDriver browser, int timeout = 10)
    {
        IWait<IWebDriver> wait = new WebDriverWait(browser, TimeSpan.FromSeconds(timeout));
        wait.Until(driver1 => ((IJavaScriptExecutor)browser).ExecuteScript("return document.readyState;").Equals("complete"));
    }
}
