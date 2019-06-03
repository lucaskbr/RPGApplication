using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RPGApplication.Models
{
    [Table("bag")]
    public class Bag
    {
        [Key]
        public int BagId { get; set; }

        [Required]
        [Display(Name = "Espaço:")]
        public int slots { get; set; }

        [Required]
        [Display(Name = "Itens:")]
        public List<ItemInBag> ItemsInBag { get; set; }


        public Bag() {
            this.slots = 5;
        }

        public Bag(List<ItemInBag> ItemsInBag)
        {
            this.ItemsInBag = ItemsInBag;
            this.slots = 5;
        }

    }
}