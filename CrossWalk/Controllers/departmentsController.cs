using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using CrossWalk.Departmentclasses;
using System.Data;
using System.IO;
using Oracle.ManagedDataAccess.Client;
//using ClassLibrary;
using CommonLibrary;
//using log_in_component;
using DotNetCasClient.Security;
using System.Security.Principal;
using CrossWalk.Models;
using log_in_component;
using log_in_component.Controllers;

namespace CrossWalk.Controllers
{
    public class departmentsController : BaseController
    {

        [Authorize]
        // GET: departements



        public ActionResult Index()
        {
            if (HealthUser.Groups.Contains("App_DataWarehouse_Depts"))
                return DepartmentsView();
            else
                return UnauthorizedUser();
        }

        private ActionResult DepartmentsView()
        {
            var Department = GetDepartmentsFromApi();
            return View(Department);
        }

        private ActionResult UnauthorizedUser()
        {
            UserInformation ui = new UserInformation();
            ui.FirstName = HealthUser.FirstName;
            ui.LastName = HealthUser.LastName;
            ui.Email = HealthUser.Email;
            ui.UID = HealthUser.UID;
            //User u = new User();


            return View("UnauthorizedUser", ui);
        }

        public List<Departments> GetDepartmentsFromApi()
        {
            var resultList = new List<Departments>();

            var client = new HttpClient();
            var getdata = client.GetAsync("https://cftest.hsc.usf.edu/globaldepts/api/values")
                .ContinueWith(response =>
                {
                    var result = response.Result;
                    if(result.StatusCode== System.Net.HttpStatusCode.OK)
                    {
                        var readResult = result.Content.ReadAsAsync<List<Departments>>();
                        readResult.Wait();
                        //get the  result
                        resultList = readResult.Result;
                    }
                });
            //wait until async method completes
            getdata.Wait();
            return resultList;
        }

        //public CommonLibrary.Database Database
        //{
        //    get { return HttpContext.Application["database"] as CommonLibrary.Database; }

        //}

        [HttpPost]
        public ActionResult SubDepts(int KEY)

        {
            Departments dpt = new Departments();
            dpt.KEY_GLOBAL_DEPT = KEY;

            AllMethods am = new AllMethods();
            am.ListMethodscoda = dpt.GetcodaDepartments(Database);
            am.ListMethodsfast = dpt.GetfastDepartments(Database);
            am.ListMethodsgems = dpt.GetgemsDepartments(Database);
            am.ListMethodsoasis = dpt.GetoasisDepartments(Database);
            am.ListMethodsbanner = dpt.GetbannerDepartments(Database);
            am.ListMethodsidx = dpt.GetidxDepartments(Database);
            am.ListMethodsepic = dpt.GetepicDepartments(Database);
            am.ListMethodssamas = dpt.GetsamasDepartments(Database);

            return PartialView("SubDepts", am);
        }

        [HttpPost]
       public void ReassignDepartment(int ddl, string personid, int deptkey, string source)
        {

            Departments dept = new Departments();
            dept.KEY_GLOBAL_DEPT = ddl;
            dept.PERSON_ID = personid;
            dept.SOURCE_KEY = source;
            dept.DEPT_KEY = deptkey;

            dept.ReassignDepartment(Database);

        }
      
    }
}