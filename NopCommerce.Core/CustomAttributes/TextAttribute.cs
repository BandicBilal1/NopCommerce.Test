namespace NopCommerce.Core.CustomAttributes;

[AttributeUsage(AttributeTargets.All)]
public class TextAttribute : Attribute
{
    public TextAttribute(string uiText)
    {
        Text = uiText;
    }

    private string Text { get; set; }
}
