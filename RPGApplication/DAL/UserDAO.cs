using RPGApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPGApplication.DAL
{
    public class UserDAO
    {

        private static Context ctx = ContextSingleton.GetInstance();


        public static User Get(int? id)
        {
            if (id != null)
            {
                return ctx.Users.Include("Character").FirstOrDefault(x => x.UserId == id);
            }
            return null;
        }


        public static User GetByLogin(User user)
        {
            return ctx.Users.Include("Character").FirstOrDefault(x => x.Login.Equals(user.Login));
        }

        public static User GetByLoginAndPassword(User user)
        {
            return ctx.Users.Include("Character").FirstOrDefault(x => x.Login.Equals(user.Login) && x.Password.Equals(user.Password));
        }



        public static List<User> GetAll()
        {
            List<User> userList = new List<User>();

            try {
                userList = ctx.Users.ToList();
            }
            catch (Exception e) {

            }
            return userList;
        }

        public static List<User> GetAllUsersActives()
        {
            return ctx.Users.Where(x => x.ActiveAccount == true).ToList();
        }

        
        public static bool Save(User user)
        {
            if (GetByLogin(user) == null)
            {
                ctx.Users.Add(user);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static void Update(User user)
        {
            ctx.Entry(user).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }


        public static void DisableOrEnable(User user)
        {
            user = Get(user.UserId);
            user.ActiveAccount = !user.ActiveAccount;
            ctx.SaveChanges();
        }
        
    }
}