using OpenQA.Selenium;

namespace EPAM.Lab_2023CW36.Elements;

public class DropDown : BaseElement
{
    public DropDown(By locator) : base(locator)
    {

    }

    public DropDown(IWebElement element) : base(element)
    {

    }
}