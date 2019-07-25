using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Okapia.Application.Contracts;
using Okapia.Domain.ViewModels.EmployeeController;

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

        public ViewViewComponentResult Invoke()
        {
            var currentUserinfo = _authHelper.GetCurrnetUserInfo();
            if (!currentUserinfo.IsAuthorized) return View("DefaultN", new List<AccessControllerViewModel>());
            var employeeId = currentUserinfo.ReferenceRecordId;
            var accessControllers = _employeeApplication.GetEmployeeAccessControllers(employeeId);
            ViewData["Auth"] = _authHelper.GetCurrnetUserInfo();
            return View("DefaultN", accessControllers);
        }
    }
}