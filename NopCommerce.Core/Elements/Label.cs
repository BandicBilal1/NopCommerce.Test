using NopCommerce.Core.Interfaces;
using OpenQA.Selenium;

namespace NopCommerce.Core.Elements;
public class Label : ILabel
{
    private readonly IWebElement _element;
    public string Id { get; set; }
    private static WebExecutionTool WebExecutionTool => WebExecutionTool.Instance;

    public Label(By by)
    {
        Id = Guid.NewGuid().ToString();
        _element = WebExecutionTool.GetWebExecutionTool().FindElement(by);
    }

    public Label(IWebElement element)
    {
        Id = Guid.NewGuid().ToString();
        _element = element;
    }

    public bool Exists(int timeout)
    {
        return _element.Displayed;
    }

    public string Read()
    {
        return _element.Text;
    }
}
