using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetCasClient.Configuration;
using DotNetCasClient.Security;
using System.Security.Principal;

namespace CommonLibrary
{
    public class Authentication
    {
       static public User GetUser(IPrincipal user, HttpSessionStateBase session )
        {
           ICasPrincipal sessionPrincipal = user as ICasPrincipal;
           IAssertion sessionAssertion = sessionPrincipal.Assertion;

            
            User userObject = new User();

            userObject.NetID = sessionPrincipal.Identity.Name;

            try
            {
                List<string> firstname = sessionAssertion.Attributes["GivenName"].ToList();
                string fname = string.Join("", firstname.ToArray());
                userObject.FirstName = fname;
            }

            catch
            {
                userObject.FirstName = "";
            }


            try
            {
                List<string> lastname = sessionAssertion.Attributes["Surname"].ToList();
                string lname = string.Join("", lastname.ToArray());
                userObject.LastName = lname;
            }
            catch
            {
                userObject.LastName = "";
            }

            try
            {
                List<string> UID = sessionAssertion.Attributes["USFeduUnumber"].ToList();
                string USFID = string.Join("", UID.ToArray());
              
                userObject.UID = USFID;
            }
            catch
            {

                userObject.UID = "";
            }
            try
            {
                List<string> email = sessionAssertion.Attributes["mail"].ToList();
                string Email = string.Join("", email.ToArray());
                userObject.Email = Email;

            }
            catch
            {
                userObject.Email = "";

            }

         



            session["user"] = userObject;
            return userObject;
        }



    }

}