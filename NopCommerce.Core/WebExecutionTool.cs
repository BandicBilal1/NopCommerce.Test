using NopCommerce.Core.Elements;
using NopCommerce.Core.Enums;
using NopCommerce.Core.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace NopCommerce.Core;
public sealed class WebExecutionTool : IExecutionTool
{
    private IWebDriver  _webDriver;

    static readonly ThreadLocal<WebExecutionTool> ExecutionToolThread = new ThreadLocal<WebExecutionTool>(() => new WebExecutionTool());
    public static WebExecutionTool Instance => ExecutionToolThread.Value;

    private WebExecutionTool()
    {

    }

    public bool StartApplication()
    {
        Instance.SetWebExecutionTool(Configuration.DriverType);
        return true;
    }

    public void GoTo(string url)
    {
        _webDriver.Navigate().GoToUrl(url);
    }

    public void WaitForApplicationIdle()
    {
    }

    public bool ExitApplication()
    {
        _webDriver.Close();
        _webDriver.Quit();
        return true;
    }

    public IWebDriver GetWebExecutionTool()
    {
        return _webDriver;
    }

    public static IWebElement FindElement(IWebDriver driver, By by, int timeoutInMilliseconds)
    {
        if (timeoutInMilliseconds > 0)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeoutInMilliseconds));
            return wait.Until(drv => drv.FindElement(by));
        }
        return driver.FindElement(by);
    }

    public Dictionary<string, ILabel> GetAllLabels()
    {
        var allLabelElements = _webDriver.FindElements(By.XPath(".//*[string-length(normalize-space(text())) > 0]"));
        var labels = new Dictionary<string, ILabel>();
        foreach (var labelElement in allLabelElements)
        {
            var label = new Label(labelElement);
            labels.Add(label.Id, label);
        }

        return labels;
    }

    public Dictionary<string, IButton> GetAllButtons()
    {
        var allButtonElements = _webDriver.FindElements(By.ClassName("button"));
        var buttons = new Dictionary<string, IButton>();
        foreach (var buttonElement in allButtonElements)
        {
            var button = new Button(buttonElement);
            buttons.Add(button.Id, button);
        }

        return buttons;
    }

    public Dictionary<string, IField> GetAllFields()
    {
        var allFieldElements = _webDriver.FindElements(By.TagName("input"));
        var fields = new Dictionary<string, IField>();
        foreach (var fieldElement in allFieldElements)
        {
            var field = new Field(fieldElement);
            fields.Add(field.Id, field);
        }

        return fields;
    }

    private void SetWebExecutionTool(DriverType driverType)
    {
        switch (driverType)
        {
            case DriverType.Chrome:
                ChromeOptions driverOptions = new ChromeOptions();
                driverOptions.AddArguments("start-maximized");
                _webDriver = new ChromeDriver((ChromeOptions)driverOptions);
                //_webDriver.Manage().Window.FullScreen();
                break;
            case DriverType.Edge:
                _webDriver = new EdgeDriver();
                break;
            default:
                throw new DriveNotFoundException();
        }
    }
}
