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
using System.Text;
using System.Security.Cryptography;
using iTextSharp.text.html.simpleparser;
using Microsoft.Reporting.WebForms;

namespace KACDC
{
    public partial class CW_Form : System.Web.UI.Page
    {
        SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
        BinaryReader br = null;
        Stream fs = null;
        private string UserName
        {
            set { ViewState["UserName"] = value; }
            get { return ViewState["UserName"] as string; }
        }
        static Byte[] byCEODocArivu;
        static string ArApplicationNumber="", SeApplicationNumber="";
        static string ArReject = "",SEReject="";
        static string getDistrict;
        //string ApplicationNumber;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERTYPE"] != "CASEWORKER")
            {
                Response.Redirect("~/Login.aspx");
                UserName = Session["UserName"].ToString();
            }
            getDistrict = Session["District"].ToString();
            if (!this.IsPostBack)
            {
                this.ArivuCWApproveBindGrid();
                this.SECWApproveBindGrid();
                this.FillRejectList();
            }
            
        }
        private void FillRejectList()
        {
            //foreach (GridViewRow grdrw in ArivugvCWApprove.Rows)
            //{
            //    ListBox bstbox = (ListBox)grdrw.FindControl("drpArivuRejectReason");
            //    System.Web.UI.WebControls.ListItem lstitm = new System.Web.UI.WebControls.ListItem();
            //    if (!this.IsPostBack)
            //    {
            //        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            //        using (SqlConnection con = new SqlConnection(constr))
            //        {
            //            using (SqlCommand cmd = new SqlCommand("SELECT CustomerId, Name FROM Customers"))
            //            {
            //                cmd.CommandType = CommandType.Text;
            //                cmd.Connection = con;
            //                con.Open();

            //                lstitm. = cmd.ExecuteReader();
            //                lstitm.Text = "Name";
            //                lstitm.Value = "CustomerId";
            //                lstitm.DataBind();
            //                con.Close();
            //            }
            //        }
            //    }
            //}
        }
        private void SECWApproveBindGrid()
        {
            DataSet ds = new DataSet();
            //CEO
            string DistCode = "";
            if (UserName == "CWBLRN")
            {
                DistCode = "31";
                string SQL = @"SELECT DISTINCT * FROM SelfEmpLoan SE INNER JOIN
(SELECT min(Dis.DistrictCD) AS ID,Dis.DistrictName AS DName FROM MstDistrict Dis group by DIS.DistrictName) AS TabDiS ON 
	TabDiS.DName=SE.ParDistrict AND ParDistrict='Bengaluru (U)' AND CWApprove='PENDING'
	 INNER JOIN MstConstituencies AS Con ON	Con.AssemblyName=SE.ParConstituency AND	Con.DistrictCD=@DistCode 
ORDER BY ApplicationNumber ";
                using (kvdConn)
                {
                    SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

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
                        SECWApprove.DataSource = ds;
                        SECWApprove.DataBind();

                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        SECWApprove.DataSource = ds;
                        SECWApprove.DataBind();
                        int columncount = SECWApprove.Rows[0].Cells.Count;
                        SECWApprove.Rows[0].Cells.Clear();
                        SECWApprove.Rows[0].Cells.Add(new TableCell());
                        SECWApprove.Rows[0].Cells[0].ColumnSpan = columncount;
                        SECWApprove.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
            else if (UserName == "CWBLRS")
            {
                DistCode = "1";
                string SQL = @"SELECT DISTINCT * FROM SelfEmpLoan SE INNER JOIN
(SELECT min(Dis.DistrictCD) AS ID,Dis.DistrictName AS DName FROM MstDistrict Dis group by DIS.DistrictName) AS TabDiS ON 
	TabDiS.DName=SE.ParDistrict AND ParDistrict='Bengaluru (U)' AND CWApprove='PENDING'
	 INNER JOIN MstConstituencies AS Con ON	Con.AssemblyName=SE.ParConstituency AND	Con.DistrictCD=@DistCode 
ORDER BY ApplicationNumber ";
                using (kvdConn)
                {
                    SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

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
                        SECWApprove.DataSource = ds;
                        SECWApprove.DataBind();

                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        SECWApprove.DataSource = ds;
                        SECWApprove.DataBind();
                        int columncount = SECWApprove.Rows[0].Cells.Count;
                        SECWApprove.Rows[0].Cells.Clear();
                        SECWApprove.Rows[0].Cells.Add(new TableCell());
                        SECWApprove.Rows[0].Cells[0].ColumnSpan = columncount;
                        SECWApprove.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
            else
            {
                
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
                    cmd.Parameters.AddWithValue("@status", "SESELECTCW");
                    cmd.Parameters.AddWithValue("@District", getDistrict);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    kvdConn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        SECWApprove.DataSource = ds;
                        SECWApprove.DataBind();

                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        SECWApprove.DataSource = ds;
                        SECWApprove.DataBind();
                        int columncount = SECWApprove.Rows[0].Cells.Count;
                        SECWApprove.Rows[0].Cells.Clear();
                        SECWApprove.Rows[0].Cells.Add(new TableCell());
                        SECWApprove.Rows[0].Cells[0].ColumnSpan = columncount;
                        SECWApprove.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
        }

        private void ArivuCWApproveBindGrid()
        {
            DataSet ds = new DataSet();
            //CEO
            string DistCode = "";
            if(UserName== "CWBLRN")
            {
                DistCode = "31";
                string SQL = @"SELECT DISTINCT * FROM ArivuEduLoan SE INNER JOIN
(SELECT min(Dis.DistrictCD) AS ID,Dis.DistrictName AS DName FROM MstDistrict Dis group by DIS.DistrictName) AS TabDiS ON 
	TabDiS.DName=SE.ParDistrict AND ParDistrict='Bengaluru (U)' AND CWApprove='PENDING'
	 INNER JOIN MstConstituencies AS Con ON	Con.AssemblyName=SE.ParConstituency AND	Con.DistrictCD=@DistCode 
ORDER BY ApplicationNumber ";
                using (kvdConn)
                {
                    SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

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
                        ArivugvCWApprove.DataSource = ds;
                        ArivugvCWApprove.DataBind();

                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        ArivugvCWApprove.DataSource = ds;
                        ArivugvCWApprove.DataBind();
                        int columncount = ArivugvCWApprove.Rows[0].Cells.Count;
                        ArivugvCWApprove.Rows[0].Cells.Clear();
                        ArivugvCWApprove.Rows[0].Cells.Add(new TableCell());
                        ArivugvCWApprove.Rows[0].Cells[0].ColumnSpan = columncount;
                        ArivugvCWApprove.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
            else if (UserName == "CWBLRS")
            {
                DistCode = "1";
                string SQL = @"SELECT DISTINCT * FROM ArivuEduLoan SE INNER JOIN
(SELECT min(Dis.DistrictCD) AS ID,Dis.DistrictName AS DName FROM MstDistrict Dis group by DIS.DistrictName) AS TabDiS ON 
	TabDiS.DName=SE.ParDistrict AND ParDistrict='Bengaluru (U)' AND CWApprove='PENDING'
	 INNER JOIN MstConstituencies AS Con ON	Con.AssemblyName=SE.ParConstituency AND	Con.DistrictCD=@DistCode 
ORDER BY ApplicationNumber ";
                using (kvdConn)
                {
                    SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

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
                        ArivugvCWApprove.DataSource = ds;
                        ArivugvCWApprove.DataBind();

                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        ArivugvCWApprove.DataSource = ds;
                        ArivugvCWApprove.DataBind();
                        int columncount = ArivugvCWApprove.Rows[0].Cells.Count;
                        ArivugvCWApprove.Rows[0].Cells.Clear();
                        ArivugvCWApprove.Rows[0].Cells.Add(new TableCell());
                        ArivugvCWApprove.Rows[0].Cells[0].ColumnSpan = columncount;
                        ArivugvCWApprove.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }
            else
            {
                using (kvdConn)
                {
                    SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                    //kvdConn.Open();
                    if (kvdConn.State == ConnectionState.Closed)
                    {
                        kvdConn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("spDMApprove", kvdConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@status", "ARSELECTCW");
                    cmd.Parameters.AddWithValue("@District", getDistrict);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    kvdConn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ArivugvCWApprove.DataSource = ds;
                        ArivugvCWApprove.DataBind();

                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        ArivugvCWApprove.DataSource = ds;
                        ArivugvCWApprove.DataBind();
                        int columncount = ArivugvCWApprove.Rows[0].Cells.Count;
                        ArivugvCWApprove.Rows[0].Cells.Clear();
                        ArivugvCWApprove.Rows[0].Cells.Add(new TableCell());
                        ArivugvCWApprove.Rows[0].Cells[0].ColumnSpan = columncount;
                        ArivugvCWApprove.Rows[0].Cells[0].Text = "No Records Found";
                    }
                }
            }

            
        }
        protected void btnArivuCWApprovee_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = ArivugvCWApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();

            spDMStatus("ARAPPROVECW","", ApplicationNumber);

            this.ArivuCWApproveBindGrid();
            this.SECWApproveBindGrid();
        }
        protected void btnArivuRowEditing(object sender, GridViewEditEventArgs e)
        {
            //divCEOgv.Visible = true;
            ArivugvCWApprove.EditIndex = e.NewEditIndex;
            this.ArivuCWApproveBindGrid();
            (ArivugvCWApprove.Rows[e.NewEditIndex].FindControl("drpArivuRejectReason") as ListBox).Items[e.NewEditIndex].Selected = true;
            //(ArivugvCWApprove.Rows[e.NewEditIndex].FindControl("ddlCountries") as ListBox).Items[e.NewEditIndex + 1].Selected = true;
        }
        protected void ArivugvCW_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ArivugvCWApprove.EditIndex = -1;
            this.ArivuCWApproveBindGrid();
            
        }
        protected void btnArivuCEReject_Click(object sender, EventArgs e)
        {
            //GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;

            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            ArApplicationNumber = ArivugvCWApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();

            string message = "";
            //ListBox ArivuRejectListCW = (ListBox)(row.FindControl("drpArivuRejectReason"));
            //foreach (System.Web.UI.WebControls.ListItem item in ArivuRejectListCW.Items)
            //{
            //    if (item.Selected)
            //    {
            //        message += item.Text + " , ";
            //    }
            //}
            string a = "Update";
            object obj = a;
            OnUpdate(obj, e);
            spDMStatus("ARREJECTCW", ArReject, ArApplicationNumber);
            this.ArivuCWApproveBindGrid();



            //Button btn = (Button)sender;
            //GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            //int rowindex = gvr.RowIndex;
            //ArApplicationNumber = ArivugvCWApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();

            //divCWArivuRejectReason.Visible = true;          
        }
        protected void CancelArivuCW_Click(object sender, EventArgs e)
        {
            ArivugvCWApprove.EditIndex = -1;
            this.ArivuCWApproveBindGrid();
        }
        protected void CancelSECW_Click(object sender, EventArgs e)
        {
            SECWApprove.EditIndex = -1;
            this.SECWApproveBindGrid();
        }
        protected void OnUpdate(object sender, EventArgs e)
        {
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            string ArApplicationNumber = (row.FindControl("txtAppNum") as TextBox).Text;
            string ab=ArivugvCWApprove.DataKeyNames.ToString();
            string ArRR = string.Empty;
            ListBox cblProject = (ListBox)(row.FindControl("drpArivuRejectReason"));
            foreach (System.Web.UI.WebControls.ListItem item in cblProject.Items)
            {
                if (item.Selected)
                {
                    ArRR += item.Text + ",";

                }
            }
            ArReject = ArRR;
            //ArRR.Replace(",", " ");
            //DataTable dt = ViewState["dt"] as DataTable;
            //dt.Rows[row.RowIndex]["Name"] = name;
            //dt.Rows[row.RowIndex]["Country"] = ArRR;
            //ViewState["dt"] = dt;
            //string a= "Ineligible";
            spDMStatus("ARREJECTCW", ArReject, ArApplicationNumber);

            //btnArivuCEReject_Click(obj,e);
            //ArivugvCWApprove.EditIndex = -1;
            this.ArivuCWApproveBindGrid();
        }
        protected void spDMStatus(string status, string RejReason,string ApplicationNumber)
        {
            using (kvdConn)
            {
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spDMApprove", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (status == "ARREJECTCW")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@RejectReason", RejReason);
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                }
                else if (status == "ARAPPROVECW")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                }

                cmd.ExecuteNonQuery();
                //lblresult.ForeColor = Color.Green;
                //lblresult.Text = YearLoan1 + " details " + status.ToLower() + "d successfully";
                ArivugvCWApprove.EditIndex = -1;
                //ArivuDMApproveBindGrid();
            }
        }

        protected void btnCasteIncome_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string RDNumber = ArivugvCWApprove.DataKeys[rowindex].Values["RDNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath(@"~/ArivuAppFileData/ARCasteIncomeCert\");
            string filepath1 = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = RDNumber.ToUpper() + ".pdf";
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
            string ApplicationNumber = ArivugvCWApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
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
            string ApplicationNumber = ArivugvCWApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
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
            string ApplicationNumber = ArivugvCWApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
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
            string ApplicationNumber = ArivugvCWApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
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
            string ApplicationNumber = ArivugvCWApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
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
            string ApplicationNumber = ArivugvCWApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
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
            string ApplicationNumber = ArivugvCWApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
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
            string ApplicationNumber = ArivugvCWApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
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

            //string strJavascript = "<script type='text/javascript'>window.open('Download.aspx?File=";
            //strJavascript += filename + "','_blank');</script>";
            //Response.Write(strJavascript);

            //Response.Write("<script language='javascript'> window.open(Download.aspx?File='" + filename + "'); </script>");

            string url = "Download.aspx?File=" + filename;
            string winUrl = "window.open('" + url + "', 'popup_window', 'width=1500,height=500,left=300,top=20,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", winUrl, true);

            //Response.Redirect("Download.aspx?File=" + filename);
            //Response.Write("<script>");
            //Response.Write("window.open('Download.aspx?File="+ filename+", '_newtab');");
            //Response.Write("</script>");
        }
     
        protected void btnSEDispPH_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = SECWApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = ApplicationNumber + "Aadhar.pdf";
            string sPathToSaveFileTo = filepath + filename;
            string DBFile = "ImgAadharFront";
            ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[SelfEmpLoan]");
        }

        protected void btnSECasteIncome_Click(object sender, EventArgs e)
        {

            //DisplayAlert("Test", this);
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string RDNumber = SECWApprove.DataKeys[rowindex].Values["RDNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath(@"~/SEAppFielsData/SECasteIncomeCert\");
            string filepath1 = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = RDNumber.ToUpper() + ".pdf";
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
            string AadharNum = SECWApprove.DataKeys[rowindex].Values["AadharNum"].ToString();
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
            string ApplicationNumber = SECWApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = ApplicationNumber + "Aadhar.pdf";
            string sPathToSaveFileTo = filepath + filename;
            string DBFile = "DocBankPassbook";
            ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[SelfEmpLoan]");
        }

        protected void btnSECWApprovee_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = SECWApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();

            spSECWStatus("SEAPPROVECW","", ApplicationNumber);

            this.ArivuCWApproveBindGrid();
            this.SECWApproveBindGrid();
        }

        protected void btnSECWReject_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            SeApplicationNumber = SECWApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();

            divCWSERejectReason.Visible = true;
            
        }
        protected void spSECWStatus(string status, string RejReason, string ApplicationNumber)
        {
            using (kvdConn)
            {
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spSEApprove", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (status == "SEAPPROVECW")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                }
                else if (status == "SEREJECTCW")
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@RejectReason", RejReason);
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                }

                cmd.ExecuteNonQuery();
                //lblresult.ForeColor = Color.Green;
                //lblresult.Text = YearLoan1 + " details " + status.ToLower() + "d successfully";
                ArivugvCWApprove.EditIndex = -1;
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
            spSECWStatus("SEREJECTCW", message, SeApplicationNumber);            
            divCWSERejectReason.Visible = false;
            this.SECWApproveBindGrid();
        }

        protected void SECWApprove_RowEditing(object sender, GridViewEditEventArgs e)
        {
            SECWApprove.EditIndex = e.NewEditIndex;
            this.SECWApproveBindGrid();
            (SECWApprove.Rows[e.NewEditIndex].FindControl("drpSERejectReason") as ListBox).Items[e.NewEditIndex].Selected = true;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }

        protected void OnUpdateSE(object sender, EventArgs e)
        {
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            string ArApplicationNumber = (row.FindControl("txtSEAppNum") as TextBox).Text;
            string ab = SECWApprove.DataKeyNames.ToString();
            string SERR = string.Empty;
            ListBox cblProject = (ListBox)(row.FindControl("drpSERejectReason"));
            foreach (System.Web.UI.WebControls.ListItem item in cblProject.Items)
            {
                if (item.Selected)
                {
                    SERR += item.Text + ",";

                }
            }

            //ArRR.Replace(",", " ");
            //DataTable dt = ViewState["dt"] as DataTable;
            //dt.Rows[row.RowIndex]["Name"] = name;
            //dt.Rows[row.RowIndex]["Country"] = ArRR;
            //ViewState["dt"] = dt;
            //string a= "Ineligible";
            spSECWStatus("SEREJECTCW", SERR, ArApplicationNumber);

            //btnArivuCEReject_Click(obj,e);
            SECWApprove.EditIndex = -1;
            this.SECWApproveBindGrid();
        }

        protected void btnSECasteIncome_Click1(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = SECWApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath("~/DownloadFiles/");
            string filename = ApplicationNumber + "Aadhar.pdf";
            string sPathToSaveFileTo = filepath + filename;
            string DBFile = "DocCasteIncome";
            ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[SelfEmpLoan]");
        }

       
    }
}