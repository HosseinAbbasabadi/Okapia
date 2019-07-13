using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Okapia.Domain.Models;
using Okapia.Repository;

namespace Okapia.Application.Utilities
{
    public class CustomAuthorization : AuthorizeAttribute, IAuthorizationFilter
    {
        public int ControllerId { get; set; }


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                return;
            }

            var claims = context.HttpContext.User.Claims.ToList();
            var userId = long.Parse(claims.First(x => x.Type == "UserId").Value);
            List<EmployeeController> employeeControllers;
            using (var okapiaContext = new OkapiaContext())
            {
                employeeControllers = okapiaContext.EmployeeControllers.Where(x => x.EmployeeId == userId).ToList();
            }

            if (employeeControllers.Any(x => x.ControllerId == ControllerId))
            {
                return;
            }
            //var q = from ar in db.Areas
            //    join co in db.Controllers
            //        on ar.AreaID equals co.AreaID
            //    join ac in db.Actions on co.ControlerID equals ac.ControllerID
            //    join uac in db.UserActions on ac.ActionID equals uac.ActionID
            //    join usr in db.Users on uac.UserID equals usr.UserID
            //    select new
            //    {
            //        ar.AreaName,
            //        co.ControllerName,
            //        ac.ActionName,
            //        usr.UserName,
            //        uac.HasPermission
            //    };
            //if (!q.Any(x =>
            //    x.UserName == userName && x.ActionName == ActionName && x.ControllerName == ControllerName &&
            //    x.AreaName == Area))
            //{
            //    return false;
            //}

            //return q.SingleOrDefault(x =>
            //    x.UserName == userName && x.ActionName == ActionName && x.ControllerName == ControllerName &&
            //    x.AreaName == Area).HasPermission;
        }
    }
}