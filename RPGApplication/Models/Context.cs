using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RPGApplication.Models
{
    public class Context : DbContext
    {

        

        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Proficiency> Proficiencys { get; set; }
        public DbSet<AttributeInCharacter> AttributeInCharacters { get; set; }
        public DbSet<Bag> Bags { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemRarity> ItemsRarity { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Armour> Armours { get; set; }
        public DbSet<Combat> Combats { get; set; }
        public DbSet<Attack> Attacks { get; set; }



        public Context() : base("RPGAPPLICATION") { }


    }
}