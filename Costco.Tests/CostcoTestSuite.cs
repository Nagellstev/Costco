using Costco.Core.Browser;
using Costco.Utilities.FileReader.Models;
using Costco.Utilities.Logger;
using Costco.Utilities.Screenshotter;
using Costco.Web.Pages;

namespace Costco.Tests
{
    public class CostcoTestSuite: IClassFixture<TestFixture>
    {
        TestFixture fixture;

        public CostcoTestSuite(TestFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void Test1()
        {
            try 
            {
                //test goes here
            }
            catch (Exception ex)
            {
                Logger.Error($"Test failed, exception {ex.Message}");
                Screenshoter.TakeScreenshot(Browser.Driver); 
                throw;
            }
        }

        [Fact]
        public void Test2()
        {

        }
    }
}