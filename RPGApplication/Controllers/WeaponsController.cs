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
    public class WeaponsController : Controller
    {


        // GET: Weapons
        public ActionResult Index()
        {
            return View(WeaponDAO.GetAll());
        }

        // GET: Weapons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weapon weapon = WeaponDAO.Get(id);
            if (weapon == null)
            {
                return HttpNotFound();
            }
            return View(weapon);
        }

        // GET: Weapons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Weapons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId,Name,Deion,RequiredLevel,Price,Damage,Critical")] Weapon weapon)
        {
            if (ModelState.IsValid)
            {
                WeaponDAO.Save(weapon);
                return RedirectToAction("Index");
            }

            return View(weapon);
        }

        // GET: Weapons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weapon weapon = WeaponDAO.Get(id);
            if (weapon == null)
            {
                return HttpNotFound();
            }
            return View(weapon);
        }

        // POST: Weapons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,Name,Deion,RequiredLevel,Price,Damage,Critical")] Weapon weapon)
        {
            if (ModelState.IsValid)
            {

                Weapon weaponInDataBase = WeaponDAO.Get(weapon.ItemId);
                weaponInDataBase.Name = weapon.Name;
                weaponInDataBase.ItemRarity = weapon.ItemRarity;
                weaponInDataBase.Price = weapon.Price;
                weaponInDataBase.RequiredLevel = weapon.RequiredLevel;
                weaponInDataBase.Description = weapon.Description;
                weaponInDataBase.Damage = weapon.Damage;
                weaponInDataBase.Critical = weapon.Critical;

                WeaponDAO.Update(weaponInDataBase);

                return RedirectToAction("Index");
            }
            return View(weapon);
        }

        // GET: Weapons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weapon weapon = WeaponDAO.Get(id);
            if (weapon == null)
            {
                return HttpNotFound();
            }
            return View(weapon);
        }

        // POST: Weapons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Weapon weapon = WeaponDAO.Get(id);
            WeaponDAO.Remove(weapon);
            return RedirectToAction("Index");
        }
        /*
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/

    }
}
