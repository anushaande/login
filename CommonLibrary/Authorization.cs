using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;
using System.IO;
using CommonLibrary;

namespace CommonLibrary
{
    public class Authorization
    {
        public static void PopulateUser(User user, Database database)
        {
            if (string.IsNullOrEmpty(user.UID) )
            {

                 
                var parameters = new OracleParameter[]
                {
                new OracleParameter(){ ParameterName="p_hscnet_id", Direction = ParameterDirection.Input, Value = user.GetHSCNetIdFromEmail()},
                new OracleParameter(){ ParameterName = "p_firstname", Direction = ParameterDirection.Output, Size = 5000},
                new OracleParameter(){ ParameterName = "p_lastname", Direction = ParameterDirection.Output, Size = 5000},
                new OracleParameter(){ ParameterName = "p_personid", Direction = ParameterDirection.Output, Size = 5000},
                };
                database.FillParametersFromProcedure("hsc.health_account.get_accounts_by_hscnet_id", parameters);

                //throw new Exception(parameters[1].Value.ToString());



                user.FirstName = parameters[1].Value.ToString();
                user.LastName = parameters[2].Value.ToString();
                user.PersonID = parameters[3].Value.ToString();
                
            }

            else
            {
                var newparameters = new OracleParameter[]
                 {
                new OracleParameter(){ ParameterName="p_uid", Direction = ParameterDirection.Input, Value = user.UID},
                new OracleParameter(){ ParameterName = "p_firstname", Direction = ParameterDirection.Output, Size = 5000},
                new OracleParameter(){ ParameterName = "p_lastname", Direction = ParameterDirection.Output, Size = 5000},
                new OracleParameter(){ ParameterName = "p_personid", Direction = ParameterDirection.Output, Size = 5000},
                 };
                database.FillParametersFromProcedure("hsc.health_account.get_health_accounts_by_UID", newparameters);

                //throw new Exception(parameters[1].Value.ToString());



                user.FirstName = newparameters[1].Value.ToString();
                user.LastName = newparameters[2].Value.ToString();
                user.PersonID = newparameters[3].Value.ToString();
            }

            //StreamWriter sw = new StreamWriter(@"c:\inetpub\wwwroot\logcas.txt");
            //sw.WriteLine("PersonID = " + user.PersonID);
            //sw.WriteLine("First Name = " + user.FirstName);
            //sw.WriteLine("Last Name = " + user.LastName);
            //sw.WriteLine("UID = " + user.UID);

            if (database == null)
                throw new Exception("Database is null");
            if (user.PersonID == null)
                throw new Exception("PersonID is null");

            var personID = new OracleParameter() { ParameterName = "p_person_id", Direction = ParameterDirection.Input, Value = user.PersonID};
            var cursor = new OracleParameter("curr_groups", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            var data = database.GetDataFromProcedure("hsc.active_directory.sel_user_groups",
                personID,
                cursor
            );

            // data.WriteXml("C:\\inetpub\\wwwroot\\data.xml");
            if (data == null)
                throw new Exception("no groups to retrieve");

            var table = data.Tables[0];

            var rows = table.Rows;


            //sw.WriteLine("Number of Rows = " + rows.Count);

            //sw.Close();

            //user.Groups.Add(rows[0]["sam_account_name"].ToString());

           for(var i=0; i < rows.Count; i++)
            {
                if (rows != null && rows[i] != null)
                {
                    DataRow row = rows[i];

                    user.Groups.Add(row["sam_account_name"].ToString());
                }
                
            }


        }
    }
}