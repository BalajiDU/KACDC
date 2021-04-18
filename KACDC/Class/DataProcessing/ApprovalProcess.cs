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

            UriBuilder builder = new UriBuilder("http://localhost:50369/api/CaseWorker");
            if (Reason == "")
            {
                builder.Query = "Status=" + Method + "&ApplicationStatus=" + ApplicationStatus + "&ApplicationNumber=" + ApplicationNumber;
            }
            else
            {
                builder.Query = "Status=" + Method + "&ApplicationStatus=" + ApplicationStatus + "&ApplicationNumber=" + ApplicationNumber + "&RejectReason=" + Reason;
            }
            HC.BaseAddress = new Uri("http://localhost:50369/api/");
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