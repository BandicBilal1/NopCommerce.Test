using NUnit.Allure.Core;

namespace NopCommerce.Tests.UITests;

[AllureNUnit]
public class UserStory1 : BaseTest
{
    [Test]
    [Property("UITest", "1")]
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
