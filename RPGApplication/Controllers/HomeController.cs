using Newtonsoft.Json;
using RPGApplication.DAL;
using RPGApplication.Models;
using RPGApplication.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace RPGApplication.Controllers
{
    public class HomeController : Controller
    {
        [VerifyAuthentication]
        public ActionResult Index()
        {
            int userId = Convert.ToInt32(SessionManager.GetUserId());
            User user = UserDAO.Get(userId);

            if (user.Character == null)
            {
                return View("GenerateCharacter");
            }
            Character character = CharacterDAO.GetAllInformations(user.Character.CharacterId);
            return View(character);
        }


        public ActionResult Login()
        {
            if (SessionManager.GetUserId() != string.Empty)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Joke = GetJokeFromAPI();    
            return View();
        }

        public ActionResult LogOff()
        {
            SessionManager.LogOff();
            return RedirectToAction("Login");
        }


        [HttpPost]
        public ActionResult Login([Bind(Include = "Login, Password")] User user)
        {

            if (user.Login == null || user.Password == null)
            {
                ViewBag.Joke = GetJokeFromAPI();
                ModelState.AddModelError("nullFields", "Favor preencher os campos para realizar o login");
                return View(user);
            }

            user = UserDAO.GetByLoginAndPassword(user);

            if (user != null)
            {
                SessionManager.Login(user);
                return RedirectToAction("Index");
            }

            ViewBag.Joke = GetJokeFromAPI();
            ModelState.AddModelError("deniedAuthentication", "Não foi possível autenticar o usuário");
            return View(user);
        }


        public ActionResult Register()
        {
            User user = (User)TempData["user"];
            return View(user);
        }


        [VerifyCharacterCreated]
        public ActionResult Market()
        {
            return View(ItemDAO.GetAll());
        }

        [VerifyCharacterCreated]
        public ActionResult Ranking()
        {
            return View(CharacterDAO.GetAll());
        }

        [VerifyAuthentication]
        public ActionResult CharacterDetails(int? characterId)
        {
            if (characterId == null)
                return RedirectToAction("Ranking");

            return View(CharacterDAO.GetAllInformations(characterId));
        }

        [VerifyAuthentication]
        public ActionResult GenerateCharacter()
        {
            User user = UserDAO.Get(Convert.ToInt32(SessionManager.GetUserId()));

            if (user.Character != null)
            {
                return View("Index");
            }
            return View();
        }



        public Joke GetJokeFromAPI()
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://us-central1-kivson.cloudfunctions.net/charada-aleatoria");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var responseTask = client.GetAsync(client.BaseAddress);
            responseTask.Wait();

            var result = responseTask.Result;

            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();


                return JsonConvert.DeserializeObject<Joke>(readTask.Result);

            }
            return new Joke();

        }


    }
}