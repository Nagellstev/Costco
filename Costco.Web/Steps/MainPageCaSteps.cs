using Costco.Core.Browser;
using Costco.Web.Blocks;
using Costco.Web.Pages;
using OpenQA.Selenium;

namespace Costco.Web.Steps
{
    public class MainPageCaSteps
    {
        private MainPageCa _mainPageCa;

        public MainPageCaSteps(MainPageCa mainPageCa)
        {
            _mainPageCa = mainPageCa;
        }

        public void ChooseTires()
        {
            Waiters.WaitForCondition(() => _mainPageCa.TiresButton.IsEnabled() && _mainPageCa.TiresButton.IsDisplayed(), 10);
            _mainPageCa.TiresButton.Click();
        }
    }
}
