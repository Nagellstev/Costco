﻿using Costco.Core.Browser;
using TechTalk.SpecFlow;

namespace Costco.BDTTests.StepDefinitions
{
    [Binding]
    public sealed class NavigationStepDefinitions
    {
        private readonly string _mainPageUrl = TestSettings.ApplicationUrl;

        [Given(@"I am on the main page")]
        public void GivenIAmOnTheMainPage()
        {
            BrowserFactory.Browser.GoToUrl(_mainPageUrl);
        }

        [Given(@"I go to the page '(.*)'")]
        public void GivenIGoToThePage(string url)
        {
            BrowserFactory.Browser.GoToUrl(_mainPageUrl+'/'+url);
        }

        [Given(@"I opened page '(.*)'")]
        public void GivenIOpenedThePage(string url)
        {
            BrowserFactory.Browser.GoToUrl(url);
        }
    }
}
