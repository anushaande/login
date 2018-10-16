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
using System.Data;
//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;


namespace log_in_component.Test
{
    [TestClass]

    public class DatabaseConnectionTests
    {
        //Test method to check authorization class. 
        [TestMethod]
        public void TestConnectivity()
        {
            //arrange
           var data = Utilities.GetDatabase();
            string UID = "U68652646";
            string PersonID = "2873183";
            string FirstName = "Fnu";
            string LastName = "Nitesh Kumar";


            //act
            var newparameters = new OracleParameter[]
                             {
                new OracleParameter(){ ParameterName="p_uid", Direction = ParameterDirection.Input, Value = UID},
                new OracleParameter(){ ParameterName = "p_firstname", Direction = ParameterDirection.Output, Size = 5000},
                new OracleParameter(){ ParameterName = "p_lastname", Direction = ParameterDirection.Output, Size = 5000},
                new OracleParameter(){ ParameterName = "p_personid", Direction = ParameterDirection.Output, Size = 5000},
                             };
            data.FillParametersFromProcedure("hsc.health_account.get_health_accounts_by_UID", newparameters);

            //throw new Exception(parameters[1].Value.ToString());



            //assert
            Assert.AreEqual(FirstName, newparameters[1].Value.ToString());
            Assert.AreEqual(LastName, newparameters[2].Value.ToString());
            Assert.AreEqual(PersonID, newparameters[3].Value.ToString());
        }

     
    }
}
