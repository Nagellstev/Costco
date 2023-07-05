using EPAM.Lab_2023CW36.Elements;
using OpenQA.Selenium;

namespace EPAM.Lab_2023CW36.Elements;

public class CheckBox : BaseElement
{
    public CheckBox(By locator) : base(locator)
    {

    }

    public CheckBox(IWebElement element) : base(element)
    {

    }
}