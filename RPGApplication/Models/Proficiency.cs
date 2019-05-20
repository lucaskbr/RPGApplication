using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RPGApplication.Models
{
    [Table("attributeInCharacter")]
    public class Proficiency
    {


        [Key]
        public int ProficiencyId { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        public Proficiency() { }

        public Proficiency(string name)
        {
            this.Name = name;
        }




    }
}