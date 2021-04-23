using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using KACDC.Class.Declaration.Schemes;

namespace KACDC.Class.DataProcessing.ApplicationProcess.CaseWorker
{
    public class GetDataToProcessSelfEmployment
    {
        protected IEnumerable<SelfEmployment> GetApplication(string Method, string District, IEnumerable<SelfEmployment> SE=null)
        {
            //IEnumerable<CaseWorker> CW = null;
            HttpClient HC = new HttpClient();
            UriBuilder builder = new UriBuilder();
            if (HttpContext.Current.Request.Url.Host.ToString() == "localhost")
            {
                builder = new UriBuilder("http://localhost:50369/api/CaseWorker/");
            }
            else
            {
                builder = new UriBuilder("https://aryavysya.karnataka.gov.in/api/CaseWorker/");
            }
            //var ConsAPI = HC.GetAsync("CaseWorker");
            builder.Query = "Status=" + Method + "&District=" + District;
            var ConsAPI = HC.GetAsync(builder.Uri);

            ConsAPI.Wait();
            var readData = ConsAPI.Result;
            if (readData.IsSuccessStatusCode)
            {

                var disprecord = readData.Content.ReadAsAsync<IList<SelfEmployment>>();
                disprecord.Wait();
                SE = disprecord.Result;

            }
            return SE;
        }
    }
}