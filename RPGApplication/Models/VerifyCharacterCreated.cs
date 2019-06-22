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
    public class VerifyCharacterCreated : ActionFilterAttribute
    {


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            string characterId = SessionManager.GetCharacterId();

            if (characterId.Equals(string.Empty))
            {
                FlashMessage.Danger("Erro: ", "É necessário criar um personagem para acessar esta página");
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "GenerateCharacter" }));
            }
            base.OnActionExecuting(filterContext);
        }


    }
}