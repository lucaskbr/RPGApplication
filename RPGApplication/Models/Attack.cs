using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RPGApplication.Models
{
    [Table("attack")]
    public class Attack
    {
        [Key]
        public int AttackId { get; set; }
        public Character Attacker { get; set; }
        public Character Attacked { get; set; }
        public int DamageDone { get; set; }
        public bool Dodged { get; set; }

        public Attack() { }


        public Attack(Character attacker, Character attacked, int damageDone, bool dodged) {
            this.Attacker = attacker;
            this.Attacked = attacked;
            this.DamageDone = damageDone;
            this.Dodged = dodged;
        }


    }
}