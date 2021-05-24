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

namespace KACDC
{
    public partial class AdminHome : System.Web.UI.Page
    {
        SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
        BinaryReader br = null;
        Stream fs = null;
        static Byte[] byCM, byMinister, byChairman, byGOK, byKACDC;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USERTYPE"].ToString() != "ADMIN" || Session["USERTYPE"] == null)
            {
                Response.Redirect("~/Login.aspx");

            }
            if (!this.IsPostBack)
            {
                this.DMKABindGrid();
                this.DMENBindGrid();
                this.ZMENBindGrid();
                this.ZMKABindGrid();
                this.HOENBindGrid();
                this.HOKABindGrid();
                this.UsrCreBindGrid();
                this.FillpwdGrid();
                this.FillSliderGrid();
                this.FillMpicGridViewDataBind();
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
                drpSEMPICDistrict.DataSource = dtDistric;
                drpSEMPICDistrict.DataBind();
                drpSEMPICDistrict.DataTextField = "DistrictName";
                drpSEMPICDistrict.DataValueField = "DistrictCD";
                drpSEMPICDistrict.DataBind();
                drpSEMPICDistrict.Items.Insert(0, "--SELECT--");
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
                drpARMPICDistrict.DataSource = dtDistric;
                drpARMPICDistrict.DataBind();
                drpARMPICDistrict.DataTextField = "DistrictName";
                drpARMPICDistrict.DataValueField = "DistrictCD";
                drpARMPICDistrict.DataBind();
                drpARMPICDistrict.Items.Insert(0, "--SELECT--");
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
                txtUsrCreDistrict.DataSource = dtDistric;
                txtUsrCreDistrict.DataBind();
                txtUsrCreDistrict.DataTextField = "DistrictName";
                txtUsrCreDistrict.DataValueField = "DistrictCD";
                txtUsrCreDistrict.DataBind();
                txtUsrCreDistrict.Items.Insert(0, "--SELECT--");
            }
            if (!IsPostBack)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                //fillDistrictName();
                //fillConstituencies();
                SqlDataAdapter FillDistric1 = new SqlDataAdapter("SELECT username FROM UserLogin", kvdConn);
                DataTable dtDistric1 = new DataTable();
                FillDistric1.Fill(dtDistric1);
                drpUser.DataSource = dtDistric1;
                drpUser.DataBind();
                drpUser.DataTextField = "username";
                drpUser.DataValueField = "username";
                drpUser.DataBind();
                drpUser.Items.Insert(0, "--SELECT--");
            }
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[ArivuEduLoan] WHERE ApplicationNumber;"))
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                cmd.CommandType = CommandType.Text;
                cmd.Connection = kvdConn;
                //kvdConn.Open();
                //using (SqlDataReader sdr = cmd.ExecuteReader())
                //{
                //    sdr.Read();
                //    //lblCM.Text = sdr["LoanAmount"].ToString();
                //    //lblMinister.Text = sdr["LoanAmount"].ToString();
                //    //lblChairman.Text = sdr["LoanAmount"].ToString();
                //    //ImgGOK.ImageUrl = "data:Image/png;base64," + Convert.ToBase64String((byte[])sdr["ImgCandidate"]);
                //    //Imgkacdc.ImageUrl = "data:Image/png;base64," + Convert.ToBase64String((byte[])sdr["ImgCandidate"]);
                //    //ImgCM.ImageUrl = "data:Image/png;base64," + Convert.ToBase64String((byte[])sdr["ImgCandidate"]);
                //    //ImgChairman.ImageUrl = "data:Image/png;base64," + Convert.ToBase64String((byte[])sdr["ImgCandidate"]);
                //    //ImaMinister.ImageUrl = "data:Image/png;base64," + Convert.ToBase64String((byte[])sdr["ImgCandidate"]);
                //}
                //kvdConn.Close();
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
        protected void btnCMName_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand("Update KACDCInfo set  [CM Name]='"+txtCMName.Text+"' where id=1"))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = kvdConn;
                kvdConn.Open();
                Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                kvdConn.Close();
            }
        }

        protected void btnMinister_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand("Update KACDCInfo set  [Minister Name]='" + txtMinisterName.Text + "' where id=1"))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = kvdConn;
                kvdConn.Open();
                Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                kvdConn.Close();
            }
        }

        protected void btnMinisterPhoto_Click(object sender, EventArgs e)
        {
            if (FileImgMinister.HasFile)
            {
                string name = FileImgMinister.FileName + Path.GetExtension(FileImgMinister.FileName);
                string fileExtension = Path.GetExtension(FileImgMinister.FileName);

                if (name.Contains(".exe") && name.Contains(".msi") && name.Contains(".etc") && name.Contains(".dll") && name.Contains(".dat") && fileExtension.ToLower() != ".jpg" && fileExtension.ToLower() != ".jpeg" && fileExtension.ToLower() != ".png")
                {
                    DisplayAlert("Only Image file allowed", this);
                }
                else
                {
                    int fileSize = FileImgMinister.PostedFile.ContentLength;
                    if (fileSize < 53600)
                    {
                        DisplayAlert("Minimun size 50KB ", this);
                    }
                    else if (fileSize > 1536000)
                    {
                        DisplayAlert("File size Exceeded.. Maximum size 150KB", this);
                    }

                    else
                    {
                        FileImgMinister.SaveAs(Server.MapPath("~/ImageUpload/" + FileImgMinister.FileName));
                        DisplayAlert("File Uploaded successfully", this);
                        fs = FileImgMinister.PostedFile.InputStream;
                        br = new BinaryReader(fs);
                        ImgMinister.ImageUrl = "~/ImageUpload/" + FileImgMinister.FileName;

                        byMinister = br.ReadBytes((Int32)fs.Length);
                        using (SqlCommand cmd = new SqlCommand("Update KACDCInfo set  [Minister Photo]=@ImgData where id=1"))
                        {
                            cmd.Parameters.AddWithValue("@ImgData", byMinister);

                            //cmd.CommandType = CommandType.Text;
                            cmd.Connection = kvdConn;
                            kvdConn.Open();
                            cmd.ExecuteScalar();
                            kvdConn.Close();
                        }
                    }
                }
            }
            else
            {
                DisplayAlert("File not uploaded", this);
            }
        }

        protected void btnChairmanPhoto_Click(object sender, EventArgs e)
        {
            if (FileImgChairman.HasFile)
            {
                string name = FileImgChairman.FileName + Path.GetExtension(FileImgChairman.FileName);
                string fileExtension = Path.GetExtension(FileImgChairman.FileName);

                if (name.Contains(".exe") && name.Contains(".msi") && name.Contains(".etc") && name.Contains(".dll") && name.Contains(".dat") && fileExtension.ToLower() != ".jpg" && fileExtension.ToLower() != ".jpeg" && fileExtension.ToLower() != ".png")
                {
                    DisplayAlert("Only Image file allowed", this);
                }
                else
                {
                    int fileSize = FileImgChairman.PostedFile.ContentLength;
                    if (fileSize < 53600)
                    {
                        DisplayAlert("Minimun size 50KB ", this);
                    }
                    else if (fileSize > 1536000)
                    {
                        DisplayAlert("File size Exceeded.. Maximum size 150KB", this);
                    }

                    else
                    {
                        FileImgChairman.SaveAs(Server.MapPath("~/ImageUpload/" + FileImgChairman.FileName));
                        DisplayAlert("File Uploaded successfully", this);
                        fs = FileImgChairman.PostedFile.InputStream;
                        br = new BinaryReader(fs);
                        byChairman = br.ReadBytes((Int32)fs.Length);
                        ImgChairman.ImageUrl = "~/ImageUpload/" + FileImgChairman.FileName;

                        using (SqlCommand cmd = new SqlCommand("Update KACDCInfo set  [Chairman Photo]=@ImgData where id=1"))
                        {
                            cmd.Parameters.AddWithValue("@ImgData", byChairman);

                            //cmd.CommandType = CommandType.Text;
                            cmd.Connection = kvdConn;
                            kvdConn.Open();
                            cmd.ExecuteScalar();
                            kvdConn.Close();
                        }
                    }
                }
            }
            else
            {
                DisplayAlert("File not uploaded", this);
            }
        }

        protected void btnGOK_Click(object sender, EventArgs e)
        {
            if (FileImgGOK.HasFile)
            {
                string name = FileImgGOK.FileName + Path.GetExtension(FileImgGOK.FileName);
                string fileExtension = Path.GetExtension(FileImgGOK.FileName);
                //if (name.Contains(".exe") { }
                if (name.Contains(".exe") && name.Contains(".msi") && name.Contains(".etc")&& name.Contains(".dll")&& name.Contains(".dat")&& fileExtension.ToLower() != ".jpg" && fileExtension.ToLower() != ".jpeg" && fileExtension.ToLower() != ".png")
                {
                    DisplayAlert("Only Image file allowed", this);
                }
                else
                {
                    int fileSize = FileImgGOK.PostedFile.ContentLength;
                    if (fileSize < 53600)
                    {
                        DisplayAlert("Minimun size 50KB ", this);
                    }
                    else if (fileSize > 1536000)
                    {
                        DisplayAlert("File size Exceeded.. Maximum size 150KB", this);
                    }

                    else
                    {
                        FileImgGOK.SaveAs(Server.MapPath("~/ImageUpload/" + FileImgGOK.FileName));
                        DisplayAlert("File Uploaded successfully", this);
                        fs = FileImgGOK.PostedFile.InputStream;
                        br = new BinaryReader(fs);
                        byGOK = br.ReadBytes((Int32)fs.Length);
                        ImgGOK.ImageUrl = "~/ImageUpload/" + FileImgGOK.FileName;

                        using (SqlCommand cmd = new SqlCommand("Update KACDCInfo set  [GOK]=@ImgData where id=1"))
                        {
                            cmd.Parameters.AddWithValue("@ImgData", byGOK);

                            //cmd.CommandType = CommandType.Text;
                            cmd.Connection = kvdConn;
                            kvdConn.Open();
                            cmd.ExecuteScalar();
                            kvdConn.Close();
                        }
                    }
                }
            }
            else
            {
                DisplayAlert("File not uploaded", this);
            }
        }

        protected void btnImgKACDC_Click(object sender, EventArgs e)
        {
            if (FileImgKacdc.HasFile)
            {
                string name = FileImgKacdc.FileName + Path.GetExtension(FileImgKacdc.FileName);
                string fileExtension = Path.GetExtension(FileImgKacdc.FileName);

                if (name.Contains(".exe") && name.Contains(".msi") && name.Contains(".etc") && name.Contains(".dll") && name.Contains(".dat") && fileExtension.ToLower() != ".jpg" && fileExtension.ToLower() != ".jpeg" && fileExtension.ToLower() != ".png")
                {
                    DisplayAlert("Only Image file allowed", this);
                }
                else
                {
                    int fileSize = FileImgKacdc.PostedFile.ContentLength;
                    if (fileSize < 53600)
                    {
                        DisplayAlert("Minimun size 50KB ", this);
                    }
                    else if (fileSize > 1536000)
                    {
                        DisplayAlert("File size Exceeded.. Maximum size 150KB", this);
                    }

                    else
                    {
                        FileImgKacdc.SaveAs(Server.MapPath("~/ImageUpload/" + FileImgKacdc.FileName));
                        DisplayAlert("File Uploaded successfully", this);
                        fs = FileImgKacdc.PostedFile.InputStream;
                        br = new BinaryReader(fs);
                        byKACDC = br.ReadBytes((Int32)fs.Length);
                        ImgKACDC.ImageUrl = "~/ImageUpload/" + FileImgKacdc.FileName;

                        using (SqlCommand cmd = new SqlCommand("Update KACDCInfo set  [KACDC]=@ImgData where id=1"))
                        {
                            cmd.Parameters.AddWithValue("@ImgData", byKACDC);

                            //cmd.CommandType = CommandType.Text;
                            cmd.Connection = kvdConn;
                            kvdConn.Open();
                            cmd.ExecuteScalar();
                            kvdConn.Close();
                        }
                    }
                }
            }
            else
            {
                DisplayAlert("File not uploaded", this);
            }
        }

        protected void btnChairman_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand("Update KACDCInfo set  [Chairman Name]='" + txtChairmanName.Text + "' where id=1"))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = kvdConn;
                kvdConn.Open();
                Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                kvdConn.Close();
            }
        }

        protected void btnArivuEnable_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand("Update KACDCInfo set  [Arivu Enable]='" + drpArivuEnable.Text + "' where id=1"))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = kvdConn;
                kvdConn.Open();
                Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                kvdConn.Close();
            }
        }

        protected void btnSEEnable_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand("Update KACDCInfo set  [Self Employment Enable]='" + drpSEEnable.Text + "' where id=1"))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = kvdConn;
                kvdConn.Open();
                Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                kvdConn.Close();
            }
        }

        protected void btnCMPhoto_Click(object sender, EventArgs e)
        {
            if (FileImgCM.HasFile)
            {
                string name = FileImgGOK.FileName + Path.GetExtension(FileImgGOK.FileName);
                string fileExtension = Path.GetExtension(FileImgCM.FileName);

                if (name.Contains(".exe") && name.Contains(".msi") && name.Contains(".etc") && name.Contains(".dll") && name.Contains(".dat") && fileExtension.ToLower() != ".jpg" && fileExtension.ToLower() != ".jpeg" && fileExtension.ToLower() != ".png")
                {
                    DisplayAlert("Only Image file allowed", this);
                }
                else
                {
                    int fileSize = FileImgCM.PostedFile.ContentLength;
                    if (fileSize < 53600)
                    {
                        DisplayAlert("Minimun size 50KB ", this);
                    }
                    else if (fileSize > 1536000)
                    {
                        DisplayAlert("File size Exceeded.. Maximum size 150KB", this);
                    }
                    
                    else
                    {
                        FileImgCM.SaveAs(Server.MapPath("~/ImageUpload/" + FileImgCM.FileName));
                        DisplayAlert("File Uploaded successfully", this);
                        fs = FileImgCM.PostedFile.InputStream;
                        br = new BinaryReader(fs);
                        byCM = br.ReadBytes((Int32)fs.Length);
                        ImgCM.ImageUrl = "~/ImageUpload/" + FileImgCM.FileName;

                        using (SqlCommand cmd = new SqlCommand("Update KACDCInfo set  [CMPhoto]=@ImgData where id=1"))
                        {
                            cmd.Parameters.AddWithValue("@ImgData", byCM);

                            //cmd.CommandType = CommandType.Text;
                            cmd.Connection = kvdConn;
                            kvdConn.Open();
                            cmd.ExecuteScalar();
                            kvdConn.Close();
                        }
                    }
                }
            }
            else
            {
                DisplayAlert("File not uploaded",this);
            }
        }

        private void DMKABindGrid()
        {
            
            string constr = ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString;
            string query = "SELECT * FROM [DM Kannada]";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        gvDMKan.DataSource = dt;
                        gvDMKan.DataBind();
                    }
                }
            }
        }

        protected void DMKAInsert(object sender, EventArgs e)
        {
            //string name = txtName.Text;
            //string country = txtCountry.Text;

            //int SlNo = Convert.ToInt32(gvDMKan.DataKeys[e.RowIndex].Values["SlNo"].ToString());
            string District = txtDMKADistrict.Text;
            string OfficerandDesignation = txtDMKAOfficerandDesignation.Text;
            string EMail = txtDMKAEMail.Text;
            string Telephone = txtDMKATelephone.Text;
            string Address = txtDMKAAddress.Text;

            txtDMKADistrict.Text = "";
            txtDMKAOfficerandDesignation.Text = "";
            txtDMKAEMail.Text = "";
            txtDMKATelephone.Text = "";
            txtDMKAAddress.Text = "";
            string query = "INSERT INTO [DM Kannada] VALUES(@District,@OfficerandDesignation,@EMail,@Telephone,@Address)";
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@District", District);
                    cmd.Parameters.AddWithValue("@OfficerandDesignation", OfficerandDesignation);
                    cmd.Parameters.AddWithValue("@EMail", EMail);
                    cmd.Parameters.AddWithValue("@Telephone", Telephone);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }
            this.DMKABindGrid();
        }

        protected void DMKAOnRowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDMKan.EditIndex = e.NewEditIndex;
            this.DMKABindGrid();
        }

        protected void DMKAOnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvDMKan.Rows[e.RowIndex];
            int SlNo = Convert.ToInt32(gvDMKan.DataKeys[e.RowIndex].Values[0]);
            string District = (row.FindControl("txtDMKADistrict") as TextBox).Text;
            string OfficerandDesignation = (row.FindControl("txtDMKAOfficerandDesignation") as TextBox).Text;
            string EMail = (row.FindControl("txtDMKAEMail") as TextBox).Text;
            string Telephone = (row.FindControl("txtDMKATelephone") as TextBox).Text;
            string Address = (row.FindControl("txtDMKAAddress") as TextBox).Text;
            string query = "UPDATE [DM Kannada] SET [District]=@District,[OfficerandDesignation]=@OfficerandDesignation ,[EMail]=@EMail,[Telephone]=@Telephone,[Address]=@Address WHERE [SlNo]=@SlNo";
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@SlNo", SlNo);
                    cmd.Parameters.AddWithValue("@District", District);
                    cmd.Parameters.AddWithValue("@OfficerandDesignation", OfficerandDesignation);
                    cmd.Parameters.AddWithValue("@EMail", EMail);
                    cmd.Parameters.AddWithValue("@Telephone", Telephone);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }
            gvDMKan.EditIndex = -1;
            this.DMKABindGrid();
        }

        protected void DMKAOnRowCancelingEdit(object sender, EventArgs e)
        {
            gvDMKan.EditIndex = -1;
            this.DMKABindGrid();
        }

        protected void DMKAOnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int SlNo = Convert.ToInt32(gvDMKan.DataKeys[e.RowIndex].Values[0]);
            string query = "DELETE FROM [DM Kannada] WHERE SlNo=@SlNo";
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@SlNo", SlNo);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }

            this.DMKABindGrid();
        }

        protected void DMKAOnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != gvDMKan.EditIndex)
            {
                (e.Row.Cells[6].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }

        protected void DMKAOnPaging(object sender, GridViewPageEventArgs e)
        {
            gvDMKan.PageIndex = e.NewPageIndex;
            this.DMKABindGrid();
        }

        private void DMENBindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString;
            string query = "SELECT * FROM [DM English]";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        gvDMENn.DataSource = dt;
                        gvDMENn.DataBind();
                    }
                }
            }
        }

        protected void DMENInsert(object sender, EventArgs e)
        {
            //string name = txtName.Text;
            //string country = txtCountry.Text;

            //int SlNo = Convert.ToInt32(gvDMENn.DataKeys[e.RowIndex].Values["SlNo"].ToString());
            string District = txtDMENDistrict.Text;
            string OfficerandDesignation = txtDMENOfficerandDesignation.Text;
            string EMail = txtDMENEMail.Text;
            string Telephone = txtDMENTelephone.Text;
            string Address = txtDMENAddress.Text;

            txtDMENDistrict.Text = "";
            txtDMENOfficerandDesignation.Text = "";
            txtDMENEMail.Text = "";
            txtDMENTelephone.Text = "";
            txtDMENAddress.Text = "";
            string query = "INSERT INTO [DM English] VALUES(@District,@OfficerandDesignation,@EMail,@Telephone,@Address)";
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@District", District);
                    cmd.Parameters.AddWithValue("@OfficerandDesignation", OfficerandDesignation);
                    cmd.Parameters.AddWithValue("@EMail", EMail);
                    cmd.Parameters.AddWithValue("@Telephone", Telephone);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }
            this.DMENBindGrid();
        }

        protected void DMENOnRowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDMENn.EditIndex = e.NewEditIndex;
            this.DMENBindGrid();
        }

        protected void DMENOnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvDMENn.Rows[e.RowIndex];
            int SlNo = Convert.ToInt32(gvDMENn.DataKeys[e.RowIndex].Values[0]);
            string District = (row.FindControl("txtDMENDistrict") as TextBox).Text;
            string OfficerandDesignation = (row.FindControl("txtDMENOfficerandDesignation") as TextBox).Text;
            string EMail = (row.FindControl("txtDMENEMail") as TextBox).Text;
            string Telephone = (row.FindControl("txtDMENTelephone") as TextBox).Text;
            string Address = (row.FindControl("txtDMENAddress") as TextBox).Text;
            string query = "UPDATE [DM English] SET [District]=@District,[OfficerandDesignation]=@OfficerandDesignation ,[EMail]=@EMail,[Telephone]=@Telephone,[Address]=@Address WHERE [SlNo]=@SlNo";
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@SlNo", SlNo);
                    cmd.Parameters.AddWithValue("@District", District);
                    cmd.Parameters.AddWithValue("@OfficerandDesignation", OfficerandDesignation);
                    cmd.Parameters.AddWithValue("@EMail", EMail);
                    cmd.Parameters.AddWithValue("@Telephone", Telephone);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }
            gvDMENn.EditIndex = -1;
            this.DMENBindGrid();
        }

        protected void DMENOnRowCancelingEdit(object sender, EventArgs e)
        {
            gvDMENn.EditIndex = -1;
            this.DMENBindGrid();
        }

        protected void DMENOnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int SlNo = Convert.ToInt32(gvDMENn.DataKeys[e.RowIndex].Values[0]);
            string query = "DELETE FROM [DM English] WHERE SlNo=@SlNo";
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@SlNo", SlNo);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }

            this.DMENBindGrid();
        }

        protected void DMENOnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != gvDMENn.EditIndex)
            {
                (e.Row.Cells[6].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }

        protected void DMENOnPaging(object sender, GridViewPageEventArgs e)
        {
            gvDMENn.PageIndex = e.NewPageIndex;
            this.DMENBindGrid();
        }

        private void ZMENBindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString;
            string query = "SELECT * FROM [ZM English]";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        gvZMENn.DataSource = dt;
                        gvZMENn.DataBind();
                    }
                }
            }
        }

        protected void ZMENInsert(object sender, EventArgs e)
        {
            //string name = txtName.Text;
            //string country = txtCountry.Text;

            //int SlNo = Convert.ToInt32(gvZMENn.DataKeys[e.RowIndex].Values["SlNo"].ToString());
            string District = txtZMENDistrict.Text;
            string OfficerandDesignation = txtZMENOfficerandDesignation.Text;
            string EMail = txtZMENEMail.Text;
            string Telephone = txtZMENTelephone.Text;
            string Address = txtZMENAddress.Text;

            txtZMENDistrict.Text = "";
            txtZMENOfficerandDesignation.Text = "";
            txtZMENEMail.Text = "";
            txtZMENTelephone.Text = "";
            txtZMENAddress.Text = "";
            string query = "INSERT INTO [ZM English] VALUES(@District,@OfficerandDesignation,@EMail,@Telephone,@Address)";
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@District", District);
                    cmd.Parameters.AddWithValue("@OfficerandDesignation", OfficerandDesignation);
                    cmd.Parameters.AddWithValue("@EMail", EMail);
                    cmd.Parameters.AddWithValue("@Telephone", Telephone);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }
            this.ZMENBindGrid();
        }

        protected void ZMENOnRowEditing(object sender, GridViewEditEventArgs e)
        {
            gvZMENn.EditIndex = e.NewEditIndex;
            this.ZMENBindGrid();
        }

        protected void ZMENOnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvZMENn.Rows[e.RowIndex];
            int SlNo = Convert.ToInt32(gvZMENn.DataKeys[e.RowIndex].Values[0]);
            string District = (row.FindControl("txtZMENDistrict") as TextBox).Text;
            string OfficerandDesignation = (row.FindControl("txtZMENOfficerandDesignation") as TextBox).Text;
            string EMail = (row.FindControl("txtZMENEMail") as TextBox).Text;
            string Telephone = (row.FindControl("txtZMENTelephone") as TextBox).Text;
            string Address = (row.FindControl("txtZMENAddress") as TextBox).Text;
            string query = "UPDATE [ZM English] SET [District]=@District,[OfficerandDesignation]=@OfficerandDesignation ,[EMail]=@EMail,[Telephone]=@Telephone,[Address]=@Address WHERE [SlNo]=@SlNo";
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@SlNo", SlNo);
                    cmd.Parameters.AddWithValue("@District", District);
                    cmd.Parameters.AddWithValue("@OfficerandDesignation", OfficerandDesignation);
                    cmd.Parameters.AddWithValue("@EMail", EMail);
                    cmd.Parameters.AddWithValue("@Telephone", Telephone);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }
            gvZMENn.EditIndex = -1;
            this.ZMENBindGrid();
        }

        protected void ZMENOnRowCancelingEdit(object sender, EventArgs e)
        {
            gvZMENn.EditIndex = -1;
            this.ZMENBindGrid();
        }

        protected void ZMENOnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int SlNo = Convert.ToInt32(gvZMENn.DataKeys[e.RowIndex].Values[0]);
            string query = "DELETE FROM [ZM English] WHERE SlNo=@SlNo";
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@SlNo", SlNo);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }

            this.ZMENBindGrid();
        }

        protected void ZMENOnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != gvZMENn.EditIndex)
            {
                (e.Row.Cells[6].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }

        protected void ZMENOnPaging(object sender, GridViewPageEventArgs e)
        {
            gvZMENn.PageIndex = e.NewPageIndex;
            this.ZMENBindGrid();
        }

        private void ZMKABindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString;
            string query = "SELECT * FROM [ZM Kannada]";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        gvZMKAn.DataSource = dt;
                        gvZMKAn.DataBind();
                    }
                }
            }
        }

        protected void ZMKAInsert(object sender, EventArgs e)
        {
            //string name = txtName.Text;
            //string country = txtCountry.Text;

            //int SlNo = Convert.ToInt32(gvZMKAn.DataKeys[e.RowIndex].Values["SlNo"].ToString());
            string District = txtZMKADistrict.Text;
            string OfficerandDesignation = txtZMKAOfficerandDesignation.Text;
            string EMail = txtZMKAEMail.Text;
            string Telephone = txtZMKATelephone.Text;
            string Address = txtZMKAAddress.Text;

            txtZMKADistrict.Text = "";
            txtZMKAOfficerandDesignation.Text = "";
            txtZMKAEMail.Text = "";
            txtZMKATelephone.Text = "";
            txtZMKAAddress.Text = "";
            string query = "INSERT INTO [ZM Kannada] VALUES(@District,@OfficerandDesignation,@EMail,@Telephone,@Address)";
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@District", District);
                    cmd.Parameters.AddWithValue("@OfficerandDesignation", OfficerandDesignation);
                    cmd.Parameters.AddWithValue("@EMail", EMail);
                    cmd.Parameters.AddWithValue("@Telephone", Telephone);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }
            this.ZMKABindGrid();
        }

        protected void ZMKAOnRowEditing(object sender, GridViewEditEventArgs e)
        {
            gvZMKAn.EditIndex = e.NewEditIndex;
            this.ZMKABindGrid();
        }

        protected void ZMKAOnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvZMKAn.Rows[e.RowIndex];
            int SlNo = Convert.ToInt32(gvZMKAn.DataKeys[e.RowIndex].Values[0]);
            string District = (row.FindControl("txtZMKADistrict") as TextBox).Text;
            string OfficerandDesignation = (row.FindControl("txtZMKAOfficerandDesignation") as TextBox).Text;
            string EMail = (row.FindControl("txtZMKAEMail") as TextBox).Text;
            string Telephone = (row.FindControl("txtZMKATelephone") as TextBox).Text;
            string Address = (row.FindControl("txtZMKAAddress") as TextBox).Text;
            string query = "UPDATE [ZM Kannada] SET [District]=@District,[OfficerandDesignation]=@OfficerandDesignation ,[EMail]=@EMail,[Telephone]=@Telephone,[Address]=@Address WHERE [SlNo]=@SlNo";
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@SlNo", SlNo);
                    cmd.Parameters.AddWithValue("@District", District);
                    cmd.Parameters.AddWithValue("@OfficerandDesignation", OfficerandDesignation);
                    cmd.Parameters.AddWithValue("@EMail", EMail);
                    cmd.Parameters.AddWithValue("@Telephone", Telephone);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }
            gvZMKAn.EditIndex = -1;
            this.ZMKABindGrid();
        }

        protected void ZMKAOnRowCancelingEdit(object sender, EventArgs e)
        {
            gvZMKAn.EditIndex = -1;
            this.ZMKABindGrid();
        }

        protected void ZMKAOnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int SlNo = Convert.ToInt32(gvZMKAn.DataKeys[e.RowIndex].Values[0]);
            string query = "DELETE FROM [ZM Kannada] WHERE SlNo=@SlNo";
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@SlNo", SlNo);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }

            this.ZMKABindGrid();
        }

        protected void ZMKAOnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != gvZMKAn.EditIndex)
            {
                (e.Row.Cells[6].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }

        protected void ZMKAOnPaging(object sender, GridViewPageEventArgs e)
        {
            gvZMKAn.PageIndex = e.NewPageIndex;
            this.ZMKABindGrid();
        }
        private void HOKABindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString;
            string query = "SELECT * FROM [HO Kannada]";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        gvHOKAn.DataSource = dt;
                        gvHOKAn.DataBind();
                    }
                }
            }
        }

        protected void HOKAInsert(object sender, EventArgs e)
        {
            //string name = txtName.Text;
            //string country = txtCountry.Text;

            //int SlNo = Convert.ToInt32(gvHOKAn.DataKeys[e.RowIndex].Values["SlNo"].ToString());
            string District = txtHOKADistrict.Text;
            string OfficerandDesignation = txtHOKAOfficerandDesignation.Text;
            string EMail = txtHOKAEMail.Text;
            string Telephone = txtHOKATelephone.Text;
            string Address = txtHOKAAddress.Text;

            txtHOKADistrict.Text = "";
            txtHOKAOfficerandDesignation.Text = "";
            txtHOKAEMail.Text = "";
            txtHOKATelephone.Text = "";
            txtHOKAAddress.Text = "";
            string query = "INSERT INTO [HO Kannada] VALUES(@District,@OfficerandDesignation,@EMail,@Telephone,@Address)";
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@District", District);
                    cmd.Parameters.AddWithValue("@OfficerandDesignation", OfficerandDesignation);
                    cmd.Parameters.AddWithValue("@EMail", EMail);
                    cmd.Parameters.AddWithValue("@Telephone", Telephone);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }
            this.HOKABindGrid();
        }

        protected void HOKAOnRowEditing(object sender, GridViewEditEventArgs e)
        {
            gvHOKAn.EditIndex = e.NewEditIndex;
            this.HOKABindGrid();
        }

        protected void HOKAOnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvHOKAn.Rows[e.RowIndex];
            int SlNo = Convert.ToInt32(gvHOKAn.DataKeys[e.RowIndex].Values[0]);
            string District = (row.FindControl("txtHOKADistrict") as TextBox).Text;
            string OfficerandDesignation = (row.FindControl("txtHOKAOfficerandDesignation") as TextBox).Text;
            string EMail = (row.FindControl("txtHOKAEMail") as TextBox).Text;
            string Telephone = (row.FindControl("txtHOKATelephone") as TextBox).Text;
            string Address = (row.FindControl("txtHOKAAddress") as TextBox).Text;
            string query = "UPDATE [HO Kannada] SET [District]=@District,[OfficerandDesignation]=@OfficerandDesignation ,[EMail]=@EMail,[Telephone]=@Telephone,[Address]=@Address WHERE [SlNo]=@SlNo";
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@SlNo", SlNo);
                    cmd.Parameters.AddWithValue("@District", District);
                    cmd.Parameters.AddWithValue("@OfficerandDesignation", OfficerandDesignation);
                    cmd.Parameters.AddWithValue("@EMail", EMail);
                    cmd.Parameters.AddWithValue("@Telephone", Telephone);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }
            gvHOKAn.EditIndex = -1;
            this.HOKABindGrid();
        }

        protected void HOKAOnRowCancelingEdit(object sender, EventArgs e)
        {
            gvHOKAn.EditIndex = -1;
            this.HOKABindGrid();
        }

        protected void HOKAOnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int SlNo = Convert.ToInt32(gvHOKAn.DataKeys[e.RowIndex].Values[0]);
            string query = "DELETE FROM [HO Kannada] WHERE SlNo=@SlNo";
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@SlNo", SlNo);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }

            this.HOKABindGrid();
        }

        protected void HOKAOnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != gvHOKAn.EditIndex)
            {
                (e.Row.Cells[6].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }

        protected void HOKAOnPaging(object sender, GridViewPageEventArgs e)
        {
            gvHOKAn.PageIndex = e.NewPageIndex;
            this.HOKABindGrid();
        }

        private void HOENBindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString;
            string query = "SELECT * FROM [HO English]";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        gvHOENn.DataSource = dt;
                        gvHOENn.DataBind();
                    }
                }
            }
        }

        protected void HOENInsert(object sender, EventArgs e)
        {
            //string name = txtName.Text;
            //string country = txtCountry.Text;

            //int SlNo = Convert.ToInt32(gvHOENn.DataKeys[e.RowIndex].Values["SlNo"].ToString());
            string District = txtHOENDistrict.Text;
            string OfficerandDesignation = txtHOENOfficerandDesignation.Text;
            string EMail = txtHOENEMail.Text;
            string Telephone = txtHOENTelephone.Text;
            string Address = txtHOENAddress.Text;

            txtHOENDistrict.Text = "";
            txtHOENOfficerandDesignation.Text = "";
            txtHOENEMail.Text = "";
            txtHOENTelephone.Text = "";
            txtHOENAddress.Text = "";
            string query = "INSERT INTO [HO English] VALUES(@District,@OfficerandDesignation,@EMail,@Telephone,@Address)";
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@District", District);
                    cmd.Parameters.AddWithValue("@OfficerandDesignation", OfficerandDesignation);
                    cmd.Parameters.AddWithValue("@EMail", EMail);
                    cmd.Parameters.AddWithValue("@Telephone", Telephone);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }
            this.HOENBindGrid();
        }

        protected void HOENOnRowEditing(object sender, GridViewEditEventArgs e)
        {
            gvHOENn.EditIndex = e.NewEditIndex;
            this.HOENBindGrid();
        }

        protected void HOENOnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvHOENn.Rows[e.RowIndex];
            int SlNo = Convert.ToInt32(gvHOENn.DataKeys[e.RowIndex].Values[0]);
            string District = (row.FindControl("txtHOENDistrict") as TextBox).Text;
            string OfficerandDesignation = (row.FindControl("txtHOENOfficerandDesignation") as TextBox).Text;
            string EMail = (row.FindControl("txtHOENEMail") as TextBox).Text;
            string Telephone = (row.FindControl("txtHOENTelephone") as TextBox).Text;
            string Address = (row.FindControl("txtHOENAddress") as TextBox).Text;
            string query = "UPDATE [HO English] SET [District]=@District,[OfficerandDesignation]=@OfficerandDesignation ,[EMail]=@EMail,[Telephone]=@Telephone,[Address]=@Address WHERE [SlNo]=@SlNo";
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@SlNo", SlNo);
                    cmd.Parameters.AddWithValue("@District", District);
                    cmd.Parameters.AddWithValue("@OfficerandDesignation", OfficerandDesignation);
                    cmd.Parameters.AddWithValue("@EMail", EMail);
                    cmd.Parameters.AddWithValue("@Telephone", Telephone);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }
            gvHOENn.EditIndex = -1;
            this.HOENBindGrid();
        }

        protected void HOENOnRowCancelingEdit(object sender, EventArgs e)
        {
            gvHOENn.EditIndex = -1;
            this.HOENBindGrid();
        }

        protected void HOENOnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int SlNo = Convert.ToInt32(gvHOENn.DataKeys[e.RowIndex].Values[0]);
            string query = "DELETE FROM [HO English] WHERE SlNo=@SlNo";
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@SlNo", SlNo);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }

            this.HOENBindGrid();
        }

        protected void HOENOnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != gvHOENn.EditIndex)
            {
                (e.Row.Cells[6].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }

        protected void HOENOnPaging(object sender, GridViewPageEventArgs e)
        {
            gvHOENn.PageIndex = e.NewPageIndex;
            this.HOENBindGrid();
        }

        protected void FillpwdGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT username,password FROM UserLogin"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        DataTable dt = new DataTable();
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                        gvUsers.DataSource = dt;
                        gvUsers.DataBind();
                    }
                }
            }
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Text = Decrypt(e.Row.Cells[1].Text);
            }
        }

        protected void UsrCreInsert(object sender, EventArgs e)
        {
            lblAddUserError.Text = "";
            if (txtUsrCreDistrict.SelectedIndex != 0)
            {
                if (txtUsrCreActive.SelectedIndex != 0)
                {
                    if (txtUsrCreUserType.SelectedIndex != 0)
                    {
                        if (txtUsrCreUserName.Text != "" && txtUsrCrePassword.Text != "")
                        {
                            if (txtUsrCrePassword.Text.Length >= 8)
                            {
                                SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM UserLogin where UserName='" + txtUsrCreUserName.Text + "'");
                                sqlCommand.Connection = kvdConn;
                                kvdConn.Open();
                                int RecordCount = Convert.ToInt32(sqlCommand.ExecuteScalar());
                                kvdConn.Close();
                                if (RecordCount == 0)
                                {

                                    string District = txtUsrCreDistrict.SelectedItem.Text;
                                    string UserName = txtUsrCreUserName.Text;
                                    string Password = Encrypt(txtUsrCrePassword.Text.Trim());
                                    string UserType = txtUsrCreUserType.Text;
                                    string Active = txtUsrCreActive.Text;

                                    txtUsrCreDistrict.SelectedIndex = 0;
                                    txtUsrCreUserName.Text = "";
                                    txtUsrCrePassword.Text = "";
                                    txtUsrCreUserType.Text = "";
                                    txtUsrCreActive.Text = "";
                                    string query = "INSERT INTO [UserLogin] VALUES(@District,@UserName,@Password,@UserType,@Active)";
                                    using (kvdConn)
                                    {
                                        using (SqlCommand cmd = new SqlCommand(query))
                                        {
                                            cmd.Parameters.AddWithValue("@District", District);
                                            cmd.Parameters.AddWithValue("@UserName", UserName);
                                            cmd.Parameters.AddWithValue("@Password", Password);
                                            cmd.Parameters.AddWithValue("@UserType", UserType);
                                            cmd.Parameters.AddWithValue("@Active", Active);
                                            cmd.Connection = kvdConn;
                                            kvdConn.Open();
                                            cmd.ExecuteNonQuery();
                                            kvdConn.Close();
                                        }
                                    }
                                    this.UsrCreBindGrid();
                                    this.FillpwdGrid();
                                }
                                else
                                {
                                    lblAddUserError.Text = "User Name Exist";
                                    lblAddUserError.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                            else
                            {
                                lblAddUserError.Text = "Password Must 8 to 16 Characters";
                                lblAddUserError.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        else
                        {
                            lblAddUserError.Text = "Enter All Details";
                            lblAddUserError.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        lblAddUserError.Text = "Select User Type";
                        lblAddUserError.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lblAddUserError.Text = "Select Status";
                    lblAddUserError.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblAddUserError.Text = "Select District";
                lblAddUserError.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void UsrCreOnRowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUsrCren.EditIndex = e.NewEditIndex;
            this.UsrCreBindGrid();
            this.FillpwdGrid();
        }
        private string Encrypt(string clearText)
        {
            string EncryptionKey = "KABA94ASBHSU143";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "KABA94ASBHSU143";
            // string EncryptisnKey = "KABA94ASBHSU143";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        protected void UsrCreOnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvUsrCren.Rows[e.RowIndex];
            int SlNo = Convert.ToInt32(gvUsrCren.DataKeys[e.RowIndex].Values[0]);
            string Active = (row.FindControl("txtUsrCreActive") as DropDownList).SelectedValue;
            string query = "UPDATE [UserLogin] SET [Active]=@Active WHERE [SlNo]=@SlNo";
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@SlNo", SlNo);

                    cmd.Parameters.AddWithValue("@Active", Active);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }
            gvUsrCren.EditIndex = -1;
            this.UsrCreBindGrid();
            this.FillpwdGrid();
        }

        protected void UsrCreOnRowCancelingEdit(object sender, EventArgs e)
        {
            gvUsrCren.EditIndex = -1;
            this.UsrCreBindGrid();
            this.FillpwdGrid();
        }
        private void UsrCreBindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString;
            string query = "SELECT [SlNo],[District],[UserName],[UserType],[Active] FROM [UserLogin]";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        gvUsrCren.DataSource = dt;
                        gvUsrCren.DataBind();
                    }
                }
            }
        }
        protected void UsrCreOnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int SlNo = Convert.ToInt32(gvUsrCren.DataKeys[e.RowIndex].Values[0]);
            string query = "DELETE FROM [UserLogin] WHERE SlNo=@SlNo";
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@SlNo", SlNo);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }

            this.UsrCreBindGrid();
            this.FillpwdGrid();
        }

        protected void UsrCreOnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != gvUsrCren.EditIndex)
            {
                (e.Row.Cells[5].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }

        protected void UsrCreOnPaging(object sender, GridViewPageEventArgs e)
        {
            gvUsrCren.PageIndex = e.NewPageIndex;
            this.UsrCreBindGrid();
            this.FillpwdGrid();
        }

        protected void btnUpdatePwd_Click(object sender, EventArgs e)
        {
            lblPwdError.Text = "";
            if (txtNewPassword.Text.Length >= 8)
            {
                if (drpUser.SelectedIndex != 0)
                {
                    string username = drpUser.SelectedItem.Text;
                    string pwd = Encrypt(txtNewPassword.Text.Trim());
                    string query = "UPDATE [UserLogin] SET [password]=@pwd WHERE [username]=@username";
                    using (kvdConn)
                    {
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Parameters.AddWithValue("@username", username);

                            cmd.Parameters.AddWithValue("@pwd", pwd);
                            cmd.Connection = kvdConn;
                            kvdConn.Open();
                            cmd.ExecuteNonQuery();
                            kvdConn.Close();
                        }
                    }
                    gvUsrCren.EditIndex = -1;
                    this.UsrCreBindGrid();
                    this.FillpwdGrid();
                }
                else
                {
                    lblPwdError.Text = "Select User";
                    lblPwdError.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblPwdError.Text = "Password Must 8 to 16 Characters";
                lblPwdError.ForeColor = System.Drawing.Color.Red;
            }


        }

        protected void FillSliderGrid()
        {
            string kvdConn = ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(kvdConn))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Slider", conn))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    gvSliderImg.DataSource = dt;
                    gvSliderImg.DataBind();
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }

        protected void btnSEMpicUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand("spMPICTargetUpdate", kvdConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SELLOAN", "SE");
                    cmd.Parameters.AddWithValue("@DISTRICT", drpSEMPICDistrict.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@SEPhysicalTarget", txtSEPhysical.Text);
                    cmd.Parameters.AddWithValue("@SEFinancialTarget", txtSEFinancial.Text);
                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }
            FillMpicGridViewDataBind();
            txtSEPhysical.Text = "";
            txtSEFinancial.Text = "";
            drpSEMPICDistrict.ClearSelection();
        }

        protected void btnARMpicUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand("spMPICTargetUpdate", kvdConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SELLOAN", "ARIVU");
                    cmd.Parameters.AddWithValue("@DISTRICT", drpARMPICDistrict.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@ARPhysicalTarget", txtARPhysical.Text);
                    cmd.Parameters.AddWithValue("@ARFinancialTarget", txtARFinancial.Text);
                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }
            FillMpicGridViewDataBind();
            txtARPhysical.Text = "";
            txtARFinancial.Text = "";
            drpARMPICDistrict.ClearSelection();
        }
        protected void FillMpicGridViewDataBind()
        {
            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                DataSet ds = new DataSet();
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("SELECT *  FROM [dbo].[MpicArivuTarget]", kvdConn);
                cmd.CommandType = CommandType.Text;
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    GvARMPICFill.DataSource = ds;
                    GvARMPICFill.DataBind();
                    
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GvARMPICFill.DataSource = ds;
                    GvARMPICFill.DataBind();
                    int columncount = GvARMPICFill.Rows[0].Cells.Count;
                    GvARMPICFill.Rows[0].Cells.Clear();
                    GvARMPICFill.Rows[0].Cells.Add(new TableCell());
                    GvARMPICFill.Rows[0].Cells[0].ColumnSpan = columncount;
                    GvARMPICFill.Rows[0].Cells[0].Text = "No Records Found";
                }
            }
            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                DataSet ds = new DataSet();
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("SELECT *  FROM [dbo].[MpicSelfEmpTarget]", kvdConn);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                kvdConn.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    GvSEMPICFill.DataSource = ds;
                    GvSEMPICFill.DataBind();

                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GvSEMPICFill.DataSource = ds;
                    GvSEMPICFill.DataBind();
                    int columncount = GvSEMPICFill.Rows[0].Cells.Count;
                    GvSEMPICFill.Rows[0].Cells.Clear();
                    GvSEMPICFill.Rows[0].Cells.Add(new TableCell());
                    GvSEMPICFill.Rows[0].Cells[0].ColumnSpan = columncount;
                    GvSEMPICFill.Rows[0].Cells[0].Text = "No Records Found";
                }
            }
        }

        protected void btnARRenewalEnable_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand("Update KACDCInfo set  [Arivu_Renewal]='" + drpARRenewal.Text + "' where id=1"))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = kvdConn;
                kvdConn.Open();
                Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                kvdConn.Close();
            }
        }

        protected void SliderOnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["Image"]);
                (e.Row.FindControl("ImgSlider") as Image).ImageUrl = imageUrl;
            }
        }

        protected void SliderUpload(object sender, EventArgs e)
        {
            byte[] bytes;
            string kvdConn = ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString;
            fs = FileSliderImg.PostedFile.InputStream;
            br = new BinaryReader(fs);
            bytes = br.ReadBytes((Int32)fs.Length);
            using (SqlConnection conn = new SqlConnection(kvdConn))
            {
                string sql = "INSERT INTO Slider VALUES(@Heading, @Captions, @Image)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Heading", txtSliderHeading.Text);
                    cmd.Parameters.AddWithValue("@Captions", txtSliderCaption.Text);
                    cmd.Parameters.AddWithValue("@Image", bytes);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            this.FillSliderGrid();
            //Response.Redirect(Request.Url.AbsoluteUri);
        }
        protected void SliderOnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int SlNo = Convert.ToInt32(gvSliderImg.DataKeys[e.RowIndex].Values[0]);
            string query = "DELETE FROM [Slider] WHERE SlNo=@SlNo";
            using (kvdConn)
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@SlNo", SlNo);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }

            this.FillSliderGrid();
        }
        protected void SliderOnPaging(object sender, GridViewPageEventArgs e)
        {
            gvSliderImg.PageIndex = e.NewPageIndex;
        }
    }
}