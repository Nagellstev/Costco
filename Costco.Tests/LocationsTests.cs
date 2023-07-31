using Costco.Core.Browser;
using Costco.TestData.Models;
using Costco.Web.Steps;

namespace Costco.Tests
{
    [Trait("Target", "Delivery")]
    public class LocationsTests : BaseTest, IClassFixture<TestFixture>
    {
        TestFixture fixture;
        private LocationsPageSteps locationsPageSteps;
        private WarehousePageSteps warehousePageSteps;

        public LocationsTests(TestFixture fixture, ITestOutputHelper testOutputHelper): base(testOutputHelper)
        {
            this.fixture = fixture;
            locationsPageSteps = new(new());
            warehousePageSteps = new(new());
        }

        [Fact]
        public void SetWarehouseAsMyWarehouseTest()
        {
            string warehouse = ((LocationsModel)fixture.TestData).Warehouse;
            BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl + fixture.Urls.WarehouseLocations);
            
            locationsPageSteps.SearchForWarehouse(warehouse);
            locationsPageSteps.SetAsMyWarehouse(warehouse);

            Assert.True(locationsPageSteps.IsWarehouseSet(warehouse), "\"My Warehouse\" wasn't set.");
        }

        [Fact]
        public void ViewStoreDetailsTest()
        {
            string warehouse = ((LocationsModel)fixture.TestData).Warehouse;
            BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl + fixture.Urls.WarehouseLocations);

            locationsPageSteps.SearchForWarehouse(warehouse);
            string nameOnLocationsPage = locationsPageSteps.GetWarehouseName();
            string addressOnLocationsPage = locationsPageSteps.GetWarehouseAddress();
            locationsPageSteps.ClickStoreDetails();
            string nameOnWarehousePage = warehousePageSteps.GetName();
            string addressOnWarehousePage = warehousePageSteps.GetAddress();

            Assert.True(nameOnLocationsPage == nameOnWarehousePage &&
                addressOnLocationsPage == addressOnWarehousePage,
                "Names and addresses don't match on search page and details page.");
        }

        [Fact]
        public void ChangeDeliveryLocationTest()
        {
            string deliveryLocation = ((LocationsModel)fixture.TestData).DeliveryLocation;
            BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl + fixture.Urls.WarehouseLocations);

            locationsPageSteps.SetDeliveryLocation(deliveryLocation);

            Assert.True(locationsPageSteps.IsDeliveryLocationSet(deliveryLocation), "Delivery location wasn't set.");
        }
    }
}