using RPGApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPGApplication.DAL
{



    public class WeaponDAO
    {

        private static Context ctx = ContextSingleton.GetInstance();


        public static Weapon Get(int? id)
        {
            Weapon weapon = new Weapon();

            try
            {
                weapon = ctx.Weapons.Find(id);
            }
            catch (Exception e) { }

            return weapon;

        }


        public static Weapon GetByName(Weapon weapon)
        {
            return ctx.Weapons.FirstOrDefault(p => p.Name.Equals(weapon.Name));
        }


        public static List<Weapon> GetAll()
        {

            List<Weapon> armourList = new List<Weapon>();

            try
            {
                armourList = ctx.Weapons.ToList();
            }
            catch (Exception e) { }

            return armourList;
        }

        public static bool Save(Weapon weapon)
        {
            if (GetByName(weapon) == null)
            {
                ctx.Weapons.Add(weapon);
                ctx.SaveChanges();
                return true;
            }

            return false;

        }

        public static void Update(Weapon weapon)
        {
            ctx.Entry(weapon).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }


        public static void Remove(Weapon weapon)
        {
            ctx.Weapons.Remove(weapon);
            ctx.SaveChanges();
        }

    }
}