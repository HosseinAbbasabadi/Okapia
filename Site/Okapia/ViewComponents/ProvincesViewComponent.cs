using Microsoft.AspNetCore.Mvc;

namespace Okapia.ViewComponents
{
    public class ProvincesViewComponent : ViewComponent
    {
        private readonly ICookieHelper _cookieHelper;

        public ProvincesViewComponent(ICookieHelper cookieHelper)
        {
            _cookieHelper = cookieHelper;
        }

        public IViewComponentResult Invoke()
        {
            var pn = HttpContext.Request.Query["pn"].ToString();
            var province = _cookieHelper.Get("province");
            if (!string.IsNullOrEmpty(pn))
                province = pn;
            if (string.IsNullOrEmpty(province))
                province = "البرز";
            _cookieHelper.Set("province", province);
            ViewData["province"] = province;
            return View("_Provinces");
        }
    }
}