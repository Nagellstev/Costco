using OpenQA.Selenium;

namespace EPAM.Lab_2023CW36.Elements;

public abstract class BaseElement
{
    private readonly IWebElement _element;


    protected BaseElement(By locator)
    {

    }

    protected BaseElement(IWebElement element)
    {
        _element = element;
    }

    public IWebElement OriginalWebElement => _element;

    public virtual void Click()
    {
        OriginalWebElement.Click();
    }
}