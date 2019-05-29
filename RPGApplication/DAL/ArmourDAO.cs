using RPGApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPGApplication.DAL
{
    public class ArmourDAO
    {

        private static Context ctx = ContextSingleton.GetInstance();


        public static Armour Get(int? id)
        {
            Armour armour = new Armour();

            try
            {
                armour = ctx.Armours.Find(id);
            }
            catch (Exception e) { }

            return armour;

        }


        public static Armour GetByName(Armour armour)
        {
            return ctx.Armours.FirstOrDefault(p => p.Name.Equals(armour.Name));
        }

        public static List<Armour> GetAll()
        {

            List<Armour> armourList = new List<Armour>();

            try
            {
                armourList = ctx.Armours.ToList();
            }
            catch (Exception e) { }

            return armourList;
        }

        public static bool Save(Armour armour)
        {
            if (GetByName(armour) == null)
            {
                ctx.Armours.Add(armour);
                ctx.SaveChanges();
                return true;
            }

            return false;

        }

        public static void Update(Armour armour)
        {
            ctx.Entry(armour).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }


        public static void Remove(Armour armour)
        {
            ctx.Armours.Remove(armour);
            ctx.SaveChanges();
        }


    }
}