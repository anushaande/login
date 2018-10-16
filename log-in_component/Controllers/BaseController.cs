using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Collections.Specialized;
using Newtonsoft.Json;
using System.Net.Mail;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using CommonLibrary;

namespace log_in_component.Controllers
{
    public class BaseController : Controller
    {
        public Database Database
        {
            get { return HttpContext.Application["database"] as Database; }
           
        }

        public Database HscDatabase
        {
            get { return HttpContext.Application["hscdatabase"] as Database; }

        }

        public bool IsDebug => (bool)HttpContext.Application["debug"];

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if ((User.Identity.IsAuthenticated == true && Session["user"] == null) || (Session["user"] != null && User.Identity.Name != HealthUser.NetID))
            {
               var user = Authentication.GetUser(User, Session);

                Authorization.PopulateUser(user, HscDatabase);
            }
              
           base.OnActionExecuting(filterContext);
        }

        public User HealthUser
        { get
            {
               return Session["user"] as User;
            }
         
        }

        Dictionary<string, string> serializeNVCollection(NameValueCollection nvc)
        {
            var list = new Dictionary<string, string>();

            foreach (var key in nvc.AllKeys)
            {
                list.Add(key, nvc[key]);
            }

            return list;
        }

        string constructErrorMessage(Exception ex, string jsonState)
        {
            return string.Format(
                "{0}{1}{1} Error: {2}{1}{1} Stack Trace: {3}{1}{1} State: {4}{1}", 
                DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss"),
                Environment.NewLine+"<br/>",
                ex.Message,
                ex.StackTrace.Replace(Environment.NewLine, Environment.NewLine+"<br/>"),
                jsonState
                );
        }

        void sendEmail(string message, string path)
        {
            var msg = new MailMessage();
            var client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.hscnet.hsc.usf.edu";
            msg.To.Add("cferror@health.usf.edu");
            msg.From = new MailAddress("oops@hsccf.hsc.usf.edu");
            msg.Subject = "Unhandled exception from: " + path;
            msg.IsBodyHtml = true;
            msg.Body = message;
            client.Send(msg);
        }

        void insertLogEntry(string message, string applicationPath)
        {
            //hscdatabase
            HscDatabase.FillParametersFromProcedure("hsc.application_common.insert_errors",
                new OracleParameter() { ParameterName = "p_date", Direction = ParameterDirection.Input, Value = DateTime.Now },
                new OracleParameter() { ParameterName = "p_description", Direction = ParameterDirection.Input, Value = message },
                new OracleParameter() { ParameterName = "p_application_name", Direction = ParameterDirection.Input, Value = applicationPath }
            );
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            var Request = HttpContext.Request;
            var Session = this.Session;
            var Application = this.HttpContext.Application;
            filterContext.ExceptionHandled = true;            

            var cooks = new Dictionary<string, string>();
            foreach (string cook in Request.Cookies)
                cooks.Add(cook, Request.Cookies[cook].Value);

            var sess = new Dictionary<string, string>();
            foreach (string item in Session)
                sess.Add(item, JsonConvert.SerializeObject(Session[item], Formatting.Indented));

            var app = new Dictionary<string, string>();
            foreach (string item in Application)
                app.Add(item, JsonConvert.SerializeObject(Application[item], Formatting.Indented));
            
            var struc = new
            {                
                Url=Request.Url,
                Method=Request.HttpMethod,
                Path=Request.Path,
                UserHostAddress = Request.UserHostAddress,
                QueryString = serializeNVCollection(Request.QueryString),
                Form = serializeNVCollection(Request.Form),
                Cookies = cooks,
                Headers = serializeNVCollection(Request.Headers),
                Session = sess,
                Application = app
            };
            

            var message = constructErrorMessage(filterContext.Exception, JsonConvert.SerializeObject(struc, Formatting.Indented).Replace(Environment.NewLine, "<br/>") + "</p>");

            if(IsDebug)
                Response.Write(message);

            sendEmail(message, Request.Url.ToString());

            insertLogEntry(message, Request.ApplicationPath.ToString());

            filterContext.Result = new ViewResult
            { 
                ViewName = "~/Views/Home/About.cshtml"
            };
        }
    }   
}