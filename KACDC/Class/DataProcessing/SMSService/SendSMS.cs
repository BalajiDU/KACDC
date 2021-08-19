using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace KACDC.Class.DataProcessing.SMSService
{
    public class SendSMS
    {
        CreateSMSLog LOG = new CreateSMSLog();
        public string sendSMS(string MobileNumber, string Message, int Language, string Cetegory)
        {
            ///API service key: 8116a1fe - c69c - 49a0 - 8f9f - 0e0b2b2dcac1
            ///Sender id: KAVDES
            ///Username: Mobile_1 - KAVDES
            ///Password: kavdes@1234

            ///API service key: 9a7aebf7-843a-4da8-8ed7-48ebd2ea71af
            ///Sender id: GKACDC
            ///Username: Mobile_1 - GKACDC
            ///Password: gkacdc@1234

            ///Language
            ///Unicode:1
            ///English:2

            ///Template: PAYMENT STATUS
            ///Category: PAYSTS
            ///ID: 1107161001617332958
            ///User: KAVDES
            ///Text : "Thank You {#var#},for repayment of Rs. {#var#} for the account {#var#}. From: KARNATAKA ARYA VYSYA COMMUNITY DEVELOPMENT CORPORATION

            ///Template: NOTIFICATION
            ///Category: APPCAL
            ///ID: 1107160931579290352
            ///User: KAVDES
            ///Text : To all {#var#}, Karnataka Arya Vysya community Development Corporation has called for applications for 2 schemes and last date is {#var#}. Form G caste and income certificate for Arya Vysya is compulsory to apply for loan, request you to issue caste and income certificate in Form G as per the government order attached below link.{#var#}

            ///Template: APPLICATION NOTIFICATION
            ///Category: SAAPPS
            ///ID: 1107160931572557362
            ///User: KAVDES
            ///Text : Arya Vysya Community People can now apply for {#var#} loan and {#var#} scheme in {#var#}. For information contact Helpline: {#var#}Email: {#var#} LAST DATE FOR APPLYING ONLINE APPLICATION IS {#var#}


            ///Template: USER CREATION
            ///Category: USRCRE
            ///ID: 1107160931568711448
            ///User: KAVDES
            ///Text : Dear Beneficiary, {#var#} your loan repayment USER ID and PASSWORD is your registered mobile number.Click Following link to Login {#var#}.From:KAVDES


            ///Template: LOAN CLOSER
            ///Category: LANCLR
            ///ID: 1107160931564447289
            ///User: KAVDES
            ///Text : Dear Beneficiary, {#var#} your loan account {#var#} is fully repaid and closed. From:KARNATAKA ARYA VYSYA COMMUNITY DEVELOPMENT CORPORATION


            ///Template: OTP KAVDES
            ///Category: LGNOTP
            ///ID: 1107160931550750179
            ///User: KAVDES
            ///Text : {#var#} is your OTP to verify, your application number {#var#}. do not share with others. From:KARNATAKA ARYA VYSYA COMMUNITY DEVELOPMENT CORPORATION



            ///Template: Reminder by KDAC
            ///Category: PAYREM
            ///ID: 1107161001607292719
            ///User: GKACDC
            ///Text : Dear Beneficiary, we request you to repay the loan instalments on time in the concerned district office on or before {#var#}.If you already paid Ignore this message. From: KACDC

            ///Template: STATUS UPDATE 1
            /// Category: APPSTS
            /// ID: 1107161001582618828
            /// User: GKACDC
            /// Text : Dear applicant {#var#}, your application is approved. Kindly complete the documentation process by visiting district office. From: KACDC


            ///Template: ACKNOWLEDGEMENT 3
            /// Category: ACKNOW
            /// ID: 1107161001578434595
            /// User: GKACDC
            /// Text : Dear Applicant, {#var#} is your {#var#} loan application number {#var#} is received. We will notify once processed. From: KACDC


            string UserName = "";
            string Password = "";
            string APIkey = "";
            string SenderId = "";
            string MessageStatus = "";
            string TemplateID = "";
            string SMSLanguage = "";

            string KAVDESAPIkey = "8116a1fe-c69c-49a0-8f9f-0e0b2b2dcac1";
            string KAVDESSenderId = "KAVDES";
            string KAVDESUserName = "Mobile_1-KAVDES";
            string KAVDESPassword = "kavdes@1234";

            string GKACDCAPIkey = "9a7aebf7-843a-4da8-8ed7-48ebd2ea71af";
            string GKACDCSenderId = "GKACDC";
            string GKACDCUserName = "Mobile_1-GKACDC";
            string GKACDCPassword = "gkacdc@1234";

            //using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            //{
            //    using (SqlCommand cmd = new SqlCommand("select SMSLanguage,SMSUser from SMSTemplate where KeyVal=@Cetegory", kvdConn))
            //    {
            //        cmd.CommandType = CommandType.Text;
            //        cmd.Parameters.AddWithValue("@Cetegory", Cetegory);

            //        cmd.Connection = kvdConn;
            //        kvdConn.Open();
            //        using (SqlDataReader sdr = cmd.ExecuteReader())
            //        {
            //            sdr.Read();
            //            SMSLanguage = sdr["SMSLanguage"].ToString();
            //            UserName = "Mobile_1-"+sdr["SMSUser"].ToString();
            //        }
            //        kvdConn.Close();
            //    }
            //}
            //using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            //{
            //    using (SqlCommand cmd = new SqlCommand("select  Value,Value1 from KACDCSettings where Cetegory=@UserName", kvdConn))
            //    {
            //        cmd.CommandType = CommandType.Text;
            //        cmd.Parameters.AddWithValue("@UserName", UserName);

            //        cmd.Connection = kvdConn;
            //        kvdConn.Open();
            //        using (SqlDataReader sdr = cmd.ExecuteReader())
            //        {
            //            sdr.Read();
            //            GKACDCPassword = sdr["Value"].ToString();
            //            GKACDCAPIkey = sdr["Value1"].ToString();
            //        }
            //        kvdConn.Close();
            //    }
            //}

            switch (Cetegory)
            {
                case "PAYSTS":
                    UserName = KAVDESUserName;
                    Password = KAVDESPassword;
                    SenderId = KAVDESSenderId;
                    APIkey = KAVDESAPIkey;
                    TemplateID = "1107161001617332958";
                    break;
                case "MOBVER":
                    UserName = KAVDESUserName;
                    Password = KAVDESPassword;
                    SenderId = KAVDESSenderId;
                    APIkey = KAVDESAPIkey;
                    TemplateID = "1107162556447130963";
                    break;
                case "APPCAL":
                    UserName = KAVDESUserName;
                    Password = KAVDESPassword;
                    SenderId = KAVDESSenderId;
                    APIkey = KAVDESAPIkey;
                    TemplateID = "1107160931579290352";
                    break;
                case "SAAPPS":
                    UserName = KAVDESUserName;
                    Password = KAVDESPassword;
                    SenderId = KAVDESSenderId;
                    APIkey = KAVDESAPIkey;
                    TemplateID = "1107160931572557362";
                    break;
                case "USRCRE":
                    UserName = KAVDESUserName;
                    Password = KAVDESPassword;
                    SenderId = KAVDESSenderId;
                    APIkey = KAVDESAPIkey;
                    TemplateID = "1107160931568711448";
                    break;
                case "LANCLR":
                    UserName = KAVDESUserName;
                    Password = KAVDESPassword;
                    SenderId = KAVDESSenderId;
                    APIkey = KAVDESAPIkey;
                    TemplateID = "1107160931564447289";
                    break;
                case "LGNOTP":
                    UserName = KAVDESUserName;
                    Password = KAVDESPassword;
                    SenderId = KAVDESSenderId;
                    APIkey = KAVDESAPIkey;
                    TemplateID = "1107160931550750179";
                    break;
                case "PAYREM":
                    UserName = GKACDCUserName;
                    Password = GKACDCPassword;
                    SenderId = GKACDCSenderId;
                    APIkey = GKACDCAPIkey;
                    TemplateID = "1107161001607292719";
                    break;
                case "APPSTS":
                    UserName = GKACDCUserName;
                    Password = GKACDCPassword;
                    SenderId = GKACDCSenderId;
                    APIkey = GKACDCAPIkey;
                    TemplateID = "1107161001582618828";
                    break;
                case "ACKNOW":
                    UserName = GKACDCUserName;
                    Password = GKACDCPassword;
                    SenderId = GKACDCSenderId;
                    APIkey = GKACDCAPIkey;
                    TemplateID = "1107161001578434595";
                    break;
                case "COVIDMSG":
                    UserName = GKACDCUserName;
                    Password = GKACDCPassword;
                    SenderId = GKACDCSenderId;
                    APIkey = GKACDCAPIkey;
                    TemplateID = "1107162556442347820";
                    break;
                default:
                    UserName = GKACDCUserName;
                    Password = GKACDCPassword;
                    SenderId = GKACDCSenderId;
                    APIkey = GKACDCAPIkey;
                    TemplateID = "1107161001582618828";
                    break;
            }
            string CheckCetegory = "";
            if (Cetegory == "PAYSTS" || Cetegory == "APPCAL" || Cetegory == "LANCLR" || Cetegory == "ACKNOW")
            {
                CheckCetegory = "SINGLE";
            }
            else if(Cetegory== "SAAPPS"||Cetegory== "USRCRE"||Cetegory== "PAYREM"||Cetegory== "APPSTS")
            {
                CheckCetegory = "BULK";
            }
            else
            {
                CheckCetegory = Cetegory;
            }

            if (Language == 2)
            {
                switch (CheckCetegory)
                {
                    case "SINGLE":
                        MessageStatus = sendSingleSMS(UserName, Password, SenderId, MobileNumber, Message, APIkey, TemplateID);
                        break;
                    case "BULK":
                        MessageStatus = sendBulkSMS(UserName, Password, SenderId, MobileNumber, Message, APIkey, TemplateID);
                        break;
                    case "LGNOTP":
                        MessageStatus = sendOTPMSG(UserName, Password, SenderId, MobileNumber, Message, APIkey, TemplateID);
                        break;
                    case "OTP":
                        MessageStatus = sendOTPMSG(UserName, Password, SenderId, MobileNumber, Message, APIkey, TemplateID);
                        break;
                    default:
                        MessageStatus = sendBulkSMS(UserName, Password, SenderId, MobileNumber, Message, APIkey, TemplateID);
                        break;

                }
            }
            else if (Language == 1)
            {
                MessageStatus = sendUnicodeSMS(UserName, Password, SenderId, MobileNumber, Message, APIkey, TemplateID);
            }
            LOG.CreateLog(Cetegory, MobileNumber, MessageStatus, Message);
            if (MessageStatus.StartsWith("402"))
            {
                return "Message Sent";
            }
            else
            {
                return MessageStatus;
            }
        }

        public string BulkMessaging(string username, string password, string senderid, string MobileNumber, string Message, string secureKey, string templateid, string Language, string MessageType,string Cetegory)
        {
            string MessageStatus = "";
            if (Language == "Kannada")
            {
                MessageStatus = sendUnicodeSMS(username, password, senderid, MobileNumber, Message, secureKey, templateid);
            }
            else
            {if (MessageType == "FGTPWD")
                {
                    MessageStatus = sendOTPMSG(username, password, senderid, MobileNumber, Message, secureKey, templateid);
                }
                else
                {
                    if (MessageType == "Single")
                    {
                        MessageStatus = sendSingleSMS(username, password, senderid, MobileNumber, Message, secureKey, templateid);
                    }
                    else
                    {
                        MessageStatus = sendBulkSMS(username, password, senderid, MobileNumber, Message, secureKey, templateid);
                    }
                }
            }

            LOG.CreateLog(Cetegory, MobileNumber, MessageStatus, Message);
            if (MessageStatus.StartsWith("402"))
            {
                //return MessageStatus; 
                return "Message Sent";
            }
            else
            {
                return MessageStatus;
            }
        }



        /// <summary>
        /// Method for sending single SMS.
        /// </summary>
        /// <param name="username"> Registered user name
        /// <param name="password"> Valid login password
        /// <param name="senderid">Sender ID
        /// <param name="mobileNo"> valid Single Mobile Number
        /// <param name="message">Message Content
        /// <param name="secureKey">Department generate key by login to services portal
        /// <param name="templateid">templateid unique for each template message content


        // Method for sending single SMS.

        public String sendSingleSMS(String username, String password, String senderid, string mobileNo, String message, String secureKey, String templateid)
        {
            //Latest Generated Secure Key
            Stream dataStream;

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; //forcing .Net framework to use TLSv1.2

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequestDLT");
            request.ProtocolVersion = HttpVersion.Version10;
            request.KeepAlive = false;
            request.ServicePoint.ConnectionLimit = 1;

            //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
            ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0;Windows 98; DigExt)";


            request.Method = "POST";

            System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();

            String encryptedPassword = encryptedPasswod(password);
            String NewsecureKey = hashGenerator(username.Trim(), senderid.Trim(), message.Trim(), secureKey.Trim());
            String smsservicetype = "singlemsg"; //For single message.

            String query = "username=" + HttpUtility.UrlEncode(username.Trim()) +
            "&password=" + HttpUtility.UrlEncode(encryptedPassword) +

            "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +

            "&content=" + HttpUtility.UrlEncode(message.Trim()) +

            "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +

            "&senderid=" + HttpUtility.UrlEncode(senderid.Trim()) +
            "&key=" + HttpUtility.UrlEncode(NewsecureKey.Trim()) +
            "&templateid=" + HttpUtility.UrlEncode(templateid.Trim());



            byte[] byteArray = Encoding.ASCII.GetBytes(query);

            request.ContentType = "application/x-www-form-urlencoded";

            request.ContentLength = byteArray.Length;



            dataStream = request.GetRequestStream();

            dataStream.Write(byteArray, 0, byteArray.Length);

            dataStream.Close();

            WebResponse response = request.GetResponse();

            String Status = ((HttpWebResponse)response).StatusDescription;

            dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);

            String responseFromServer = reader.ReadToEnd();

            reader.Close();

            dataStream.Close();

            response.Close();
            return responseFromServer;

        }


        /// <summary>
        /// Method for sending bulk SMS.
        /// </summary>
        /// <param name="username"> Registered user name
        /// <param name="password"> Valid login password
        /// <param name="senderid">Sender ID
        /// <param name="mobileNo"> valid Mobile Numbers
        /// <param name="message">Message Content
        /// <param name="secureKey">Department generate key by login to services portal
        /// <param name="templateid">templateid unique for each template message content

        // method for sending bulk SMS

        public String sendBulkSMS(String username, String password, String senderid, string mobileNos, String message, String secureKey, String templateid)
        {
            Stream dataStream;

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequestDLT");
            request.ProtocolVersion = HttpVersion.Version10;
            request.KeepAlive = false;
            request.ServicePoint.ConnectionLimit = 1;

            //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
            ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0;Windows 98; DigExt)";

            request.Method = "POST";

            System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();

            String encryptedPassword = encryptedPasswod(password);
            String NewsecureKey = hashGenerator(username.Trim(), senderid.Trim(), message.Trim(), secureKey.Trim());
            Console.Write(NewsecureKey);
            Console.Write(encryptedPassword);

            String smsservicetype = "bulkmsg"; // for bulk msg

            String query = "username=" + HttpUtility.UrlEncode(username.Trim()) +

            "&password=" + HttpUtility.UrlEncode(encryptedPassword) +

            "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +

            "&content=" + HttpUtility.UrlEncode(message.Trim()) +

            "&bulkmobno=" + HttpUtility.UrlEncode(mobileNos) +

            "&senderid=" + HttpUtility.UrlEncode(senderid.Trim()) +

            "&key=" + HttpUtility.UrlEncode(NewsecureKey.Trim()) +
            "&templateid=" + HttpUtility.UrlEncode(templateid.Trim());
            Console.Write(query);

            byte[] byteArray = Encoding.ASCII.GetBytes(query);

            request.ContentType = "application/x-www-form-urlencoded";

            request.ContentLength = byteArray.Length;

            dataStream = request.GetRequestStream();

            dataStream.Write(byteArray, 0, byteArray.Length);

            dataStream.Close();

            WebResponse response = request.GetResponse();

            String Status = ((HttpWebResponse)response).StatusDescription;

            dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);

            String responseFromServer = reader.ReadToEnd();

            reader.Close();

            dataStream.Close();

            response.Close();
            return responseFromServer;

        }


        /// <summary>
        /// method for Sending unicode..
        /// </summary>
        /// <param name="username"> Registered user name
        /// <param name="password"> Valid login password
        /// <param name="senderid">Sender ID
        /// <param name="mobileNo"> valid Mobile Numbers
        /// <param name="Unicodemessage">Unicodemessage Message Content
        /// <param name="secureKey">Department generate key by login to services portal
        /// <param name="templateid">templateid unique for each template message content

        //method for Sending unicode message..

        public String sendUnicodeSMS(String username, String password, String senderid, String mobileNos, String Unicodemessage, String secureKey, String templateid)

        {
            Stream dataStream;

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; //forcing .Net framework to use TLSv1.2

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequestDLT");
            request.ProtocolVersion = HttpVersion.Version10;
            request.KeepAlive = false;
            request.ServicePoint.ConnectionLimit = 1;

            //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
            ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0;Windows 98; DigExt)";

            request.Method = "POST";

            System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
            String U_Convertedmessage = "";

            foreach (char c in Unicodemessage)
            {
                int j = (int)c;
                String sss = "&#" + j + ";";
                U_Convertedmessage = U_Convertedmessage + sss;
            }
            String encryptedPassword = encryptedPasswod(password);
            String NewsecureKey = hashGenerator(username.Trim(), senderid.Trim(), U_Convertedmessage.Trim(), secureKey.Trim());

            String smsservicetype = "unicodemsg"; // for unicode msg
            String query = "username=" + HttpUtility.UrlEncode(username.Trim()) +
            "&password=" + HttpUtility.UrlEncode(encryptedPassword) +
            "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
            "&content=" + HttpUtility.UrlEncode(U_Convertedmessage.Trim()) +
            "&bulkmobno=" + HttpUtility.UrlEncode(mobileNos) +
            "&senderid=" + HttpUtility.UrlEncode(senderid.Trim()) +
            "&key=" + HttpUtility.UrlEncode(NewsecureKey.Trim()) +
            "&templateid=" + HttpUtility.UrlEncode(templateid.Trim());


            byte[] byteArray = Encoding.ASCII.GetBytes(query);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            String Status = ((HttpWebResponse)response).StatusDescription;
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }



        /// <summary>
        /// Method for sending OTP MSG.
        /// </summary>
        /// <param name="username"> Registered user name
        /// <param name="password"> Valid login password
        /// <param name="senderid">Sender ID
        /// <param name="mobileNo"> valid single Mobile Number
        /// <param name="message">Message Content
        /// <param name="secureKey">Department generate key by login to services portal
        /// <param name="templateid">templateid unique for each template message content

        // Method for sending OTP MSG.

        public String sendOTPMSG(String username, String password, String senderid, string mobileNo, String message, String secureKey, String templateid)

        {
            Stream dataStream;

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; //forcing .Net framework to use TLSv1.2

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequestDLT");
            request.ProtocolVersion = HttpVersion.Version10;
            request.KeepAlive = false;
            request.ServicePoint.ConnectionLimit = 1;

            //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
            ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0;Windows 98; DigExt)";

            request.Method = "POST";
            System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();

            String encryptedPassword = encryptedPasswod(password);
            String key = hashGenerator(username.Trim(), senderid.Trim(), message.Trim(), secureKey.Trim());
            String smsservicetype = "otpmsg"; //For OTP message.

            String query = "username=" + HttpUtility.UrlEncode(username.Trim()) +
            "&password=" + HttpUtility.UrlEncode(encryptedPassword) +

            "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +

            "&content=" + HttpUtility.UrlEncode(message.Trim()) +

            "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +

            "&senderid=" + HttpUtility.UrlEncode(senderid.Trim()) +
            "&key=" + HttpUtility.UrlEncode(key.Trim()) +
            "&templateid=" + HttpUtility.UrlEncode(templateid.Trim());



            byte[] byteArray = Encoding.ASCII.GetBytes(query);

            request.ContentType = "application/x-www-form-urlencoded";

            request.ContentLength = byteArray.Length;



            dataStream = request.GetRequestStream();

            dataStream.Write(byteArray, 0, byteArray.Length);

            dataStream.Close();

            WebResponse response = request.GetResponse();

            String Status = ((HttpWebResponse)response).StatusDescription;

            dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);

            String responseFromServer = reader.ReadToEnd();

            reader.Close();

            dataStream.Close();

            response.Close();
            return responseFromServer;

        }


        // Method for sending UnicodeOTP MSG.

        /// <summary>
        /// method for Sending unicode..
        /// </summary>
        /// <param name="username"> Registered user name
        /// <param name="password"> Valid login password
        /// <param name="senderid">Sender ID
        /// <param name="mobileNo"> valid Mobile Numbers
        /// <param name="Unicodemessage">Unicodemessage Message Content
        /// <param name="secureKey">Department generate key by login to services portal
        /// <param name="templateid">templateid unique for each template message content12/28/2020 Mobile Seva

        //method for Sending unicode message..

        public String sendUnicodeOTPSMS(String username, String password, String senderid, String mobileNos, String UnicodeOTPmsg, String secureKey, String templateid)
        {
            Stream dataStream;

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; //forcing .Net framework to use TLSv1.2

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequestDLT");
            request.ProtocolVersion = HttpVersion.Version10;
            request.KeepAlive = false;
            request.ServicePoint.ConnectionLimit = 1;

            //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
            ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0;Windows 98; DigExt)";

            request.Method = "POST";
            System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();

            String U_Convertedmessage = "";

            foreach (char c in UnicodeOTPmsg)
            {
                int j = (int)c;
                String sss = "&#" + j + ";";
                U_Convertedmessage = U_Convertedmessage + sss;
            }
            String encryptedPassword = encryptedPasswod(password);
            String NewsecureKey = hashGenerator(username.Trim(), senderid.Trim(), U_Convertedmessage.Trim(), secureKey.Trim());


            String smsservicetype = "unicodeotpmsg"; // for unicode msg
            String query = "username=" + HttpUtility.UrlEncode(username.Trim()) +
            "&password=" + HttpUtility.UrlEncode(encryptedPassword) +
            "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
            "&content=" + HttpUtility.UrlEncode(U_Convertedmessage.Trim()) +
            "&bulkmobno=" + HttpUtility.UrlEncode(mobileNos) +
            "&senderid=" + HttpUtility.UrlEncode(senderid.Trim()) +
            "&key=" + HttpUtility.UrlEncode(NewsecureKey.Trim()) +
            "&templateid=" + HttpUtility.UrlEncode(templateid.Trim());


            byte[] byteArray = Encoding.ASCII.GetBytes(query);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            String Status = ((HttpWebResponse)response).StatusDescription;
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }

        /// <summary>
        /// Method to get Encrypted the password
        /// </summary>
        /// <param name="password"> password as String"

        protected String encryptedPasswod(String password)
        {

            byte[] encPwd = Encoding.UTF8.GetBytes(password);
            //static byte[] pwd = new byte[encPwd.Length];
            HashAlgorithm sha1 = HashAlgorithm.Create("SHA1");
            byte[] pp = sha1.ComputeHash(encPwd);
            // static string result = System.Text.Encoding.UTF8.GetString(pp);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in pp)
            {

                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();

        }

        /// <summary>
        /// Method to Generate hash code
        /// </summary>
        /// <param name="secure_key">your last generated Secure_key

        protected String hashGenerator(String Username, String sender_id, String message, String secure_key)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append(Username).Append(sender_id).Append(message).Append(secure_key);
            byte[] genkey = Encoding.UTF8.GetBytes(sb.ToString());
            //static byte[] pwd = new byte[encPwd.Length];
            HashAlgorithm sha1 = HashAlgorithm.Create("SHA512");
            byte[] sec_key = sha1.ComputeHash(genkey);

            StringBuilder sb1 = new StringBuilder();
            for (int i = 0; i < sec_key.Length; i++)
            {
                sb1.Append(sec_key[i].ToString("x2"));
            }
            return sb1.ToString();
        }

    }

}

class MyPolicy : ICertificatePolicy
{
    public bool CheckValidationResult(ServicePoint srvPoint, X509Certificate certificate, WebRequest request, int certificateProblem)
    {
        return true;
    }
}


