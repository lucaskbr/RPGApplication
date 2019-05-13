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
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Character Character { get; set; }
        public bool ActiveAccount { get; set; }
        public DateTime SignUpDate { get; set; }

        public User()
        {
            this.ActiveAccount = true;
            this.SignUpDate = DateTime.Now;
            }

        public User(string name, string lastName, string login, string email, string password, Character character)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Login = login;
            this.Email = email;
            this.Password = password;
            this.Character = character;

        }



    }
}