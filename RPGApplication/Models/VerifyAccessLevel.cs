using RPGApplication.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Vereyon.Web;

namespace RPGApplication.Models
{
    public class VerifyAccessLevel : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            string userAccess = SessionManager.GetAccessLevel();

            if (userAccess.Equals(string.Empty))
            {
                FlashMessage.Danger("Erro: ", "Você não está logado!!!");
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Login" }));
            }
            else if (userAccess.Equals("0"))
            {
                FlashMessage.Danger("Erro: ", "Você não é um administrador para acessar esta página.");
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index" }));
            }
            base.OnActionExecuting(filterContext);
        }

    }
}