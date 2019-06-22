using RPGApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPGApplication.DAL
{
    public class CharacterDAO
    {

        private static Context ctx = ContextSingleton.GetInstance();


        public static Character Get(int? id)
        {
            return ctx.Characters.Find(id);
        }


        public static Character GetByUserLogin(User user)
        {
            return ctx.Characters.FirstOrDefault(x => x.Name.Equals(user.Login));
        }


        public static Character GetAllInformations(int? id)
        {
            if (id != null) {
                 return ctx.Characters
                    .Include("AttributesInCharacter.Proficiency")
                    .Include("Bag.ItemsInBag.Item.ItemRarity")
                    .FirstOrDefault(x => x.CharacterId == id); 
            }
            return null;
        }
        
        public static List<Character> GetAll()
        {
            List<Character> characterList = new List<Character>();
            try
            {
                characterList = ctx.Characters.OrderBy(x => x.Name).ToList();
            }
            catch (Exception e)
            {
            }
            return characterList;
        }


        public static void Save(Character character)
        {
            ctx.Characters.Add(character);
            ctx.SaveChanges();
        }


        public static void Update(Character character)
        {
            ctx.Entry(character).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }



    }
}