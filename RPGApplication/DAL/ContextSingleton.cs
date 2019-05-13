using RPGApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPGApplication.DAL
{
    public class ContextSingleton
    {

        private static Context ctx;

        public static Context GetInstance()
        {

            if (ctx == null)
            {
                ctx = new Context();
            }
            return ctx;
        }


    }
}