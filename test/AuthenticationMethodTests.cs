using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using log_in_component;
using System.Web;
using System.Configuration;
using System.Security.Principal;
using DotNetCasClient;
using DotNetCasClient.Security;
using CommonLibrary;

namespace log_in_component.Test
{
    [TestClass]

    public class AuthenticationMethodTests
    {
        //Test method to check authentication class.
        
        [TestMethod]
        public void TestGetUser()
        {
            //arrange
            string UID = "U68652646";
            string Email = "niteshk@health.usf.edu";
            string FirstName = "Fnu";
            string LastName = "Nitesh Kumar";

            var session = new TestSession();

            //act

            var userObject = Authentication.GetUser( new TestPrincipal(), session);

            //assert
            Assert.AreEqual(FirstName, userObject.FirstName);
            Assert.AreEqual(LastName, userObject.LastName);
            Assert.AreEqual(Email, userObject.Email);
            Assert.AreEqual(UID, userObject.UID);

            Assert.AreSame(session["user"], userObject);
        }


        class TestSession : HttpSessionStateBase
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            public override object this[string key]
            {
                get {
                    if (dict.ContainsKey(key))
                        return dict[key];

                    return null;
                }
                set {
                    dict[key] = value;
                }
            }

            
        }

        class TestPrincipal : IPrincipal, ICasPrincipal
        {
            class TestIdentity : IIdentity
            {
                string IIdentity.Name => "niteshk";

                string IIdentity.AuthenticationType => "Test Type";

                bool IIdentity.IsAuthenticated => true;
            }

            class TestAssertion : IAssertion
            {
                DateTime IAssertion.ValidFromDate => DateTime.Now;

                DateTime IAssertion.ValidUntilDate => DateTime.Now.AddDays(1);

                Dictionary<string, IList<string>> IAssertion.Attributes {
                    get {
                        var dict = new Dictionary<string, IList<string>>();


                        dict.Add("GivenName", new List<string>(new string[] { "Fnu"}));
                        dict.Add("Surname", new List<string>(new string[] { "Nitesh Kumar" }));
                        dict.Add("mail", new List<string>(new string[] { "niteshk@health.usf.edu" }));
                        dict.Add("USFeduUnumber", new List<string>(new string[] { "U68652646" }));

                        return dict;
                    }
                }
            
                string IAssertion.PrincipalName => throw new NotImplementedException();
            }

            IIdentity IPrincipal.Identity => new TestIdentity();

            IAssertion ICasPrincipal.Assertion => new TestAssertion();

            string ICasPrincipal.ProxyGrantingTicket => throw new NotImplementedException();

            IEnumerable<string> ICasPrincipal.Proxies => throw new NotImplementedException();

            bool IPrincipal.IsInRole(string role)
            {
                return true;
            }

            string ICasPrincipal.GetPassword()
            {
                throw new NotImplementedException();
            }
        }
    }
}
