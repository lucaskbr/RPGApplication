using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RPGApplication.Models
{
    [Table("coin")]
    public class Coin
    {
        [Key]
        public int CoinId { get; set; }
        public string Name { get; set; }

        public Coin() { }


        public Coin(string name) {
            this.Name = name;
        }


    }
}
