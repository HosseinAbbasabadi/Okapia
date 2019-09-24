using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;

namespace Okapia.ViewComponents
{
    public class SlideShowViewComponent : ViewComponent
    {
        private readonly ISlideApplication _slideApplication;
        private readonly ICookieHelper _cookieHelper;

        public SlideShowViewComponent(ISlideApplication slideApplication, ICookieHelper cookieHelper)
        {
            _slideApplication = slideApplication;
            _cookieHelper = cookieHelper;
        }

        public IViewComponentResult Invoke(string pn)
        {
            var slideShow = _slideApplication.GetSlideShow(pn);
            return View("_SlideShow", slideShow);
        }
    }
}