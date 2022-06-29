using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KACDC.Class.DataProcessing.Nadakacheri
{
    public class StoreNadakacheriPWDData
    {
        public void StorePWDCert(string NCGSCNumber, string RIReportNo, string RIReportDate, string AppDisability, string DisabilityPercentage, string ApplicantEName, string EffectiveDate, string NCApplicantName,
                        string NCTalukName, string NCDistrictName, string NCApplicantCAddressPin, string NCApplicantCAddress1, string NCApplicantCAddress2, string NCApplicantCAddress3, string App_Title, string NCGender, string NCVerification,
                        string TLIFileNo, string HobliName, string VillageName, string HabitationName, string ApplicantBincom, string Fat_Title, string ApplicantMotherName,
                        string SpecialTaluk)
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spCreateNadakacheriPWDLog", kvdConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NCGSCNumber", NCGSCNumber);
                    cmd.Parameters.AddWithValue("@RIReportNo", RIReportNo);
                    cmd.Parameters.AddWithValue("@RIReportDate", RIReportDate);
                    cmd.Parameters.AddWithValue("@AppDisability", AppDisability);
                    cmd.Parameters.AddWithValue("@DisabilityPercentage", DisabilityPercentage);
                    cmd.Parameters.AddWithValue("@ApplicantEName", ApplicantEName);
                    cmd.Parameters.AddWithValue("@EffectiveDate", EffectiveDate);
                
                    //cmd.Parameters.AddWithValue("@NCDateOfIssue", NCDateOfIssue);
                    cmd.Parameters.AddWithValue("@NCApplicantName", NCApplicantName);
                    cmd.Parameters.AddWithValue("@NCTalukName", NCTalukName);
                    cmd.Parameters.AddWithValue("@NCDistrictName", NCDistrictName);
                    cmd.Parameters.AddWithValue("@NCApplicantCAddressPin", NCApplicantCAddressPin);
                    cmd.Parameters.AddWithValue("@NCApplicantCAddress1", NCApplicantCAddress1);
                    cmd.Parameters.AddWithValue("@NCApplicantCAddress2", NCApplicantCAddress2);
                    cmd.Parameters.AddWithValue("@NCApplicantCAddress3", NCApplicantCAddress3);
                    cmd.Parameters.AddWithValue("@App_Title", App_Title);
                    cmd.Parameters.AddWithValue("@NCGender", NCGender);
                    cmd.Parameters.AddWithValue("@NCVerification", NCVerification);
                    cmd.Parameters.AddWithValue("@TLIFileNo", TLIFileNo);
                    cmd.Parameters.AddWithValue("@HobliName", HobliName);
                    cmd.Parameters.AddWithValue("@VillageName", VillageName);
                    cmd.Parameters.AddWithValue("@HabitationName", HabitationName);
                    cmd.Parameters.AddWithValue("@ApplicantBincom", ApplicantBincom);
                    cmd.Parameters.AddWithValue("@Fat_Title", Fat_Title);
                    cmd.Parameters.AddWithValue("@ApplicantMotherName", ApplicantMotherName);
                    //cmd.Parameters.AddWithValue("@ReservationCategory", ReservationCategory);
                    //cmd.Parameters.AddWithValue("@AnnualIncomeInWords", AnnualIncomeInWords);
                    //cmd.Parameters.AddWithValue("@Purpose", Purpose);
                    //cmd.Parameters.AddWithValue("@ValidPeriod", ValidPeriod);
                    cmd.Parameters.AddWithValue("@SpecialTaluk", SpecialTaluk);
                    //cmd.Parameters.AddWithValue("@DocumentsSubmitted", DocumentsSubmitted);
                    //cmd.Parameters.AddWithValue("@DisplayDocumentsSubmitted", DisplayDocumentsSubmitted);


                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }
        }

    }
}