using OpenQA.Selenium;

namespace EPAM.Lab_2023CW36.Elements;

public class WebTable : BaseElement
{
    public WebTable(By locator) : base(locator)
    {

    }

    public WebTable(IWebElement element) : base(element)
    {

    }
}