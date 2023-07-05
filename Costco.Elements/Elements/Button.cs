using EPAM.Lab_2023CW36.Elements;
using OpenQA.Selenium;

namespace EPAM.Lab_2023CW36.Elements;

public class Button : BaseElement
{

    public Button(By locator) : base(locator)
    {

    }

    public Button(IWebElement element) : base(element)
    {

    }
}