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
    public class CombatesController : Controller
    {
        // GET: Combates
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult MakeCombat(int? characterId)
        {


            if (characterId == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            else if (characterId == Convert.ToInt32(SessionManager.GetUserId()))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);


            Character challenger = CharacterDAO.GetAllInformations(Convert.ToInt32(SessionManager.GetUserId()));
            Character challenged = CharacterDAO.GetAllInformations(characterId);

            List<Attack> attacksInCombat = new List<Attack>();

            List<int> lifePointsOfCharacters = new List<int>();
            lifePointsOfCharacters.Add(challenger.GetLife());
            lifePointsOfCharacters.Add(challenged.GetLife());

            int round = 1;
            do
            {
                Attack attack;

                if (round % 2 != 0)
                {
                    attack = new Attack(challenger, challenged);
                    lifePointsOfCharacters[0] -= attack.DamageDone;
                }
                else
                {
                    attack = new Attack(challenged, challenger);
                    lifePointsOfCharacters[1] -= attack.DamageDone;
                }

                attacksInCombat.Add(attack);
                round++;
            }
            while (lifePointsOfCharacters[0] != 0 || lifePointsOfCharacters[1] != 0);

            if (lifePointsOfCharacters[0] == 0)
            {
                Combat combat = new Combat(challenger, challenged, attacksInCombat, challenger);
            }
            else
            {
                Combat combat = new Combat(challenged, challenger, attacksInCombat, challenged);
            }

            return View();
        }






    }
}