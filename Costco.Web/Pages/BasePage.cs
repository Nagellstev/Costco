using Costco.Core.Browser;

namespace Costco.Web.Pages
{
    public class BasePage 
    {
        public virtual string? Url { get; }
        public virtual void GoToPage()
        {
        }
    }
}
