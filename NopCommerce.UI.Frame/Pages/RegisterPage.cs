using FluentAssertions;
using NopCommerce.Core;
using NopCommerce.Core.Elements;
using NopCommerce.Core.Interfaces;
using NopCommerce.UI.Frame.Extensions;
using OpenQA.Selenium;
using Pages;

namespace NopCommerce.UI.Frame.Pages;
public class RegisterPage : BasePage
{
    #region Properties
    private RadioButton RadioButton => new (By.Name("Gender"));
    private  Field FirstNameTextField => new (By.Id("FirstName"));
    private  Field LastNameTextField => new (By.Id("LastName"));
    private  Field EmailTextField => new (By.Id("Email"));
    private  Field PasswordTextField => new (By.Id("Password"));
    private  Field ConfirmPasswordTextField => new (By.Id("ConfirmPassword"));
    private Button RegisterButton => new (By.Id("register-button"));

    #endregion

    #region Constructors

    public RegisterPage(WebExecutionTool executionTool) : base(executionTool)
    {
    }

    #endregion

    #region General

    internal RegisterPage WaitForPage()
    {
        WebExecutionTool.GetWebExecutionTool().WaitForPageToLoad();

        return new RegisterPage(Browser);
    }

    #endregion

    #region Actions

    public HomePage RegisterToTheNopCommerce()
    {
        FillInRequiredFieldsForRegistration();
        ClickOnTheRegisterButton();
        VerifyThatUserIsRegistered();

        return new HomePage(Browser).WaitForPage();
    }
    
    private RegisterPage FillInRequiredFieldsForRegistration()
    {
        RadioButton.SelectValue("M");
        FirstNameTextField.Write("Bilal");
        LastNameTextField.Write("Bandic");
        EmailTextField.Write("bandic.bilal.bkkdjjscdjjycd@gmail.com");
        PasswordTextField.Write("Capri0123.");
        ConfirmPasswordTextField.Write("Capri0123.");

        return new RegisterPage(Browser).WaitForPage();
    }

    private void ClickOnTheRegisterButton()
    {
        RegisterButton.Click();
    }

    #endregion

    #region Verifications

    private HomePage VerifyThatUserIsRegistered()
    {
        var registrationCompletedText = WebExecutionTool.FindElement(Browser.GetWebExecutionTool(), By.CssSelector("div[class='result']"), 5000);
        registrationCompletedText.Displayed.Should().BeTrue();

        var continueButton = WebExecutionTool.FindElement(Browser.GetWebExecutionTool(), By.XPath("//a[text()='Continue']"), 5000);
        continueButton.Click();

        return new HomePage(Browser).WaitForPage();
    }

    #endregion

}
