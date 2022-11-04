using FluentAssertions;
using NopCommerce.Core;
using NopCommerce.Core.Elements;
using NopCommerce.UI.Frame.Extensions;
using OpenQA.Selenium;
using Pages;

namespace NopCommerce.UI.Frame.Pages;
public class GiftCardsPage : BasePage
{
    #region Properties

    private Button AddToWishListButton => new Button(By.CssSelector("button[class='button-2 add-to-wishlist-button']"));

    #endregion

    #region Constructors

    public GiftCardsPage(WebExecutionTool executionTool) : base(executionTool)
    {
    }

    #endregion

    #region General

    internal GiftCardsPage WaitForPage()
    {
        WebExecutionTool.GetWebExecutionTool().WaitForPageToLoad();

        return new GiftCardsPage(Browser);
    }

    #endregion

    public GiftCardPage ClickOnWishListButtonForItem()
    {
        AddToWishListButton.Click();

        return new GiftCardPage(Browser).WaitForPage();
    }

    #region Actions

    #endregion

    #region Verifications

    #endregion
}
