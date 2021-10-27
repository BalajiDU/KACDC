using KACDC.Class.DataProcessing.EmailService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.DataProcessing.OnlineApplication
{
    public class ApplicationSubmitEmail
    {
        MailingService MS = new MailingService();
        public void ApplicantEmailConfirmation(string EmailID, string ApplicationNumber, string LoanName, string ApplicantName, byte[] ApplicationCopy, string FileName)
        {
            string EmailBody = "Dear Applicant, " + ApplicantName + " your " + LoanName + " loan application number " + ApplicationNumber + " is received. We will notify once processed. <br /><br />From:<br />KARNATAKA ARYA VYSYA COMMUNITY DEVELOPMENT CORPORATION LTD";
            MS.SendMail(LoanName+" Loan Application Acknowledgment : "+ApplicationNumber,
                EmailBody, EmailID,"", ApplicationCopy,FileName);
        }
        public void ApplicantEmailSanction(string EmailID, string ApplicationNumber, string LoanNumber, string LoanName, string ApplicantName, byte[] ApplicationCopy, string FileName)
        {
            string EmailBody = "Dear Beneficiary, " + ApplicantName + " your " + LoanName + " loan application number " + ApplicationNumber + " is approved and your loan number is "+ LoanNumber + ". <br />Please find the attachment of Sanction Copy. <br /><br />From:<br />KARNATAKA ARYA VYSYA COMMUNITY DEVELOPMENT CORPORATION LTD";
            MS.SendMail(LoanName+ " Sanction Copy : " + ApplicationNumber,
                EmailBody, EmailID,"", ApplicationCopy,FileName);
        }
    }
}