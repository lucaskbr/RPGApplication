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


        public Attack(Character attacker, Character attacked)
        {
            this.Attacker = attacker;
            this.DamageDone = CombatDamageCalculator(attacker, attacked);
        }

        private int CombatDamageCalculator(Character attacker, Character attacked)
        {
            return Convert.ToInt32(AttackWasDodged(attacked) ? (AttackHasCrit(attacker) * attacker.MakeAttack()) - attacked.MakeDefense() : 0);
        }


        private double ChanceOfSpecialMove()
        {
            Random random = new Random();
            return Convert.ToDouble(String.Format("{0:0.##}", random.NextDouble() * (100 - 1) + 1));
        }

        private int AttackHasCrit(Character attacker)
        {
            if (ChanceOfSpecialMove() <= attacker.ChanceOfCrit())
                return 2;
            return 1;
        }

        private bool AttackWasDodged(Character attacked)
        {
            if (ChanceOfSpecialMove() <= attacked.ChanceOfDodge())
                return true;
            return false;
        }

    }
}