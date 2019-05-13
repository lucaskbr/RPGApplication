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
        public int slots { get; set; }
        public List<Item> Itens { get; set; }


        public Bag()
        {
            this.slots = 2;
        }

        public void CheckIfExistsEmptySlotsInBag()
        {
        }

        public void AddNewItemInBag()
        {

        }

    }
}