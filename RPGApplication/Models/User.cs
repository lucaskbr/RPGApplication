using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RPGApplication.Models
{
    [Table("user")]
    public class User
    {

        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Nome:")]
        [MinLength(5, ErrorMessage = "O campo deve ser preenchido com no mínimo 5 caracteres")]
        [MaxLength(20, ErrorMessage = "O campo deve ser preenchido com no máximo 20 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Sobrenome:")]
        [MinLength(5, ErrorMessage = "O campo deve ser preenchido com no mínimo 5 caracteres")]
        [MaxLength(20, ErrorMessage = "O campo deve ser preenchido com no máximo 20 caracteres")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Login:")]
        [MinLength(1, ErrorMessage = "O campo deve ser preenchido com no mínimo 1 caracter")]
        [MaxLength(25, ErrorMessage = "O campo deve ser preenchido com no máximo 25 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Email:")]
        [MinLength(5, ErrorMessage = "O campo deve ser preenchido com no mínimo 5 caracteres")]
        [MaxLength(150, ErrorMessage = "O campo deve ser preenchido com no máximo 150 caracteres")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Senha:")]
        [MinLength(5, ErrorMessage = "O campo deve ser preenchido com no mínimo 5 caracteres")]
        [MaxLength(50, ErrorMessage = "O campo deve ser preenchido com no máximo 50 caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public Character Character { get; set; }

        [Required]
        [Range(0,1, ErrorMessage = "O campo só pode conter o valor 0 ou 1")]
        public int UserAcess { get; set; }

        [Required]
        public bool ActiveAccount { get; set; }

        [Required]
        public DateTime SignUpDate { get; set; }


        public User()
        {
            this.ActiveAccount = true;
            this.SignUpDate = DateTime.Now;
            this.UserAcess = 0;
            }

        public User(string name, string lastName, string login, string email, string password, Character character)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Login = login;
            this.Email = email;
            this.Password = password;
            this.Character = character;
            this.UserAcess = 0;
            this.ActiveAccount = true;
            this.SignUpDate = DateTime.Now;
        }



    }
}