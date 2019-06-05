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

        public const string AGILITY = "AGILIDADE";
        public const string STRENGTH = "FORCA";
        public const string CONSTITUTION = "CONSTITUICAO";

        public const int AGILITY_BASE = 1;
        public const int STRENGTH_BASE = 3;
        public const int CONSTITUTION_BASE = 5;



        [Key]
        public int CharacterId { get; set; }

        [Display(Name = "Imagem:")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Nome:")]
        [MinLength(5, ErrorMessage = "O campo deve ser preenchido com no minimo 5 caracteres")]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "PONTOS DE VIDA:")]
        public int LifePoints { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Level:")]
        public int Level { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Experiência:")]
        public double Experience { get; set; }

        [Display(Name = "Pontos de atributo:")]
        public int AttributePoints { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Atributos:")]
        public List<AttributeInCharacter> AttributesInCharacter { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Mochila:")]
        public Bag Bag { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Moedas:")]
        public int Coins { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Pontos de ranking:")]
        public int RankingPoints { get; set; }


        public Character()
        {

        }

        public Character(string name, List<AttributeInCharacter> attributesInCharacter, Bag bag)
        {
            this.Image = "Characters/default.jpg";
            this.Name = name;
            this.LifePoints = 5;
            this.Level = 1;
            this.Experience = 0;
            this.AttributePoints = 0;
            this.AttributesInCharacter = attributesInCharacter;
            this.Bag = bag;
            this.Coins = 100;
            this.RankingPoints = -1;

        }


        /* public int GetBonusFromAttribute()
         {
             //return GetDamageOfWeaponsEquipped();
         }*/

        public int GetBonusFromAttribute(Proficiency proficiency)
        {

            return AttributesInCharacter.FirstOrDefault(x => x.Proficiency.Name.Equals(proficiency.Name)).ProficiencyPoints;

            /*
            foreach (var item in AttributesInCharacter)
            {
                if (item.Equals(proficiency.Name))
                {
                    return item.ProficiencyPoints;
                }
            }

            return 0;*/

        }


        public int GetLife()
        {
            return GetBonusFromAttribute(new Proficiency(CONSTITUTION)) + CONSTITUTION_BASE + LifePoints;
        }

        public double ChanceOfCrit()
        {
            return GetBonusFromAttribute(new Proficiency(AGILITY)) + AGILITY_BASE;
        }

        public double ChanceOfDodge()
        {
            return GetBonusFromAttribute(new Proficiency(AGILITY)) + AGILITY_BASE;
        }

        public int MakeAttack()
        {
            return GetBonusFromAttribute(new Proficiency(STRENGTH)) + GetDamageOfWeaponsEquipped();
        }

        public int MakeDefense()
        {
            return GetBonusFromAttribute(new Proficiency(STRENGTH)) + GetDefenseOfArmoursEquipped();

        }

        public int GetDamageOfWeaponsEquipped()
        {
            return GetWeaponsEquipped().Sum(x => x.Damage);
        }


        public int GetDefenseOfArmoursEquipped()
        {
            return GetArmoursEquipped().Sum(x => x.Defense);
        }


        public double GetCritOfWeaponsEquipped()
        {
            return GetWeaponsEquipped().Sum(x => x.Critical);
        }

        public double GetEvasionOfArmoursEquipped()
        {
            return GetArmoursEquipped().Sum(x => x.Evasion);
        }


        public List<Armour> GetArmoursEquipped()
        {
            return Bag.ItemsInBag
                        .Where(
                            x => x.Equipped == true &&
                            x.Item != null &&
                            x.Item.GetType() == typeof(Armour)
                        )
                        .ToList()
                        .ConvertAll(x => (Armour)x.Item)
                        .ToList();
        }


        public List<Weapon> GetWeaponsEquipped()
        {
            return Bag.ItemsInBag
                        .Where(
                            x => x.Equipped == true &&
                            x.Item != null &&
                            x.Item.GetType() == typeof(Weapon)
                        )
                        .ToList()
                        .ConvertAll(x => (Weapon)x.Item)
                        .ToList();
        }


    }
}