using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RPGApplication.Models
{
    [Table("item")]
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        /*public ItemType ItemType { get; set; }*/
        public int RequiredLevel { get; set; }
        public int Price { get; set; }
        public ItemRarity ItemRarity { get; set; }
        /* public Modifier Modifier { get; set; }*/


        public Item() { }


        public Item(string name, string description, int requiredLevel, int price, ItemRarity itemRarity)
        {
            this.Name = name;
            this.Description = description;
            this.RequiredLevel = requiredLevel;
            this.Price = price;
            this.ItemRarity = itemRarity;
        }




    }

}