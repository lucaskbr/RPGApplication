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
        [Display(Name = "ID:")]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Nome:")]
        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "Imagem:")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Descrição:")]
        [MaxLength(150)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Nível:")]
        public int RequiredLevel { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Preço:")]
        public int Price { get; set; }

        public ItemRarity ItemRarity { get; set; }


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