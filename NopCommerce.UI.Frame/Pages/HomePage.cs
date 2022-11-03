using NopCommerce.Core.Elements;
using NopCommerce.Core.Interfaces;
using NopCommerce.UI.Frame;
using NopCommerce.UI.Frame.Pages;
using OpenQA.Selenium;

namespace Pages;
public class HomePage : BasePage
{
    #region Properties
    private IButton RegisterButton => new Button(By.XPath("//a[text()='Register']"));
    #endregion

    #region Constructors
    public HomePage(IExecutionTool executionTool) : base(executionTool)
    {

    }
    #endregion

    #region Actions

    public RegisterPage NavigateToTheRegisterPage()
    {
        RegisterButton.Click();
        return new RegisterPage(ExecutionTool);
    }

    #endregion

}
