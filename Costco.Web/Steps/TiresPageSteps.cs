using Costco.Core.Browser;
using Costco.Web.Blocks;
using Costco.Web.Pages;

namespace Costco.Web.Steps
{
    public class TiresPageSteps
    {
        private TiresPage _tiresPage;

        public TiresPageSteps(TiresPage tiresPage)
        {
            _tiresPage = tiresPage;
        }

        public void SearchBySize()
        {
            Waiters.WaitForCondition(() => _tiresPage.SearchBySizeButton.IsDisplayed(), 10);
            _tiresPage.SearchBySizeButton.Click();
        }

        public void FindTiresButtonClick()
        {
            Waiters.WaitForCondition(() => _tiresPage.FindTiresButton.IsDisplayed(), 5);
            _tiresPage.FindTiresButton.Click();
        }

        public void PostalCodeInput(string code)
        {
            Waiters.WaitForCondition(() => _tiresPage.PostalCodeInput.IsDisplayed(), 10);
            _tiresPage.PostalCodeInput.SendKeys(code);
        }

        public void AcceptAllCookies()
        {
            Waiters.WaitForCondition(() => _tiresPage.AcceptAllCookiesButton.IsDisplayed(), 10);
            _tiresPage.AcceptAllCookiesButton.Click();
        }

        public bool VerifyPresenceOfTireCenterMessage()
        {
            Waiters.WaitForCondition(() => _tiresPage.SelectTireCenterLabel.IsDisplayed(), 5);
            return _tiresPage.SelectTireCenterLabel.IsDisplayed();
        }

        public void SelectTire(string width, string aspect, string rim)
        {
            MenuItemClick(_tiresPage.WidthSelectBlock, width);
            MenuItemClick(_tiresPage.AspectSelectBlock, aspect);
            MenuItemClick(_tiresPage.RimSelectBlock, rim);
            _tiresPage.RimSelectBlock.Click();
        }

        private void MenuItemClick(DropdownOnClickSelectBlock menu, string item)
        {
            Waiters.WaitForCondition(() => menu.IsDisplayed() && menu.IsEnabled(), 10);
            menu.OriginalWebElement.Click();
            Waiters.WaitForCondition(() => menu.Items.Count > 0, 10);
            for (int i = 0; i < menu.Items.Count; i++)
            {
                if (menu.Items[i].Text.Contains(item))
                {
                    menu.Items[i].Click();
                }
            }
        }
    }
}
