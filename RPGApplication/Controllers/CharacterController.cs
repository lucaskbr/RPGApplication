using RPGApplication.DAL;
using RPGApplication.Models;
using RPGApplication.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vereyon.Web;

namespace RPGApplication.Controllers
{
    public class CharacterController : Controller
    {
        // GET: Character
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddAttributePointToAnCharacter(int characterId, int attributeInCharacterId)
        {

            Character character = CharacterDAO.Get(characterId);

            if (character.AttributePoints > 0)
            {

                AttributeInCharacter attributeInCharacter = AttributeInCharacterDAO.Get(attributeInCharacterId);

                attributeInCharacter.ProficiencyPoints++;
                character.AttributePoints--;

                CharacterDAO.Update(character);
                AttributeInCharacterDAO.Update(attributeInCharacter);
            }
            return RedirectToAction("Index", "Home", null);
        }


        public ActionResult ManageItemInUse(int itemInBagId) {

            ItemInBag itemInBag = ItemInBagDAO.Get(itemInBagId);

            itemInBag.Equipped = !itemInBag.Equipped;

            ItemInBagDAO.Update(itemInBag);

            return RedirectToAction("Index", "Home", null);
        }


        public ActionResult SellItem(int characterId, int itemInBagId) {

            Character character = CharacterDAO.GetAllInformations(characterId);
            ItemInBag itemInBag = ItemInBagDAO.Get(itemInBagId);

            character.Coins += itemInBag.Item.Price;
            CharacterDAO.Update(character);

            itemInBag.Equipped = false;
            itemInBag.Item = null;

            ItemInBagDAO.Update(itemInBag);

            return RedirectToAction("Index", "Home", null);
        }

        public ActionResult BuyItem(int itemId)
        {
         
            int userId = Convert.ToInt16(SessionManager.GetUserId());
            Character character = CharacterDAO.GetAllInformations(userId);

            Item itemToBuy = ItemDAO.Get(itemId);

            if (character.Coins < itemToBuy.Price) {
                FlashMessage.Danger("Erro: ", "Você não possuí moedas suficientes para realizar a compra");
                return RedirectToAction("Market", "Home", null);
            }
            
            foreach (var itemInBag in character.Bag.ItemsInBag)
            {
                if (itemInBag.Item == null) {
                    character.Coins -= itemToBuy.Price;
                    itemInBag.Item = itemToBuy;
                    CharacterDAO.Update(character);
                    return RedirectToAction("Index", "Home", null);
                }
            }
            FlashMessage.Danger("Erro: ", "Você não possuí slots vazios na mochila para armazenar o item");
            return RedirectToAction("Market", "Home", null);

        }




    }

}
