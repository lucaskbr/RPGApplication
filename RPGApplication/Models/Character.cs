using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RPGApplication.Models
{
    [Table("character")]
    public class Character
    {

        [Key]
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public int LifePoints { get; set; }
        public int Energy { get; set; }
        public int Level { get; set; }
        public double Experience { get; set; }
        public List<AttributeInCharacter> AttributesInCharacter { get; set; }
        public Bag Bag { get; set; }
       /* public List<Skill> Skills { get; set; }*/
        public List<Coin> Coins { get; set; }
        public int RankingPoints { get; set; }


        public Character(string name)
        {
            this.Name = name;
            this.LifePoints = 5;

        }

       /* public void MakeAnAttack() {

            foreach (var item in Bag.Itens.ToList())
            {
                item.
            }
        }
        */




    }
}