using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RPGApplication.Models
{
    [Table("attribute_in_character")]
    public class AttributeInCharacter
    {
        [Key]
        public int AttributeInCharacterId { get; set; }
        public Attribute Attribute { get; set; }
        public int AttributePoints { get; set; }


        public AttributeInCharacter() { }

        public AttributeInCharacter(Attribute attribute, int attributePoints)
        {
            this.Attribute = attribute;
            this.AttributePoints = attributePoints;
        }



    }
}