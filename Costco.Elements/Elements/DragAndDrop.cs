using EPAM.Lab_2023CW36.Elements;
using OpenQA.Selenium;

namespace EPAM.Lab_2023CW36.Elements;

public class DragAndDrop : BaseElement
{
    public DragAndDrop(By locator) : base(locator)
    {

    }

    public DragAndDrop(IWebElement element) : base(element)
    {

    }
}