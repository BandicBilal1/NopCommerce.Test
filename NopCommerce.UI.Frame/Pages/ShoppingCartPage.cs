using FluentAssertions;
using NopCommerce.Core;
using NopCommerce.Core.Elements;
using NopCommerce.UI.Frame.Extensions;
using OpenQA.Selenium;

namespace NopCommerce.UI.Frame.Pages;
public class ShoppingCartPage : BasePage
{
    #region Properties

    private CheckoutPage CheckoutPage = new CheckoutPage(WebExecutionTool);
    private Button CheckoutButton => new(By.Id("checkout"));
    private Label ShoppingCartPageTitle => new(By.XPath("//h1[text()='Shopping cart']"));
    private CheckBox TermsAndServicesBox => new(By.Id("termsofservice"));

    #endregion

    #region Constructors

    public ShoppingCartPage(WebExecutionTool executionTool) : base(executionTool)
    {
    }

    #endregion

    #region General

    internal ShoppingCartPage WaitForPage()
    {
        WebExecutionTool.GetWebExecutionTool().WaitForPageToLoad();

        return new ShoppingCartPage(Browser);
    }

    #endregion

    #region Actions

    public CheckoutPage CheckoutTheCart()
    {
        TermsAndServicesBox.Click();
        CheckoutButton.Click();

        CheckoutPage.VerifyCheckoutPageIsDisplayed();

        return new CheckoutPage(Browser).WaitForPage();
    }

    #endregion

    #region Verifications

    public ShoppingCartPage VerifyShoppingCartPageIsDisplayed()
    {
        ShoppingCartPageTitle.Exists(5).Should().BeTrue();

        return new ShoppingCartPage(Browser).WaitForPage();
    }

    #endregion
}
