using RPGApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPGApplication.DAL
{
    public class CombatDAO
    {


        private static Context ctx = ContextSingleton.GetInstance();


        public static Combat Get(int? id)
        {
            Combat combat = new Combat();

            try
            {
                combat = ctx.Combats.Find(id);
            }
            catch (Exception e) { }

            return combat;

        }


        public static List<Combat> GetAll()
        {

            List<Combat> combatList = new List<Combat>();

            try
            {
                combatList = ctx.Combats.ToList();
            }
            catch (Exception e) { }

            return combatList;
        }


        public static List<Combat> GetAllCombatsByCharacterId(int? characterId)
        {

            List<Combat> combatList = new List<Combat>();

            try
            {
                combatList = ctx.Combats
                    .Include("Challanger")
                    .Include("Challanged")
                    .Include("Attacks")
                    .Where(x => x.Challanger.CharacterId == characterId || x.Challanged.CharacterId == characterId)
                    .ToList();
            }
            catch (Exception e) { }

            return combatList;
        }


        public static void Save(Combat combat)
        {
            ctx.Combats.Add(combat);
            ctx.SaveChanges();
        }

        public static void Update(Combat combat)
        {
            ctx.Entry(combat).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }


        public static void Remove(Combat combat)
        {
            ctx.Combats.Remove(combat);
            ctx.SaveChanges();
        }

    }
}