using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;

namespace Okapia.Areas.Administrator.ViewComponents
{
    public class NavigatorViewComponent : ViewComponent
    {
        private readonly IAuthHelper _authHelper;
        private readonly IEmployeeApplication _employeeApplication;

        public NavigatorViewComponent(IEmployeeApplication employeeApplication, IAuthHelper authHelper)
        {
            _employeeApplication = employeeApplication;
            _authHelper = authHelper;
        }

        public IViewComponentResult Invoke()
        {
            var employeeId = _authHelper.GetCurrnetUserInfo().ReferenceRecordId;
            var accessControllers = _employeeApplication.GetEmployeeAccessControllers(employeeId);
            ViewData["Auth"] = _authHelper.GetCurrnetUserInfo();
            return View("DefaultN", accessControllers);
        }
    }
}