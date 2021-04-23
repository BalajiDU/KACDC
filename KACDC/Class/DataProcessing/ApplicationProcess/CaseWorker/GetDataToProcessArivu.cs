using KACDC.Class.Declaration.Schemes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace KACDC.Class.DataProcessing.ApplicationProcess.CaseWorker
{
    public class GetDataToProcessArivu
    {
        protected IEnumerable<Arivu> GetApplication(string Method, string District, IEnumerable<Arivu> AR=null)
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

                var disprecord = readData.Content.ReadAsAsync<IList<Arivu>>();
                disprecord.Wait();
                AR = disprecord.Result;

            }
            return AR;
        }
    }
}