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

        public static List<Character> GetAll()
        {
            List<Character> characterList = new List<Character>();
            try
            {
                characterList = ctx.Characters.ToList();
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