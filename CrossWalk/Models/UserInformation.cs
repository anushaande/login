using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrossWalk.Models
{
    public class UserInformation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UID { get; set; }
        public string Email { get; set; }

        public string fullname
        {
            get { return FirstName + ", " + LastName; }
        }
    }
}