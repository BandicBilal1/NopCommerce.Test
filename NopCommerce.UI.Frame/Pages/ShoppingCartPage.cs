using FluentAssertions;
using NopCommerce.Core;
using NopCommerce.Core.Elements;
using OpenQA.Selenium;

namespace NopCommerce.UI.Frame.Pages;
public class ShoppingCartPage : BasePage
{
    #region Properties

    private Button CheckoutButton => new(By.Id("checkout"));
    private Label ShoppingCartPageTitle => new(By.XPath("//h1[text()='Shopping cart']"));
    private CheckBox TermsAndServicesBox => new(By.Id("termsofservice"));

    #endregion

    #region Constructors

    public ShoppingCartPage(WebExecutionTool executionTool) : base(executionTool)
    {
        this.VerifyShoppingCartPageIsDisplayed();
    }

    #endregion

    #region Actions

    /// <summary>
    /// Checkouts the cart by accepting Terms and Services and clicking checkout button
    /// </summary>
    /// <returns></returns>
    public CheckoutPage CheckoutTheCart()
    {
        TermsAndServicesBox.Click();
        CheckoutButton.Click();

        return new CheckoutPage(Browser);
    }

    #endregion

    #region Verifications

    /// <summary>
    /// Verifies user is displayed with Shopping cart page
    /// </summary>
    /// <returns></returns>
    private ShoppingCartPage VerifyShoppingCartPageIsDisplayed()
    {
        ShoppingCartPageTitle.Exists(5).Should().BeTrue();

        return new ShoppingCartPage(Browser);
    }

    #endregion
}
