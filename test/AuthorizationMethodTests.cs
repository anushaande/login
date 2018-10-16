using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using log_in_component;
using System.Web;
using CommonLibrary;
using System.Configuration;
using test;

namespace log_in_component.Test
{
    [TestClass]

    public class AuthorizationMethodTests
    {
        //Test method to check authorization class. 
        [TestMethod]
        public void TestPopulateUser()
        {
            //arrange
            User user = new User();
            user.UID = "U68652646";
            string PersonID = "2873183";
            string FirstName = "Fnu";
            string LastName = "Nitesh Kumar";


            //act
            Authorization.PopulateUser(user, Utilities.GetDatabase());

            //assert
            Assert.AreEqual(FirstName, user.FirstName);
            Assert.AreEqual(LastName, user.LastName);
            Assert.AreEqual(PersonID, user.PersonID);
        }

        
    }
}
