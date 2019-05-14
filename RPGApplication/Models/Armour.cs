﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RPGApplication.Models
{
    [Table("armour")]
    public class Armour : Item
    {

        public int Defense { get; set; }
        public double Evasion { get; set; }


        public Armour(string name, string description, int requiredLevel, int price, ItemRarity itemRarity, int defense, double evasion)
            : base(name, description, requiredLevel, price, itemRarity)
        {
            this.Defense = defense;
            this.Evasion = evasion;
        }






    }
}