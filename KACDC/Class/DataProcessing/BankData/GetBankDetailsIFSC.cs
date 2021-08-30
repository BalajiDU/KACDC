using KACDC.Class.Declaration.BankDetails;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace KACDC.Class.DataProcessing.BankData
{
    public class GetBankDetailsIFSC
    {
        DecBankDetails BD = new DecBankDetails();
        public bool GetBankDetails(string IFSC)
        {
            try
            {
                string json = (new WebClient()).DownloadString("https://ifsc.razorpay.com/" + IFSC);

                var details = JObject.Parse(json);
                BD.UPI = details["UPI"].ToString().ToUpper();
                BD.CENTRE = details["CENTRE"].ToString();
                BD.RTGS = details["RTGS"].ToString().ToUpper();
                BD.DISTRICT = details["DISTRICT"].ToString();
                BD.MICR = details["MICR"].ToString();
                BD.BRANCH = details["BRANCH"].ToString();
                BD.NEFT = details["NEFT"].ToString().ToUpper();
                BD.CITY = details["CITY"].ToString();
                BD.STATE = details["STATE"].ToString();
                BD.ADDRESS = details["ADDRESS"].ToString();
                BD.SWIFT = details["SWIFT"].ToString();
                BD.IMPS = details["IMPS"].ToString().ToUpper();
                BD.BANK = details["BANK"].ToString();
                BD.BANKCODE = details["BANKCODE"].ToString();
                BD.IFSC = details["IFSC"].ToString();
                BD.FULLADDRESS = details["ADDRESS"].ToString() + ", " + details["CITY"].ToString() + ", " + details["DISTRICT"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
    }
}