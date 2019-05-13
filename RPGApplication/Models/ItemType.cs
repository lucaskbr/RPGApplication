using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RPGApplication.Models
{
    [Table("item_type")]
    public class ItemType
    {
        [Key]
        public int ItemTypeId { get; set; }
        public string Name { get; set; }


        public ItemType() { }

        public ItemType(string name) {
            this.Name = Name;
        }




    }
}