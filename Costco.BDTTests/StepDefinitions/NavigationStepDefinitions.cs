using Costco.Core.Browser;

namespace Costco.BDTTests.StepDefinitions
{
    [Binding]
    public sealed class NavigationStepDefinitions
    {
        private readonly string _mainPageUrl = TestSettings.ApplicationUrl;

        [Given("I am on the main page")]
        public void GivenIAmOnTheMainPage()
        {
            BrowserFactory.Browser.GoToUrl(_mainPageUrl);
        }
    }
}
