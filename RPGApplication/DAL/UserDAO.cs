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

        public static bool Save(User user)
        {
            if (GetUserByLogin(user) == null)
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
            user = GetUserById(user.UserId);
            user.ActiveAccount = !user.ActiveAccount;
            ctx.SaveChanges();
        }

        public static List<User> GetAll()
        {
            return ctx.Users.ToList();
        }

        public static List<User> GetAllUsersActives()
        {
            return ctx.Users.Where(x => x.ActiveAccount == true).ToList();
        }

        public static User GetUserById(int? id)
        {
            if (id != null)
            {
                return ctx.Users.Find(id);
            }
            return null;
        }

        public static User GetUserByLogin(User user)
        {
            return ctx.Users.FirstOrDefault(x => x.Login.Equals(user.Login));
        }

    }
}