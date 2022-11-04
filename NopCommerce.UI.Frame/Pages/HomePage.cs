using FluentAssertions;
using NopCommerce.Core;
using NopCommerce.Core.Elements;
using NopCommerce.UI.Frame.Extensions;
using NopCommerce.UI.Frame;
using NopCommerce.UI.Frame.Pages;
using OpenQA.Selenium;

namespace Pages;
public class HomePage : BasePage
{
    #region Properties
    private Button RegisterLink => new (By.XPath("//a[text()='Register']"));
    private Button GiftCardsLink => new (By.XPath("//a[text()='Gift Cards ']"));

    #endregion

    #region Constructors
    public HomePage(WebExecutionTool executionTool) : base(executionTool)
    {

    }
    #endregion

    #region General

    internal HomePage WaitForPage()
    {
        WebExecutionTool.GetWebExecutionTool().WaitForPageToLoad();

        return new HomePage(Browser);
    }

    #endregion

    #region Actions

    public RegisterPage NavigateToTheRegisterPage()
    {
        RegisterLink.Click();

        return new RegisterPage(Browser).WaitForPage();
    }

    public GiftCardsPage NavigateToTheGiftCardsPage()
    {
        GiftCardsLink.Click();
        
        return new GiftCardsPage(Browser).WaitForPage();
    }

    #endregion

    #region Verifications


    #endregion

}
