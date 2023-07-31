using Costco.Core.Browser;
using Costco.Web.Pages;

namespace Costco.Web.Steps
{
    public class WarehousePageSteps
    {
        private WarehousePage warehousePage;

        public WarehousePageSteps(WarehousePage warehousePage)
        {
            this.warehousePage = warehousePage;
        }

        public string GetName()
        {
            Waiters.WaitUntilElementExists(warehousePage.NameLocator);
            return warehousePage.Name.Text[..warehousePage.Name.Text.IndexOf(" ")];
        }

        public string GetAddress()
        {
            Waiters.WaitUntilElementExists(warehousePage.NameLocator);
            return warehousePage.Address.Text;
        }
    }
}
