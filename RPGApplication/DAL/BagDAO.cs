using RPGApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPGApplication.DAL
{
    public class BagDAO
    {

        private static Context ctx = ContextSingleton.GetInstance();


        public static Bag Get(int? id)
        {
            Bag bag = new Bag();

            try
            {
                bag = ctx.Bags.Find(id);
            }
            catch (Exception e) { }

            return bag;

        }

        
        public static void Update(Bag bag)
        {
            ctx.Entry(bag).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

    }
}