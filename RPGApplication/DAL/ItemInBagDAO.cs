using RPGApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPGApplication.DAL
{
    public class ItemInBagDAO
    {

        private static Context ctx = ContextSingleton.GetInstance();

        public static ItemInBag Get(int? id)
        {
            ItemInBag itemInBag = new ItemInBag();

            try
            {
                itemInBag = ctx.ItemsInBags.Find(id);
            }
            catch (Exception e) { }

            return itemInBag;

        }

        public static void Update(ItemInBag itemInBag)
        {
            ctx.Entry(itemInBag).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

    }
}
