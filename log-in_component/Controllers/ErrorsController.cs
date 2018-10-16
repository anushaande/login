using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace log_in_component.Controllers
{
    public class ErrorsController : Controller
    {
        protected override void HandleUnknownAction(string actionName)
        {
            this.View().ExecuteResult(this.ControllerContext);
        }
    }
}