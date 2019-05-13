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


       /* public static bool AddCharacterInDataBase(User user) {
            if (GetCharacterByUserLogin(user) == null) {
               ctx.Users.
            }
        }*/

        public static Character GetByUserLogin(User user) {

            return null; // ctx.Users.Include("character").FirstOrDefault(x => x.Login.Equals(user.Login)).character; 
        }


        public static Character Get(int id) {
            return ctx.Characters.Find(id);
        }

        public static List<Character> GetAll() {
            return ctx.Characters.ToList();
        }





    }
}