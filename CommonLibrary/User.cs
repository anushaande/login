using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommonLibrary
{
    public class User
    {
        public string NetID { get; set; }
        public List<string> Groups { get; }
        public string PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UID { get; set; }
        public string Email { get; set; }

        public User()
        {
            Groups = new List<string>();
        }

        public string GetHSCNetIdFromEmail()
        {
            if (string.IsNullOrEmpty(Email))
                return null;
            
            var split = this.Email.Split('@');
            if (split[1].ToLower() == "health.usf.edu")
                return split[0];

            return null;
        }



    }
}