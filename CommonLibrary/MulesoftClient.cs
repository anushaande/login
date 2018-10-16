using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;


namespace CommonLibrary
{
    static class MulesoftClient
    {

        public static void GetDataFromAPI(string clientId, string clientSecret, string apiName, string apiPath, Dictionary<string, string> parameters)
        {


        }



        //public List<T> Get<T>(string clientId, string clientSecret, string apiName, string apiPath, Dictionary<string, string> parameters)
        //{
        //           var resultList =  new List<T>();

        //            var client = new HttpClient();
        //            var getdata = client.GetAsync(apiPath)
        //            .ContinueWith(response =>
        //                {
        //                    var result = response.Result;
        //                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
        //                    {
        //                        var readResult = result.Content.ReadAsAsync<List< >>();
        //                        readResult.Wait();
        //                        //get the  result
        //                        resultList = readResult.Result;
        //                    }
        //                });
              
        //        ////wait until async method completes
        //        //getdata.Wait();
        //        //return resultList;
            
        //}
    }
}
