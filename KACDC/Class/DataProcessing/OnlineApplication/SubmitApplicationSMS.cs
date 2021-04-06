using KACDC.Class.DataProcessing.SMSService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.DataProcessing.OnlineApplication
{
    public class SubmitApplicationSMS
    {
        SendSMS MSG = new SendSMS();
        public void ApplicantSMSConfirmation(string MobileNumber, string ApplicationNumber,string LoanName,string ApplicantName)
        {
            string Message = "Dear Applicant, "+ ApplicantName + " your " + LoanName + " loan application number " + ApplicationNumber + " is received. We will notify once processed. From:KARNATAKA ARYA VYSYA COMMUNITY DEVELOPMENT CORPORATION";
            MSG.sendSMS(MobileNumber, Message,2, "ACKNOW");
        }
    }
}