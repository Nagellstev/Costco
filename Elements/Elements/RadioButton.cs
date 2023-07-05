using OpenQA.Selenium;

namespace EPAM.Lab_2023CW36.Elements;

public class RadioButton : BaseElement
{
    public RadioButton(By locator) : base(locator)
    {

    }

    public RadioButton(IWebElement element) : base(element)
    {

    }
}