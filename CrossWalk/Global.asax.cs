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
using log_in_component;

namespace CrossWalk
{
    public class MvcApplication : log_in_component.MvcApplication
    {
        //protected new void Application_Start()
        //{

        //    AreaRegistration.RegisterAllAreas();
        //    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        //    RouteConfig.RegisterRoutes(RouteTable.Routes);
        //    BundleConfig.RegisterBundles(BundleTable.Bundles);

       public override void InitializeApplication()
        {
            base.InitializeApplication();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var settings = ConfigurationManager.AppSettings;

            var db = new CommonLibrary.Database(

            settings["host"].ToString(),
            settings["port"].ToString(),
            settings["sid"].ToString(),
            settings["user"].ToString(),
            settings["pass"].ToString()
            );


            Application.Add("database", db);
        }


    }
}
