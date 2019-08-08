﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Repository;

namespace Okapia.Helpers
{
    public class AuthorizeFilter : ActionFilterAttribute
    {
        private readonly IAuthHelper _authHelper;
        private readonly OkapiaContext _okapiaContext;

        public AuthorizeFilter(IAuthHelper authHelper, OkapiaContext okapiaContext)
        {
            _authHelper = authHelper;
            _okapiaContext = okapiaContext;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var roles = Constants.Roles;
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.HttpContext.Response.Redirect("/Administrator/User/Login");
            }

            var controller = context.RouteData.Values["Controller"].ToString();
            var controllerId = _okapiaContext.Controllers.First(x => x.Name == controller).Id;
            var userInfo = _authHelper.GetCurrnetUserInfo();
            var authId = userInfo.AuthUserId;
            var employeeId = userInfo.ReferenceRecordId;
            var roleId = userInfo.Role;

            if (roleId == roles.Administrator.Id) return;

            if (roleId == roles.User.Id || roleId == roles.Job.Id || roleId == roles.Club.Id)
            {
                context.HttpContext.Response.Redirect("/Account/AccessDenied");
            }

            var employeeControllers =
                _okapiaContext.EmployeeControllers.Where(x => x.EmployeeId == employeeId).ToList();
            if (employeeControllers.All(x => x.ControllerId != controllerId))
            {
                context.HttpContext.Response.Redirect("/Account/AccessDenied");
            }

            base.OnActionExecuting(context);
        }
    }
}