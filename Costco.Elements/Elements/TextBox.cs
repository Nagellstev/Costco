using OpenQA.Selenium;

namespace EPAM.Lab_2023CW36.Elements;

public class TextBox : BaseElement
{
    public TextBox(By locator) : base(locator)
    {

    }

    public TextBox(IWebElement element) : base(element)
    {

    }
}