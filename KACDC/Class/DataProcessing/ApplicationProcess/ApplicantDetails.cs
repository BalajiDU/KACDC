using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.DataProcessing.ApplicationProcess
{
    public class ApplicantDetails
    {
        //public string ApplicationNumber
        //{
        //    set { HttpContext.Current.Session["ApplicationNumber"] = value; }
        //    get { return HttpContext.Current.Session["ApplicationNumber"] as string; }
        //}
        public string ApplicationNumber { set { HttpContext.Current.Session["ApplicationNumber"] = value; } get { return HttpContext.Current.Session["ApplicationNumber"] as string; } }
        public string ApplicantName { set { HttpContext.Current.Session["ApplicantName"] = value; } get { return HttpContext.Current.Session["ApplicantName"] as string; } }
        public string FatherName { set { HttpContext.Current.Session["FatherName"] = value; } get { return HttpContext.Current.Session["FatherName"] as string; } }
        public string Gender { set { HttpContext.Current.Session["Gender"] = value; } get { return HttpContext.Current.Session["Gender"] as string; } }
        public string Widowed { set { HttpContext.Current.Session["Widowed"] = value; } get { return HttpContext.Current.Session["Widowed"] as string; } }
        public string Divorced { set { HttpContext.Current.Session["Divorced"] = value; } get { return HttpContext.Current.Session["Divorced"] as string; } }
        public string PhysicallyChallenged { set { HttpContext.Current.Session["PhysicallyChallenged"] = value; } get { return HttpContext.Current.Session["PhysicallyChallenged"] as string; } }
        public string AnualIncome { set { HttpContext.Current.Session["AnualIncome"] = value; } get { return HttpContext.Current.Session["AnualIncome"] as string; } }
        public string RDNumber { set { HttpContext.Current.Session["RDNumber"] = value; } get { return HttpContext.Current.Session["RDNumber"] as string; } }
        public string EmailID { set { HttpContext.Current.Session["EmailID"] = value; } get { return HttpContext.Current.Session["EmailID"] as string; } }
        public string MobileNumber { set { HttpContext.Current.Session["MobileNumber"] = value; } get { return HttpContext.Current.Session["MobileNumber"] as string; } }
        public string AlternateNumber { set { HttpContext.Current.Session["AlternateNumber"] = value; } get { return HttpContext.Current.Session["AlternateNumber"] as string; } }
        public string DoB { set { HttpContext.Current.Session["DoB"] = value; } get { return HttpContext.Current.Session["DoB"] as string; } }
        public string LoanPurpose { set { HttpContext.Current.Session["LoanPurpose"] = value; } get { return HttpContext.Current.Session["LoanPurpose"] as string; } }
        public string AadharNum { set { HttpContext.Current.Session["AadharNum"] = value; } get { return HttpContext.Current.Session["AadharNum"] as string; } }
        public string Occupation { set { HttpContext.Current.Session["Occupation"] = value; } get { return HttpContext.Current.Session["Occupation"] as string; } }
        public string ContactAddress { set { HttpContext.Current.Session["ContactAddress"] = value; } get { return HttpContext.Current.Session["ContactAddress"] as string; } }
        public string ContDistrict { set { HttpContext.Current.Session["ContDistrict"] = value; } get { return HttpContext.Current.Session["ContDistrict"] as string; } }
        public string ContPincode { set { HttpContext.Current.Session["ContPincode"] = value; } get { return HttpContext.Current.Session["ContPincode"] as string; } }
        public string ParmanentAddress { set { HttpContext.Current.Session["ParmanentAddress"] = value; } get { return HttpContext.Current.Session["ParmanentAddress"] as string; } }
        public string ParDistrict { set { HttpContext.Current.Session["ParDistrict"] = value; } get { return HttpContext.Current.Session["ParDistrict"] as string; } }
        public string ParConstituency { set { HttpContext.Current.Session["ParConstituency"] = value; } get { return HttpContext.Current.Session["ParConstituency"] as string; } }
        public string ParPincode { set { HttpContext.Current.Session["ParPincode"] = value; } get { return HttpContext.Current.Session["ParPincode"] as string; } }
        public string AccHolderName { set { HttpContext.Current.Session["AccHolderName"] = value; } get { return HttpContext.Current.Session["AccHolderName"] as string; } }
        public string AccountNumber { set { HttpContext.Current.Session["AccountNumber"] = value; } get { return HttpContext.Current.Session["AccountNumber"] as string; } }
        public string BankName { set { HttpContext.Current.Session["BankName"] = value; } get { return HttpContext.Current.Session["BankName"] as string; } }
        public string Branch { set { HttpContext.Current.Session["Branch"] = value; } get { return HttpContext.Current.Session["Branch"] as string; } }
        public string IFSCCode { set { HttpContext.Current.Session["IFSCCode"] = value; } get { return HttpContext.Current.Session["IFSCCode"] as string; } }
        public string BankAddress { set { HttpContext.Current.Session["BankAddress"] = value; } get { return HttpContext.Current.Session["BankAddress"] as string; } }
        public string AppliedDate { set { HttpContext.Current.Session["AppliedDate"] = value; } get { return HttpContext.Current.Session["AppliedDate"] as string; } }
        public string ModifiedDate { set { HttpContext.Current.Session["ModifiedDate"] = value; } get { return HttpContext.Current.Session["ModifiedDate"] as string; } }
        public string ParTaluk { set { HttpContext.Current.Session["ParTaluk"] = value; } get { return HttpContext.Current.Session["ParTaluk"] as string; } }
        public string ContTaluk { set { HttpContext.Current.Session["ContTaluk"] = value; } get { return HttpContext.Current.Session["ContTaluk"] as string; } }
        public string FinancialYear { set { HttpContext.Current.Session["FinancialYear"] = value; } get { return HttpContext.Current.Session["FinancialYear"] as string; } }
        public string LoanDescription { set { HttpContext.Current.Session["LoanDescription"] = value; } get { return HttpContext.Current.Session["LoanDescription"] as string; } }
        public string ApplicantNameNC { set { HttpContext.Current.Session["ApplicantNameNC"] = value; } get { return HttpContext.Current.Session["ApplicantNameNC"] as string; } }
        public string ApprovedApplicationNum { set { HttpContext.Current.Session["ApprovedApplicationNum"] = value; } get { return HttpContext.Current.Session["ApprovedApplicationNum"] as string; } }

    }
}