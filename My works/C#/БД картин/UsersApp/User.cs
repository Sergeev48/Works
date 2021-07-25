﻿using System.ComponentModel.DataAnnotations;
namespace UsersApp
{
    class User
    {
        [Key]
        public int id_user { get; set; }


        public string login, password;

        
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }



        public User() { }
        public User(string login, string password) 
        {
            this.login = login;
            this.password = password;  
        }

        
    }
}
