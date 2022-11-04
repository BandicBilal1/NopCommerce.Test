namespace NopCommerce.Tests.UITests;
public class UserStory1 : BaseTest
{
    [Test]
    [Property("Test", "1")]
    public void TC_01_AC1()
    {
        Navigator.GoToHomePage()
            .NavigateToTheRegisterPage()
            .RegisterToTheNopCommerce()
            .NavigateToTheGiftCardsPage()
            .ClickOnWishListButtonForItem()
            .AddItemToTheWishList()
            .NavigateToTheWishListPage()
            .UpdateProductQuantityFor("3")
            .AddProductToTheCart()
            .CheckoutTheCart()
            .ConfirmTheOrder()
            .VerifyOrderHasBeenProcessed();
    }
}
