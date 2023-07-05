using OpenQA.Selenium;

namespace EPAM.Lab_2023CW36.Elements;

public class LinkText : BaseElement
{
    public LinkText(By locator) : base(locator)
    {

    }

    public LinkText(IWebElement element) : base(element)
    {

    }
}