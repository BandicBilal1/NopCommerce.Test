using OpenQA.Selenium;

namespace NopCommerce.Core.Interfaces;
public interface IButton : IElement
{
    /// <summary>
    /// Simulates a left mouse click on button UI element
    /// </summary>
    /// <returns>true on successful click</returns>
    bool Click();
}
