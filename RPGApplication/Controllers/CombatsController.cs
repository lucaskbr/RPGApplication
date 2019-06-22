using RPGApplication.DAL;
using RPGApplication.Models;
using RPGApplication.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vereyon.Web;

namespace RPGApplication.Controllers
{
    [VerifyCharacterCreated]
    public class CombatsController : Controller
    {

        // GET: Combates
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CombatHistory()
        {
            return View(CombatDAO.GetAllCombatsByCharacterId(Convert.ToInt32(SessionManager.GetCharacterId())));
        }

        public ActionResult AttackCharacter(int? characterId)
        {


            if (characterId == null || characterId == Convert.ToInt32(SessionManager.GetCharacterId()))
            {
                FlashMessage.Danger("Erro: ", "Você não não pode atacar o seu próprio personagem!!!");
                return RedirectToAction("Ranking", "Home");
            }
               

            Character challenger = CharacterDAO.GetAllInformations(Convert.ToInt32(SessionManager.GetCharacterId()));
            Character challenged = CharacterDAO.GetAllInformations(characterId);


            Character winner = MakeCombat(challenger, challenged);
            GiveBonusFromCombat(winner);

            CharacterDAO.Update(GiveBonusFromCombat(winner));

            if (winner.CharacterId != Convert.ToInt32(SessionManager.GetCharacterId())) {
                FlashMessage.Danger(":/ ", "Você perdeu o combate, tente bater em alguém mais noob!!!");
                return RedirectToAction("Ranking", "Home");
            }

            return RedirectToAction("IsCharacterEnvolved", "Characters");
        }

        private Character GiveBonusFromCombat(Character character)
        {
            character.Coins += 15;
            character.RankingPoints += 10;
            character.Experience += 20;
            return character;
        }


        private Character MakeCombat(Character challenger, Character challenged)
        {
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
                    lifePointsOfCharacters[1] -= attack.DamageDone;
                }
                else
                {
                    attack = new Attack(challenged, challenger);
                    lifePointsOfCharacters[0] -= attack.DamageDone;
                }

                attacksInCombat.Add(attack);
                round++;
            }
            while (CombatIsOver(lifePointsOfCharacters));


            if (lifePointsOfCharacters[0] >= 0)
            {
                CombatDAO.Save(new Combat(challenger, challenged, attacksInCombat, challenger));
                return challenger;
            }

            CombatDAO.Save(new Combat(challenger, challenged, attacksInCombat, challenged));
            return challenged;

        }

        private bool CombatIsOver(List<int> lifePointsOfCharacters)
        {
            return (lifePointsOfCharacters[0] > 0 && lifePointsOfCharacters[1] > 0);

        }
    }
}