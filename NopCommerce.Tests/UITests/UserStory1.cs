namespace NopCommerce.Tests.UITests;
public class UserStory1 : BaseTest
{
    [Test]
    [Property("Test", "1")]
    public void TC_01_VerifyThatUserIsAbleToRegisterToTheNopCommerceSite()
    {
        Navigator.GoToHomePage()
            .NavigateToTheRegisterPage();
    }
}
