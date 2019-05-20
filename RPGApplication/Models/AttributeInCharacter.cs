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

        [Required]
        public Proficiency Proficiency { get; set; }

        [Required]
        public int ProficiencyPoints { get; set; }


        public AttributeInCharacter() { }

        public AttributeInCharacter(Proficiency attributeInCharacter, int proficiencyPoints)
        {
            this.Proficiency = attributeInCharacter;
            this.ProficiencyPoints = proficiencyPoints;
        }



    }
}