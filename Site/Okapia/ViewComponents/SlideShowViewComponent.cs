using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;

namespace Okapia.ViewComponents
{
    public class SlideShowViewComponent : ViewComponent
    {
        private readonly ISlideApplication _slideApplication;

        public SlideShowViewComponent(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }
        
        public IViewComponentResult Invoke()
        {
            var slideShow = _slideApplication.GetSlideShow();
            return View("_SlideShow", slideShow);
        }
    }
}