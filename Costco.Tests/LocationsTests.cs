using Costco.Core.Browser;
using Costco.Utilities.FileReader.Models;
using Costco.Web.Pages;

namespace Costco.Tests
{
    public class LocationsTests : IClassFixture<TestFixture>
    {
        TestFixture fixture;

        public LocationsTests(TestFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void SetWarehouseAsMyWarehouseTest()
        {
            string warehouse = ((LocationsModel)fixture.testData).Warehouse;

            LocationsPage locationsPage = new();
            BrowserFactory.Browser.GoToUrl(locationsPage.Url);
            locationsPage.SearchForWarehouse(warehouse);
            Waiters.WaitForCondition(() => locationsPage.SetAsMyWarehouseButton.IsDisplayed(), 5);
            locationsPage.SetAsMyWarehouse();
            Waiters.WaitForCondition(() => locationsPage.IsWarehouseSet(warehouse), 5);

            Assert.True(locationsPage.IsWarehouseSet(warehouse));
        }

        [Fact]
        public void ViewStoreDetailsTest()
        {

        }

        [Fact]
        public void ChangeDeliveryLocationTest()
        {

        }
    }
}