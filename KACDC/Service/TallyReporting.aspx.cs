using KACDC.Class.DataProcessing.ApplicationProcess;
using KACDC.Class.DataProcessing.FileProcessing;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KACDC.Service
{
    public partial class TallyReporting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                fillDistrict();
                FillFY();
            }
        }
        private void fillDistrict()
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select DistrictName from MstDistrict "))
                {
                    cmd.CommandType = CommandType.Text;
                    //cmd.Parameters.AddWithValue("@District", Session["Zone"].ToString());
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    drpDistrict.DataSource = cmd.ExecuteReader();
                    drpDistrict.DataTextField = "DistrictName";
                    drpDistrict.DataValueField = "DistrictName";
                    drpDistrict.DataBind();
                    drpDistrict.Items.Insert(0, "District");
                    kvdConn.Close();
                }
            }
        }

        protected void btnDownloadExcel_Click(object sender, EventArgs e)
        {
            ExcelFileOperations EFO = new ExcelFileOperations();
            GetDataToProcess GDTP = new GetDataToProcess();
            //DataTable dt = GDTP.GetData("spGetDataToApprovalProcess", "SESELECTRELEASE", drpDistrict.SelectedValue);
            DataSet DS = new DataSet();
            DataTable dt = new DataTable();



            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetTallyApplications", kvdConn))//"spGetDataToApprovalProcess"
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (drpZone.SelectedIndex != 0)
                        cmd.Parameters.AddWithValue("@FinancialYear", drpFinancialYear.SelectedValue); //"SESELECTCW"
                    if (drpZone.SelectedIndex != 0)
                        cmd.Parameters.AddWithValue("@Zone", drpZone.SelectedValue); //"SESELECTCW"
                    if (drpDistrict.SelectedIndex != 0)
                        cmd.Parameters.AddWithValue("@District", drpDistrict.SelectedValue);//"Bengaluru Dakshina"
                    cmd.Parameters.AddWithValue("@MethodName", "SEReport");

                    cmd.Connection = kvdConn;
                    //kvdConn.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                        //if (TableName != "")
                        //    dt.TableName = TableName;
                        //return dt;
                    }
                    //kvdConn.Close();
                }
            }




            DS.Tables.Add(dt);
            EFO.ExportToExcel(DS, Server.MapPath("~/Files_SelfEmployment/"), drpFinancialYear.SelectedValue + "_SelfEmployment_Report.xlsx", "1", drpDistrict.SelectedValue);
            if (System.IO.File.Exists(Server.MapPath("~/Files_SelfEmployment/" + drpFinancialYear.SelectedValue + "_SelfEmployment_Report.xlsx")))
            {
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; " + drpFinancialYear.SelectedValue + "_SelfEmployment_Report.xlsx");
                //Response.TransmitFile(Server.MapPath("~/Files_Arivu/" + ARRD.Installment + "/RenewalRequestCopy/" + ARRD.FILENAME + ".pdf"));
                //Response.ContentType = "application/pdf";
                //Response.Buffer = true;
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();
            }
        }

        protected void drpZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpZone.SelectedValue != "0")
            {
                using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("select DistrictName from MstDistrict where ZoneName=@District"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@District", drpZone.SelectedValue);
                        cmd.Connection = kvdConn;
                        kvdConn.Open();
                        drpDistrict.DataSource = cmd.ExecuteReader();
                        drpDistrict.DataTextField = "DistrictName";
                        drpDistrict.DataValueField = "DistrictName";
                        drpDistrict.DataBind();
                        drpDistrict.Items.Insert(0, "District");
                        kvdConn.Close();
                    }
                }
            }
            else
            {
                fillDistrict();
            }
        }

        protected void drpDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void FillFY()
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select distinct FinancialYear from SelfEmpLoan"))
                {
                    cmd.CommandType = CommandType.Text;
                    //cmd.Parameters.AddWithValue("@District", Session["Zone"].ToString());
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    drpFinancialYear.DataSource = cmd.ExecuteReader();
                    drpFinancialYear.DataTextField = "FinancialYear";
                    drpFinancialYear.DataValueField = "FinancialYear";
                    drpFinancialYear.DataBind();
                    drpFinancialYear.Items.Insert(0, "Financial Year");
                    kvdConn.Close();
                }
            }
        }
        protected void drpFinancialYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
