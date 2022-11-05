using FluentAssertions;
using NopCommerce.Core;
using NopCommerce.Core.Elements;
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

    #region Actions

    /// <summary>
    /// Navigate user to the Register page
    /// </summary>
    /// <returns></returns>
    public RegisterPage NavigateToTheRegisterPage()
    {
        RegisterLink.Click();

        return new RegisterPage(Browser);
    }

    /// <summary>
    /// Navigate user to the Gift cards page
    /// </summary>
    /// <returns></returns>
    public GiftCardsPage NavigateToTheGiftCardsPage()
    {
        GiftCardsLink.Click();

        return new GiftCardsPage(Browser);
    }

    #endregion

    #region Verifications


    #endregion

}
