using FluentAssertions;
using NopCommerce.Core;
using NopCommerce.Core.Elements;
using NopCommerce.Core.Extensions;
using OpenQA.Selenium;

namespace NopCommerce.UI.Frame.Pages;
public class WishListPage : BasePage
{
    #region Properties

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

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WishListPage WaitForPage()
    {
        Extensions.WaitForPageToLoad();

        return new WishListPage(Browser);
    }

    #endregion

    #region Actions

    /// <summary>
    /// Updates quantity of  product in the cart
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public WishListPage UpdateProductQuantityFor(string value)
    {
        QuantityField.ClearValue();
        QuantityField.Write(value);

        return new WishListPage(Browser).WaitForPage();
    }

    /// <summary>
    /// Adds product to the cart
    /// </summary>
    /// <returns></returns>
    public ShoppingCartPage AddProductToTheCart()
    {
        AddToCartBox.Click();
        AddToCartButton.Click();

        return new ShoppingCartPage(Browser).WaitForPage();
    }

    #endregion

    #region Verifications

    /// <summary>
    /// Verifies user is displayed with Wish list page
    /// </summary>
    /// <returns></returns>
    private WishListPage VerifyWishListPageIsDisplayed()
    {
        WishListPageTitle.Exists(5).Should().BeTrue();

        return new WishListPage(Browser);
    }

    #endregion
}
