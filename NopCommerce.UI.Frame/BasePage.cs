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
        //Thread.Sleep(2000);
    }

}
