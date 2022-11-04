using NopCommerce.Core.Interfaces;
using OpenQA.Selenium;

namespace NopCommerce.Core.Elements;
public class RadioButton : IButton
{
    private string Id { get; set; }

    private readonly IWebElement _element;

    private readonly IReadOnlyCollection<IWebElement> _elements;
    private static WebExecutionTool WebExecutionTool => WebExecutionTool.Instance;

    public RadioButton(By by)
    {
        Id = Guid.NewGuid().ToString();
        _elements = WebExecutionTool.GetWebExecutionTool().FindElements(by);
    }

    public void SelectValue(string value)
    {
        _elements.Single(_element => _element.GetAttribute("value") == value).Click();
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
