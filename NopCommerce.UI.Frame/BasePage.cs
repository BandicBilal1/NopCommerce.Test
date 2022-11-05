using NopCommerce.Core;
using NopCommerce.Core.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NopCommerce.UI.Frame;
public class BasePage
{
    protected int DefaultExplicitWait = 30;
    protected WebExecutionTool Browser;

    public  BasePage(WebExecutionTool executionTool)
    {
        this.Browser = executionTool;
        //this.WaitForPage();
        Thread.Sleep(2000);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private void WaitForPage()
    {
        IWait<IWebDriver> wait = new WebDriverWait(Browser.GetWebExecutionTool(), TimeSpan.FromSeconds(10));
        wait.Until(driver1 => ((IJavaScriptExecutor)Browser.GetWebExecutionTool()).ExecuteScript("return document.readyState;").Equals("complete"));
    }
}
