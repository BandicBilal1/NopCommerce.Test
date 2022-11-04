using FluentAssertions;
using NopCommerce.Core;
using NopCommerce.Core.Elements;
using NopCommerce.UI.Frame.Extensions;
using OpenQA.Selenium;

namespace NopCommerce.UI.Frame.Pages;
public class WishListPage : BasePage
{
    #region Properties

    private ShoppingCartPage ShoppingCartPage = new ShoppingCartPage(WebExecutionTool);
    private Label WishListPageTitle => new(By.XPath("//h1[text()='Wishlist']"));
    private Field QuantityField => new(By.CssSelector("input[class='qty-input']"));
    private CheckBox AddToCartBox => new(By.Name("addtocart"));
    private Button AddToCartButton => new(By.Name("addtocartbutton"));

    #endregion

    #region Constructors

    public WishListPage(WebExecutionTool executionTool) : base(executionTool)
    {
    }

    #endregion

    #region General

    internal WishListPage WaitForPage()
    {
        WebExecutionTool.GetWebExecutionTool().WaitForPageToLoad();

        return new WishListPage(Browser);
    }

    #endregion

    #region Actions

    public WishListPage UpdateProductQuantityFor(string value)
    {
        QuantityField.ClearValue();
        QuantityField.Write(value);

        return new WishListPage(Browser).WaitForPage();
    }

    public ShoppingCartPage AddProductToTheCart()
    {
        AddToCartBox.Click();
        AddToCartButton.Click();

        ShoppingCartPage.VerifyShoppingCartPageIsDisplayed();

        return new ShoppingCartPage(Browser).WaitForPage();
    }

    #endregion

    #region Verifications

    public WishListPage VerifyWishListPageIsDisplayed()
    {
        WishListPageTitle.Exists(5).Should().BeTrue();

        return new WishListPage(Browser).WaitForPage();
    }

    #endregion
}
