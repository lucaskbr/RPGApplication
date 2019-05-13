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
        public Character CharacterOne { get; set; }
        public Character CharacterTwo { get; set; }
        public List<Attack> Attacks { get; set; }
        public Character Winner { get; set; }




    }
}