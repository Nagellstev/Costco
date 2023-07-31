using Costco.Core.Browser;
using Costco.TestData.Models;
using Costco.Web.Pages;

namespace Costco.Tests
{
    [Trait("Target", "Delivery")]
    public class LocationsTests : BaseTest, IClassFixture<TestFixture>
    {
        TestFixture fixture;

        public LocationsTests(TestFixture fixture, ITestOutputHelper testOutputHelper): base(testOutputHelper)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void SetWarehouseAsMyWarehouseTest()
        {
            string warehouse = ((LocationsModel)fixture.TestData).Warehouse;

            LocationsPage locationsPage = new();

            BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl + fixture.Urls.WarehouseLocations);
            Waiters.WaitForCondition(() => locationsPage.WarehouseSearch.IsEnabled());
            locationsPage.SearchForWarehouse(warehouse);
            Waiters.WaitForCondition(() => locationsPage.SetAsMyWarehouseButton.IsEnabled());
            locationsPage.SetAsMyWarehouse();
            Waiters.WaitForCondition(() => locationsPage.IsWarehouseSet(warehouse));

            Assert.True(locationsPage.IsWarehouseSet(warehouse));
        }

        [Fact]
        public void ViewStoreDetailsTest()
        {
            string warehouse = ((LocationsModel)fixture.TestData).Warehouse;

            LocationsPage locationsPage = new();

            BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl + fixture.Urls.WarehouseLocations);
            Waiters.WaitForCondition(() => locationsPage.WarehouseSearch.IsEnabled());
            locationsPage.SearchForWarehouse(warehouse);
            Waiters.WaitForCondition(() => locationsPage.IsResultFound(warehouse));
            string nameOnLocationsPage = locationsPage.GetWarehouseName();
            string addressOnLocationsPage = locationsPage.GetWarehouseAddress();
            locationsPage.ClickStoreDetails();
            WarehousePage warehousePage = new();
            Waiters.WaitForCondition(() => warehousePage.Name.IsEnabled());
            string nameOnWarehousePage = warehousePage.GetName();
            string addressOnWarehousePage = warehousePage.GetAddress();

            Assert.True(nameOnLocationsPage == nameOnWarehousePage &&
                addressOnLocationsPage == addressOnWarehousePage);
        }

        [Fact]
        public void ChangeDeliveryLocationTest()
        {
            string deliveryLocation = ((LocationsModel)fixture.TestData).DeliveryLocation;

            LocationsPage locationsPage = new();
            BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl + fixture.Urls.WarehouseLocations);
            locationsPage.LocationsBlock.SetDeliveryLocation(deliveryLocation);
            Waiters.WaitForCondition(() => locationsPage.IsDeliveryLocationSet(deliveryLocation));

            Assert.True(locationsPage.IsDeliveryLocationSet(deliveryLocation));
        }
    }
}