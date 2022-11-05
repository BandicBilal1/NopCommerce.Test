using NopCommerce.Core;
using NopCommerce.Core.Elements;
using OpenQA.Selenium;

namespace NopCommerce.UI.Frame.Pages;
public class GiftCardPage : BasePage
{
    #region Properties

    private GiftCardsPage GiftCardsPage => new (Browser);
    private Button AddToWishListButton => new Button(By.CssSelector("button[class='button-2 add-to-wishlist-button']"));
    private Field RecipientsNameTextField => new (By.Id("giftcard_43_RecipientName"));
    private Field RecipientsEmailTextField => new (By.Id("giftcard_43_RecipientEmail"));
    private Field SenderNameTextField => new (By.Id("giftcard_43_SenderName"));
    private Field SenderEmailTextField => new (By.Id("giftcard_43_SenderEmail"));
    private Button WishListLink => new(By.CssSelector("a[class='ico-wishlist']"));

    #endregion

    #region Constructors

    public GiftCardPage(WebExecutionTool executionTool) : base(executionTool)
    {
    }

    #endregion

    #region Actions

    /// <summary>
    /// Add item to the Wish list 
    /// </summary>
    /// <returns></returns>
    public GiftCardPage AddItemToTheWishList()
    {
        FillInGiftCardRequiredFields();
        GiftCardsPage.ClickOnWishListButtonForItem();

        return new GiftCardPage(Browser);
    }

    /// <summary>
    /// Fill in recipients data to send gift card if user is logged in
    /// </summary>
    /// <returns></returns>
    private void FillInGiftCardRequiredFields()
    {
        RecipientsNameTextField.Write("aaaa");
        RecipientsEmailTextField.Write("aa.aa@gmail.com");
    }

    /// <summary>
    /// Navigate to the Wish list page
    /// </summary>
    /// <returns></returns>
    public WishListPage NavigateToTheWishListPage()
    {
        WishListLink.Click();

        return new WishListPage(Browser);
    }

    #endregion

    #region Verifications

    #endregion
}
