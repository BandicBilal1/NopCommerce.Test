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
        
    }

    #endregion

    #region Actions

    /// <summary>
    /// Checkouts the cart by accepting Terms and Services and clicking checkout button
    /// </summary>
    /// <returns></returns>
    public CheckoutPage CheckoutTheCart()
    {
        VerifyUpdatedValueForProductQuantityIs("3");

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

    /// <summary>
    /// Verifies value for quantity is the same as the one updated in wish list page
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private ShoppingCartPage VerifyUpdatedValueForProductQuantityIs(string value)
    {
        var quantityField = WebExecutionTool.FindElement(Browser.GetWebExecutionTool(), By.CssSelector("input[class='qty-input']"), 5000);
        quantityField.GetAttribute("value").Should().BeEquivalentTo(value);

        return new ShoppingCartPage(Browser);
    }

    #endregion
}
