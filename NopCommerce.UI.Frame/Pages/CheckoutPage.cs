using FluentAssertions;
using NopCommerce.Core;
using NopCommerce.Core.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NopCommerce.UI.Frame.Pages;
public class CheckoutPage : BasePage
{
    #region Properties

    private Label CheckoutPageTitle => new(By.XPath("//h1[text()='Checkout']"));
    private Field CityTextField => new(By.Id("BillingNewAddress_City"));
    private Field Address1TextField => new(By.Id("BillingNewAddress_Address1"));
    private Field ZipPostalCodeTextField => new(By.Id("BillingNewAddress_ZipPostalCode"));
    private Field PhoneNumberTextField => new(By.Id("BillingNewAddress_PhoneNumber"));
    private Button ContinueButton => new(By.Name("save"));
    private RadioButton PaymentMethodRadioButton => new (By.Name("paymentmethod"));
    private Button ConfirmButton => new(By.XPath("//button[text()='Confirm']"));
    private Label ConfirmedOrderTitle => new(By.XPath("//div[@class='title']/child::strong"));


    #endregion

    #region Constructors

    public CheckoutPage(WebExecutionTool executionTool) : base(executionTool)
    {

    }

    #endregion

    #region Actions

    /// <summary>
    /// Confirms the order od the user after card being checkout
    /// </summary>
    /// <returns></returns>
    public CheckoutPage ConfirmTheOrder()
    {
        FillInBillingAddress();
        ProceedToNextStep();
        SelectPaymentMethod();
        ProceedToNextStep();
        ProceedToNextStep();
        ConfirmButton.Click();

        return new CheckoutPage(Browser);
    }

    /// <summary>
    /// Fill in user information for Billing address
    /// </summary>
    /// <returns></returns>
    private CheckoutPage FillInBillingAddress()
    {
        SelectElement oSelectElement = new SelectElement(Browser.GetWebExecutionTool().FindElement(By.Id("BillingNewAddress_CountryId")));
        oSelectElement.SelectByText("Bosnia and Herzegowina");
        CityTextField.Write("Sarajevo");
        Address1TextField.Write("Usivak 76, Hadzici");
        ZipPostalCodeTextField.Write("71240");
        PhoneNumberTextField.Write("062889912");

        return new CheckoutPage(Browser);
    }

    /// <summary>
    /// Selects CheckMoneyOrder payment method
    /// </summary>
    /// <returns></returns>
    private CheckoutPage SelectPaymentMethod()
    {
        PaymentMethodRadioButton.SelectValue("Payments.CheckMoneyOrder");

        return new CheckoutPage(Browser);
    }

    /// <summary>
    /// Proceeds to the next step of order confirmation by clicking Continue button
    /// </summary>
    /// <returns></returns>
    private CheckoutPage ProceedToNextStep()
    {
        ContinueButton.Click();
        return new CheckoutPage(Browser);
    }

    #endregion

    #region Verifications

    /// <summary>
    /// Verifies that Checkout page is displayed to the user
    /// </summary>
    /// <returns></returns>
    private CheckoutPage VerifyCheckoutPageIsDisplayed()
    {
        CheckoutPageTitle.Exists(5).Should().BeTrue();

        return new CheckoutPage(Browser);
    }

    /// <summary>
    /// Verifies that order has been placed by the user
    /// </summary>
    /// <returns></returns>
    public CheckoutPage VerifyOrderHasBeenProcessed()
    {
        ConfirmedOrderTitle.Read().Contains("Your order has been successfully processed!");

        return new CheckoutPage(Browser);
    }

    #endregion
}
