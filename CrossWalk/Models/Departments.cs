using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrossWalk.Departmentclasses;
using CrossWalk;
using System.Data;
//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;
using System.IO;
//using ClassLibrary;
using CommonLibrary;
using System.Net.Http;

namespace API.Models
{
    public class Departments
    {
        public int KEY_GLOBAL_DEPT { get; set; }
        public int DEPT_KEY { get; set; }
        public string GLOBAL_DEPT_NAME { get; set; }
        public string SOURCE_KEY { get; set; }
        public string PERSON_ID { get; set; }



        public List<FastDepartment> GetfastDepartments(CommonLibrary.Database database)
        {

            var parameters = new OracleParameter[]
            {
                new OracleParameter(){ ParameterName="phart_dept_key", Direction = ParameterDirection.Input, Value = KEY_GLOBAL_DEPT},
                new OracleParameter("presults", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            var Fastdata = database.GetDataFromProcedure("dept_assignment.get_fast_assigned_depts", parameters);

            List<FastDepartment> fastList = new List<FastDepartment>();

            foreach (DataRow pRow in Fastdata.Tables[0].Rows)
            {
                var fastlist = new FastDepartment();
                fastlist.USF_DEPT_NAME = pRow["USF_DEPT_NAME"].ToString();
                fastlist.USF_DEPT_CODE = Convert.ToInt32(pRow["USF_DEPT_CODE"].ToString());
                fastlist.KEY_USF_DEPT = Convert.ToInt32(pRow["KEY_USF_DEPT"].ToString());


                fastList.Add(fastlist);
            }
            return fastList;

        }
        public List<SamasDepartment> GetsamasDepartments(CommonLibrary.Database database)
        {

            var parameters = new OracleParameter[]
            {
                new OracleParameter(){ ParameterName="phart_dept_key", Direction = ParameterDirection.Input, Value = KEY_GLOBAL_DEPT},
                new OracleParameter("presults", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            var samsdata = database.GetDataFromProcedure("dept_assignment.get_samas_assigned_depts", parameters);

            List<SamasDepartment> SamasList = new List<SamasDepartment>();
            foreach (DataRow pRow in samsdata.Tables[0].Rows)
            {
                var samaslist = new SamasDepartment();
                samaslist.KEY_SAMAS_DEPT = Convert.ToInt32(pRow["KEY_SAMAS_DEPT"].ToString());
                samaslist.SAMAS_DEPT = pRow["SAMAS_DEPT"].ToString();
                samaslist.SAMAS_TITLE = pRow["SAMAS_TITLE"].ToString();
                

                SamasList.Add(samaslist);
            }
            return SamasList;

        }

        public List<GemsDepartment> GetgemsDepartments(CommonLibrary.Database database)
        {

            var parameters = new OracleParameter[]
            {
                new OracleParameter(){ ParameterName="phart_dept_key", Direction = ParameterDirection.Input, Value = KEY_GLOBAL_DEPT},
                new OracleParameter("presults", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            var gemsdata = database.GetDataFromProcedure("dept_assignment.get_gems_assigned_depts", parameters);

            List<GemsDepartment> GemsList = new List<GemsDepartment>();
            foreach (DataRow pRow in gemsdata.Tables[0].Rows)
            {
                var gemslist = new GemsDepartment();
                gemslist.GEMS_DEPT_CODE = pRow["GEMS_DEPT_CODE"].ToString();
                gemslist.GEMS_DEPT_DESC = pRow["GEMS_DEPT_DESC"].ToString();
                gemslist.KEY_GEMS_DEPT = Convert.ToInt32(pRow["KEY_GEMS_DEPT"].ToString());

                GemsList.Add(gemslist);
            }
            return GemsList;

        }

        public List<CodaDepartment> GetcodaDepartments(CommonLibrary.Database database)
        {

            var parameters = new OracleParameter[]
            {
                new OracleParameter(){ ParameterName="phart_dept_key", Direction = ParameterDirection.Input, Value = KEY_GLOBAL_DEPT},
                new OracleParameter("presults", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            var codadata = database.GetDataFromProcedure("dept_assignment.get_coda_assigned_depts", parameters);


            List<CodaDepartment> CodaList = new List<CodaDepartment>();
            foreach (DataRow pRow in codadata.Tables[0].Rows)
            {
                var codalist = new CodaDepartment();
                codalist.USFPG_DEPT_DIV_CODE = Convert.ToInt32(pRow["USFPG_DEPT_DIV_CODE"].ToString());
                codalist.USFPG_COMPANY_CODE = pRow["USFPG_COMPANY_CODE"].ToString();
                codalist.USFPG_DEPT_NAME = pRow["USFPG_DEPT_NAME"].ToString();
                codalist.USFPG_DIV_NAME = pRow["USFPG_DIV_NAME"].ToString();
                codalist.KEY_USFPG_DEPT = Convert.ToInt32(pRow["KEY_USFPG_DEPT"].ToString());
                CodaList.Add(codalist);
            }
            return CodaList;
        }

        public List<OasisDepartment> GetoasisDepartments(CommonLibrary.Database database)
        {

            var parameters = new OracleParameter[]
            {
                new OracleParameter(){ ParameterName="phart_dept_key", Direction = ParameterDirection.Input, Value = KEY_GLOBAL_DEPT},
                new OracleParameter("presults", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            var oasisdata = database.GetDataFromProcedure("dept_assignment.get_oasis_assigned_depts", parameters);

            List<OasisDepartment> OasisList = new List<OasisDepartment>();
            foreach (DataRow pRow in oasisdata.Tables[0].Rows)
            {
                var oasislist = new OasisDepartment();
                oasislist.OASIS_DEPT_CODE = pRow["OASIS_DEPT_CODE"].ToString();
                oasislist.OASIS_DEPT_DESC = pRow["OASIS_DEPT_DESC"].ToString();
                oasislist.KEY_OASIS_DEPT = Convert.ToInt32(pRow["KEY_OASIS_DEPT"].ToString());
                OasisList.Add(oasislist);
            }
            return OasisList;
        }

        public List<BannerDepartment> GetbannerDepartments(CommonLibrary.Database database)
        {

            var parameters = new OracleParameter[]
            {
                new OracleParameter(){ ParameterName="phart_dept_key", Direction = ParameterDirection.Input, Value = KEY_GLOBAL_DEPT},
                new OracleParameter("presults", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            var bannerdata = database.GetDataFromProcedure("dept_assignment.get_mdbanner_assigned_depts", parameters);

            List<BannerDepartment> BannerList = new List<BannerDepartment>();
            foreach (DataRow pRow in bannerdata.Tables[0].Rows)
            {
                var bannerlist = new BannerDepartment();
                bannerlist.MDBANNER_DEPT_CODE = Convert.ToInt32(pRow["MDBANNER_DEPT_CODE"].ToString());
                bannerlist.MDBANNER_DEPT_DESC = pRow["MDBANNER_DEPT_DESC"].ToString();
                bannerlist.KEY_MDBANNER_DEPT = Convert.ToInt32(pRow["KEY_MDBANNER_DEPT"].ToString());

                BannerList.Add(bannerlist);
            }
            return BannerList;

        }


        public List<EpicDepartment> GetepicDepartments(CommonLibrary.Database database)
        {

            var parameters = new OracleParameter[]
            {
                new OracleParameter(){ ParameterName="phart_dept_key", Direction = ParameterDirection.Input, Value = KEY_GLOBAL_DEPT},
                new OracleParameter("presults", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            var epicdata = database.GetDataFromProcedure("dept_assignment.get_epic_assigned_depts", parameters);


            List<EpicDepartment> EpicList = new List<EpicDepartment>();
            foreach (DataRow pRow in epicdata.Tables[0].Rows)
            {
                var epiclist = new EpicDepartment();
                epiclist.DEPARTMENT_EPIC_ID = pRow["DEPARTMENT_EPIC_ID"].ToString();
                epiclist.DEPARTMENT_EXTERNAL_NAME = pRow["DEPARTMENT_EXTERNAL_NAME"].ToString();
                epiclist.DEPARTMENT_NAME = pRow["DEPARTMENT_NAME"].ToString();
                epiclist.KEY_EPIC_DEPT = Convert.ToInt32(pRow["KEY_EPIC_DEPT"].ToString());

                EpicList.Add(epiclist);
            }
            return EpicList;
        }


        public List<IdxDepartment> GetidxDepartments(CommonLibrary.Database database)
        {

            var parameters = new OracleParameter[]
            {
                new OracleParameter(){ ParameterName="phart_dept_key", Direction = ParameterDirection.Input, Value =KEY_GLOBAL_DEPT},
                new OracleParameter("presults", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            var idxdata = database.GetDataFromProcedure("dept_assignment.get_idx_assigned_depts", parameters);


            List<IdxDepartment> IDXList = new List<IdxDepartment>();
            foreach (DataRow pRow in idxdata.Tables[0].Rows)
            {
                var idxlist = new IdxDepartment();
                idxlist.DIV_MNEMONIC = pRow["DIV_MNEMONIC"].ToString();
                idxlist.DIV_NAME = pRow["DIV_NAME"].ToString();
                idxlist.DIV_REPORTINGCATEGORY3 = pRow["DIV_REPORTINGCATEGORY3"].ToString();
                idxlist.KEY_USFPG_DIV = Convert.ToInt32(pRow["KEY_USFPG_DIV"].ToString());

                IDXList.Add(idxlist);
            }
            return IDXList;
        }

        //public List<Departments> GetDepartmentsFromApi()
        //{
        //    var resultList = new List<Departments>();

        //    var client = new HttpClient();
        //    var getdata = client.GetAsync("https://cftest.hsc.usf.edu/globaldepts/api/values")
        //        .ContinueWith(response =>
        //        {
        //            var result = response.Result;
        //            if (result.StatusCode == System.Net.HttpStatusCode.OK)
        //            {
        //                var readResult = result.Content.ReadAsAsync<List<Departments>>();
        //                readResult.Wait();
        //                //get the  result
        //                resultList = readResult.Result;
        //            }
        //        });
        //    //wait until async method completes
        //    getdata.Wait();
        //    return resultList;
        //}

        public void ReassignDepartment(CommonLibrary.Database database)
        {
            var parameters = new OracleParameter[]
{
                new OracleParameter(){ ParameterName="phart_dept_key  ", Direction = ParameterDirection.Input, Value = KEY_GLOBAL_DEPT},
                new OracleParameter(){ ParameterName = "pdept_key", Direction = ParameterDirection.Input, Value = DEPT_KEY},
                new OracleParameter(){ ParameterName = "psource_sys", Direction = ParameterDirection.Input, Value = SOURCE_KEY},
                new OracleParameter(){ ParameterName = "pperson_id", Direction = ParameterDirection.Input, Value = PERSON_ID},
};
            database.FillParametersFromProcedure("dept_assignment.change_dept_assignment", parameters);


            //StreamWriter sw = new StreamWriter(@"c:\repos\logs\error2.txt");
            //sw.WriteLine("ddl = " + KEY_GLOBAL_DEPT);
            //sw.WriteLine("PersonID = " + DEPT_KEY);
            //sw.WriteLine("source = " + SOURCE_KEY);
            //sw.WriteLine("deptkey = " + PERSON_ID);
            //sw.Close();
        }


    }

    
}