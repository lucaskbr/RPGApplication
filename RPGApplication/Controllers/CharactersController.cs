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
    public class CharactersController : Controller
    {
       
        [HttpPost]
        public ActionResult GenerateCharacter(HttpPostedFileBase characterImage)
        {

            User user = UserDAO.Get(Convert.ToInt32(SessionManager.GetUserId()));

            if (user.Character == null)
            {

                Character newCharacter = CreateAnCharacterToUser(user);
                newCharacter = SetAnImageToCharacter(characterImage, newCharacter);
                user.Character = newCharacter;
                UserDAO.Update(user);
            }

            SessionManager.SetCharacterId(user);

            return RedirectToAction("Index", "Home", null);
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


        public ActionResult ManageItemInUse(int itemInBagId)
        {

            ItemInBag itemInBag = ItemInBagDAO.Get(itemInBagId);

            itemInBag.Equipped = !itemInBag.Equipped;

            ItemInBagDAO.Update(itemInBag);

            return RedirectToAction("Index", "Home", null);
        }


        public ActionResult SellItem(int characterId, int itemInBagId)
        {

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

            int characterId = Convert.ToInt32(SessionManager.GetCharacterId());
            Character character = CharacterDAO.GetAllInformations(characterId);

            Item itemToBuy = ItemDAO.Get(itemId);

            if (character.Coins < itemToBuy.Price || character.Level < itemToBuy.RequiredLevel)
            {
                FlashMessage.Danger("Erro: ", "Você não possuí moedas suficientes para realizar a compra ou não tem level suficiente para adquirir o item");
                return RedirectToAction("Market", "Home", null);
            }

            foreach (var itemInBag in character.Bag.ItemsInBag)
            {
                if (itemInBag.Item == null)
                {
                    character.Coins -= itemToBuy.Price;
                    itemInBag.Item = itemToBuy;
                    CharacterDAO.Update(character);
                    return RedirectToAction("Index", "Home", null);
                }
            }
            FlashMessage.Danger("Erro: ", "Você não possuí slots vazios na mochila para armazenar o item");
            return RedirectToAction("Market", "Home", null);

        }


        public ActionResult IsCharacterEnvolved()
        {
            Character character = CharacterDAO.Get(Convert.ToInt32(SessionManager.GetCharacterId()));

            if (character.Experience >= character.Level * 10)
            {
                character.Level += 1;
                character.Experience = 0;
                character.Coins += 10;
                character.LifePoints += 5;
                character.AttributePoints += 1;
                CharacterDAO.Update(character);
                FlashMessage.Confirmation("Evolução ", "Parabéns, você passou de level!!!");
                return RedirectToAction("Index", "Home");
            }

            FlashMessage.Confirmation(":) ", "Parabéns, você ganhou esse duelo!!!");
            return RedirectToAction("Ranking", "Home");
        }


        private List<ItemInBag> CreateItemsInBag(Bag bag)
        {

            List<ItemInBag> itemsInBag = new List<ItemInBag>();

            for (int i = 0; i < bag.slots; i++)
            {
                ItemInBag itemInBag = new ItemInBag();
                itemInBag.Item = null;
                itemInBag.Equipped = false;
                itemInBag.Bag = bag;
                itemsInBag.Add(itemInBag);
            }
            return itemsInBag;
        }

        private Bag CreateAnBagToAnCharacter()
        {
            Bag bag = new Bag();
            bag.ItemsInBag = CreateItemsInBag(bag);
            return bag;
        }

        private List<AttributeInCharacter> CreateAttributesToAnCharacter()
        {
            return ProficiencyDAO.GetAll().ConvertAll(x => new AttributeInCharacter(x));
        }

        private Character CreateAnCharacterToUser(User user)
        {
            return new Character(user.Login, CreateAttributesToAnCharacter(), CreateAnBagToAnCharacter());
        }


        private Character SetAnImageToCharacter(HttpPostedFileBase characterImage, Character character)
        {

            if (characterImage != null)
            {
                string newImageName = FileUploadHandling.RenameFile(characterImage, character.Name);
                FileUploadHandling.SaveFile(characterImage, newImageName, "Characters");
                character.Image = "Characters/" + newImageName;
            }

            return character;

        }

    }
}