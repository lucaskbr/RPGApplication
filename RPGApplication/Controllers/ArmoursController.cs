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
    public class ArmoursController : Controller
    {

        // GET: Armours
        public ActionResult Index()
        {
            return View(ArmourDAO.GetAll());
        }

        // GET: Armours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armour armour = ArmourDAO.Get(id);
            if (armour == null)
            {
                return HttpNotFound();
            }
            return View(armour);
        }

        // GET: Armours/Create
        public ActionResult Create()
        {
            ViewBag.ItemRarity = new SelectList(ItemRarityDAO.GetAll(), "ItemRarityId", "Name");
            return View();
        }

        // POST: Armours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase image, [Bind(Include = "ItemId,Name,Description,RequiredLevel,Price,ItemRarity,Defense,Evasion")] Armour armour)
        {
        
            armour.ItemRarity = ItemRarityDAO.Get(armour.ItemRarity.ItemRarityId);

            if (ModelState.IsValid)
            {

                if (image != null)
                {

                    string newImageName = FileUploadHandling.RenameFile(image, armour.Name);
                    FileUploadHandling.SaveFile(image, newImageName, "Armours");
                    armour.Image = "Armours/" + newImageName;
                }
                else
                {
                    armour.Image = "Armours/default.jpg";
                }

                ArmourDAO.Save(armour);
                return RedirectToAction("Index");
            }

            if (armour.ItemRarity == null)
            {
                ModelState.AddModelError("error", "Necessário selecionar a raridade do item");
            }

            ViewBag.ItemRarity = new SelectList(ItemRarityDAO.GetAll(), "ItemRarityId", "Name");
            return View(armour);
        }

        // GET: Armours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armour armour = ArmourDAO.Get(id);
            if (armour == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemRarity = new SelectList(ItemRarityDAO.GetAll(), "ItemRarityId", "Name");
            return View(armour);
        }

        // POST: Armours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,Name,Description,RequiredLevel,Price,ItemRarity,Defense,Evasion")] Armour armour)
        {

            armour.ItemRarity = ItemRarityDAO.Get(armour.ItemRarity.ItemRarityId);

            if (ModelState.IsValid)
            {
                
                Armour armourInDataBase = ArmourDAO.Get(armour.ItemId);

                armourInDataBase.Name = armour.Name;
                armourInDataBase.ItemRarity = armour.ItemRarity;
                armourInDataBase.Price = armour.Price;
                armourInDataBase.RequiredLevel = armour.RequiredLevel;
                armourInDataBase.Description = armour.Description;
                armourInDataBase.Defense = armour.Defense;
                armourInDataBase.Evasion = armour.Evasion;

                ArmourDAO.Update(armourInDataBase);

                return RedirectToAction("Index");
            }

            if (armour.ItemRarity == null)
            {
                ModelState.AddModelError("error", "Necessário selecionar a raridade do item");
            }

            ViewBag.ItemRarity = new SelectList(ItemRarityDAO.GetAll(), "ItemRarityId", "Name");
            return View(armour);
        }

        // GET: Armours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armour armour = ArmourDAO.Get(id);
            if (armour == null)
            {
                return HttpNotFound();
            }
            return View(armour);
        }

        // POST: Armours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Armour armour = ArmourDAO.Get(id);
            FileUploadHandling.RemoveFile(armour.Image);
            ArmourDAO.Remove(armour);
            return RedirectToAction("Index");
        }
        
      /*  protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
        
    }
}
