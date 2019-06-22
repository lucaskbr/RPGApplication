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
        public static string characterId = "CHARACTER_ID";
        private static string accessLevel = "ACESS_LEVEL";

        public static string Login(User user)
        {

            if (HttpContext.Current.Session[userId] == null)
            {
                HttpContext.Current.Session[userId] = user.UserId;
                HttpContext.Current.Session[accessLevel] = user.AccessLevel;
                HttpContext.Current.Session[characterId] = null;

                if (user.Character != null)
                {
                    HttpContext.Current.Session[characterId] = user.Character.CharacterId;
                }

            }

            return HttpContext.Current.Session[userId].ToString();

        }


        public static void LogOff()
        {

            HttpContext.Current.Session[userId] = null;
            HttpContext.Current.Session[accessLevel] = null;
            HttpContext.Current.Session[characterId] = null;

        }


        public static string GetUserId()
        {
            string id = String.Empty;
            try
            {

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


        public static string GetCharacterId()
        {
            string id = String.Empty;
            try
            {
                id = HttpContext.Current.Session[characterId].ToString();
            }
            catch (Exception e) { }

            return id;
        }



        public static void SetCharacterId(User user)
        {
            HttpContext.Current.Session[characterId] = user.Character.CharacterId;
        }


    }
}