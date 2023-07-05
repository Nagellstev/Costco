using OpenQA.Selenium;

namespace EPAM.Lab_2023CW36.Elements;

public class SearchBar : BaseElement
{
    public SearchBar(By locator) : base(locator)
    {

    }

    public SearchBar(IWebElement element) : base(element)
    {

    }
}