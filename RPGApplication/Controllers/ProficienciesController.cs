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
    public class ProficienciesController : Controller
    {
        
        // GET: Proficiencies
        public ActionResult Index()
        {
            return View(ProficiencyDAO.GetAll());
        }

        // GET: Proficiencies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proficiency proficiency = ProficiencyDAO.Get(id);
            if (proficiency == null)
            {
                return HttpNotFound();
            }
            return View(proficiency);
        }

        // GET: Proficiencies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proficiencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProficiencyId,Name")] Proficiency proficiency)
        {
            if (ModelState.IsValid)
            {
                if (ProficiencyDAO.Save(proficiency)) {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("error", "A proficiencia já existe");
            }

            return View(proficiency);
        }

        // GET: Proficiencies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proficiency proficiency = ProficiencyDAO.Get(id);
            if (proficiency == null)
            {
                return HttpNotFound();
            }
            return View(proficiency);
        }

        // POST: Proficiencies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProficiencyId,Name")] Proficiency proficiency)
        {
            if (ModelState.IsValid)
            {

                Proficiency proficiencyInDataBase = ProficiencyDAO.Get(proficiency.ProficiencyId);

                proficiencyInDataBase.Name = proficiency.Name;

                if (ProficiencyDAO.Update(proficiencyInDataBase)) {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("error", "A proficiencia já existe");
            }
            return View(proficiency);
        }

        // GET: Proficiencies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proficiency proficiency = ProficiencyDAO.Get(id);
            if (proficiency == null)
            {
                return HttpNotFound();
            }
            return View(proficiency);
        }

        // POST: Proficiencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proficiency proficiency = ProficiencyDAO.Get(id);
            ProficiencyDAO.Remove(proficiency);
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
