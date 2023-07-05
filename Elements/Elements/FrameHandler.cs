using OpenQA.Selenium;

namespace EPAM.Lab_2023CW36.Elements;

public class FrameHandler : BaseElement
{
    public FrameHandler(By locator) : base(locator)
    {

    }

    public FrameHandler(IWebElement element) : base(element)
    {

    }
}