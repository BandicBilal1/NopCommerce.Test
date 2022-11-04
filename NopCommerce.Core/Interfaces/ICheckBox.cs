namespace NopCommerce.Core.Interfaces;
public interface ICheckBox : IElement
{
    /// <summary>
    /// Simulates a left mouse click on button UI element
    /// </summary>
    /// <returns>true on successful click</returns>
    bool Click();
}
