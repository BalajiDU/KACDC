using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.DataProcessing.Aadhaar
{
    public class AadhaarError
    {
        public string GetAadhaarErrorMessage(string OTPErrorCode)
        {
            if (OTPErrorCode == "AUA-OTP-01")
                return "Invalid OTP";
            else if (OTPErrorCode == "AUA-OTP-05")
                return "OTP Expired";
            else if (OTPErrorCode == "111")
                return "Aadhaar is not linked to mobile number";
            else if (OTPErrorCode == "AUA-OTP-05")
                return "Invalid OTP";
            else
                return "Unable to Connect, Try again "+ OTPErrorCode;
        }
    }
}