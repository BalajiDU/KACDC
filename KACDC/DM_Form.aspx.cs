using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using Microsoft.Reporting.WebForms;
using Ionic.Zip;
using System.Net.Mail;
using System.Collections;
using System.Net;

namespace KACDC
{
    public partial class DM_Form : System.Web.UI.Page
    {
        SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
        BinaryReader br = null;
        Stream fs = null;

        static Byte[] byCEODocArivu;
        static string ArApplicationNumber, SeApplicationNumber;
        static string District;
        static string SEFileNum, ARFileNum;
        static int ArivuFile, SEFile;
        static string ArDocApplicationNumber, SEDocApplicationNumber;

        private string ApplicationNumber
        {
            set { ViewState["ApplicationNumber"] = value; }
            get { return ViewState["ApplicationNumber"] as string; }
        }
        private string getDistrict
        {
            set { ViewState["getDistrict"] = value; }
            get { return ViewState["getDistrict"] as string; }
        }

        private string FinancialYear
        {
            set { ViewState["FinancialYear"] = value; }
            get { return ViewState["FinancialYear"] as string; }
        }        
        private string SenderPassword
        {
            set { ViewState["SenderPassword"] = value; }
            get { return ViewState["SenderPassword"] as string; }
        }
        private string SenderMailID
        {
            set { ViewState["SenderMailID"] = value; }
            get { return ViewState["SenderMailID"] as string; }
        }
        private string ToMail
        {
            set { ViewState["ToMail"] = value; }
            get { return ViewState["ToMail"] as string; }
        }
        private string CCMail
        {
            set { ViewState["CCMail"] = value; }
            get { return ViewState["CCMail"] as string; }
        }
        private string PortNum
        {
            set { ViewState["PortNum"] = value; }
            get { return ViewState["PortNum"] as string; }
        }
        private string SMTP_Server
        {
            set { ViewState["SMTP_Server"] = value; }
            get { return ViewState["SMTP_Server"] as string; }
        }

        private string UserName
        {
            set { ViewState["UserName"] = value; }
            get { return ViewState["UserName"] as string; }
        }

        //string ApplicationNumber;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

            if (Session["USERTYPE"] != "DISTRICTMANAGER")
            {
                Response.Redirect("~/Login.aspx");
                UserName = Session["UserName"].ToString();
            }
            if (Session["District"] != null)
            {
                getDistrict = Session["District"].ToString();
            }
            try
            {
                using (kvdConn)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[KACDCInfo]"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = kvdConn;
                        kvdConn.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();                            
                            FinancialYear = sdr["FinancialYear"].ToString();
                            SenderPassword = sdr["SenderPassword"].ToString();
                            SenderMailID = sdr["SenderMailID"].ToString();
                            ToMail = sdr["ToMail"].ToString();
                            CCMail = sdr["CCMail"].ToString();
                            PortNum = sdr["SmtpServerPortNum"].ToString();
                            SMTP_Server= sdr["SMTP_Server"].ToString();
                        }
                        kvdConn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

            if (!this.IsPostBack)
            {
                RefreshAllData();
            }
            //this.filldrp();
            divCEOgv.Visible = false;
            divCEOSE.Visible = false;
        }
        private void RefreshAllData()
        {
            this.ArivuDMApproveBindGrid();
            this.SEDMApproveBindGrid();
            this.ArivuDocApproveBindGrid();
            this.SEDocApproveBindGrid();
            this.ArivuCEOWaitingBindGrid();
            this.SECEOWaitingBindGrid();
            this.SEDMPrintingBindGrid();
            this.SECEOApproveBindGrid();
            this.DMDocReportPrintBindGrid();
            this.ArivuCEOApproveBindGrid();
        }
        private void SEDMPrintingBindGrid()
        {
            string DistCode = "";
            if (UserName == "DMBLRS")
            {
                DistCode = "1";
            }
            else if (UserName == "DMBLRN")
            {
                DistCode = "31";
            }
            else
            {
                using (kvdConn)
                {
                    SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                    DataSet ds = new DataSet();
                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("spPrinting", kvdConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@status", "SEDMCEOWAITING");
                    cmd.Parameters.AddWithValue("@District", getDistrict);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    kvdConn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        SEgvDMCEOWaitingList.DataSource = ds;
                        SEgvDMCEOWaitingList.DataBind();
                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        SEgvDMCEOWaitingList.DataSource = ds;
                        SEgvDMCEOWaitingList.DataBind();
                        int columncount = SEgvDMCEOWaitingList.Rows[0].Cells.Count;
                        SEgvDMCEOWaitingList.Rows[0].Cells.Clear();
                        SEgvDMCEOWaitingList.Rows[0].Cells.Add(new TableCell());
                        SEgvDMCEOWaitingList.Rows[0].Cells[0].ColumnSpan = columncount;
                        SEgvDMCEOWaitingList.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
            //SE Pringting 
            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                DataSet ds = new DataSet();
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spPrinting", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "SEDMCEOAPPROVED");
                cmd.Parameters.AddWithValue("@District", getDistrict);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    SEgvDMCEOApprovedList.DataSource = ds;
                    SEgvDMCEOApprovedList.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    SEgvDMCEOApprovedList.DataSource = ds;
                    SEgvDMCEOApprovedList.DataBind();
                    int columncount = SEgvDMCEOApprovedList.Rows[0].Cells.Count;
                    SEgvDMCEOApprovedList.Rows[0].Cells.Clear();
                    SEgvDMCEOApprovedList.Rows[0].Cells.Add(new TableCell());
                    SEgvDMCEOApprovedList.Rows[0].Cells[0].ColumnSpan = columncount;
                    SEgvDMCEOApprovedList.Rows[0].Cells[0].Text = "No Records Found";
                }
            }

            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                DataSet ds = new DataSet();
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spPrinting", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "SEDMCEOREJECTED");
                cmd.Parameters.AddWithValue("@District", getDistrict);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    SEgvDMCEORejectedList.DataSource = ds;
                    SEgvDMCEORejectedList.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    SEgvDMCEORejectedList.DataSource = ds;
                    SEgvDMCEORejectedList.DataBind();
                    int columncount = SEgvDMCEORejectedList.Rows[0].Cells.Count;
                    SEgvDMCEORejectedList.Rows[0].Cells.Clear();
                    SEgvDMCEORejectedList.Rows[0].Cells.Add(new TableCell());
                    SEgvDMCEORejectedList.Rows[0].Cells[0].ColumnSpan = columncount;
                    SEgvDMCEORejectedList.Rows[0].Cells[0].Text = "No Records Found";
                }
            }

            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                DataSet ds = new DataSet();
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spPrinting", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "ARDMCEOAPPROVED");
                cmd.Parameters.AddWithValue("@District", getDistrict);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ArivugvDMCEOApprovedList.DataSource = ds;
                    ArivugvDMCEOApprovedList.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    ArivugvDMCEOApprovedList.DataSource = ds;
                    ArivugvDMCEOApprovedList.DataBind();
                    int columncount = ArivugvDMCEOApprovedList.Rows[0].Cells.Count;
                    ArivugvDMCEOApprovedList.Rows[0].Cells.Clear();
                    ArivugvDMCEOApprovedList.Rows[0].Cells.Add(new TableCell());
                    ArivugvDMCEOApprovedList.Rows[0].Cells[0].ColumnSpan = columncount;
                    ArivugvDMCEOApprovedList.Rows[0].Cells[0].Text = "No Records Found";
                }
            }
            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                DataSet ds = new DataSet();
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spPrinting", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "ARDMCEOWAITING");
                cmd.Parameters.AddWithValue("@District", getDistrict);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ArivugvDMCEOWaitingList.DataSource = ds;
                    ArivugvDMCEOWaitingList.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    ArivugvDMCEOWaitingList.DataSource = ds;
                    ArivugvDMCEOWaitingList.DataBind();
                    int columncount = ArivugvDMCEOWaitingList.Rows[0].Cells.Count;
                    ArivugvDMCEOWaitingList.Rows[0].Cells.Clear();
                    ArivugvDMCEOWaitingList.Rows[0].Cells.Add(new TableCell());
                    ArivugvDMCEOWaitingList.Rows[0].Cells[0].ColumnSpan = columncount;
                    ArivugvDMCEOWaitingList.Rows[0].Cells[0].Text = "No Records Found";
                }
            }
            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                DataSet ds = new DataSet();
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spPrinting", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "ARDMCEOREJECTED");
                cmd.Parameters.AddWithValue("@District", getDistrict);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ArivugvDMCEORejectedList.DataSource = ds;
                    ArivugvDMCEORejectedList.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    ArivugvDMCEORejectedList.DataSource = ds;
                    ArivugvDMCEORejectedList.DataBind();
                    int columncount = ArivugvDMCEORejectedList.Rows[0].Cells.Count;
                    ArivugvDMCEORejectedList.Rows[0].Cells.Clear();
                    ArivugvDMCEORejectedList.Rows[0].Cells.Add(new TableCell());
                    ArivugvDMCEORejectedList.Rows[0].Cells[0].ColumnSpan = columncount;
                    ArivugvDMCEORejectedList.Rows[0].Cells[0].Text = "No Records Found";
                }
            }
        }
        private void DMDocReportPrintBindGrid()
        {

            //SE Pringting 

            //Doc
            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                DataSet ds = new DataSet();
                //kvdConn.Open();
                if (kvdConn.State == ConnectionState.Closed)
                {
                    kvdConn.Open();
                }
                SqlCommand cmd = new SqlCommand("spPrinting", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "SEDMDocWAITING");
                cmd.Parameters.AddWithValue("@District", getDistrict);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    SEDMDocPrintWaiting.DataSource = ds;
                    SEDMDocPrintWaiting.DataBind();
                }
                else
                {
                    //ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    //SEDMDocPrintWaiting.DataSource = ds;
                    //SEDMDocPrintWaiting.DataBind();
                    //int columncount = SEDMDocPrintWaiting.Rows[0].Cells.Count;
                    //SEDMDocPrintWaiting.Rows[0].Cells.Clear();
                    //SEDMDocPrintWaiting.Rows[0].Cells.Add(new TableCell());
                    //SEDMDocPrintWaiting.Rows[0].Cells[0].ColumnSpan = columncount;
                    //SEDMDocPrintWaiting.Rows[0].Cells[0].Text = "No Records Found";
                }
            }

            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                DataSet ds = new DataSet();
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spPrinting", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "SEDMDocAPPROVED");
                cmd.Parameters.AddWithValue("@District", getDistrict);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    SEDMDocPrintApprove.DataSource = ds;
                    SEDMDocPrintApprove.DataBind();
                }
                else
                {
                    //ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    //SEDMDocPrintApprove.DataSource = ds;
                    //SEDMDocPrintApprove.DataBind();
                    //int columncount = SEDMDocPrintApprove.Rows[0].Cells.Count;
                    //SEDMDocPrintApprove.Rows[0].Cells.Clear();
                    //SEDMDocPrintApprove.Rows[0].Cells.Add(new TableCell());
                    //SEDMDocPrintApprove.Rows[0].Cells[0].ColumnSpan = columncount;
                    //SEDMDocPrintApprove.Rows[0].Cells[0].Text = "No Records Found";
                }
            }

            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                DataSet ds = new DataSet();
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spPrinting", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "SEDMDocREJECTED");
                cmd.Parameters.AddWithValue("@District", getDistrict);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    SEDMDocPrintReject.DataSource = ds;
                    SEDMDocPrintReject.DataBind();
                }
                else
                {
                    //ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    //SEDMDocPrintReject.DataSource = ds;
                    //SEDMDocPrintReject.DataBind();
                    //int columncount = SEDMDocPrintReject.Rows[0].Cells.Count;
                    //SEDMDocPrintReject.Rows[0].Cells.Clear();
                    //SEDMDocPrintReject.Rows[0].Cells.Add(new TableCell());
                    //SEDMDocPrintReject.Rows[0].Cells[0].ColumnSpan = columncount;
                    //SEDMDocPrintReject.Rows[0].Cells[0].Text = "No Records Found";
                }
            }
            //Ar Pringting 

            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                DataSet ds = new DataSet();
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spPrinting", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "ARDMDocAPPROVED");
                cmd.Parameters.AddWithValue("@District", getDistrict);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ARDMDocPrintApprove.DataSource = ds;
                    ARDMDocPrintApprove.DataBind();
                }
                else
                {
                    //ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    //ARDMDocPrintApprove.DataSource = ds;
                    //ARDMDocPrintApprove.DataBind();
                    //int columncount = ARDMDocPrintApprove.Rows[0].Cells.Count;
                    //ARDMDocPrintApprove.Rows[0].Cells.Clear();
                    //ARDMDocPrintApprove.Rows[0].Cells.Add(new TableCell());
                    //ARDMDocPrintApprove.Rows[0].Cells[0].ColumnSpan = columncount;
                    //ARDMDocPrintApprove.Rows[0].Cells[0].Text = "No Records Found";
                }
            }
            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                DataSet ds = new DataSet();
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spPrinting", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "ARDMDocWAITING");
                cmd.Parameters.AddWithValue("@District", getDistrict);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ARDMDocPrintWaiting.DataSource = ds;
                    ARDMDocPrintWaiting.DataBind();
                }
                else
                {
                    //ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    //ARDMDocPrintWaiting.DataSource = ds;
                    //ARDMDocPrintWaiting.DataBind();
                    //int columncount = ARDMDocPrintWaiting.Rows[0].Cells.Count;
                    //ARDMDocPrintWaiting.Rows[0].Cells.Clear();
                    //ARDMDocPrintWaiting.Rows[0].Cells.Add(new TableCell());
                    //ARDMDocPrintWaiting.Rows[0].Cells[0].ColumnSpan = columncount;
                    //ARDMDocPrintWaiting.Rows[0].Cells[0].Text = "No Records Found";
                }
            }
            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                DataSet ds = new DataSet();
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spPrinting", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "ARDMDocREJECTED");
                cmd.Parameters.AddWithValue("@District", getDistrict);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ARDMDocPrintReject.DataSource = ds;
                    ARDMDocPrintReject.DataBind();
                }
                else
                {
                    //ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    //ARDMDocPrintReject.DataSource = ds;
                    //ARDMDocPrintReject.DataBind();
                    //int columncount = ARDMDocPrintReject.Rows[0].Cells.Count;
                    //ARDMDocPrintReject.Rows[0].Cells.Clear();
                    //ARDMDocPrintReject.Rows[0].Cells.Add(new TableCell());
                    //ARDMDocPrintReject.Rows[0].Cells[0].ColumnSpan = columncount;
                    //ARDMDocPrintReject.Rows[0].Cells[0].Text = "No Records Found";
                }
            }
        }
        private void SEDMApproveBindGrid()
        {

            DataSet ds = new DataSet();
            string DistCode = "";
            if (UserName == "DMBLRS")
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                DistCode = "1";
                string SQL = @"SELECT DISTINCT * FROM SelfEmpLoan SE INNER JOIN
(SELECT min(Dis.DistrictCD) AS ID,Dis.DistrictName AS DName FROM MstDistrict Dis group by DIS.DistrictName) AS TabDiS ON 
	TabDiS.DName=SE.ParDistrict AND ParDistrict='Bengaluru (U)' AND CWApprove !='PENDING' AND DMApprove='PENDING'
	 INNER JOIN MstConstituencies AS Con ON	Con.AssemblyName=SE.ParConstituency AND	Con.DistrictCD=@DistCode 
ORDER BY ApplicationNumber ";
                using (kvdConn)
                {

                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(SQL, kvdConn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DistCode", DistCode);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    kvdConn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        SEDMApprove.DataSource = ds;
                        SEDMApprove.DataBind();

                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        SEDMApprove.DataSource = ds;
                        SEDMApprove.DataBind();
                        int columncount = SEDMApprove.Rows[0].Cells.Count;
                        SEDMApprove.Rows[0].Cells.Clear();
                        SEDMApprove.Rows[0].Cells.Add(new TableCell());
                        SEDMApprove.Rows[0].Cells[0].ColumnSpan = columncount;
                        SEDMApprove.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
            else if (UserName == "DMBLRN")
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                DistCode = "31";
                string SQL = @"SELECT DISTINCT * FROM SelfEmpLoan SE INNER JOIN
(SELECT min(Dis.DistrictCD) AS ID,Dis.DistrictName AS DName FROM MstDistrict Dis group by DIS.DistrictName) AS TabDiS ON 
	TabDiS.DName=SE.ParDistrict AND ParDistrict='Bengaluru (U)' AND CWApprove !='PENDING' AND DMApprove='PENDING'
	 INNER JOIN MstConstituencies AS Con ON	Con.AssemblyName=SE.ParConstituency AND	Con.DistrictCD=@DistCode 
ORDER BY ApplicationNumber ";
                using (kvdConn)
                {

                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(SQL, kvdConn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DistCode", DistCode);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    kvdConn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        SEDMApprove.DataSource = ds;
                        SEDMApprove.DataBind();

                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        SEDMApprove.DataSource = ds;
                        SEDMApprove.DataBind();
                        int columncount = SEDMApprove.Rows[0].Cells.Count;
                        SEDMApprove.Rows[0].Cells.Clear();
                        SEDMApprove.Rows[0].Cells.Add(new TableCell());
                        SEDMApprove.Rows[0].Cells[0].ColumnSpan = columncount;
                        SEDMApprove.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
            else
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                using (kvdConn)
                {

                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("spSEApprove", kvdConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@status", "SESELECTDM");
                    cmd.Parameters.AddWithValue("@District", getDistrict);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    kvdConn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        SEDMApprove.DataSource = ds;
                        SEDMApprove.DataBind();

                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        SEDMApprove.DataSource = ds;
                        SEDMApprove.DataBind();
                        int columncount = SEDMApprove.Rows[0].Cells.Count;
                        SEDMApprove.Rows[0].Cells.Clear();
                        SEDMApprove.Rows[0].Cells.Add(new TableCell());
                        SEDMApprove.Rows[0].Cells[0].ColumnSpan = columncount;
                        SEDMApprove.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
        }

        private void ArivuDMApproveBindGrid()
        {

            DataSet ds = new DataSet();
            //DM
            string DistCode = "";
            if (UserName == "DMBLRS")
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                DistCode = "1";
                string SQL = @"SELECT DISTINCT * FROM ArivuEduLoan SE INNER JOIN
(SELECT min(Dis.DistrictCD) AS ID,Dis.DistrictName AS DName FROM MstDistrict Dis group by DIS.DistrictName) AS TabDiS ON 
	TabDiS.DName=SE.ParDistrict AND ParDistrict='Bengaluru (U)' AND CWApprove !='PENDING' AND DMApprove='PENDING'
	 INNER JOIN MstConstituencies AS Con ON	Con.AssemblyName=SE.ParConstituency AND	Con.DistrictCD=@DistCode 
ORDER BY ApplicationNumber ";
                using (kvdConn)
                {

                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(SQL, kvdConn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DistCode", DistCode);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    try
                    {
                        da.Fill(ds);
                        kvdConn.Close();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ArivugvDMApprove.DataSource = ds;
                            ArivugvDMApprove.DataBind();

                        }
                        else
                        {
                            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                            ArivugvDMApprove.DataSource = ds;
                            ArivugvDMApprove.DataBind();
                            int columncount = ArivugvDMApprove.Rows[0].Cells.Count;
                            ArivugvDMApprove.Rows[0].Cells.Clear();
                            ArivugvDMApprove.Rows[0].Cells.Add(new TableCell());
                            ArivugvDMApprove.Rows[0].Cells[0].ColumnSpan = columncount;
                            ArivugvDMApprove.Rows[0].Cells[0].Text = "No Records Found";
                        }
                    }

                    catch (StackOverflowException ex)
                    {
                        DisplayAlert(ex.ToString(), this);
                    }
                }
            }
            else if (UserName == "DMBLRN")
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                DistCode = "31";
                string SQL = @"SELECT DISTINCT * FROM ArivuEduLoan SE INNER JOIN
(SELECT min(Dis.DistrictCD) AS ID,Dis.DistrictName AS DName FROM MstDistrict Dis group by DIS.DistrictName) AS TabDiS ON 
	TabDiS.DName=SE.ParDistrict AND ParDistrict='Bengaluru (U)' AND CWApprove !='PENDING' AND DMApprove='PENDING'
	 INNER JOIN MstConstituencies AS Con ON	Con.AssemblyName=SE.ParConstituency AND	Con.DistrictCD=@DistCode 
ORDER BY ApplicationNumber ";
                using (kvdConn)
                {

                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(SQL, kvdConn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DistCode", DistCode);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    try
                    {
                        da.Fill(ds);
                        kvdConn.Close();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ArivugvDMApprove.DataSource = ds;
                            ArivugvDMApprove.DataBind();

                        }
                        else
                        {
                            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                            ArivugvDMApprove.DataSource = ds;
                            ArivugvDMApprove.DataBind();
                            int columncount = ArivugvDMApprove.Rows[0].Cells.Count;
                            ArivugvDMApprove.Rows[0].Cells.Clear();
                            ArivugvDMApprove.Rows[0].Cells.Add(new TableCell());
                            ArivugvDMApprove.Rows[0].Cells[0].ColumnSpan = columncount;
                            ArivugvDMApprove.Rows[0].Cells[0].Text = "No Records Found";
                        }
                    }

                    catch (StackOverflowException ex)
                    {
                        DisplayAlert(ex.ToString(), this);
                    }
                }
            }
            else
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                using (kvdConn)
                {

                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("spDMApprove", kvdConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@status", "ARSELECTDM");
                    cmd.Parameters.AddWithValue("@District", getDistrict);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    try
                    {
                        da.Fill(ds);
                        kvdConn.Close();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ArivugvDMApprove.DataSource = ds;
                            ArivugvDMApprove.DataBind();

                        }
                        else
                        {
                            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                            ArivugvDMApprove.DataSource = ds;
                            ArivugvDMApprove.DataBind();
                            int columncount = ArivugvDMApprove.Rows[0].Cells.Count;
                            ArivugvDMApprove.Rows[0].Cells.Clear();
                            ArivugvDMApprove.Rows[0].Cells.Add(new TableCell());
                            ArivugvDMApprove.Rows[0].Cells[0].ColumnSpan = columncount;
                            ArivugvDMApprove.Rows[0].Cells[0].Text = "No Records Found";
                        }
                    }

                    catch (StackOverflowException ex)
                    {
                        DisplayAlert(ex.ToString(), this);
                    }
                }
            }
        }
        protected void btnArivuDMApprovee_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = ArivugvDMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();

            spDMStatus("ARAPPROVEDM","", ApplicationNumber);

            this.ArivuDMApproveBindGrid();
            this.SEDMApproveBindGrid();
            RefreshAllData();
        }

        protected void btnArivuDMReject_Click(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            ArApplicationNumber = ArivugvDMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            RefreshAllData();
            //divDMArivuRejectReason.Visible = true;            
        }
        protected void btnCancelSEDM_Click(object sender, EventArgs e)
        {
            SEDMApprove.EditIndex = -1;
            this.SEDMApproveBindGrid();
            RefreshAllData();
        }

        protected void OnUpdateSEDM_Click(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            string ArApplicationNumber = (row.FindControl("txtSEDMAppNum") as TextBox).Text;
            string ab = SEDMApprove.DataKeyNames.ToString();
            string SERR = string.Empty;
            ListBox cblProject = (ListBox)(row.FindControl("drpSEDMRejectReason"));
            foreach (System.Web.UI.WebControls.ListItem item in cblProject.Items)
            {
                if (item.Selected)
                {
                    SERR += item.Text + ",";

                }
            }
            //spSEDMStatus("SEREJECTDM", ApplicationNumber);
            spSEDMStatus("SEREJECTDM", SERR, ArApplicationNumber);
            SEDMApprove.EditIndex = -1;
            //this.SEDMApproveBindGrid();
            RefreshAllData();
        }

        protected void spDMStatus(string status,string RejectReason, string ApplicationNumber)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

            using (kvdConn)
            {
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spDMApprove", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (status == "ARREJECTDM")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                    cmd.Parameters.AddWithValue("@DMRejectReason", RejectReason);
                }
                else if (status == "ARAPPROVEDM")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                }

                cmd.ExecuteNonQuery();
                //lblresult.ForeColor = Color.Green;
                //lblresult.Text = YearLoan1 + " details " + status.ToLower() + "d successfully";
                ArivugvDMApprove.EditIndex = -1;
                //ArivuDMApproveBindGrid();
            }
        }

        protected void btnCasteIncome_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string RDNumber = ArivugvDMApprove.DataKeys[rowindex].Values["RDNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath(@"~/ArivuAppFileData/ARCasteIncomeCert\");
            string filepath1 = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = RDNumber + ".pdf";
            string sPathToSaveFileTo = filepath + filename;
            if (File.Exists(sPathToSaveFileTo))
            { File.Copy(sPathToSaveFileTo, filepath1 + filename); }
            string DBFile = "DocCasteIncome";
            ViewFile(DBFile, RDNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[ArivuEduLoan]");

        }

        protected void btnDispPH_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = ArivugvDMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = ApplicationNumber + "PH.pdf";
            string sPathToSaveFileTo = filepath + filename;
            string DBFile = "DocPhyCha";
            ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[ArivuEduLoan]");
        }

        protected void btnDispPassbook_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = ArivugvDMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = ApplicationNumber + "Passbook.pdf";
            string sPathToSaveFileTo = filepath + filename;
            string DBFile = "DocBankPassbook";
            ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[ArivuEduLoan]");
        }

        protected void btnDispCET_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = ArivugvDMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = ApplicationNumber + "CET.pdf";
            string sPathToSaveFileTo = filepath + filename;
            string DBFile = "DocCETAdmissionTicate";
            ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[ArivuEduLoan]");
        }

        protected void btnStudyCertificate_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = ArivugvDMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = ApplicationNumber + "StudyCertificate.pdf";
            string sPathToSaveFileTo = filepath + filename;
            string DBFile = "DocStudyCertificate";
            ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[ArivuEduLoan]");
        }

        protected void btnDispClgHostel_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = ArivugvDMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = ApplicationNumber + "ClgHostel.pdf";
            string sPathToSaveFileTo = filepath + filename;
            string DBFile = "DocCollegeHostel";
            ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[ArivuEduLoan]");
        }

        protected void btnFeeStruct_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = ArivugvDMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = ApplicationNumber + "FeeStructure.pdf";
            string sPathToSaveFileTo = filepath + filename;
            string DBFile = "DocFeesStructure";
            ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[ArivuEduLoan]");
        }

        protected void btnMarksCard_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = ArivugvDMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = ApplicationNumber + "MarksCard.pdf";
            string sPathToSaveFileTo = filepath + filename;
            string DBFile = "DocPrevMarksCard";
            ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[ArivuEduLoan]");
        }

        protected void btnDispAadhar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string AadharNum = ArivugvDMApprove.DataKeys[rowindex].Values["AadharNum"].ToString();
            string filepath = HttpContext.Current.Server.MapPath(@"~/ArivuAppFileData\ARAadharCard\");
            string filepath1 = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename1 = AadharNum + ".png";
            string filename2 = AadharNum + ".png";
            string filename3 = AadharNum + ".pdf";
            string sPathToSaveFileTo1 = filepath + filename1;
            string sPathToSaveFileTo2 = filepath + filename2;
            string sPathToSaveFileTo3 = filepath1 + filename3;
            string DBFile = "ImgAadharFront";
            //ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[ArivuEduLoan]");
            //using (kvdConn)
            //{
            //    kvdConn.Open();
            //    using (SqlCommand cmd = new SqlCommand("select ImgAadharFront,ImgAadharBack from [KACDC].[dbo].[ArivuEduLoan] where [ApplicationNumber]='" + ApplicationNumber + "' ", kvdConn))
            //    {
            //        using (SqlDataReader dr1 = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
            //        {
            //            if (dr1.Read())
            //            {
            //                // read in using GetValue and cast to byte array
            //                byte[] fileData1 = ((byte[])dr1["ImgAadharFront"]);
            //                // write bytes to disk as file
            //                using (System.IO.FileStream fs = new System.IO.FileStream(sPathToSaveFileTo1, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
            //                {
            //                    // use a binary writer to write the bytes to disk
            //                    using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
            //                    {
            //                        bw.Write(fileData1);
            //                        bw.Close();
            //                    }
            //                }
            //                byte[] fileData2 = ((byte[])dr1["ImgAadharBack"]);
            //                // write bytes to disk as file
            //                using (System.IO.FileStream fs = new System.IO.FileStream(sPathToSaveFileTo2, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
            //                {
            //                    // use a binary writer to write the bytes to disk
            //                    using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
            //                    {
            //                        bw.Write(fileData2);
            //                        bw.Close();
            //                    }
            //                }
            //            }
            //            dr1.Close();
            //        }
            //    }
            //}
            try
            {
                using (var doc1 = new iTextSharp.text.Document())
                {
                    PdfWriter writer = PdfWriter.GetInstance(doc1, new FileStream(sPathToSaveFileTo3, FileMode.Create));
                    doc1.Open();

                    //Add the Image file to the PDF document object.
                    iTextSharp.text.Image img1 = iTextSharp.text.Image.GetInstance(sPathToSaveFileTo1);
                    //iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance(sPathToSaveFileTo2);
                    doc1.Add(new Paragraph("AAdhar Front"));
                    doc1.Add(img1);
                    //doc1.Add(new Paragraph("AAdhar Back"));
                    //doc1.Add(img2);
                    doc1.Close();
                }
            }
            catch
            {
                callaadhar(filename3);
            }
            //Download the PDF file.
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", "attachment;filename=ImageExport.pdf");
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.Write(pdfDoc);
            //Response.End();
            callaadhar(filename3);

        }
        public void callaadhar(string filepath)
        {
            Response.Redirect("Download.aspx?File=" + filepath);
        }
        protected void ViewFile(string DBFile, string ApplicationNumber, string filename, string sPathToSaveFileTo, string TableName)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

            using (kvdConn)
            {
                kvdConn.Open();
                using (SqlCommand cmd = new SqlCommand("select " + DBFile + " from " + TableName + " where [ApplicationNumber]='" + ApplicationNumber + "' ", kvdConn))
                {
                    using (SqlDataReader dr1 = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                    {
                        if (dr1.Read())
                        {
                            // read in using GetValue and cast to byte array
                            byte[] fileData = ((byte[])dr1[DBFile]);
                            // write bytes to disk as file
                            using (System.IO.FileStream fs = new System.IO.FileStream(sPathToSaveFileTo, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                            {
                                // use a binary writer to write the bytes to disk
                                using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                                {
                                    bw.Write(fileData);
                                    bw.Close();
                                }
                            }
                        }
                        dr1.Close();
                    }
                }
            }
            //Response.Redirect("Download.aspx?File=" + filename);
            string url = "Download.aspx?File=" + filename;
            string winUrl = "window.open('" + url + "', 'popup_window', 'width=1500,height=500,left=300,top=20,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", winUrl, true);

        }

        protected void btnSEDispPH_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = SEDMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = ApplicationNumber + "Aadhar.pdf";
            string sPathToSaveFileTo = filepath + filename;
            string DBFile = "ImgAadharFront";
            ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[SelfEmpLoan]");
        }

        protected void btnSECasteIncome_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string RDNumber = SEDMApprove.DataKeys[rowindex].Values["RDNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath(@"~/SEAppFielsData/SECasteIncomeCert\");
            string filepath1 = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = RDNumber + ".pdf";
            string sPathToSaveFileTo = filepath + filename;
            if (File.Exists(sPathToSaveFileTo))
            { File.Copy(sPathToSaveFileTo, filepath1 + filename); }
            string DBFile = "DocCasteIncome";
            ViewFile(DBFile, RDNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[SelfEmpLoan]");

        }

        protected void btnSEDispAadhar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string AadharNum = SEDMApprove.DataKeys[rowindex].Values["AadharNum"].ToString();
            string filepath = HttpContext.Current.Server.MapPath(@"~/SEAppFielsData\SEAadharCard\");
            string filepath1 = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename1 = AadharNum + ".png";
            string filename2 = AadharNum + ".png";
            string filename3 = AadharNum + ".pdf";
            string sPathToSaveFileTo1 = filepath + filename1;
            string sPathToSaveFileTo2 = filepath + filename2;
            string sPathToSaveFileTo3 = filepath1 + filename3;
            string DBFile = "ImgAadharFront";
            //ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[SelfEmpLoan]");
            try
            {
                using (var doc1 = new iTextSharp.text.Document())
                {
                    PdfWriter writer = PdfWriter.GetInstance(doc1, new FileStream(sPathToSaveFileTo3, FileMode.Create));
                    doc1.Open();

                    //Add the Image file to the PDF document object.
                    iTextSharp.text.Image img1 = iTextSharp.text.Image.GetInstance(sPathToSaveFileTo1);
                    //iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance(sPathToSaveFileTo2);
                    doc1.Add(new Paragraph("AAdhar Front"));
                    doc1.Add(img1);
                    //doc1.Add(new Paragraph("AAdhar Back"));
                    //doc1.Add(img2);
                    doc1.Close();
                }
            }
            catch
            {
                callaadhar(filename3);
            }
            callaadhar(filename3);
        }

        protected void btnSEDispPassbook_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = SEDMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = ApplicationNumber + "Aadhar.pdf";
            string sPathToSaveFileTo = filepath + filename;
            string DBFile = "DocBankPassbook";
            ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[SelfEmpLoan]");
        }

        protected void btnSEDMApprovee_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = SEDMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();

            spSEDMStatus("SEAPPROVEDM","", ApplicationNumber);

            //this.ArivuDMApproveBindGrid();
            //this.SEDMApproveBindGrid();
            RefreshAllData();
        }

        protected void btnSEDMReject_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = SEDMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();

            // spSEDMStatus("SEREJECTDM", ApplicationNumber);

            //this.ArivuDMApproveBindGrid();
            //this.SEDMApproveBindGrid();
            RefreshAllData();
        }
        protected void spSEDMStatus(string status,string Reason, string ApplicationNumber)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

            using (kvdConn)
            {
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spSEApprove", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (status == "SEAPPROVEDM")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                }
                else if (status == "SEREJECTDM")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@DMRejectReason", Reason);
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                }

                cmd.ExecuteNonQuery();
                //lblresult.ForeColor = Color.Green;
                //lblresult.Text = YearLoan1 + " details " + status.ToLower() + "d successfully";
                ArivugvDMApprove.EditIndex = -1;
                //ArivuDMApproveBindGrid();
                RefreshAllData();
            }
        }
        public static void DisplayAlert(string message, Control owner)
        {
            Page page = (owner as Page) ?? owner.Page;
            if (page == null) return;

            page.ClientScript.RegisterStartupScript(owner.GetType(),
                "ShowMessage", string.Format("<script type='text/javascript'>alert('{0}')</script>",
                message));
        }
        protected void btnExportArivu_Click(object sender, EventArgs e)
        {
            divArivuReport.Visible = true;
            DisplayArivuReport();
        }
        protected void DisplayArivuReport()
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            DataTable dt = new DataTable();
            using (kvdConn)
            {
                DataSet ds = new DataSet();
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spDMApprove", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "ARSELECTCEO");
                cmd.Parameters.AddWithValue("@District", getDistrict);
                SqlDataReader dr = cmd.ExecuteReader();

                dt.Load(dr);
                kvdConn.Close();

            }

            rvDMReportArivu.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            rvDMReportArivu.LocalReport.ReportPath = Server.MapPath("~/DMReport.rdlc");
        }

        protected void btnExportSE_Click(object sender, EventArgs e)
        {
            divSEReportExport.Visible = true;
            DisplaySEReport();
        }
        protected void DisplaySEReport()
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

            DataTable dt = new DataTable();
            using (kvdConn)
            {
                DataSet ds = new DataSet();
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spSEApprove", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "SESELECTCEO");
                cmd.Parameters.AddWithValue("@District", getDistrict);
                SqlDataReader dr = cmd.ExecuteReader();

                dt.Load(dr);
                kvdConn.Close();

            }

            rvDMReportSE.LocalReport.ReportPath = Server.MapPath("~/DMSEReport.rdlc");
            rvDMReportSE.LocalReport.DataSources.Add(new ReportDataSource("SEReportConnection", dt));

        }
        private DataSet GetData(string query)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

            SqlCommand cmd = new SqlCommand(query);
            using (kvdConn)
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = kvdConn;
                    sda.SelectCommand = cmd;
                    using (DataSet ds = new DataSet())
                    {
                        sda.Fill(ds);
                        return ds;
                    }
                }
            }
        }
        private void ArivuCEOApproveBindGrid()
        {
            //RefreshAllData();
            divCEOgv.Visible = true;
            DataSet ds = new DataSet();
            string DistCode = "";
            if (UserName == "DMBLRS")
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                DistCode = "1";
                string SQL = @"SELECT DISTINCT * FROM ArivuEduLoan SE INNER JOIN
(SELECT min(Dis.DistrictCD) AS ID,Dis.DistrictName AS DName FROM MstDistrict Dis group by DIS.DistrictName) AS TabDiS ON 
	TabDiS.DName=SE.ParDistrict AND ParDistrict='Bengaluru (U)' AND DMApprove='APPROVED'AND DMCEOApprove='WAITING'
	 INNER JOIN MstConstituencies AS Con ON	Con.AssemblyName=SE.ParConstituency AND	Con.DistrictCD=@DistCode 
ORDER BY ApplicationNumber ";
                using (kvdConn)
                {

                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(SQL, kvdConn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DistCode", DistCode);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    kvdConn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ArivugvDMCEO.DataSource = ds;
                        ArivugvDMCEO.DataBind();

                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        ArivugvDMCEO.DataSource = ds;
                        ArivugvDMCEO.DataBind();
                        int columncount = ArivugvDMCEO.Rows[0].Cells.Count;
                        ArivugvDMCEO.Rows[0].Cells.Clear();
                        ArivugvDMCEO.Rows[0].Cells.Add(new TableCell());
                        ArivugvDMCEO.Rows[0].Cells[0].ColumnSpan = columncount;
                        ArivugvDMCEO.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
            else if (UserName == "DMBLRN")
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                DistCode = "31";
                string SQL = @"SELECT DISTINCT * FROM ArivuEduLoan SE INNER JOIN
(SELECT min(Dis.DistrictCD) AS ID,Dis.DistrictName AS DName FROM MstDistrict Dis group by DIS.DistrictName) AS TabDiS ON 
	TabDiS.DName=SE.ParDistrict AND ParDistrict='Bengaluru (U)' AND DMApprove='APPROVED'AND DMCEOApprove='WAITING'
	 INNER JOIN MstConstituencies AS Con ON	Con.AssemblyName=SE.ParConstituency AND	Con.DistrictCD=@DistCode 
ORDER BY ApplicationNumber ";
                using (kvdConn)
                {

                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(SQL, kvdConn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DistCode", DistCode);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    kvdConn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ArivugvDMCEO.DataSource = ds;
                        ArivugvDMCEO.DataBind();

                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        ArivugvDMCEO.DataSource = ds;
                        ArivugvDMCEO.DataBind();
                        int columncount = ArivugvDMCEO.Rows[0].Cells.Count;
                        ArivugvDMCEO.Rows[0].Cells.Clear();
                        ArivugvDMCEO.Rows[0].Cells.Add(new TableCell());
                        ArivugvDMCEO.Rows[0].Cells[0].ColumnSpan = columncount;
                        ArivugvDMCEO.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
            else
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                using (kvdConn)
                {

                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("spDMApprove", kvdConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@status", "ARSELECTCEO");
                    cmd.Parameters.AddWithValue("@District", getDistrict);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    kvdConn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ArivugvDMCEO.DataSource = ds;
                        ArivugvDMCEO.DataBind();

                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        ArivugvDMCEO.DataSource = ds;
                        ArivugvDMCEO.DataBind();
                        int columncount = ArivugvDMCEO.Rows[0].Cells.Count;
                        ArivugvDMCEO.Rows[0].Cells.Clear();
                        ArivugvDMCEO.Rows[0].Cells.Add(new TableCell());
                        ArivugvDMCEO.Rows[0].Cells[0].ColumnSpan = columncount;
                        ArivugvDMCEO.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
            
        }
        private void ArivuCEOWaitingBindGrid()
        {
            divCEOgv.Visible = true;
            DataSet ds = new DataSet();
            string DistCode = "";
            if (UserName == "DMBLRS")
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                DistCode = "1";
                string SQL = @"SELECT DISTINCT * FROM ArivuEduLoan SE INNER JOIN
(SELECT min(Dis.DistrictCD) AS ID,Dis.DistrictName AS DName FROM MstDistrict Dis group by DIS.DistrictName) AS TabDiS ON 
	TabDiS.DName=SE.ParDistrict AND ParDistrict='Bengaluru (U)' AND DMApprove='APPROVED'AND DMCEOApprove='WAITING'
	 INNER JOIN MstConstituencies AS Con ON	Con.AssemblyName=SE.ParConstituency AND	Con.DistrictCD=@DistCode 
ORDER BY ApplicationNumber ";
                using (kvdConn)
                {

                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(SQL, kvdConn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DistCode", DistCode);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    kvdConn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ArivugvDMCEOWaiting.DataSource = ds;
                        ArivugvDMCEOWaiting.DataBind();

                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        ArivugvDMCEOWaiting.DataSource = ds;
                        ArivugvDMCEOWaiting.DataBind();
                        int columncount = ArivugvDMCEOWaiting.Rows[0].Cells.Count;
                        ArivugvDMCEOWaiting.Rows[0].Cells.Clear();
                        ArivugvDMCEOWaiting.Rows[0].Cells.Add(new TableCell());
                        ArivugvDMCEOWaiting.Rows[0].Cells[0].ColumnSpan = columncount;
                        ArivugvDMCEOWaiting.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
            else if (UserName == "DMBLRN")
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                DistCode = "31";
                string SQL = @"SELECT DISTINCT * FROM ArivuEduLoan SE INNER JOIN
(SELECT min(Dis.DistrictCD) AS ID,Dis.DistrictName AS DName FROM MstDistrict Dis group by DIS.DistrictName) AS TabDiS ON 
	TabDiS.DName=SE.ParDistrict AND ParDistrict='Bengaluru (U)' AND DMApprove='APPROVED'AND DMCEOApprove='WAITING'
	 INNER JOIN MstConstituencies AS Con ON	Con.AssemblyName=SE.ParConstituency AND	Con.DistrictCD=@DistCode 
ORDER BY ApplicationNumber ";
                using (kvdConn)
                {

                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(SQL, kvdConn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DistCode", DistCode);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    kvdConn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ArivugvDMCEOWaiting.DataSource = ds;
                        ArivugvDMCEOWaiting.DataBind();

                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        ArivugvDMCEOWaiting.DataSource = ds;
                        ArivugvDMCEOWaiting.DataBind();
                        int columncount = ArivugvDMCEOWaiting.Rows[0].Cells.Count;
                        ArivugvDMCEOWaiting.Rows[0].Cells.Clear();
                        ArivugvDMCEOWaiting.Rows[0].Cells.Add(new TableCell());
                        ArivugvDMCEOWaiting.Rows[0].Cells[0].ColumnSpan = columncount;
                        ArivugvDMCEOWaiting.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
            else
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                using (kvdConn)
                {

                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("spDMApprove", kvdConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@status", "ARSELECTCEOWAITING");
                    cmd.Parameters.AddWithValue("@District", getDistrict);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    kvdConn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ArivugvDMCEOWaiting.DataSource = ds;
                        ArivugvDMCEOWaiting.DataBind();

                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        ArivugvDMCEOWaiting.DataSource = ds;
                        ArivugvDMCEOWaiting.DataBind();
                        int columncount = ArivugvDMCEOWaiting.Rows[0].Cells.Count;
                        ArivugvDMCEOWaiting.Rows[0].Cells.Clear();
                        ArivugvDMCEOWaiting.Rows[0].Cells.Add(new TableCell());
                        ArivugvDMCEOWaiting.Rows[0].Cells[0].ColumnSpan = columncount;
                        ArivugvDMCEOWaiting.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
        }
        private void SECEOApproveBindGrid()
        {

            //RefreshAllData();
            divCEOSE.Visible = true;
            DataSet ds = new DataSet();
            string DistCode = "";
            if (UserName == "DMBLRS")
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                DistCode = "1";
                string SQL = @"SELECT DISTINCT * FROM SelfEmpLoan SE INNER JOIN
(SELECT min(Dis.DistrictCD) AS ID,Dis.DistrictName AS DName FROM MstDistrict Dis group by DIS.DistrictName) AS TabDiS ON 
	TabDiS.DName=SE.ParDistrict AND ParDistrict='Bengaluru (U)' AND DMApprove='APPROVED'AND DMCEOApprove='PENDING'
	 INNER JOIN MstConstituencies AS Con ON	Con.AssemblyName=SE.ParConstituency AND	Con.DistrictCD=@DistCode 
ORDER BY ApplicationNumber ";
                using (kvdConn)
                {

                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(SQL, kvdConn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DistCode", DistCode);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    kvdConn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        SEgvDMCEO.DataSource = ds;
                        SEgvDMCEO.DataBind();

                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        SEgvDMCEO.DataSource = ds;
                        SEgvDMCEO.DataBind();
                        int columncount = SEgvDMCEO.Rows[0].Cells.Count;
                        SEgvDMCEO.Rows[0].Cells.Clear();
                        SEgvDMCEO.Rows[0].Cells.Add(new TableCell());
                        SEgvDMCEO.Rows[0].Cells[0].ColumnSpan = columncount;
                        SEgvDMCEO.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
            else if (UserName == "DMBLRN")
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                DistCode = "31";
                string SQL = @"SELECT DISTINCT * FROM SelfEmpLoan SE INNER JOIN
(SELECT min(Dis.DistrictCD) AS ID,Dis.DistrictName AS DName FROM MstDistrict Dis group by DIS.DistrictName) AS TabDiS ON 
	TabDiS.DName=SE.ParDistrict AND ParDistrict='Bengaluru (U)' AND DMApprove='APPROVED'AND DMCEOApprove='PENDING'
	 INNER JOIN MstConstituencies AS Con ON	Con.AssemblyName=SE.ParConstituency AND	Con.DistrictCD=@DistCode 
ORDER BY ApplicationNumber ";
                using (kvdConn)
                {

                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(SQL, kvdConn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DistCode", DistCode);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    kvdConn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        SEgvDMCEO.DataSource = ds;
                        SEgvDMCEO.DataBind();

                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        SEgvDMCEO.DataSource = ds;
                        SEgvDMCEO.DataBind();
                        int columncount = SEgvDMCEO.Rows[0].Cells.Count;
                        SEgvDMCEO.Rows[0].Cells.Clear();
                        SEgvDMCEO.Rows[0].Cells.Add(new TableCell());
                        SEgvDMCEO.Rows[0].Cells[0].ColumnSpan = columncount;
                        SEgvDMCEO.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
            else
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                using (kvdConn)
                {

                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("spSEApprove", kvdConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@status", "SESELECTCEO");
                    cmd.Parameters.AddWithValue("@District", getDistrict);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    kvdConn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        SEgvDMCEO.DataSource = ds;
                        SEgvDMCEO.DataBind();

                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        SEgvDMCEO.DataSource = ds;
                        SEgvDMCEO.DataBind();
                        int columncount = SEgvDMCEO.Rows[0].Cells.Count;
                        SEgvDMCEO.Rows[0].Cells.Clear();
                        SEgvDMCEO.Rows[0].Cells.Add(new TableCell());
                        SEgvDMCEO.Rows[0].Cells[0].ColumnSpan = columncount;
                        SEgvDMCEO.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
            
        }
        private void SECEOWaitingBindGrid()
        {

            divCEOSE.Visible = true;
            DataSet ds = new DataSet();
            string DistCode = "";
            if (UserName == "DMBLRS")
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                DistCode = "1";
                string SQL = @"SELECT DISTINCT * FROM SelfEmpLoan SE INNER JOIN
(SELECT min(Dis.DistrictCD) AS ID,Dis.DistrictName AS DName FROM MstDistrict Dis group by DIS.DistrictName) AS TabDiS ON 
	TabDiS.DName=SE.ParDistrict AND ParDistrict='Bengaluru (U)' AND DMApprove='APPROVED'AND DMCEOApprove='WAITING'
	 INNER JOIN MstConstituencies AS Con ON	Con.AssemblyName=SE.ParConstituency AND	Con.DistrictCD=@DistCode 
ORDER BY ApplicationNumber ";
                using (kvdConn)
                {

                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(SQL, kvdConn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DistCode", DistCode);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    kvdConn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        SEgvDMCEOWaiting.DataSource = ds;
                        SEgvDMCEOWaiting.DataBind();

                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        SEgvDMCEOWaiting.DataSource = ds;
                        SEgvDMCEOWaiting.DataBind();
                        int columncount = SEgvDMCEOWaiting.Rows[0].Cells.Count;
                        SEgvDMCEOWaiting.Rows[0].Cells.Clear();
                        SEgvDMCEOWaiting.Rows[0].Cells.Add(new TableCell());
                        SEgvDMCEOWaiting.Rows[0].Cells[0].ColumnSpan = columncount;
                        SEgvDMCEOWaiting.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
            else if (UserName == "DMBLRN")
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                DistCode = "31";
                string SQL = @"SELECT DISTINCT * FROM SelfEmpLoan SE INNER JOIN
(SELECT min(Dis.DistrictCD) AS ID,Dis.DistrictName AS DName FROM MstDistrict Dis group by DIS.DistrictName) AS TabDiS ON 
	TabDiS.DName=SE.ParDistrict AND ParDistrict='Bengaluru (U)' AND DMApprove='APPROVED'AND DMCEOApprove='WAITING'
	 INNER JOIN MstConstituencies AS Con ON	Con.AssemblyName=SE.ParConstituency AND	Con.DistrictCD=@DistCode 
ORDER BY ApplicationNumber ";
                using (kvdConn)
                {

                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(SQL, kvdConn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DistCode", DistCode);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    kvdConn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        SEgvDMCEOWaiting.DataSource = ds;
                        SEgvDMCEOWaiting.DataBind();

                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        SEgvDMCEOWaiting.DataSource = ds;
                        SEgvDMCEOWaiting.DataBind();
                        int columncount = SEgvDMCEOWaiting.Rows[0].Cells.Count;
                        SEgvDMCEOWaiting.Rows[0].Cells.Clear();
                        SEgvDMCEOWaiting.Rows[0].Cells.Add(new TableCell());
                        SEgvDMCEOWaiting.Rows[0].Cells[0].ColumnSpan = columncount;
                        SEgvDMCEOWaiting.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
            else
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                using (kvdConn)
                {

                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("spSEApprove", kvdConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@status", "SESELECTCEOWAITING");
                    cmd.Parameters.AddWithValue("@District", getDistrict);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    kvdConn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        SEgvDMCEOWaiting.DataSource = ds;
                        SEgvDMCEOWaiting.DataBind();

                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        SEgvDMCEOWaiting.DataSource = ds;
                        SEgvDMCEOWaiting.DataBind();
                        int columncount = SEgvDMCEOWaiting.Rows[0].Cells.Count;
                        SEgvDMCEOWaiting.Rows[0].Cells.Clear();
                        SEgvDMCEOWaiting.Rows[0].Cells.Add(new TableCell());
                        SEgvDMCEOWaiting.Rows[0].Cells[0].ColumnSpan = columncount;
                        SEgvDMCEOWaiting.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
            
        }
        protected void ClickTest(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

            if (FileCeoArivu.HasFile)
            {
                string dateTime = DateTime.Now.ToString();
                string name = FileCeoArivu.FileName + Path.GetExtension(FileCeoArivu.FileName);
                string fileExtension = Path.GetExtension(FileCeoArivu.FileName);

                if (name.Contains(".exe") && name.Contains(".msi") && name.Contains(".etc") && name.Contains(".dll") && name.Contains(".dat") && fileExtension.ToLower() != ".pdf")
                {
                    DisplayAlert("Only PDF file allowed", this);
                }
                else
                {
                    int fileSize = FileCeoArivu.PostedFile.ContentLength;
                    if (fileSize < 53600)
                    {
                        DisplayAlert("Minimun size 50KB ", this);
                    }
                    else if (fileSize > 5536000)
                    {
                        DisplayAlert("File size Exceeded.. Maximum size 500KB", this);
                    }

                    else
                    {
                        FileCeoArivu.SaveAs(Server.MapPath("~/ImageUpload/" + FileCeoArivu.FileName));
                        //DisplayAlert("File Uploaded successfully", this);
                        fs = FileCeoArivu.PostedFile.InputStream;
                        br = new BinaryReader(fs);

                        byCEODocArivu = br.ReadBytes((Int32)fs.Length);
                        using (kvdConn)
                        {
                            using (SqlCommand cmd = new SqlCommand("spArivuCEOScanDoc"))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@CEOVerifiedDoc", byCEODocArivu);
                                cmd.Parameters.AddWithValue("@District", District);
                                cmd.Parameters.AddWithValue("@DateTime", (DateTime.Now).ToString());
                                cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                                //cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                                cmd.Connection = kvdConn;
                                kvdConn.Open();
                                ArivuFile = cmd.ExecuteNonQuery();
                                ARFileNum = cmd.Parameters["@id"].Value.ToString();
                                //cmd.CommandType = CommandType.Text;

                                kvdConn.Close();
                                if (Int32.Parse(ARFileNum) > 0)
                                {
                                    divCEOgv.Visible = true;
                                    //lblID.Visible = true;
                                    lblFileID.Text = ARFileNum;
                                    this.ArivuCEOApproveBindGrid();
                                }
                                else
                                {
                                    divCEOgv.Visible = false;
                                    lblFileID.Text = "Upload File";
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                DisplayAlert("File Not Selected", this);
            }
        }
        protected void btnArivuUploadCeoDoc_Click(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            if (FileCeoArivu.HasFile)
            {
                string dateTime = DateTime.Now.ToString();
                string name = FileCeoArivu.FileName + Path.GetExtension(FileCeoArivu.FileName);
                string fileExtension = Path.GetExtension(FileCeoArivu.FileName);

                if (name.Contains(".exe") && name.Contains(".msi") && name.Contains(".etc") && name.Contains(".dll") && name.Contains(".dat") && fileExtension.ToLower() == ".pdf")
                {
                    DisplayAlert("Only PDF file allowed", this);
                }
                else
                {
                    if (fileExtension.ToLower() == ".pdf")
                    {


                        int fileSize = FileCeoArivu.PostedFile.ContentLength;
                        if (fileSize < 53600)
                        {
                            DisplayAlert("Minimun size 50KB ", this);
                        }
                        
                        else
                        {
                            FileCeoArivu.SaveAs(Server.MapPath("~/ImageUpload/" + FileCeoArivu.FileName));
                            //DisplayAlert("File Uploaded successfully", this);
                            fs = FileCeoArivu.PostedFile.InputStream;
                            br = new BinaryReader(fs);

                            byCEODocArivu = br.ReadBytes((Int32)fs.Length);
                            using (kvdConn)
                            {
                                using (SqlCommand cmd = new SqlCommand("spArivuCEOScanDoc"))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@CEOVerifiedDoc", byCEODocArivu);
                                    cmd.Parameters.AddWithValue("@District", getDistrict);
                                    cmd.Parameters.AddWithValue("@DateTime", (DateTime.Now).ToString());
                                    cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                                    //cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                                    cmd.Connection = kvdConn;
                                    kvdConn.Open();
                                    ArivuFile = cmd.ExecuteNonQuery();
                                    ARFileNum = cmd.Parameters["@id"].Value.ToString();
                                    //cmd.CommandType = CommandType.Text;

                                    kvdConn.Close();
                                    if (Int32.Parse(ARFileNum) > 0)
                                    {
                                        divCEOgv.Visible = true;
                                        //lblID.Visible = true;
                                        lblFileID.Text = ARFileNum;
                                        this.ArivuCEOApproveBindGrid();
                                    }
                                    else
                                    {
                                        divCEOgv.Visible = false;
                                        lblFileID.Text = "Upload File";
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        lblFileID.Text = "Only PDF File Allowed";
                    }
                }
            }
            else
            {
                DisplayAlert("File not Selected", this);
            }
        }
        protected void btnArivuDMCEOApprove_Click(object sender, GridViewUpdateEventArgs e)
        {
            //Button btn = (Button)sender;
            //GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            //int rowindex = gvr.RowIndex;
            //string ApplicationNumber = ArivugvDMCEO.DataKeys[rowindex].Values["ApplicationNumber"].ToString();            
            string ApplicationNumber = Convert.ToString(ArivugvDMCEO.DataKeys[e.RowIndex].Values["ApplicationNumber"].ToString());
            TextBox txt1Year = (TextBox)ArivugvDMCEO.Rows[e.RowIndex].FindControl("txt1Year");
            TextBox txt2Year = (TextBox)ArivugvDMCEO.Rows[e.RowIndex].FindControl("txt2Year");
            TextBox txt3Year = (TextBox)ArivugvDMCEO.Rows[e.RowIndex].FindControl("txt3Year");
            TextBox txt4Year = (TextBox)ArivugvDMCEO.Rows[e.RowIndex].FindControl("txt4Year");
            TextBox txt5Year = (TextBox)ArivugvDMCEO.Rows[e.RowIndex].FindControl("txt5Year");
            DropDownList drpQuota = (DropDownList)ArivugvDMCEO.Rows[e.RowIndex].FindControl("drpQuota");
            GridViewRow row = ArivugvDMCEO.Rows[e.RowIndex];
            string y1, y2, y3, y4, y5, qta;
            y1 = txt1Year.Text;
            y2 = txt2Year.Text;
            y3 = txt3Year.Text;
            y4 = txt4Year.Text;
            y5 = txt5Year.Text;
            qta = drpQuota.SelectedItem.Text;
            if (y1 == null) { y1 = "0"; }
            if (y2 == null) { y2 = "0"; }
            if (y3 == null) { y3 = "0"; }
            if (y4 == null) { y4 = "0"; }
            if (y5 == null) { y5 = "0"; }
            if (qta != "--SELECT--")
            {
                spDMArCEO("ARAPPROVECEO", y1, y2, y3, y4, y5, qta, "", "", "", ApplicationNumber); ;
            }

            
            RefreshAllData();
        }
        protected void spDMArCEO(string status, string YearLoan1, string YearLoan2, string YearLoan3, string YearLoan4, string YearLoan5, string Quota, string RejectReason, string DMDocVerified, string DMRejectReason, string ApplicationNumber)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

            using (kvdConn)
            {
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spDMApprove", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (status == "ARAPPROVECEO")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@1YearLoan", YearLoan1);
                    cmd.Parameters.AddWithValue("@2YearLoan", YearLoan2);
                    cmd.Parameters.AddWithValue("@3YearLoan", YearLoan3);
                    cmd.Parameters.AddWithValue("@4YearLoan", YearLoan4);
                    cmd.Parameters.AddWithValue("@5YearLoan", YearLoan5);
                    cmd.Parameters.AddWithValue("@CEOFileNum", ARFileNum);
                    cmd.Parameters.AddWithValue("@Quota", Quota);
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                }
                else if (status == "ARREJECTCEO")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@CEORejectReason", DMRejectReason);
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                }
                
                else if (status == "ARWAITINGCEO")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                }
                

                int abc = cmd.ExecuteNonQuery();
                //lblresult.ForeColor = Color.Green;
                //lblresult.Text = YearLoan1 + " details " + status.ToLower() + "d successfully";
                ArivugvDMCEO.EditIndex = -1;
                //ArivuDMApproveBindGrid();
                this.ArivuCEOApproveBindGrid();
                RefreshAllData();
            }
        }
        
        protected void btnArivuDMCEOWaiting_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            ArApplicationNumber = ArivugvDMCEO.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            spDMArCEO("ARWAITINGCEO", "", "", "", "", "", "", "", "", "", ArApplicationNumber);
            //this.ArivuCEOApproveBindGrid();
            RefreshAllData();
        }
        protected void ArivugvDMCEO_RowEditing(object sender, GridViewEditEventArgs e)
        {
            divCEOgv.Visible = true;
            ArivugvDMCEO.EditIndex = e.NewEditIndex;
            ArivuCEOApproveBindGrid();
        }

        protected void btnSEUploadCeoDoc_Click(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

            if (FileCeoSE.HasFile)
            {
                string dateTime = DateTime.Now.ToString();
                string name = FileCeoSE.FileName + Path.GetExtension(FileCeoSE.FileName);
                string fileExtension = Path.GetExtension(FileCeoSE.FileName);

                if (name.Contains(".exe") && name.Contains(".msi") && name.Contains(".etc") && name.Contains(".dll") && name.Contains(".dat") && fileExtension.ToLower() != ".pdf")
                {
                    DisplayAlert("Only PDF file allowed", this);
                }
                else
                {
                    if (fileExtension.ToLower() == ".pdf")
                    {


                        int fileSize = FileCeoSE.PostedFile.ContentLength;
                        if (fileSize < 53600)
                        {
                            DisplayAlert("Minimun size 50KB ", this);
                        }
                       
                        else
                        {
                            FileCeoSE.SaveAs(Server.MapPath("~/ImageUpload/" + FileCeoSE.FileName));
                            //DisplayAlert("File Uploaded successfully", this);
                            fs = FileCeoSE.PostedFile.InputStream;
                            br = new BinaryReader(fs);

                            byCEODocArivu = br.ReadBytes((Int32)fs.Length);
                            using (kvdConn)
                            {
                                using (SqlCommand cmd = new SqlCommand("spSECEOScanDoc"))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@CEOVerifiedDoc", byCEODocArivu);
                                    cmd.Parameters.AddWithValue("@District", getDistrict);
                                    //cmd.Parameters.AddWithValue("@CEOFileNum", SEFileNum);
                                    cmd.Parameters.AddWithValue("@DateTime", (DateTime.Now).ToString());
                                    cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                                    //cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                                    cmd.Connection = kvdConn;
                                    kvdConn.Open();
                                    SEFile = cmd.ExecuteNonQuery();
                                    SEFileNum = cmd.Parameters["@id"].Value.ToString();
                                    //cmd.CommandType = CommandType.Text;

                                    kvdConn.Close();
                                    if (Int32.Parse(SEFileNum) > 0)
                                    {
                                        divCEOSE.Visible = true;
                                        //lblID.Visible = true;
                                        lblSEFileID.Text = SEFileNum;
                                        this.SECEOApproveBindGrid();
                                    }
                                    else
                                    {
                                        divCEOSE.Visible = false;
                                        lblSEFileID.Text = "Upload File";
                                    }
                                }
                            }
                        }
                    }
                    else {
                        lblSEFileID.Text = "Upload File";
                    }
                }
            }
            else
            {
                DisplayAlert("Only PDF file allowed", this);
            }
        }

        protected void SEgvDMCEO_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            SEgvDMCEO.EditIndex = -1;
            this.SECEOApproveBindGrid();
        }

        protected void SEgvDMCEO_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Button btn = (Button)sender;
            //GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            //int rowindex = gvr.RowIndex;
            //string ApplicationNumber = SEgvDMCEO.DataKeys[rowindex].Values["ApplicationNumber"].ToString();            
            string ApplicationNumber = Convert.ToString(SEgvDMCEO.DataKeys[e.RowIndex].Values["ApplicationNumber"].ToString());
            TextBox txtLA = (TextBox)SEgvDMCEO.Rows[e.RowIndex].FindControl("txtLoanAmt");
            DropDownList drpQuota = (DropDownList)SEgvDMCEO.Rows[e.RowIndex].FindControl("drpQuota");
            GridViewRow row = SEgvDMCEO.Rows[e.RowIndex];
            string LoanAmt, qta;
            LoanAmt = txtLA.Text;

            qta = drpQuota.SelectedItem.Text;
            if (LoanAmt == null) { LoanAmt = "0"; }
            if (qta != "--SELECT--")
            {
                spCEOStatus("SEAPPROVECEO", LoanAmt, qta, "", "", "", ApplicationNumber);
            }

            
            RefreshAllData();
        }

        protected void BindGridview()
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

            DataSet ds = new DataSet();
            using (kvdConn)
            {
                kvdConn.Open();
                SqlCommand cmd = new SqlCommand("spSEApprove", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SlNo", "");
                cmd.Parameters.AddWithValue("@status", "SELECT");
                cmd.Parameters.AddWithValue("@District", "");
                cmd.Parameters.AddWithValue("@UserName", "");
                cmd.Parameters.AddWithValue("@Password", "");
                cmd.Parameters.AddWithValue("@UserType", "");
                cmd.Parameters.AddWithValue("@Active", "");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ArivugvDMCEO.DataSource = ds;
                    ArivugvDMCEO.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    ArivugvDMCEO.DataSource = ds;
                    ArivugvDMCEO.DataBind();
                    int columncount = ArivugvDMCEO.Rows[0].Cells.Count;
                    ArivugvDMCEO.Rows[0].Cells.Clear();
                    ArivugvDMCEO.Rows[0].Cells.Add(new TableCell());
                    ArivugvDMCEO.Rows[0].Cells[0].ColumnSpan = columncount;
                    ArivugvDMCEO.Rows[0].Cells[0].Text = "No Records Found";
                }

                //kvdConn.Open();
                //SqlCommand cmd = new SqlCommand("spDMKannada", kvdConn);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@status", "SELECT");
                //cmd.Parameters.AddWithValue("@SlNo", "");
                //using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                //{
                //    using (DataTable dt = new DataTable())
                //    {
                //        da.Fill(dt);
                //        kvdConn.Close();
                //        if (ds.Tables[0].Rows.Count > 0)
                //        {
                //            gvDMKan.DataSource = dt;
                //            gvDMKan.DataBind();
                //        }
                //        else
                //{
                //            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                //            gvDMKan.DataSource = ds;
                //            gvDMKan.DataBind();
                //            int columncount = gvDMKan.Rows[0].Cells.Count;
                //            gvDMKan.Rows[0].Cells.Clear();
                //            gvDMKan.Rows[0].Cells.Add(new TableCell());
                //            gvDMKan.Rows[0].Cells[0].ColumnSpan = columncount;
                //            gvDMKan.Rows[0].Cells[0].Text = "No Records Found";
                //        }
                //    }
                //}
            }
        }
        
        protected void btnSECEOWaiting_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            SeApplicationNumber = SEgvDMCEO.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            spCEOStatus("SEWAITINGCEO", "", "", "", "", "", SeApplicationNumber);
            //DivSERr.Visible = true;
            //this.SECEOApproveBindGrid();
            RefreshAllData();
        }
        protected void btnSERejectAppn_Click(object sender, EventArgs e)
        {
            string message = "";
            foreach (System.Web.UI.WebControls.ListItem item in drpSERejectReason.Items)
            {
                if (item.Selected)
                {
                    message += item.Text + " , ";
                }
            }

            spCEOStatus("SEREJECTCEO", "", "", "", "", message, SeApplicationNumber);
            DivSERr.Visible = false;
            //this.SECEOApproveBindGrid();
            RefreshAllData();
        }

        protected void SEgvDMCEO_RowEditing(object sender, GridViewEditEventArgs e)
        {
            divCEOSE.Visible = true;
            SEgvDMCEO.EditIndex = e.NewEditIndex;
            RefreshAllData();
            //this.SECEOApproveBindGrid();
        }

        protected void ArivugvDMCEO_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ArivugvDMCEO.EditIndex = -1;
            RefreshAllData(); 
            //this.ArivuCEOApproveBindGrid();
        }
        protected void spCEOStatus(string status, string LoanAmt, string Quota, string RejectReason, string DMDocVerified, string DMRejectReason, string ApplicationNumber)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

            using (kvdConn)
            {
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spSEApprove", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (status == "SEAPPROVECEO")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@LoanAmount", LoanAmt);
                    cmd.Parameters.AddWithValue("@CEOFileNum", SEFileNum);

                    cmd.Parameters.AddWithValue("@Quota", Quota);
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                }
                else if (status == "SEREJECTCEO")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    //cmd.Parameters.AddWithValue("@DMRejectReason", DMRejectReason);
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                    cmd.Parameters.AddWithValue("@CEORejectReason", RejectReason);
                }
                else if (status == "SEWAITINGCEO")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    //cmd.Parameters.AddWithValue("@DMRejectReason", DMRejectReason);
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                }
                

                int abc = cmd.ExecuteNonQuery();
                //lblresult.ForeColor = Color.Green;
                //lblresult.Text = YearLoan1 + " details " + status.ToLower() + "d successfully";
                SEgvDMCEO.EditIndex = -1;
                //ArivuDMApproveBindGrid();
                RefreshAllData();
                //this.SECEOApproveBindGrid();
            }
        }
        private void ArivuDocApproveBindGrid()
        {
            divDocArivu.Visible = true;
            DataSet ds = new DataSet();
            string DistCode = "";
            if (UserName == "DMBLRS")
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                DistCode = "1";
                string SQL = @"SELECT DISTINCT *,CASE WHEN BankUpdateReason IS NULL THEN 'UPDATE BANK DETAILS' ELSE 'UPDATED' END AS REASON FROM ArivuEduLoan SE INNER JOIN
(SELECT min(Dis.DistrictCD) AS ID,Dis.DistrictName AS DName FROM MstDistrict Dis group by DIS.DistrictName) AS TabDiS ON 
	TabDiS.DName=SE.ParDistrict AND ParDistrict='Bengaluru (U)' AND DMCEOApprove='APPROVED' AND DMDocApprove='PENDING'
	 INNER JOIN MstConstituencies AS Con ON	Con.AssemblyName=SE.ParConstituency AND	Con.DistrictCD=@DistCode 
ORDER BY ApplicationNumber ";
                using (kvdConn)
                {
                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(SQL, kvdConn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DistCode", DistCode);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    kvdConn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ArivugvDMDoc.DataSource = ds;
                        ArivugvDMDoc.DataBind();

                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        ArivugvDMDoc.DataSource = ds;
                        ArivugvDMDoc.DataBind();
                        int columncount = ArivugvDMDoc.Rows[0].Cells.Count;
                        ArivugvDMDoc.Rows[0].Cells.Clear();
                        ArivugvDMDoc.Rows[0].Cells.Add(new TableCell());
                        ArivugvDMDoc.Rows[0].Cells[0].ColumnSpan = columncount;
                        ArivugvDMDoc.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
            else if (UserName == "DMBLRN")
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                DistCode = "31";
                string SQL = @"SELECT DISTINCT *,CASE WHEN BankUpdateReason IS NULL THEN 'UPDATE BANK DETAILS' ELSE 'UPDATED' END AS REASON FROM ArivuEduLoan SE INNER JOIN
(SELECT min(Dis.DistrictCD) AS ID,Dis.DistrictName AS DName FROM MstDistrict Dis group by DIS.DistrictName) AS TabDiS ON 
	TabDiS.DName=SE.ParDistrict AND ParDistrict='Bengaluru (U)' AND DMCEOApprove='APPROVED' AND DMDocApprove='PENDING'
	 INNER JOIN MstConstituencies AS Con ON	Con.AssemblyName=SE.ParConstituency AND	Con.DistrictCD=@DistCode 
ORDER BY ApplicationNumber ";
                using (kvdConn)
                {
                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(SQL, kvdConn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DistCode", DistCode);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    kvdConn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ArivugvDMDoc.DataSource = ds;
                        ArivugvDMDoc.DataBind();

                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        ArivugvDMDoc.DataSource = ds;
                        ArivugvDMDoc.DataBind();
                        int columncount = ArivugvDMDoc.Rows[0].Cells.Count;
                        ArivugvDMDoc.Rows[0].Cells.Clear();
                        ArivugvDMDoc.Rows[0].Cells.Add(new TableCell());
                        ArivugvDMDoc.Rows[0].Cells[0].ColumnSpan = columncount;
                        ArivugvDMDoc.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
            else
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                using (kvdConn)
                {
                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("spDMApprove", kvdConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@status", "ARSELECTDOC");
                    cmd.Parameters.AddWithValue("@District", getDistrict);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    kvdConn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ArivugvDMDoc.DataSource = ds;
                        ArivugvDMDoc.DataBind();

                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        ArivugvDMDoc.DataSource = ds;
                        ArivugvDMDoc.DataBind();
                        int columncount = ArivugvDMDoc.Rows[0].Cells.Count;
                        ArivugvDMDoc.Rows[0].Cells.Clear();
                        ArivugvDMDoc.Rows[0].Cells.Add(new TableCell());
                        ArivugvDMDoc.Rows[0].Cells[0].ColumnSpan = columncount;
                        ArivugvDMDoc.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
        }
        private void SEDocApproveBindGrid()
        {
            divDocSE.Visible = true;
            DataSet ds = new DataSet();
            string DistCode = "";
            if (UserName == "DMBLRS")
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                DistCode = "1";
                string SQL = @"SELECT DISTINCT *,CASE WHEN BankUpdateReason IS NULL THEN 'UPDATE BANK DETAILS' ELSE 'UPDATED' END AS REASON FROM SelfEmpLoan SE INNER JOIN
(SELECT min(Dis.DistrictCD) AS ID,Dis.DistrictName AS DName FROM MstDistrict Dis group by DIS.DistrictName) AS TabDiS ON 
	TabDiS.DName=SE.ParDistrict AND ParDistrict='Bengaluru (U)' AND DMCEOApprove='APPROVED' AND DMDocApprove='PENDING'
	 INNER JOIN MstConstituencies AS Con ON	Con.AssemblyName=SE.ParConstituency AND	Con.DistrictCD=@DistCode 
ORDER BY ApplicationNumber ";
                using (kvdConn)
                {
                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(SQL, kvdConn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DistCode", DistCode);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    kvdConn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        SEgvDMDoc.DataSource = ds;
                        SEgvDMDoc.DataBind();

                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        SEgvDMDoc.DataSource = ds;
                        SEgvDMDoc.DataBind();
                        int columncount = SEgvDMDoc.Rows[0].Cells.Count;
                        SEgvDMDoc.Rows[0].Cells.Clear();
                        SEgvDMDoc.Rows[0].Cells.Add(new TableCell());
                        SEgvDMDoc.Rows[0].Cells[0].ColumnSpan = columncount;
                        SEgvDMDoc.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
            else if (UserName == "DMBLRN")
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                DistCode = "31";
                string SQL = @"SELECT DISTINCT *,CASE WHEN BankUpdateReason IS NULL THEN 'UPDATE BANK DETAILS' ELSE 'UPDATED' END AS REASON FROM SelfEmpLoan SE INNER JOIN
(SELECT min(Dis.DistrictCD) AS ID,Dis.DistrictName AS DName FROM MstDistrict Dis group by DIS.DistrictName) AS TabDiS ON 
	TabDiS.DName=SE.ParDistrict AND ParDistrict='Bengaluru (U)' AND DMCEOApprove='APPROVED' AND DMDocApprove='PENDING'
	 INNER JOIN MstConstituencies AS Con ON	Con.AssemblyName=SE.ParConstituency AND	Con.DistrictCD=@DistCode 
ORDER BY ApplicationNumber ";
                using (kvdConn)
                {
                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(SQL, kvdConn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@DistCode", DistCode);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    kvdConn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        SEgvDMDoc.DataSource = ds;
                        SEgvDMDoc.DataBind();

                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        SEgvDMDoc.DataSource = ds;
                        SEgvDMDoc.DataBind();
                        int columncount = SEgvDMDoc.Rows[0].Cells.Count;
                        SEgvDMDoc.Rows[0].Cells.Clear();
                        SEgvDMDoc.Rows[0].Cells.Add(new TableCell());
                        SEgvDMDoc.Rows[0].Cells[0].ColumnSpan = columncount;
                        SEgvDMDoc.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
            else
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                using (kvdConn)
                {
                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("spSEApprove", kvdConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@status", "SESELECTDOC");
                    cmd.Parameters.AddWithValue("@District", getDistrict);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    kvdConn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        SEgvDMDoc.DataSource = ds;
                        SEgvDMDoc.DataBind();

                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        SEgvDMDoc.DataSource = ds;
                        SEgvDMDoc.DataBind();
                        int columncount = SEgvDMDoc.Rows[0].Cells.Count;
                        SEgvDMDoc.Rows[0].Cells.Clear();
                        SEgvDMDoc.Rows[0].Cells.Add(new TableCell());
                        SEgvDMDoc.Rows[0].Cells[0].ColumnSpan = columncount;
                        SEgvDMDoc.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
           
        }

        protected void btnRejectDOCArivu_Click(object sender, EventArgs e)
        {
        }

        protected void btnArivuDocDownload_Click(object sender, EventArgs e)
        {
            string DocCasteIncome, DocPhyCha, DocBankPassbook;
            string DBFile;
            string filename;
            string filepath, aadfilename, DocStudyCertificate, DocCETAdmissionTicate, DocFeesStructure, DocPrevMarksCard, DocCollegeHostel;
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = ArivugvDMDoc.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            filename = ApplicationNumber + "DocCasteIncome.pdf";
            DocCasteIncome = filepath + filename;
            DBFile = "DocCasteIncome";
            DownloadFile(DBFile, ApplicationNumber, filename, DocCasteIncome, "[KACDC].[dbo].[ArivuEduLoan]");

            //filename = ApplicationNumber + "DocPhyCha.pdf";
            //DocPhyCha = filepath + filename;
            //DBFile = "DocPhyCha";
            //DownloadFile(DBFile, ApplicationNumber, filename, DocPhyCha, "[KACDC].[dbo].[ArivuEduLoan]");

            filename = ApplicationNumber + "DocBankPassbook.pdf";
            DocBankPassbook = filepath + filename;
            DBFile = "DocPhyCha";
            DownloadFile(DBFile, ApplicationNumber, filename, DocBankPassbook, "[KACDC].[dbo].[ArivuEduLoan]");

            filename = ApplicationNumber + "DocCETAdmissionTicate.pdf";
            DocCETAdmissionTicate = filepath + filename;
            DBFile = "DocPhyCha";
            DownloadFile(DBFile, ApplicationNumber, filename, DocCETAdmissionTicate, "[KACDC].[dbo].[ArivuEduLoan]");

            filename = ApplicationNumber + "DocFeesStructure.pdf";
            DocFeesStructure = filepath + filename;
            DBFile = "DocPhyCha";
            DownloadFile(DBFile, ApplicationNumber, filename, DocFeesStructure, "[KACDC].[dbo].[ArivuEduLoan]");

            filename = ApplicationNumber + "DocPrevMarksCard.pdf";
            DocPrevMarksCard = filepath + filename;
            DBFile = "DocPhyCha";
            DownloadFile(DBFile, ApplicationNumber, filename, DocPrevMarksCard, "[KACDC].[dbo].[ArivuEduLoan]");

            filename = ApplicationNumber + "DocCollegeHostel.pdf";
            DocCollegeHostel = filepath + filename;
            DBFile = "DocPhyCha";
            DownloadFile(DBFile, ApplicationNumber, filename, DocCollegeHostel, "[KACDC].[dbo].[ArivuEduLoan]");

            //aadfilename = ApplicationNumber + "Aadhar.pdf";
            //DownloadAadhar(ApplicationNumber, filename, "[KACDC].[dbo].[SelfEmpLoan]");

            using (ZipFile zip = new ZipFile())
            {
                zip.AddFile(DocCasteIncome, "files");
                zip.AddFile(DocBankPassbook, "files");
                //zip.AddFile(filepath + aadfilename, "files");
                //zip.AddFile(DocPhyCha, "files");
                zip.AddFile(DocCETAdmissionTicate, "files");
                zip.AddFile(DocFeesStructure, "files");
                zip.AddFile(DocPrevMarksCard, "files");
                zip.AddFile(DocCollegeHostel, "files");

                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + ApplicationNumber + ".zip");
                Response.ContentType = "application/zip";
                zip.Save(Response.OutputStream);
                Response.End();
            }
        }

        protected void btnArivuDocAccept_Click(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = ArivugvDMDoc.DataKeys[rowindex].Values["ApplicationNumber"].ToString();

            ArDocStatus("ARAPPROVEDOC", "", ApplicationNumber);
            //this.ArivuDocApproveBindGrid();
            //this.SEDocApproveBindGrid();
            
            RefreshAllData();
        }
        protected void ArDocStatus(string status, string RejectReason, string ApplicationNumber)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            using (kvdConn)
            {
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spDMApprove", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (status == "ARAPPROVEDOC")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@District", getDistrict);
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                }
                else if (status == "ARREJECTDOC")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@DOCRejectReason", RejectReason);
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                }

                cmd.ExecuteNonQuery();
                //lblresult.ForeColor = Color.Green;
                //lblresult.Text = YearLoan1 + " details " + status.ToLower() + "d successfully";
                ArivugvDMDoc.EditIndex = -1;
                ArivuDocApproveBindGrid();
                //ArivuDMApproveBindGrid();
            }
        }
        protected void SEDocStatus(string status, string RejectReason, string ApplicationNumber)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            using (kvdConn)
            {
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spSEApprove", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (status == "SEAPPROVEDOC")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@District", getDistrict);
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                }
                else if (status == "SEREJECTDOC")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    //cmd.Parameters.AddWithValue("@RejectReason", RejectReason);
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                    cmd.Parameters.AddWithValue("@DOCRejectReason", RejectReason);
                }

                cmd.ExecuteNonQuery();
                //lblresult.ForeColor = Color.Green;
                //lblresult.Text = YearLoan1 + " details " + status.ToLower() + "d successfully";
                SEgvDMDoc.EditIndex = -1;
                this.SEDocApproveBindGrid();
                //ArivuDMApproveBindGrid();
            }
        }
        

        protected void btnRejectDOCSE_Click(object sender, EventArgs e)
        {
            string message = "";
            foreach (System.Web.UI.WebControls.ListItem item in drpRejectDOCSE.Items)
            {
                if (item.Selected)
                {
                    message += item.Text + " , ";
                }
            }

            SEDocStatus("SEREJECTDOC", message, SEDocApplicationNumber);
            divRejectDOCSE.Visible = false;
            //this.ArivuDocApproveBindGrid();
            //this.SEDocApproveBindGrid();
            RefreshAllData();
        }

        //protected void DMArivuRejectAppn_Click(object sender, EventArgs e)
        //{
        //    string message = "";
        //    foreach (System.Web.UI.WebControls.ListItem item in drpDMArivuRejectReason.Items)
        //    {
        //        if (item.Selected)
        //        {
        //            message += item.Text + " , ";
        //        }
        //    }
        //    spDMStatus("ARREJECTDM", message, ArApplicationNumber);
        //    //divDMArivuRejectReason.Visible = false;
        //    this.ArivuDMApproveBindGrid();            
        //}

        protected void btnCancelArivuDM_Click(object sender, EventArgs e)
        {
            ArivugvDMApprove.EditIndex = -1;
            RefreshAllData();
            //this.ArivuDMApproveBindGrid();
        }

        protected void OnUpdateArivuDM_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            string ArApplicationNumber = (row.FindControl("txtArivuDMAppNum") as TextBox).Text;
            string ab = ArivugvDMApprove.DataKeyNames.ToString();
            string SERR = string.Empty;
            ListBox cblProject = (ListBox)(row.FindControl("drpArivuRejectReasonDM"));
            foreach (System.Web.UI.WebControls.ListItem item in cblProject.Items)
            {
                if (item.Selected)
                {
                    SERR += item.Text + ",";

                }
            }
            //spSEDMStatus("SEREJECTDM", ApplicationNumber);
            spDMStatus("ARREJECTDM", SERR, ArApplicationNumber);
            ArivugvDMApprove.EditIndex = -1;
            RefreshAllData();
            //this.ArivuDMApproveBindGrid();
        }

        protected void SEDMApprove_RowEditing(object sender, GridViewEditEventArgs e)
        {
            SEDMApprove.EditIndex = e.NewEditIndex;
            this.SEDMApproveBindGrid();
            (SEDMApprove.Rows[e.NewEditIndex].FindControl("drpSEDMRejectReason") as ListBox).Items[e.NewEditIndex].Selected = true;
        }

        protected void ArivugvDMApprove_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ArivugvDMApprove.EditIndex = e.NewEditIndex;
            this.ArivuDMApproveBindGrid();
            (ArivugvDMApprove.Rows[e.NewEditIndex].FindControl("drpArivuRejectReasonDM") as ListBox).Items[e.NewEditIndex].Selected = true;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }

        protected void btnClearSE_Click(object sender, EventArgs e)
        {
            if (txtAccountNumberSE.Text != "" && txtBankNameSE.Text != "" && txtIFSCCodeSE.Text != "" &&
                   txtBankAddrSE.Text != "" && txtBranchSE.Text != "")
            {
                lblApplicationNumberSE.Text = "";
                txtBankAddrSE.Text = "";
                txtIFSCCodeSE.Text = "";
                txtBranchSE.Text = "";
                txtBankNameSE.Text = "";
                txtAccountNumberSE.Text = "";
                txtApplicantNameSE.Text = "";
                lblApplicationNumberSE.Text = "";
                btnUpdateBankSE.Enabled = false;
                btnUpdateBankSE.CssClass = "Button";
            }
        }

        protected void btnGVUpdateBankSE_Click(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            //lblApplicationNumberSE.CssClass.Replace( "text-primary","");
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            ApplicationNumber = SEgvDMDoc.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            if (ApplicationNumber != "")
            {
                using (kvdConn)
                {
                    if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                    SqlDataAdapter DAcmd = new SqlDataAdapter("SELECT ApplicantName,BankName,Branch,AccountNumber,IFSCCode,BankAddress FROM SelfEmpLoan WHERE ApplicationNumber= @AppnNumber", kvdConn);
                    DAcmd.SelectCommand.Parameters.AddWithValue("@AppnNumber", ApplicationNumber);
                    DataTable dt = new DataTable();
                    DAcmd.Fill(dt);

                    txtApplicantNameSE.Text = dt.Rows[0]["ApplicantName"].ToString();
                    txtAccountNumberSE.Text = dt.Rows[0]["AccountNumber"].ToString();
                    txtBankNameSE.Text = dt.Rows[0]["BankName"].ToString();
                    txtIFSCCodeSE.Text = dt.Rows[0]["IFSCCode"].ToString();
                    txtBankAddrSE.Text = dt.Rows[0]["BankAddress"].ToString();
                    txtBranchSE.Text = dt.Rows[0]["Branch"].ToString();
                    lblApplicationNumberSE.Text = ApplicationNumber;

                    btnUpdateBankSE.Enabled = true;
                    //txtApplicantNameSE.Enabled = false;
                    kvdConn.Close();
                    RefreshAllData();
                }

            }
        }
        protected void btnUpdateBankSE_Click(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            if (txtApplicantNameSE.Text.Trim() != "" && txtAccountNumberSE.Text.Trim() != "" && txtBankNameSE.Text.Trim() != "" && txtIFSCCodeSE.Text.Trim() != "" &&
                  txtBankAddrSE.Text.Trim() != "" && txtBranchSE.Text.Trim() != "")
            {
                if (ApplicationNumber != "")
                {
                    using (kvdConn)
                    {
                        if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                        SqlCommand cmd = new SqlCommand("UpdateBankDetails", kvdConn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (ApplicationNumber != "") //todo
                        {
                            if (drpSEReasonBankModify.SelectedValue != "")
                            {
                                cmd.Parameters.AddWithValue("@AccountNumber", txtAccountNumberSE.Text);
                                cmd.Parameters.AddWithValue("@BankName", txtBankNameSE.Text);
                                cmd.Parameters.AddWithValue("@IFSCCode", txtIFSCCodeSE.Text);
                                cmd.Parameters.AddWithValue("@BankAddress", txtBankAddrSE.Text);
                                cmd.Parameters.AddWithValue("@Branch", txtBranchSE.Text);
                                cmd.Parameters.AddWithValue("@Reason", drpSEReasonBankModify.SelectedValue);
                                cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                                cmd.Parameters.AddWithValue("@ApplicantName", txtApplicantNameSE.Text);
                                cmd.Parameters.AddWithValue("@UpdatingTable", "SE");
                                cmd.ExecuteNonQuery();

                                lblApplicationNumberSE.Text = "";
                                txtBankAddrSE.Text = "";
                                txtIFSCCodeSE.Text = "";
                                txtBranchSE.Text = "";
                                txtBankNameSE.Text = "";
                                txtAccountNumberSE.Text = "";
                                txtApplicantNameSE.Text = "";
                                lblApplicationNumberSE.Text = ApplicationNumber + " Updated";
                                //lblApplicationNumberSE.CssClass = "text-primary";
                                btnUpdateBankSE.Enabled = false;
                                btnUpdateBankSE.CssClass = "Button";


                            }
                            else
                            {
                                lblApplicationNumberSE.Text = ApplicationNumber + " Select Reason";
                            }
                        }
                        RefreshAllData();
                    }
                }
            }
            else
            {
                lblApplicationNumberSE.Text = ApplicationNumber + " Fill All Details";
            }
        }
        protected void btnClearAR_Click(object sender, EventArgs e)
        {
            if (txtAccountNumberAR.Text != "" && txtBankNameAR.Text != "" && txtIFSCCodeAR.Text != "" &&
                   txtBankAddrAR.Text != "" && txtBranchAR.Text != "")
            {
                lblApplicationNumberAR.Text = "";
                txtBankAddrAR.Text = "";
                txtIFSCCodeAR.Text = "";
                txtBranchAR.Text = "";
                txtBankNameAR.Text = "";
                txtAccountNumberAR.Text = "";
                txtApplicantNameAR.Text = "";
                lblApplicationNumberAR.Text = "";
                btnUpdateBankAR.Enabled = false;
                btnUpdateBankAR.CssClass = "Button";
            }
        }

        protected void btnGVUpdateBankAR_Click(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            //lblApplicationNumberAR.CssClass.Replace( "text-primary","");
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            ApplicationNumber = ArivugvDMDoc.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            if (ApplicationNumber != "")
            {
                using (kvdConn)
                {
                    if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                    SqlDataAdapter DAcmd = new SqlDataAdapter("SELECT ApplicantName,BankName,Branch,AccountNumber,IFSCCode,BankAddress FROM ArivuEduLoan WHERE ApplicationNumber= @AppnNumber", kvdConn);
                    DAcmd.SelectCommand.Parameters.AddWithValue("@AppnNumber", ApplicationNumber);
                    DataTable dt = new DataTable();
                    DAcmd.Fill(dt);

                    txtApplicantNameAR.Text = dt.Rows[0]["ApplicantName"].ToString();
                    txtAccountNumberAR.Text = dt.Rows[0]["AccountNumber"].ToString();
                    txtBankNameAR.Text = dt.Rows[0]["BankName"].ToString();
                    txtIFSCCodeAR.Text = dt.Rows[0]["IFSCCode"].ToString();
                    txtBankAddrAR.Text = dt.Rows[0]["BankAddress"].ToString();
                    txtBranchAR.Text = dt.Rows[0]["Branch"].ToString();
                    lblApplicationNumberAR.Text = ApplicationNumber;

                    btnUpdateBankAR.Enabled = true;
                    //txtApplicantNameAR.Enabled = false;
                    kvdConn.Close();
                    RefreshAllData();
                }

            }
        }
        protected void btnUpdateBankAR_Click(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            if (txtApplicantNameAR.Text.Trim() != "" && txtAccountNumberAR.Text.Trim() != "" && txtBankNameAR.Text.Trim() != "" && txtIFSCCodeAR.Text.Trim() != "" &&
                  txtBankAddrAR.Text.Trim() != "" && txtBranchAR.Text.Trim() != "")
            {
                if (ApplicationNumber != "")
                {
                    using (kvdConn)
                    {
                        if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                        SqlCommand cmd = new SqlCommand("UpdateBankDetails", kvdConn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (ApplicationNumber != "") //todo
                        {
                            if (drpARReasonBankModify.SelectedValue != "")
                            {
                                cmd.Parameters.AddWithValue("@AccountNumber", txtAccountNumberAR.Text);
                                cmd.Parameters.AddWithValue("@BankName", txtBankNameAR.Text);
                                cmd.Parameters.AddWithValue("@IFSCCode", txtIFSCCodeAR.Text);
                                cmd.Parameters.AddWithValue("@BankAddress", txtBankAddrAR.Text);
                                cmd.Parameters.AddWithValue("@Branch", txtBranchAR.Text);
                                cmd.Parameters.AddWithValue("@Reason", drpARReasonBankModify.SelectedValue);
                                cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                                cmd.Parameters.AddWithValue("@ApplicantName", txtApplicantNameAR.Text);
                                cmd.Parameters.AddWithValue("@UpdatingTable", "Arivu");
                                cmd.ExecuteNonQuery();

                                lblApplicationNumberAR.Text = "";
                                txtBankAddrAR.Text = "";
                                txtIFSCCodeAR.Text = "";
                                txtBranchAR.Text = "";
                                txtBankNameAR.Text = "";
                                txtAccountNumberAR.Text = "";
                                txtApplicantNameAR.Text = "";
                                lblApplicationNumberAR.Text = ApplicationNumber + " Updated";
                                //lblApplicationNumberAR.CssClass = "text-primary";
                                btnUpdateBankAR.Enabled = false;
                                btnUpdateBankAR.CssClass = "Button";
                            }
                            else
                            {
                                lblApplicationNumberAR.Text = ApplicationNumber + " Select Reason";
                            }
                        }
                       


                        RefreshAllData();
                    }
                }
            }
            else
            {
                lblApplicationNumberAR.Text = ApplicationNumber + " Fill All Details";
            }
        }
        protected void btnSEDocDownload_Click(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

            string DocCasteIncome, DocPhyCha, DocBankPassbook;
            string DBFile;
            string filename;
            string filepath, aadfilename;
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = SEgvDMDoc.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            filename = ApplicationNumber + "DocCasteIncome.pdf";
            DocCasteIncome = filepath + filename;
            DBFile = "DocCasteIncome";
            DownloadFile(DBFile, ApplicationNumber, filename, DocCasteIncome, "[KACDC].[dbo].[SelfEmpLoan]");

            filename = ApplicationNumber + "DocPhyCha.pdf";
            DocPhyCha = filepath + filename;
            DBFile = "DocPhyCha";
            DownloadFile(DBFile, ApplicationNumber, filename, DocPhyCha, "[KACDC].[dbo].[SelfEmpLoan]");

            filename = ApplicationNumber + "DocBankPassbook.pdf";
            DocBankPassbook = filepath + filename;
            DBFile = "DocPhyCha";
            DownloadFile(DBFile, ApplicationNumber, filename, DocBankPassbook, "[KACDC].[dbo].[SelfEmpLoan]");

            //aadfilename = ApplicationNumber + "Aadhar.pdf";
            //DownloadAadhar(ApplicationNumber, filename, "[KACDC].[dbo].[SelfEmpLoan]");

            using (ZipFile zip = new ZipFile())
            {
                zip.AddFile(DocCasteIncome, "files");
                zip.AddFile(DocBankPassbook, "files");
                //zip.AddFile(filepath + aadfilename, "files");
                zip.AddFile(DocPhyCha, "files");

                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + ApplicationNumber + ".zip");
                Response.ContentType = "application/zip";
                zip.Save(Response.OutputStream);
                Response.End();
            }

        }

        protected void SEgvDMCEOWaiting_RowEditing(object sender, GridViewEditEventArgs e)
        {
            divCEOSE.Visible = true;
            SEgvDMCEOWaiting.EditIndex = e.NewEditIndex;
            RefreshAllData();
        }

        protected void SEgvDMCEOWaiting_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Button btn = (Button)sender;
            //GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            //int rowindex = gvr.RowIndex;
            //string ApplicationNumber = SEgvDMCEOWaiting.DataKeys[rowindex].Values["ApplicationNumber"].ToString();            
            string ApplicationNumber = Convert.ToString(SEgvDMCEOWaiting.DataKeys[e.RowIndex].Values["ApplicationNumber"].ToString());
            TextBox txtLA = (TextBox)SEgvDMCEOWaiting.Rows[e.RowIndex].FindControl("txtLoanAmt");
            DropDownList drpQuota = (DropDownList)SEgvDMCEOWaiting.Rows[e.RowIndex].FindControl("drpQuota");
            GridViewRow row = SEgvDMCEOWaiting.Rows[e.RowIndex];
            string LoanAmt, qta;
            LoanAmt = txtLA.Text;

            qta = drpQuota.SelectedItem.Text;
            if (LoanAmt == null) { LoanAmt = "0"; }
            if (qta != "--SELECT--")
            {
                spCEOStatus("SEAPPROVECEO", LoanAmt, qta, "", "", "", ApplicationNumber);
            }

            
            RefreshAllData();
        }

        protected void SEgvDMCEOWaiting_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            SEgvDMCEOWaiting.EditIndex = -1;
            RefreshAllData();
        }

        protected void ArivugvDMCEOWaiting_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ArivugvDMCEOWaiting.EditIndex = -1;
            RefreshAllData();
        }

        protected void ArivugvDMCEOWaiting_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string ApplicationNumber = Convert.ToString(ArivugvDMCEOWaiting.DataKeys[e.RowIndex].Values["ApplicationNumber"].ToString());
            TextBox txt1Year = (TextBox)ArivugvDMCEOWaiting.Rows[e.RowIndex].FindControl("txt1Year");
            TextBox txt2Year = (TextBox)ArivugvDMCEOWaiting.Rows[e.RowIndex].FindControl("txt2Year");
            TextBox txt3Year = (TextBox)ArivugvDMCEOWaiting.Rows[e.RowIndex].FindControl("txt3Year");
            TextBox txt4Year = (TextBox)ArivugvDMCEOWaiting.Rows[e.RowIndex].FindControl("txt4Year");
            TextBox txt5Year = (TextBox)ArivugvDMCEOWaiting.Rows[e.RowIndex].FindControl("txt5Year");
            DropDownList drpQuota = (DropDownList)ArivugvDMCEOWaiting.Rows[e.RowIndex].FindControl("drpQuota");
            GridViewRow row = ArivugvDMCEOWaiting.Rows[e.RowIndex];
            string y1, y2, y3, y4, y5, qta;
            y1 = txt1Year.Text;
            y2 = txt2Year.Text;
            y3 = txt3Year.Text;
            y4 = txt4Year.Text;
            y5 = txt5Year.Text;
            qta = drpQuota.SelectedItem.Text;
            if (y1 == null) { y1 = "0"; }
            if (y2 == null) { y2 = "0"; }
            if (y3 == null) { y3 = "0"; }
            if (y4 == null) { y4 = "0"; }
            if (y5 == null) { y5 = "0"; }
            if (qta != "--SELECT--")
            {
                spDMArCEO("ARAPPROVECEO", y1, y2, y3, y4, y5, qta, "", "", "", ApplicationNumber);
            }

            
            RefreshAllData();
        }

        protected void ArivugvDMCEOWaiting_RowEditing(object sender, GridViewEditEventArgs e)
        {
            divCEOgv.Visible = true;
            ArivugvDMCEOWaiting.EditIndex = e.NewEditIndex;
            RefreshAllData();
        }
        
        protected void btnSEDocAccept_Click(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = SEgvDMDoc.DataKeys[rowindex].Values["ApplicationNumber"].ToString();

            SEDocStatus("SEAPPROVEDOC", "", ApplicationNumber);
            //this.ArivuDocApproveBindGrid();
            //this.SEDocApproveBindGrid();
            

            RefreshAllData();
        }

        protected void btnArivuDocReject_Click(object sender, EventArgs e)
        {
            txtARDocRejectReason.Text = "";
            lblARDocRejectError.Text = "";
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblARDocRejApplicationNumber.Text = ArivugvDMDoc.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblARDocRejApplicationName .Text= ArivugvDMDoc.DataKeys[rowindex].Values["ApplicantName"].ToString();
            DMARDocRejectPopup.Show();
        }
        protected void btnARDocRejectUpdate_Click(object sender, EventArgs e)
        {
            if (txtARDocRejectReason.Text.Trim() != "" && txtARDocRejectReason.Text.Trim() != null)
            {
                if (txtARDocRejectReason.Text.Length > 10)
                {
                    ArDocStatus("ARREJECTDOC", txtARDocRejectReason.Text.Trim(), lblARDocRejApplicationNumber.Text);
                    RefreshAllData();
                }
                else
                {
                    lblARDocRejectError.Text = "Reason must be minium 10 Characters";
                    DMARDocRejectPopup.Show();
                }
            }
            else
            {
                lblARDocRejectError.Text = "Enter Reason";
                DMARDocRejectPopup.Show();
            }
        }
        protected void btnArivuDMCEOReject_Click(object sender, EventArgs e)
        {
            txtARCEORejectReason.Text = "";
            lblARCEORejectError.Text = "";

            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblARCEORejApplicationNumber.Text = ArivugvDMCEO.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblARCEORejApplicationName.Text = ArivugvDMCEO.DataKeys[rowindex].Values["ApplicantName"].ToString();
            DMARCEORejectPopup.Show();            
        }
         protected void btnArivuDMCEOWaitingReject_Click(object sender, EventArgs e)
         {
            txtARCEOWaitingRejectReason.Text = "";
            lblARCEOWaitingRejectError.Text = "";

            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblARCEOWaitingRejApplicationNumber.Text = ArivugvDMCEOWaiting.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblARCEOWaitingRejApplicationName.Text = ArivugvDMCEOWaiting.DataKeys[rowindex].Values["ApplicantName"].ToString();
            DMARCEOWaitingRejectPopup.Show();
         }
        protected void btnARCEOWaitingRejectUpdate_Click(object sender, EventArgs e)
        {
            if (txtARCEOWaitingRejectReason.Text.Trim() != "" && txtARCEOWaitingRejectReason.Text.Trim() != null)
            {
                if (txtARCEOWaitingRejectReason.Text.Length > 10)
                {
                    spDMArCEO("ARREJECTCEO", "", "", "", "", "", "", "", "", txtARCEOWaitingRejectReason.Text.Trim(), lblARCEOWaitingRejApplicationNumber.Text);
                    RefreshAllData();
                }
                else
                {
                    lblARCEOWaitingRejectError.Text = "Reason must be minium 10 Characters";
                    DMARCEOWaitingRejectPopup.Show();
                }
            }
            else
            {
                lblARCEOWaitingRejectError.Text = "Enter Reason";
                DMARCEOWaitingRejectPopup.Show();
            }
        }

        protected void btnARCEORejectUpdate_Click(object sender, EventArgs e)
        {
            if (txtARCEORejectReason.Text.Trim() != "" && txtARCEORejectReason.Text.Trim() != null)
            {
                if (txtARCEORejectReason.Text.Length > 10)
                {
                    spDMArCEO("ARREJECTCEO", "", "", "", "", "", "", "", "", txtARCEORejectReason.Text.Trim(), lblARCEORejApplicationNumber.Text);
                    RefreshAllData();
                }
                else
                {
                    lblARCEORejectError.Text = "Reason must be minium 10 Characters";
                    DMARCEORejectPopup.Show();
                }
            }
            else
            {
                lblARCEORejectError.Text = "Enter Reason";
                DMARCEORejectPopup.Show();
            }
        }
        protected void btnSEDocReject_Click(object sender, EventArgs e)
        {
            txtSEDocRejectReason.Text = "";
            lblSEDocRejectError.Text = "";
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblSEDocRejApplicationNumber.Text = SEgvDMDoc.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblSEDocRejApplicationName.Text = SEgvDMDoc.DataKeys[rowindex].Values["ApplicantName"].ToString();
            DMSEDocRejectPopup.Show();
            
        }
        protected void btnSEDOCRejectUpdate_Click(object sender, EventArgs e)
        {
            if (txtSEDocRejectReason.Text.Trim()!="" && txtSEDocRejectReason.Text.Trim() != null )
            {
                if (txtSEDocRejectReason.Text.Length>10)
                {
                    SEDocStatus("SEREJECTDOC", txtSEDocRejectReason.Text.Trim(), lblSEDocRejApplicationNumber.Text);
                    RefreshAllData();
                }
                else
                {
                    lblSEDocRejectError.Text = "Reason must be minium 10 Characters";
                    DMSEDocRejectPopup.Show();
                }
            }
            else
            {
                lblSEDocRejectError.Text = "Enter Reason";
                DMSEDocRejectPopup.Show();
            }
        }
        protected void btnSECEOWaitingReject_Click(object sender, EventArgs e)
        {
            txtSECEOWaitingRejectReason.Text = "";
            lblSECEOWaitingRejectError.Text = "";
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblSECEOWaitingRejApplicationNumber.Text = SEgvDMCEOWaiting.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblSECEOWaitingRejApplicationName.Text = SEgvDMCEOWaiting.DataKeys[rowindex].Values["ApplicantName"].ToString();
            DMSECEOWaitingRejectPopup.Show();
        }
        protected void btnSECEOWaitingRejectUpdate_Click(object sender, EventArgs e)
        {
            if (txtSECEOWaitingRejectReason.Text.Trim() != "" && txtSECEOWaitingRejectReason.Text.Trim() != null)
            {
                if (txtSECEOWaitingRejectReason.Text.Length > 10)
                {
                    spCEOStatus("SEREJECTCEO", "", "", txtSECEOWaitingRejectReason.Text.Trim(), "", "", lblSECEOWaitingRejApplicationNumber.Text);
                    RefreshAllData();
                }
                else
                {
                    lblSECEOWaitingRejectError.Text = "Reason must be minium 10 Characters";
                    DMSECEOWaitingRejectPopup.Show();
                }
            }
            else
            {
                lblSECEOWaitingRejectError.Text = "Enter Reason";
                DMSECEOWaitingRejectPopup.Show();
            }
        }

        protected void btnSECEOReject_Click(object sender, EventArgs e)
        {
            txtSECEORejectReason.Text = "";
            lblSECEORejectError.Text = "";
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblSECEORejApplicationNumber.Text = SEgvDMCEO.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblSECEORejApplicationName.Text = SEgvDMCEO.DataKeys[rowindex].Values["ApplicantName"].ToString();
            DMSECEORejectPopup.Show();
            
        }
        protected void btnSECEORejectUpdate_Click(object sender, EventArgs e)
        {
            if (txtSECEORejectReason.Text.Trim() != "" && txtSECEORejectReason.Text.Trim() != null)
            {
                if (txtSECEORejectReason.Text.Length > 10)
                {
                    spCEOStatus("SEREJECTCEO", "", "", txtSECEORejectReason.Text.Trim(), "", "", lblSECEORejApplicationNumber.Text);
                    RefreshAllData();
                }
                else
                {
                    lblSECEORejectError.Text = "Reason must be minium 10 Characters";
                    DMSECEORejectPopup.Show();
                }
            }
            else
            {
                lblSECEORejectError.Text = "Enter Reason";
                DMSECEORejectPopup.Show();
            }
        }
        protected void DownloadFile(string DBFile, string ApplicationNumber, string filename, string sPathToSaveFileTo, string TableName)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
            using (SqlCommand cmd = new SqlCommand("select " + DBFile + " from " + TableName + " where [ApplicationNumber]='" + ApplicationNumber + "' ", kvdConn))
            {
                using (SqlDataReader dr1 = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                {
                    if (dr1.Read())
                    {
                        // read in using GetValue and cast to byte array
                        //byte[] v = ((byte[])dr1[DBFile]);
                        //if (v == DBNull.Value) { }

                        byte[] fileData = ((byte[])dr1[DBFile]);
                        // write bytes to disk as file
                        using (System.IO.FileStream fs = new System.IO.FileStream(sPathToSaveFileTo, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                        {
                            // use a binary writer to write the bytes to disk
                            using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                            {
                                bw.Write(fileData);
                                bw.Close();
                            }
                        }
                    }
                    dr1.Close();
                }
            }
            kvdConn.Close();

            //Response.Redirect("Download.aspx?File=" + filename);
        }

        protected void DownloadAadhar(string ApplicationNumber, string filename, string TableName)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            string filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename1 = ApplicationNumber + "Aadhar1.png";
            string filename2 = ApplicationNumber + "Aadhar2.png";
            string sPathToSaveFileTo1 = filepath + filename1;
            string sPathToSaveFileTo2 = filepath + filename2;
            string sPathToSaveFileTo3 = filepath + filename;
            string DBFile = "ImgAadharFront";
            //ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[ArivuEduLoan]");
            using (kvdConn)
            {
                kvdConn.Open();
                using (SqlCommand cmd = new SqlCommand("select ImgAadharFront,ImgAadharBack from " + TableName + " where [ApplicationNumber]='" + ApplicationNumber + "' ", kvdConn))
                {
                    using (SqlDataReader dr1 = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                    {
                        if (dr1.Read())
                        {
                            // read in using GetValue and cast to byte array
                            byte[] fileData1 = ((byte[])dr1["ImgAadharFront"]);
                            // write bytes to disk as file
                            using (System.IO.FileStream fs = new System.IO.FileStream(sPathToSaveFileTo1, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                            {
                                // use a binary writer to write the bytes to disk
                                using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                                {
                                    bw.Write(fileData1);
                                    bw.Close();
                                }
                            }
                            byte[] fileData2 = ((byte[])dr1["ImgAadharBack"]);
                            // write bytes to disk as file
                            using (System.IO.FileStream fs = new System.IO.FileStream(sPathToSaveFileTo2, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                            {
                                // use a binary writer to write the bytes to disk
                                using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                                {
                                    bw.Write(fileData2);
                                    bw.Close();
                                }
                            }
                        }
                        dr1.Close();
                    }
                }
            }
            using (var doc1 = new iTextSharp.text.Document())
            {
                PdfWriter writer = PdfWriter.GetInstance(doc1, new FileStream(sPathToSaveFileTo3, FileMode.Create));
                doc1.Open();

                //Add the Image file to the PDF document object.
                iTextSharp.text.Image img1 = iTextSharp.text.Image.GetInstance(sPathToSaveFileTo1);
                iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance(sPathToSaveFileTo2);
                doc1.Add(new Paragraph("AAdhar Front"));
                doc1.Add(img1);
                doc1.Add(new Paragraph("AAdhar Back"));
                doc1.Add(img2);
                doc1.Close();
            }
            //Download the PDF file.
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", "attachment;filename=ImageExport.pdf");
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.Write(pdfDoc);
            //Response.End();
            //callaadhar(filename3);

        }

        protected void btnPrintCEOApproved_Click(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            Document pdfDoc = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            Phrase phrase = null;           
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan"));  //Page Header          
            DrawSingleLine(pdfDoc, writer);   //Separater Line        
            pdfDoc.Add(PrintGrid(SEgvDMCEOApprovedList, "Approved List"));//Printing Table
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;" + "filename=SelfEmployment_Approved_"+getDistrict+"_"+FinancialYear+".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End(); 
        }
        protected void btnPrintCEOWaiting_Click(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            Document pdfDoc = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            Phrase phrase = null;
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan"));  //Page Header          
            DrawSingleLine(pdfDoc, writer);   //Separater Line        
            pdfDoc.Add(PrintGrid(SEgvDMCEOWaitingList, "Waiting List"));//Printing Table
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;" + "filename=SelfEmployment_Waiting_" + getDistrict + "_" + FinancialYear + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }
        protected void btnPrintCEORejected_Click(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            //PrintReportPDF("Arivu Educational Loan", "Rejected List", ArivugvDMCEORejectedList, "Arivu_Rejected_" + getDistrict + "_" + FinancialYear);

            Document pdfDoc = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            Phrase phrase = null;
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan"));  //Page Header          
            DrawSingleLine(pdfDoc, writer);   //Separater Line        
            pdfDoc.Add(PrintGrid(SEgvDMCEORejectedList, "Rejected List"));//Printing Table
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;" + "filename=SelfEmployment_Rejected_" + getDistrict + "_" + FinancialYear + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }
        protected void btnArivuPrintCEOApproved_Click(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

            Document pdfDoc = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            Phrase phrase = null;
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            pdfDoc.Add(PrintPageHeading(phrase, "Arivu Educational Loan"));  //Page Header          
            DrawSingleLine(pdfDoc, writer);   //Separater Line        
            pdfDoc.Add(PrintGrid(ArivugvDMCEOApprovedList, "Approved List"));//Printing Table
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;" + "filename=Arivu_Approved_" + getDistrict + "_" + FinancialYear + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }

        protected void btnArivuPrintCEOWaiting_Click(object sender, EventArgs e)
        {
            Document pdfDoc = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            Phrase phrase = null;
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            pdfDoc.Add(PrintPageHeading(phrase, "Arivu Education Loan"));  //Page Header          
            DrawSingleLine(pdfDoc, writer);   //Separater Line        
            pdfDoc.Add(PrintGrid(ArivugvDMCEOWaitingList, "Waiting List"));//Printing Table
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;" + "filename=Arivu_Waiting_" + getDistrict + "_" + FinancialYear + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();

        }

        protected void btnArivuPrintCEORejected_Click(object sender, EventArgs e)
        {
            //PrintReportPDF("Arivu Educational Loan", "Rejected List", ArivugvDMCEORejectedList,"Arivu_Rejected_" + getDistrict + "_" + FinancialYear);
            Document pdfDoc = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            Phrase phrase = null;
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            pdfDoc.Add(PrintPageHeading(phrase, "Arivu Edication Loan"));  //Page Header          
            DrawSingleLine(pdfDoc, writer);   //Separater Line        
            pdfDoc.Add(PrintGrid(ArivugvDMCEORejectedList, "Rejected List"));//Printing Table
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;" + "filename=Arivu_Rejected_" + getDistrict + "_" + FinancialYear + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }
        protected void PrintReportPDF(string LoanName,string ListType,GridView gridView,string FileName)
        {
            Document pdfDoc = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            Phrase phrase = null;
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            pdfDoc.Add(PrintPageHeading(phrase, LoanName));  //Page Header          
            DrawSingleLine(pdfDoc, writer);   //Separater Line        
            pdfDoc.Add(PrintGrid(gridView, ListType));//Printing Table
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;" + "filename=" + FileName + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }
        protected void btnSESubmitZM_Click(object sender, EventArgs e)
        {
            this.DMDocReportPrintBindGrid();
            Document pdfDoc = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
            Phrase phrase = null;
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            //PdfWriter.GetInstance(pdfDoc, memoryStream);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);               
                pdfDoc.Open();
                //htmlparser.Parse(sr);

                pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan"));  //Page Header          
                DrawSingleLine(pdfDoc, writer);   //Separater Line    
                if (SEDMDocPrintApprove.Rows.Count > 0)
                {
                    pdfDoc.Add(PrintGrid(SEDMDocPrintApprove, "Documentation Approved List"));//Printing Table
                }
                if (SEDMDocPrintWaiting.Rows.Count > 0)
                {
                    pdfDoc.Add(PrintGrid(SEDMDocPrintWaiting, "Documentation Pending List"));//Printing Table
                }
                if(SEDMDocPrintReject.Rows.Count > 0)
                {
                    pdfDoc.Add(PrintGrid(SEDMDocPrintReject, "Documentation Rejected List"));//Printing Table
                }
                
                writer.CloseStream = false;
                pdfDoc.Close();

                //Sending Mail
                byte[] bytes = memoryStream.ToArray();

                //string SenderMailID = "kacdc.bangalore@gmail.com";
                //string SenderPassword = "Kacdc@123";
                //PortNum : 587
                //SMTP_Server: smtp.gmail.com
                SmtpClient SmtpServer = new SmtpClient(SMTP_Server);
                SmtpServer.Port = Int32.Parse(PortNum);
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential(SenderMailID, SenderPassword);
                SmtpServer.EnableSsl = true;
                

                MailMessage mail = new MailMessage();
                mail.To.Add(ToMail);
                mail.CC.Add(CCMail);
                mail.From = new MailAddress(SenderMailID);
                mail.Subject = "Self Employment Report : " + getDistrict + " ( " + FinancialYear + " ) ";
                mail.IsBodyHtml = true;
                mail.Body = "Dear Sir/Madam <br />Please find the attachment of Document Verification Report and sent same for Zonal Manager <br /><br />From  <br />Karnataka Arya Vysya Community Development Corporation <br />" + getDistrict;
                mail.Attachments.Add(new Attachment(new MemoryStream(bytes), "SelfEmployment_" + getDistrict + "_" + FinancialYear + ".pdf"));
                SmtpServer.Send(mail);

                lblSEZMSubmitStatus.Text = "Successfully Submitted to ZM";
                lblSEZMSubmitStatus.ForeColor = System.Drawing.Color.Green;
                //Response.ContentType = "application/pdf";
                //Response.AddHeader("content-disposition", "attachment;" + "filename=SelfEmployment_Rejected_" + getDistrict + "_" + FinancialYear + ".pdf");
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.Write(pdfDoc);
                //Response.End();
                SEPrintDocReportToDM();
            }
        }
        protected void SEPrintDocReportToDM()
        {
            Document pdfDoc = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            Phrase phrase = null;
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Edication Loan"));  //Page Header          
            DrawSingleLine(pdfDoc, writer);   //Separater Line        
            if (SEDMDocPrintApprove.Rows.Count > 0)
            {
                pdfDoc.Add(PrintGrid(SEDMDocPrintApprove, "Documentation Approved List"));//Printing Table
            }
            if (SEDMDocPrintWaiting.Rows.Count > 0)
            {
                pdfDoc.Add(PrintGrid(SEDMDocPrintWaiting, "Documentation Pending List"));//Printing Table
            }
            if (SEDMDocPrintReject.Rows.Count > 0)
            {
                pdfDoc.Add(PrintGrid(SEDMDocPrintReject, "Documentation Rejected List"));//Printing Table
            }
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;" + "filename=SelfEmployment_" + getDistrict + "_" + FinancialYear + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }
        protected void btnArivuSubmitZM_Click(object sender, EventArgs e)
        {
            lblArivuZMSubmitStatus.Text = "Please Wait...";
            this.DMDocReportPrintBindGrid();
            Document pdfDoc = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
            Phrase phrase = null;
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            //PdfWriter.GetInstance(pdfDoc, memoryStream);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();
                //htmlparser.Parse(sr);
                //
                pdfDoc.Add(PrintPageHeading(phrase, "Arivu Edication Loan"));  //Page Header          
                DrawSingleLine(pdfDoc, writer);   //Separater Line   
                if (ARDMDocPrintApprove.Rows.Count > 0)
                {
                    pdfDoc.Add(PrintGrid(ARDMDocPrintApprove, "Documentation Approved List"));//Printing Table
                }
                if (ARDMDocPrintWaiting.Rows.Count > 0)
                {
                    pdfDoc.Add(PrintGrid(ARDMDocPrintWaiting, "Documentation Pending List"));//Printing Table
                }
                if (ARDMDocPrintReject.Rows.Count > 0)
                {
                    pdfDoc.Add(PrintGrid(ARDMDocPrintReject, "Documentation Rejected List"));//Printing Table
                }
                writer.CloseStream = false;
                pdfDoc.Close();

                //Sending Mail
                byte[] bytes = memoryStream.ToArray();

                //string SenderMailID = "kacdc.bangalore@gmail.com";
                //string SenderPassword = "Kacdc@123";
                //PortNum : 587
                //SMTP_Server: smtp.gmail.com
                SmtpClient SmtpServer = new SmtpClient(SMTP_Server);
                SmtpServer.Port = Int32.Parse(PortNum);
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential(SenderMailID, SenderPassword);
                SmtpServer.EnableSsl = true;


                MailMessage mail = new MailMessage();
                mail.To.Add(ToMail);
                mail.CC.Add(CCMail);
                mail.From = new MailAddress(SenderMailID);
                mail.Subject = "Arivu Report : " + getDistrict + " ( " + FinancialYear + " ) ";
                mail.IsBodyHtml = true;
                mail.Body = "Dear Sir/Madam <br />Please find the attachment of Document Verification Report and sent same for Zonal Manager <br /><br />From  <br />Karnataka Arya Vysya Community Development Corporation <br />" + getDistrict;
                mail.Attachments.Add(new Attachment(new MemoryStream(bytes), "Arivu_" + getDistrict + "_" + FinancialYear + ".pdf"));
                SmtpServer.Send(mail);

                lblArivuZMSubmitStatus.Text = "Successfully Submitted to ZM";
                lblArivuZMSubmitStatus.ForeColor= System.Drawing.Color.Green;
                //Response.ContentType = "application/pdf";
                //Response.AddHeader("content-disposition", "attachment;" + "filename=SelfEmployment_Rejected_" + getDistrict + "_" + FinancialYear + ".pdf");
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.Write(pdfDoc);
                //Response.End();
                ARPrintDocReportToDM();
            }
        }
        protected void ARPrintDocReportToDM()
        {
            Document pdfDoc = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            Phrase phrase = null;
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            pdfDoc.Add(PrintPageHeading(phrase, "Arivu Edication Loan"));  //Page Header          
            DrawSingleLine(pdfDoc, writer);   //Separater Line        
            if (ARDMDocPrintApprove.Rows.Count > 0)
            {
                pdfDoc.Add(PrintGrid(ARDMDocPrintApprove, "Documentation Approved List"));//Printing Table
            }
            if (ARDMDocPrintWaiting.Rows.Count > 0)
            {
                pdfDoc.Add(PrintGrid(ARDMDocPrintWaiting, "Documentation Pending List"));//Printing Table
            }
            if (ARDMDocPrintReject.Rows.Count > 0)
            {
                pdfDoc.Add(PrintGrid(ARDMDocPrintReject, "Documentation Rejected List"));//Printing Table
            }
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;" + "filename=Arivu_" + getDistrict + "_" + FinancialYear + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }
        protected PdfPTable PrintPageHeading(Phrase phrase, string LoanName)
        {
            PdfPTable table = null;
            //Create Header Table
            table = new PdfPTable(3);
            table.TotalWidth = 550f;
            table.LockedWidth = true;
            table.SetWidths(new float[] { 0.1f, 0.7f, 0.1f });
            PageHeader(table, phrase, LoanName);
            return table;
        }
        protected PdfPTable PageHeader(PdfPTable table, Phrase phrase, string LoanType)
        {
            table.AddCell(AddLogo("~/Image/GOK_PDF.png", phrase, PdfPCell.ALIGN_LEFT)); //GOV Logo      
            table.AddCell(NameAddr(LoanType, FinancialYear, phrase, getDistrict, DateTime.Now.ToString("dd MMMM yyyy hh:mm tt")));//Page Heading
            table.AddCell(AddLogo("~/Image/KACDC_PDF.png", phrase, PdfPCell.ALIGN_RIGHT));//KACDC Logo   
            return table;
        }
        protected PdfPTable PrintGrid(GridView gridView, string ListType)
        {
            PdfPTable D_Table = null;
            int ColCount = gridView.Columns.Count;
            ZM_Form zf = new ZM_Form();
            int[] widths = new int[gridView.Columns.Count];
            D_Table = CreatePdfTable(D_Table, ColCount); //Assign Table Properties                  
            D_Table.AddCell(TableHeader(ListType, ColCount)); //Table Heading
            ColumHeader(gridView, D_Table, widths);//Table Colum Header
            FillTableData(gridView, D_Table);//Table Data
            return D_Table;
        }
        protected void ColumHeader(GridView gv, PdfPTable D_Table, int[] widths)
        {
            PdfPCell cell = null;
            for (int x = 0; x < gv.Columns.Count; x++)
            {
                widths[x] = (int)gv.Columns[x].ItemStyle.Width.Value;
                string cellText = Server.HtmlDecode(gv.HeaderRow.Cells[x].Text);
                cell = new PdfPCell(new Phrase(new Chunk(cellText, FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLACK))));
                cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#008000"));
                cell.BorderColor = BaseColor.BLACK;
                cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cell.PaddingBottom = 2f;
                cell.PaddingTop = 0f;
                D_Table.AddCell(cell);
            }

        }
        protected void FillTableData(GridView gv, PdfPTable D_Table)
        {
            PdfPCell cell = null;
            for (int i = 0; i < gv.Rows.Count; i++)
            {
                if (gv.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    for (int j = 0; j < gv.Columns.Count; j++)
                    {
                        string cellText = Server.HtmlDecode(gv.Rows[i].Cells[j].Text);
                        cell = new PdfPCell(new Phrase(cellText));

                        //Set Color of Alternating row
                        if (i % 2 != 0)
                        {
                            cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#C2D69B"));
                        }
                        cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                        cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        cell.PaddingBottom = 3f;
                        cell.PaddingTop = 3f;
                        D_Table.AddCell(cell);
                    }
                }
            }
        }
        private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, BaseColor color)
        {
            PdfContentByte contentByte = writer.DirectContent;
            contentByte.SetColorStroke(color);
            contentByte.MoveTo(x1, y1);
            contentByte.LineTo(x2, y2);
            contentByte.Stroke();
        }
        private static PdfPTable CreatePdfTable(PdfPTable D_Table, int ColCount)
        {
            D_Table = new PdfPTable(ColCount);
            D_Table.TotalWidth = 550f;
            D_Table.LockedWidth = true;
            //D_Table.SetWidths(new float[] { 0.1f, 0.2f, 0.1f });
            D_Table.SpacingBefore = 20;
            D_Table.SpacingAfter = 30f;
            return D_Table;
        }
        private static PdfPCell PhraseCell(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            return cell;
        }
        private static PdfPCell AddLogo(string Path, Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell = ImageCell(Path, 30f, align);
            return cell;
        }

        protected void SEgvDMDoc_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            SEgvDMDoc.EditIndex = -1;
            this.SEDocApproveBindGrid();
        }

        protected void SEgvDMDoc_RowEditing(object sender, GridViewEditEventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

            string GetApplicationNum;
            //using (kvdConn)
            //{
            //    SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            //    if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }

            //    SqlCommand cmd = new SqlCommand("spSEGetApprovedAppNumber");
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@District", getDistrict);
            //    cmd.Parameters.Add("@Appnum", SqlDbType.NVarChar, 100);
            //    cmd.Parameters["@Appnum"].Direction = ParameterDirection.Output;
            //    //GetApplicationNum = (string)cmd.Parameters["@Appnum"].Value.ToString();



            //    //cmd.Parameters.Add("@Appnum", SqlDbType.NVarChar, 100);
            //    //cmd.Parameters["@Appnum"].Direction = ParameterDirection.Output;

            //    //cmd.Parameters.Add("@Appnum", SqlDbType.NVarChar,100).Direction = ParameterDirection.Output;
            //    //cmd.Parameters["@id"].Direction = ParameterDirection.Output;
            //    cmd.Connection = kvdConn;
            //    //cmd.ExecuteScalar();

            //    //GetApplicationNum = (string)cmd.Parameters["@Appnum"].Value;
            //    GetApplicationNum= "KACDC/SE/03/CR-01(000001)/17-05-2020";

            //    //SqlCommand CmdGetApplicationNum = new SqlCommand("SELECT [dbo].[funNextApplicationNum](@District)", kvdConn);
            //    //CmdGetApplicationNum.CommandType = CommandType.Text;
            //    //CmdGetApplicationNum.Parameters.Add(new SqlParameter("@District", getDistrict));
            //    //GetApplicationNum = (string)CmdGetApplicationNum.ExecuteScalar();
            //    //kvdConn.Close();


            //}

            SEgvDMDoc.EditIndex = e.NewEditIndex;
            TextBox ApplicationNumber = (TextBox)SEgvDMDoc.Rows[e.NewEditIndex].FindControl("txtApprovedApplicationNumber");
            //txtApprovedApplicationNumber.Text = "KACDC/SE/03/CR-01(000001)/17-05-2020";
            SEDocApproveBindGrid();

            //SEgvDMDoc.EditIndex = e.NewEditIndex;
            //TextBox AppNumTextBox = (TextBox)SEgvDMDoc.Rows[e.NewEditIndex].FindControl("txtApprovedApplicationNumber");
            ////AppNumTextBox.Text = "KACDC/SE/03/CR-01(000001)/17-05-2020";
            //this.SEDocApproveBindGrid();
        }
        protected void ShowPopup(object sender, EventArgs e)
        {
            string title = "Greetings";
            string body = "Welcome to ASPSnippets.com";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
        protected void SEgvDMDoc_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string ApplicationNumber = Convert.ToString(SEgvDMCEO.DataKeys[e.RowIndex].Values["ApplicationNumber"].ToString());
            TextBox txtLA = (TextBox)SEgvDMCEO.Rows[e.RowIndex].FindControl("txtLoanAmt");
            DropDownList drpQuota = (DropDownList)SEgvDMCEO.Rows[e.RowIndex].FindControl("drpQuota");
            GridViewRow row = SEgvDMCEO.Rows[e.RowIndex];
            string LoanAmt, qta;
            LoanAmt = txtLA.Text;

            qta = drpQuota.SelectedItem.Text;
            if (LoanAmt == null) { LoanAmt = "0"; }
            if (qta != "--SELECT--")
            {
                spCEOStatus("SEAPPROVECEO", LoanAmt, qta, "", "", "", ApplicationNumber);
            }


            RefreshAllData();
        }

        protected void btnSeAppNum_Click(object sender, EventArgs e)
        {
            //txtApplicationNumber.Text = "Hi...";
            string title = "Greetings";
            string body = "Welcome to ASPSnippets.com";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
        
        private static PdfPCell TableHeader(string Headding, int ColSpanCount)
        {
            PdfPCell cell = null;
            cell = new PdfPCell(new Phrase(new Chunk(Headding, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK))));
            cell.Colspan = ColSpanCount;
            cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            cell.PaddingBottom = 3f;
            cell.Border = 0;
            cell.Padding = 5;
            return cell;
        }
        private static PdfPCell NameAddr(string LoanName, string FinancialYear, Phrase phrase, string District, string Date)
        {
            PdfPCell cell = null;
            phrase = new Phrase();
            phrase.Add(new Chunk("Karnataka Arya Vysya Community Development Corporation\n", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.RED)));
            phrase.Add(new Chunk(LoanName + " ( " + FinancialYear + " )" + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
            //phrase.Add(new Chunk("Year of: " + FinancialYear + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
            phrase.Add(new Chunk("District: " + District + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
            phrase.Add(new Chunk("Date: " + Date, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER);
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            return cell;
        }
        private static void DrawSingleLine(Document pdfDoc, PdfWriter writer)
        {
            BaseColor color = null;
            color = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"));
            DrawLine(writer, 25f, pdfDoc.Top - 82f, pdfDoc.PageSize.Width - 25f, pdfDoc.Top - 82f, color);
            DrawLine(writer, 25f, pdfDoc.Top - 83f, pdfDoc.PageSize.Width - 25f, pdfDoc.Top - 83f, color);
        }
        private static PdfPCell ImageCell(string path, float scale, int align)
        {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
            image.ScalePercent(scale);
            PdfPCell cell = new PdfPCell(image);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 0f;
            cell.PaddingTop = 0f;
            return cell;
        }
    }
}