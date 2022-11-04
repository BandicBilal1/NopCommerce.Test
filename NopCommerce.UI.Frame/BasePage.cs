using NopCommerce.Core;
using NopCommerce.Core.Interfaces;

namespace NopCommerce.UI.Frame;
public class BasePage
{
    protected int DefaultExplicitWait = 30;
    protected readonly WebExecutionTool Browser;
    protected static WebExecutionTool WebExecutionTool => WebExecutionTool.Instance;

    public  BasePage(WebExecutionTool executionTool)
    {
        this.Browser = executionTool;
        Thread.Sleep(1000);
        executionTool.WaitForApplicationIdle();
    }
}
