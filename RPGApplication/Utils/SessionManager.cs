using RPGApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPGApplication.Utils
{
    public class SessionManager
    {

        private static string userId = "USER_ID";
        private static string accessLevel = "ACESS_LEVEL";

        public static string Login(User user)
        {

            if (HttpContext.Current.Session[userId] == null)
            {
                HttpContext.Current.Session[userId] = user.UserId;
                HttpContext.Current.Session[accessLevel] = user.AccessLevel;
            }

            return HttpContext.Current.Session[userId].ToString();

        }

        public static string GetUserId()
        {
            string id = String.Empty;
            try {
    
                id = HttpContext.Current.Session[userId].ToString();
            }
            catch (Exception e) { }
           
            return id;
        }


        public static string GetAccessLevel()
        {
            string access = String.Empty;
            try
            {
                access = HttpContext.Current.Session[accessLevel].ToString();
            }
            catch (Exception e) { }

            return access;
        }

    }
}