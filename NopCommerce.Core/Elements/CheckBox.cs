using NopCommerce.Core.Interfaces;
using OpenQA.Selenium;

namespace NopCommerce.Core.Elements;
public class CheckBox : ICheckBox
{
    public string Id { get; private set; }

    private readonly IWebElement _element;
    private static WebExecutionTool WebExecutionTool => WebExecutionTool.Instance;
    public CheckBox(By by)
    {
        Id = Guid.NewGuid().ToString();
        _element = WebExecutionTool.GetWebExecutionTool().FindElement(by);
    }

    public CheckBox(IWebElement element)
    {
        Id = Guid.NewGuid().ToString();
        _element = element;
    }
    public bool Click()
    {
        _element.Click();
        return true;
    }

    public bool Exists(int timeout)
    {
        return _element.Displayed;
    }
}