using FluentAssertions;
using NopCommerce.API.Helpers;
using NopCommerce.Core;
using NopCommerce.Core.Elements;
using NopCommerce.Core.Interfaces;
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

    #region Actions

    /// <summary>
    /// Register user in NopCommerce
    /// </summary>
    /// <returns></returns>
    public HomePage RegisterToTheNopCommerce()
    {
        FillInRequiredFieldsForRegistration();
        ClickOnTheRegisterButton();
        VerifyThatUserIsRegistered();

        return new HomePage(Browser);
    }
    
    /// <summary>
    /// Fill in user data needed for registration
    /// </summary>
    /// <returns></returns>
    private RegisterPage FillInRequiredFieldsForRegistration()
    {
        RadioButton.SelectValue("M");
        FirstNameTextField.Write("Bilal");
        LastNameTextField.Write("Bandic");
        EmailTextField.Write($"bandic.bilal.{Helper.GenerateRandomString()}@gmail.com");
        PasswordTextField.Write("Capri0123.");
        ConfirmPasswordTextField.Write("Capri0123.");

        return new RegisterPage(Browser);
    }

    /// <summary>
    /// Conclude registration of user by clicking Register button
    /// </summary>
    /// <returns></returns>
    private void ClickOnTheRegisterButton()
    {
        RegisterButton.Click();
    }

    #endregion

    #region Verifications

    /// <summary>
    /// Verifies user is registered 
    /// </summary>
    /// <returns></returns>
    private HomePage VerifyThatUserIsRegistered()
    {
        var registrationCompletedText = WebExecutionTool.FindElement(Browser.GetWebExecutionTool(), By.CssSelector("div[class='result']"), 5000);
        registrationCompletedText.Displayed.Should().BeTrue();

        var continueButton = WebExecutionTool.FindElement(Browser.GetWebExecutionTool(), By.XPath("//a[text()='Continue']"), 5000);
        continueButton.Click();

        return new HomePage(Browser);
    }

    #endregion

}
