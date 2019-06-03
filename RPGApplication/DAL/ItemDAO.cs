using RPGApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPGApplication.DAL
{
    public class ItemDAO
    {

        private static Context ctx = ContextSingleton.GetInstance();

        public static Item Get(int? id)
        {
            Item item = new Item();

            try
            {
                item = ctx.Items.Find(id);
            }
            catch (Exception e) { }

            return item;

        }


        public static List<Item> GetAll()
        {

            List<Item> armourList = new List<Item>();

            try
            {
                armourList = ctx.Items.Include("ItemRarity").ToList();
            }
            catch (Exception e) { }

            return armourList;
        }

        public static void Update(Item item)
        {
            ctx.Entry(item).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }


        public static void Remove(Item item)
        {
            ctx.Items.Remove(item);
            ctx.SaveChanges();
        }

    }
}