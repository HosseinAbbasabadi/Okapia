using Microsoft.AspNetCore.Mvc;

namespace Okapia.Areas.Customer.ViewComponents
{
    public class NavigatorViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Default");
        }
    }
}
