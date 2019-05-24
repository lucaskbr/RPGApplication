using RPGApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPGApplication.DAL
{
    public class ItemRarityDAO
    {

        private static Context ctx = ContextSingleton.GetInstance();


        public static ItemRarity Get(int? id)
        {
            ItemRarity itemRarity = new ItemRarity();

            try
            {
                itemRarity = ctx.ItemsRarity.Find(id);
            }
            catch (Exception e) { }

            return itemRarity;

        }


        public static ItemRarity GetByName(ItemRarity itemRarity)
        {
            return ctx.ItemsRarity.FirstOrDefault(p => p.Name.Equals(itemRarity.Name));
        }


        public static List<ItemRarity> GetAll()
        {

            List<ItemRarity> itemsList = new List<ItemRarity>();

            try
            {
                itemsList = ctx.ItemsRarity.ToList();
            }
            catch (Exception e) { }

            return itemsList;
        }

        public static bool Save(ItemRarity itemRarity)
        {
            if (GetByName(itemRarity) == null)
            {
                ctx.ItemsRarity.Add(itemRarity);
                ctx.SaveChanges();
                return true;
            }

            return false;

        }

        public static void Update(ItemRarity itemRarity)
        {
            ctx.Entry(itemRarity).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }


        public static void Remove(ItemRarity itemRarity)
        {
            ctx.ItemsRarity.Remove(itemRarity);
        }


    }
}