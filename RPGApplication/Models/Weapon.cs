using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RPGApplication.Models
{
    [Table("weapon")]
    public class Weapon : Item
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Dano:")]
        public int Damage { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Crítico:")]
        public double Critical { get; set; }

        public Weapon() : base() { }

        public Weapon(string name, string description, int requiredLevel, int price, ItemRarity itemRarity, int damage, double critical)
            : base(name, description, requiredLevel, price, itemRarity)
        {
            this.Damage = damage;
            this.Critical = damage;
        }



    }
}