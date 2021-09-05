using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.Declaration.WebServices
{
    public class WSApprovedDataForTally
    {
        public string ApplicationNumber { get; set; }
        public string ApplicantName { get; set; }
        public string DistrictCD { get; set; }
        public string LoanName { get; set; }
        public string LoanAmount { get; set; }
        public string ACCOUNTNUMBER { get; set; }
        public string Error { get; set; }
    }
}