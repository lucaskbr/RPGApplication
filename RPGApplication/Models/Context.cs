using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RPGApplication.Models
{
    public class Context : DbContext
    {


        public Context() : base("RPGAPPLICATION") { }


        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<AttributeInCharacter> AttributeInCharacters { get; set; }
        public DbSet<Bag> Bags { get; set; }
        public DbSet<Coin> Coins { get; set; }



    }
}