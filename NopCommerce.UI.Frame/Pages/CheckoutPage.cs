using FluentAssertions;
using NopCommerce.Core;
using NopCommerce.Core.Elements;
using NopCommerce.UI.Frame.Extensions;
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

    #region General

    internal CheckoutPage WaitForPage()
    {
        WebExecutionTool.GetWebExecutionTool().WaitForPageToLoad();

        return new CheckoutPage(Browser);
    }

    #endregion

    #region Actions

    public CheckoutPage ConfirmTheOrder()
    {
        FillInBillingAddress();
        ProceedToNextStep();
        SelectPaymentMethod();
        ProceedToNextStep();
        ProceedToNextStep();
        ConfirmButton.Click();

        return new CheckoutPage(Browser).WaitForPage();
    }

    private CheckoutPage FillInBillingAddress()
    {
        SelectElement oSelectElement = new SelectElement(WebExecutionTool.GetWebExecutionTool().FindElement(By.Id("BillingNewAddress_CountryId")));
        oSelectElement.SelectByText("Bosnia and Herzegowina");
        CityTextField.Write("Sarajevo");
        Address1TextField.Write("Usivak 76, Hadzici");
        ZipPostalCodeTextField.Write("71240");
        PhoneNumberTextField.Write("062889912");

        return new CheckoutPage(Browser).WaitForPage();
    }

    private CheckoutPage SelectPaymentMethod()
    {
        PaymentMethodRadioButton.SelectValue("Payments.CheckMoneyOrder");

        return new CheckoutPage(Browser).WaitForPage();
    }

    private CheckoutPage ProceedToNextStep()
    {
        ContinueButton.ClickJs();
        return new CheckoutPage(Browser).WaitForPage();
    }

    #endregion

    #region Verifications

    public CheckoutPage VerifyCheckoutPageIsDisplayed()
    {
        CheckoutPageTitle.Exists(5).Should().BeTrue();

        return new CheckoutPage(Browser).WaitForPage();
    }

    public CheckoutPage VerifyOrderHasBeenProcessed()
    {
        ConfirmedOrderTitle.Read().Contains("Your order has been successfully processed!");

        return new CheckoutPage(Browser).WaitForPage();
    }

    #endregion
}
