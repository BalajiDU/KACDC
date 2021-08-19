using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.Declaration.OnlineApplication
{
    public class AVPortal
    {
        public string EncryptedOTP
        {
            set { HttpContext.Current.Session["EncryptedOTP"] = value; }
            get { return HttpContext.Current.Session["EncryptedOTP"] as string; }
        }
        public string IsMobileVerified
        {
            set { HttpContext.Current.Session["IsMobileVerified"] = value; }
            get { return HttpContext.Current.Session["IsMobileVerified"] as string; }
        }
        public string EmailID
        {
            set { HttpContext.Current.Session["EmailID"] = value; }
            get { return HttpContext.Current.Session["EmailID"] as string; }
        }
        public string Name
        {
            set { HttpContext.Current.Session["Name"] = value; }
            get { return HttpContext.Current.Session["Name"] as string; }
        }
        public string Gender
        {
            set { HttpContext.Current.Session["Gender"] = value; }
            get { return HttpContext.Current.Session["Gender"] as string; }
        }
        public string FatherName
        {
            set { HttpContext.Current.Session["FatherName"] = value; }
            get { return HttpContext.Current.Session["FatherName"] as string; }
        }
        public string Address
        {
            set { HttpContext.Current.Session["Address"] = value; }
            get { return HttpContext.Current.Session["Address"] as string; }
        }
        public string Pincode
        {
            set { HttpContext.Current.Session["Pincode"] = value; }
            get { return HttpContext.Current.Session["Pincode"] as string; }
        }
        public string District
        {
            set { HttpContext.Current.Session["District"] = value; }
            get { return HttpContext.Current.Session["District"] as string; }
        }
        public string Taluk
        {
            set { HttpContext.Current.Session["Taluk"] = value; }
            get { return HttpContext.Current.Session["Taluk"] as string; }
        }
        public string DOB
        {
            set { HttpContext.Current.Session["DOB"] = value; }
            get { return HttpContext.Current.Session["DOB"] as string; }
        }
        public string MobileNumber
        {
            set { HttpContext.Current.Session["MobileNumber"] = value; }
            get { return HttpContext.Current.Session["MobileNumber"] as string; }
        }
        public string WhatsappNumber
        {
            set { HttpContext.Current.Session["WhatsappNumber"] = value; }
            get { return HttpContext.Current.Session["WhatsappNumber"] as string; }
        }
        public string Occupation
        {
            set { HttpContext.Current.Session["Occupation"] = value; }
            get { return HttpContext.Current.Session["Occupation"] as string; }
        }
        public string OccupationDetails
        {
            set { HttpContext.Current.Session["OccupationDetails"] = value; }
            get { return HttpContext.Current.Session["OccupationDetails"] as string; }
        }
        public string Declaration
        {
            set { HttpContext.Current.Session["Declaration"] = value; }
            get { return HttpContext.Current.Session["Declaration"] as string; }
        }
        public string EducationQualification
        {
            set { HttpContext.Current.Session["EducationQualification"] = value; }
            get { return HttpContext.Current.Session["EducationQualification"] as string; }
        }
        public string PhysicallyChallenged
        {
            set { HttpContext.Current.Session["PhysicallyChallenged"] = value; }
            get { return HttpContext.Current.Session["PhysicallyChallenged"] as string; }
        }

    }
}