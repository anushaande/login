using log_in_component.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CommonLibrary;

namespace log_in_component
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
           // RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var settings = ConfigurationManager.AppSettings;

            
            var db = new Database(
                            settings["hsc_host"].ToString(),
                            settings["hsc_port"].ToString(),
                            settings["hsc_sid"].ToString(),
                            settings["hsc_user"].ToString(),
                            settings["hsc_pass"].ToString()
                );

            Application.Add("Hscdatabase", db);

            Application.Add("debug", bool.Parse(settings["debug"].ToString()));

            InitializeApplication();
         }

        public virtual void InitializeApplication() { }
        

    }
}
