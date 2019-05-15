using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RPGApplication.Models
{
    [Table("Proficiency")]
    public class Proficiency
    {


        [Key]
        public int ProficiencyId { get; set; }
        public string Name { get; set; }

        public Proficiency() { }

        public Proficiency(string name)
        {
            this.Name = name;
        }




    }
}