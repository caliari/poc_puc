using System;
using SIG.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SIG.Filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class AuthenticadedAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            
            if (UserModel.AuthenticatedUser == null)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "Login",
                        action = "UserFail"
                    }));
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "Login",
                        action = "UserRedirect"
                    }));
                }
            }
        }
    }
}