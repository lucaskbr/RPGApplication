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
        // GET: Home
        public ActionResult Index(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Character character = CharacterDAO.GetAllInformations(id);
            
            if (character == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //ViewBag.Armour = ItemFilter.GetArmours(character.Bag.ItemsInBag);
            //ViewBag.Weapons = weaponList;
            return View(character);
        }






    }
}