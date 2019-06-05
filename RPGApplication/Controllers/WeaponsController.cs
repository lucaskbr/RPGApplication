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
using RPGApplication.Utils;

namespace RPGApplication.Controllers
{
    [VerifyAccessLevel]
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
            ViewBag.ItemRarity = new SelectList(ItemRarityDAO.GetAll(), "ItemRarityId", "Name");
            return View();
        }

        // POST: Weapons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase image, [Bind(Include = "ItemId,Name,Description,RequiredLevel,Price,ItemRarity,Damage,Critical")] Weapon weapon)
        {

            if (ModelState.IsValid)
            {
                weapon.ItemRarity = ItemRarityDAO.Get(weapon.ItemRarity.ItemRarityId);
                if (weapon.ItemRarity != null)
                {
                    weapon = SetAnImageToNewWeapon(weapon, image);
                    WeaponDAO.Save(weapon);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("error", "Necessário selecionar a raridade do item");
                }
            }
            ViewBag.ItemRarity = new SelectList(ItemRarityDAO.GetAll(), "ItemRarityId", "Name");
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

            ViewBag.ItemRarity = new SelectList(ItemRarityDAO.GetAll(), "ItemRarityId", "Name");
            return View(weapon);
        }

        // POST: Weapons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,Name,Description,RequiredLevel,Price,ItemRarity,Damage,Critical")] Weapon weapon)
        {

            weapon.ItemRarity = ItemRarityDAO.Get(weapon.ItemRarity.ItemRarityId);

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

            if (weapon.ItemRarity == null)
            {
                ModelState.AddModelError("error", "Necessário selecionar a raridade do item");
            }

            ViewBag.ItemRarity = new SelectList(ItemRarityDAO.GetAll(), "ItemRarityId", "Name");
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
            FileUploadHandling.RemoveFile(weapon.Image);
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



        private Weapon SetAnImageToNewWeapon(Weapon weapon, HttpPostedFileBase image)
        {

            if (image != null)
            {
                string newImageName = FileUploadHandling.RenameFile(image, weapon.Name);
                FileUploadHandling.SaveFile(image, newImageName, "Weapons");
                weapon.Image = "Weapons/" + newImageName;
            }
            else
            {
                weapon.Image = "Weapons/default.jpg";
            }

            return weapon;

        }



    }
}
