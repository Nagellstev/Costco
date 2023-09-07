using Costco.Core.Browser;
using Costco.Web.Pages;
using FluentAssertions.Execution;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Costco.BDTTests.StepDefinitions
{
    [Binding]
    public sealed class LocalizationStepDefinitions
    {
        private ScenarioContext _scenarioContext;
        private MainPage mainPage;

        public LocalizationStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            mainPage = new();
        }

        [When(@"I choose the '(.*)' country")]
        public void WhenIChooseTheCountry(string country)
        {
            mainPage.CountrySelectButton.Hover();
            mainPage.CountrySelectList.GetElementByText(By.CssSelector("li"), country).Click();
        }

        [When(@"I choose the '(.*)' language")]
        public void WhenIChooseTheLanguage(string language)
        {
            mainPage.LanguageSelectButton.Hover();
            mainPage.LanguageSelectList.GetElementByText(By.CssSelector("li"), language).Click();
        }

        [Then(@"URL should be '(.*)' and country should be '(.*)' and language should be '(.*)'")]
        public void ThenUrlShouldBeAndCountryShouldBeAndLanguageShouldBe(string expectedUrl, string country, string language)
        {
            string currentUrl = Browser.Driver.Url;
            Uri uri = new Uri(currentUrl);
            Uri trimmedUri = new UriBuilder(uri.Scheme, uri.Host).Uri;
            string trimmedUrl = trimmedUri.ToString();

            using (new AssertionScope())
            {
                trimmedUrl.Should().Be(expectedUrl, "url should correspond to the chosen country");
                mainPage.CountrySelectButton.Text.Should().Be(country, "country should be set");
                mainPage.LanguageSelectButton.Text.Should().Be(language, "language should be set");
            }
        }
    }
}
