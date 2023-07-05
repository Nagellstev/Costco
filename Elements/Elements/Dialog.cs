using EPAM.Lab_2023CW36.Elements;
using OpenQA.Selenium;

namespace EPAM.Lab_2023CW36.Elements;

public class Dialog : BaseElement
{
    public Dialog(By locator) : base(locator)
    {

    }

    public Dialog(IWebElement element) : base(element)
    {

    }
}