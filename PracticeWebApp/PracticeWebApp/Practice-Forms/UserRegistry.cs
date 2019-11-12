using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeWebApp.Practice_Forms
{
    public class UserRegistry
    {
        //Objective: define user registry as an object

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }


        public UserRegistry() { }

        public UserRegistry(string firstname, string lastname,
            string username, string email,
            string passwork)
        {
            FirstName = firstname;
            LastName = lastname;
            UserName = username;
            Email = email;
            Password = passwork;
        }


    }
}