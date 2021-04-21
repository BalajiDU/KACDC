using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace KACDC.Class.DataProcessing
{
    public class ApprovalProcess
    {
        public void ApplicationApprovalProcess(string Method,string ApplicationStatus,string ApplicationNumber,string Reason="")
        {
            HttpClient HC = new HttpClient();
            string district = "Bengaluru Dakshina";
            string method = "SESELECTCW";

            UriBuilder builder = new UriBuilder();
            //builder.Query = "Status='"+ method + "'&District='"+ district + "'";
            builder.Query = "Status=" + method + "&District=" + district;

            if (HttpContext.Current.Request.Url.Host.ToString() == "localhost")
            {
                HC.BaseAddress = new Uri("http://localhost:50369/api/");
            }
            else
            {
                HC.BaseAddress = new Uri("https://aryavysya.karnataka.gov.in/api/");
            }
            if (Reason == "")
            {
                builder.Query = "Status=" + Method + "&ApplicationStatus=" + ApplicationStatus + "&ApplicationNumber=" + ApplicationNumber;
            }
            else
            {
                builder.Query = "Status=" + Method + "&ApplicationStatus=" + ApplicationStatus + "&ApplicationNumber=" + ApplicationNumber + "&RejectReason=" + Reason;
            }
            

            var ConsAPI = HC.GetAsync(builder.Uri);
            ConsAPI.Wait();
            var readData = ConsAPI.Result;
            if (readData.IsSuccessStatusCode)
            {
                
            }
            else
            {

            }
        }
    }
}