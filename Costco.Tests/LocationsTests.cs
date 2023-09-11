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

        [Theory]
        [ClassTestData("Costco.TestData\\TestData\\LocationsTestData.json", typeof(LocationsModel))]
        public void SetWarehouseAsMyWarehouseTest(LocationsModel model)
        {
            string warehouse = model.Warehouse;
            BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl + fixture.Urls.WarehouseLocations);
            
            locationsPageSteps.SearchForWarehouse(warehouse);
            locationsPageSteps.SetAsMyWarehouse(warehouse);

            Assert.True(locationsPageSteps.IsWarehouseSet(warehouse), "\"My Warehouse\" wasn't set.");
        }

        [Theory]
        [ClassTestData("Costco.TestData\\TestData\\LocationsTestData.json", typeof(LocationsModel))]
        public void ViewStoreDetailsTest(LocationsModel model)
        {
            string warehouse = model.Warehouse;
            BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl + fixture.Urls.WarehouseLocations);

            locationsPageSteps.SearchForWarehouse(warehouse);
            string nameOnLocationsPage = locationsPageSteps.GetWarehouseName();
            string addressOnLocationsPage = locationsPageSteps.GetWarehouseAddress();
            locationsPageSteps.ClickStoreDetails();
            string nameOnWarehousePage = warehousePageSteps.GetName();
            string addressOnWarehousePage = warehousePageSteps.GetAddress();

            Assert.Multiple(
                () => Assert.Equal(nameOnLocationsPage, nameOnWarehousePage),
                () => Assert.Equal(addressOnLocationsPage, addressOnWarehousePage));
        }

        [Theory]
        [ClassTestData("Costco.TestData\\TestData\\LocationsTestData.json", typeof(LocationsModel))]
        public void ChangeDeliveryLocationTest(LocationsModel model)
        {
            string deliveryLocation = model.DeliveryLocation;
            BrowserFactory.Browser.GoToUrl(TestSettings.ApplicationUrl + fixture.Urls.WarehouseLocations);

            locationsPageSteps.SetDeliveryLocation(deliveryLocation);

            Assert.True(locationsPageSteps.IsDeliveryLocationSet(deliveryLocation), "Delivery location wasn't set.");
        }
    }
}