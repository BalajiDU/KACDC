using KACDC.Models;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace KACDC.Class.GetCountStatistics
{
    public class GetCount
    {
        public string GetTotalCountRest(string StotedProcedureName, string MethodName, string ApplicationStatus = "", string District = "",string Gender="", string Zone = "")
        {
            try
            {
                var client = new RestClient("https://aryavysya.karnataka.gov.in/api/ApplicationCount/");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                //request.AddParameter("application/json", "{\"naeUser\":\"tmtestuser\",\"naePassword\":\"P@ssw0rd\",\"dbUser\":\"DBTEST\",\"dbPassword\":\"rndo_1234\",\"value\":\"" + txtAadhaar.Text.Trim() + "\",\"tableName\":\"DBVAULT\",\"format\":\"103\"}", ParameterType.RequestBody);
                request.AddParameter("application/json",
                    "{\"StotedProcedureName\":\"" + StotedProcedureName +
                    "\",\"MethodName\":\"" + MethodName +
                   
                    "\"}",
                    RestSharp.ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                //Response.Write("___response Data" + response.Content);
                string responseData = response.Content;

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    var jObject = JObject.Parse(response.Content);
                    //string token1 = jObject.GetValue("token").ToString();
                    return  jObject.GetValue("Count").ToString();

                    //Response.Write("___response token is:" + token1);
                }
                else
                {
                    //Response.Write("___response code:" + response.StatusCode.ToString());
                    //Response.Write("___response code:" + response.ErrorMessage);
                }
                return "";
            }
            catch (Exception ex)
            {
                //DisplayAlert(ex.Message, this);
                return ex.Message;
            }
        }
        public string GetTotalCount(string StotedProcedureName, string MethodName, string ApplicationStatus = "", string District = "",string Gender="", string Zone = "")
        {
            try
            {
                IEnumerable<CountValue> CW = null;
                HttpClient HC = new HttpClient();
                UriBuilder builder = new UriBuilder();

                if (HttpContext.Current.Request.Url.Host.ToString() == "localhost")
                {
                    builder = new UriBuilder("http://localhost:50369/api/ApplicationCount/");
                    //builder = new UriBuilder("/api/ApplicationCount/");

                }
                else
                {
                    builder = new UriBuilder("https://aryavysya.karnataka.gov.in/api/ApplicationCount/");
                    //builder = new UriBuilder("/api/ApplicationCount/");
                }
                var query = HttpUtility.ParseQueryString(builder.Query);
                if (StotedProcedureName != "") query["StotedProcedureName"] = StotedProcedureName;
                if (MethodName != "") query["MethodName"] = MethodName;
                if (ApplicationStatus != "") query["ApplicationStatus"] = ApplicationStatus;
                if (District != "") query["District"] = District;
                if (Zone != "") query["Zone"] = Zone;
                if (Gender != "") query["Gender"] = Gender;

                builder.Query = query.ToString();
                //return builder.Uri.ToString();
                var client = new System.Net.WebClient();
                var jObject_Response = Newtonsoft.Json.Linq.JObject.Parse(client.DownloadString(builder.Uri));
                return jObject_Response.GetValue("Count").ToString();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public string GetTotalCountNew(string StotedProcedureName, string MethodName, string ApplicationStatus = "", string District = "",string Gender="", string Zone = "")
        {
            IEnumerable<CountValue> CW = null;
            HttpClient HC = new HttpClient();
            UriBuilder builder = new UriBuilder();

            if (HttpContext.Current.Request.Url.Host.ToString() == "localhost")
            {
                builder = new UriBuilder("http://localhost:50369/api/ApplicationCount/");
                //builder = new UriBuilder("/api/ApplicationCount/");

            }
            else
            {
                builder = new UriBuilder("https://10.10.31.87/api/ApplicationCount/");
                //builder = new UriBuilder("/api/ApplicationCount/");
            }
            var query = HttpUtility.ParseQueryString(builder.Query);
            if (StotedProcedureName != "") query["StotedProcedureName"] = StotedProcedureName;
            if (MethodName != "") query["MethodName"] = MethodName;
            if (ApplicationStatus != "") query["ApplicationStatus"] = ApplicationStatus;
            if (District != "") query["District"] = District;
            if (Zone != "") query["Zone"] = Zone;
            if (Gender != "") query["Gender"] = Gender;
           
            builder.Query = query.ToString();
            //return builder.Uri.ToString();
            var client = new System.Net.WebClient();
            var jObject_Response = Newtonsoft.Json.Linq.JObject.Parse(client.DownloadString(builder.Uri));
            return jObject_Response.GetValue("Count").ToString();            
        }
        public string GetTotalCountOld(string StotedProcedureName, string MethodName, string ApplicationStatus = "", string District = "", string Zone = "")
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(StotedProcedureName, kvdConn))
                {
                    if (StotedProcedureName != "")
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ZoneName", Zone);
                        cmd.Parameters.AddWithValue("@MethodName", MethodName);
                        cmd.Parameters.AddWithValue("@ApplicationStatusType", ApplicationStatus);
                        cmd.Parameters.AddWithValue("@District", District);
                        cmd.Parameters.Add("@RetValue", SqlDbType.VarChar, -1);
                        cmd.Parameters["@RetValue"].Direction = ParameterDirection.Output;
                        kvdConn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            kvdConn.Close();
                            return cmd.Parameters["@RetValue"].Value.ToString();
                        }
                        //int count = (int)cmd.ExecuteScalar();
                        //return count.ToString();
                    }
                    return "NA";
                }
            }
        }
    }
}