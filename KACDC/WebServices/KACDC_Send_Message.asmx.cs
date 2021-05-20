using KACDC.Class.DataProcessing.SMSService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace KACDC.WebServices
{
    /// <summary>
    /// Summary description for KACDC_Send_Message
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class KACDC_Send_Message : System.Web.Services.WebService
    {

        [WebMethod]
        public string SendMessage(string Message,string MobileNumber,string MessageType,string Key)
        {
            if (Key == "KABA94ASBHSU14DBA3U")
            {
                if (Message.Length > 1)
                {
                    if (MobileNumber.Length == 10)
                    {
                        if(System.Text.RegularExpressions.Regex.IsMatch(MobileNumber, @"^\d+$"))
                        {
                            SendSMS SM = new SendSMS();
                            return SM.sendSMS(MobileNumber,Message,2, MessageType);
                        }
                        else { return "Invalid Mobile Number"; }
                    }
                    else { return "Invalid Mobile Number"; }
                }
                else { return "Invalid Message"; }
            }
            else { return "Invalid Key"; }
        }
    }
}
