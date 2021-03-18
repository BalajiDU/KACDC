using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using GoogleMaps.LocationServices;

namespace KACDC
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString);
        int userId = 0;
        static string LoginUserName, UserType, UserPwd,UserActivation, UserDistrict;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ValidateUser(object sender, EventArgs e)
        {
            LoginUserName = Login1.UserName.Trim();
            //string a = "@dm!nK@cdC@2019";
            using (kvdConn)
            {
                GetAdminPwd();


                Decrypt();


                if (Login1.Password.Trim() != UserPwd)
                {
                    userId = -1;
                }
                else if (UserActivation != "TRUE      ")
                {
                    userId = 2;
                }
                else {
                    userId = 1;
                }
                WriteErrorLog(LoginUserName, UserType);
                switch (userId)
                {
                    case -1:
                        Login1.FailureText = "Username and/or password is incorrect.";
                        break;
                    case -2:
                        Login1.FailureText = "Account has not been activated.";
                        break;
                    case 1:
                        if(UserType== "ADMIN")
                        {
                            Session["USERTYPE"] = "ADMIN";
                            Session["District"] = UserDistrict;
                            Session["Designation"] = UserType;
                            Response.Redirect(@"~\AdminHome.aspx");
                        }
                        else if (UserType == "DATAVIEW")
                        {
                            Session["USERTYPE"] = "DATAVIEW";
                            Session["District"] = UserDistrict;
                            Session["Designation"] = UserType;
                            Response.Redirect(@"~\KACDC_AppInfo.aspx");
                        }
                        else if (UserType == "CASEWORKER")
                        {
                            Session["USERTYPE"] = "CASEWORKER";
                            Session["District"] = UserDistrict;
                            Session["Designation"] = UserType;
                            Session["UserName"] = LoginUserName;
                            Response.Redirect(@"~\ApprovalPage\CW_Approval.aspx");
                        }
                        else if (UserType == "DISTRICTMANAGER")
                        {
                            Session["USERTYPE"] = "DISTRICTMANAGER";
                            Session["District"] = UserDistrict;
                            Session["Designation"] = UserType;
                            Session["UserName"] = LoginUserName;
                            Response.Redirect(@"~\ApprovalPage\DM_Approval.aspx");
                        }
                        else if (UserType == "ZONALMANAGER")
                        {
                            Session["USERTYPE"] = "ZONALMANAGER";
                            Session["Zone"] = UserDistrict;
                            Session["Designation"] = UserType;
                            Response.Redirect(@"~\ApprovalPage\ZM_Approval.aspx");
                        }
                        else if (UserType == "APPDOWNLOAD")
                        {
                            Session["USERTYPE"] = "APPDOWNLOAD";
                            Session["District"] = UserDistrict;
                            Session["Designation"] = UserType;
                            Response.Redirect(@"~\DownloadAppn.aspx");
                        }
                        else if (UserType == "ADMINAPPROVE")
                        {
                            Session["USERTYPE"] = "ADMINAPPROVE";
                            Session["District"] = UserDistrict;
                            Session["Designation"] = UserType;
                            Response.Redirect(@"~\AdminApprove.aspx");
                        }
                        else if (UserType == "CHECKRD")
                        {
                            Session["USERTYPE"] = "CHECKRD";
                            Session["District"] = UserDistrict;
                            Session["Designation"] = UserType;
                            Response.Redirect(@"~\CheckRD.aspx");
                        }
                        else if (UserType == "MESSAGESERVICE")
                        {
                            Session["USERTYPE"] = "MESSAGESERVICE";
                            Session["District"] = UserDistrict;
                            Session["Designation"] = UserType;
                            Response.Redirect(@"~\Service\BulkMessageService.aspx");
                        }
                        else if (UserType == "DASHBOARD")
                        {
                            Session["USERTYPE"] = "DASHBOARD";
                            Session["District"] = UserDistrict;
                            Session["Designation"] = UserType;
                            Response.Redirect(@"~\Service\Admin_Dashboard.aspx");
                        }


                        break;
                    case 2:
                        Login1.FailureText = "Account has not been activated.";
                        break;
                    default:
                        FormsAuthentication.RedirectFromLoginPage(LoginUserName, Login1.RememberMeSet);
                        break;
                }
            }
        }
        private void Decrypt()
        {
            string EncryptionKey = "KABA94ASBHSU143";
            // string EncryptisnKey = "KABA94ASBHSU143";
            byte[] cipherBytes = Convert.FromBase64String(UserPwd);
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
                    UserPwd = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            //return UserPwd;
        }
        private void GetAdminPwd()
        {
            using (SqlCommand cmd = new SqlCommand("Validate_AdminUser"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", LoginUserName);
                cmd.Parameters.Add("@Password", SqlDbType.VarChar,-1);
                cmd.Parameters["@Password"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@UserType", SqlDbType.VarChar, -1);
                cmd.Parameters["@UserType"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Active", SqlDbType.VarChar, -1);
                cmd.Parameters["@Active"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@District", SqlDbType.VarChar, -1);
                cmd.Parameters["@District"].Direction = ParameterDirection.Output;

                cmd.Connection = kvdConn;
                kvdConn.Open();
                userId = Convert.ToInt32(cmd.ExecuteScalar());
                kvdConn.Close();
                UserType= cmd.Parameters["@UserType"].Value.ToString();

                UserPwd= cmd.Parameters["@Password"].Value.ToString();

                UserActivation= cmd.Parameters["@Active"].Value.ToString();

                UserDistrict = cmd.Parameters["@District"].Value.ToString();
            }
        }

        protected void WriteErrorLog(string username, string UserType)
        {
            string ipaddress;
            ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
                ipaddress = Request.ServerVariables["REMOTE_ADDR"];

            string webPageName = Path.GetFileName(Request.Path);
            string errorLogFilename = "Login_Logging.txt";
            string path = Server.MapPath("~/LogFiles/LoginLogFile/" + errorLogFilename);
            if (File.Exists(path))
            {
                using (StreamWriter stwriter = new StreamWriter(path, true))
                {
                    stwriter.WriteLine("\n-----------------New Login-----------------");
                    stwriter.WriteLine("Date : " + DateTime.Now.ToString("dd-MM-yyyy"));
                    stwriter.WriteLine("Time : " + DateTime.Now.ToString("hh:mm tt"));
                    stwriter.WriteLine("WebPage Name :" + webPageName);
                    stwriter.WriteLine("User Name:" + username);
                    stwriter.WriteLine("User Type:" + UserType);
                    stwriter.WriteLine("IP:" + ipaddress );

                }
            }
            else
            {
                StreamWriter stwriter = File.CreateText(path);
                stwriter.WriteLine("-----------------New Login-----------------");
                stwriter.WriteLine("Date : " + DateTime.Now.ToString("dd-MM-yyyy"));
                stwriter.WriteLine("Time : " + DateTime.Now.ToString("hh:mm tt"));
                stwriter.WriteLine("WebPage Name :" + webPageName);
                stwriter.WriteLine("User Name:" + username);
                stwriter.WriteLine("User Type:" + UserType);
                stwriter.WriteLine("IP:" + ipaddress);
                stwriter.Close();
            }
        }
    }
}