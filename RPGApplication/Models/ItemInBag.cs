using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RPGApplication.Models
{
    [Table("item_in_bag")]
    public class ItemInBag
    {
        [Key]
        public int ItemInBagId { get; set; }

        [Display(Name = "Item:")]
        public Item Item { get; set; }

        [Required]
        [Display(Name = "Equipado:")]
        public Boolean Equipped { get; set; }

        [Required]
        [Display(Name = "Mochila:")]
        public Bag Bag { get; set; }



    }
}