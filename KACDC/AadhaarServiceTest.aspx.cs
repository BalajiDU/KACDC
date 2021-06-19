using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KACDC.Class;

using krdh.connector;
using krdh.parameters;
using KRDHConnector;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Configuration;
using System.IO;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Web.Script.Serialization;

using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Data;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using KACDC;
using KACDC.Class.Declaration.Nadakacheri;
using KACDC.Class.Declaration.CollegeData;
using KACDC.Class.Declaration.Aadhaar;
using KACDC.Class.Declaration.BankDetails;
using KACDC.NadaKacheriServiceReference;
using System.Xml.Linq;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using KACDC.Class.DataProcessing.FileProcessing;
using KACDC.Class.DataProcessing.GetDataToFillGridView;
using KACDC.Class.MessageSending;
using KACDC.Class.Declaration.MessageDeclaration;

namespace KACDC
{
    public partial class AadhaarServiceTest : System.Web.UI.Page
    {
        AadhaarServiceData ADSE = new AadhaarServiceData();
        ApplicantCollegeData CLGAR = new ApplicantCollegeData();
        //NadaKacheri_SelfEmployment NCSE = new NadaKacheri_SelfEmployment();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Abandon();
            }
        }

        protected void btnAadhaarGetOTP_Click(object sender, EventArgs e)
        {
            string abc = ConfigurationSettings.AppSettings["naeUser"].ToString();
            //DisplayAlert(abc,this);
            //AadhaarSendOTP();
            ADSE.AadhaarNumber = txtAadhaar.Text.Trim();
            //DisplayAlert("Before", this);
            try
            {
                if (AadhaarSendOTP())
                {
                    DisplayAlert("OTP sent to registerd mobile number", this);
                    lblTransID.Text = ADSE.AadhaarOTPResponseTransactionID;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                WriteErrorLog(ADSE.SendOTPErrorCode, ADSE.SendOTPErrorMessage);
                if (ADSE.SendOTPErrorCode== "AUA-OTP-03")
                    DisplayAlert("Try after some time", this);
                else if (ADSE.SendOTPErrorCode == "AUA-OTP-01")
                    DisplayAlert("Invalid Information", this);
                else 
                    DisplayAlert(ADSE.SendOTPErrorMessage, this);
            }
        }

        protected bool AadhaarSendOTP()
        {
            //AadhaarHistoryLog("OTP", "1", "1", "1");

            RequestObject request = new RequestObject();

            request.setAadhaarNumber(ADSE.AadhaarNumber);
            request.setTransaction(Util.generateTransactionId(TypeOfRequest.Others));
            request.setOtpRequestType(OTPRequestType.AADHAAR);
            request.setTimeStamp(Util.getTimeStamp());

            krdh.connector.KRDHConnectorImpl krdhConnector = new KRDHConnectorImpl();
            ResponseObject response = krdhConnector.RequestOTP(request);
            
            if (response.getStatus().Equals("N"))
            {
                //Response.Write("Failed to generate the request.");
                //Response.Write(response.getError());
                //Response.Write(response.getErrorMessage());
                Response.Write(response.getUIDToken());
                ADSE.SendOTPErrorMessage = response.getErrorMessage();
                ADSE.SendOTPErrorCode = response.getError();
                //DisplayAlert(response.getErrorMessage(),this);
                AadhaarHistoryLog("OTP", response.getStatus(), response.getTransaction(),response.getTimeStamp().ToString());
                return false;
            }
            else
            {
                
                if (response.getResponseStatus().ToLower().Equals("y"))
                {
                    Response.Write(response.getTimeStamp());
                    ADSE.AadhaarOTPResponseTransactionID = response.getTransaction();

                    Response.Write("SUCCESS");
                    Response.Write("OTP Sent: " + response.getTransaction() + "\n");

                    Response.Write("Var OTP Sent: " + ADSE.AadhaarOTPResponseTransactionID + "\n");
                    AadhaarHistoryLog("OTP", response.getStatus(), response.getTransaction(), response.getTimeStamp().ToString());

                    return true;
                }
                else
                {
                    Response.Write(response.getError());
                    Response.Write(response.getErrorMessage());
                    DisplayAlert(response.getErrorMessage(), this);
                    ADSE.SendOTPErrorMessage = response.getErrorMessage();
                    ADSE.SendOTPErrorCode = response.getError();
                    AadhaarHistoryLog("OTP", response.getStatus(), response.getTransaction(), response.getTimeStamp().ToString());

                    return false;
                    
                }
            }
            
        }
        protected void btnAadhaarOTPVerify_Click(object sender, EventArgs e)
        {
            
            try
            {
                //VerifyAadhaarOTP();
                ADSE.AadhaarApplicantOTP = txtAadhaarOTP.Text.Trim();
                if (VerifyAadhaarOTP())
                {
                    Response.Write("OTP Verified Successful");
                    DisplayAlert("OTP Verified", this);
                    if(GetAadhaarToken())
                    {
                        Response.Write("Token received"+ADSE.AadhaarVaultToken);
                        DisplayAlert("OTP Verified_"+ADSE.AadhaarVaultToken, this);
                    }
                    else
                    {
                        DisplayAlert("OTP Verified_" + ADSE.AadhaarVaultToken, this);
                    }

                }
                else
                {
                    throw new Exception();
                }
            }
            catch(Exception ex)
            {
                WriteErrorLog(ADSE.OTPErrorCode, ADSE.OTPErrorMessage);
                DisplayAlert(ADSE.OTPErrorCode+"__"+ADSE.OTPErrorMessage,this);
            }
            
        }
        private bool VerifyAadhaarOTP()
        {
            KYCRequest kYCRequest = new KYCRequest();
            kYCRequest.setAuthenticationType(ResidentAuthenticationType.OTP);
            kYCRequest.setDecryptionRequired(false);
            kYCRequest.setLocalLanguageRequired(false);
            kYCRequest.setPrintFormatRequired(false);

            RequestObject request = new RequestObject();

            request.setAadhaarNumber(ADSE.AadhaarNumber);
            request.setVersion("2.5");
            request.setUdc(ConfigurationSettings.AppSettings["UDCCode"].ToString());
            //request.setUdc("ASBD20171013100000");
            request.setTimeStamp(Util.getTimeStamp());
            request.setResidentConsent(true);

            request.setKycRequest(kYCRequest);

            PinValue pv = new PinValue();

            pv.setOtp(ADSE.AadhaarApplicantOTP);

            request.setTransaction(ADSE.AadhaarOTPResponseTransactionID);
            Response.Write("Verifying OTP(var): " + ADSE.AadhaarOTPResponseTransactionID + "\n");
            //request.setTransaction(UUID.randomUUID().toString());
            request.setPinValue(pv);


            KRDHConnectorImpl krdhConnector = new KRDHConnectorImpl();

            ResponseObject response = krdhConnector.requestKYC(request);
            Response.Write("Got Response\n");

            Response.Write(response.getInfo());
            if (response.getStatus().Equals("N"))
            {
                Response.Write("Failed to generate the request.\n");
                Response.Write(response.getError() + "\n");
                Response.Write(response.getErrorMessage() + "\n");
                Response.Write("Var : "+ADSE.AadhaarOTPResponseTransactionID + "\n");
                ADSE.OTPErrorCode = response.getError();
                ADSE.OTPErrorMessage= response.getErrorMessage();
                WriteErrorLog(ADSE.OTPErrorCode, ADSE.OTPErrorMessage);
                return false;
            }
            else
            {
                if (response.getResponseStatus().ToLower().Equals("y"))
                {
                    Response.Write(response.getTimeStamp()+"\n");
                    Response.Write(response.getTransaction() + "\n");
                    Response.Write("SUCCESS" + "\n");

                    
                    lblToken.Text = ADSE.AadhaarVaultToken;

                    ADSE.DOB = response.GetKycRes().UidData.Poi.dob;
                    ADSE.Gender = response.GetKycRes().UidData.Poi.gender;
                    ADSE.Name = response.GetKycRes().UidData.Poi.name;

                    ADSE.State = response.GetKycRes().UidData.Poa.state;
                    ADSE.District = response.GetKycRes().UidData.Poa.state;

                    ADSE.Photo = response.GetKycRes().UidData.Pht;
                    ADSE.Pincode = response.GetKycRes().UidData.Poa.pc;
                    Response.Write("___" + ADSE.Name+"___" + ADSE.DOB+ "_" + ADSE.Gender+ "_" + ADSE.District+"_"+ ADSE.State);
                    //string fileName = Path.Combine(Server.MapPath("C:\inetpub\wwwroot\AadhaarApplicantPhoto"));

                    return true;
                }
                else
                {
                    Response.Write(response.getError() + "\n");
                    Response.Write(response.getErrorMessage() + "\n");
                    ADSE.OTPErrorCode = response.getError();
                    ADSE.OTPErrorMessage = response.getErrorMessage();
                    WriteErrorLog(ADSE.OTPErrorCode, ADSE.OTPErrorMessage);

                    return false;
                }
            }
        }
        public static void DisplayAlert(string message, Control owner)
        {
            System.Web.UI.Page page = (owner as System.Web.UI.Page) ?? owner.Page;
            if (page == null) return;

            //page.ClientScript.RegisterStartupScript(owner.GetType(),"ShowMessage", string.Format("<script type='text/javascript'>alert('{0}')</script>",
            //    message));
            ScriptManager.RegisterClientScriptBlock(owner, owner.GetType(), "alertMessage", "alert('" + message + "')", true);
        }
        protected void WriteErrorLog(string ErrCode,string ErrMsg)
        {
            string ipaddress;
            ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
                ipaddress = Request.ServerVariables["REMOTE_ADDR"];

            string webPageName = Path.GetFileName(Request.Path);
            string errorLogFilename = "ErrorLog_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
            string path = Server.MapPath("~/LogFiles/AadhaarErrorLog/" + errorLogFilename);
            if (File.Exists(path))
            {
                using (StreamWriter stwriter = new StreamWriter(path, true))
                {
                    stwriter.WriteLine("------------------- " + DateTime.Now.ToString("hh:mm tt") + " -----------");
                    stwriter.WriteLine("WebPage Name :" + webPageName);
                    stwriter.WriteLine("Code:" + ErrCode);
                    stwriter.WriteLine("Message:" + ErrMsg);
                    stwriter.WriteLine("IP:" + ipaddress);
                    stwriter.WriteLine("-------------------End----------------------------");

                }
            }
            else
            {
                StreamWriter stwriter = File.CreateText(path);
                stwriter.WriteLine("-------------------Error Log Start-----------as on " + DateTime.Now.ToString("hh:mm tt"));
                stwriter.WriteLine("WebPage Name :" + webPageName);
                stwriter.WriteLine("Code:" + ErrCode);
                stwriter.WriteLine("Message:" + ErrMsg);
                stwriter.WriteLine("IP:" + ipaddress);
                stwriter.WriteLine("-------------------End----------------------------");
                stwriter.Close();
            }
        }
        private bool GetAadhaarToken()
        {
            try
            {
                var client = new RestClient("http://172.31.36.246:8080/tmrest/SafeNetTokenManager/insertToken");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                //request.AddParameter("application/json", "{\"naeUser\":\"tmtestuser\",\"naePassword\":\"P@ssw0rd\",\"dbUser\":\"DBTEST\",\"dbPassword\":\"rndo_1234\",\"value\":\"" + txtAadhaar.Text.Trim() + "\",\"tableName\":\"DBVAULT\",\"format\":\"103\"}", ParameterType.RequestBody);
                request.AddParameter("application/json", "{\"naeUser\":\""+ ConfigurationSettings.AppSettings["naeUser"].ToString() +
                    "\",\"naePassword\":\""+ ConfigurationSettings.AppSettings["naePassword"].ToString() +
                    "\",\"dbUser\":\""+ ConfigurationSettings.AppSettings["dbUser"].ToString() +
                    "\",\"dbPassword\":\""+ ConfigurationSettings.AppSettings["dbPassword"].ToString() +
                    "\",\"value\":\"" + txtAadhaar.Text.Trim() +
                    "\",\"tableName\":\""+ ConfigurationSettings.AppSettings["tableName"].ToString() +
                    "\",\"format\":\""+ ConfigurationSettings.AppSettings["format"].ToString() + "\"}", RestSharp.ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                Response.Write("___response Data" + response.Content);
                string responseData = response.Content;

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    var jObject = JObject.Parse(response.Content);
                    string token1 = jObject.GetValue("token").ToString();
                    Response.Write("___response token is:" + token1);
                }
                else
                {
                    Response.Write("___response code:" + response.StatusCode.ToString());
                    Response.Write("___response code:" + response.ErrorMessage);
                }
                return true;
            }
            catch (Exception ex)
            {
                DisplayAlert(ex.Message,this);
                return false;
            }
        }

        protected void btnGetToken_Click(object sender, EventArgs e)
        {
            GetAadhaarToken();
        }

        protected void btnVerifyAge_Click(object sender, EventArgs e)
        {
            DateTime dtStart = DateTime.Parse(ADSE.DOB);
            TimeSpan sp = DateTime.Now - dtStart;
            DisplayAlert((sp.Days / 365).ToString(), this);
            if (sp.Days < 18 * 365)
            {
                Response.Write("18 years__");
                DisplayAlert("Manimum 18 Years", this);
            }
            else if (sp.Days > 45 * 365)
            {
                Response.Write("45 years__");
                DisplayAlert("Maximun 45 Years", this);
            }
            else
            {
                Response.Write("Age is__" + sp.Days + "_" + ADSE.DOB);
                DisplayAlert("Age is " + (sp.Days / 365).ToString(), this);
               
            }
        }
        
        private void AadhaarHistoryLog( string Type, string status,string TransactionID,string TimeStamp)
        {
            try
            {
                SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
                if (kvdConn.State == ConnectionState.Closed) { kvdConn.Open(); }


                SqlCommand cmd = new SqlCommand("INSERT INTO AadhaarTransactionHistory ([Type],[Status],[TransactionID],[TimeStamp]) VALUES('" + Type + "','" + status + "','" + TransactionID + "','" + TimeStamp + "')", kvdConn);

                cmd.ExecuteNonQuery();

                kvdConn.Close();
            }
            catch(Exception ex)
            {
                DisplayAlert(ex.Message, this);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Updating Label1 Text with the current Time Ticks
            Label1.Text = DateTime.Now.Ticks.ToString();
            //Register Label2 control with current DataTime as DataItem
            //ScriptManager1.RegisterDataItem(Label2, DateTime.Now.ToString());
            //ScriptManager1.RegisterDataItem(divoutside, "divoutside.Visible=true");
            ////if(test2.style("display") = "block")
            //System.Web.UI.WebControls.Button btn =(System.Web.UI.WebControls.Button)FindControl("Button2");
            //((System.Web.UI.WebControls.Button)FindControl("btnOutside")).OnClientClick = "ToggleVisibility('" + btn.ClientID + "')";

            divoutside.Visible = true;
            //string script = "window.onload = function() { YourJavaScriptFunctionName(); };";
            //ClientScript.RegisterStartupScript(this.GetType(), "YourJavaScriptFunctionName", script, true);
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "divviz", "divviZ()", true);

        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //Read the uploaded File as Byte Array from FileUpload control.
            Stream fs = FileUpload1.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            byte[] bytes = br.ReadBytes((Int32)fs.Length);

            //Save the Byte Array as File.
            byte[] imgdata = System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/Image/KACDC_PDF.jpg"));

            string filePath = "~/AadhaarApplicantPhoto/" + "TestFile"+".png";
            File.WriteAllBytes(Server.MapPath(filePath), imgdata);
            DisplayAlert("saved", this);
            //System.Threading.Thread.Sleep(10000);
            //Display the Image File.
            Image1.ImageUrl = filePath;
            Image1.Visible = true;
        }

        protected void Value_Click(object sender, EventArgs e)
        {
            //CLGAR.PdfCETAdmissionTicket=System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/Image/KACDC_PDF.jpg"));
            if (CLGAR.PdfCETAdmissionTicket!=null)
            {
                DisplayAlert("Null", this);
            }
            else
            {
                DisplayAlert("not Null", this);
            }
        }
        protected void btnUploadfile_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileExtwnsion = Path.GetExtension(FileUpload1.FileName);

                if (fileExtwnsion.ToLower() != ".jpg" && fileExtwnsion.ToLower() != ".png")
                {
                    lblMessage.Text = "Only jpg and png file allowed";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    int fileSize = FileUpload1.PostedFile.ContentLength;
                    if (fileSize > 2097152)
                    {
                        lblMessage.Text = "Maximum size 2(MB) exceeded ";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("~/images/" + FileUpload1.FileName));
                        lblMessage.Text = "File Uploaded successfully";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                    }
                }
            }
            else
            {
                lblMessage.Text = "File not uploaded";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void txtCollegeCode_TextChanged(object sender, EventArgs e)
        {
            ApplicantCollegeData CLGAR = new ApplicantCollegeData();
            try
            {
                //CollegeDataServiceReference.GetCollegeDetailsSoapClient client = new CollegeDataServiceReference.GetCollegeDetailsSoapClient();
                //string resp = client.CollegeDetails(txtCollegeCode.Text.Trim());
                //var jObject = JObject.Parse(resp);
                //string token1 = jObject["Clg"].ToString();  //jObject.GetValue("Clg").ToString();
                //var jObject1 = JObject.Parse(token1);
                //if (jObject1["CollegeName"].ToString() != "NoCollege")
                //{
                //    string token2 = jObject1["CollegeName"].ToString();
                //    CLGAR.CollegeName= jObject1["CollegeName"].ToString();
                //    CLGAR.CollegeAddress = jObject1["CollegeAddress"].ToString();
                //    txtCollegeName.Text = jObject1["CollegeName"].ToString();
                //    txtCollegeAddress.Text= jObject1["CollegeAddress"].ToString();
                //    lblresp.Text = "College Found";
                //    //DisplayAlert(CLGAR.CollegeName+"_"+ CLGAR.CollegeAddress, this);
                //}
                //else
                //{
                //    lblresp.Text = "College Not Found";
                //    CLGAR.CollegeName = "";
                //    CLGAR.CollegeAddress = "";
                //    txtCollegeName.Text = jObject1["CollegeName"].ToString();
                //    txtCollegeAddress.Text = jObject1["CollegeAddress"].ToString();
                //}
                //CollegeDataArivu cd = new CollegeDataArivu();
                ////txtCollegeName.Text = cd.CollegeName;
                ////txtCollegeAddress.Text = cd.CollegeAddress;
            }
            catch (System.Web.Services.Protocols.SoapException soapEx)
            {
                DisplayAlert(soapEx.Message, this);
            }
            //txtCollegeAddress.Text = CLGAR.CollegeAddress;
            //txtCollegeName.Text = CLGAR.CollegeName;
            var position = txtCollegeCode.Text.IndexOf(txtCollegeCode.Text) + txtCollegeCode.Text.Length + 1;
            var script = String.Format("setCursorPosition('{0}',{1});", txtCollegeCode.ClientID, position);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "CursorScript", script, true);
        }
        protected void btnSendMessage_Click1(object sender, EventArgs e)
        {
            Message Msg = new Message();
            
            Msg.SMSMessageSendingKey = "79ebcb3a-68b9-48c1-877b-b4d6948236d1";
            //NCSE.SMSMessageSendingKey = "bbbe7d22-b12b-412e-92d4-f484b3655cbe";
            Msg.SMSNotifyURL = "http://10.10.29.74/";
            Msg.SMSSendUrl = "https://10.10.30.183/smsmessaging/1/outbound/tel%3A%2BKAVDES/requests";
            //Msg.SMSNotifyURL = "httpS://http://kacdc.karnataka.gov.in//";
            //Msg.SMSSendUrl = "http://smspush.openhouseplatform.com/smsmessaging/1/outbound/tel%3A%2BKAVDES/requests";
            Msg.SenderID = "KAVDES";
            
            SendMessage sendMessage = new SendMessage();
            //sendMessage.WriteLog("SMS", "From Main Page", Server.MapPath("~/LogFiles/"));
            sendMessage.MessageRequest(txtMessage.Text.Trim(), txtMobileNumber.Text.Trim(), "GKACDC-Employment",1,Server.MapPath("~/LogFiles/"));
        }
        protected void btnSendMessage_Click2(object sender, EventArgs e)
        {
            Message Msg = new Message();

            Msg.SMSMessageSendingKey = "79ebcb3a-68b9-48c1-877b-b4d6948236d1";
            //NCSE.SMSMessageSendingKey = "bbbe7d22-b12b-412e-92d4-f484b3655cbe";
            Msg.SMSNotifyURL = "http://10.10.29.74/";
            Msg.SMSSendUrl = "https://10.10.30.183/smsmessaging/1/outbound/tel%3A%2BKAVDES/requests";
            //Msg.SMSNotifyURL = "httpS://http://kacdc.karnataka.gov.in//";
            //Msg.SMSSendUrl = "http://smspush.openhouseplatform.com/smsmessaging/1/outbound/tel%3A%2BKAVDES/requests";
            Msg.SenderID = "KAVDES";

            SendMessage sendMessage = new SendMessage();
            //sendMessage.WriteLog("SMS", "From Main Page", Server.MapPath("~/LogFiles/"));

            string CompleteMobileNumber = txtMobileNumber.Text;
            string[] MobileNumberList = CompleteMobileNumber.Split(',');
            foreach (string MobileNumber in MobileNumberList)
            {
                sendMessage.MessageRequest(txtMessage.Text.Trim(), MobileNumber, "GKACDC-BulkMessage", 1, Server.MapPath("~/LogFiles/"));
            }
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
                //NCSE.SMSSendUrl = NCSE.SMSSendUrl.Replace("$(senderAddress)", "KAVDES");

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
                //strMainContent = strMainContent.Replace("!notifyURL!", NCSE.SMSNotifyURL);
                //strMainContent = strMainContent.Replace("!callbackData!", callbackData);
                strMainContent = strMainContent.Replace("!senderName!", "KAVDES");

                //POST the request with JSON Object
                string retval;
                //retval = DoPostRequest(NCSE.SMSSendUrl, strMainContent);
                count++;
                lblCountDisplay.Text = count.ToString();
            }
            watch.Stop();
            long ms = watch.ElapsedMilliseconds;
            string msg = (((ms / 1000) / 60) / 60).ToString() + "h : " + ((ms / 1000) / 60).ToString() + "m : " + (ms / 1000).ToString() + "s Count :" + count.ToString();
            DisplayAlert(msg, this);
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
                //objReq.Headers.Add("key", NCSE.SMSMessageSendingKey);

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
                DisplayAlert(ex.Message, this);
                strRetVal = "eRROR";
                //MessageBox.Show("Unable to send message", "Failed!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //strRetVal = "Unable to Process Request.";
            }
            return strRetVal;
        }
        protected async void btnDownloadExcel_Click(object sender, EventArgs e)
        {
            Task<bool> task = new Task<bool>(CompleteTask);
            task.Start();
            lblFileStatus.Text = "File Creating";
            await task;
            lblFileStatus.Text = "Completed File Creating";
        }
        protected bool CompleteTask()
        {
            GetGVData FillGV = new GetGVData();
            ExcelFileOperations FileOperations = new ExcelFileOperations();
            DataSet ds = new DataSet();
            ds.Tables.Add(FillGV.GetDMApprovedForCEO("spPrintExcel", "SEDOCAPPROVED", "Bengaluru Dakshina", "APPROVED"));
            FileOperations.ExportToExcel(ds, Server.MapPath("~/DownloadFiles/" + "Bengaluru Dakshina" + ".xlsx"), "3", "Bengaluru Dakshina");
            System.Threading.Thread.Sleep(3000);
            return true;
        }
        protected void btnUpdateTaluk_Click(object sender, EventArgs e)
        {
            //GetApplicationList("spTempUpdate", "GETAPPLICATIONLIST");
            string[] ApplicationNumberList = GetApplicationList("spTempUpdate", "GETAPPLICATIONLIST").Split(',');
            foreach (string ApplicationNumber in ApplicationNumberList)
            {
                //GetRDNumber("spTempUpdate", "GETRDNUM", ApplicationNumber);
                //GetCasteAndIncomeCertificate(GetRDNumber("spTempUpdate", "GETRDNUM", ApplicationNumber));
                string UpdateString = "UPDATE SelfEmpLoan SET ParTaluk =N'"+ GetCasteAndIncomeCertificate(GetRDNumber("spTempUpdate", "GETRDNUM", ApplicationNumber)) + "' WHERE ApplicationNumber=@ApplicationNumber";
                using (SqlCommand cmd = new SqlCommand(UpdateString))
                {
                    SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                    cmd.Connection = kvdConn;
                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }
        }
        private string GetCasteAndIncomeCertificate(string RDNumber)
        {
            string NCTalukName="";
            try
            {
                XElement xElement;
                XmlDocument xmlDocument = new XmlDocument();
                XmlDocument xmlApplicantDetails = new XmlDocument();
                WebServiceSoapClient NCWebService = new WebServiceSoapClient("WebServiceSoap");
                xElement = NCWebService.GetXmlDataWoDSCV(RDNumber);
                //xElement = NCWebService.GetXmlDataWoDSCV("RD0038750142124");
                xmlDocument.LoadXml(xElement.ToString());

                if (Int32.Parse(xElement.Element("FacilityCode").Value.ToString()) == 42)
                {
                    string xml = HttpUtility.HtmlDecode(xElement.Element("xmlData").ToString()).Replace("\r", "").Replace("\n", "").Replace("{Text = \"", "").Replace("\"", "")
                .Replace("{", "").Replace("}", "").Replace("\"", "");
                    xmlApplicantDetails.LoadXml(xml);

                    XmlNodeList nodeList = xmlApplicantDetails.GetElementsByTagName("ApplicantDetails");
                    foreach (XmlNode nodeRes in nodeList)
                    {

                        NCTalukName = nodeRes["TalukName"].InnerText;
                        return nodeRes["TalukName"].InnerText;
                    }
                    return "NA";
                }
                return "NA";
            }
            catch (Exception ex)
            {
                return "NA";
                //DisplayAlert(ex.Message, this);
            }
        }
        public string GetApplicationList(string StotedProcedureName, string MethodName)
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(StotedProcedureName, kvdConn))
                {
                    if (StotedProcedureName != "")
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@status", MethodName);
                        cmd.Parameters.Add("@RetValue", SqlDbType.VarChar, -1);
                        cmd.Parameters["@RetValue"].Direction = ParameterDirection.Output;
                        kvdConn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            kvdConn.Close();
                            return cmd.Parameters["@RetValue"].Value.ToString();
                        }
                        //int count = (int)cmd.ExecuteScalar();
                        //return count.ToString();
                    }
                    return "NA";
                }
            }
        }
        public string GetRDNumber(string StotedProcedureName, string MethodName,string ApplicationNumber)
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(StotedProcedureName, kvdConn))
                {
                    if (StotedProcedureName != "")
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@status", MethodName);
                        cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);
                        cmd.Parameters.Add("@RetValue", SqlDbType.VarChar, -1);
                        cmd.Parameters["@RetValue"].Direction = ParameterDirection.Output;
                        kvdConn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            kvdConn.Close();
                            return cmd.Parameters["@RetValue"].Value.ToString();
                        }
                        //int count = (int)cmd.ExecuteScalar();
                        //return count.ToString();
                    }
                    return "NA";
                }
            }
        }
        protected void btnPDFGenerate_Click(object sender, EventArgs e)
        {
            
            ReportDocument RD = new ReportDocument();
            RD.Load(Server.MapPath("/Reports/DocumentationDownload.rpt"));
            ParameterField myParam = new ParameterField();
            ParameterDiscreteValue myDiscreteValue = new ParameterDiscreteValue();

            //            RD.SetParameterValue("rptTxtBalaji","dbsdjf");

            //TextObject TO = (TextObject)RD.ReportDefinition.Sections["Section1"].ReportObjects["rptTxtBalaji"];
            //TextObject TO1 = (TextObject)RD.ReportDefinition.Sections["Section1"].ReportObjects["Text1"];
            //TO.Text = "23 kajsdnf";
            //TO1.Text = "CªÀ¢üAiÀÄ£ÀÄß";
            //TO.ApplyFont(new System.Drawing.Font("Arial", 11f, System.Drawing.FontStyle.Bold));
            //TO1.ApplyFont(new System.Drawing.Font("Nudi 01 e", 11f, System.Drawing.FontStyle.Bold));

            RD.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "abc");
            RD.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Crystal");
        }
    }
    public class TokenResponse
    {
        public string username { get; set; }
        public bool authenticated { get; set; }
        public string token { get; set; }
    }

}