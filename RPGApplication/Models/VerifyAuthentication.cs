using RPGApplication.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RPGApplication.Models
{
    public class VerifyAuthentication : ActionFilterAttribute
    {


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            string userId = SessionManager.GetUserId();


            if (userId.Equals(string.Empty))
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Login" }));
            base.OnActionExecuting(filterContext);
        }


    }
}