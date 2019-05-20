using RPGApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPGApplication.DAL
{
    public class ProficiencyDAO
    {


        private static Context ctx = ContextSingleton.GetInstance();


        public static Proficiency Get(int? id)
        {
            Proficiency proficiency = new Proficiency();

            try
            {
                proficiency = ctx.Proficiencys.Find(id);
            }
            catch (Exception e) { }

            return proficiency;

        }


        public static Proficiency GetByName(Proficiency proficiency)
        {
            return ctx.Proficiencys.FirstOrDefault(p => p.Name.Equals(proficiency.Name));
        }


        public static List<Proficiency> GetAll()
        {

            List<Proficiency> proficiencyList = new List<Proficiency>();

            try
            {
                proficiencyList = ctx.Proficiencys.ToList();
            }
            catch (Exception e) { }

            return proficiencyList;
        }

        public static bool Save(Proficiency proficiency)
        {
            if (GetByName(proficiency) == null) {
                ctx.Proficiencys.Add(proficiency);
                ctx.SaveChanges();
                return true;
            }

            return false;

        }

        public static void Update(Proficiency proficiency) {
            ctx.Entry(proficiency).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }



    }
}