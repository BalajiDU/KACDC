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

namespace KACDC.TestForms
{
    public partial class TestFormSimilarity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
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
            string sql = "select ApplicationNumber,AadharNum from SelfEmpLoan where FinancialYear='2019-20'";
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {

                kvdConn.Open();
                using (SqlDataReader rdr = new SqlCommand(sql, kvdConn).ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        AadhaarEnceyption AE = new AadhaarEnceyption();
                        AadhaarServiceData ADSER = new AadhaarServiceData();
                        AE.GetAadhaarToken(rdr["ApplicationNumber"].ToString());
                        Label2.Text +=("<br />", rdr["ApplicationNumber"].ToString(), rdr["AadharNum"].ToString(), ADSER.AadhaarVaultToken);

                        string updateSQL = "update SelfEmpLoan set	AadharNum=@AadharNum where ApplicationNumber=@ApplicationNumber";
                        SqlCommand cmd = new SqlCommand(updateSQL, kvdConn);
                        cmd.Parameters.AddWithValue("@AadharNum", ADSER.AadhaarVaultToken);
                        cmd.Parameters.AddWithValue("@ApplicationNumber", rdr["ApplicationNumber"].ToString());
                        //Console.WriteLine((string)c["LoginID"]);
                    }
                }
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql = "select ApplicationNumber,AadharNum from SelfEmpLoan where cast(right(ApplicationNumber,6)as int)<5";
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {

                kvdConn.Open();
                using (SqlDataReader Reader = new SqlCommand(sql, kvdConn).ExecuteReader())
                {

                    foreach (System.Data.Common.DbDataRecord rdr in Reader)
                    {
                        AadhaarEnceyption AE = new AadhaarEnceyption();
                        AadhaarServiceData ADSER = new AadhaarServiceData();
                        AE.GetAadhaarToken(rdr["ApplicationNumber"].ToString());
                        Label2.Text += ("<br />", rdr["ApplicationNumber"].ToString(), rdr["AadharNum"].ToString(), ADSER.AadhaarVaultToken);

                        string updateSQL = "update SelfEmpLoan set	AadharNum=@AadharNum where ApplicationNumber=@ApplicationNumber";
                        SqlCommand cmd = new SqlCommand(updateSQL, kvdConn);
                        cmd.Parameters.AddWithValue("@AadharNum", ADSER.AadhaarVaultToken);
                        cmd.Parameters.AddWithValue("@ApplicationNumber", rdr["ApplicationNumber"].ToString());
                        //Console.WriteLine((string)c["LoginID"]);
                    }
                }
            }
        }
    }
}