using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RPGApplication.Models;
using RPGApplication.DAL;

namespace RPGApplication.Controllers
{
    public class UsersController : Controller
    {
        private Context db = new Context();

        // GET: Users
        public ActionResult Index()
        {
            return View(UserDAO.GetAll());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = UserDAO.Get(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Name,LastName,Login,Email,Password,UserAcess,ActiveAccount,SignUpDate")] User user)
        {

            user.Character = CreateAnCharacterToUser(user);


            ModelState.SetModelValue("Character", new ValueProviderResult(user.Character, "Character"));
            


            if (ModelState.IsValid)
            {
                /*db.Users.Add(user);
                db.SaveChanges();*/
                UserDAO.Save(user);
                return RedirectToAction("Index");
            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                                       .Where(y => y.Count > 0)
                                       .ToList();
            }

            return View(user);
        }

        private Character CreateAnCharacterToUser(User user) {
            Bag bag = new Bag();
            List<AttributeInCharacter> attributesInCharacter = new List<AttributeInCharacter>();

            foreach (var proficiency in ProficiencyDAO.GetAll())
            {
                AttributeInCharacter attribute = new AttributeInCharacter(proficiency, 0);
                attributesInCharacter.Add(attribute);
            }

            Character character = new Character(user.Login, attributesInCharacter, bag);

            return character;

        }



        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = UserDAO.Get(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Name,LastName,Login,Email,Password,UserAcess,ActiveAccount,SignUpDate")] User user)
        {
            if (ModelState.IsValid)
            {
                UserDAO.Update(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = UserDAO.Get(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = UserDAO.Get(id);
            UserDAO.DisableOrEnable(user);
            /*db.Users.Remove(user);
            db.SaveChanges();*/
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
