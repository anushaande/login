using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using log_in_component;
using System.Web;
using ClassLibrary;
using System.Configuration;

namespace log_in_component.Test
{
    [TestClass]

    public class Class1
    {
        //Test method to check authorization class. 
        [TestMethod]
        public void Test1()
        {
            //arrange
            User user = new User();
            user.UID = "U68652646";
            string PersonID = "2873183";
            string FirstName = "FNU";
            string LastName = "Nitesh kumar";


            //act
            Authorization.PopulateUser(user, getDatabase());

            //assert
            Assert.AreEqual(FirstName, user.FirstName);
            Assert.AreEqual(LastName, user.LastName);
            Assert.AreEqual(PersonID, user.PersonID);
        }

        private Database getDatabase()
        {
            var settings = ConfigurationManager.AppSettings;
            return new Database(
                settings["host"].ToString(),
                settings["port"].ToString(),
                settings["sid"].ToString(),
                settings["user"].ToString(),
                settings["pass"].ToString()
            );
        }
    }
}
