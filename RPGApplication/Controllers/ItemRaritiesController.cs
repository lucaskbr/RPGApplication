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
    [VerifyAccessLevel]
    public class ItemRaritiesController : Controller
    {
        // GET: ItemRarities
        public ActionResult Index()
        {
            return View(ItemRarityDAO.GetAll());
        }

        // GET: ItemRarities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemRarity itemRarity = ItemRarityDAO.Get(id);
            if (itemRarity == null)
            {
                return HttpNotFound();
            }
            return View(itemRarity);
        }

        // GET: ItemRarities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemRarities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RarityId,Name")] ItemRarity itemRarity)
        {
            if (ModelState.IsValid)
            {
                ItemRarityDAO.Save(itemRarity);
                return RedirectToAction("Index");
            }

            return View(itemRarity);
        }

        // GET: ItemRarities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemRarity itemRarity = ItemRarityDAO.Get(id);
            if (itemRarity == null)
            {
                return HttpNotFound();
            }
            return View(itemRarity);
        }

        // POST: ItemRarities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemRarityId,Name")] ItemRarity itemRarity)
        {
            if (ModelState.IsValid)
            {
                ItemRarity itemRarityInDataBase = ItemRarityDAO.Get(itemRarity.ItemRarityId);

                itemRarityInDataBase.Name = itemRarity.Name.ToUpper();

                if (ItemRarityDAO.Update(itemRarityInDataBase)) {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("error", "A raridade já está cadastrada");

            }
            return View(itemRarity);
        }

        // GET: ItemRarities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemRarity itemRarity = ItemRarityDAO.Get(id);
            if (itemRarity == null)
            {
                return HttpNotFound();
            }
            return View(itemRarity);
        }

        // POST: ItemRarities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemRarity itemRarity = ItemRarityDAO.Get(id);
            ItemRarityDAO.Remove(itemRarity);

            return RedirectToAction("Index");
        }
        
        /*protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
