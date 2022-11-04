using NopCommerce.Core;
using NopCommerce.Core.Elements;
using NopCommerce.UI.Frame.Extensions;
using OpenQA.Selenium;

namespace NopCommerce.UI.Frame.Pages;
public class GiftCardPage : BasePage
{
    #region Properties

    private GiftCardsPage GiftCardsPage = new (WebExecutionTool);

    private WishListPage WishListPage = new WishListPage(WebExecutionTool);
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

    #region General

    internal GiftCardPage WaitForPage()
    {
        WebExecutionTool.GetWebExecutionTool().WaitForPageToLoad();

        return new GiftCardPage(Browser);
    }

    #endregion

    #region Actions

    public GiftCardPage AddItemToTheWishList()
    {
        FillInGiftCardRequiredFields();
        GiftCardsPage.ClickOnWishListButtonForItem();

        return new GiftCardPage(Browser).WaitForPage();
    }

    private void FillInGiftCardRequiredFields()
    {
        RecipientsNameTextField.Write("aaaa");
        RecipientsEmailTextField.Write("aa.aa@gmail.com");
        //SenderNameTextField.Write("bbbb");
        //SenderEmailTextField.Write("bb.bb@gmail.com");
    }

    public WishListPage NavigateToTheWishListPage()
    {
        WishListLink.Click();
        WishListPage.VerifyWishListPageIsDisplayed();

        return new WishListPage(Browser).WaitForPage();
    }

    #endregion

    #region Verifications

    #endregion
}
