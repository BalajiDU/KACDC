using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.Declaration.WebServices
{
    public class WSPaymentStatistics
    {
        public string ApplicationNumber { get; set; }
        public string ApplicantName { get; set; }
        public string LoanAmount { get; set; }
        public string ReleaseDate { get; set; }
        public string ZMApprove { get; set; }
        public string DISTRICT { get; set; }
        public string ZONE { get; set; }
        public string LOANNUMBER { get; set; }
        public string TOTALPAID { get; set; }
        public string LASTPAID { get; set; }
        public string SINSCNOTPAID { get; set; }
        public string INSTALMENT { get; set; }
        public string PAYABLEINSTALMENTS { get; set; }
        public string PAYABLEAMOUNT { get; set; }
        public string REMAININGAMOUNT { get; set; }

        public string Error { get; set; }
    }
}