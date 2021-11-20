using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KACDC.Class.Declaration.WebServices
{
    
    public class WSSuvidha
    {
        public string ApplicationNumber { get; set; }
        public string RDNumber { get; set; }
        public string Aadhaar { get; set; }
        //[DataMember(EmitDefaultValue = false)]
        public string LoanAmount1 { get; set; }
        public string LoanAmount2 { get; set; }
        public string LoanAmount3 { get; set; }
        public string LoanAmount4 { get; set; }
        public string LoanAmount5 { get; set; }
        public string LoanAmount6 { get; set; }
        public string Status { get; set; }
        public string FinancialYear { get; set; }
        public string ApplicantName { get; set; }

    }
}