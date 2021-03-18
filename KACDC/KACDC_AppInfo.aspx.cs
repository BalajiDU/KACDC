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
using System.Text;
using System.Security.Cryptography;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;

namespace KACDC
{
    public partial class KACDC_AppInfo : System.Web.UI.Page
    {
        SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
           
        private string ReportLoanName
        {
            set { ViewState["ReportLoanName"] = value; }
            get { return ViewState["ReportLoanName"] as string; }
        }
        private string ReportDistrict
        {
            set { ViewState["ReportDistrict"] = value; }
            get { return ViewState["ReportDistrict"] as string; }
        }
        private string ReportStage
        {
            set { ViewState["ReportStage"] = value; }
            get { return ViewState["ReportStage"] as string; }
        }
        private string ReportStatus
        {
            set { ViewState["ReportStatus"] = value; }
            get { return ViewState["ReportStatus"] as string; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERTYPE"] != "DATAVIEW")
            {
                Response.Redirect("~/Login.aspx");

            }
            if (!this.IsPostBack)
            {
                this.DropDownDistrictBinding();
                this.DropDownStatusBinding();
                this.ArivuCWApproveBindGrid();
                //this.SECWApproveBindGrid();
                this.ArivuCeoDocDownloadBindGrid();
                this.SECeoDocDownloadBindGrid();
                this.FillReportGridBind();
            }
            if (!IsPostBack)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                //fillDistrictName();
                //fillConstituencies();
                SqlDataAdapter FillDistric = new SqlDataAdapter("SELECT DistrictCD, DistrictName FROM MstDistrict", kvdConn);
                DataTable dtDistric = new DataTable();
                FillDistric.Fill(dtDistric);
                drpArivuDistrict.DataSource = dtDistric;
                drpArivuDistrict.DataBind();
                drpArivuDistrict.DataTextField = "DistrictName";
                drpArivuDistrict.DataValueField = "DistrictCD";
                drpArivuDistrict.DataBind();
                drpArivuDistrict.Items.Insert(0, "--SELECT--");
            }
            if (!IsPostBack)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                //fillDistrictName();
                //fillConstituencies();
                SqlDataAdapter FillDistric = new SqlDataAdapter("SELECT DistrictCD, DistrictName FROM MstDistrict", kvdConn);
                DataTable dtDistric = new DataTable();
                FillDistric.Fill(dtDistric);
                drpSEDistrict.DataSource = dtDistric;
                drpSEDistrict.DataBind();
                drpSEDistrict.DataTextField = "DistrictName";
                drpSEDistrict.DataValueField = "DistrictCD";
                drpSEDistrict.DataBind();
                drpSEDistrict.Items.Insert(0, "--SELECT--");
            }
        }
        private void ArivuCeoDocDownloadBindGrid()
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT AR.Id,AR.District,AR.DateTime FROM ArivuCEODoc AR INNER JOIN	(SELECT MIN(ID)AS ID,CEOVerifiedDoc AS DOC FROM	ArivuCEODoc GROUP BY CEOVerifiedDoc) AS B ON AR.Id=b.Id AND	AR.CEOVerifiedDoc=b.DOC";
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
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT AR.Id,AR.District,AR.DateTime FROM SECEODoc AR INNER JOIN	(SELECT MIN(ID)AS ID,CEOVerifiedDoc AS DOC FROM	SECEODoc GROUP BY CEOVerifiedDoc) AS B ON AR.Id=b.Id AND	AR.CEOVerifiedDoc=b.DOC";
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
                        fileName = "Arivu_"+sdr["District"].ToString();
                    }
                    kvdConn.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName+".pdf");
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
        private void SECWApproveBindGrid()
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
                if (!string.IsNullOrEmpty(txtSearchSE.Text.Trim()))
                {
                    cmd.Parameters.AddWithValue("@ApplicationNumber", txtSearchSE.Text.Trim());
                }
                if (!string.IsNullOrEmpty(txtSearchMobileSE.Text.Trim()))
                {
                    cmd.Parameters.AddWithValue("@AadharNum", txtSearchMobileSE.Text.Trim());
                }
                if (drpSEDistrict.SelectedIndex > 0)
                {
                    cmd.Parameters.AddWithValue("@District", drpSEDistrict.SelectedItem.Text.Trim());
                }
                cmd.Parameters.AddWithValue("@status", "SEAPPVIEW");
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
        protected void gvArivu_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ArivugvCWApprove.PageIndex = e.NewPageIndex;
            this.ArivuCWApproveBindGrid();
        }

        protected void gvSE_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SECWApprove.PageIndex = e.NewPageIndex;
            this.SECWApproveBindGrid();
        }

        protected void txtSESearchMob_TextChanged(object sender, EventArgs e)
        {
            this.SECWApproveBindGrid();
        }

        protected void txtSESearchAppNum_TextChanged(object sender, EventArgs e)
        {
            this.SECWApproveBindGrid();

        }
        protected void btnSESearch_Click(object sender, EventArgs e)
        {
            txtSearchSE.Text = "";
            txtSearchMobileSE.Text = "";
            this.SECWApproveBindGrid();
        }
        protected void txtSearchArivu_TextChanged(object sender, EventArgs e)
        {
            this.ArivuCWApproveBindGrid();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchMobileArivu.Text = "";
            txtSearchArivu.Text = "";
            drpArivuDistrict.ClearSelection();
            this.ArivuCWApproveBindGrid();
        }
        private void ArivuCWApproveBindGrid()
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
                SqlCommand cmd = new SqlCommand("spDMApprove", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (!string.IsNullOrEmpty(txtSearchArivu.Text.Trim()))
                {
                    cmd.Parameters.AddWithValue("@ApplicationNumber", txtSearchArivu.Text.Trim());
                }
                if (!string.IsNullOrEmpty(txtSearchMobileArivu.Text.Trim()))
                {
                    cmd.Parameters.AddWithValue("@AadharNum", txtSearchMobileArivu.Text.Trim());
                }
                if (drpArivuDistrict.SelectedIndex>0)
                {
                    cmd.Parameters.AddWithValue("@District", drpArivuDistrict.SelectedItem.Text.Trim());
                }
                cmd.Parameters.AddWithValue("@status", "ARAPPVIEW");
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
        protected void btnArivuCWApprovee_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string ApplicationNumber = ArivugvCWApprove.DataKeys[rowindex].Values["ApplicationNumber"].ToString();

            spDMStatus("ARAPPROVECW", "", ApplicationNumber);

            this.ArivuCWApproveBindGrid();
            this.SECWApproveBindGrid();
        }


        protected void spDMStatus(string status, string RejReason, string ApplicationNumber)
        {
            using (kvdConn)
            {
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("spDMApprove", kvdConn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (status == "ARREJECTCW")
                {
                    cmd.Parameters.AddWithValue("@status", status);
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
            string filepath = HttpContext.Current.Server.MapPath(@"~/ArivuAppFileData\ARCasteIncomeCert\");
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
            string AadharNum = ArivugvCWApprove.DataKeys[rowindex].Values["AadharNum"].ToString();
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
            //Response.Redirect("Download.aspx?File=" + filepath);
            string url = "Download.aspx?File=" + filepath;
            string winUrl = "window.open('" + url + "', 'popup_window', 'width=1500,height=500,left=300,top=20,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", winUrl, true);
        }
        protected void ViewFile(string DBFile, string ApplicationNumber, string filename, string sPathToSaveFileTo, string TableName)
        {
            using (kvdConn)
            {
                //kvdConn.Open();
                //using (SqlCommand cmd = new SqlCommand("select " + DBFile + " from " + TableName + " where [ApplicationNumber]='" + ApplicationNumber + "' ", kvdConn))
                //{
                //    using (SqlDataReader dr1 = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                //    {
                //        if (dr1.Read())
                //        {
                //            // read in using GetValue and cast to byte array
                //            byte[] fileData = ((byte[])dr1[DBFile]);
                //            // write bytes to disk as file
                //            using (System.IO.FileStream fs = new System.IO.FileStream(sPathToSaveFileTo, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                //            {
                //                // use a binary writer to write the bytes to disk
                //                using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                //                {
                //                    bw.Write(fileData);
                //                    bw.Close();
                //                }
                //            }
                //        }
                //        dr1.Close();
                //    }
                //}

               

            }
            //Response.Redirect("Download.aspx?File=" + filename);
            //string url = "Download.aspx?File=" + System.Web.HttpUtility.UrlEncode(sPathToSaveFileTo);
            string url = "Download.aspx?File=" + filename;
            string winUrl = "window.open('" + url + "', 'popup_window', 'width=1500,height=800,left=300,top=20,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", winUrl, true);
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
            string DBFile = "DocPhyCha";
            ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[SelfEmpLoan]");
        }

        protected void btnSECasteIncome_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowindex = gvr.RowIndex;
            string RDNumber = SECWApprove.DataKeys[rowindex].Values["RDNumber"].ToString();
            string filepath = HttpContext.Current.Server.MapPath(@"~/SEAppFielsData\SECasteIncomeCert\");
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
            //ViewFile(DBFile, ApplicationNumber, filename, sPathToSaveFileTo, "[KACDC].[dbo].[ArivuEduLoan]");
            //using (kvdConn)
            //{
            //    kvdConn.Open();
            //    using (SqlCommand cmd = new SqlCommand("select ImgAadharFront,ImgAadharBack from [KACDC].[dbo].[SelfEmpLoan] where [ApplicationNumber]='" + ApplicationNumber + "' ", kvdConn))
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
            try {
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
            catch {
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

            spSECWStatus("SEAPPROVECW", "", ApplicationNumber);

            this.ArivuCWApproveBindGrid();
            this.SECWApproveBindGrid();
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

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }

        protected void btnClearSE_Click(object sender, EventArgs e)
        {
            txtSearchSE.Text = "";
            txtSearchMobileSE.Text = "";
            drpSEDistrict.ClearSelection();
        }

        protected void drpArivuDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpArivuDistrict.SelectedIndex!=0)
            {
                this.ArivuCWApproveBindGrid();
            }
            
        }

        protected void drpSEDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SECWApproveBindGrid();
        }
        private void DropDownDistrictBinding()
        {
            //drpArivuDistrict
            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                using (SqlCommand cmd = new SqlCommand("select DistrictName from MstDistrict"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    drpRepDistrict.DataSource = cmd.ExecuteReader();
                    drpRepDistrict.DataTextField = "DistrictName";
                    drpRepDistrict.DataValueField = "DistrictName";
                    drpRepDistrict.DataBind();

                    kvdConn.Close();
                }
            }
        }
        private void DropDownStatusBinding()
        {
            //drpArivuDistrict
            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                if (ReportStage == null) { ReportStage = "CWApprove"; }
                if (ReportLoanName == null) {ReportLoanName = "ArivuEduLoan";}
                using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT "+ReportStage+" as Stage FROM "+ReportLoanName + " WHERE ParDistrict ='" + ReportDistrict + "'"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    drpRepStatus.DataSource = cmd.ExecuteReader();
                    drpRepStatus.DataTextField = "Stage";
                    drpRepStatus.DataValueField = "Stage";
                    drpRepStatus.DataBind();
                    kvdConn.Close();
                }
            }
        }

        protected void drpRepLoanName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportLoanName = drpRepLoanName.SelectedValue;
            this.DropDownStatusBinding();
            this.FillReportGridBind();
        }

        protected void drpRepDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportDistrict = drpRepDistrict.SelectedValue;
            this.DropDownStatusBinding();
            this.FillReportGridBind();
        }

        protected void drpRepStage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportStage = drpRepStage.SelectedValue;
            this.DropDownStatusBinding();
            this.FillReportGridBind();
        }

        protected void drpRepStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportStatus = drpRepStatus.SelectedValue;
            this.FillReportGridBind();
        }
        private void FillReportGridBind()
        {
            if (ReportStage == null) { ReportStage = "CWApprove"; }
            if (ReportLoanName == null) { ReportLoanName = "ArivuEduLoan"; }
            if (ReportStatus == null) { ReportStatus = "APPROVED"; }
            string Getsql = @"SELECT ROW_NUMBER() OVER (ORDER BY ApplicationNumber) AS 'SlNo',ApplicationNumber,ApplicantName,MobileNumber,  
 CASE WHEN CWApprove = 'REJECTED' THEN CWApprove+' : '+RejectReason else CWApprove END CWStatus
	  ,CASE WHEN DMApprove = 'REJECTED' THEN DMApprove+' : '+DMRejectReason else DMApprove END DMStatus
	  	  ,CASE WHEN DMCEOApprove = 'REJECTED' THEN DMCEOApprove+' : '+DMCEORejectReason WHEN DMCEOApprove = 'APPROVED' THEN DMCEOApprove+' : '+LoanAmount else DMCEOApprove	END	CEOStatus   
	  ,CASE WHEN DMDocApprove = 'REJECTED' THEN DMDocApprove+' : '+DMDocRejectReason else DMDocApprove END DOCStatus
	  ,CASE WHEN ZMApprove = 'REJECTED' THEN ZMApprove+' : '+ZMRejectReason else ZMApprove END ZMStatus FROM
" + ReportLoanName +" WHERE " + ReportStage + "='"+ ReportStatus+ "' AND ParDistrict ='" + ReportDistrict+"'";
            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand(Getsql, kvdConn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();
                if (ds.Tables[0].Rows.Count >= 0)
                {
                    gvPrintReport.DataSource = ds;
                    gvPrintReport.DataBind();
                }
            }
        }

        protected void btnReportPrint_Click(object sender, EventArgs e)
        {
            if (gvPrintReport.Rows.Count > 0)
            {

                string TableHeader = "";
                string Stage = "";
                if (ReportStage != null)
                {
                    Stage = drpRepStage.SelectedItem.Text;
                    TableHeader = drpRepStatus.SelectedItem.Text;
                }
                if (ReportLoanName == null) { ReportLoanName = "ArivuEduLoan"; }
                if (ReportStatus == null) { ReportStatus = "APPROVED"; }
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                Document pdfDoc = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                Phrase phrase = null;
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan"));  //Page Header          
                DrawSingleLine(pdfDoc, writer);   //Separater Line        
                pdfDoc.Add(PrintGrid(gvPrintReport, Stage + " - " + TableHeader));//Printing Table
                pdfDoc.Close();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;" + "filename=" + ReportLoanName + "_" + ReportStatus + "_" + ReportDistrict + "_" + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('NO APPLICATIONS FROM SELECTED OPTION');", true);
            }
        }
        private static void DrawSingleLine(Document pdfDoc, PdfWriter writer)
        {
            BaseColor color = null;
            color = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"));
            DrawLine(writer, 25f, pdfDoc.Top - 82f, pdfDoc.PageSize.Width - 25f, pdfDoc.Top - 82f, color);
            DrawLine(writer, 25f, pdfDoc.Top - 83f, pdfDoc.PageSize.Width - 25f, pdfDoc.Top - 83f, color);
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
            table.AddCell(NameAddr(ReportLoanName, ReportStage,ReportStatus, phrase, ReportDistrict, DateTime.Now.ToString("dd MMMM yyyy hh:mm tt")));//Page Heading
            table.AddCell(AddLogo("~/Image/KACDC_PDF.png", phrase, PdfPCell.ALIGN_RIGHT));//KACDC Logo   
            return table;
        }
        private static PdfPCell NameAddr(string LoanName, string ReportStage,string ReportStatus, Phrase phrase, string District, string Date)
        {
            PdfPCell cell = null;
            phrase = new Phrase();
            phrase.Add(new Chunk("Karnataka Arya Vysya Community Development Corporation\n", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.RED)));
            phrase.Add(new Chunk(LoanName  + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
            //phrase.Add(new Chunk("Year of: " + FinancialYear + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
            phrase.Add(new Chunk("District: " + District + "\n", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
            phrase.Add(new Chunk("Date: " + Date, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER);
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            return cell;
        }
        protected PdfPTable PrintGrid(GridView gridView, string ListType)
        {
            PdfPTable D_Table = null;
            int ColCount = gridView.Columns.Count;
            //ZM_Form zf = new ZM_Form();
            int[] widths = new int[gridView.Columns.Count];
            D_Table = CreatePdfTable(D_Table, ColCount); //Assign Table Properties                  
            D_Table.AddCell(TableHeader(ListType, ColCount)); //Table Heading
            ColumHeader(gridView, D_Table, widths);//Table Colum Header
            FillTableData(gridView, D_Table);//Table Data
            return D_Table;
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
                        
                        String cellText = Server.HtmlDecode(gv.Rows[i].Cells[j].Text);
                        cellText= Regex.Replace(cellText, "<([^>]+)>", "\n");
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
            float[] columnWidths = new float[ColCount];
            for (int i = 0; i < ColCount; i++)
            {
                if (i == 0)
                {
                    columnWidths[i] = 3f;
                }
                else if (i == 1)
                {
                    columnWidths[i] = 10f;
                }
                else if (i == 2)
                {
                    columnWidths[i] = 12f;
                }
                else if (i == 3)
                {
                    columnWidths[i] = 10f;
                }
                else if (i == 4)
                {
                    columnWidths[i] = 18f;
                }
                else
                {
                    columnWidths[i] = 20f;
                }
            }
            D_Table = new PdfPTable(ColCount);
            D_Table.TotalWidth = 550f;
            D_Table.SetWidths(columnWidths);
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
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        protected void btnArivuReport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;

            Response.AddHeader("content-disposition", "attachment;filename=Arivu_Statistics.xls");
            Response.Charset = "";
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            dgvArivuStat.AllowPaging = false;
            dgvArivuStat.DataBind();

            //Change the Header Row back to white color
            dgvArivuStat.HeaderRow.Style.Add("background-color", "#FFFFFF");
            int columnCount = dgvArivuStat.Columns.Count;
            int ColCount = 20;
            //Apply style to Individual Cells
            //dgvArivuStat.HeaderRow.Cells[0].Style.Add("background-color", "green");
            //dgvArivuStat.HeaderRow.Cells[1].Style.Add("background-color", "green");
            //dgvArivuStat.HeaderRow.Cells[2].Style.Add("background-color", "green");
            //dgvArivuStat.HeaderRow.Cells[3].Style.Add("background-color", "green");
            for (int i = 0; i < ColCount; i++)
            {
                dgvArivuStat.HeaderRow.Cells[i].Style.Add("background-color", "green");
            }

            for (int i = 0; i < dgvArivuStat.Rows.Count; i++)
            {
                GridViewRow row = dgvArivuStat.Rows[i];

                //Change Color back to white
                row.BackColor = System.Drawing.Color.White;

                //Apply text style to each Row
                row.Attributes.Add("class", "textmode");

                //Apply style to Individual Cells of Alternating Row
                if (i % 2 != 0)
                {
                    //row.Cells[0].Style.Add("background-color", "#C2D69B");
                    //row.Cells[1].Style.Add("background-color", "#C2D69B");
                    //row.Cells[2].Style.Add("background-color", "#C2D69B");
                    //row.Cells[3].Style.Add("background-color", "#C2D69B");
                }
            }
            dgvArivuStat.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        protected void btnSEReport_Click(object sender, EventArgs e)
        {

            Response.Clear();
            Response.Buffer = true;

            Response.AddHeader("content-disposition", "attachment;filename=SelfEmployment_Statistics.xls");
            Response.Charset = "";
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            dgvSEStat.AllowPaging = false;
            dgvSEStat.DataBind();

            //Change the Header Row back to white color
            dgvSEStat.HeaderRow.Style.Add("background-color", "#FFFFFF");
            int columnCount = dgvSEStat.Columns.Count;
            int ColCount = 20;
            //Apply style to Individual Cells
            //dgvSEStat.HeaderRow.Cells[0].Style.Add("background-color", "green");
            //dgvSEStat.HeaderRow.Cells[1].Style.Add("background-color", "green");
            //dgvSEStat.HeaderRow.Cells[2].Style.Add("background-color", "green");
            //dgvSEStat.HeaderRow.Cells[3].Style.Add("background-color", "green");
            for (int i = 0; i < ColCount; i++)
            {
                dgvSEStat.HeaderRow.Cells[i].Style.Add("background-color", "green");
            }

            for (int i = 0; i < dgvSEStat.Rows.Count; i++)
            {
                GridViewRow row = dgvSEStat.Rows[i];

                //Change Color back to white
                row.BackColor = System.Drawing.Color.White;

                //Apply text style to each Row
                row.Attributes.Add("class", "textmode");

                //Apply style to Individual Cells of Alternating Row
                if (i % 2 != 0)
                {
                    //row.Cells[0].Style.Add("background-color", "#C2D69B");
                    //row.Cells[1].Style.Add("background-color", "#C2D69B");
                    //row.Cells[2].Style.Add("background-color", "#C2D69B");
                    //row.Cells[3].Style.Add("background-color", "#C2D69B");
                }
            }
            dgvSEStat.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        protected void gvPrintReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[4].Text = string.Format("{0} {1} {2} {3} {4}"
                    , "CW : "+DataBinder.Eval(e.Row.DataItem, "CWStatus")
                    , "<br /> DM : " + DataBinder.Eval(e.Row.DataItem, "DMStatus")
                    , "<br /> CEO : " + DataBinder.Eval(e.Row.DataItem, "CEOStatus")
                    , "<br /> DOC : " + DataBinder.Eval(e.Row.DataItem, "DOCStatus")
                    , "<br /> ZM : " + DataBinder.Eval(e.Row.DataItem, "ZMStatus"));
            }
        }
    }
}