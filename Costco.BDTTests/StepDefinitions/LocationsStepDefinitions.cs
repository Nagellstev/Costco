using Costco.Core.Browser;
using Costco.Web.Pages;
using FluentAssertions.Execution;

namespace Costco.BDTTests.StepDefinitions
{
    [Binding]
    public sealed class LocationsStepDefinitions
    {
        private ScenarioContext context;
        private LocationsPage locationsPage;
        private WarehousePage warehousePage;

        public LocationsStepDefinitions(ScenarioContext scenarioContext)
        {
            context = scenarioContext;
            locationsPage = new();
            warehousePage = new();
        }

        [When(@"I enter '(.*)' in warehouse search field")]
        public void WhenIEnterWarehouseNameInWarehouseSearchField(string warehouse)
        {
            context["warehouse"] = warehouse;
            Waiters.WaitForCondition(() => locationsPage.WarehouseSearch.IsEnabled());
            locationsPage.WarehouseSearch.Clear();
            locationsPage.WarehouseSearch.SendKeys(warehouse);
        }

        [When(@"I click Find a Warehouse")]
        public void WhenIClickFindAWarehouse()
        {
            locationsPage.FindButton.Click();
            Waiters.WaitForCondition(() => !locationsPage.WarehouseTable.IsEmpty());
            Waiters.WaitForCondition(() => locationsPage.WarehouseName.Text.Equals(context["warehouse"]));
        }

        [When(@"I click Set as My Warehouse")]
        public void WhenIClickSetAsMyWarehouse()
        {
            Waiters.WaitForCondition(() => locationsPage.SetAsMyWarehouseButton.IsEnabled());
            locationsPage.SetAsMyWarehouseButton.Click();
            Waiters.WaitForCondition(() => locationsPage.LocationsBlock.MyWarehouseButton.Text.Equals(context["warehouse"]));
        }

        [When(@"I remember name and address on locations page")]
        public void WhenIRememberNameAndAddressOnLocationsPage()
        {
            context["nameOnLocationsPage"] = locationsPage.WarehouseName.Text;
            context["addressOnLocationsPage"] = locationsPage.WarehouseAddress.Text;
        }

        [When(@"I remember name and address on warehouse page")]
        public void WhenIRememberNameAndAddressOnWarehousePage()
        {
            Waiters.WaitUntilElementExists(warehousePage.NameLocator);
            context["nameOnWarehousePage"] = warehousePage.Name.Text[..warehousePage.Name.Text.IndexOf(" ")];
            context["addressOnWarehousePage"] = warehousePage.Address.Text;
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
        public void WhenIEnterZIPCodeInTheZIPCodeField(string location)
        {
            context["location"] = location;
            locationsPage.LocationsBlock.ZipCodeInput.Clear();
            locationsPage.LocationsBlock.ZipCodeInput.SendKeys(location);
        }

        [When(@"I click Change Delivery Location")]
        public void WhenIClickChangeDeliveryLocation()
        {
            locationsPage.LocationsBlock.ChangeDeliveryLocationButton.Click();
            Waiters.WaitForCondition(() => locationsPage.LocationsBlock.DeliveryLocationButton.Text.Equals(context["location"]));
        }

        [Then(@"My Warehouse should be '(.*)'")]
        public void ThenMyWarehouseShouldBe(string warehouse)
        {
            string warehouseToAssert = locationsPage.LocationsBlock.MyWarehouseButton.Text;
            warehouseToAssert.Should().Be(warehouse);
        }

        [Then(@"Name and address should match on warehouse page and on locations page")]
        public void ThenNameAndAddressShouldMatchOnWarehousePageAndOnLocationsPage()
        {
            using (new AssertionScope())
            {
                context["nameOnLocationsPage"].Should().Be(context["nameOnWarehousePage"]);
                context["addressOnLocationsPage"].Should().Be(context["addressOnWarehousePage"]);
            }
        }

        [Then(@"Delivery Location should be '(.*)'")]
        public void ThenDeliveryLocationShouldBe(string location)
        {
            string locationToAssert = locationsPage.LocationsBlock.DeliveryLocationButton.Text;
            locationToAssert.Should().Be(location);
        }
    }
}