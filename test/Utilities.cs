using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary;
using System.Configuration;

namespace test
{
    class Utilities
    {
        public static Database GetDatabase()
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
