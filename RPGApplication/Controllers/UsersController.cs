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
using System.Net.Http;
using Newtonsoft.Json;

namespace RPGApplication.Controllers
{

    public class UsersController : Controller
    {
        [VerifyAccessLevel]
        // GET: Users
        public ActionResult Index()
        {
            return View(UserDAO.GetAll());
        }

        [VerifyAccessLevel]
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

        [VerifyAccessLevel]
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

            if (/*ModelState.IsValid*/ true)
            {
                UserDAO.Save(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult GetRandomName(User user)

        {
            user.Login = GetNameFromAPI()[0];
            TempData["user"] = user;
            return RedirectToAction("Register", "Home");
        }

        public List<string> GetNameFromAPI()
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://names.drycodes.com/1");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var responseTask = client.GetAsync(client.BaseAddress);
            responseTask.Wait();

            var result = responseTask.Result;

            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();


                return JsonConvert.DeserializeObject<List<string>>(readTask.Result);

            }
            return null;

        }



        [VerifyAccessLevel]
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

        [VerifyAccessLevel]
        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Name,LastName,Login,Email,Password,UserAcess,ActiveAccount")] User user)
        {
            if (ModelState.IsValid)
            {

                User userInDataBase = UserDAO.Get(user.UserId);
                userInDataBase.Name = user.Name;
                userInDataBase.LastName = user.LastName;
                userInDataBase.Login = user.Login;
                userInDataBase.Email = user.Email;
                userInDataBase.Password = user.Password;
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

        [VerifyAccessLevel]
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



    }
}

