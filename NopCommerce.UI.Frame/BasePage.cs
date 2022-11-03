using NopCommerce.Core.Interfaces;

namespace NopCommerce.UI.Frame;
public class BasePage
{
    protected int DefaultExplicitWait = 30;
    protected readonly IExecutionTool ExecutionTool;

    public  BasePage(IExecutionTool executionTool)
    {
        this.ExecutionTool = executionTool;
        Thread.Sleep(5000);
        executionTool.WaitForApplicationIdle();
    }
}
