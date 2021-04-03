using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Collections;
using System.Web.Configuration;
using System.Web.Services;
using System.Text.RegularExpressions;
using KACDC.Class;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Drawing.Text;
using iTextSharp.text.html;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using KACDC.CreateTextSharpPDF.Schemes.SelfEmployment;
using KACDC.CreateTextSharpPDF.Process;

namespace KACDC
{
    public partial class TestBa : System.Web.UI.Page
    {
        SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
        NadaKacheri_SelfEmployment NCSE = new NadaKacheri_SelfEmployment();
        BankDetails_SelfEmployment BD = new BankDetails_SelfEmployment();


        ApplicantPDFTable APPLITAB = new ApplicantPDFTable();
        BankTable BT = new BankTable();
        AgreementTable AT = new AgreementTable();
        SignatureTable ST = new SignatureTable();
        HeadingTable HT = new HeadingTable();
        private string ApplicantMobileNumber
        {
            set { ViewState["ApplicantMobileNumber"] = value; }
            get { return ViewState["ApplicantMobileNumber"] as string; }
        }
        private string ApplicantRDNumber
        {
            set { ViewState["ApplicantRDNumber"] = value; }
            get { return ViewState["ApplicantRDNumber"] as string; }
        }
        private string ApplicantMobileNumberVerification
        {
            set { ViewState["ApplicantMobileNumberVerification"] = value; }
            get { return ViewState["ApplicantMobileNumberVerification"] as string; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            NCSE.SMSSendUrl = "http://smspush.openhouseplatform.com/smsmessaging/1/outbound/tel%3A%2BKAVDES/requests";
            NCSE.SMSMessageSendingKey = "79ebcb3a-68b9-48c1-877b-b4d6948236d1";
//            NCSE.SMSMessageSendingKey = "bbbe7d22-b12b-412e-92d4-f484b3655cbe";
            NCSE.SMSNotifyURL = "httpS://http://kacdc.karnataka.gov.in//";
            //txtArPhy.Text = "bjsbahd";
            if (!IsPostBack)
            {
                //SegvReleaseBindGrid();
                //BindSecondaryGrid();

                DataTable dt = new DataTable();
                dt.Columns.Add("EndDate", typeof(DateTime));
                dt.Rows.Add("2021-03-08 17:00:34.943");
                DateTime startDate = DateTime.Now;
                DateTime endDate = Convert.ToDateTime(dt.Rows[0]["EndDate"].ToString());
                //lblTime.Text = CalculateTimeDifference(startDate, endDate);

                SqlDataAdapter FillDistric1 = new SqlDataAdapter("SELECT DistrictCD, NC_District_Name_Kan FROM MstDistrict where NC_District_Name_Kan like N'%ಬೆಂಗಳೂರು%'", kvdConn);
                DataTable dtDistric1 = new DataTable();
                FillDistric1.Fill(dtDistric1);
                drpContDistrict.DataSource = dtDistric1;
                drpContDistrict.DataBind();
                drpContDistrict.DataTextField = "NC_District_Name_Kan";
                drpContDistrict.DataValueField = "NC_District_Name_Kan";
                drpContDistrict.DataBind();
                drpContDistrict.Items.Insert(0, "--SELECT--");
            }
            if (!this.IsPostBack)
            {
                System.Web.UI.WebControls.ListItem item1 = new System.Web.UI.WebControls.ListItem("Camel", "1");
                item1.Attributes["OptionGroup"] = "Mammals";

                System.Web.UI.WebControls.ListItem item2 = new System.Web.UI.WebControls.ListItem("Lion", "2");
                item2.Attributes["OptionGroup"] = "Mammals";


                System.Web.UI.WebControls.ListItem item7 = new System.Web.UI.WebControls.ListItem("Triceratops", "7");
                item7.Attributes["OptionGroup"] = "Dinosaurs";

                System.Web.UI.WebControls.ListItem item8 = new System.Web.UI.WebControls.ListItem("Stegosaurus", "8");
                item8.Attributes["OptionGroup"] = "Dinosaurs";

                System.Web.UI.WebControls.ListItem item9 = new System.Web.UI.WebControls.ListItem("Tyrannosaurus", "9");
                item9.Attributes["OptionGroup"] = "Dinosaurs";


                ddlItems.Items.Add(item1);
                ddlItems.Items.Add(item2);
               
                ddlItems.Items.Add(item7);
                ddlItems.Items.Add(item8);
                ddlItems.Items.Add(item9);
            }
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            if (IsPostBack)
            {
                SessionUpdate();
            }
            if (!IsPostBack)
            {
                SessionUpdate();
            }
            application.Attributes["src"] = "~/Image/APRIL.pdf#toolbar=0";// D:\KACDC WebPortal - Copy (2)\KACDC\KACDC\Image\GOK.png
        }
        protected void ViewApplication(object sender, EventArgs e)
        {
            Document pdfDoc = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
            Phrase phrase = null;
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            StringWriter sw = new StringWriter();
            //PdfWriter.GetInstance(pdfDoc, memoryStream);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();

                pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan"));
                pdfDoc.Close();
                //byte[] result = memoryStream.ToArray();
                byte[] result = System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/Image/APRIL.pdf"));

                string base64 = Convert.ToBase64String(result, 0, result.Length);

                string pdfframesrc = "data:Application/pdf;base64,{0}" + base64;
                //application.Attributes["src"] = pdfframesrc + ".pdf#toolbar=0";
                application.Attributes["src"] = "~/Image/APRIL.pdf";
            }
        }
        protected PdfPTable PrintPageHeading(Phrase phrase, string LoanName)
        {
            PdfPTable table = null;
            //Create Header Table
            table = new PdfPTable(4);
            table.TotalWidth = 550f;
            table.LockedWidth = true;
            table.SetWidths(new float[] { 0.2f, 0.3f, 0.3f, 0.2f });
            PageHeader(table, phrase, LoanName);
            return table;
        }
        protected PdfPTable PageHeader(PdfPTable table, Phrase phrase, string LoanType)
        {
            string FinancialYear = "";
            table.AddCell(AddLogo("~/Image/GOK_PDF.png", phrase, PdfPCell.ALIGN_LEFT)); //GOV Logo  
            PdfPCell nested = NameAddr(LoanType, FinancialYear, phrase, DateTime.Now.ToString("dd MMMM yyyy hh:mm tt"));
            nested.Colspan = 2;
            table.AddCell(nested);//Page Heading
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
                cell = new PdfPCell(new Phrase(new Chunk(cellText, FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK))));
                cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#008000"));
                cell.BorderColor = BaseColor.WHITE;
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
            cell = ImageCell(Path, 30f, align, BaseColor.WHITE);
            return cell;
        }

        private static PdfPCell TableHeader(string Headding, int ColSpanCount)
        {
            PdfPCell cell = null;
            cell = new PdfPCell(new Phrase(new Chunk(Headding, FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD, BaseColor.BLACK))));
            cell.Colspan = ColSpanCount;
            cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            cell.PaddingBottom = 3f;
            cell.Border = 0;
            cell.Padding = 5;
            return cell;
        }
        private static PdfPCell NameAddr(string LoanName, string FinancialYear, Phrase phrase, string Date)
        {
            //PdfPCell cell = null;
            //phrase = new Phrase();
            //Paragraph p1 = new Paragraph();
            //Paragraph p2 = new Paragraph();
            //Paragraph p3 = new Paragraph();


            //p1.Add(new Chunk("KARNATAKA ARYA VYSYA COMMUNITY DEVELOPMENT CORPORATION\n", FontFactory.GetFont("sans-serif", 15, iTextSharp.text.Font.BOLD, BaseColor.RED)));
            //p2.Add(new Chunk(LoanName + " ( " + FinancialYear + " )" + "\n", FontFactory.GetFont("sans-serif", 13, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
            ////phrase.Add(new Chunk("Year of: " + FinancialYear + "\n", FontFactory.GetFont("sans-serif", 12, Font.NORMAL, BaseColor.BLACK)));
            ////phrase.Add(new Chunk("District: " + District + "\n", FontFactory.GetFont("sans-serif", 12, Font.NORMAL, BaseColor.BLACK)));
            //p3.Add(new Chunk("Date: " + Date, FontFactory.GetFont("sans-serif", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
            //p1.SpacingAfter = 50;
            //p2.SpacingAfter = 50;
            //p3.SpacingAfter = 50;
            //phrase.Add(p1);
            //phrase.Add(p2);
            //phrase.Add(p3);
            //cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER);
            //cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            PdfPCell cell = null;
            phrase = new Phrase();
            BaseColor color = new BaseColor(123, 0, 0);
            phrase.Add(new Chunk("KARNATAKA ARYA VYSYA COMMUNITY DEVELOPMENT CORPORATION\n", FontFactory.GetFont("sans-serif", 15, iTextSharp.text.Font.BOLD, color)));
            phrase.Add(new Chunk("\n", FontFactory.GetFont("sans-serif", 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
            phrase.Add(new Chunk(LoanName.ToUpper() + " ( " + FinancialYear + " )" + "\n", FontFactory.GetFont("sans-serif", 13, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
            phrase.Add(new Chunk("\n", FontFactory.GetFont("sans-serif", 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
            //phrase.Add(new Chunk("Year of: " + FinancialYear + "\n", FontFactory.GetFont("sans-serif", 12, Font.NORMAL, BaseColor.BLACK)));
            //phrase.Add(new Chunk("District: " + District + "\n", FontFactory.GetFont("sans-serif", 12, Font.NORMAL, BaseColor.BLACK)));
            phrase.Add(new Chunk("Date: " + Date, FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)));
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
        private static PdfPCell ImageCell(string path, float scale, int align, BaseColor CellBorderColer)
        {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
            image.ScalePercent(scale);
            PdfPCell cell = new PdfPCell(image);
            cell.BorderColor = CellBorderColer;
            cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 0f;
            cell.PaddingTop = 2f;
            return cell;
        }
        protected void SessionUpdate()
        {
            Session["Reset"] = true;
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.Config");
            SessionStateSection section = (SessionStateSection)config.GetSection("system.web/sessionState");
            int timeout = (int)section.Timeout.TotalMinutes * 1000 * 60;
            //int timeout = (int)section.Timeout.TotalMinutes * 1000 * 60;
            ClientScript.RegisterStartupScript(this.GetType(), "SessionAlert", "SessionExpireAlert(" + timeout + ");", true);
        }

        protected void btnGetOTP_Click(object sender, EventArgs e)
        {
            if (txtApplicantMobileNumber.Text.Trim() != null)
            {
                if (txtApplicantMobileNumber.Text.Trim() != "")
                {
                    if (txtApplicantMobileNumber.Text.Trim().Length == 10)
                    {
                        if (long.TryParse(txtApplicantMobileNumber.Text.Trim(), out _))
                        {
                            if (Regex.IsMatch(txtApplicantMobileNumber.Text.Trim(), @"^\d+$"))
                            {
                                NCSE.OTP = NewOTP();
                                SendOTPMessage(txtApplicantMobileNumber.Text.Trim());
                                ///////////////////////////////////lblOTP.Text = NCSE.OTP;
                                ///////////////////////////////////divMobileOTP.Visible = true;
                                txtApplicantMobileNumber.Enabled = false;
                                btnGetOTP.Enabled = false;
                                ApplicantMobileNumber = txtApplicantMobileNumber.Text.Trim();
                            }
                        }
                    }
                }
            }
        }






        protected string NewOTP()
        {
            string numbers = "1234567890";

            string characters = numbers;
            string otp = string.Empty;
            for (int i = 0; i < 8; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }
            return otp;
        }
        protected void SendOTPMessage(string MobNumber)
        {
            try
            {
                if (NCSE.OTP != null)
                {
                    if (MobNumber != "")
                    {
                        //GeneratedOTP = NewOTP();
                        //txtOTP.Visible = true;

                        //----
                        //string txt_MobNum = "9740560748";
                        //Define the json object to be sent with request.
                        string strMainContent = "{\"outboundSMSMessageRequest\":{" +
                                          "\"address\":[\"" + "!strMobileNo!" + "\"]," +
                                          "\"senderAddress\":\"" + "!senderAddress!" + "\"," +
                                          "\"outboundSMSTextMessage\":{\"message\":\"" + "!strMsg!" + "\"}," +
                                          "\"clientCorrelator\":\"" + "!clientCorrelator!" + "\"," +
                                          "\"messageType\":\"" + "!messageType!" + "\"," +
                                          "\"category\":\"" + "!category!" + "\"," +
                                         "\"receiptRequest\":{\"notifyURL\":\"" + "!notifyURL!" + "\"," +
                                          "\"callbackData\":\"$(" + "!callbackData!" + ")\"}," +
                                          "\"senderName\":\"" + "!senderName!" + "\"}}";

                        //Replace all the parametersin above defined json object

                        //Replace senderAddress in RequestURL:
                        NCSE.SMSSendUrl = NCSE.SMSSendUrl.Replace("$(senderAddress)", "GKACDC");

                        //It is Optional to prefix 'tel:'
                        string mbnumber = "91" + MobNumber;
                        strMainContent = strMainContent.Replace("!strMobileNo!", "tel:+" + mbnumber);

                        //senderAddress can be alphanumeric
                        strMainContent = strMainContent.Replace("!senderAddress!", "GKACDC");
                        strMainContent = strMainContent.Replace("!category!", "GKACDC-Employment");
                        strMainContent = strMainContent.Replace("!messageType!", "");

                        string cont = "Dear Applicant your One Time Password(OTP) is " + NCSE.OTP + " to Apply Self Employment Application . Don't Share this with anyone From KACDC";
                        strMainContent = strMainContent.Replace("!strMsg!", cont);
                        //strMainContent = strMainContent.Replace("!clientCorrelator!", clientCorrelator);
                        strMainContent = strMainContent.Replace("!notifyURL!", NCSE.SMSNotifyURL);
                        //strMainContent = strMainContent.Replace("!callbackData!", callbackData);
                        strMainContent = strMainContent.Replace("!senderName!", "GKACDC");

                        //POST the request with JSON Object
                        string retval;
                        retval = DoPostRequest(NCSE.SMSSendUrl, strMainContent);
                        DisplayAlert("OTP Sent to your Registered Mobile Number", this);

                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "Select District" + "')", true);
                        //DisplayAlert(retval, this);
                        //DisplayAlert(MobNumber+" "+ ApplicaName, this);
                        ///////////////////////////////////txtOTP.Visible = true;
                        //txtAppNum.Enabled = false;
                        //txtAppNum.CssClass = "rowMargin txtcolor text-uppercase text-lg-center";
                        //btnGenerate.Text = "Resend OTP";
                        ///////////////////////////////////btnVerifyOTP.Visible = true;
                        //----
                    }
                    else
                    {
                        //txtAppNum.Text = "";
                        //txtOTP.Visible = false;
                        //btnVerifyOTP.Visible = false;
                        //lblError.Text = "Application Not Exist, Check Provided Information";
                    }
                }
            }
            catch(Exception ex)
            {
                DisplayAlert(ex.Message,this);
            }
        }
        private string DoPostRequest(string strURL, string strData)
        {
            //Store the returned value(A json object in this case). 
            string strRetVal = string.Empty;
            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback =
                   ((sender, certificate, chain, sslPolicyErrors) => true);
                //Create a request using a URL that can receive a post.
                HttpWebRequest objReq = WebRequest.Create(strURL) as HttpWebRequest;

                //Set the Method property of the request to POST.
                objReq.Method = "POST";

                //Set the Request Timeout.
                objReq.Timeout = 50000;

                //Put key as header
                objReq.Headers.Add("key", NCSE.SMSMessageSendingKey);

                //Set the ContentType property of the WebRequest.
                objReq.ContentType = "application/json";

                //Create POST data and convert it to a byte array.
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(strData);
                objReq.ContentLength = byteArray.Length;

                //Get the request stream.
                using (Stream dataStream = objReq.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }

                //Write the data to the request stream.
                using (HttpWebResponse objRes = objReq.GetResponse() as HttpWebResponse)
                {
                    StreamReader objSr = new StreamReader(objRes.GetResponseStream());
                    strRetVal = objSr.ReadToEnd();
                }

                // MessageBox.Show("Message Sent successfuly.", "Success!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DisplayAlert(ex.Message,this);
                strRetVal = "eRROR";
                //MessageBox.Show("Unable to send message", "Failed!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //strRetVal = "Unable to Process Request.";
            }
            return strRetVal;
        }
        public static void DisplayAlert(string message, Control owner)
        {
            Page page = (owner as Page) ?? owner.Page;
            if (page == null) return;

            //page.ClientScript.RegisterStartupScript(owner.GetType(),"ShowMessage", string.Format("<script type='text/javascript'>alert('{0}')</script>",
            //    message));
            ScriptManager.RegisterClientScriptBlock(owner, owner.GetType(), "alertMessage", "alert('" + message + "')", true);
        }




















        protected void btnTestGetData_Click(object sender, EventArgs e)
        {
            XElement xElement;
            XmlDocument xmlDocument = new XmlDocument();
            XmlDocument xmlContant = new XmlDocument();
            NadaKacheriServiceReference.WebServiceSoapClient GetXmlDataWoDSCV_Client = new NadaKacheriServiceReference.WebServiceSoapClient("WebServiceSoap");
            xElement = GetXmlDataWoDSCV_Client.GetXmlDataWoDSCV(txtRDNum.Text.Trim());
            //xElement = GetXmlDataWoDSCV_Client.GetXmlDataWoDSCV("RD0038750142124");
            //xElement = xElement.Replace(Environment.NewLine, String.Empty);
            string xml = HttpUtility.HtmlDecode(xElement.Element("xmlData").ToString()).Replace("\r", "").Replace("\n", "").Replace("{Text = \"", "").Replace("\"", "")
                .Replace("{", "").Replace("}", "").Replace("\"", "");
            //xmlDocument = xElement.FirstNode;
            lbldecode.Text = xElement.Element("Language").Value.ToString(); 
            xmlContant.LoadXml(xml);
            lbldecode.Text = xmlContant.SelectSingleNode("xmlData/CasteCertificate/ApplicantDetails/HabitationName").ToString();
            lbldecode.Text = xmlContant.SelectSingleNode("xmlData/CasteCertificate/ApplicantDetails/HabitationName").ToString();
            XmlNodeList nodeList = xmlContant.GetElementsByTagName("ApplicantDetails");
            foreach (XmlNode nodeRes in nodeList)
            {
                lbldecode.Text = nodeRes["HabitationName"].InnerText;
                lbldecode.Text=xElement.Element("Language").Value.ToString();
            }

            IEnumerable<XElement> Data = xElement.Elements();
            // string atr =xElement.Attribute("xmlData").ToString();
            xmlDocument.LoadXml(xElement.ToString());
            XmlNodeList parentNode = xmlDocument.GetElementsByTagName("CasteCertificate");
            XmlNode root = xmlDocument.SelectSingleNode("/SMSWSOP");
            //string a =root.ChildNodes[].ToString();
            lbldecode.Text = xElement.Element("Language").Value.ToString();



            //XmlNode root = xElement.;




            string Status = xElement.Element("Status").ToString();
            string StatusMsg = xElement.Element("StatusMsg").ToString();
            string FacilityCode = xElement.Element("FacilityCode").ToString();
            string FacilityName = xElement.Element("FacilityName").ToString();
            XElement ApplicantData = xElement.Element("xmlData");
            //string ApplicantFatherName = ApplicantData.Element("ApplicantFatherName").ToString();
            //string c3 = (string)xElement.Element("AnnualIncome");
            string result = GetXmlDataWoDSCV_Client.GetXmlDataWoDSCV("RD0038109138130").ToString();
            //lblresult.Text = Status + " status <br />"+ StatusMsg + "status message <br />"+ FacilityCode+"<br />"+FacilityName;
            //lblresult.Text = ApplicantFatherName;
            NadaKacheriServiceReference.WebServiceSoapClient NCWebService = new NadaKacheriServiceReference.WebServiceSoapClient("WebServiceSoap");
            NadaKacheriServiceReference.CheckGSCNumberRequestBody NCRequestBody = new NadaKacheriServiceReference.CheckGSCNumberRequestBody(txtRDNum.Text.Trim());
            NadaKacheriServiceReference.CheckGSCNumberRequest NCRequest = new NadaKacheriServiceReference.CheckGSCNumberRequest(NCRequestBody);
            NadaKacheriServiceReference.CheckGSCNumberResponseBody NCResponseBody = new NadaKacheriServiceReference.CheckGSCNumberResponseBody();
            NadaKacheriServiceReference.CheckGSCNumberResponse NCResonse = new NadaKacheriServiceReference.CheckGSCNumberResponse(NCResponseBody);
            //NadaKacheriServiceReference.GetXmlDataWoDSCVRequestBody result = NCWebService.GetXmlDataWoDSCVRequestBody(txtRDNum.Text.Trim());
            //if (result != null)
            //{
            //    lblresult.Text = result.ToString();
            //}
        }
        private void SegvReleaseBindGrid()
        {
            using (kvdConn)
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                DataSet ds = new DataSet();
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }
                SqlCommand cmd = new SqlCommand("SELECT * FROM SelfEmpLoan", kvdConn);
                cmd.CommandType = CommandType.Text;
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
        }

        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            GetData();
            SetData();
            BindSecondaryGrid();
        }
        private void BindSecondaryGrid()
        {
            DataTable dt = (DataTable)ViewState["SelectedRecords"];
            gvSelected.DataSource = dt;
            gvSelected.DataBind();
        }
        private void SetData()
        {
            CheckBox chkAll = (CheckBox)gvZMSERelease.HeaderRow.Cells[0].FindControl("chkAll");
            chkAll.Checked = true;
            if (ViewState["SelectedRecords"] != null)
            {
                DataTable dt = (DataTable)ViewState["SelectedRecords"];
                for (int i = 0; i < gvZMSERelease.Rows.Count; i++)
                {
                    CheckBox chk = (CheckBox)gvZMSERelease.Rows[i].Cells[0].FindControl("chk");
                    if (chk != null)
                    {
                        DataRow[] dr = dt.Select("ApplicationNumber = '" + gvZMSERelease.Rows[i].Cells[1].Text + "'");
                        chk.Checked = dr.Length > 0;
                        if (!chk.Checked)
                        {
                            chkAll.Checked = false;
                        }
                    }
                }
            }
        }
        private DataTable CreateDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ApplicationNumber");
            dt.Columns.Add("ApplicantName");
            dt.Columns.Add("AccountNumber");
            dt.AcceptChanges();
            return dt;
        }
        private void GetData()
        {
            DataTable dt;
            if (ViewState["SelectedRecords"] != null)
                dt = (DataTable)ViewState["SelectedRecords"];
            else
                dt = CreateDataTable();
            CheckBox chkAll = (CheckBox)gvZMSERelease.HeaderRow.Cells[0].FindControl("chkAll");
            for (int i = 0; i < gvZMSERelease.Rows.Count; i++)
            {
                if (chkAll.Checked)
                {
                    dt = AddRow(gvZMSERelease.Rows[i], dt);
                }
                else
                {
                    CheckBox chk = (CheckBox)gvZMSERelease.Rows[i].Cells[0].FindControl("chk");
                    if (chk.Checked)
                    {
                        dt = AddRow(gvZMSERelease.Rows[i], dt);
                    }
                    else
                    {
                        dt = RemoveRow(gvZMSERelease.Rows[i], dt);
                    }
                }
            }
            ViewState["SelectedRecords"] = dt;
        }
        private DataTable AddRow(GridViewRow gvRow, DataTable dt)
        {
            DataRow[] dr = dt.Select("ApplicationNumber = '" + gvRow.Cells[1].Text + "'");
            if (dr.Length <= 0)
            {
                dt.Rows.Add();
                dt.Rows[dt.Rows.Count - 1]["ApplicationNumber"] = gvRow.Cells[1].Text;
                dt.Rows[dt.Rows.Count - 1]["ApplicantName"] = gvRow.Cells[2].Text;
                dt.Rows[dt.Rows.Count - 1]["AccountNumber"] = gvRow.Cells[3].Text;
                dt.AcceptChanges();
            }
            return dt;
        }
        private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
        {
            DataRow[] dr = dt.Select("ApplicationNumber = '" + gvRow.Cells[1].Text + "'");
            if (dr.Length > 0)
            {
                dt.Rows.Remove(dr[0]);
                dt.AcceptChanges();
            }
            return dt;
        }

        protected void btnGetBankData_Click(object sender, EventArgs e)
        {
            string json = (new WebClient()).DownloadString("https://ifsc.razorpay.com/" + txtIFSC.Text.Trim());



            var details = JObject.Parse(json);
            lblIFSCData.Text = details["BRANCH"].ToString();
            //XmlDocument doc = JsonConvert.DeserializeXmlNode("<root>"+json+"</root>");
            //XmlDocument xmlApplicantDetails = JsonConvert.DeserializeXmlNode(json);
            //xmlApplicantDetails.LoadXml(xml);
            //lblIFSCData.Text = json;
            //lblIFSCData.Text= doc.InnerText;


            //XmlNodeList nodeList = xmlApplicantDetails.GetElementsByTagName("JSON");
            //foreach (XmlNode nodeRes in nodeList)
            //{
            //    lblIFSCData.Text = nodeRes["BRANCH"].InnerText;

            //}
            //GridView1.DataSource = JsonConvert.DeserializeObject<DataTable>(json);
            //GridView1.DataBind();
        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            btnSessionUpdate_Click(sender, e);
            SessionUpdate();
            //input = kannad part to convert
            //string languagePair = "kn|en";  //i.e kannad to english
            //string url = String.Format("http://www.google.com/translate_t?hl=en&ie=UTF8&text={0}&langpair={1}", txtInput.Text.Trim(), languagePair);

            //WebClient webClient = new WebClient();

            //webClient.Encoding = System.Text.Encoding.UTF8;

            string result = TranslateText(txtInput.Text.Trim());
            lblOutput.Text = result;
            DisplayAlert("Test Alert", this);
        }
        public string TranslateText(string input)
        {
            // Set the language from/to in the url (or pass it into this function)
            string url = String.Format
            ("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
             "kn", "en", Uri.EscapeUriString(input));
            HttpClient httpClient = new HttpClient();
            string result = httpClient.GetStringAsync(url).Result;

            // Get all json data
            var jsonData = new JavaScriptSerializer().Deserialize<List<dynamic>>(result);

            // Extract just the first array element (This is the only data we are interested in)
            var translationItems = jsonData[0];

            // Translation Data
            string translation = "";

            // Loop through the collection extracting the translated objects
            foreach (object item in translationItems)
            {
                // Convert the item array to IEnumerable
                IEnumerable translationLineObject = item as IEnumerable;

                // Convert the IEnumerable translationLineObject to a IEnumerator
                IEnumerator translationLineString = translationLineObject.GetEnumerator();

                // Get first object in IEnumerator
                translationLineString.MoveNext();

                // Save its value (translated text)
                translation += string.Format(" {0}", Convert.ToString(translationLineString.Current));
            }

            // Remove first blank character
            if (translation.Length > 1) { translation = translation.Substring(1); };

            // Return translation
            return translation;
        }

        [WebMethod]
        public void AlertFromServer()
        {
            DisplayAlert("From Server", this);
        }


        protected void btnSessionUpdate_Click(object sender, EventArgs e)
        {
            Session["Reset"] = true;
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.Config");
            SessionStateSection section = (SessionStateSection)config.GetSection("system.web/sessionState");
            int timeout = (int)section.Timeout.TotalMinutes * 1000 * 60;
            //int timeout = (int)section.Timeout.TotalMinutes * 1000 * 60;
            ClientScript.RegisterStartupScript(this.GetType(), "SessionAlert", "SessionExpireAlert(" + timeout + ");", true);
        }
        public string CalculateTimeDifference(DateTime startDate, DateTime endDate)
        {
            int days = 0; int hours = 0; int mins = 0; int secs = 0;
            string final = string.Empty;
            if (endDate > startDate)
            {
                days = (endDate - startDate).Days;
                hours = (endDate - startDate).Hours;
                mins = (endDate - startDate).Minutes;
                secs = (endDate - startDate).Seconds;
                final = string.Format("{0} days {1} hours {2} mins {3} secs", days, hours, mins, secs);
            }
            return final;
        }
        protected PdfPCell PrintCell(string Text, string FontName, int size, int TextStyle, BaseColor TextColor, float MinCellHeight, int HAlign, int VAlign)
        {
            PdfPCell cell;      
            cell = new PdfPCell(new Phrase(new Chunk(UppercaseFirst(Text), FontFactory.GetFont(FontName, size, TextStyle, TextColor))));
            cell.MinimumHeight = MinCellHeight;
            cell.VerticalAlignment = VAlign;
            cell.HorizontalAlignment = HAlign;
            cell.BorderColor = BaseColor.WHITE;
            cell.PaddingTop = 15f;
            cell.PaddingBottom = 15f;
            return cell;
        }
        protected PdfPCell PrintHeaderCell(string Text, string FontName, int size, int TextStyle, BaseColor TextColor, float MinCellHeight, int HAlign, int VAlign)
        {
            PdfPCell cell;
            cell = new PdfPCell(new Phrase(new Chunk(UppercaseFirst(Text), FontFactory.GetFont(FontName, size, TextStyle, TextColor))));
            cell.MinimumHeight = MinCellHeight;
            cell.VerticalAlignment = VAlign;
            cell.HorizontalAlignment = HAlign;
            cell.BorderColor = BaseColor.BLACK;
            cell.PaddingTop = -1f;
            cell.PaddingBottom = -1f;
            cell.BorderWidth = 2f;
            return cell;
        }
        protected string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
        public class UnicodeFontFactory : FontFactoryImp
        {
            private static readonly string FontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arialuni.ttf");

            private readonly BaseFont _baseFont;

            public UnicodeFontFactory()
            {
                _baseFont = BaseFont.CreateFont(FontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            }

            //public override Font GetFont(string fontname, string encoding, bool embedded, float size, int style, BaseColor color, bool cached)
            //{
            //    return new Font(_baseFont, size, style, color);
            //}
        }
        public iTextSharp.text.Image ConvertTextToImage(string text, string fontname, int fontsize, Color bgcolor, Color fcolor)
        {
            text = text.Replace("<br />", "\n").Replace("<br/>", "\n");
            Bitmap bitmap = new Bitmap(1, 1);
            System.Drawing.Font font11 = new System.Drawing.Font("Arial", 50, FontStyle.Regular, GraphicsUnit.Pixel);
            Graphics graphics = Graphics.FromImage(bitmap);
            int width = (int)graphics.MeasureString(text, font11).Width;
            int height = (int)graphics.MeasureString(text, font11).Height;
            bitmap = new Bitmap(bitmap, new Size(width, height));
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(bgcolor);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            graphics.DrawString(text, font11, new SolidBrush(fcolor), 0, 0);
            graphics.Flush();
            graphics.Dispose();
            iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(bitmap, System.Drawing.Imaging.ImageFormat.Jpeg);
            return pdfImage;
        }
        private PdfPCell GenerateCell(string Englisg,int fontSize,string Kannada, float scale,string FontName=BaseFont.TIMES_ROMAN)
        {
            BaseFont bf = BaseFont.CreateFont(FontName, BaseFont.CP1252, false);

            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, fontSize, iTextSharp.text.Font.NORMAL);
            PdfPCell cell = new PdfPCell();
            Paragraph p = new Paragraph();
            p.SpacingAfter = 0f;
            p.Leading = 10f;
            p.Add(new Phrase( Englisg, FontFactory.GetFont(FontName, fontSize, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
            cell.AddElement(p);
            iTextSharp.text.Image KannadaImage = ConvertTextToImage(Kannada, "sans-serif", 10, Color.White, Color.Black);
            KannadaImage.ScalePercent(scale);
            cell.AddElement(KannadaImage);
            cell.BorderColor = BaseColor.WHITE;
            return cell;
            
        }
        public iTextSharp.text.Image ConvertTextToImagePAddress(string text, string fontname, int fontsize, Color bgcolor, Color fcolor)
        {
            text = text.Replace("<br />", "\n").Replace("<br/>", "\n");
            Bitmap bitmap = new Bitmap(1, 1);
            System.Drawing.Font font11 = new System.Drawing.Font("sans-serif", 50, FontStyle.Regular, GraphicsUnit.Pixel);
            Graphics graphics = Graphics.FromImage(bitmap);
            int width = (int)graphics.MeasureString(text, font11).Width;
            int height = (int)graphics.MeasureString(text, font11).Height;
            bitmap = new Bitmap(bitmap, new Size(width, height));
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(bgcolor);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            graphics.DrawString(text, font11, new SolidBrush(fcolor), 0, 0);
            graphics.Flush();
            graphics.Dispose();
            iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(bitmap, System.Drawing.Imaging.ImageFormat.Jpeg);
            text = "";
            return pdfImage;
        }
        public iTextSharp.text.Image ConvertTextToImageCAddress(string text, string fontname, int fontsize, Color bgcolor, Color fcolor)
        {
            text = text.Replace("<br />", "\n").Replace("<br/>", "\n");
            Bitmap bitmap = new Bitmap(1, 1);
            System.Drawing.Font font11 = new System.Drawing.Font("sans-serif", 50, FontStyle.Regular, GraphicsUnit.Pixel);
            Graphics graphics = Graphics.FromImage(bitmap);
            int width = (int)graphics.MeasureString(text, font11).Width;
            int height = (int)graphics.MeasureString(text, font11).Height;
            bitmap = new Bitmap(bitmap, new Size(width, height));
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(bgcolor);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            graphics.DrawString(text, font11, new SolidBrush(fcolor), 0, 0);
            graphics.Flush();
            graphics.Dispose();
            iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(bitmap, System.Drawing.Imaging.ImageFormat.Jpeg);
            text = "";
            return pdfImage;
        }
        public string GenerateMultiLineTextAreaPAddress(string value, int length)
        {
            if (value.Length <= length && value.Length != 0)
            {

                TextArea.Append($"{value.PadRight(length)}");
            }
            else
            {
                TextArea.Append($"{value.Substring(0, length).ToString()}".PadLeft(length) + "\r\n");
                value = value.Substring(length, (value.Length) - (length));
                GenerateMultiLineTextAreaPAddress(value, length);
            }
            return TextArea.ToString();
        }
        public string GenerateMultiLineTextAreaCAddress(string value, int length)
        {
            if (value.Length <= length && value.Length != 0)
            {

                TextArea.Append($"{value.PadRight(length)}");
            }
            else
            {
                TextArea.Append($"{value.Substring(0, length).ToString()}".PadLeft(length) + "\r\n");
                value = value.Substring(length, (value.Length) - (length));
                GenerateMultiLineTextAreaCAddress(value, length);
            }
            return TextArea.ToString();
        }
        protected void btnpdfprint_Click(object sender, EventArgs e)
        {
            string SelfEnglish = "I hereby certify that the above furnished information is true to my knowledge. I shall abide by the terms and conditions of the sanction of the Arivu Education Loan. If any discrepancies are found later, I agree to take legal action against me.";
            string SelfKannada = "\n ಈ ಮೇಲ್ಕಂಡ ಮಾಹಿತಿಗಳು  ನನಗೆ ತಿಳಿದ ಮಟ್ಟಿಗೆ ಸತ್ಯ ಮತ್ತು  ಸರಿಯಾಗಿವೆಯೆಂದು ಪ್ರಮಾಣೀಕರಿಸುತ್ತೇನೆ.  ಒಂದು ವೇಳೆ ಮೇಲ್ಕಂಡ  ಮಾಹಿತಿಗಳು ಸುಳ್ಳು ಎಂದು \n ಕಂಡುಬಂದಲ್ಲಿ ನನ್ನ ವಿರುದ್ಧ ಕಾನೂನು ರೀತಿಯ ಕ್ರಮ ಜರುಗಿಸಲು ಒಪ್ಪಿರುತ್ತೇನೆ.";
            string AadhaarEnglish = "I hereby provide my consent to Karnataka Arya Vysya Community Development Corporation (Government of Karnataka Undertaking) to use my Aadhaar Number for performing all such validations, which may be required to verify the correctness of the data either provided by me or associated with me under schemes with whom I am enrolled for. I understand that the use of my Aadhaar Number will be restricted to the extent required for efficient delivery of benefits to me by the State Government.";
            string AadhaarKannada = "\n ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ ಸಮುದಾಯ ಅಭಿವೃದ್ಧಿ ನಿಗಮ(ಕರ್ನಾಟಕ ಸರ್ಕಾರದ ಉದ್ಯಮ) ಕ್ಕೆ ನನ್ನ  ಆಧಾರ್ ಸಂಖ್ಯೆಯನ್ನು ಬಳಸಲು  ಈ ಮೂಲಕ ನಾನು ಒಪ್ಪಿಗೆಯನ್ನು\n ನೀಡುತ್ತಿದ್ದೇನೆ. ನನ್ನಿಂದ ಒದಗಿಸಲಾದ ಅಥವಾ ನನ್ನೊಂದಿಗೆ ಸಂಯೋಜಿತವಾಗಿರುವ ಮಾಹಿತಿ ನಿಖರತೆಯನ್ನು ಪರಿಶೀಲಿಸಲು ಅಗತ್ಯವಿರುವ ಎಲ್ಲಾ ಮೌಲ್ಯಮಾಪನಗಳನ್ನು \n ನಿರ್ವಹಿಸಲು ಅಗತ್ಯವಾಗಿರುವುದರಿಂದ ನನ್ನ ಆಧಾರ್ ಸಂಖ್ಯೆಯ ಬಳಕೆಯನ್ನು ರಾಜ್ಯ ಸರ್ಕಾರವು ನನಗೆ ಸವಲತ್ತುಗಳನ್ನು ಸಮರ್ಪಕವಾಗಿ ತಲುಪಿಸಲು ಮಿತಗೊಂಡಿರುತ್ತದೆ \n ಎಂದು ನಾನು ಅರ್ಥಮಾಡಿಕೊಂಡಿರುತ್ತೇನೆ.";
            string ShareEnglish = "I hereby provide my consent to Karnataka Arya Vysya Community Development Corporation (Government of Karnataka Undertaking) to use my Aadhaar Number for performing all such validations, which may be required to verify the correctness of the data either provided by me or associated with me under schemes with whom I am enrolled for. I understand that the use of my Aadhaar Number will be restricted to the extent required for efficient delivery of benefits to me by the State Government.";
            string ShareKannada = "\n ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ ಸಮುದಾಯ ಅಭಿವೃದ್ಧಿ ನಿಗಮ(ಕರ್ನಾಟಕ ಸರ್ಕಾರದ ಉದ್ಯಮ) ಕ್ಕೆ ನನ್ನ  ಆಧಾರ್ ಸಂಖ್ಯೆಯನ್ನು ಬಳಸಲು  ಈ ಮೂಲಕ ನಾನು ಒಪ್ಪಿಗೆಯನ್ನು\n ನೀಡುತ್ತಿದ್ದೇನೆ. ನನ್ನಿಂದ ಒದಗಿಸಲಾದ ಅಥವಾ ನನ್ನೊಂದಿಗೆ ಸಂಯೋಜಿತವಾಗಿರುವ ಮಾಹಿತಿ ನಿಖರತೆಯನ್ನು ಪರಿಶೀಲಿಸಲು ಅಗತ್ಯವಿರುವ ಎಲ್ಲಾ ಮೌಲ್ಯಮಾಪನಗಳನ್ನು \n ನಿರ್ವಹಿಸಲು ಅಗತ್ಯವಾಗಿರುವುದರಿಂದ ನನ್ನ ಆಧಾರ್ ಸಂಖ್ಯೆಯ ಬಳಕೆಯನ್ನು ರಾಜ್ಯ ಸರ್ಕಾರವು ನನಗೆ ಸವಲತ್ತುಗಳನ್ನು ಸಮರ್ಪಕವಾಗಿ ತಲುಪಿಸಲು ಮಿತಗೊಂಡಿರುತ್ತದೆ \n ಎಂದು ನಾನು ಅರ್ಥಮಾಡಿಕೊಂಡಿರುತ್ತೇನೆ.";

            
            PdfPTable HeadingTable = null;
            HeadingTable = new PdfPTable(4);
            HeadingTable = HT.GenerateHeading(HeadingTable, "Self Employment Loan");
            //pdfDoc.Add(GenerateHeading(phrase, "Self Employment Loan"));
            PdfPTable Table = null;
            Table = new PdfPTable(4);
            Table = APPLITAB.SEApplicantMainTable(Table);
            PdfPTable BankTable = null;
            BankTable = new PdfPTable(4);
            BankTable = BT.GenerateBankTable(BankTable);
            PdfPTable AgreeTable = null;
            AgreeTable = new PdfPTable(4);
            AgreeTable = AT.GenerateAgreementTable(AgreeTable, SelfEnglish, SelfKannada, AadhaarEnglish, AadhaarKannada, ShareEnglish, ShareKannada);
            PdfPTable SignatureTable = null;
            SignatureTable = new PdfPTable(4);
            SignatureTable = ST.GenerateSignatureTable(SignatureTable);



            Document pdfDoc = new Document(PageSize.A4, 0, 0, 35, 0);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();
                pdfDoc.Add(HeadingTable);
                pdfDoc.Add(Table);
                pdfDoc.Add(BankTable);
                pdfDoc.Add(AgreeTable);
                pdfDoc.Add(SignatureTable);

                pdfDoc.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                Response.Clear();
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                string fname = "EmpFile";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fname + ".pdf");
                Response.ContentType = "application/pdf";
                Response.Buffer = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();
            }
        }
        protected void btnpdfprint_Click1(object sender, EventArgs e)
        {
            Document pdfDoc = new Document(PageSize.A4, 0, 0, 35, 0);
            //PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            Phrase phrase = null;
            //PdfPCell cell = null;
            PdfPTable table = null;
            
            PdfPTable BankTable = null;
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            //pdfDoc.Open();
            int Center = PdfPCell.ALIGN_CENTER;
            int VCenter = PdfPCell.ALIGN_MIDDLE;
            int Left = PdfPCell.ALIGN_LEFT;
            //int Justify = PdfPCell.ALIGN_JUSTIFIED;
            //BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\fonts\ArialUni.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\fonts\tunga.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            string arialuniTff = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALUNI.TTF");
            iTextSharp.text.FontFactory.Register(arialuniTff);
            //List<IElement> list = HTMLWorker.ParseToList(new StringReader(stringBuilder.ToString()), ST);

            iTextSharp.text.html.simpleparser.StyleSheet ST = new iTextSharp.text.html.simpleparser.StyleSheet();
            ST.LoadTagStyle(HtmlTags.BODY, HtmlTags.FACE, "Arial Unicode MS");
            ST.LoadTagStyle(HtmlTags.BODY, HtmlTags.ENCODING, BaseFont.IDENTITY_H);


            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();
                table = new PdfPTable(4);
               

                table.TotalWidth = 550f;
                table.LockedWidth = true;
                table.SetWidths(new float[] { 0.3f, 0.4f, 0.3f, 0.4f });

                BankTable = new PdfPTable(4);
                BankTable.TotalWidth = 550f;
                BankTable.LockedWidth = true;
                BankTable.SetWidths(new float[] { 0.3f, 0.4f, 0.3f, 0.4f });

                pdfDoc.Add(PrintPageHeading(phrase, "Self Employment Loan"));
                PdfPCell cellWithRowspan = new PdfPCell(ImageCell("~/Image/KACDC_PDF.png", 30f, PdfPCell.ALIGN_CENTER, BaseColor.BLACK));

                //System.Drawing.Image imageBIt = ConvertTextToImage("ಈ ಮೇಲ್ಕಂಡ ಮಾಹಿತಿಗಳು ನನಗೆ ತಿಳಿದ<br />ABCjhk", "Arial", 10, Color.Yellow, Color.Black);
                //iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(imageBIt, System.Drawing.Imaging.ImageFormat.Jpeg);
                //pdfImage.ScaleToFit( 0.3f, 0.4f, 0.3f, 0.4f );

                //Row 2
                table.AddCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                PdfPCell cell = new PdfPCell(PrintHeaderCell("- Applicant Details -".ToUpper(), "sans-serif", 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Center, VCenter));
                cell.Colspan = 2;
                table.AddCell(cell);
                table.AddCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));


                //Row 2
                table.AddCell(GenerateCell("Application Number",12, "ಅರ್ಜಿ ಸಂಖ್ಯೆ", 20f));
                table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                table.AddCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                table.AddCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

                //Row 3
                table.AddCell(GenerateCell("NAME", 12, "ಹೆಸರು", 20f));
                table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                table.AddCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                // Applicant Photo
                cellWithRowspan.Rowspan = 5;
                cellWithRowspan.BorderColor = BaseColor.WHITE;
                table.AddCell(cellWithRowspan);

                //Row 4
                table.AddCell(GenerateCell("Father / Guardian Name", 12, "ತಂದೆ / ರಕ್ಷಕರ ಹೆಸರು", 20f));
                table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                table.AddCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

                //Row 5
                table.AddCell(GenerateCell("Gender", 12, "ಲಿಂಗ", 20f));
                table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                table.AddCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

                //Row 6
                table.AddCell(GenerateCell("DOB", 12, "ಜನ್ಮ ದಿನಾಂಕ", 20f));
                table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                table.AddCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

                //Row 7
                table.AddCell(GenerateCell("Emai ID", 12, "ಇ-ಮೇಲ್ ಐಡಿ", 20f));
                table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                table.AddCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

                //Row 8
                
                table.AddCell(GenerateCell("Person With Disablities", 12, "ತಂದೆ / ರಕ್ಷಕರ ಹೆಸರು", 20f));
                table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                table.AddCell(GenerateCell("Anual Income", 12, "ವಾರ್ಷಿಕ ಆದಾಯ", 20f));
                table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

                //Row 9

                table.AddCell(GenerateCell("Purpose of Loan", 12, "ಸಾಲದ ಉದ್ದೇಶ", 20f));
                table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                table.AddCell(GenerateCell("Description of Loan", 12, "ಸಾಲದ ವಿವರಣೆ", 20f));
                table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

                //Row 10
                table.AddCell(GenerateCell("Mobile Number", 12, "ಮೊಬೈಲ್ ಸಂಖ್ಯೆ", 20f));
                table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                table.AddCell(GenerateCell("Alternate Mobile Number", 12, "ಪರ್ಯಾಯ ಮೊಬೈಲ್ ಸಂಖ್ಯೆ", 20f));
                table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

                
                //Row 
                table.AddCell(GenerateCell("RD Number", 12, "R D ಸಂಖ್ಯೆ", 20f));
                table.AddCell(PrintCell("VERIFIED", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                table.AddCell(GenerateCell("Aadhar", 12, "ಆಧಾರ್", 20f));
                table.AddCell(PrintCell("VERIFIED", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

                //Row 10
                table.AddCell(GenerateCell("Parmanent Address", 12, "ಶಾಶ್ವತ ವಿಳಾಸ", 20f));
                PdfPCell FullAddresscell;

                iTextSharp.text.Image FullAddressImage = ConvertTextToImagePAddress(GenerateMultiLineTextAreaPAddress("ಅನವಾಲ , ಬಾದಾಮಿ, ಬಾಗಲಕೋಟ", 18), "sans-serif", 10, Color.White, Color.Black);
                FullAddressImage.ScalePercent(20f);


                FullAddresscell = new PdfPCell(FullAddressImage);
                FullAddresscell.VerticalAlignment = VCenter;
                FullAddresscell.HorizontalAlignment = Left;
                FullAddresscell.BorderColor = BaseColor.WHITE;

                table.AddCell(FullAddresscell);



                table.AddCell(GenerateCell("Contact Address", 12, "ಸಂಪರ್ಕ ವಿಳಾಸ", 20f));
                PdfPCell ContactAddresscell;

                string Caddress = GenerateMultiLineTextAreaCAddress("ಮದು ಬಸವರಾಜ ಬಿಜಾಪುರ", 18);
                iTextSharp.text.Image ContactFullAddressImage = ConvertTextToImageCAddress(Caddress, "sans-serif", 10, Color.White, Color.Black);
                ContactFullAddressImage.ScalePercent(20f);

                ContactAddresscell = new PdfPCell(ContactFullAddressImage);
                ContactAddresscell.VerticalAlignment = VCenter;
                ContactAddresscell.HorizontalAlignment = Left;
                ContactAddresscell.BorderColor = BaseColor.WHITE;

                table.AddCell(ContactAddresscell);
                //Row 11
                table.AddCell(GenerateCell("District", 12, "ಜಿಲ್ಲೆ", 20f));
                table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                table.AddCell(GenerateCell("District", 12, "ಜಿಲ್ಲೆ", 20f));
                table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

                //Row 12
                table.AddCell(GenerateCell("Taluk", 12, "ತಾಲ್ಲೂಕು", 20f));
                table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                table.AddCell(GenerateCell("Taluk", 12, "ತಾಲ್ಲೂಕು", 20f));
                table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

                //Row 13
                table.AddCell(GenerateCell("Pin code", 12, "ಪಿನ್ ಕೋಡ್", 20f));
                table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                table.AddCell(GenerateCell("Pin code", 12, "ಪಿನ್ ಕೋಡ್", 20f));
                table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

                //Row 13
                table.AddCell(GenerateCell("Constituency", 12, "ಕ್ಷೇತ್ರ", 20f));
                table.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                table.AddCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                table.AddCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));


                PdfPCell BankDetailsHeader = new PdfPCell(PrintHeaderCell("Bank Details".ToUpper(), "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Center, VCenter));
                BankDetailsHeader.Colspan = 4;
                BankTable.AddCell(BankDetailsHeader);

                BankTable.AddCell(GenerateCell("Account Holder Name", 12, "ಖಾತೆದಾರರ ಹೆಸರು", 20f));
                BankTable.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                BankTable.AddCell(GenerateCell("A/C Number", 12, "ಖಾತೆ ಸಂಖ್ಯೆ", 20f));
                BankTable.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

                BankTable.AddCell(GenerateCell("Bank", 12, "ಬ್ಯಾಂಕ್", 20f));
                BankTable.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                BankTable.AddCell(GenerateCell("Branch", 12, "ಶಾಖೆ", 20f));
                BankTable.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

                BankTable.AddCell(GenerateCell("IFSC Code", 12, "ಐಎಫ್‌ಎಸ್‌ಸಿ ಕೋಡ್", 20f));
                BankTable.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                BankTable.AddCell(GenerateCell("Address", 12, "ವಿಳಾಸ", 20f));
                BankTable.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

                //BankTable.AddCell(GenerateCell("Account Holder Name", 12, "ಖಾತೆದಾರರ ಹೆಸರು", 20f));
                //BankTable.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                //BankTable.AddCell(GenerateCell("A/C Number", 12, "ಖಾತೆ ಸಂಖ್ಯೆ", 20f));
                //BankTable.AddCell(PrintCell("XXXXXXXXXXXXXXXXX", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

                string abc = @"I hereby provide my consent to Karnataka Arya Vysya Community Development Corporation, (Government of Karnataka Undertaking), to use my Aadhaar number for performing all such validations which may be, required to verify the correctness of the data either provided by me or associated with me under schemes with whom I am enrolled for. I understand that the use of my Aadhaar number will be restricted to the extent required for efficient delivery of benefits to me by the State Government.";
                PdfPCell BankDetailsHeade = new PdfPCell(PrintCell(abc, "Times New Roman", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, PdfPCell.ALIGN_JUSTIFIED, PdfPCell.ALIGN_JUSTIFIED));
                BankDetailsHeade.Colspan = 4;
                //BankTable.AddCell(BankDetailsHeade);



                string SelfEnglish = "I hereby certify that the above furnished information is true to my knowledge. I shall abide by the terms and conditions of the sanction of the Arivu Education Loan. If any discrepancies are found later, I agree to take legal action against me.";
                string SelfKannada = "\n ಈ ಮೇಲ್ಕಂಡ ಮಾಹಿತಿಗಳು  ನನಗೆ ತಿಳಿದ ಮಟ್ಟಿಗೆ ಸತ್ಯ ಮತ್ತು  ಸರಿಯಾಗಿವೆಯೆಂದು ಪ್ರಮಾಣೀಕರಿಸುತ್ತೇನೆ.  ಒಂದು ವೇಳೆ ಮೇಲ್ಕಂಡ  ಮಾಹಿತಿಗಳು ಸುಳ್ಳು ಎಂದು \n ಕಂಡುಬಂದಲ್ಲಿ ನನ್ನ ವಿರುದ್ಧ ಕಾನೂನು ರೀತಿಯ ಕ್ರಮ ಜರುಗಿಸಲು ಒಪ್ಪಿರುತ್ತೇನೆ.";
                string AadhaarEnglish = "I hereby provide my consent to Karnataka Arya Vysya Community Development Corporation (Government of Karnataka Undertaking) to use my Aadhaar Number for performing all such validations, which may be required to verify the correctness of the data either provided by me or associated with me under schemes with whom I am enrolled for. I understand that the use of my Aadhaar Number will be restricted to the extent required for efficient delivery of benefits to me by the State Government.";
                string AadhaarKannada = "\n ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ ಸಮುದಾಯ ಅಭಿವೃದ್ಧಿ ನಿಗಮ(ಕರ್ನಾಟಕ ಸರ್ಕಾರದ ಉದ್ಯಮ) ಕ್ಕೆ ನನ್ನ  ಆಧಾರ್ ಸಂಖ್ಯೆಯನ್ನು ಬಳಸಲು  ಈ ಮೂಲಕ ನಾನು ಒಪ್ಪಿಗೆಯನ್ನು\n ನೀಡುತ್ತಿದ್ದೇನೆ. ನನ್ನಿಂದ ಒದಗಿಸಲಾದ ಅಥವಾ ನನ್ನೊಂದಿಗೆ ಸಂಯೋಜಿತವಾಗಿರುವ ಮಾಹಿತಿ ನಿಖರತೆಯನ್ನು ಪರಿಶೀಲಿಸಲು ಅಗತ್ಯವಿರುವ ಎಲ್ಲಾ ಮೌಲ್ಯಮಾಪನಗಳನ್ನು \n ನಿರ್ವಹಿಸಲು ಅಗತ್ಯವಾಗಿರುವುದರಿಂದ ನನ್ನ ಆಧಾರ್ ಸಂಖ್ಯೆಯ ಬಳಕೆಯನ್ನು ರಾಜ್ಯ ಸರ್ಕಾರವು ನನಗೆ ಸವಲತ್ತುಗಳನ್ನು ಸಮರ್ಪಕವಾಗಿ ತಲುಪಿಸಲು ಮಿತಗೊಂಡಿರುತ್ತದೆ \n ಎಂದು ನಾನು ಅರ್ಥಮಾಡಿಕೊಂಡಿರುತ್ತೇನೆ.";


                PdfPCell SelfDeclaration = new PdfPCell(GenerateCell(SelfEnglish, 8, SelfKannada, 15f,BaseFont.COURIER));
                SelfDeclaration.Colspan = 4;
                BankTable.AddCell(SelfDeclaration);

                PdfPCell AadhaarDeclaration = new PdfPCell(GenerateCell(AadhaarEnglish, 8, AadhaarKannada, 15f, BaseFont.COURIER));
                AadhaarDeclaration.Colspan = 4;
                BankTable.AddCell(AadhaarDeclaration);

                PdfPCell EmptyHeader = new PdfPCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Center, VCenter));
                EmptyHeader.Colspan = 4;
                BankTable.AddCell(EmptyHeader);

                PdfPCell SignatureCell = new PdfPCell(GenerateCell("Signature", 15, "    ಸಹಿ", 25f));
                BankTable.AddCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                BankTable.AddCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                BankTable.AddCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                BankTable.AddCell(SignatureCell);



                ////BankTable.AddCell(ConvertTextToImage("ಪರ್ಯಾಯ ಮೊಬೈಲ್ ಸಂಖ್ಯೆ               .", "Arial", 10, Color.Yellow, Color.Black));
                ////iTextSharp.text.Font font1 = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD);
                ////PdfPCell cellele = new PdfPCell();
                ////cellele.AddElement(ConvertTextToImage("ಈ ಮೇಲ್ಕಂಡ ", "Arial", 10, Color.Yellow, Color.Black));
                ////cellele.AddElement(new Phrase(12, "hjhs BAS"));
                //////font.Color = new Color(GridView1.RowStyle.ForeColor);

                ////BankTable.AddCell(PrintCell("Applicant Name \n" + new Phrase(12, "ಹೆಸರು", font), "Arial", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                ////BankTable.AddCell(PrintCell("Applicant Name \n" + new Phrase(12, "ಹೆಸರು", font), "Arial", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                ////BankTable.AddCell(cellele);
                ////BankTable.AddCell(GenerateCell("Application Number", "ಅರ್ಜಿ ಸಂಖ್ಯೆ",20f));
                //////BankTable.AddCell(PrintCell("Applicant Name", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                ////BankTable.AddCell(PrintCell("Applicant Name", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

                ////BankTable.AddCell(PrintCell("Applicant Name", "Arial", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                ////BankTable.AddCell(PrintCell("Applicant Name", "Arial", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                ////BankTable.AddCell(PrintCell("Applicant Name", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                ////BankTable.AddCell(PrintCell("Applicant Name", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));

                ////BankTable.AddCell(PrintCell("Applicant Name", "Arial", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                ////BankTable.AddCell(PrintCell("Applicant Name", "Arial", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                ////BankTable.AddCell(PrintCell("Applicant Name", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));
                ////BankTable.AddCell(PrintCell("Applicant Name", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Left, VCenter));


                ////cell = ImageCell("~/Image/KACDC_PDF.png", 30f, PdfPCell.ALIGN_CENTER);
                ////BankTable.AddCell(cell);


                //header = new PdfPCell(PrintCell("", "sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK, 20f, Center, VCenter));
                //header.Colspan = 4;
                //BankTable.AddCell(header);


                //PdfPCell headerName = new PdfPCell(new Phrase("Self Employment"));
                //headerName.Colspan = 2;
                //BankTable.AddCell("ab");
                //BankTable.AddCell(headerName);
                //BankTable.AddCell("ab");

                ////for (int iRow = 0; iRow < 3; iRow++)
                ////{
                //// The first cell spans 5 rows  
                //////PdfPCell cellWithRowspan = new PdfPCell(ImageCell("~/Image/KACDC_PDF.png", 30f, PdfPCell.ALIGN_CENTER, BaseColor.BLACK));

                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("Applicant Name is", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("abcde", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                ////}
                ////BankTable.AddCell(new PdfPCell(ImageCell("~/Image/KACDC_PDF.png", 30f, PdfPCell.ALIGN_CENTER)));

                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                //cellWithRowspan.Rowspan = 6;
                //BankTable.AddCell(cellWithRowspan);
                //cell = new PdfPCell(new Phrase(new Chunk("12345Test", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK))));
                //BankTable.AddCell(cell);
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)))));
                ////BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, Font.NORMAL, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, Font.NORMAL, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, Font.NORMAL, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, Font.NORMAL, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("", FontFactory.GetFont("sans-serif", 10, Font.NORMAL, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, Font.NORMAL, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, Font.NORMAL, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, Font.NORMAL, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, Font.NORMAL, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, Font.NORMAL, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("12345", FontFactory.GetFont("sans-serif", 10, Font.NORMAL, BaseColor.BLACK)))));
                //BankTable.AddCell(new PdfPCell(new Phrase(new Chunk("", FontFactory.GetFont("sans-serif", 10, Font.NORMAL, BaseColor.BLACK)))));

                pdfDoc.Add(table);
                pdfDoc.NewPage();
                pdfDoc.Add(BankTable);

                //table = new PdfPTable(4);
                //table.TotalWidth = 400f;
                //table.LockedWidth = true;
                //PdfPCell header = new PdfPCell(new Phrase("Header"));
                //header.Colspan = 4;
                //table.AddCell(header);
                //table.AddCell("Cell 1");
                //table.AddCell("Cell 2");
                //table.AddCell("Cell 3");
                //table.AddCell("Cell 4");
                //PdfPTable nested = new PdfPTable(1);
                //nested.AddCell("Nested Row 1");
                //nested.AddCell("Nested Row 2");
                //nested.AddCell("Nested Row 3");
                //PdfPCell nesthousing = new PdfPCell(nested);
                //nesthousing.Padding = 0f;
                //table.AddCell(nesthousing);
                //PdfPCell bottom = new PdfPCell(new Phrase("bottom"));
                //bottom.Colspan = 3;
                //table.AddCell(bottom);
                //pdfDoc.Add(table);


                //StringBuilder sb = new StringBuilder();
                //sb.Append("<body>");
                //sb.Append("<h1 style=\"text-align:center;\">これは日本語のテキストの例です。</h1>");
                //sb.Append("</body>");
                //Document Doc = new Document(PageSize.A4);

                //using (FileStream fs = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Test.pdf"), FileMode.Create, FileAccess.Write, FileShare.Read))
                //{
                //    //Bind PDF writer to document and stream
                //    PdfWriter writer1 = PdfWriter.GetInstance(Doc, fs);

                //    //Open document for writing
                //    Doc.Open();


                //    //Add a page
                //    Doc.NewPage();

                //    MemoryStream msHtml = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(sb.ToString()));
                //    //XMLWorkerHelper.GetInstance().ParseXHtml(writer1, Doc, msHtml, null, Encoding.UTF8, new UnicodeFontFactory());

                //    //Close the PDF
                //    Doc.Close();
                //}



                pdfDoc.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                Response.Clear();
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                string fname = "EmpFile";
                Response.AddHeader("Content-Disposition", "attachment; filename="+ fname + ".pdf");
                Response.ContentType = "application/pdf";
                Response.Buffer = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();
            }
        }

        protected void btnExportGridviewPDF_Click(object sender, EventArgs e)
        {
            GridView1.AllowPaging = false;
            GridView1.DataBind();

            BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\fonts\Tunga.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            PdfPTable table = new PdfPTable(GridView1.Columns.Count);
            int[] widths = new int[GridView1.Columns.Count];
            for (int x = 0; x < GridView1.Columns.Count; x++)
            {
                widths[x] = (int)GridView1.Columns[x].ItemStyle.Width.Value;
                string cellText = Server.HtmlDecode(GridView1.HeaderRow.Cells[x].Text);

                //Set Font and Font Color
                iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD);
                //font.Color = new Color(GridView1.HeaderStyle.ForeColor);
                PdfPCell cell = new PdfPCell(new Phrase(12, cellText, font));

                //Set Header Row BackGround Color
                //cell.BackgroundColor = new Color(GridView1.HeaderStyle.BackColor);
                table.AddCell(cell);
            }
            table.SetWidths(widths);

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    for (int j = 0; j < GridView1.Columns.Count; j++)
                    {
                        string cellText = Server.HtmlDecode(GridView1.Rows[i].Cells[j].Text);
                        //Set Font and Font Color
                        iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD);
                        //font.Color = new Color(GridView1.RowStyle.ForeColor);
                        PdfPCell cell = new PdfPCell(new Phrase(12, cellText, font));
                        table.AddCell(cell);
                    }
                }
            }

            //Create the PDF Document
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            pdfDoc.Add(table);
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=ExportGridView.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            base.VerifyRenderingInServerForm(control);
            /* Verifies that the control is rendered */
        }
        protected void Export(object sender, EventArgs e)
        {
            //Export HTML String as PDF.
            string html = Request.Form["Table_HTML"];
            StringReader sr = new StringReader(html);
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.ContentType = "application/pdf";

            Response.AddHeader("content-disposition", "attachment;filename=Table.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }

        protected void btnPdfTable_Click(object sender, EventArgs e)
        {
        }
        private void CreatePDFFromHTMLFile(string html, string FileName)
        {
            TextReader reader = new StringReader(html);
            // step 1: creation of a document-object
            Document document = new Document(PageSize.A4, 30, 30, 30, 30);

            // step 2:
            // we create a writer that listens to the document
            // and directs a XML-stream to a file
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(FileName, FileMode.Create));

            // step 3: we create a worker parse the document
            HTMLWorker worker = new HTMLWorker(document);

            // step 4: we open document and start the worker on the document
            document.Open();

            // step 4.1: register a unicode font and assign it an allias
            FontFactory.Register("C:\\Windows\\Fonts\\ARIALUNI.TTF", "arial unicode ms");

            // step 4.2: create a style sheet and set the encoding to Identity-H
            iTextSharp.text.html.simpleparser.StyleSheet ST = new iTextSharp.text.html.simpleparser.StyleSheet();
            ST.LoadTagStyle("body", "encoding", "Identity-H");

            // step 4.3: assign the style sheet to the html parser
            worker.SetStyleSheet(ST);
            worker.StartDocument();

            // step 5: parse the html into the document
            worker.Parse(reader);

            // step 6: close the document and the worker
            worker.EndDocument();
            worker.Close();
            document.Close();
        }

        protected void btnIRONPdf_Click(object sender, EventArgs e)
        {
        }
        protected void ExportToPDF(object sender, EventArgs e)
        {
            StringReader sr = new StringReader(Request.Form[hfGridHtml.UniqueID]);
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=HTML.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }
        protected void OndateChange(object sender, EventArgs e)
        {
        }

        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
            lbldate.Text = txtDOB.Text;
        }
        public StringBuilder TextArea { get; set; } = new StringBuilder();
        public string GenerateMultiLineTextArea(string value, int length)
        {
            // first call - first length values -> append first length values, remove first length values from value, make second call
            // second call - second length values -> append second length values, remove first length values from value, make third call
            // third call - value length is less then length just append as it is

            if (value.Length <= length && value.Length != 0)
            {

                TextArea.Append($"{value.PadRight(length)}" );
            }
            else
            {
                TextArea.Append($"{value.Substring(0, length).ToString()}".PadLeft(length) + "\r\n");
                value = value.Substring(length, (value.Length) - (length));
                GenerateMultiLineTextArea(value, length);
            }
            return TextArea.ToString();
        }
        protected void btnwrap_Click(object sender, EventArgs e)
        {
            int length = 25;
            string value= "ಈ ಮೇಲ್ಕಂಡ ಮಾಹಿತಿಗಳು ನನಗೆ ತಿಳಿದ ಮಟ್ಟಿಗೆ ಸತ್ಯ ಮತ್ತು ಸರಿಯಾಗಿವೆಯೆಂದು ಪ್ರಮಾಣಿಕರಿಸುತ್ತೇನೆ. ಒಂದು ವೇಳೆ ಮೇಲ್ಕಂಡ ಮಾಹಿತಿಗಳು ಸುಳ್ಳು ಎಂದು ಕಂಡುಬಂದಲ್ಲಿ ನನ್ನ ವಿರುದ್ಧ ಕಾನೂನು ರೀತಿ ಕ್ರಮ ಜರುಗಿಸಲು ನಾನು ಒಪ್ಪಿರುತ್ತೇನೆ.";
            // second call - second length values -> append second length values, remove first length values from value, make third call
            // third call - value length is less then length just append as it is
            txtwrap.Text= GenerateMultiLineTextArea(value, length);
            

        }

        protected void btnSendMessage_Click(object sender, EventArgs e)
        {
            string mob = txtMobileNumber.Text;
            string[] authorsList = mob.Split(',');
            int count = 0;
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            foreach (string author in authorsList)
            {
                string strMainContent = "{\"outboundSMSMessageRequest\":{" +
                               "\"address\":[\"" + "!strMobileNo!" + "\"]," +
                               "\"senderAddress\":\"" + "!senderAddress!" + "\"," +
                               "\"outboundSMSTextMessage\":{\"message\":\"" + "!strMsg!" + "\"}," +
                               "\"clientCorrelator\":\"" + "!clientCorrelator!" + "\"," +
                               "\"messageType\":\"" + "!messageType!" + "\"," +
                               "\"category\":\"" + "!category!" + "\"," +
                              "\"receiptRequest\":{\"notifyURL\":\"" + "!notifyURL!" + "\"," +
                               "\"callbackData\":\"$(" + "!callbackData!" + ")\"}," +
                               "\"senderName\":\"" + "!senderName!" + "\"}}";

                //Replace all the parametersin above defined json object

                //Replace senderAddress in RequestURL:
                NCSE.SMSSendUrl = NCSE.SMSSendUrl.Replace("$(senderAddress)", "KAVDES");

                //It is Optional to prefix 'tel:'
                string mbnumber = "91" + author;
                strMainContent = strMainContent.Replace("!strMobileNo!", "tel:+" + mbnumber);

                //senderAddress can be alphanumeric
                strMainContent = strMainContent.Replace("!senderAddress!", "KAVDES");
                strMainContent = strMainContent.Replace("!category!", "KAVDES-ArivuLoan");
                strMainContent = strMainContent.Replace("!messageType!", "4");

                //string cont = "Dear Beneficiar Self Employement Loan application submitted Successful your application number. Keep it for future reference From Karnataka Arya Vysya Community Development Corporation";
                string cont = txtMessage.Text;
                strMainContent = strMainContent.Replace("!strMsg!", cont);
                //strMainContent = strMainContent.Replace("!clientCorrelator!", clientCorrelator);
                strMainContent = strMainContent.Replace("!notifyURL!", NCSE.SMSNotifyURL);
                //strMainContent = strMainContent.Replace("!callbackData!", callbackData);
                strMainContent = strMainContent.Replace("!senderName!", "KAVDES");

                //POST the request with JSON Object
                string retval;
                retval = DoPostRequest(NCSE.SMSSendUrl, strMainContent);
                count++;
                lblCountDisplay.Text = count.ToString();
            }
            watch.Stop();
            long ms= watch.ElapsedMilliseconds;
            string msg = (((ms / 1000) / 60)/60).ToString() + "h : " + ((ms / 1000) / 60).ToString() +"m : "+ (ms / 1000).ToString() + "s Count :" + count.ToString();
            DisplayAlert(msg, this);
        }

        protected void btnDisplayOutside_Click(object sender, EventArgs e)
        {
            divOutside.Visible = true;
            //ScriptManager1.RegisterDataItem(Label2, DateTime.Now.ToString());
        }
    }
}