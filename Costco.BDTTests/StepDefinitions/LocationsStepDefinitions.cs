using Costco.Core.Browser;
using Costco.Web.Pages;
using FluentAssertions.Execution;

namespace Costco.BDTTests.StepDefinitions
{
    [Binding]
    public sealed class LocationsStepDefinitions
    {
        private ScenarioContext _scenarioContext;
        private LocationsPage locationsPage;
        private WarehousePage warehousePage;
        private const string warehouse = nameof(warehouse);
        private const string location = nameof(location);
        private const string nameOnLocationsPage = nameof(nameOnLocationsPage);
        private const string addressOnLocationsPage = nameof(addressOnLocationsPage);
        private const string nameOnWarehousePage = nameof(nameOnWarehousePage);
        private const string addressOnWarehousePage = nameof(addressOnWarehousePage);

        public LocationsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            locationsPage = new();
            warehousePage = new();
        }

        [When(@"I enter '(.*)' in warehouse search field")]
        public void WhenIEnterWarehouseNameInWarehouseSearchField(string warehouseInput)
        {
            _scenarioContext[warehouse] = warehouseInput;
            Waiters.WaitForCondition(() => locationsPage.WarehouseSearch.IsEnabled());
            locationsPage.WarehouseSearch.Clear();
            locationsPage.WarehouseSearch.SendKeys(warehouseInput);
        }

        [When(@"I click Find a Warehouse")]
        public void WhenIClickFindAWarehouse()
        {
            locationsPage.FindButton.Click();
            Waiters.WaitForCondition(() => !locationsPage.WarehouseTable.IsEmpty());
            Waiters.WaitForCondition(() => locationsPage.WarehouseName.Text.Equals(_scenarioContext[warehouse]));
        }

        [When(@"I click Set as My Warehouse")]
        public void WhenIClickSetAsMyWarehouse()
        {
            Waiters.WaitForCondition(() => locationsPage.SetAsMyWarehouseButton.IsEnabled());
            locationsPage.SetAsMyWarehouseButton.Click();
            Waiters.WaitForCondition(() => locationsPage.LocationsBlock.MyWarehouseButton.Text.Equals(_scenarioContext[warehouse]));
        }

        [When(@"I get name and address of the warehouse on locations page")]
        public void WhenIGetNameAndAddressOfTheWarehouseOnLocationsPage()
        {
            _scenarioContext[nameOnLocationsPage] = locationsPage.WarehouseName.Text;
            _scenarioContext[addressOnLocationsPage] = locationsPage.WarehouseAddress.Text;
        }

        [When(@"I get name and address of the warehouse on warehouse page")]
        public void WhenIGetNameAndAddressOfTheWarehouseOnWarehousePage()
        {
            Waiters.WaitUntilElementExists(warehousePage.NameLocator);
            _scenarioContext[nameOnWarehousePage] = warehousePage.Name.Text[..warehousePage.Name.Text.IndexOf(" ")];
            _scenarioContext[addressOnWarehousePage] = warehousePage.Address.Text;
        }

        [When(@"I click Store Details")]
        public void WhenIClickStoreDetails()
        {
            locationsPage.StoreDetailsButton.Click();
        }

        [When(@"I click Delivery Location")]
        public void WhenIClickDeliveryLocation()
        {
            locationsPage.LocationsBlock.DeliveryLocationButton.Click();
        }

        [When(@"I enter '(.*)' in the ZIP code field")]
        public void WhenIEnterZIPCodeInTheZIPCodeField(string locationInput)
        {
            _scenarioContext[location] = locationInput;
            locationsPage.LocationsBlock.ZipCodeInput.Clear();
            locationsPage.LocationsBlock.ZipCodeInput.SendKeys(locationInput);
        }

        [When(@"I click Change Delivery Location")]
        public void WhenIClickChangeDeliveryLocation()
        {
            locationsPage.LocationsBlock.ChangeDeliveryLocationButton.Click();
            Waiters.WaitForCondition(() => locationsPage.LocationsBlock.DeliveryLocationButton.Text.Equals(_scenarioContext[location]));
        }

        [Then(@"My Warehouse should be '(.*)'")]
        public void ThenMyWarehouseShouldBe(string warehouse)
        {
            string actualWarehouse = locationsPage.LocationsBlock.MyWarehouseButton.Text;
            actualWarehouse.Should().Be(warehouse, "warehouse should be set as My Warehouse");
        }

        [Then(@"Name and address should match on warehouse page and on locations page")]
        public void ThenNameAndAddressShouldMatchOnWarehousePageAndOnLocationsPage()
        {
            using (new AssertionScope())
            {
                _scenarioContext[nameOnLocationsPage].Should().Be(_scenarioContext[nameOnWarehousePage], "warehouse names should match on warehouse page and on locations page");
                _scenarioContext[addressOnLocationsPage].Should().Be(_scenarioContext[addressOnWarehousePage], "warehouse addresses should match on warehouse page and on locations page");
            }
        }

        [Then(@"Delivery Location should be '(.*)'")]
        public void ThenDeliveryLocationShouldBe(string location)
        {
            string actualLocation = locationsPage.LocationsBlock.DeliveryLocationButton.Text;
            actualLocation.Should().Be(location, "location should be set as Delivery Location");
        }
    }
}