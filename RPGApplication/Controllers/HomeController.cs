using RPGApplication.DAL;
using RPGApplication.Models;
using RPGApplication.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RPGApplication.Controllers
{
    public class HomeController : Controller
    {
        [VerifyAuthentication]
        public ActionResult Index()
        {
            int userId = Convert.ToInt16(SessionManager.GetUserId());
            
            Character character = CharacterDAO.GetAllInformations(userId);
            
            if (character == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          
            return View(character);
        }


        public ActionResult Login()
        {
            if (SessionManager.GetUserId() != string.Empty)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "Login, Password")] User user) {
            
            if (user.Login == null || user.Password == null) {
                ModelState.AddModelError("nullFields", "Favor preencher os campos para realizar o login");
                return View(user);
            }

            user = UserDAO.GetByLoginAndPassword(user);

            if (user != null) {
                SessionManager.Login(user);
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("deniedAuthentication", "Não foi possível autenticar o usuário");

            return View(user);
        }


        public ActionResult Register() {
            return RedirectToAction("Create", "Users");
        }


        public ActionResult Market()
        {
            return View(ItemDAO.GetAll());
        }








    }
}