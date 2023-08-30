﻿using Costco.Core.Browser;
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
        private string warehouse;
        private string location;
        private string nameOnLocationsPage;
        private string addressOnLocationsPage;
        private string nameOnWarehousePage;
        private string addressOnWarehousePage;

        public LocationsStepDefinitions(ScenarioContext scenarioContext)
        {
            context = scenarioContext;
            locationsPage = new();
            warehousePage = new();
        }

        [When(@"I enter '(.*)' in warehouse search field")]
        public void WhenIEnterWarehouseNameInWarehouseSearchField(string warehouse)
        {
            this.warehouse = warehouse;
            Waiters.WaitForCondition(() => locationsPage.WarehouseSearch.IsEnabled());
            locationsPage.WarehouseSearch.Clear();
            locationsPage.WarehouseSearch.SendKeys(this.warehouse);
        }

        [When(@"I click Find a Warehouse")]
        public void WhenIClickFindAWarehouse()
        {
            locationsPage.FindButton.Click();
            Waiters.WaitForCondition(() => !locationsPage.WarehouseTable.IsEmpty());
            Waiters.WaitForCondition(() => locationsPage.WarehouseName.Text.Equals(warehouse));
        }

        [When(@"I click Set as My Warehouse")]
        public void WhenIClickSetAsMyWarehouse()
        {
            Waiters.WaitForCondition(() => locationsPage.SetAsMyWarehouseButton.IsEnabled());
            locationsPage.SetAsMyWarehouseButton.Click();
            Waiters.WaitForCondition(() => locationsPage.LocationsBlock.MyWarehouseButton.Text.Equals(warehouse));
        }

        [When(@"I remember name and address on locations page")]
        public void WhenIRememberNameAndAddressOnLocationsPage()
        {
            nameOnLocationsPage = locationsPage.WarehouseName.Text;
            addressOnLocationsPage = locationsPage.WarehouseAddress.Text;
        }

        [When(@"I remember name and address on warehouse page")]
        public void WhenIRememberNameAndAddressOnWarehousePage()
        {
            Waiters.WaitUntilElementExists(warehousePage.NameLocator);
            nameOnWarehousePage = warehousePage.Name.Text[..warehousePage.Name.Text.IndexOf(" ")];
            addressOnWarehousePage = warehousePage.Address.Text;
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
            this.location = location;
            locationsPage.LocationsBlock.ZipCodeInput.Clear();
            locationsPage.LocationsBlock.ZipCodeInput.SendKeys(this.location);
        }

        [When(@"I click Change Delivery Location")]
        public void WhenIClickChangeDeliveryLocation()
        {
            locationsPage.LocationsBlock.ChangeDeliveryLocationButton.Click();
            Waiters.WaitForCondition(() => locationsPage.LocationsBlock.DeliveryLocationButton.Text.Equals(location));
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
                nameOnLocationsPage.Should().Be(nameOnWarehousePage, "warehouse names should match on warehouse page and on locations page");
                addressOnLocationsPage.Should().Be(addressOnWarehousePage, "warehouse addresses should match on warehouse page and on locations page");
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