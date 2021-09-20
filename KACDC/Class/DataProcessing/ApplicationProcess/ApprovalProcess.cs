using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            //builder.Query = "Status=" + method + "&District=" + district;

            if (HttpContext.Current.Request.Url.Host.ToString() == "localhost")
            {
                builder = new UriBuilder("http://localhost:50369/api/CaseWorker/");
            }
            else
            {
                builder = new UriBuilder("https://aryavysya.karnataka.gov.in/api/CaseWorker/");
            }
            if (Reason == "")
            {
                builder.Query = "Status=" + Method + "&ApplicationStatus=" + ApplicationStatus + "&ApplicationNumber=" + ApplicationNumber;
            }
            else
            {
                builder.Query = "Status=" + Method + "&ApplicationStatus=" + ApplicationStatus + "&ApplicationNumber=" + ApplicationNumber + "&RejectReason=" + Reason;
            }
            //if(HttpContext.Current.Request.Url.Host.ToString()== "localhost")
            //{
            //    HC.BaseAddress = new Uri("http://localhost:50369/api/");
            //}
            //else
            //{
            //    HC.BaseAddress = new Uri("https://aryavysya.karnataka.gov.in/api/");
            //}

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

        public bool ApplicationStatusUpdate(string Method, string ApplicationStatus, string ApplicationNumber, string RejectReason = "")
        {
            try
            {
                //List<CaseWorker> CWList = new List<CaseWorker>();
                using (SqlConnection kvdConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spApprovalProcess", kvdConn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@status", Method); //"SESELECTCW"
                        cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);//"Bengaluru Dakshina"
                        cmd.Parameters.AddWithValue("@RejectReason", RejectReason);//"Bengaluru Dakshina"
                        cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);//"Bengaluru Dakshina"
                        cmd.Connection = kvdConn;
                        kvdConn.Open();
                        cmd.ExecuteNonQuery();
                        kvdConn.Close();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ApplicationAmountUpdate(string Method, string ApplicationNumber, string Quota,string LoanAmount)
        {
            try
            {
                //List<CaseWorker> CWList = new List<CaseWorker>();
                using (SqlConnection kvdConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spApprovalProcess", kvdConn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@status", Method); //"SESELECTCW"
                        cmd.Parameters.AddWithValue("@Quota", Quota);//"Bengaluru Dakshina"
                        cmd.Parameters.AddWithValue("@1YearLoan", LoanAmount);//"Bengaluru Dakshina"
                        cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);//"Bengaluru Dakshina"
                        cmd.Parameters.AddWithValue("@RejectReason", "");//"Bengaluru Dakshina"
                        cmd.Parameters.AddWithValue("@ApplicationStatus", "");//"Bengaluru Dakshina"
                        cmd.Connection = kvdConn;
                        kvdConn.Open();
                        cmd.ExecuteNonQuery();
                        kvdConn.Close();
                    }
                }
                return true;
            }
            catch(Exception EX)
            {
                string MESSAGE = EX.Message;
                return false;
            }
        }

    }
}