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
        public int slots { get; set; }

        public List<Item> Items { get; set; }
         

        public Bag()
        {
            this.slots = 5;
        }

        public void CheckIfExistsEmptySlotsInBag()
        {
        }

        public void AddNewItemInBag()
        {

        }

    }
}