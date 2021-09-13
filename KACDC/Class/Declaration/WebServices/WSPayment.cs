using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.Declaration.WebServices
{
    public class WSPayment
    {
        public string ApplicationNumber { get; set; }
        public string ApplicantName { get; set; }
        public string LoanNumber { get; set; }
        public string District { get; set; }
        public string PaymentDate { get; set; }
        public string PayedAmount { get; set; }
        public string PaymentMode { get; set; }
        public string Remarks { get; set; }
        public string Zone { get; set; }
        public string ReceiptNumber { get; set; }
        public string ReceiptGeneratedDate { get; set; }
        public string AddedBy { get; set; }
        public string modified_by { get; set; }
        public string modified_datetime { get; set; }
        public string pay_status { get; set; }
        public string pay_otp { get; set; }
        public string Error { get; set; }

    }
}