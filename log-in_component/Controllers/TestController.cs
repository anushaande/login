using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using log_in_component;

namespace log_in_component.Controllers
{
    public class TestController : BaseController
    {
        public ActionResult GetPerson()
        {
            return View();
        }

        public ActionResult ThrowException()
        {
            Session["Boom"] = 1;
            HttpContext.Application["Tisk"] = 2;


            throw new Exception("This is an exception.");

            return View();
        }
    }
}