using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RPGApplication.Models
{
    [Table("item_rarity")]
    public class ItemRarity
    {
        [Key]
        public int RarityId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Nome:")]
        [MinLength(5)]
        [MaxLength(15)]
        public string Name { get; set; }

        public ItemRarity() { }

        public ItemRarity(string name)
        {
            this.Name = name;
        }

    }
}