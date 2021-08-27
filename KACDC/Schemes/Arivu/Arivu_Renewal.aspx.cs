using iTextSharp.text.pdf;
using KACDC.Class.DataProcessing.FileProcessing.CreatePDF.ArivuRenewalAcknoledgement;
using KACDC.Class.DataProcessing.OnlineApplication.Arivu;
using KACDC.Class.Declaration.OnlineApplication;
using KACDC.Class.FileSaving;
using KACDC.CreateTextSharpPDF.Process;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using iTextSharp.text;
using iTextSharp.text.pdf;
using KACDC.Class.CreateLog;
using KACDC.Class.DataProcessing.Aadhaar;
using KACDC.Class.DataProcessing.BankData;
using KACDC.Class.DataProcessing.Nadakacheri;
using KACDC.Class.DataProcessing.OnlineApplication;
using KACDC.Class.Declaration.Aadhaar;
using KACDC.Class.Declaration.BankDetails;
using KACDC.Class.Declaration.CollegeData;
using KACDC.Class.Declaration.Nadakacheri;
using KACDC.Class.Declaration.OnlineApplication;
using KACDC.Class.FileSaving;
using KACDC.CreateTextSharpPDF.Process;
using KACDC.CreateTextSharpPDF.Schemes.Arivu;
using KACDC.CreateTextSharpPDF.Schemes.SelfEmployment;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KACDC.Class.DataProcessing.FileProcessing.CreatePDF;

namespace KACDC.Schemes.Arivu
{
    public partial class Arivu_Renewal : System.Web.UI.Page
    {
        ArRenewalProcess ARP = new ArRenewalProcess();
        ArRenewalDec ARRD = new ArRenewalDec();
        SaveFile SF = new SaveFile();
        HeadingTable HT = new HeadingTable();
        GenerateRenewalAcknolegdement ARGA = new GenerateRenewalAcknolegdement();
        SignatureTable ST = new SignatureTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    kvdConn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM KACDCSettings where KeyVal=@Key"))
                    {
                        cmd.Parameters.AddWithValue("@Key", "ArivuRenewalEnable");
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = kvdConn;
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            if (bool.Parse(sdr["Value"].ToString().ToUpper()) != true)
                            {
                                Response.Redirect(@"~\Default.aspx");
                            }
                        }
                    }
                    kvdConn.Close();
                }
            }
        }
        protected void btntest_click(object sender, EventArgs e)
        {

        }
        protected void btnconfirm_Click(object sender, EventArgs e)
        {

        }
        protected void btnGetOTP_Click(object sender, EventArgs e)
        {
            lblApplicationNumberError.Text = "";
            if (txtApplicationNumber.Text.Trim() != "")
            {
                if (txtApplicationNumber.Text.Trim().Length >= 16)
                {
                    if(ARP.CheckApplicatDetails(txtApplicationNumber.Text.Trim(), "CHECKAPPLICATIONEXIST") != "NA")
                    {
                        divVerifyOTP.Visible = true;
                        ARRD.ApplicationNumber= txtApplicationNumber.Text.Trim();
                    }
                    else
                    {
                        lblApplicationNumberError.Text = "Enter Valid Application Number";
                        DisplayAlert("Enter Valid Application Number", this);
                        txtApplicationNumber.Focus();
                    }
                }
                else
                {
                    lblApplicationNumberError.Text = "Enter Valid Application Number";
                    DisplayAlert("Enter Valid Application Number", this);
                    txtApplicationNumber.Focus();
                }
            }
            else
            {
                lblApplicationNumberError.Text = "Enter Application Number";
                DisplayAlert("Enter Application Number", this);
                txtApplicationNumber.Focus();
            }
            
        }
        protected void btnVerifyOTP_Click(object sender, EventArgs e)
        {
            lblOTPError.Text = "";
            if (txtOTP.Text.Trim() != "")
            {
                if (txtOTP.Text.Trim().Length == 15)
                {
                    if (ARP.CheckApplicatDetails(txtApplicationNumber.Text.Trim(), "GETAPPLICANTLOGINCODE") == txtOTP.Text.Trim())
                    {
                        CheckInstallment();
                        if (ARRD.Installment!="NA")
                        {
                            divUploadFiles.Visible = true;
                            divVerifyOTP.Visible = false;
                            txtApplicationNumber.ReadOnly = true;
                            btnGetOTP.Visible = false;
                        }
                    }
                    else
                    {
                        lblOTPError.Text = "Enter Valid Passcode ";
                        DisplayAlert("Enter Valid Passcode ", this);
                        txtOTP.Focus();
                    }
                }
                else
                {
                    lblOTPError.Text = "Enter Valid Passcode ";
                    DisplayAlert("Enter Valid Passcode ", this);
                    txtOTP.Focus();
                }
            }
            else
            {
                lblOTPError.Text = "Enter Passcode ";
                DisplayAlert("Enter Passcode ", this);
                txtOTP.Focus();
            }
        }
        private void CheckInstallment()
        {
            ARRD.Installment = ARP.CheckApplicatDetails(txtApplicationNumber.Text.Trim(), "GETREQUESTINGYEAR");
            ARRD.FILENAME = ARP.CheckApplicatDetails(txtApplicationNumber.Text.Trim(), "GETAPPLICANTFILENAME");
            ARRD.MOBILENUMBER = ARP.CheckApplicatDetails(txtApplicationNumber.Text.Trim(), "GETMOBILENUMBER");
            ARRD.APPLICANTNAME = ARP.CheckApplicatDetails(txtApplicationNumber.Text.Trim(), "GETAPPLICANTNAME");
            ARRD.GETEMAILID = ARP.CheckApplicatDetails(txtApplicationNumber.Text.Trim(), "GETEMAILID") != "" ? ARP.CheckApplicatDetails(txtApplicationNumber.Text.Trim(), "GETEMAILID") : "";
            if (ARRD.Installment == "2ND_INSTALMENT")
                ARRD.DBInstallment = "Y2Release";
            if (ARRD.Installment == "3RD_INSTALMENT")
                ARRD.DBInstallment = "Y3Release";
            if (ARRD.Installment == "4TH_INSTALMENT")
                ARRD.DBInstallment = "Y4Release";
            if (ARRD.Installment == "5TH_INSTALMENT")
                ARRD.DBInstallment = "Y5Release";
            if (ARRD.Installment == "6TH_INSTALMENT")
                ARRD.DBInstallment = "Y6Release";
            lblApplicantName.Text = ARRD.APPLICANTNAME;
            lblApplicationNumber.Text = txtApplicationNumber.Text.Trim();
        }
        protected void btnUploadPrevMarksCard_Click(object sender, EventArgs e)
        {
            if (FilePrevMarksCard.HasFile)
            {
                string name = FilePrevMarksCard.FileName + Path.GetExtension(FilePrevMarksCard.FileName);
                string fileExtension = Path.GetExtension(FilePrevMarksCard.FileName);

                if (name.Contains(".exe") && name.Contains(".msi") && name.Contains(".etc") && name.Contains(".dll") && name.Contains(".dat") && fileExtension.ToLower() != ".pdf")
                {
                    DisplayAlert("Only PDF file allowed", this);
                }
                else
                {
                    int fileSize = FilePrevMarksCard.PostedFile.ContentLength;
                    if (fileSize < 51300)
                    {
                        DisplayAlert("Minimun size 50KB ", this);
                    }
                    else if (fileSize > 512000)
                    {
                        DisplayAlert("File size Exceeded.. Maximum size 500KB", this);
                    }

                    else
                    {
                        FilePrevMarksCard.SaveAs(Server.MapPath("~/ImageUpload/" + FilePrevMarksCard.FileName));
                        DisplayAlert("File Uploaded successfully", this);
                        Stream fs = FilePrevMarksCard.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        ARRD.bytePrevMarksCard = br.ReadBytes((Int32)fs.Length);
                        ARRD.PrevMarksCard = (true.ToString());
                    }
                }
            }
            else
            {
                DisplayAlert("File not uploaded", this);
            }
        }
        protected void btnUploadStudyCertificate_Click(object sender, EventArgs e)
        {
            if (FileStudyCertificate.HasFile)
            {
                string name = FileStudyCertificate.FileName + Path.GetExtension(FileStudyCertificate.FileName);
                string fileExtension = Path.GetExtension(FileStudyCertificate.FileName);

                if (name.Contains(".exe") && name.Contains(".msi") && name.Contains(".etc") && name.Contains(".dll") && name.Contains(".dat") && fileExtension.ToLower() != ".pdf")
                {
                    DisplayAlert("Only PDF file allowed", this);
                }
                else
                {
                    int fileSize = FileStudyCertificate.PostedFile.ContentLength;
                    if (fileSize < 51300)
                    {
                        DisplayAlert("Minimun size 50KB ", this);
                    }
                    else if (fileSize > 512000)
                    {
                        DisplayAlert("File size Exceeded.. Maximum size 500KB", this);
                    }

                    else
                    {
                        FileStudyCertificate.SaveAs(Server.MapPath("~/ImageUpload/" + FileStudyCertificate.FileName));
                        DisplayAlert("File Uploaded successfully", this);
                        Stream fs = FileStudyCertificate.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        ARRD.byteStudyCertificate = br.ReadBytes((Int32)fs.Length);
                        ARRD.StudyCertificate = (true.ToString());
                    }
                }
            }
            else
            {
                DisplayAlert("File not uploaded", this);
            }
        }
        protected void btnSubmitRenewalRequest_Click(object sender, EventArgs e)
        {
            //if (bool.Parse((ARRD.StudyCertificate)))
            //{
            //    if (bool.Parse((ARRD.PrevMarksCard)))
            //    {
            //        if (ARRD.byteStudyCertificate!=null)
            //        {
            //            if (ARRD.bytePrevMarksCard != null)
            //            {
            //                if (ARP.UpdateRenewalRequest(ARRD.ApplicationNumber,"YES")!="NA")
            //                {
            //                    GenerateAcknoledgement();
            //                    SF.SavingFileOnServer("~/Files_Arivu/" + ARRD.Installment + "/StudyCertificate/", ARRD.FILENAME + ".pdf", ARRD.byteStudyCertificate);
            //                    SF.SavingFileOnServer("~/Files_Arivu/" + ARRD.Installment + "/PreviousMarksCard/", ARRD.FILENAME + ".pdf", ARRD.bytePrevMarksCard);
            //                }
            //                else
            //                {
            //                    DisplayAlert("try again later",this);
            //                }
            //            }
            //        }
            //    }
            //}
            GenerateAcknoledgement();
        }
        private void GenerateAcknoledgement()
        {
            
            PdfPTable HeadingTable = null;
            HeadingTable = new PdfPTable(4);
            HeadingTable = HT.GenerateHeadingARRenewal(HeadingTable, "ARIVU EDUCATIONAL LOAN", DateTime.Now.ToString("MM/dd/yyyy hh:mm:sss tt"));

            PdfPTable Table = new PdfPTable(4);
            Table = ARGA.ApplicantMainTable(Table,ARRD.ApplicationNumber,ARRD.APPLICANTNAME,ARRD.MOBILENUMBER,ARRD.Installment );

            PdfPTable SignatureTable = null;
            SignatureTable = new PdfPTable(4);
            SignatureTable = ST.GenerateSignatureTable(SignatureTable);


            Document pdfDoc = new Document(PageSize.A5, 0, 0, 35, 0);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();


                pdfDoc.Add(HeadingTable);
                pdfDoc.Add(Table);
                pdfDoc.Add(SignatureTable);

                pdfDoc.Add(new Phrase("", FontFactory.GetFont(BaseFont.TIMES_ROMAN, 13, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                pdfDoc.Add(new Phrase("", FontFactory.GetFont(BaseFont.TIMES_ROMAN, 13, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                pdfDoc.Add(new Phrase("", FontFactory.GetFont(BaseFont.TIMES_ROMAN, 13, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                pdfDoc.Add(new Phrase(" Note: \n    This letter must be submitted at the time of document verification. ", FontFactory.GetFont(BaseFont.TIMES_ROMAN, 13, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));

                pdfDoc.Close();
                byte[] bytes = memoryStream.ToArray();



                //var img = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Image/KACDC_PDF.png"));
                //img.SetAbsolutePosition(100, 200);
                //PdfContentByte waterMark;

                //PdfReader reader = new PdfReader(bytes);
                //using (PdfStamper stamper = new PdfStamper(reader, memoryStream))
                //{
                //    int pages = reader.NumberOfPages;
                //    for (int i = 1; i <= pages; i++)
                //    {
                //        //waterMark = stamper.GetUnderContent(i);
                //        //waterMark.AddImage(img);
                //        PdfContentByte under = stamper.GetUnderContent(i);
                //        Rectangle pagesize = reader.GetPageSize(i);
                //        float x = (pagesize.Left + pagesize.Right) / 2;
                //        float y = (pagesize.Bottom + pagesize.Top) / 2;
                //        PdfGState gs = new PdfGState();
                //        gs.FillOpacity = 0.3f;
                //        under.SaveState();
                //        under.SetGState(gs);
                //        under.SetRGBColorFill(200, 200, 0);
                //        waterMark = stamper.GetUnderContent(i);
                //        waterMark.AddImage(img);
                //        under.RestoreState();
                //    }
                //}


                //bytes = memoryStream.ToArray();



                memoryStream.Close();
                Response.Clear();

                SaveFile SV = new SaveFile();
                SV.SavingFileOnServer(Server.MapPath("~/Files_Arivu/" + ARRD.Installment + "/RenewalRequestCopy/"), ARRD.FILENAME + ".pdf", bytes);

                AddPDFWaterMark WM = new AddPDFWaterMark();
                WM.PdfStampInExistingFile(Server.MapPath("~/Files_Arivu/" + ARRD.Installment + "/RenewalRequestCopy/") + ARRD.FILENAME + ".pdf", Server.MapPath("~/Image/KACDC_PDF.png"));

                if (File.Exists(Server.MapPath("~/Files_Arivu/" + ARRD.Installment + "/RenewalRequestCopy/") + ARRD.FILENAME + ".pdf"))
                {
                    if (ARRD.GETEMAILID != "")
                    {
                        SendSMSEmail();
                    }
                }
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                Response.AddHeader("Content-Disposition", "attachment; filename=" + ARRD.FILENAME + ".pdf");
                Response.ContentType = "application/pdf";
                Response.Buffer = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();
            }
        }
        private bool SendSMSEmail()
        {
            SubmitApplicationSMS SMS = new SubmitApplicationSMS();
            ApplicationSubmitEmail EMAIL = new ApplicationSubmitEmail();
            //SMS.ApplicantSMSConfirmation(ODAR.MobileNumber, ODAR.GeneratedApplicationNumber, "Self Employment", ADSER.Name);
            EMAIL.ApplicantEmailConfirmation(ARRD.GETEMAILID, ARRD.ApplicationNumber, "Arivu Education Loan Renewal Request", ARRD.APPLICANTNAME,
                File.ReadAllBytes(Server.MapPath("~/Files_Arivu/" + ARRD.Installment + "/RenewalRequestCopy/") + ARRD.FILENAME + ".pdf"),
                ARRD.FILENAME + ".pdf");
            return true;
        }
        protected void btnDownloadAcknolegdement_Click(object sender, EventArgs e)
        {

        }
        protected void btnTryAgain_Click(object sender, EventArgs e)
        {

        }
        protected void btnDownloadFormat_Click(object sender, EventArgs e)
        {

        }
        protected void rbCollegeHostel_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        public static void DisplayAlert(string message, Control owner)
        {
            Page page = (owner as Page) ?? owner.Page;
            if (page == null) return;

            //page.ClientScript.RegisterStartupScript(owner.GetType(),"ShowMessage", string.Format("<script type='text/javascript'>alert('{0}')</script>",
            //    message));
            ScriptManager.RegisterClientScriptBlock(owner, owner.GetType(), "alertMessage", "alert('" + message.ToUpper() + "')", true);
        }

        
    }
}