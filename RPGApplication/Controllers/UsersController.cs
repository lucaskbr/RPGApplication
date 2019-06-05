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
        // GET: Users
        [VerifyAccessLevel]
        public ActionResult Index()
        {
            return View(UserDAO.GetAll());
        }

        // GET: Users/Details/5
        [VerifyAccessLevel]
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

            if (ModelState.IsValid)
            {
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
        
        // GET: Users/Edit/5
        [VerifyAccessLevel]
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

                User userInDataBase = UserDAO.Get(user.UserId);
                userInDataBase.Name = user.Name;
                userInDataBase.LastName = user.LastName;
                userInDataBase.AccessLevel = user.AccessLevel;
                userInDataBase.ActiveAccount = user.ActiveAccount;

                UserDAO.Update(userInDataBase);

                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        [VerifyAccessLevel]
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
            return RedirectToAction("Index");
        }

        /* protected override void Dispose(bool disposing)
         {
             if (disposing)
             {
                 db.Dispose();
             }
             base.Dispose(disposing);
         }*/


        private List<ItemInBag> CreateItemsInBag(Bag bag)
        {

            List<ItemInBag> itemsInBag = new List<ItemInBag>();

            for (int i = 0; i < bag.slots; i++)
            {
                ItemInBag itemInBag = new ItemInBag();
                itemInBag.Item = null;
                itemInBag.Equipped = false;
                itemInBag.Bag = bag;
                itemsInBag.Add(itemInBag);
            }
            return itemsInBag;
        }

        private Bag CreateAnBagToAnCharacter()
        {
            Bag bag = new Bag();
            bag.ItemsInBag = CreateItemsInBag(bag);
            return bag;
        }

        private List<AttributeInCharacter> CreateAttributesToAnCharacter()
        {
            List<AttributeInCharacter> attributesInCharacter = new List<AttributeInCharacter>();

            foreach (var proficiency in ProficiencyDAO.GetAll())
            {
                AttributeInCharacter attribute = new AttributeInCharacter(proficiency, 0);
                attributesInCharacter.Add(attribute);
            }
            return attributesInCharacter;
        }
        
        private Character CreateAnCharacterToUser(User user)
        {
            return new Character(user.Login, CreateAttributesToAnCharacter(), CreateAnBagToAnCharacter());
        }

    }
}

