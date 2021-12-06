using KACDC.Class.DataProcessing.Aadhaar;
using KACDC.Class.DataProcessing.OnlineApplication;
using KACDC.Class.Declaration.Aadhaar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using RestSharp;
using KACDC.Class.DataProcessing.ApplicationProcess;

namespace KACDC.TestForms
{
    public partial class TestFormSimilarity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            CheckNameSimilarity CNS = new CheckNameSimilarity();
            lblRes.Text= (CalculateSimilarity(txt1.Text.Trim(), txt2.Text.Trim())).ToString();

        }

        public  double CalculateSimilarity(string source, string target)
        {
            if (string.IsNullOrEmpty(source))
                return string.IsNullOrEmpty(target) ? 1 : 0;

            if (string.IsNullOrEmpty(target))
                return string.IsNullOrEmpty(source) ? 1 : 0;

            double stepsToSame = ComputeLevenshteinDistance(source, target);
            //return stepsToSame;
            return (1.0 - (stepsToSame / (double)Math.Max(source.Length, target.Length)));
        }

        private int ComputeLevenshteinDistance(string source, string target)
        {
            if (string.IsNullOrEmpty(source))
                return string.IsNullOrEmpty(target) ? 0 : target.Length;

            if (string.IsNullOrEmpty(target))
                return string.IsNullOrEmpty(source) ? 0 : source.Length;

            int sourceLength = source.Length;
            int targetLength = target.Length;

            int[,] distance = new int[sourceLength + 1, targetLength + 1];

            // Step 1
            for (int i = 0; i <= sourceLength; distance[i, 0] = i++) ;
            for (int j = 0; j <= targetLength; distance[0, j] = j++) ;

            for (int i = 1; i <= sourceLength; i++)
            {
                for (int j = 1; j <= targetLength; j++)
                {
                    // Step 2
                    int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    // Step 3
                    distance[i, j] = Math.Min(
                                        Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1),
                                        distance[i - 1, j - 1] + cost);
                }
            }

            return distance[sourceLength, targetLength];
        }

        protected void btnExist_Click(object sender, EventArgs e)
        {
            IsAadhaarExist AE = new IsAadhaarExist();
            Label1.Text=AE.CheckAadhaar(TextBox1.Text.Trim());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //AadhaarServiceData SER = new AadhaarServiceData();
            //SER.AadhaarVaultToken = "Test123456";
            string sql = "select ApplicationNumber,AadharNum from ArivuEduLoan where FinancialYear='2019-20' ";
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {

                kvdConn.Open();
                using (SqlDataReader rdr = new SqlCommand(sql, kvdConn).ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        //AadhaarServiceData ADSER = new AadhaarServiceData();
                        string VaultToken=this.GetAadhaarToken(rdr["AadharNum"].ToString());
                        //ADSER.AadhaarVaultToken = SER.AadhaarVaultToken;
                        Label2.Text +=("<br />", rdr["ApplicationNumber"].ToString(), rdr["AadharNum"].ToString(), VaultToken);

                        

                        using (SqlConnection kvdConn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                        {
                            string updateSQL = "update ArivuEduLoan set	AadharNum=@AadharNum where ApplicationNumber=@ApplicationNumber";
                            SqlCommand cmd = new SqlCommand(updateSQL, kvdConn1);
                            cmd.Parameters.AddWithValue("@AadharNum", VaultToken);
                            cmd.Parameters.AddWithValue("@ApplicationNumber", rdr["ApplicationNumber"].ToString());
                            kvdConn1.Open();
                            cmd.ExecuteNonQuery();
                        }
                        //Console.WriteLine((string)c["LoginID"]);
                    }
                }
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            //AadhaarServiceData SER = new AadhaarServiceData();
            //SER.AadhaarVaultToken = "Test123456";
            string sql = "select ApplicationNumber,AadharNum from ArivuEduLoan where cast(right(ApplicationNumber,6)as int)<5";
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {

                kvdConn.Open();
                using (SqlDataReader Reader = new SqlCommand(sql, kvdConn).ExecuteReader())
                {
                    //SqlDataReader ReaderTemp = new SqlDataReader();
                    //ReaderTemp = Reader;
                    //Reader.Close();
                    foreach (System.Data.Common.DbDataRecord rdr in Reader)
                    {
                        //AadhaarServiceData ADSER = new AadhaarServiceData();
                        string VaultToken=this.GetAadhaarToken(rdr["AadharNum"].ToString());
                        //ADSER.AadhaarVaultToken = SER.AadhaarVaultToken;
                        Label2.Text += ("<br />", rdr["ApplicationNumber"].ToString(), rdr["AadharNum"].ToString(), VaultToken);

                        using (SqlConnection kvdConn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                        {
                            string updateSQL = "update ArivuEduLoan set	AadharNum=@AadharNum where ApplicationNumber=@ApplicationNumber";
                            SqlCommand cmd = new SqlCommand(updateSQL, kvdConn1);
                            cmd.Parameters.AddWithValue("@AadharNum", VaultToken);
                            cmd.Parameters.AddWithValue("@ApplicationNumber", rdr["ApplicationNumber"].ToString());
                            kvdConn1.Open();
                            cmd.ExecuteNonQuery();
                        }
                        //Console.WriteLine((string)c["LoginID"]);
                    }
                }
            }
        }
        public string GetAadhaarToken(string AadhaarNumber)
        {
            try
            {
                var client = new RestClient("http://172.31.36.246:8080/tmrest/SafeNetTokenManager/insertToken");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                //request.AddParameter("application/json", "{\"naeUser\":\"tmtestuser\",\"naePassword\":\"P@ssw0rd\",\"dbUser\":\"DBTEST\",\"dbPassword\":\"rndo_1234\",\"value\":\"" + txtAadhaar.Text.Trim() + "\",\"tableName\":\"DBVAULT\",\"format\":\"103\"}", ParameterType.RequestBody);
                request.AddParameter("application/json", "{\"naeUser\":\"" + ConfigurationSettings.AppSettings["naeUser"].ToString() +
                    "\",\"naePassword\":\"" + ConfigurationSettings.AppSettings["naePassword"].ToString() +
                    "\",\"dbUser\":\"" + ConfigurationSettings.AppSettings["dbUser"].ToString() +
                    "\",\"dbPassword\":\"" + ConfigurationSettings.AppSettings["dbPassword"].ToString() +
                    "\",\"value\":\"" + AadhaarNumber +
                    "\",\"tableName\":\"" + ConfigurationSettings.AppSettings["tableName"].ToString() +
                    "\",\"format\":\"" + ConfigurationSettings.AppSettings["format"].ToString() + "\"}", RestSharp.ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                //Response.Write("___response Data" + response.Content);
                string responseData = response.Content;

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    var jObject = JObject.Parse(response.Content);
                    //string token1 = jObject.GetValue("token").ToString();
                    return jObject.GetValue("token").ToString();

                    //Response.Write("___response token is:" + token1);
                }
                else
                {
                    //Response.Write("___response code:" + response.StatusCode.ToString());
                    //Response.Write("___response code:" + response.ErrorMessage);
                }
                return "NA";
            }
            catch (Exception ex)
            {
                //DisplayAlert(ex.Message, this);
                return "ER";
            }
        }
        private void Update(string AadhaarVaultToken, string ApplicationNumber)
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                string updateSQL = "update ArivuEduLoan set	AadharNum=@AadharNum where ApplicationNumber=@ApplicationNumber";
                SqlCommand cmd = new SqlCommand(updateSQL, kvdConn);
                cmd.Parameters.AddWithValue("@AadharNum", AadhaarVaultToken);
                cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                cmd.ExecuteNonQuery();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Write(this.GetAadhaarToken("301007056373"));
        }
    }
}