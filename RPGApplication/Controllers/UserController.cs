using RPGApplication.DAL;
using RPGApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RPGApplication.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register() {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user) {

            Character character = new Character(user.Login);
            user.Character = character;

            UserDAO.Save(user);
            return RedirectToAction("Register");
        }


        public ActionResult Edit(int? id) {

            if(id != null)
            {
                ViewBag.User = UserDAO.GetUserById(id);
                return View();
            }
            return RedirectToAction("ListUsers"); 
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {

            User oldUser = UserDAO.GetUserById(user.UserId);

            oldUser.Email = user.Email;
            oldUser.Name = user.Name;
            oldUser.LastName = user.LastName;
           
            UserDAO.Update(oldUser);
            return RedirectToAction("ListUsers");
        }




        public ActionResult ListUsers() {
            ViewBag.Users = UserDAO.GetAll();
            return View();
        }

        public ActionResult DisableOrEnable(int? id) {

            if (id != null) {
                UserDAO.DisableOrEnable(UserDAO.GetUserById(id));
            }
            return RedirectToAction("ListUsers");
        }

       
    }
}