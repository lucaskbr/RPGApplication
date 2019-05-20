using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RPGApplication.Models
{
    [Table("character")]
    public class Character
    {

        [Key]
        public int CharacterId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Nome:")]
        [MinLength(5, ErrorMessage = "O campo deve ser preenchido com no minimo 5 caracteres")]
        [MaxLength(15)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Pontos de vida:")]
        public int LifePoints { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Level:")]
        public int Level { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Experiência:")]
        public double Experience { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Atributos:")]
        public List<AttributeInCharacter> AttributesInCharacter { get; set; }

        [Display(Name = "Itens equipados:")]
        public List<Item> EquipedItems { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Mochila:")]
        public Bag Bag { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Moedas:")]
        public int Coins { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Pontos de ranking:")]
        public int RankingPoints { get; set; }


        public Character(string name, List<AttributeInCharacter> attributesInCharacter, Bag bag)
        {
            this.Name = name;
            this.LifePoints = 5;
            this.Level = 1;
            this.Experience = 0;
            this.AttributesInCharacter = attributesInCharacter;
            this.Bag = bag;
            this.Coins = 100;
            this.RankingPoints = -1;

        }

       /* public void MakeAnAttack() {

            foreach (var item in Bag.Itens.ToList())
            {
                item.
            }
        }
        */




    }
}