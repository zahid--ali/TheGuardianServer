using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheGuardian.Models
{
    public class UserLoginModel
    {
        //Sign Up Model
        public string Email { get; set; }


        //Login Model
        public string Username { get; set; }
        public string Password { get; set; }

        //Checker
        public string Type { get; set; }
    }
}