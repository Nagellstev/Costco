using Costco.TestData.Models;
using Costco.Web.Steps;
using Costco.Web.Pages;
using Costco.Core.Browser;

namespace Costco.Tests
{
    [Trait("Target", "Search")]
    public class ZaqariaTests : BaseTest, IClassFixture<TestFixture>
    {
        TestFixture fixture;
        private TiresPageSteps _tiresPageSteps;
        private MainPageSteps _mainPageSteps;

        public ZaqariaTests(TestFixture fixture, ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            this.fixture = fixture;
            _mainPageSteps = new MainPageSteps(new MainPage());
            _tiresPageSteps = new(new TiresPage());
        }

        /// <summary>
        /// EPMFARMATS-17501 Search specific tires using sizes
        /// 1)go to https://www.costco.com/
        /// 2)Change region to Canada
        /// 3)Click Tires button
        /// 4)Click search by size
        /// 5)Select sizes of: Width=285, Aspect=30, Rim=19
        /// 6)Enter postal code
        /// 7)Click "Find tires"
        /// result) Website should display number of tires found using specified sizes, in this case "Searching Tires For 285 30/R19" of sizes should be displayed        
        /// </summary>
        [Theory]
        [ClassTestData("ZaqariaTestData.json", typeof(ZaqariaDataModel))]
        public void SearchSpecificTiresTest(ZaqariaDataModel zaqariaDataModel)
        {
            //Waiters.WaitForPageLoad();
            //_mainPageSteps.ChooseCountry(zaqariaDataModel.Country);
            BrowserFactory.Browser.GoToUrl("https://www.costco.ca/");

            Waiters.WaitForPageLoad();
            _mainPageSteps.ChooseTires();

            Waiters.WaitForPageLoad();
            _tiresPageSteps.SearchBySize();
            _tiresPageSteps.AcceptAllCookies();
            _tiresPageSteps.SelectTire("215", "60", "17");
            _tiresPageSteps.PostalCodeInput("M6B 3B1");
            _tiresPageSteps.FindTiresButtonClick();

            Assert.True(_tiresPageSteps.VerifyPresenceOfTireCenterMessage());
        }
    }
}