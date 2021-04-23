using KACDC.Models;
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
        public string GetTotalCount(string StotedProcedureName, string MethodName, string ApplicationStatus = "", string District = "", string Zone = "")
        {
            IEnumerable<CountValue> CW = null;
            HttpClient HC = new HttpClient();
            UriBuilder builder = new UriBuilder();

            if (HttpContext.Current.Request.Url.Host.ToString() == "localhost")
            {
                builder = new UriBuilder("http://localhost:50369/api/ApplicationCount/");
            }
            else
            {
                builder = new UriBuilder("https://aryavysya.karnataka.gov.in/api/ApplicationCount/");
            }
            var query = HttpUtility.ParseQueryString(builder.Query);
            if (StotedProcedureName != "") query["StotedProcedureName"] = StotedProcedureName;
            if (MethodName != "") query["MethodName"] = MethodName;
            if (ApplicationStatus != "") query["ApplicationStatus"] = ApplicationStatus;
            if (District != "") query["District"] = District;
            if (Zone != "") query["Zone"] = Zone;
           
            builder.Query = query.ToString();

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