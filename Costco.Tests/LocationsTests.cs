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
            LocationsPage locationsPage = new();
            BrowserFactory.Browser.GoToUrl(locationsPage.Url);
            //locationsPage.SearchForWarehouse();
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