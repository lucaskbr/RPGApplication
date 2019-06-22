using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RPGApplication.Models
{
    [Table("combat")]
    public class Combat
    {
        [Key]
        public int CombatId { get; set; }

        [Display(Name = "Desafiante:")]
        public Character Challanger { get; set; }

        [Display(Name = "Desafiado:")]
        public Character Challanged { get; set; }

        [Display(Name = "Ataques:")]
        public List<Attack> Attacks { get; set; }

        [Display(Name = "Vencedor:")]
        public Character Winner { get; set; }



        public Combat() { }


        public Combat(Character challanger, Character challanged, List<Attack> attacks, Character winner)
        {
            this.Challanger = challanger;
            this.Challanged = challanged;
            this.Attacks = attacks;
            this.Winner = winner;
        }
        
    }
}