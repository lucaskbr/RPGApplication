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

        [Required]
        public Character Attacker { get; set; }

        [Required]
        public int DamageDone { get; set; }


        public Attack() { }


        public Attack(Character attacker, int damageDone) {
            this.Attacker = attacker;
            this.DamageDone = damageDone;
        }


    }
}