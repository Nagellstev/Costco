using OpenQA.Selenium;

namespace EPAM.Lab_2023CW36.Elements;

public class FileUpload : BaseElement
{
    public FileUpload(By locator) : base(locator)
    {

    }

    public FileUpload(IWebElement element) : base(element)
    {

    }
}