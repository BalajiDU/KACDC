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
using Excel = Microsoft.Office.Interop.Excel;
using System.Net.Mail;
using iTextSharp.text.html.simpleparser;

namespace KACDC
{
    public partial class ZM_Form : System.Web.UI.Page
    {
        SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
        private string getZone
        {
            set { ViewState["getZone"] = value; }
            get { return ViewState["getZone"] as string; }
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
        private string ZMAccountNumber
        {
            set { ViewState["ZMAccountNumber"] = value; }
            get { return ViewState["ZMAccountNumber"] as string; }
        }
        private string ZMIFSCCode
        {
            set { ViewState["ZMIFSCCode"] = value; }
            get { return ViewState["ZMIFSCCode"] as string; }
        }
        private string ZMBankName
        {
            set { ViewState["ZMBankName"] = value; }
            get { return ViewState["ZMBankName"] as string; }
        }
        private string ZMARYear
        {
            set { ViewState["ZMARYear"] = value; }
            get { return ViewState["ZMARYear"] as string; }
        }
        private string ZMARYearRelease
        {
            set { ViewState["ZMARYearRelease"] = value; }
            get { return ViewState["ZMARYearRelease"] as string; }
        }
        private string ZMARLoanType
        {
            set { ViewState["ZMARLoanType"] = value; }
            get { return ViewState["ZMARLoanType"] as string; }
        }
        private string ZMBranch
        {
            set { ViewState["ZMBranch"] = value; }
            get { return ViewState["ZMBranch"] as string; }
        }
        private string ZMSETotalFund
        {
            set { ViewState["ZMSETotalFund"] = value; }
            get { return ViewState["ZMSETotalFund"] as string; }
        }
        private string ZMSEDistrictTotalFund
        {
            set { ViewState["ZMSEDistrictTotalFund"] = value; }
            get { return ViewState["ZMSEDistrictTotalFund"] as string; }
        }
        private string ZMARDistrictTotalFund
        {
            set { ViewState["ZMARDistrictTotalFund"] = value; }
            get { return ViewState["ZMARDistrictTotalFund"] as string; }
        }
        private string ZMARTotalFund
        {
            set { ViewState["ZMARTotalFund"] = value; }
            get { return ViewState["ZMARTotalFund"] as string; }
        }
        private string ZMSEApprovedCount
        {
            set { ViewState["ZMSEApprovedCount"] = value; }
            get { return ViewState["ZMSEApprovedCount"] as string; }
        }
        private string ZMSEDistrictApprovedCount
        {
            set { ViewState["ZMSEDistrictApprovedCount"] = value; }
            get { return ViewState["ZMSEDistrictApprovedCount"] as string; }
        }
        private string ZMARDistrictApprovedCount
        {
            set { ViewState["ZMARDistrictApprovedCount"] = value; }
            get { return ViewState["ZMARDistrictApprovedCount"] as string; }
        }
        private string ZMARApprovedCount
        {
            set { ViewState["ZMARApprovedCount"] = value; }
            get { return ViewState["ZMARApprovedCount"] as string; }
        }
        private string ZMARRelease
        {
            set { ViewState["ZMARRelease"] = value; }
            get { return ViewState["ZMARRelease"] as string; }
        }
        private string ApplicationNumberAR
        {
            set { ViewState["ApplicationNumberAR"] = value; }
            get { return ViewState["ApplicationNumberAR"] as string; }
        }
        private string ApplicationNumberReleaseAR
        {
            set { ViewState["ApplicationNumberReleaseAR"] = value; }
            get { return ViewState["ApplicationNumberReleaseAR"] as string; }
        }
        private string ApplicationNumberSE
        {
            set { ViewState["ApplicationNumberSE"] = value; }
            get { return ViewState["ApplicationNumberSE"] as string; }
        }
        private string ApplicationNumberReleaseSE
        {
            set { ViewState["ApplicationNumberReleaseSE"] = value; }
            get { return ViewState["ApplicationNumberReleaseSE"] as string; }
        }
        private string ZMARSelectedDistrict
        {
            set { ViewState["ZMARSelectedDistrict"] = value; }
            get { return ViewState["ZMARSelectedDistrict"] as string; }
        }
        private string ZMARSelectedReleaseDistrict
        {
            set { ViewState["ZMARSelectedReleaseDistrict"] = value; }
            get { return ViewState["ZMARSelectedReleaseDistrict"] as string; }
        }
        private string ZMSESelectedReleaseDistrict
        {
            set { ViewState["ZMSESelectedReleaseDistrict"] = value; }
            get { return ViewState["ZMSESelectedReleaseDistrict"] as string; }
        }
        private string ZMSESelectedDistrict
        {
            set { ViewState["ZMSESelectedDistrict"] = value; }
            get { return ViewState["ZMSESelectedDistrict"] as string; }
        }
        private string ZMSEBankDifferBank
        {
            set { ViewState["ZMSEBankDifferBank"] = value; }
            get { return ViewState["ZMSEBankDifferBank"] as string; }
        }
        private string ZMSEBankDifferType
        {
            set { ViewState["ZMSEBankDifferType"] = value; }
            get { return ViewState["ZMSEBankDifferType"] as string; }
        }
        
            
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

            if (Session["USERTYPE"] != "ZONALMANAGER")
            {
                Response.Redirect("~/Login.aspx");

            }
            getZone = Session["Zone"].ToString();
            
            if (!this.IsPostBack)
            {
                this.DropDownBinding();
                RefreshAll();
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
                            SMTP_Server = sdr["SMTP_Server"].ToString();
                        }
                        kvdConn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            
            this.GetAccountDetails();
        }
        private void GetAccountDetails()
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

            try
            {
                using (kvdConn)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM MstZone WHERE ZoneName='"+getZone+"'"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@ZoneName", getZone);
                        cmd.Connection = kvdConn;
                        kvdConn.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            ZMAccountNumber = sdr["AccountNumber"].ToString();
                            ZMIFSCCode = sdr["IFSCCode"].ToString();
                            ZMBankName = sdr["BankName"].ToString();
                            ZMBranch = sdr["Branch"].ToString();
                        }
                        kvdConn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        private void GetTotalCount()
        {
            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                DataSet ds = new DataSet();
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spZMPrinting", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "SEZMAPPROVEDCount");
                cmd.Parameters.AddWithValue("@Zone", getZone);
                cmd.Parameters.AddWithValue("@District", ZMSESelectedDistrict);
                cmd.Parameters.Add("@Count", SqlDbType.VarChar, -1);
                cmd.Parameters["@Count"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Total", SqlDbType.VarChar, -1);
                cmd.Parameters["@Total"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@DisCount", SqlDbType.VarChar, -1);
                cmd.Parameters["@DisCount"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@DisTotal", SqlDbType.VarChar, -1);
                cmd.Parameters["@DisTotal"].Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();
                ZMSETotalFund= cmd.Parameters["@Total"].Value.ToString();
                ZMSEApprovedCount= cmd.Parameters["@Count"].Value.ToString();
                ZMSEDistrictTotalFund = cmd.Parameters["@DisTotal"].Value.ToString();
                ZMSEDistrictApprovedCount = cmd.Parameters["@DisCount"].Value.ToString();
                lblSETotalApplications.Text = ZMSEApprovedCount;
                lblSETotalSum.Text = ZMSETotalFund;
                lblZMSEDistrictDisplayCount.Text = ZMSESelectedDistrict + " - Applications";
                lblZMSEDistrictApplicationCount.Text = ZMSEDistrictApprovedCount;
                lblZMSEDistrictDisplayTotal.Text = ZMSESelectedDistrict+ " -  Fund";
                lblZMSEDistrictApplicationTotal.Text = ZMSEDistrictTotalFund;
            }
            using (kvdConn)
            {
                if (ZMARYear== "Year1Loan")
                {
                    ZMARRelease = "Y1Release";
                }
                else if (ZMARYear == "Year2Loan")
                {
                    ZMARRelease = "Y2Release";
                }
                else if(ZMARYear == "Year3Loan")
                {
                    ZMARRelease = "Y3Release";
                }
                else if (ZMARYear == "Year4Loan")
                {
                    ZMARRelease = "Y4Release";
                }
                else if (ZMARYear == "Year5Loan")
                {
                    ZMARRelease = "Y5Release";
                }
                else
                {
                    ZMARYear = "Year1Loan";
                    ZMARRelease = "Y1Release";
                }
                //if (ZMARLoanType == null)
                //{
                //    ZMARLoanType = "NOT";
                //}
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                string Sumsql = @"SELECT CAST(SUM(CAST(" + ZMARYear + " as NUMERIC(10, 2)))AS nvarchar(20)) as SumVal FROM[dbo].ArivuEduLoan,MstDistrict as Dst " +
                    "WHERE ZMApprove = 'APPROVED' AND Dst.ZoneName = @ZoneName and dst.DistrictName = ParDistrict " +
                    "";
                    //"and "+ ZMARRelease + " IS " + ZMARLoanType + " NULL";
                string Countsql = @"SELECT CAST(COUNT(*)AS nvarchar(20)) as CountVal FROM[dbo].ArivuEduLoan,MstDistrict as Dst " +
                    "WHERE ZMApprove = 'APPROVED' AND Dst.ZoneName = @ZoneName and dst.DistrictName = ParDistrict " +
                    "";
                //"and " + ZMARRelease + " IS " + ZMARLoanType + " NULL";
                string DisSumsql = @"SELECT CAST(SUM(CAST(" + ZMARYear + " as NUMERIC(10, 2)))AS nvarchar(20)) as SumVal FROM[dbo].ArivuEduLoan,MstDistrict as Dst " +
                    "WHERE ZMApprove = 'APPROVED' AND Dst.ZoneName = @ZoneName and dst.DistrictName = ParDistrict " +
                    // "and " + ZMARRelease + " IS " + ZMARLoanType + " NULL " +
                    "and ParDistrict=@District";
                string DisCountsql = @"SELECT CAST(COUNT(*)AS nvarchar(20)) as CountVal FROM[dbo].ArivuEduLoan,MstDistrict as Dst " +
                    "WHERE ZMApprove = 'APPROVED' AND Dst.ZoneName = @ZoneName and dst.DistrictName = ParDistrict " +
                    //"and " + ZMARRelease + " IS " + ZMARLoanType + " NULL " +
                    "and ParDistrict=@District";

                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + sql + "')", true);

                using (SqlCommand cmd = new SqlCommand(Sumsql))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ZoneName", getZone);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                         ZMARTotalFund= sdr["SumVal"].ToString();
                        lblARTotalSum.Text = ZMARTotalFund;
                    }
                    kvdConn.Close();
                }
                using (SqlCommand cmd = new SqlCommand(Countsql))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ZoneName", getZone);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        ZMARApprovedCount = sdr["CountVal"].ToString();
                        lblARTotalApplications.Text = ZMARApprovedCount;
                    }
                    kvdConn.Close();
                }
                using (SqlCommand cmd = new SqlCommand(DisSumsql))
                {
                    if (ZMARSelectedDistrict != null)
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@ZoneName", getZone);
                        cmd.Parameters.AddWithValue("@District", ZMARSelectedDistrict);
                        cmd.Connection = kvdConn;
                        kvdConn.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            ZMARDistrictTotalFund = sdr["SumVal"].ToString();
                            if (ZMARDistrictTotalFund != "")
                            {
                                lblZMARDistrictApplicationTotal.Text = ZMARDistrictTotalFund;
                            }
                            else
                            {
                                lblZMARDistrictApplicationTotal.Text = "0";
                            }
                            lblZMARDistrictDisplayTotal.Text = ZMARSelectedDistrict + " -  Fund";
                        }
                        kvdConn.Close();
                    }
                }
                using (SqlCommand cmd = new SqlCommand(DisCountsql))
                {
                    if (ZMARSelectedDistrict != null)
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@ZoneName", getZone);
                        cmd.Parameters.AddWithValue("@District", ZMARSelectedDistrict);
                        cmd.Connection = kvdConn;
                        kvdConn.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            ZMARDistrictApprovedCount = sdr["CountVal"].ToString();
                            if (ZMARDistrictApprovedCount != "")
                            {
                                lblZMARDistrictApplicationCount.Text = ZMARDistrictApprovedCount;
                            }
                            lblZMARDistrictDisplayCount.Text = ZMARSelectedDistrict + " - Applications";

                        }
                        kvdConn.Close();
                    }
                }

            }
        }
        private void RefreshAll()
        {            
            this.GetTotalCount();
            this.ArivuCWApproveBindGrid();
            this.gvSEZMpproveBindGrid();
            this.ZMReportPrintBindGrid();
            this.ArivuCeoDocDownloadBindGrid();
            this.SECeoDocDownloadBindGrid();
            this.ArivuZMDisplayBindGrid();
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        } 
        private void gvSEZMpproveBindGrid()
        {
            DataSet ds = new DataSet();
            //CEO
            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                //kvdConn.Open();
                if (kvdConn.State == ConnectionState.Closed)
                {
                    kvdConn.Open();
                }
                SqlCommand cmd = new SqlCommand("spSEApprove", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "SESELECTZM");
                cmd.Parameters.AddWithValue("@Zone", getZone);
                cmd.Parameters.AddWithValue("@District", ZMSESelectedDistrict);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvSEZMpprove.DataSource = ds;
                    gvSEZMpprove.DataBind();

                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    gvSEZMpprove.DataSource = ds;
                    gvSEZMpprove.DataBind();
                    int columncount = gvSEZMpprove.Rows[0].Cells.Count;
                    gvSEZMpprove.Rows[0].Cells.Clear();
                    gvSEZMpprove.Rows[0].Cells.Add(new TableCell());
                    gvSEZMpprove.Rows[0].Cells[0].ColumnSpan = columncount;
                    gvSEZMpprove.Rows[0].Cells[0].Text = "No Records Found";
                }
            }
        }
        private void DropDownBinding()
        {
            //drpArivuDistrict
            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            
                using (SqlCommand cmd = new SqlCommand("select DistrictName from MstDistrict where ZoneName=@Zone"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Zone", getZone);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    drpArivuDistrict.DataSource = cmd.ExecuteReader();
                    drpArivuDistrict.DataTextField = "DistrictName";
                    drpArivuDistrict.DataValueField = "DistrictName";
                    drpArivuDistrict.DataBind();
                    drpArivuDistrict.Items.Insert(0, "--SELECT--");
                    kvdConn.Close();
                }
            }
            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                using (SqlCommand cmd = new SqlCommand("select distinct DistrictName from MstDistrict where ZoneName=@Zone"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Zone", getZone);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    drpSEDistrict.DataSource = cmd.ExecuteReader();
                    drpSEDistrict.DataTextField = "DistrictName";
                    drpSEDistrict.DataValueField = "DistrictName";
                    drpSEDistrict.DataBind();
                    drpSEDistrict.Items.Insert(0, "--SELECT--");
                    kvdConn.Close();
                }
            }
            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                using (SqlCommand cmd = new SqlCommand("select distinct DistrictName from MstDistrict where ZoneName=@Zone"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Zone", getZone);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    drpZMArReleaseDistrict.DataSource = cmd.ExecuteReader();
                    drpZMArReleaseDistrict.DataTextField = "DistrictName";
                    drpZMArReleaseDistrict.DataValueField = "DistrictName";
                    drpZMArReleaseDistrict.DataBind();
                    drpZMArReleaseDistrict.Items.Insert(0, "--SELECT--");
                    kvdConn.Close();
                }
            }
            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                using (SqlCommand cmd = new SqlCommand("select distinct DistrictName from MstDistrict where ZoneName=@Zone"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Zone", getZone);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    drpZMSEReleaseDistrict.DataSource = cmd.ExecuteReader();
                    drpZMSEReleaseDistrict.DataTextField = "DistrictName";
                    drpZMSEReleaseDistrict.DataValueField = "DistrictName";
                    drpZMSEReleaseDistrict.DataBind();
                    drpZMSEReleaseDistrict.Items.Insert(0, "--SELECT--");
                    kvdConn.Close();
                }
            }
        }
        private void ZMReportPrintBindGrid()
        {
            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                DataSet ds = new DataSet();
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spZMPrinting", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "SEZMAPPROVED");
                cmd.Parameters.AddWithValue("@Zone", getZone);
                cmd.Parameters.AddWithValue("@District", ZMSESelectedDistrict);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    SEZMPrintApprove.DataSource = ds;
                    SEZMPrintApprove.DataBind();

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //string total = dt.Compute("Sum("+ int.Parse("LoanAmount"),"").ToString();
                    SEZMPrintApprove.FooterRow.Cells[8].Text = "Total";
                    SEZMPrintApprove.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Center;
                    SEZMPrintApprove.FooterRow.Cells[9].Text = ZMSETotalFund;
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    SEZMPrintApprove.DataSource = ds;
                    SEZMPrintApprove.DataBind();
                    int columncount = SEZMPrintApprove.Rows[0].Cells.Count;
                    SEZMPrintApprove.Rows[0].Cells.Clear();
                    SEZMPrintApprove.Rows[0].Cells.Add(new TableCell());
                    SEZMPrintApprove.Rows[0].Cells[0].ColumnSpan = columncount;
                    SEZMPrintApprove.Rows[0].Cells[0].Text = "No Records Found";
                }
            }

            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                DataSet ds = new DataSet();
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spZMPrinting", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "SEZMREJECTED");
                cmd.Parameters.AddWithValue("@Zone", getZone);
                cmd.Parameters.AddWithValue("@District", ZMSESelectedDistrict);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    SEZMPrintReject.DataSource = ds;
                    SEZMPrintReject.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    SEZMPrintReject.DataSource = ds;
                    SEZMPrintReject.DataBind();
                    int columncount = SEZMPrintReject.Rows[0].Cells.Count;
                    SEZMPrintReject.Rows[0].Cells.Clear();
                    SEZMPrintReject.Rows[0].Cells.Add(new TableCell());
                    SEZMPrintReject.Rows[0].Cells[0].ColumnSpan = columncount;
                    SEZMPrintReject.Rows[0].Cells[0].Text = "No Records Found";
                }
            }
            GetTotalCount();
           
        }
        private void ArivuCWApproveBindGrid()
        {
            string WhereClaus="";
            DataSet ds = new DataSet();
            if (ZMARYear == "Year1Loan")
            {
                WhereClaus = "AdminApprove='APPROVED' AND ZMApprove='PENDING' AND ParDistrict='" + ZMARSelectedDistrict + "'";
            }
            else
            {
                WhereClaus = "ZMApprove='APPROVED' AND ParDistrict='" + ZMARSelectedDistrict + "'";
            }
            //," + ZMARYear + " as LAmount
            string Getsql = @"SELECT *," + ZMARYear + " as LAmount,CASE WHEN BankUpdateReason IS NULL THEN 'UPDATE BANK DETAILS' ELSE 'UPDATED' END AS REASON FROM[dbo].ArivuEduLoan,MstDistrict as Dst " +
                    "WHERE "+WhereClaus+" AND Dst.ZoneName = @ZoneName and dst.DistrictName = ParDistrict " +
                    "and " + ZMARRelease + " IS " + ZMARLoanType + " NULL";
            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                //kvdConn.Open();
                if (kvdConn.State == ConnectionState.Closed)
                {
                    kvdConn.Open();
                }
                SqlCommand cmd = new SqlCommand(Getsql, kvdConn);
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("@status", "ARSELECTZM");
                cmd.Parameters.AddWithValue("@ZoneName", getZone);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ArivugvZMApprove.DataSource = ds;
                    ArivugvZMApprove.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    ArivugvZMApprove.DataSource = ds;
                    ArivugvZMApprove.DataBind();
                    int columncount = ArivugvZMApprove.Rows[0].Cells.Count;
                    ArivugvZMApprove.Rows[0].Cells.Clear();
                    ArivugvZMApprove.Rows[0].Cells.Add(new TableCell());
                    ArivugvZMApprove.Rows[0].Cells[0].ColumnSpan = columncount;
                    ArivugvZMApprove.Rows[0].Cells[0].Text = "No Records Found";
                }
            }
        }
        private void ArivuZMDisplayBindGrid()
        {
            if (ZMARSelectedDistrict != null)
            {
                using (kvdConn)
                {
                    //ZMARLoanType
                    string WhereClaus = "";
                    WhereClaus = "ZMApprove='APPROVED'";
                    string Getsql = @"SELECT *," + ZMARYear + " as LAmount FROM[dbo].ArivuEduLoan,MstDistrict as Dst " +
                        "WHERE " + WhereClaus + " AND Dst.ZoneName = @ZoneName and dst.DistrictName = ParDistrict " +
                        //"and " + ZMARRelease + " IS " + ZMARLoanType + " NULL " +
                        "  and ParDistrict=@District";
                    DataSet ds = new DataSet();
                    SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(Getsql, kvdConn);
                    cmd.CommandType = CommandType.Text;
                    //cmd.Parameters.AddWithValue("@status", "ARSELECTZM");
                    cmd.Parameters.AddWithValue("@ZoneName", getZone);
                    cmd.Parameters.AddWithValue("@District", ZMARSelectedDistrict);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    kvdConn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ARZMPrintApprove.DataSource = ds;
                        ARZMPrintApprove.DataBind();

                        ARZMPrintApprove.FooterRow.Cells[8].Text = "Total";
                        ARZMPrintApprove.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Center;
                        ARZMPrintApprove.FooterRow.Cells[9].Text = ZMARDistrictTotalFund;
                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        ARZMPrintApprove.DataSource = ds;
                        ARZMPrintApprove.DataBind();
                        int columncount = ARZMPrintApprove.Rows[0].Cells.Count;
                        ARZMPrintApprove.Rows[0].Cells.Clear();
                        ARZMPrintApprove.Rows[0].Cells.Add(new TableCell());
                        ARZMPrintApprove.Rows[0].Cells[0].ColumnSpan = columncount;
                        ARZMPrintApprove.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }

                using (kvdConn)
                {
                    string WhereClaus = "";
                    WhereClaus = "ZMApprove='REJECTED'";
                    string Getsql = @"SELECT *," + ZMARYear + " as LAmount FROM[dbo].ArivuEduLoan,MstDistrict as Dst " +
                        "WHERE " + WhereClaus + " AND Dst.ZoneName = @ZoneName and dst.DistrictName = ParDistrict ";
                        //"and " + ZMARRelease + " IS " + ZMARLoanType + " NULL";
                    DataSet ds = new DataSet();
                    SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(Getsql, kvdConn);
                    cmd.CommandType = CommandType.Text;
                    //cmd.Parameters.AddWithValue("@status", "ARSELECTZM");
                    cmd.Parameters.AddWithValue("@ZoneName", getZone);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    kvdConn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ARZMPrintReject.DataSource = ds;
                        ARZMPrintReject.DataBind();
                    }
                    else
                    {
                        //ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        //ARZMPrintReject.DataSource = ds;
                        //ARZMPrintReject.DataBind();
                        //int columncount = ARZMPrintReject.Rows[0].Cells.Count;
                        //ARZMPrintReject.Rows[0].Cells.Clear();
                        //ARZMPrintReject.Rows[0].Cells.Add(new TableCell());
                        //ARZMPrintReject.Rows[0].Cells[0].ColumnSpan = columncount;
                        //ARZMPrintReject.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
        }
        protected void btnZMArivuApprovee_Click(object sender, EventArgs e)
        {
            Button btnZM = (Button)sender;
            GridViewRow gvr = (GridViewRow)btnZM.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = ArivugvZMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            if (ZMARYear == "Year1Loan")
            {
                ZMARRelease = "Y1Release";
            }
            else if (ZMARYear == "Year2Loan")
            {
                ZMARRelease = "Y2Release";
            }
            else if (ZMARYear == "Year3Loan")
            {
                ZMARRelease = "Y3Release";
            }
            else if (ZMARYear == "Year4Loan")
            {
                ZMARRelease = "Y4Release";
            }
            else if (ZMARYear == "Year5Loan")
            {
                ZMARRelease = "Y5Release";
            }
            //spZMStatusUpdate("ARAPPROVEZM", ApplicationNumber);
            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spDMApprove", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                
                    cmd.Parameters.AddWithValue("@status", "ARAPPROVEZM");
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                
                cmd.ExecuteNonQuery();
            }
            string SQL = @" UPDATE[dbo].[ArivuEduLoan] SET "+ ZMARRelease + " = 'YES'  WHERE ApplicationNumber = @ApplicationNumber ";
            //ZMARYear;
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                cmd.Connection = kvdConn;
                kvdConn.Open();
                cmd.ExecuteScalar();
                kvdConn.Close();
            }
            string LoanNumber;
            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                using (SqlCommand cmd = new SqlCommand("SELECT ApprovedApplicationNum FROM [dbo].[ArivuEduLoan] WHERE ApplicationNumber = @ApplicationNumber"))
                {
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        LoanNumber = sdr["ApprovedApplicationNum"].ToString();
                    }
                    kvdConn.Close();
                }
            }
            string strMsg = "Loan Application Number is " + LoanNumber;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + strMsg + "')", true);

            RefreshAll();
        }
       
        protected void spZMStatusUpdate(string status, string ApplicationNumber,string Reason)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

            using (kvdConn)
            {
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spDMApprove", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (status == "ARREJECTZM")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                    cmd.Parameters.AddWithValue("@ZMRejectReason", Reason);
                }
                else if (status == "ARAPPROVEZM")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                }

                cmd.ExecuteNonQuery();
                //lblresult.ForeColor = Color.Green;
                //lblresult.Text = YearLoan1 + " details " + status.ToLower() + "d successfully";
                ArivugvZMApprove.EditIndex = -1;
                //ArivuDMApproveBindGrid();
            }
        }

        protected void btnZMCasteIncome_Click(object sender, EventArgs e)
        {
            Button btnZM = (Button)sender;
            GridViewRow gvr = (GridViewRow)btnZM.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = ArivugvZMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = ApplicationNumber + "CasteIncome.pdf";
            string sPathToSaveFileTo = filepath + filename;
            string DBFile = "DocCasteIncome";
            ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[ArivuEduLoan]");
        }

        protected void btnZMDispPH_Click(object sender, EventArgs e)
        {
            Button btnZM = (Button)sender;
            GridViewRow gvr = (GridViewRow)btnZM.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = ArivugvZMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = ApplicationNumber + "PH.pdf";
            string sPathToSaveFileTo = filepath + filename;
            string DBFile = "DocPhyCha";
            ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[ArivuEduLoan]");
        }

        protected void btnZMDispPassbook_Click(object sender, EventArgs e)
        {
            Button btnZM = (Button)sender;
            GridViewRow gvr = (GridViewRow)btnZM.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = ArivugvZMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = ApplicationNumber + "Passbook.pdf";
            string sPathToSaveFileTo = filepath + filename;
            string DBFile = "DocBankPassbook";
            ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[ArivuEduLoan]");
        }

        protected void btnZMDispCET_Click(object sender, EventArgs e)
        {
            Button btnZM = (Button)sender;
            GridViewRow gvr = (GridViewRow)btnZM.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = ArivugvZMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = ApplicationNumber + "CET.pdf";
            string sPathToSaveFileTo = filepath + filename;
            string DBFile = "DocCETAdmissionTicate";
            ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[ArivuEduLoan]");
        }

        protected void btnZMStudyCertificate_Click(object sender, EventArgs e)
        {
            Button btnZM = (Button)sender;
            GridViewRow gvr = (GridViewRow)btnZM.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = ArivugvZMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = ApplicationNumber + "StudyCertificate.pdf";
            string sPathToSaveFileTo = filepath + filename;
            string DBFile = "DocStudyCertificate";
            ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[ArivuEduLoan]");
        }

        protected void btnZMDispClgHostel_Click(object sender, EventArgs e)
        {
            Button btnZM = (Button)sender;
            GridViewRow gvr = (GridViewRow)btnZM.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = ArivugvZMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = ApplicationNumber + "ClgHostel.pdf";
            string sPathToSaveFileTo = filepath + filename;
            string DBFile = "DocCollegeHostel";
            ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[ArivuEduLoan]");
        }

        protected void btnZMFeeStruct_Click(object sender, EventArgs e)
        {
            Button btnZM = (Button)sender;
            GridViewRow gvr = (GridViewRow)btnZM.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = ArivugvZMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = ApplicationNumber + "FeeStructure.pdf";
            string sPathToSaveFileTo = filepath + filename;
            string DBFile = "DocFeesStructure";
            ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[ArivuEduLoan]");
        }

        protected void btnZMMarksCard_Click(object sender, EventArgs e)
        {
            Button btnZM = (Button)sender;
            GridViewRow gvr = (GridViewRow)btnZM.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = ArivugvZMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = ApplicationNumber + "MarksCard.pdf";
            string sPathToSaveFileTo = filepath + filename;
            string DBFile = "DocPrevMarksCard";
            ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[ArivuEduLoan]");
        }

        protected void btnZMDispAadhar_Click(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

            Button btnZM = (Button)sender;
            GridViewRow gvr = (GridViewRow)btnZM.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = ArivugvZMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename1 = ApplicationNumber + "Aadhar1.png";
            string filename2 = ApplicationNumber + "Aadhar2.png";
            string filename3 = ApplicationNumber + "Aadhar.pdf";
            string sPathToSaveFileTo1 = filepath + filename1;
            string sPathToSaveFileTo2 = filepath + filename2;
            string sPathToSaveFileTo3 = filepath + filename3;
            string DBFile = "ImgAadharFront";
            //ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[ArivuEduLoan]");
            using (kvdConn)
            {
                kvdConn.Open();
                using (SqlCommand cmd = new SqlCommand("select ImgAadharFront,ImgAadharBack from [KACDC].[dbo].[ArivuEduLoan] where [ApplicationNumber]='" + ApplicationNumber + "' ", kvdConn))
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
            Response.Redirect("Download.aspx?File=" + filename);
        }

        protected void btnZMSEDispPH_Click(object sender, EventArgs e)
        {
            Button btnZM = (Button)sender;
            GridViewRow gvr = (GridViewRow)btnZM.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = gvSEZMpprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = ApplicationNumber + "Aadhar.pdf";
            string sPathToSaveFileTo = filepath + filename;
            string DBFile = "ImgAadharFront";
            ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[SelfEmpLoan]");
        }

        protected void btnZMSECasteIncome_Click(object sender, EventArgs e)
        {
            Button btnZM = (Button)sender;
            GridViewRow gvr = (GridViewRow)btnZM.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = gvSEZMpprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = ApplicationNumber + "Aadhar.pdf";
            string sPathToSaveFileTo = filepath + filename;
            string DBFile = "DocCasteIncome";
            ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[SelfEmpLoan]");
        }

        protected void btnZMSEDispAadhar_Click(object sender, EventArgs e)
        {
            Button btnZM = (Button)sender;
            GridViewRow gvr = (GridViewRow)btnZM.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = gvSEZMpprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = ApplicationNumber + "Aadhar.pdf";
            string sPathToSaveFileTo = filepath + filename;
            string DBFile = "ImgAadharFront";
            ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[SelfEmpLoan]");
        }

        protected void btnZMSEDispPassbook_Click(object sender, EventArgs e)
        {
            Button btnZM = (Button)sender;
            GridViewRow gvr = (GridViewRow)btnZM.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = gvSEZMpprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = ApplicationNumber + "Aadhar.pdf";
            string sPathToSaveFileTo = filepath + filename;
            string DBFile = "DocBankPassbook";
            ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[SelfEmpLoan]");
        }

        protected void btnZMSEApprovee_Click(object sender, EventArgs e)
        {
            Button btnZM = (Button)sender;
            GridViewRow gvr = (GridViewRow)btnZM.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = gvSEZMpprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();

            spSEZMStatus("SEAPPROVEZM", ApplicationNumber,"");
            string LoanNumber;
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand("SELECT ApprovedApplicationNum FROM [dbo].[SelfEmpLoan] WHERE ApplicationNumber = @ApplicationNumber"))
                {
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        LoanNumber = sdr["ApprovedApplicationNum"].ToString();
                    }
                    kvdConn.Close();
                }
            }
            string strMsg = "Loan Application Number is " + LoanNumber;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + strMsg + "')", true);

            RefreshAll();
        }
        protected void btnZMSERejectUpdate_Click(object sender, EventArgs e)
        {
            if (txtZMSERejectReason.Text.Trim() != "" && txtZMSERejectReason.Text.Trim() != null)
            {
                if (txtZMSERejectReason.Text.Trim().Length > 10)
                {
                    spSEZMStatus("SEREJECTZM", lblZMSERejApplicationNumber.Text, txtZMSERejectReason.Text.Trim());
                    RefreshAll();
                }
                else
                {
                    lblZMSERejectError.Text = "Reason must be minium 10 Characters";
                    ZMSERejectPopup.Show();
                }
            }
            else
            {
                lblZMSERejectError.Text = "Enter Reason";
                ZMSERejectPopup.Show();
            }
        }
        protected void btnZMSEReject_Click(object sender, EventArgs e)
        {
            txtZMSERejectReason.Text = "";
            lblZMSERejectError.Text = "";

            Button btnZM = (Button)sender;
            GridViewRow gvr = (GridViewRow)btnZM.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblZMSERejApplicationNumber.Text = gvSEZMpprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblZMSERejApplicationName.Text = gvSEZMpprove.DataKeys[rowindex].Values["ApplicantName"].ToString();
            ZMSERejectPopup.Show();

        }
        protected void btnZMArivuReject_Click(object sender, EventArgs e)
        {
            txtZMARRejectReason.Text = "";
            lblZMARRejectError.Text = "";
            Button btnZM = (Button)sender;
            GridViewRow gvr = (GridViewRow)btnZM.NamingContainer;
            int rowindex = gvr.RowIndex;
            lblZMARRejApplicationNumber.Text = ArivugvZMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            lblZMARRejApplicationName.Text = ArivugvZMApprove.DataKeys[rowindex].Values["ApplicantName"].ToString();
            ZMARRejectPopup.Show();

        }
        protected void btnZMARRejectUpdate_Click(object sender, EventArgs e)
        {
            if (txtZMARRejectReason.Text.Trim() != "" && txtZMARRejectReason.Text.Trim() != null)
            {
                if (txtZMARRejectReason.Text.Trim().Length > 10)
                {
                    spZMStatusUpdate("ARREJECTZM", lblZMARRejApplicationNumber.Text, txtZMARRejectReason.Text.Trim());
                    RefreshAll();
                }
                else
                {
                    lblZMARRejectError.Text = "Reason must be minium 10 Characters";
                    ZMARRejectPopup.Show();
                }
            }
            else
            {
                lblZMARRejectError.Text = "Enter Reason";
                ZMARRejectPopup.Show();
            }
        }
        protected void spSEZMStatus(string status, string ApplicationNumber, string reason)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

            using (kvdConn)
            {
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spSEApprove", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (status == "SEAPPROVEZM")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                }
                else if (status == "SEREJECTZM")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                    cmd.Parameters.AddWithValue("@ZMRejectReason", reason);
                }
                else if (status == "SEZMRELEASE")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                }

                cmd.ExecuteNonQuery();
                //lblresult.ForeColor = Color.Green;
                //lblresult.Text = YearLoan1 + " details " + status.ToLower() + "d successfully";
                ArivugvZMApprove.EditIndex = -1;
                //ArivuDMApproveBindGrid();
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
        protected Paragraph getParagraph(string content, int fontSize, int Justification, int FontType, BaseColor baseColor, float IndentLeft, float IndentRight, int LineSpace)
        {
            Paragraph Paragraph = new Paragraph(LineSpace);
            Phrase Phrase = new Phrase(new Chunk(content, FontFactory.GetFont("Arial", fontSize, FontType, baseColor)));
            Paragraph.IndentationLeft = IndentLeft;
            Paragraph.IndentationRight = IndentRight;
            Paragraph.Alignment = Justification;
            Paragraph.Add(Phrase);
            return Paragraph;
        }

        protected void btnSEZM_Click(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            //PrintReportPDF("Arivu Educational Loan", "Rejected List", ArivugvDMCEORejectedList, "Arivu_Rejected_" + getDistrict + "_" + FinancialYear);

            Document pdfDoc = new Document(PageSize.A4, 0, 0, 5, 0);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            Phrase phrase = null;
            PdfPCell cell = null;
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();


            //pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan", 550f)); //Page Header          
            //DrawSingleLine(pdfDoc, writer);   //Separater Line      
            pdfDoc.Add(getParagraph("\n\n\n\n\n\n\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            //pdfDoc.Add(PrintGrid(SEZMPrintApprove, "Rejected List"));//Printing Table

            //pdfDoc.NewPage();
            //pdfDoc.Add(new Paragraph("This is Portrait Page"));
            //pdfDoc.SetPageSize(new Rectangle(1100f, 850f));
            string Subject = "Sub :- Transfer of amount to the beneficiaries \n SB Accounts through RTGF/NEFT-reg \n***************";
            Subject = Subject.Replace(Environment.NewLine, String.Empty).Replace("  ", String.Empty);
            string Block1_1 = "     We are enclosing herewith a crossed cheque bearing No ";
            string Block1_2 = " for Rs ";
            string Block1_3 = " along with the list of ";
            string Block1_4 = " beneficiaries.\n";
            string Block2_1 = "     We are request you to transferthe amount to the beneficiaries SB accounts as mentioned in the list enclosed to this letter through RTGS/NEFT transfer by debeting the amount to our SB Account Number: ";
            string Block2_2 = " Assistant General Manager K.A.C.D.C " + getZone + " Division and inform to this office in case of non transfer/failure to trasfer the amount to the beneficiaries account, the amount to be re-credited to the our SB account of the Assistant General Manager.";
            string Ty = "Thank You,";
            string YF = "Your Faithfully";
            string AgmName = "(" + "ZM Name" + ")";
            string AGM = "Assistant General Manager";



            Chunk ChunkSubject = new Chunk(Subject, FontFactory.GetFont("Arial", 14, Font.NORMAL, BaseColor.BLACK));
            Phrase PhraseSubject = new Phrase(ChunkSubject);
            Paragraph ParagraphSubject = new Paragraph(20);
            ParagraphSubject.IndentationLeft = 30f;
            ParagraphSubject.IndentationRight = 30f;
            ParagraphSubject.Alignment = Element.ALIGN_CENTER;
            ParagraphSubject.Add(PhraseSubject);

            Chunk ChunkChequeNum = new Chunk(txtSEZMChequeNumber.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
            Chunk ChunkTotalValue = new Chunk(lblSETotalSum.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
            Chunk ChunkBeneficiariesCount = new Chunk(lblSETotalApplications.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
            Chunk ChunkAccountNumber = new Chunk(ZMAccountNumber, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));

            Phrase PhraseChequeNum = new Phrase(ChunkChequeNum);

            Paragraph Paragraph1 = new Paragraph(25);
            Paragraph1.IndentationLeft = 50f;
            Paragraph1.IndentationRight = 30f;
            Paragraph1.Alignment = Element.ALIGN_JUSTIFIED;
            Paragraph1.Add(new Chunk(Block1_1, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
            Paragraph1.Add(PhraseChequeNum);
            Paragraph1.Add(new Chunk(Block1_2, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
            Paragraph1.Add(ChunkTotalValue);
            Paragraph1.Add(new Chunk(Block1_3, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
            Paragraph1.Add(ChunkBeneficiariesCount);
            Paragraph1.Add(new Chunk(Block1_4, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));

            Paragraph Paragraph2 = new Paragraph(25);
            Paragraph2.IndentationLeft = 50f;
            Paragraph2.IndentationRight = 30f;
            Paragraph2.Alignment = Element.ALIGN_JUSTIFIED;
            Paragraph1.Add(new Chunk(Block2_1, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
            Paragraph1.Add(ChunkAccountNumber);
            Paragraph1.Add(new Chunk(Block2_2, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
            //-------



            pdfDoc.NewPage();

            pdfDoc.SetPageSize(new Rectangle(1100f, 850f));
            //pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan", 550f));
            //DrawSingleLine(pdfDoc, writer);   //Separater Line   
            pdfDoc.Add(getParagraph("\n\n\n\n\n\n\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            Chunk c1 = new Chunk(txtSEZMChequeNumber.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
            //Application Report Page
            Phrase p2 = new Phrase();
            p2.Add(c1);

            //Paragraph p = new Paragraph(30);
            pdfDoc.Add(getParagraph("Date: " + DateTime.Now.ToString("dd MMMM yyyy"), 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 380f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("To,", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("The Cheif Manager,", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph(ZMBankName + ",", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph(ZMBranch + ",", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph(getZone + ".", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("Sir/Madam,", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph(Subject, 14, Element.ALIGN_CENTER, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(Paragraph1);
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(Paragraph2);
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph(Ty, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 90f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph(YF, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 385f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            //pdfDoc.Add(getParagraph(AgmName, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 400f, 30f, 20));
            //pdfDoc.Add(getParagraph(AGM, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 360f, 30f, 20));
            //pdfDoc.Add(getParagraph(Subject, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            //pdfDoc.Add(ParagraphSubject);


            //Table Page
            pdfDoc.NewPage();
            pdfDoc.SetPageSize(new Rectangle(1100f, 850f));
            pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan", 1000f, ZMSESelectedDistrict));
            DrawSingleLine(pdfDoc, writer);   //Separater Line    
            PdfPTable DataTable = PrintGrid(SEZMPrintApprove, "Approved List");
            cell = new PdfPCell(new Phrase("Total", FontFactory.GetFont("Arial", 18, Font.NORMAL, BaseColor.BLACK)));
            cell.Colspan = 9;
            cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cell.BorderWidthBottom = 2f;
            cell.BorderWidthTop = 2f;
            cell.Padding = 2f;
            cell.PaddingBottom = 5f;

            DataTable.AddCell(cell);

            PdfPTable nested = new PdfPTable(1);
            cell = new PdfPCell(new Phrase(lblSETotalSum.Text, FontFactory.GetFont("Arial", 18, Font.NORMAL, BaseColor.BLACK)));
            cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cell.BorderWidthBottom = 2f;
            cell.BorderWidthTop = 2f;
            cell.Padding = 2f;
            cell.PaddingBottom = 5f;
            nested.AddCell(cell);

            PdfPCell nesthousing = new PdfPCell(nested);

            nesthousing.Padding = 0f;

            DataTable.AddCell(nesthousing);
            pdfDoc.Add(DataTable);
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            //pdfDoc.Add(getParagraph(AgmName, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 840f, 30f, 20));
            //pdfDoc.Add(getParagraph(AGM, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 800f, 30f, 20));

            pdfDoc.Close();
            SEZMSendMail();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;" + "filename=SelfEmployment_" + getZone + "_"+ZMSESelectedDistrict+"_" + FinancialYear + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }
        protected void SEZMSendMail()
        {

            Document pdfDoc = new Document(PageSize.A4, 0, 0, 5, 0);
            Phrase phrase = null;
            PdfPCell cell = null;
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            //PdfWriter.GetInstance(pdfDoc, memoryStream);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();

                //pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan", 550f)); //Page Header          
                //DrawSingleLine(pdfDoc, writer);   //Separater Line      
                pdfDoc.Add(getParagraph("\n\n\n\n\n\n\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                //pdfDoc.Add(PrintGrid(SEZMPrintApprove, "Rejected List"));//Printing Table

                //pdfDoc.NewPage();
                //pdfDoc.Add(new Paragraph("This is Portrait Page"));
                //pdfDoc.SetPageSize(new Rectangle(1100f, 850f));
                string Subject = "Sub :- Transfer of amount to the beneficiaries \n SB Accounts through RTGF/NEFT-reg \n***************";
                Subject = Subject.Replace(Environment.NewLine, String.Empty).Replace("  ", String.Empty);
                string Block1_1 = "     We are enclosing herewith a crossed cheque bearing No ";
                string Block1_2 = " for Rs ";
                string Block1_3 = " along with the list of ";
                string Block1_4 = " beneficiaries.\n";
                string Block2_1 = "     We are request you to transferthe amount to the beneficiaries SB accounts as mentioned in the list enclosed to this letter through RTGS/NEFT transfer by debeting the amount to our SB Account Number: ";
                string Block2_2 = " Assistant General Manager K.A.C.D.C " + getZone + " Division and inform to this office in case of non transfer/failure to trasfer the amount to the beneficiaries account, the amount to be re-credited to the our SB account of the Assistant General Manager.";
                string Ty = "Thank You,";
                string YF = "Your Faithfully";
                string AgmName = "(" + "ZM Name" + ")";
                string AGM = "Assistant General Manager";



                Chunk ChunkSubject = new Chunk(Subject, FontFactory.GetFont("Arial", 14, Font.NORMAL, BaseColor.BLACK));
                Phrase PhraseSubject = new Phrase(ChunkSubject);
                Paragraph ParagraphSubject = new Paragraph(20);
                ParagraphSubject.IndentationLeft = 30f;
                ParagraphSubject.IndentationRight = 30f;
                ParagraphSubject.Alignment = Element.ALIGN_CENTER;
                ParagraphSubject.Add(PhraseSubject);

                Chunk ChunkChequeNum = new Chunk(txtSEZMChequeNumber.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
                Chunk ChunkTotalValue = new Chunk(lblSETotalSum.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
                Chunk ChunkBeneficiariesCount = new Chunk(lblSETotalApplications.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
                Chunk ChunkAccountNumber = new Chunk(ZMAccountNumber, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));

                Phrase PhraseChequeNum = new Phrase(ChunkChequeNum);

                Paragraph Paragraph1 = new Paragraph(25);
                Paragraph1.IndentationLeft = 50f;
                Paragraph1.IndentationRight = 30f;
                Paragraph1.Alignment = Element.ALIGN_JUSTIFIED;
                Paragraph1.Add(new Chunk(Block1_1, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
                Paragraph1.Add(PhraseChequeNum);
                Paragraph1.Add(new Chunk(Block1_2, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
                Paragraph1.Add(ChunkTotalValue);
                Paragraph1.Add(new Chunk(Block1_3, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
                Paragraph1.Add(ChunkBeneficiariesCount);
                Paragraph1.Add(new Chunk(Block1_4, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));

                Paragraph Paragraph2 = new Paragraph(25);
                Paragraph2.IndentationLeft = 50f;
                Paragraph2.IndentationRight = 30f;
                Paragraph2.Alignment = Element.ALIGN_JUSTIFIED;
                Paragraph1.Add(new Chunk(Block2_1, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
                Paragraph1.Add(ChunkAccountNumber);
                Paragraph1.Add(new Chunk(Block2_2, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
                //-------



                pdfDoc.NewPage();

                pdfDoc.SetPageSize(new Rectangle(1100f, 850f));
                //pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan", 550f));
                //DrawSingleLine(pdfDoc, writer);   //Separater Line   
                pdfDoc.Add(getParagraph("\n\n\n\n\n\n\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                Chunk c1 = new Chunk(txtSEZMChequeNumber.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
                //Application Report Page
                Phrase p2 = new Phrase();
                p2.Add(c1);

                //Paragraph p = new Paragraph(30);
                pdfDoc.Add(getParagraph("Date: " + DateTime.Now.ToString("dd MMMM yyyy"), 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 380f, 30f, 20));
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph("To,", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph("The Cheif Manager,", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph(ZMBankName + ",", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph(ZMBranch + ",", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph(getZone + ".", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph("Sir/Madam,", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph(Subject, 14, Element.ALIGN_CENTER, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(Paragraph1);
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(Paragraph2);
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph(Ty, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 90f, 30f, 20));
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph(YF, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 385f, 30f, 20));
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                //pdfDoc.Add(getParagraph(AgmName, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 400f, 30f, 20));
                //pdfDoc.Add(getParagraph(AGM, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 360f, 30f, 20));
                //pdfDoc.Add(getParagraph(Subject, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                //pdfDoc.Add(ParagraphSubject);


                //Table Page
                pdfDoc.NewPage();
                pdfDoc.SetPageSize(new Rectangle(1100f, 850f));
                pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan", 1000f, ZMSESelectedDistrict));
                DrawSingleLine(pdfDoc, writer);   //Separater Line    
                PdfPTable DataTable = PrintGrid(SEZMPrintApprove, "Approved List");
                cell = new PdfPCell(new Phrase("Total", FontFactory.GetFont("Arial", 18, Font.NORMAL, BaseColor.BLACK)));
                cell.Colspan = 9;
                cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cell.BorderWidthBottom = 2f;
                cell.BorderWidthTop = 2f;
                cell.Padding = 2f;
                cell.PaddingBottom = 5f;

                DataTable.AddCell(cell);

                PdfPTable nested = new PdfPTable(1);
                cell = new PdfPCell(new Phrase(lblSETotalSum.Text, FontFactory.GetFont("Arial", 18, Font.NORMAL, BaseColor.BLACK)));
                cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cell.BorderWidthBottom = 2f;
                cell.BorderWidthTop = 2f;
                cell.Padding = 2f;
                cell.PaddingBottom = 5f;
                nested.AddCell(cell);

                PdfPCell nesthousing = new PdfPCell(nested);

                nesthousing.Padding = 0f;

                DataTable.AddCell(nesthousing);
                pdfDoc.Add(DataTable);
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                //pdfDoc.Add(getParagraph(AgmName, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 840f, 30f, 20));
                //pdfDoc.Add(getParagraph(AGM, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 800f, 30f, 20));

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
                mail.Subject = "Self Employment RTGS Report : " + getZone + "_" + ZMSESelectedDistrict + " ( " + FinancialYear + " ) ";
                mail.IsBodyHtml = true;
                mail.Body = "Dear Sir/Madam <br />Please find the attachment of RTGS Report and sent same for Bank <br /><br />From  <br />Karnataka Arya Vysya Community Development Corporation <br />" + getZone;
                mail.Attachments.Add(new Attachment(new MemoryStream(bytes), "SelfEmployment_" + getZone + "_" + ZMSESelectedDistrict + "_" + FinancialYear + ".pdf"));
                SmtpServer.Send(mail);
            }
        }
        protected PdfPTable PageHeader(PdfPTable table, Phrase phrase, string LoanType, string District)
        {
            table.AddCell(AddLogo("~/Image/GOK_PDF.png", phrase, PdfPCell.ALIGN_LEFT)); //GOV Logo      
            table.AddCell(NameAddr(LoanType, FinancialYear, phrase,District, getZone, DateTime.Now.ToString("dd MMMM yyyy hh:mm tt")));//Page Heading
            table.AddCell(AddLogo("~/Image/KACDC_PDF.png", phrase, PdfPCell.ALIGN_RIGHT));//KACDC Logo   
            return table;
        }
        protected PdfPTable PrintPageHeading(Phrase phrase, string LoanName, float TableWidth,string District)
        {
            PdfPTable table = null;
            //Create Header Table
            table = new PdfPTable(3);
            table.TotalWidth = TableWidth;
            table.LockedWidth = true;
            table.SetWidths(new float[] { 0.1f, 0.7f, 0.1f });
            PageHeader(table, phrase, LoanName, District);
            return table;
        }

        protected PdfPTable PrintGrid(GridView gridView, string ListType)
        {
            //float[] columnWidths = { 1, 5, 5, 5, 5, 5, 5, 25 };
            //PdfPTable D_Table = new PdfPTable(columnWidths); 
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
            D_Table.TotalWidth = 1050f;
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
        private static PdfPCell NameAddr(string LoanName, string FinancialYear, Phrase phrase, string District,string Zone, string Date)
        {
            PdfPCell cell = null;
            phrase = new Phrase();
            phrase.Add(new Chunk("Karnataka Arya Vysya Community Development Corporation\n", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.RED)));
            phrase.Add(new Chunk("\n", FontFactory.GetFont("Arial", 5)));
            phrase.Add(new Chunk(LoanName + " ( " + FinancialYear + " )" + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
            phrase.Add(new Chunk("\n", FontFactory.GetFont("Arial", 5)));
            //phrase.Add(new Chunk("Year of: " + FinancialYear + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
            phrase.Add(new Chunk("District: " + District + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
            phrase.Add(new Chunk("\n", FontFactory.GetFont("Arial", 5)));
            phrase.Add(new Chunk("Zone: " + Zone + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
            //phrase.Add(new Chunk("Date: " + Date, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER);
            cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
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
        private DataTable GetData(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            String strConnString = System.Configuration.ConfigurationManager.
                 ConnectionStrings["myConnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            try
            {
                con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                sda.Dispose();
                con.Dispose();
            }
        }

        protected void drpArivuSelectYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZMARYear = drpArivuSelectYear.SelectedValue;
            GetTotalCount();
            RefreshAll();
        }

        protected void drpArivuReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZMARLoanType= drpArivuReleased.SelectedValue;
            GetTotalCount();
            RefreshAll();
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT CAST(SUM(CAST(" + ZMARYear + " as NUMERIC(10, 2)))AS nvarchar(20)) as SumVal FROM[dbo].ArivuEduLoan,MstDistrict as Dst " +
                    "WHERE ZMApprove = 'APPROVED' AND Dst.ZoneName = " + getZone + " and dst.DistrictName = ParDistrict " +
                    "and " + ZMARRelease + " IS " + ZMARLoanType + " NULL";
            DisplayAlert(sql,this);
        }
        private void ArivuCeoDocDownloadBindGrid()
        {
            string SQL = @"SELECT AR.Id,AR.District,AR.DateTime FROM ArivuCEODoc AR 
INNER JOIN	(SELECT MIN(ID)AS ID,CEOVerifiedDoc AS DOC FROM	ArivuCEODoc GROUP BY CEOVerifiedDoc) AS B 
ON AR.Id=b.Id AND	
AR.CEOVerifiedDoc=b.DOC
INNER JOIN MstDistrict  Md ON 
AR.District=Md.DistrictName AND md.ZoneName=@ZoneName ORDER BY AR.Id";
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@ZoneName", getZone);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    GvArivuCEODoc.DataSource = cmd.ExecuteReader();
                    GvArivuCEODoc.DataBind();
                    kvdConn.Close();
                }
            }
        }
        private void SECeoDocDownloadBindGrid()
        {
            string SQL = @"SELECT AR.Id,AR.District,AR.DateTime FROM SECEODoc AR 
INNER JOIN	(SELECT MIN(ID)AS ID,CEOVerifiedDoc AS DOC FROM	SECEODoc GROUP BY CEOVerifiedDoc) AS B 
ON AR.Id=b.Id AND	
AR.CEOVerifiedDoc=b.DOC
INNER JOIN MstDistrict  Md ON 
AR.District=Md.DistrictName AND md.ZoneName=@ZoneName ORDER BY AR.Id";
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@ZoneName", getZone);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    GvSECEODoc.DataSource = cmd.ExecuteReader();
                    GvSECEODoc.DataBind();
                    kvdConn.Close();
                }
            }
        }
        protected void lnkbtnArivuCEODoc_Click(object sender, EventArgs e)
        {
            int id = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select District, CEOVerifiedDoc from ArivuCEODoc where Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["CEOVerifiedDoc"];
                        contentType = "application/pdf";
                        fileName = "Arivu_" + sdr["District"].ToString();
                    }
                    kvdConn.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName + ".pdf");
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
        protected void lnkbtnSECEODoc_Click(object sender, EventArgs e)
        {
            int id = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select District, CEOVerifiedDoc from SECEODoc where Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["CEOVerifiedDoc"];
                        contentType = "application/pdf";
                        fileName = "SelfEmployment_" + sdr["District"].ToString();
                    }
                    kvdConn.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName + ".pdf");
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
        //Bank Details Update
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
        protected void btnUpdateBankAR_Click(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            if (txtApplicantNameAR.Text.Trim() != "" && txtAccountNumberAR.Text.Trim() != "" && txtBankNameAR.Text.Trim() != "" && txtIFSCCodeAR.Text.Trim() != "" &&
                  txtBankAddrAR.Text.Trim() != "" && txtBranchAR.Text.Trim() != "")
            {
                if (ApplicationNumberAR != "")
                {
                    using (kvdConn)
                    {
                        if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                        SqlCommand cmd = new SqlCommand("UpdateBankDetails", kvdConn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (ApplicationNumberAR != "") //todo
                        {
                            if (drpARReasonBankModify.SelectedValue != "")
                            {
                                cmd.Parameters.AddWithValue("@AccountNumber", txtAccountNumberAR.Text);
                                cmd.Parameters.AddWithValue("@BankName", txtBankNameAR.Text);
                                cmd.Parameters.AddWithValue("@IFSCCode", txtIFSCCodeAR.Text);
                                cmd.Parameters.AddWithValue("@BankAddress", txtBankAddrAR.Text);
                                cmd.Parameters.AddWithValue("@Branch", txtBranchAR.Text);
                                cmd.Parameters.AddWithValue("@Reason", drpARReasonBankModify.SelectedValue);
                                cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumberAR);
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
                                lblApplicationNumberAR.Text = ApplicationNumberAR + " Updated";
                                //lblApplicationNumberAR.CssClass = "text-primary";
                                btnUpdateBankAR.Enabled = false;
                                btnUpdateBankAR.CssClass = "Button";
                            }
                            else
                            {
                                lblApplicationNumberAR.Text = ApplicationNumberAR + " Select Reason";
                            }
                        }

                        RefreshAll();
                    }
                }
            }
            else
            {
                lblApplicationNumberAR.Text = ApplicationNumberAR + " Fill All Details";
            }
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
        protected void btnUpdateBankSE_Click(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            if (txtApplicantNameSE.Text.Trim() != "" && txtAccountNumberSE.Text.Trim() != "" && txtBankNameSE.Text.Trim() != "" && txtIFSCCodeSE.Text.Trim() != "" &&
                  txtBankAddrSE.Text.Trim() != "" && txtBranchSE.Text.Trim() != "")
            {
                if (ApplicationNumberSE != "")
                {
                    using (kvdConn)
                    {
                        if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                        SqlCommand cmd = new SqlCommand("UpdateBankDetails", kvdConn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (ApplicationNumberSE != "") //todo
                        {
                            if (drpSEReasonBankModify.SelectedValue != "")
                            {
                                cmd.Parameters.AddWithValue("@AccountNumber", txtAccountNumberSE.Text);
                                cmd.Parameters.AddWithValue("@BankName", txtBankNameSE.Text);
                                cmd.Parameters.AddWithValue("@IFSCCode", txtIFSCCodeSE.Text);
                                cmd.Parameters.AddWithValue("@BankAddress", txtBankAddrSE.Text);
                                cmd.Parameters.AddWithValue("@Branch", txtBranchSE.Text);
                                cmd.Parameters.AddWithValue("@Reason", drpSEReasonBankModify.SelectedValue);
                                cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumberSE);
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
                                lblApplicationNumberSE.Text = ApplicationNumberSE + " Updated";
                                //lblApplicationNumberSE.CssClass = "text-primary";
                                btnUpdateBankSE.Enabled = false;
                                btnUpdateBankSE.CssClass = "Button";


                            }
                            else
                            {
                                lblApplicationNumberSE.Text = ApplicationNumberSE + " Select Reason";
                            }
                        }
                        RefreshAll();
                    }
                }
            }
            else
            {
                lblApplicationNumberSE.Text = ApplicationNumberSE + " Fill All Details";
            }
        }
        protected void btnGVUpdateBankSE_Click(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            //lblApplicationNumberSE.CssClass.Replace( "text-primary","");
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            ApplicationNumberSE = gvSEZMpprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            if (ApplicationNumberSE != "")
            {
                using (kvdConn)
                {
                    if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                    SqlDataAdapter DAcmd = new SqlDataAdapter("SELECT ApplicantName,BankName,Branch,AccountNumber,IFSCCode,BankAddress FROM SelfEmpLoan WHERE ApplicationNumber= @AppnNumber", kvdConn);
                    DAcmd.SelectCommand.Parameters.AddWithValue("@AppnNumber", ApplicationNumberSE);
                    DataTable dt = new DataTable();
                    DAcmd.Fill(dt);

                    txtApplicantNameSE.Text = dt.Rows[0]["ApplicantName"].ToString();
                    txtAccountNumberSE.Text = dt.Rows[0]["AccountNumber"].ToString();
                    txtBankNameSE.Text = dt.Rows[0]["BankName"].ToString();
                    txtIFSCCodeSE.Text = dt.Rows[0]["IFSCCode"].ToString();
                    txtBankAddrSE.Text = dt.Rows[0]["BankAddress"].ToString();
                    txtBranchSE.Text = dt.Rows[0]["Branch"].ToString();
                    lblApplicationNumberSE.Text = ApplicationNumberSE;

                    btnUpdateBankSE.Enabled = true;
                    //txtApplicantNameSE.Enabled = false;
                    kvdConn.Close();
                    //this.RefreshAll();
                }

            }
        }
        protected void btnGVUpdateBankAR_Click(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            //lblApplicationNumberAR.CssClass.Replace( "text-primary","");
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            ApplicationNumberAR = ArivugvZMApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            if (ApplicationNumberAR != "")
            {
                using (kvdConn)
                {
                    if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                    SqlDataAdapter DAcmd = new SqlDataAdapter("SELECT ApplicantName,BankName,Branch,AccountNumber,IFSCCode,BankAddress FROM ArivuEduLoan WHERE ApplicationNumber= @AppnNumber", kvdConn);
                    DAcmd.SelectCommand.Parameters.AddWithValue("@AppnNumber", ApplicationNumberAR);
                    DataTable dt = new DataTable();
                    DAcmd.Fill(dt);

                    txtApplicantNameAR.Text = dt.Rows[0]["ApplicantName"].ToString();
                    txtAccountNumberAR.Text = dt.Rows[0]["AccountNumber"].ToString();
                    txtBankNameAR.Text = dt.Rows[0]["BankName"].ToString();
                    txtIFSCCodeAR.Text = dt.Rows[0]["IFSCCode"].ToString();
                    txtBankAddrAR.Text = dt.Rows[0]["BankAddress"].ToString();
                    txtBranchAR.Text = dt.Rows[0]["Branch"].ToString();
                    lblApplicationNumberAR.Text = ApplicationNumberAR;

                    btnUpdateBankAR.Enabled = true;
                    //txtApplicantNameAR.Enabled = false;
                    kvdConn.Close();
                    RefreshAll();
                }

            }
        }

        protected void drpSEDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZMSESelectedDistrict = drpSEDistrict.SelectedValue;
            GetTotalCount();
            ZMReportPrintBindGrid();
            drpFillBank();
            RefreshAll();
        }

        protected void drpArivuDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZMARSelectedDistrict = drpArivuDistrict.SelectedValue;
            GetTotalCount();
            ArivuZMDisplayBindGrid();
            RefreshAll();
        }

        protected void btnARZM_Click(object sender, EventArgs e)
        {

            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            //PrintReportPDF("Arivu Educational Loan", "Rejected List", ArivugvDMCEORejectedList, "Arivu_Rejected_" + getDistrict + "_" + FinancialYear);

            Document pdfDoc = new Document(PageSize.A4, 0, 0, 5, 0);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            Phrase phrase = null;
            PdfPCell cell = null;
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();


            //pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan", 550f)); //Page Header          
            //DrawSingleLine(pdfDoc, writer);   //Separater Line        
            //pdfDoc.Add(PrintGrid(SEZMPrintApprove, "Rejected List"));//Printing Table

            //pdfDoc.NewPage();
            //pdfDoc.Add(new Paragraph("This is Portrait Page"));
            //pdfDoc.SetPageSize(new Rectangle(1100f, 850f));
            string Subject = "Sub :- Transfer of amount to the beneficiaries \n SB Accounts through RTGF/NEFT-reg \n***************";
            Subject = Subject.Replace(Environment.NewLine, String.Empty).Replace("  ", String.Empty);
            string Block1_1 = "     We are enclosing herewith a crossed cheque bearing No ";
            string Block1_2 = " for Rs ";
            string Block1_3 = " along with the list of ";
            string Block1_4 = " beneficiaries.\n";
            string Block2_1 = "     We are request you to transferthe amount to the beneficiaries SB accounts as mentioned in the list enclosed to this letter through RTGS/NEFT transfer by debeting the amount to our SB Account Number: ";
            string Block2_2 = " Assistant General Manager K.A.C.D.C " + getZone + " Division and inform to this office in case of non transfer/failure to trasfer the amount to the beneficiaries account, the amount to be re-credited to the our SB account of the Assistant General Manager.";
            string Ty = "Thank You,";
            string YF = "Your Faithfully";
            string AgmName = "(" + "ZM Name" + ")";
            string AGM = "Assistant General Manager";



            Chunk ChunkSubject = new Chunk(Subject, FontFactory.GetFont("Arial", 14, Font.NORMAL, BaseColor.BLACK));
            Phrase PhraseSubject = new Phrase(ChunkSubject);
            Paragraph ParagraphSubject = new Paragraph(20);
            ParagraphSubject.IndentationLeft = 30f;
            ParagraphSubject.IndentationRight = 30f;
            ParagraphSubject.Alignment = Element.ALIGN_CENTER;
            ParagraphSubject.Add(PhraseSubject);

            Chunk ChunkChequeNum = new Chunk(txtARZMChequeNumber.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
            Chunk ChunkTotalValue = new Chunk(lblZMARDistrictApplicationTotal.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
            Chunk ChunkBeneficiariesCount = new Chunk(lblZMARDistrictApplicationCount.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
            Chunk ChunkAccountNumber = new Chunk(ZMAccountNumber, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));

            Phrase PhraseChequeNum = new Phrase(ChunkChequeNum);

            Paragraph Paragraph1 = new Paragraph(25);
            Paragraph1.IndentationLeft = 50f;
            Paragraph1.IndentationRight = 30f;
            Paragraph1.Alignment = Element.ALIGN_JUSTIFIED;
            Paragraph1.Add(new Chunk(Block1_1, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
            Paragraph1.Add(PhraseChequeNum);
            Paragraph1.Add(new Chunk(Block1_2, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
            Paragraph1.Add(ChunkTotalValue);
            Paragraph1.Add(new Chunk(Block1_3, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
            Paragraph1.Add(ChunkBeneficiariesCount);
            Paragraph1.Add(new Chunk(Block1_4, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));

            Paragraph Paragraph2 = new Paragraph(25);
            Paragraph2.IndentationLeft = 50f;
            Paragraph2.IndentationRight = 30f;
            Paragraph2.Alignment = Element.ALIGN_JUSTIFIED;
            Paragraph1.Add(new Chunk(Block2_1, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
            Paragraph1.Add(ChunkAccountNumber);
            Paragraph1.Add(new Chunk(Block2_2, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
            //-------



            pdfDoc.NewPage();

            pdfDoc.SetPageSize(new Rectangle(1100f, 850f));
            //First Page Header
            //pdfDoc.Add(PrintPageHeading(phrase, "Arivu Educational Loan", 550f));
            pdfDoc.Add(getParagraph("\n\n\n\n\n\n\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            //DrawSingleLine(pdfDoc, writer);   //Separater Line   
            Chunk c1 = new Chunk(txtARZMChequeNumber.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
            //Application Report Page
            Phrase p2 = new Phrase();
            p2.Add(c1);

            //Paragraph p = new Paragraph(30);
            pdfDoc.Add(getParagraph("Date: " + DateTime.Now.ToString("dd MMMM yyyy"), 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 380f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("To,", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("The Cheif Manager,", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph(ZMBankName + ",", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph(ZMBranch + ",", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph(getZone + ".", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("Sir/Madam,", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph(Subject, 14, Element.ALIGN_CENTER, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(Paragraph1);
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(Paragraph2);
            pdfDoc.Add(getParagraph("\n", 5, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph(Ty, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 90f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 5, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph(YF, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 385f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            //pdfDoc.Add(getParagraph(AgmName, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 400f, 30f, 20));
            //pdfDoc.Add(getParagraph(AGM, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 360f, 30f, 20));
            //pdfDoc.Add(getParagraph(Subject, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            //pdfDoc.Add(ParagraphSubject);


            //Table Page
            pdfDoc.NewPage();
            pdfDoc.SetPageSize(new Rectangle(1100f, 850f));
            pdfDoc.Add(PrintPageHeading(phrase, "Arivu Education Loan", 1000f, ZMARSelectedDistrict));
            DrawSingleLine(pdfDoc, writer);   //Separater Line    
            PdfPTable DataTable = PrintGrid(ARZMPrintApprove, "Approved List");
            cell = new PdfPCell(new Phrase("Total", FontFactory.GetFont("Arial", 18, Font.NORMAL, BaseColor.BLACK)));
            cell.Colspan = 9;
            cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cell.BorderWidthBottom = 2f;
            cell.BorderWidthTop = 2f;
            cell.Padding = 2f;
            cell.PaddingBottom = 5f;

            DataTable.AddCell(cell);

            PdfPTable nested = new PdfPTable(1);
            cell = new PdfPCell(new Phrase(lblZMARDistrictApplicationTotal.Text, FontFactory.GetFont("Arial", 18, Font.NORMAL, BaseColor.BLACK)));
            cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cell.BorderWidthBottom = 2f;
            cell.BorderWidthTop = 2f;
            cell.Padding = 2f;
            cell.PaddingBottom = 5f;
            nested.AddCell(cell);

            PdfPCell nesthousing = new PdfPCell(nested);

            nesthousing.Padding = 0f;

            DataTable.AddCell(nesthousing);
            pdfDoc.Add(DataTable);
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            //pdfDoc.Add(getParagraph(AgmName, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 840f, 30f, 20));
            //pdfDoc.Add(getParagraph(AGM, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 800f, 30f, 20));

            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;" + "filename=Arivu_" + getZone + "_"+ZMARSelectedDistrict+"_" + FinancialYear + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }
        private void ArivuGvReleaseBindGrid()
        {
            string WhereClaus = "";
            
            if (ZMARYearRelease == "Year1Loan")
            {
                ZMARRelease = "Y1Release";
            }
            else if (ZMARYearRelease == "Year2Loan")
            {
                ZMARRelease = "Y2Release";
            }
            else if (ZMARYearRelease == "Year3Loan")
            {
                ZMARRelease = "Y3Release";
            }
            else if (ZMARYearRelease == "Year4Loan")
            {
                ZMARRelease = "Y4Release";
            }
            else if (ZMARYearRelease == "Year5Loan")
            {
                ZMARRelease = "Y5Release";
            }

            if (ZMARYearRelease == "Year1Loan")
            {
                WhereClaus = " ZMApprove='APPROVED' AND ParDistrict='" + ZMARSelectedReleaseDistrict + "'";
            }
            else
            {
                WhereClaus = "ZMApprove='APPROVED' AND ParDistrict='" + ZMARSelectedReleaseDistrict + "'";
            }
            if (ZMARYearRelease == null)
            {
                ZMARYearRelease = "Year1Loan";
            }
            string Getsql = @"SELECT ApplicationNumber,ApprovedApplicationNum,ApplicantName,BankName,BankAddress,AccountNumber,IFSCCode,Branch,MobileNumber,AadharNum, "+ ZMARYearRelease + " as LAmount "+
                       ",CASE WHEN BankUpdateReason IS NULL THEN 'UPDATE BANK DETAILS' ELSE 'UPDATED' END AS REASON FROM[dbo].ArivuEduLoan,MstDistrict as Dst " +
                       "WHERE " + WhereClaus + " AND Dst.ZoneName = @ZoneName and dst.DistrictName = ParDistrict " +
                       "and " + ZMARRelease + " = 'YES'";
            //Disply Grid
            using (kvdConn)
            {
                DataSet ds = new DataSet();
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                //kvdConn.Open();
                if (kvdConn.State == ConnectionState.Closed)
                {
                    kvdConn.Open();
                }
                SqlCommand cmd = new SqlCommand(Getsql, kvdConn);
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("@status", "ARSELECTZM");
                cmd.Parameters.AddWithValue("@ZoneName", getZone);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvZMArRelease.DataSource = ds;
                    gvZMArRelease.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    gvZMArRelease.DataSource = ds;
                    gvZMArRelease.DataBind();
                    int columncount = gvZMArRelease.Rows[0].Cells.Count;
                    gvZMArRelease.Rows[0].Cells.Clear();
                    gvZMArRelease.Rows[0].Cells.Add(new TableCell());
                    gvZMArRelease.Rows[0].Cells[0].ColumnSpan = columncount;
                    gvZMArRelease.Rows[0].Cells[0].Text = "No Records Found";
                }
            }


            //Print Grid
            
            using (kvdConn)
            {
                DataSet ds = new DataSet();
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                //kvdConn.Open();
                if (kvdConn.State == ConnectionState.Closed)
                {
                    kvdConn.Open();
                }
                SqlCommand cmd = new SqlCommand(Getsql, kvdConn);
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("@status", "ARSELECTZM");
                cmd.Parameters.AddWithValue("@ZoneName", getZone);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ARZMPrintRelease.DataSource = ds;
                    ARZMPrintRelease.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    ARZMPrintRelease.DataSource = ds;
                    ARZMPrintRelease.DataBind();
                    int columncount = ARZMPrintRelease.Rows[0].Cells.Count;
                    ARZMPrintRelease.Rows[0].Cells.Clear();
                    ARZMPrintRelease.Rows[0].Cells.Add(new TableCell());
                    ARZMPrintRelease.Rows[0].Cells[0].ColumnSpan = columncount;
                    ARZMPrintRelease.Rows[0].Cells[0].Text = "No Records Found";
                }
            }

            if (ZMARYearRelease == null)
            {
                ZMARYearRelease = "Year1Loan";
            }
            string Sumsql = @"SELECT CAST(SUM(CAST(" + ZMARYearRelease + " as NUMERIC(10, 2)))AS nvarchar(20)) as SumVal FROM[dbo].ArivuEduLoan " +
                    "WHERE ZMApprove = 'APPROVED' and  ParDistrict =@SelDistrict " + "and " + ZMARRelease + " = 'YES'"+
                    "";
            using (SqlCommand cmd = new SqlCommand(Sumsql))
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@SelDistrict", ZMARSelectedReleaseDistrict);
                cmd.Connection = kvdConn;
                kvdConn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    lblPendingRTGS.Text = sdr["SumVal"].ToString();
                }
                kvdConn.Close();
            }

            string Countsql = @"SELECT COUNT(" + ZMARYearRelease + ") as CountVal FROM[dbo].ArivuEduLoan " +
                    "WHERE ZMApprove = 'APPROVED' and  ParDistrict =@SelDistrict " + "and " + ZMARRelease + " = 'YES'" +
                    "";
            using (SqlCommand cmd = new SqlCommand(Countsql))
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@SelDistrict", ZMARSelectedReleaseDistrict);
                cmd.Connection = kvdConn;
                kvdConn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    lblPendingRTGSCount.Text = sdr["CountVal"].ToString();
                }
                kvdConn.Close();
            }
        }
        protected void btnZMArivuReleased_Click(object sender, EventArgs e)
        {
            if (ZMARYearRelease == "Year1Loan")
            {
                ZMARRelease = "Y1Release";
            }
            else if (ZMARYearRelease == "Year2Loan")
            {
                ZMARRelease = "Y2Release";
            }
            else if (ZMARYearRelease == "Year3Loan")
            {
                ZMARRelease = "Y3Release";
            }
            else if (ZMARYearRelease == "Year4Loan")
            {
                ZMARRelease = "Y4Release";
            }
            else if (ZMARYearRelease == "Year5Loan")
            {
                ZMARRelease = "Y5Release";
            }
            //lblApplicationNumberReleaseAR.CssClass.Replace( "text-primary","");
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string AppNum = gvZMArRelease.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            string UpdateString = "UPDATE ArivuEduLoan SET "+ ZMARRelease + " ='RELEASED' WHERE ApplicationNumber=@ApplicationNumber";
            using (SqlCommand cmd = new SqlCommand(UpdateString))
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ApplicationNumber", AppNum);
                cmd.Connection = kvdConn;
                kvdConn.Open();
                cmd.ExecuteNonQuery();
                kvdConn.Close();
            }
            this.ArivuGvReleaseBindGrid();
        }

        protected void btnUpdateBankReleaseAR_Click(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            if (txtApplicantNameReleaseAR.Text.Trim() != "" && txtAccountNumberReleaseAR.Text.Trim() != "" && txtBankNameReleaseAR.Text.Trim() != "" && txtIFSCCodeReleaseAR.Text.Trim() != "" &&
                  txtBankAddrReleaseAR.Text.Trim() != "" && txtBranchReleaseAR.Text.Trim() != "")
            {
                if (ApplicationNumberAR != "")
                {
                    using (kvdConn)
                    {
                        if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                        SqlCommand cmd = new SqlCommand("UpdateBankDetails", kvdConn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (ApplicationNumberAR != "") //todo
                        {
                            if (drpReasonBankModifyReleaseAR.SelectedValue != "")
                            {
                                cmd.Parameters.AddWithValue("@AccountNumber", txtAccountNumberReleaseAR.Text.Trim());
                                cmd.Parameters.AddWithValue("@BankName", txtBankNameReleaseAR.Text.Trim());
                                cmd.Parameters.AddWithValue("@IFSCCode", txtIFSCCodeReleaseAR.Text.Trim());
                                cmd.Parameters.AddWithValue("@BankAddress", txtBankAddrReleaseAR.Text.Trim());
                                cmd.Parameters.AddWithValue("@Branch", txtBranchReleaseAR.Text.Trim());
                                cmd.Parameters.AddWithValue("@Reason", drpReasonBankModifyReleaseAR.SelectedValue);
                                cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumberReleaseAR);
                                cmd.Parameters.AddWithValue("@ApplicantName", txtApplicantNameReleaseAR.Text.Trim());
                                cmd.Parameters.AddWithValue("@UpdatingTable", "Arivu");
                                cmd.ExecuteNonQuery();

                                lblApplicationNumberReleaseAR.Text = "";
                                txtBankAddrReleaseAR.Text = "";
                                txtIFSCCodeReleaseAR.Text = "";
                                txtBranchReleaseAR.Text = "";
                                txtBankNameReleaseAR.Text = "";
                                txtAccountNumberReleaseAR.Text = "";
                                txtApplicantNameReleaseAR.Text = "";
                                lblApplicationNumberReleaseAR.Text = ApplicationNumberReleaseAR + " Updated";
                                //lblApplicationNumberAR.CssClass = "text-primary";
                                btnUpdateBankReleaseAR.Enabled = false;
                                btnUpdateBankReleaseAR.CssClass = "Button";
                                drpReasonBankModifyReleaseAR.SelectedIndex = 0;
                                ArivuGvReleaseBindGrid();
                            }
                            else
                            {
                                lblApplicationNumberReleaseAR.Text = ApplicationNumberReleaseAR + " Select Reason";
                            }
                        }

                        RefreshAll();
                    }
                }
            }
            else
            {
                lblApplicationNumberAR.Text = ApplicationNumberAR + " Fill All Details";
            }
        }

        protected void btnClearReleaseAR_Click(object sender, EventArgs e)
        {
            lblApplicationNumberReleaseAR.Text = "";
            txtBankAddrReleaseAR.Text = "";
            txtIFSCCodeReleaseAR.Text = "";
            txtBranchReleaseAR.Text = "";
            txtBankNameReleaseAR.Text = "";
            txtAccountNumberReleaseAR.Text = "";
            txtApplicantNameReleaseAR.Text = "";
            lblApplicationNumberReleaseAR.Text = "";
            btnUpdateBankReleaseAR.Enabled = false;
            btnUpdateBankReleaseAR.CssClass = "Button";           
        }

        protected void btnGVUpdateBankReleaseAR_Click(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            //lblApplicationNumberReleaseAR.CssClass.Replace( "text-primary","");
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            ApplicationNumberReleaseAR = gvZMArRelease.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            if (ApplicationNumberReleaseAR != "")
            {
                using (kvdConn)
                {
                    if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                    SqlDataAdapter DAcmd = new SqlDataAdapter("SELECT ApplicantName,BankName,Branch,AccountNumber,IFSCCode,BankAddress FROM ArivuEduLoan WHERE ApplicationNumber= @AppnNumber", kvdConn);
                    DAcmd.SelectCommand.Parameters.AddWithValue("@AppnNumber", ApplicationNumberReleaseAR);
                    DataTable dt = new DataTable();
                    DAcmd.Fill(dt);

                    txtApplicantNameReleaseAR.Text = dt.Rows[0]["ApplicantName"].ToString();
                    txtAccountNumberReleaseAR.Text = dt.Rows[0]["AccountNumber"].ToString();
                    txtBankNameReleaseAR.Text = dt.Rows[0]["BankName"].ToString();
                    txtIFSCCodeReleaseAR.Text = dt.Rows[0]["IFSCCode"].ToString();
                    txtBankAddrReleaseAR.Text = dt.Rows[0]["BankAddress"].ToString();
                    txtBranchReleaseAR.Text = dt.Rows[0]["Branch"].ToString();
                    lblApplicationNumberReleaseAR.Text = ApplicationNumberReleaseAR;

                    btnUpdateBankReleaseAR.Enabled = true;
                    //txtApplicantNameAR.Enabled = false;
                    kvdConn.Close();
                    RefreshAll();
                }
            }
        }

        protected void drpZMArReleaseDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZMARSelectedReleaseDistrict = drpZMArReleaseDistrict.SelectedValue;
            //GetTotalCount();
            ArivuGvReleaseBindGrid();
            //RefreshAll();
        }

        protected void drpArivuSelectYearRelease_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZMARYearRelease = drpArivuSelectYear.SelectedValue;
            //GetTotalCount();
            ArivuGvReleaseBindGrid();
        }

        protected void btnPrintRelease_Click(object sender, EventArgs e)
        {


            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            //PrintReportPDF("Arivu Educational Loan", "Rejected List", ArivugvDMCEORejectedList, "Arivu_Rejected_" + getDistrict + "_" + FinancialYear);

            Document pdfDoc = new Document(PageSize.A4, 0, 0, 5, 0);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            Phrase phrase = null;
            PdfPCell cell = null;
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();


            //pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan", 550f)); //Page Header          
            //DrawSingleLine(pdfDoc, writer);   //Separater Line        
            //pdfDoc.Add(PrintGrid(SEZMPrintApprove, "Rejected List"));//Printing Table

            //pdfDoc.NewPage();
            //pdfDoc.Add(new Paragraph("This is Portrait Page"));
            //pdfDoc.SetPageSize(new Rectangle(1100f, 850f));
            string Subject = "Sub :- Transfer of amount to the beneficiaries \n SB Accounts through RTGF/NEFT-reg \n***************";
            Subject = Subject.Replace(Environment.NewLine, String.Empty).Replace("  ", String.Empty);
            string Block1_1 = "     We are enclosing herewith a crossed cheque bearing No ";
            string Block1_2 = " for Rs ";
            string Block1_3 = " along with the list of ";
            string Block1_4 = " beneficiaries.\n";
            string Block2_1 = "     We are request you to transferthe amount to the beneficiaries SB accounts as mentioned in the list enclosed to this letter through RTGS/NEFT transfer by debeting the amount to our SB Account Number: ";
            string Block2_2 = " Assistant General Manager K.A.C.D.C " + getZone + " Division and inform to this office in case of non transfer/failure to trasfer the amount to the beneficiaries account, the amount to be re-credited to the our SB account of the Assistant General Manager.";
            string Ty = "Thank You,";
            string YF = "Your Faithfully";
            string AgmName = "(" + "ZM Name" + ")";
            string AGM = "Assistant General Manager";



            Chunk ChunkSubject = new Chunk(Subject, FontFactory.GetFont("Arial", 14, Font.NORMAL, BaseColor.BLACK));
            Phrase PhraseSubject = new Phrase(ChunkSubject);
            Paragraph ParagraphSubject = new Paragraph(20);
            ParagraphSubject.IndentationLeft = 30f;
            ParagraphSubject.IndentationRight = 30f;
            ParagraphSubject.Alignment = Element.ALIGN_CENTER;
            ParagraphSubject.Add(PhraseSubject);

            Chunk ChunkChequeNum = new Chunk(txtReleaseChequeNumber.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
            Chunk ChunkTotalValue = new Chunk(lblPendingRTGS.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
            Chunk ChunkBeneficiariesCount = new Chunk(lblPendingRTGSCount.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
            Chunk ChunkAccountNumber = new Chunk(ZMAccountNumber, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));

            Phrase PhraseChequeNum = new Phrase(ChunkChequeNum);

            Paragraph Paragraph1 = new Paragraph(25);
            Paragraph1.IndentationLeft = 50f;
            Paragraph1.IndentationRight = 30f;
            Paragraph1.Alignment = Element.ALIGN_JUSTIFIED;
            Paragraph1.Add(new Chunk(Block1_1, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
            Paragraph1.Add(PhraseChequeNum);
            Paragraph1.Add(new Chunk(Block1_2, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
            Paragraph1.Add(ChunkTotalValue);
            Paragraph1.Add(new Chunk(Block1_3, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
            Paragraph1.Add(ChunkBeneficiariesCount);
            Paragraph1.Add(new Chunk(Block1_4, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));

            Paragraph Paragraph2 = new Paragraph(25);
            Paragraph2.IndentationLeft = 50f;
            Paragraph2.IndentationRight = 30f;
            Paragraph2.Alignment = Element.ALIGN_JUSTIFIED;
            Paragraph1.Add(new Chunk(Block2_1, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
            Paragraph1.Add(ChunkAccountNumber);
            Paragraph1.Add(new Chunk(Block2_2, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
            //-------



            pdfDoc.NewPage();

            pdfDoc.SetPageSize(new Rectangle(1100f, 850f));
            //First Page Header
            //pdfDoc.Add(PrintPageHeading(phrase, "Arivu Educational Loan", 550f));
            pdfDoc.Add(getParagraph("\n\n\n\n\n\n\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            //DrawSingleLine(pdfDoc, writer);   //Separater Line   
            Chunk c1 = new Chunk(txtARZMChequeNumber.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
            //Application Report Page
            Phrase p2 = new Phrase();
            p2.Add(c1);

            //Paragraph p = new Paragraph(30);
            pdfDoc.Add(getParagraph("Date: " + DateTime.Now.ToString("dd MMMM yyyy"), 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 380f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("To,", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("The Cheif Manager,", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph(ZMBankName + ",", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph(ZMBranch + ",", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph(getZone + ".", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("Sir/Madam,", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph(Subject, 14, Element.ALIGN_CENTER, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(Paragraph1);
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(Paragraph2);
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph(Ty, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 90f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph(YF, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 385f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            //pdfDoc.Add(getParagraph(AgmName, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 400f, 30f, 20));
            //pdfDoc.Add(getParagraph(AGM, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 360f, 30f, 20));
            //pdfDoc.Add(getParagraph(Subject, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            //pdfDoc.Add(ParagraphSubject);


            //Table Page
            pdfDoc.NewPage();
            pdfDoc.SetPageSize(new Rectangle(1100f, 850f));
            pdfDoc.Add(PrintPageHeading(phrase, "Arivu Education Loan", 1000f, ZMARSelectedDistrict));
            DrawSingleLine(pdfDoc, writer);   //Separater Line    
            PdfPTable DataTable = PrintGrid(ARZMPrintRelease, "Approved List");
            cell = new PdfPCell(new Phrase("Total", FontFactory.GetFont("Arial", 18, Font.NORMAL, BaseColor.BLACK)));
            cell.Colspan = 9;
            cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cell.BorderWidthBottom = 2f;
            cell.BorderWidthTop = 2f;
            cell.Padding = 2f;
            cell.PaddingBottom = 5f;

            DataTable.AddCell(cell);

            PdfPTable nested = new PdfPTable(1);
            cell = new PdfPCell(new Phrase(lblPendingRTGS.Text, FontFactory.GetFont("Arial", 18, Font.NORMAL, BaseColor.BLACK)));
            cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cell.BorderWidthBottom = 2f;
            cell.BorderWidthTop = 2f;
            cell.Padding = 2f;
            cell.PaddingBottom = 5f;
            nested.AddCell(cell);

            PdfPCell nesthousing = new PdfPCell(nested);

            nesthousing.Padding = 0f;

            DataTable.AddCell(nesthousing);
            pdfDoc.Add(DataTable);
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            //pdfDoc.Add(getParagraph(AgmName, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 840f, 30f, 20));
            //pdfDoc.Add(getParagraph(AGM, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 800f, 30f, 20));

            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;" + "filename=Arivu_" + getZone + "_" + ZMARSelectedDistrict + "_" + FinancialYear + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }

        private void SegvReleaseBindGrid()
        {
            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                DataSet ds = new DataSet();
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spSEApprove", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "SESELECTRELEASE");
                cmd.Parameters.AddWithValue("@Zone", getZone);
                cmd.Parameters.AddWithValue("@District", ZMSESelectedReleaseDistrict);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvZMSERelease.DataSource = ds;
                    gvZMSERelease.DataBind();

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    gvZMSERelease.DataSource = ds;
                    gvZMSERelease.DataBind();
                    int columncount = gvZMSERelease.Rows[0].Cells.Count;
                    gvZMSERelease.Rows[0].Cells.Clear();
                    gvZMSERelease.Rows[0].Cells.Add(new TableCell());
                    gvZMSERelease.Rows[0].Cells[0].ColumnSpan = columncount;
                    gvZMSERelease.Rows[0].Cells[0].Text = "No Records Found";
                }

            }
            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                DataSet ds = new DataSet();
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spSEApprove", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "SESELECTRELEASE");
                cmd.Parameters.AddWithValue("@Zone", getZone);
                cmd.Parameters.AddWithValue("@District", ZMSESelectedReleaseDistrict);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvZMPrintSERelease.DataSource = ds;
                    gvZMPrintSERelease.DataBind();

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    gvZMPrintSERelease.DataSource = ds;
                    gvZMPrintSERelease.DataBind();
                    int columncount = gvZMPrintSERelease.Rows[0].Cells.Count;
                    gvZMPrintSERelease.Rows[0].Cells.Clear();
                    gvZMPrintSERelease.Rows[0].Cells.Add(new TableCell());
                    gvZMPrintSERelease.Rows[0].Cells[0].ColumnSpan = columncount;
                    gvZMPrintSERelease.Rows[0].Cells[0].Text = "No Records Found";
                }
            }
            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                DataSet ds = new DataSet();
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spZMPrinting", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", "SEZMARELEASECount");
                cmd.Parameters.AddWithValue("@Zone", getZone);
                cmd.Parameters.AddWithValue("@District", ZMSESelectedReleaseDistrict);
                cmd.Parameters.Add("@RCount", SqlDbType.VarChar, -1);
                cmd.Parameters["@RCount"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@RTotal", SqlDbType.VarChar, -1);
                cmd.Parameters["@RTotal"].Direction = ParameterDirection.Output;
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();
                lblSEPendingRTGS.Text = cmd.Parameters["@RTotal"].Value.ToString();
                lblSEPendingRTGSCount.Text = cmd.Parameters["@RCount"].Value.ToString();
                
            }
        }
        protected void btnUpdateBankReleaseSE_Click(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            if (txtApplicantNameReleaseSE.Text.Trim() != "" && txtAccountNumberReleaseSE.Text.Trim() != "" && txtBankNameReleaseSE.Text.Trim() != "" && txtIFSCCodeReleaseSE.Text.Trim() != "" &&
                  txtBankAddrReleaseSE.Text.Trim() != "" && txtBranchReleaseSE.Text.Trim() != "")
            {
                if (ApplicationNumberReleaseSE != "")
                {
                    using (kvdConn)
                    {
                        if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                        SqlCommand cmd = new SqlCommand("UpdateBankDetails", kvdConn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (ApplicationNumberReleaseSE != "") //todo
                        {
                            if (drpReasonBankModifyReleaseSE.SelectedValue != "")
                            {
                                cmd.Parameters.AddWithValue("@AccountNumber", txtAccountNumberReleaseSE.Text.Trim());
                                cmd.Parameters.AddWithValue("@BankName", txtBankNameReleaseSE.Text.Trim());
                                cmd.Parameters.AddWithValue("@IFSCCode", txtIFSCCodeReleaseSE.Text.Trim());
                                cmd.Parameters.AddWithValue("@BankAddress", txtBankAddrReleaseSE.Text.Trim());
                                cmd.Parameters.AddWithValue("@Branch", txtBranchReleaseSE.Text.Trim());
                                cmd.Parameters.AddWithValue("@Reason", drpReasonBankModifyReleaseSE.SelectedValue);
                                cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumberReleaseSE);
                                cmd.Parameters.AddWithValue("@ApplicantName", txtApplicantNameReleaseSE.Text.Trim());
                                cmd.Parameters.AddWithValue("@UpdatingTable", "SE");
                                cmd.ExecuteNonQuery();

                                lblApplicationNumberReleaseSE.Text = "";
                                txtBankAddrReleaseSE.Text = "";
                                txtIFSCCodeReleaseSE.Text = "";
                                txtBranchReleaseSE.Text = "";
                                txtBankNameReleaseSE.Text = "";
                                txtAccountNumberReleaseSE.Text = "";
                                txtApplicantNameReleaseSE.Text = "";
                                lblApplicationNumberReleaseSE.Text = ApplicationNumberReleaseSE + " Updated";
                                //lblApplicationNumberReleaseSE.CssClass = "text-primary";
                                btnUpdateBankReleaseSE.Enabled = false;
                                btnUpdateBankReleaseSE.CssClass = "Button";
                                this.SegvReleaseBindGrid();
                            }
                            else
                            {
                                lblApplicationNumberReleaseSE.Text = ApplicationNumberReleaseSE + " Select Reason";
                            }
                        }
                        
                    }
                }
            }
            else
            {
                lblApplicationNumberReleaseSE.Text = ApplicationNumberReleaseSE + " Fill All Details";
            }
        }

        protected void btnClearSEReleaseSE_Click(object sender, EventArgs e)
        {
            lblApplicationNumberReleaseSE.Text = "";
            txtBankAddrReleaseSE.Text = "";
            txtIFSCCodeReleaseSE.Text = "";
            txtBranchReleaseSE.Text = "";
            txtBankNameReleaseSE.Text = "";
            txtAccountNumberReleaseSE.Text = "";
            txtApplicantNameReleaseSE.Text = "";
            lblApplicationNumberReleaseSE.Text = "";
            btnUpdateBankReleaseSE.Enabled = false;
            btnUpdateBankReleaseSE.CssClass = "Button";
        }

        protected void btnGVUpdateBankReleaseSE_Click(object sender, EventArgs e)
        {

            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            //lblApplicationNumberReleaseSE.CssClass.Replace( "text-primary","");
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            ApplicationNumberReleaseSE = gvZMSERelease.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            if (ApplicationNumberReleaseSE != "")
            {
                using (kvdConn)
                {
                    if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                    SqlDataAdapter DAcmd = new SqlDataAdapter("SELECT ApplicantName,BankName,Branch,AccountNumber,IFSCCode,BankAddress FROM SelfEmpLoan WHERE ApplicationNumber= @AppnNumber", kvdConn);
                    DAcmd.SelectCommand.Parameters.AddWithValue("@AppnNumber", ApplicationNumberReleaseSE);
                    DataTable dt = new DataTable();
                    DAcmd.Fill(dt);

                    txtApplicantNameReleaseSE.Text = dt.Rows[0]["ApplicantName"].ToString();
                    txtAccountNumberReleaseSE.Text = dt.Rows[0]["AccountNumber"].ToString();
                    txtBankNameReleaseSE.Text = dt.Rows[0]["BankName"].ToString();
                    txtIFSCCodeReleaseSE.Text = dt.Rows[0]["IFSCCode"].ToString();
                    txtBankAddrReleaseSE.Text = dt.Rows[0]["BankAddress"].ToString();
                    txtBranchReleaseSE.Text = dt.Rows[0]["Branch"].ToString();
                    lblApplicationNumberReleaseSE.Text = ApplicationNumberReleaseSE;

                    btnUpdateBankReleaseSE.Enabled = true;
                    //txtApplicantNameSE.Enabled = false;
                    kvdConn.Close();
                    //this.RefreshAll();
                }

            }
        }

        protected void btnSEPrintRelease_Click(object sender, EventArgs e)
        {

            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            //PrintReportPDF("Arivu Educational Loan", "Rejected List", ArivugvDMCEORejectedList, "Arivu_Rejected_" + getDistrict + "_" + FinancialYear);

            Document pdfDoc = new Document(PageSize.A4, 0, 0, 5, 0);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            Phrase phrase = null;
            PdfPCell cell = null;
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();


            //pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan", 550f)); //Page Header          
            //DrawSingleLine(pdfDoc, writer);   //Separater Line        
            //pdfDoc.Add(PrintGrid(SEZMPrintApprove, "Rejected List"));//Printing Table

            //pdfDoc.NewPage();
            //pdfDoc.Add(new Paragraph("This is Portrait Page"));
            //pdfDoc.SetPageSize(new Rectangle(1100f, 850f));
            string Subject = "Sub :- Transfer of amount to the beneficiaries \n SB Accounts through RTGF/NEFT-reg \n***************";
            Subject = Subject.Replace(Environment.NewLine, String.Empty).Replace("  ", String.Empty);
            string Block1_1 = "     We are enclosing herewith a crossed cheque bearing No ";
            string Block1_2 = " for Rs ";
            string Block1_3 = " along with the list of ";
            string Block1_4 = " beneficiaries.\n";
            string Block2_1 = "     We are request you to transferthe amount to the beneficiaries SB accounts as mentioned in the list enclosed to this letter through RTGS/NEFT transfer by debeting the amount to our SB Account Number: ";
            string Block2_2 = " Assistant General Manager K.A.C.D.C " + getZone + " Division and inform to this office in case of non transfer/failure to trasfer the amount to the beneficiaries account, the amount to be re-credited to the our SB account of the Assistant General Manager.";
            string Ty = "Thank You,";
            string YF = "Your Faithfully";
            string AgmName = "(" + "ZM Name" + ")";
            string AGM = "Assistant General Manager";



            Chunk ChunkSubject = new Chunk(Subject, FontFactory.GetFont("Arial", 14, Font.NORMAL, BaseColor.BLACK));
            Phrase PhraseSubject = new Phrase(ChunkSubject);
            Paragraph ParagraphSubject = new Paragraph(20);
            ParagraphSubject.IndentationLeft = 30f;
            ParagraphSubject.IndentationRight = 30f;
            ParagraphSubject.Alignment = Element.ALIGN_CENTER;
            ParagraphSubject.Add(PhraseSubject);

            Chunk ChunkChequeNum = new Chunk(txtSEReleaseChequeNumber.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
            Chunk ChunkTotalValue = new Chunk(lblSEPendingRTGS.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
            Chunk ChunkBeneficiariesCount = new Chunk(lblSEPendingRTGSCount.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
            Chunk ChunkAccountNumber = new Chunk(ZMAccountNumber, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));

            Phrase PhraseChequeNum = new Phrase(ChunkChequeNum);

            Paragraph Paragraph1 = new Paragraph(25);
            Paragraph1.IndentationLeft = 50f;
            Paragraph1.IndentationRight = 30f;
            Paragraph1.Alignment = Element.ALIGN_JUSTIFIED;
            Paragraph1.Add(new Chunk(Block1_1, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
            Paragraph1.Add(PhraseChequeNum);
            Paragraph1.Add(new Chunk(Block1_2, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
            Paragraph1.Add(ChunkTotalValue);
            Paragraph1.Add(new Chunk(Block1_3, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
            Paragraph1.Add(ChunkBeneficiariesCount);
            Paragraph1.Add(new Chunk(Block1_4, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));

            Paragraph Paragraph2 = new Paragraph(25);
            Paragraph2.IndentationLeft = 50f;
            Paragraph2.IndentationRight = 30f;
            Paragraph2.Alignment = Element.ALIGN_JUSTIFIED;
            Paragraph1.Add(new Chunk(Block2_1, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
            Paragraph1.Add(ChunkAccountNumber);
            Paragraph1.Add(new Chunk(Block2_2, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
            //-------



            pdfDoc.NewPage();

            pdfDoc.SetPageSize(new Rectangle(1100f, 850f));
            //pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan", 550f));
            //DrawSingleLine(pdfDoc, writer);   //Separater Line   
            pdfDoc.Add(getParagraph("\n\n\n\n\n\n\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            Chunk c1 = new Chunk(txtSEZMChequeNumber.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
            //Application Report Page
            Phrase p2 = new Phrase();
            p2.Add(c1);

            //Paragraph p = new Paragraph(30);
            pdfDoc.Add(getParagraph("Date: " + DateTime.Now.ToString("dd MMMM yyyy"), 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 380f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("To,", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("The Cheif Manager,", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph(ZMBankName + ",", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph(ZMBranch + ",", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph(getZone + ".", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("Sir/Madam,", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph(Subject, 14, Element.ALIGN_CENTER, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(Paragraph1);
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(Paragraph2);
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph(Ty, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 90f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph(YF, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 385f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            //pdfDoc.Add(getParagraph(AgmName, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 400f, 30f, 20));
            //pdfDoc.Add(getParagraph(AGM, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 360f, 30f, 20));
            //pdfDoc.Add(getParagraph(Subject, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            //pdfDoc.Add(ParagraphSubject);


            //Table Page
            pdfDoc.NewPage();
            pdfDoc.SetPageSize(new Rectangle(1100f, 850f));
            pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan", 1000f, ZMSESelectedDistrict));
            DrawSingleLine(pdfDoc, writer);   //Separater Line    
            PdfPTable DataTable = PrintGrid(gvZMPrintSERelease, "Approved List");
            cell = new PdfPCell(new Phrase("Total", FontFactory.GetFont("Arial", 18, Font.NORMAL, BaseColor.BLACK)));
            cell.Colspan = 9;
            cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cell.BorderWidthBottom = 2f;
            cell.BorderWidthTop = 2f;
            cell.Padding = 2f;
            cell.PaddingBottom = 5f;

            DataTable.AddCell(cell);

            PdfPTable nested = new PdfPTable(1);
            cell = new PdfPCell(new Phrase(lblSEPendingRTGS.Text, FontFactory.GetFont("Arial", 18, Font.NORMAL, BaseColor.BLACK)));
            cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cell.BorderWidthBottom = 2f;
            cell.BorderWidthTop = 2f;
            cell.Padding = 2f;
            cell.PaddingBottom = 5f;
            nested.AddCell(cell);

            PdfPCell nesthousing = new PdfPCell(nested);

            nesthousing.Padding = 0f;

            DataTable.AddCell(nesthousing);
            pdfDoc.Add(DataTable);
            pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
            //pdfDoc.Add(getParagraph(AgmName, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 840f, 30f, 20));
            //pdfDoc.Add(getParagraph(AGM, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 800f, 30f, 20));

            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;" + "filename=SelfEmployment_" + getZone + "_" + ZMSESelectedReleaseDistrict + "_" + FinancialYear + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }

        protected void btnZMSEReleased_Click(object sender, EventArgs e)
        {
            Button btnZM = (Button)sender;
            GridViewRow gvr = (GridViewRow)btnZM.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = gvZMSERelease.DataKeys[rowindex].Values["ApplicationNumber"].ToString();

            spSEZMStatus("SEZMRELEASE", ApplicationNumber, "");
            this.SegvReleaseBindGrid();
            this.ZMReportPrintBindGrid();
        }

        protected void drpZMSEReleaseDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZMSESelectedReleaseDistrict = drpZMSEReleaseDistrict.SelectedValue;
            this.SegvReleaseBindGrid();
        }

        protected void btnZMArivuPrintReject_Click(object sender, EventArgs e)
        {
            if (ZMARSelectedDistrict != null)
            {

                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                //PrintReportPDF("Arivu Educational Loan", "Rejected List", ArivugvDMCEORejectedList, "Arivu_Rejected_" + getDistrict + "_" + FinancialYear);

                Document pdfDoc = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                Phrase phrase = null;
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                pdfDoc.Add(PrintPageHeading(phrase, "Arivu Education Loan", 550f, ZMARSelectedDistrict));  //Page Header          
                DrawSingleLine(pdfDoc, writer);   //Separater Line        
                pdfDoc.Add(RejectPrintGrid(ARZMPrintReject, "Rejected List"));//Printing Table
                pdfDoc.Close();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;" + "filename=Arivu_Rejected_" + ZMARSelectedDistrict + "_" + FinancialYear + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "Select District" + "')", true);

            }
        }

        protected void btnZMSEPrintReject_Click(object sender, EventArgs e)
        {

            if (ZMSESelectedDistrict != null)
            {

                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                //PrintReportPDF("Arivu Educational Loan", "Rejected List", ArivugvDMCEORejectedList, "Arivu_Rejected_" + getDistrict + "_" + FinancialYear);

                Document pdfDoc = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                Phrase phrase = null;
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                //pdfDoc.NewPage();
                //pdfDoc.SetPageSize(new Rectangle(1100f, 850f));
                pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan", 550f, ZMSESelectedDistrict));  //Page Header  
                DrawSingleLine(pdfDoc, writer);   //Separater Line        
                PdfPTable DataTable = RejectPrintGrid(SEZMPrintReject, "Rejected List");//Printing Table
                pdfDoc.Add(DataTable);
                pdfDoc.Close();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;" + "filename=SelfEmployment_Rejected_" + ZMSESelectedDistrict + "_" + FinancialYear + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "Select District" + "')", true);

            }
        }
        protected PdfPTable RejectPrintGrid(GridView gridView, string ListType)
        {
            PdfPTable D_Table = null;
            int ColCount = gridView.Columns.Count;
            ZM_Form zf = new ZM_Form();
            int[] widths = new int[gridView.Columns.Count];
            D_Table = RejectCreatePdfTable(D_Table, ColCount); //Assign Table Properties                  
            D_Table.AddCell(TableHeader(ListType, ColCount)); //Table Heading
            ColumHeader(gridView, D_Table, widths);//Table Colum Header
            FillTableData(gridView, D_Table);//Table Data
            return D_Table;
        }
        private static PdfPTable RejectCreatePdfTable(PdfPTable D_Table, int ColCount)
        {
            D_Table = new PdfPTable(ColCount);
            D_Table.TotalWidth = 550f;
            D_Table.LockedWidth = true;
            //D_Table.SetWidths(new float[] { 0.1f, 0.2f, 0.1f });
            D_Table.SpacingBefore = 20;
            D_Table.SpacingAfter = 30f;
            return D_Table;
        }

        protected void btnARZMExportExcel_Click(object sender, EventArgs e)
        {
            
            if (ZMARSelectedDistrict != null)
            {
                Response.Clear();
                Response.Buffer = true;

                Response.AddHeader("content-disposition", "attachment;filename=Arivu_"+ ZMARSelectedDistrict + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                ARZMPrintApprove.AllowPaging = false;
                //ARZMPrintApprove.DataBind();

                //Change the Header Row back to white color
                ARZMPrintApprove.HeaderRow.Style.Add("background-color", "#FFFFFF");
                int columnCount = ARZMPrintApprove.Columns.Count;
                int ColCount = 10;
                //Apply style to Individual Cells
                //ARZMPrintApprove.HeaderRow.Cells[0].Style.Add("background-color", "green");
                //ARZMPrintApprove.HeaderRow.Cells[1].Style.Add("background-color", "green");
                //ARZMPrintApprove.HeaderRow.Cells[2].Style.Add("background-color", "green");
                //ARZMPrintApprove.HeaderRow.Cells[3].Style.Add("background-color", "green");
                //for (int i = 0; i < ColCount; i++)
                //{
                //    ARZMPrintApprove.HeaderRow.Cells[i].Style.Add("background-color", "green");
                //}

                for (int i = 0; i < ARZMPrintApprove.Rows.Count; i++)
                {
                    GridViewRow row = ARZMPrintApprove.Rows[i];

                    //Change Color back to white
                    row.BackColor = System.Drawing.Color.White;

                    //Apply text style to each Row
                    row.Attributes.Add("class", "textmode");

                    //Apply style to Individual Cells of Alternating Row

                    //row.Cells[2].Text = "abc";
                    //row.Cells[2].Attributes.Add("class", "number");
                    row.Cells[2].Attributes.CssStyle.Add("mso-number-format", "\\@");
                    row.Cells[5].Attributes.CssStyle.Add("mso-number-format", "\\@");
                    //row.Cells[0].Style.Add("background-color", "#C2D69B");
                    //row.Cells[1].Style.Add("background-color", "#C2D69B");
                    //row.Cells[2].Style.Add("background-color", "#C2D69B");
                    //row.Cells[3].Style.Add("background-color", "#C2D69B");

                }
                ARZMPrintApprove.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
                //    Response.Clear();
                //Response.Buffer = true;
                //Response.ContentType = "application/vnd.ms-excel";
                //Response.AddHeader("content-disposition", "attachment;filename=Arivu_"+ ZMARSelectedDistrict + ".xls");
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);

                //StringWriter swr = new StringWriter();
                //HtmlTextWriter htmlwr = new HtmlTextWriter(swr);
                //ARZMPrintApprove.AllowPaging = false;
                //ARZMPrintApprove.RenderControl(htmlwr);
                //Response.Output.Write(swr.ToString());
                //Response.Flush();
                //Response.End();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "Select District" + "')", true);

            }
        }

        protected void btnSEZMExportExcel_Click(object sender, EventArgs e)
        {
            if (ZMSESelectedDistrict != null)
            {

                Response.Clear();
                Response.Buffer = true;

                Response.AddHeader("content-disposition", "attachment;filename=SelfEmployment" + ZMSESelectedDistrict + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                SEZMPrintApprove.AllowPaging = false;
                //SEZMPrintApprove.DataBind();

                //Change the Header Row back to white color
                SEZMPrintApprove.HeaderRow.Style.Add("background-color", "#FFFFFF");
                int columnCount = SEZMPrintApprove.Columns.Count;
                int ColCount = 10;
                //Apply style to Individual Cells
                //SEZMPrintApprove.HeaderRow.Cells[0].Style.Add("background-color", "green");
                //SEZMPrintApprove.HeaderRow.Cells[1].Style.Add("background-color", "green");
                //SEZMPrintApprove.HeaderRow.Cells[2].Style.Add("background-color", "green");
                //SEZMPrintApprove.HeaderRow.Cells[3].Style.Add("background-color", "green");
                //for (int i = 0; i < ColCount; i++)
                //{
                //    SEZMPrintApprove.HeaderRow.Cells[i].Style.Add("background-color", "green");
                //}

                for (int i = 0; i < SEZMPrintApprove.Rows.Count; i++)
                {
                    GridViewRow row = SEZMPrintApprove.Rows[i];

                    //Change Color back to white
                    row.BackColor = System.Drawing.Color.White;

                    //Apply text style to each Row
                    row.Attributes.Add("class", "textmode");

                    //Apply style to Individual Cells of Alternating Row

                    //row.Cells[2].Text = "abc";
                    //row.Cells[2].Attributes.Add("class", "number");
                    row.Cells[2].Attributes.CssStyle.Add("mso-number-format", "\\@");
                    row.Cells[5].Attributes.CssStyle.Add("mso-number-format", "\\@");
                    //row.Cells[0].Style.Add("background-color", "#C2D69B");
                    //row.Cells[1].Style.Add("background-color", "#C2D69B");
                    //row.Cells[2].Style.Add("background-color", "#C2D69B");
                    //row.Cells[3].Style.Add("background-color", "#C2D69B");

                }
                SEZMPrintApprove.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
                //---------------------------
                //Response.Clear();
                //Response.Buffer = true;
                //Response.ContentType = "application/vnd.ms-excel";
                //Response.AddHeader("content-disposition", "attachment;filename=SelfEmployment" + ZMSESelectedDistrict + ".xls");
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);

                //StringWriter swr = new StringWriter();
                //HtmlTextWriter htmlwr = new HtmlTextWriter(swr);
                //SEZMPrintApprove.AllowPaging = false;
                //SEZMPrintApprove.RenderControl(htmlwr);
                //Response.Output.Write(swr.ToString());
                //Response.Flush();
                //Response.End();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "Select District" + "')", true);

            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        
        protected void drpZMSEPrintBankType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZMSEBankDifferType = drpZMSEPrintBankType.SelectedValue;
            ZMSEBankDifferBindGrid();
            drpFillBank();
            btnZMSEBankDifferChequeNumber.Text = "";
            lblBankDifferTotal.Text = "";
            lblBankDifferCount.Text = "";
        }

        protected void drpZMSEPrintBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZMSEBankDifferBank = drpZMSEPrintBank.SelectedValue;
            ZMSEBankDifferBindGrid();
            //ZMSESelectedDistrict = drpSEDistrict.SelectedValue;
            //GetTotalCount();
            //ZMReportPrintBindGrid();
            //RefreshAll();
        }
        protected void ZMSEBankDifferBindGrid()
        {
            if (ZMSESelectedDistrict != null)
            {
                if (ZMSEBankDifferBank != null && ZMSEBankDifferType != null)
                {
                    using (kvdConn)
                    {
                        SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                        DataSet ds = new DataSet();
                        if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                        SqlCommand cmd = new SqlCommand("spZMPrinting", kvdConn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (ZMSEBankDifferType == "Only")
                        {
                            cmd.Parameters.AddWithValue("@status", "SEZMABankDifferCount");
                        }
                        else if (ZMSEBankDifferType == "Except")
                        {
                            cmd.Parameters.AddWithValue("@status", "SEZMABankDifferCountNotLike");
                        }
                        cmd.Parameters.AddWithValue("@Zone", getZone);
                        cmd.Parameters.AddWithValue("@District", ZMSESelectedDistrict);
                        cmd.Parameters.AddWithValue("@Bank", ZMSEBankDifferBank);
                        cmd.Parameters.Add("@DifferCount", SqlDbType.VarChar, -1);
                        cmd.Parameters["@DifferCount"].Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@DifferTotal", SqlDbType.VarChar, -1);
                        cmd.Parameters["@DifferTotal"].Direction = ParameterDirection.Output;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        kvdConn.Close();
                        lblBankDifferCount.Text = cmd.Parameters["@DifferCount"].Value.ToString();
                        lblBankDifferTotal.Text = cmd.Parameters["@DifferTotal"].Value.ToString();
                    }
                    using (kvdConn)
                    {
                        SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                        DataSet ds = new DataSet();
                        if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                        SqlCommand cmd = new SqlCommand("spZMPrinting", kvdConn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (ZMSEBankDifferType== "Only")
                        {
                            cmd.Parameters.AddWithValue("@status", "SEZMAPPROVEDBankDifferLike");
                        }
                        else if (ZMSEBankDifferType == "Except")
                        {
                            cmd.Parameters.AddWithValue("@status", "SEZMAPPROVEDBankDifferNotLike");
                        }
                        else if (ZMSEBankDifferType == "")
                        {
                            cmd.Parameters.AddWithValue("@status", "SEZMAPPROVEDBankDifferAll");
                        }
                        cmd.Parameters.AddWithValue("@Zone", getZone);
                        cmd.Parameters.AddWithValue("@District", ZMSESelectedDistrict);
                        cmd.Parameters.AddWithValue("@Bank", ZMSEBankDifferBank);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        kvdConn.Close();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            gvZMSEBankDifferApproved.DataSource = ds;
                            gvZMSEBankDifferApproved.DataBind();

                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            //string total = dt.Compute("Sum("+ int.Parse("LoanAmount"),"").ToString();
                            gvZMSEBankDifferApproved.FooterRow.Cells[8].Text = "Total";
                            gvZMSEBankDifferApproved.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Center;
                            gvZMSEBankDifferApproved.FooterRow.Cells[9].Text = lblBankDifferTotal.Text;
                        }
                        else
                        {
                            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                            gvZMSEBankDifferApproved.DataSource = ds;
                            gvZMSEBankDifferApproved.DataBind();
                            int columncount = gvZMSEBankDifferApproved.Rows[0].Cells.Count;
                            gvZMSEBankDifferApproved.Rows[0].Cells.Clear();
                            gvZMSEBankDifferApproved.Rows[0].Cells.Add(new TableCell());
                            gvZMSEBankDifferApproved.Rows[0].Cells[0].ColumnSpan = columncount;
                            gvZMSEBankDifferApproved.Rows[0].Cells[0].Text = "No Records Found";
                        }
                    }
                    
                }
            }
            else
            {
                DisplayAlert("Select District", this);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "Select District" + "')", true);
            }
        }
        protected void drpFillBank()
        {
            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                using (SqlCommand cmd = new SqlCommand("select distinct BankName from SelfEmpLoan where ParDistrict=@District and ZMApprove='APPROVED' and ApplicationStatus='PENDING'"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@District", ZMSESelectedDistrict);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    drpZMSEPrintBank.DataSource = cmd.ExecuteReader();
                    drpZMSEPrintBank.DataTextField = "BankName";
                    drpZMSEPrintBank.DataValueField = "BankName";
                    drpZMSEPrintBank.DataBind();
                    drpZMSEPrintBank.Items.Insert(0, "--SELECT--");
                    kvdConn.Close();
                }
            }
        }

        protected void btnZMSEBankDifferProceedtoPaymentPDF_Click(object sender, EventArgs e)
        {
            if (btnZMSEBankDifferChequeNumber.Text != "")
            {

                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                //PrintReportPDF("Arivu Educational Loan", "Rejected List", ArivugvDMCEORejectedList, "Arivu_Rejected_" + getDistrict + "_" + FinancialYear);

                Document pdfDoc = new Document(PageSize.A4, 0, 0, 5, 0);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                Phrase phrase = null;
                PdfPCell cell = null;
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();


                //pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan", 550f)); //Page Header          
                //DrawSingleLine(pdfDoc, writer);   //Separater Line      
                pdfDoc.Add(getParagraph("\n\n\n\n\n\n\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                //pdfDoc.Add(PrintGrid(SEZMPrintApprove, "Rejected List"));//Printing Table

                //pdfDoc.NewPage();
                //pdfDoc.Add(new Paragraph("This is Portrait Page"));
                //pdfDoc.SetPageSize(new Rectangle(1100f, 850f));
                string Subject = "Sub :- Transfer of amount to the beneficiaries \n SB Accounts through RTGF/NEFT-reg \n***************";
                Subject = Subject.Replace(Environment.NewLine, String.Empty).Replace("  ", String.Empty);
                string Block1_1 = "     We are enclosing herewith a crossed cheque bearing No ";
                string Block1_2 = " for Rs ";
                string Block1_3 = " along with the list of ";
                string Block1_4 = " beneficiaries.\n";
                string Block2_1 = "     We are request you to transferthe amount to the beneficiaries SB accounts as mentioned in the list enclosed to this letter through RTGS/NEFT transfer by debeting the amount to our SB Account Number: ";
                string Block2_2 = " Assistant General Manager K.A.C.D.C " + getZone + " Division and inform to this office in case of non transfer/failure to trasfer the amount to the beneficiaries account, the amount to be re-credited to the our SB account of the Assistant General Manager.";
                string Ty = "Thank You,";
                string YF = "Your Faithfully";
                string AgmName = "(" + "ZM Name" + ")";
                string AGM = "Assistant General Manager";



                Chunk ChunkSubject = new Chunk(Subject, FontFactory.GetFont("Arial", 14, Font.NORMAL, BaseColor.BLACK));
                Phrase PhraseSubject = new Phrase(ChunkSubject);
                Paragraph ParagraphSubject = new Paragraph(20);
                ParagraphSubject.IndentationLeft = 30f;
                ParagraphSubject.IndentationRight = 30f;
                ParagraphSubject.Alignment = Element.ALIGN_CENTER;
                ParagraphSubject.Add(PhraseSubject);

                Chunk ChunkChequeNum = new Chunk(btnZMSEBankDifferChequeNumber.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
                Chunk ChunkTotalValue = new Chunk(lblBankDifferTotal.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
                Chunk ChunkBeneficiariesCount = new Chunk(lblBankDifferCount.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
                Chunk ChunkAccountNumber = new Chunk(ZMAccountNumber, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));

                Phrase PhraseChequeNum = new Phrase(ChunkChequeNum);

                Paragraph Paragraph1 = new Paragraph(25);
                Paragraph1.IndentationLeft = 50f;
                Paragraph1.IndentationRight = 30f;
                Paragraph1.Alignment = Element.ALIGN_JUSTIFIED;
                Paragraph1.Add(new Chunk(Block1_1, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
                Paragraph1.Add(PhraseChequeNum);
                Paragraph1.Add(new Chunk(Block1_2, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
                Paragraph1.Add(ChunkTotalValue);
                Paragraph1.Add(new Chunk(Block1_3, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
                Paragraph1.Add(ChunkBeneficiariesCount);
                Paragraph1.Add(new Chunk(Block1_4, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));

                Paragraph Paragraph2 = new Paragraph(25);
                Paragraph2.IndentationLeft = 50f;
                Paragraph2.IndentationRight = 30f;
                Paragraph2.Alignment = Element.ALIGN_JUSTIFIED;
                Paragraph1.Add(new Chunk(Block2_1, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
                Paragraph1.Add(ChunkAccountNumber);
                Paragraph1.Add(new Chunk(Block2_2, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
                //-------



                pdfDoc.NewPage();

                pdfDoc.SetPageSize(new Rectangle(1100f, 850f));
                //pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan", 550f));
                //DrawSingleLine(pdfDoc, writer);   //Separater Line   
                pdfDoc.Add(getParagraph("\n\n\n\n\n\n\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                Chunk c1 = new Chunk(btnZMSEBankDifferChequeNumber.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
                //Application Report Page
                Phrase p2 = new Phrase();
                p2.Add(c1);

                //Paragraph p = new Paragraph(30);
                pdfDoc.Add(getParagraph("Date: " + DateTime.Now.ToString("dd MMMM yyyy"), 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 380f, 30f, 20));
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph("To,", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph("The Cheif Manager,", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph(ZMBankName + ",", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph(ZMBranch + ",", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph(getZone + ".", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph("Sir/Madam,", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph(Subject, 14, Element.ALIGN_CENTER, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(Paragraph1);
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(Paragraph2);
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph(Ty, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 90f, 30f, 20));
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph(YF, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 385f, 30f, 20));
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                //pdfDoc.Add(getParagraph(AgmName, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 400f, 30f, 20));
                //pdfDoc.Add(getParagraph(AGM, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 360f, 30f, 20));
                //pdfDoc.Add(getParagraph(Subject, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                //pdfDoc.Add(ParagraphSubject);


                //Table Page
                pdfDoc.NewPage();
                pdfDoc.SetPageSize(new Rectangle(1100f, 850f));
                pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan", 1000f, ZMSESelectedDistrict));
                DrawSingleLine(pdfDoc, writer);   //Separater Line    
                PdfPTable DataTable = PrintGrid(gvZMSEBankDifferApproved, "Approved List");
                cell = new PdfPCell(new Phrase("Total", FontFactory.GetFont("Arial", 18, Font.NORMAL, BaseColor.BLACK)));
                cell.Colspan = 9;
                cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cell.BorderWidthBottom = 2f;
                cell.BorderWidthTop = 2f;
                cell.Padding = 2f;
                cell.PaddingBottom = 5f;

                DataTable.AddCell(cell);

                PdfPTable nested = new PdfPTable(1);
                cell = new PdfPCell(new Phrase(lblBankDifferTotal.Text, FontFactory.GetFont("Arial", 18, Font.NORMAL, BaseColor.BLACK)));
                cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cell.BorderWidthBottom = 2f;
                cell.BorderWidthTop = 2f;
                cell.Padding = 2f;
                cell.PaddingBottom = 5f;
                nested.AddCell(cell);

                PdfPCell nesthousing = new PdfPCell(nested);

                nesthousing.Padding = 0f;

                DataTable.AddCell(nesthousing);
                pdfDoc.Add(DataTable);
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                //pdfDoc.Add(getParagraph(AgmName, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 840f, 30f, 20));
                //pdfDoc.Add(getParagraph(AGM, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 800f, 30f, 20));

                pdfDoc.Close();
                SEZMBankDifferSendMail();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;" + "filename=SelfEmployment_" + getZone + "_" + ZMSESelectedDistrict + "_" + FinancialYear + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();


                btnZMSEBankDifferChequeNumber.Text = "";
                lblBankDifferTotal.Text = "";
                lblBankDifferCount.Text = "";
                drpZMSEPrintBank.ClearSelection();
                drpZMSEPrintBankType.ClearSelection();
            }
            else
            {
                DisplayAlert("Enter Cheque Number",this);
            }
        }
        protected void SEZMBankDifferSendMail()
        {
            Document pdfDoc = new Document(PageSize.A4, 0, 0, 5, 0);
            Phrase phrase = null;
            PdfPCell cell = null;
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            //PdfWriter.GetInstance(pdfDoc, memoryStream);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();


                //pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan", 550f)); //Page Header          
                //DrawSingleLine(pdfDoc, writer);   //Separater Line      
                pdfDoc.Add(getParagraph("\n\n\n\n\n\n\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                //pdfDoc.Add(PrintGrid(SEZMPrintApprove, "Rejected List"));//Printing Table

                //pdfDoc.NewPage();
                //pdfDoc.Add(new Paragraph("This is Portrait Page"));
                //pdfDoc.SetPageSize(new Rectangle(1100f, 850f));
                string Subject = "Sub :- Transfer of amount to the beneficiaries \n SB Accounts through RTGF/NEFT-reg \n***************";
                Subject = Subject.Replace(Environment.NewLine, String.Empty).Replace("  ", String.Empty);
                string Block1_1 = "     We are enclosing herewith a crossed cheque bearing No ";
                string Block1_2 = " for Rs ";
                string Block1_3 = " along with the list of ";
                string Block1_4 = " beneficiaries.\n";
                string Block2_1 = "     We are request you to transferthe amount to the beneficiaries SB accounts as mentioned in the list enclosed to this letter through RTGS/NEFT transfer by debeting the amount to our SB Account Number: ";
                string Block2_2 = " Assistant General Manager K.A.C.D.C " + getZone + " Division and inform to this office in case of non transfer/failure to trasfer the amount to the beneficiaries account, the amount to be re-credited to the our SB account of the Assistant General Manager.";
                string Ty = "Thank You,";
                string YF = "Your Faithfully";
                string AgmName = "(" + "ZM Name" + ")";
                string AGM = "Assistant General Manager";



                Chunk ChunkSubject = new Chunk(Subject, FontFactory.GetFont("Arial", 14, Font.NORMAL, BaseColor.BLACK));
                Phrase PhraseSubject = new Phrase(ChunkSubject);
                Paragraph ParagraphSubject = new Paragraph(20);
                ParagraphSubject.IndentationLeft = 30f;
                ParagraphSubject.IndentationRight = 30f;
                ParagraphSubject.Alignment = Element.ALIGN_CENTER;
                ParagraphSubject.Add(PhraseSubject);

                Chunk ChunkChequeNum = new Chunk(btnZMSEBankDifferChequeNumber.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
                Chunk ChunkTotalValue = new Chunk(lblBankDifferTotal.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
                Chunk ChunkBeneficiariesCount = new Chunk(lblBankDifferCount.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
                Chunk ChunkAccountNumber = new Chunk(ZMAccountNumber, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));

                Phrase PhraseChequeNum = new Phrase(ChunkChequeNum);

                Paragraph Paragraph1 = new Paragraph(25);
                Paragraph1.IndentationLeft = 50f;
                Paragraph1.IndentationRight = 30f;
                Paragraph1.Alignment = Element.ALIGN_JUSTIFIED;
                Paragraph1.Add(new Chunk(Block1_1, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
                Paragraph1.Add(PhraseChequeNum);
                Paragraph1.Add(new Chunk(Block1_2, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
                Paragraph1.Add(ChunkTotalValue);
                Paragraph1.Add(new Chunk(Block1_3, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
                Paragraph1.Add(ChunkBeneficiariesCount);
                Paragraph1.Add(new Chunk(Block1_4, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));

                Paragraph Paragraph2 = new Paragraph(25);
                Paragraph2.IndentationLeft = 50f;
                Paragraph2.IndentationRight = 30f;
                Paragraph2.Alignment = Element.ALIGN_JUSTIFIED;
                Paragraph1.Add(new Chunk(Block2_1, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
                Paragraph1.Add(ChunkAccountNumber);
                Paragraph1.Add(new Chunk(Block2_2, FontFactory.GetFont("Arial", 16, Font.NORMAL, BaseColor.BLACK)));
                //-------



                pdfDoc.NewPage();

                pdfDoc.SetPageSize(new Rectangle(1100f, 850f));
                //pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan", 550f));
                //DrawSingleLine(pdfDoc, writer);   //Separater Line   
                pdfDoc.Add(getParagraph("\n\n\n\n\n\n\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                Chunk c1 = new Chunk(btnZMSEBankDifferChequeNumber.Text, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK));
                //Application Report Page
                Phrase p2 = new Phrase();
                p2.Add(c1);

                //Paragraph p = new Paragraph(30);
                pdfDoc.Add(getParagraph("Date: " + DateTime.Now.ToString("dd MMMM yyyy"), 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 380f, 30f, 20));
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph("To,", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph("The Cheif Manager,", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph(ZMBankName + ",", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph(ZMBranch + ",", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph(getZone + ".", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph("Sir/Madam,", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph(Subject, 14, Element.ALIGN_CENTER, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(Paragraph1);
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(Paragraph2);
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph(Ty, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 90f, 30f, 20));
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph(YF, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 385f, 30f, 20));
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                //pdfDoc.Add(getParagraph(AgmName, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 400f, 30f, 20));
                //pdfDoc.Add(getParagraph(AGM, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 360f, 30f, 20));
                //pdfDoc.Add(getParagraph(Subject, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                //pdfDoc.Add(ParagraphSubject);


                //Table Page
                pdfDoc.NewPage();
                pdfDoc.SetPageSize(new Rectangle(1100f, 850f));
                pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan", 1000f, ZMSESelectedDistrict));
                DrawSingleLine(pdfDoc, writer);   //Separater Line    
                PdfPTable DataTable = PrintGrid(gvZMSEBankDifferApproved, "Approved List");
                cell = new PdfPCell(new Phrase("Total", FontFactory.GetFont("Arial", 18, Font.NORMAL, BaseColor.BLACK)));
                cell.Colspan = 9;
                cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cell.BorderWidthBottom = 2f;
                cell.BorderWidthTop = 2f;
                cell.Padding = 2f;
                cell.PaddingBottom = 5f;

                DataTable.AddCell(cell);

                PdfPTable nested = new PdfPTable(1);
                cell = new PdfPCell(new Phrase(lblBankDifferTotal.Text, FontFactory.GetFont("Arial", 18, Font.NORMAL, BaseColor.BLACK)));
                cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cell.BorderWidthBottom = 2f;
                cell.BorderWidthTop = 2f;
                cell.Padding = 2f;
                cell.PaddingBottom = 5f;
                nested.AddCell(cell);

                PdfPCell nesthousing = new PdfPCell(nested);

                nesthousing.Padding = 0f;

                DataTable.AddCell(nesthousing);
                pdfDoc.Add(DataTable);
                pdfDoc.Add(getParagraph("\n", 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 50f, 30f, 20));
                //pdfDoc.Add(getParagraph(AgmName, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 840f, 30f, 20));
                //pdfDoc.Add(getParagraph(AGM, 14, Element.ALIGN_LEFT, 0, BaseColor.BLACK, 800f, 30f, 20));
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
                mail.Subject = "Self Employment RTGS Report : " + getZone+ "_"+ ZMSESelectedDistrict + " ( " + FinancialYear + " ) ";
                mail.IsBodyHtml = true;
                mail.Body = "Dear Sir/Madam <br />Please find the attachment of RTGS Report and sent same for Bank <br /><br />From  <br />Karnataka Arya Vysya Community Development Corporation <br />" + getZone;
                mail.Attachments.Add(new Attachment(new MemoryStream(bytes), "SelfEmployment_" + getZone + "_" + ZMSESelectedDistrict + "_" + FinancialYear + ".pdf"));
                SmtpServer.Send(mail);
            }
        }

        protected void btnZMSEBankDifferProceedtoPaymentExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;

            Response.AddHeader("content-disposition", "attachment;filename=SelfEmployment" + ZMSESelectedDistrict + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            gvZMSEBankDifferApproved.AllowPaging = false;
            //gvZMSEBankDifferApproved.DataBind();

            //Change the Header Row back to white color
            gvZMSEBankDifferApproved.HeaderRow.Style.Add("background-color", "#FFFFFF");
            int columnCount = gvZMSEBankDifferApproved.Columns.Count;
            int ColCount = 10;
            //Apply style to Individual Cells
            //gvZMSEBankDifferApproved.HeaderRow.Cells[0].Style.Add("background-color", "green");
            //gvZMSEBankDifferApproved.HeaderRow.Cells[1].Style.Add("background-color", "green");
            //gvZMSEBankDifferApproved.HeaderRow.Cells[2].Style.Add("background-color", "green");
            //gvZMSEBankDifferApproved.HeaderRow.Cells[3].Style.Add("background-color", "green");
            //for (int i = 0; i < ColCount; i++)
            //{
            //    gvZMSEBankDifferApproved.HeaderRow.Cells[i].Style.Add("background-color", "green");
            //}

            for (int i = 0; i < gvZMSEBankDifferApproved.Rows.Count; i++)
            {
                GridViewRow row = gvZMSEBankDifferApproved.Rows[i];

                //Change Color back to white
                row.BackColor = System.Drawing.Color.White;

                //Apply text style to each Row
                row.Attributes.Add("class", "textmode");

                //Apply style to Individual Cells of Alternating Row
                
                    //row.Cells[2].Text = "abc";
                    //row.Cells[2].Attributes.Add("class", "number");
                row.Cells[2].Attributes.CssStyle.Add("mso-number-format", "\\@");
                row.Cells[5].Attributes.CssStyle.Add("mso-number-format", "\\@");
                //row.Cells[0].Style.Add("background-color", "#C2D69B");
                //row.Cells[1].Style.Add("background-color", "#C2D69B");
                //row.Cells[2].Style.Add("background-color", "#C2D69B");
                //row.Cells[3].Style.Add("background-color", "#C2D69B");

            }
            gvZMSEBankDifferApproved.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
            //Response.Clear();
            //Response.Buffer = true;
            //Response.ContentType = "application/vnd.ms-excel";
            //Response.AddHeader("content-disposition", "attachment;filename=SelfEmployment" + ZMSESelectedDistrict + ".xls");
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);

            //StringWriter swr = new StringWriter();
            //HtmlTextWriter htmlwr = new HtmlTextWriter(swr);
            //gvZMSEBankDifferApproved.AllowPaging = false;
            //gvZMSEBankDifferApproved.RenderControl(htmlwr);
            //Response.Output.Write(swr.ToString());
            //Response.Flush();
            //Response.End();


        }
    }
}