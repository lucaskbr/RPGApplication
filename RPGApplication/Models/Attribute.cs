using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RPGApplication.Models
{
    [Table("attribute")]
    public class Attribute
    {

        [Key]
        public int AttributeId { get; set; }
        public string Name { get; set; }

        public Attribute() { }

        public Attribute(string name)
        {
            this.Name = name;
        }


    }
}