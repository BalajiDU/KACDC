using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KACDC.Class.DataProcessing.Nadakacheri
{
    public class StoreNadakacheriData
    {
        public void StoreCasteIncomeCert(string NCGSCNumber, string NCStatusCode, string NCStatusMsg, string NCFacilityCode, string NCFacilityName, string NCLanguage, string NCAnnualIncome, string NCDateOfIssue, string NCApplicantName,
                        string NCTalukName, string NCDistrictName,string NCApplicantCAddressPin, string NCApplicantCAddress1, string NCApplicantCAddress2, string NCApplicantCAddress3, string App_Title, string NCGender, string NCVerification,
                        string TLIFileNo, string HobliName, string VillageName, string HabitationName, string ApplicantBincom, string Fat_Title, string ApplicantMotherName, string ReservationCategory, string AnnualIncomeInWords, string Purpose,
                        string ValidPeriod, string SpecialTaluk, string DocumentsSubmitted, string DisplayDocumentsSubmitted)
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spCreateNadakacheriLog", kvdConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NCGSCNumber", NCGSCNumber);
                    cmd.Parameters.AddWithValue("@NCStatusCode", NCStatusCode);
                    cmd.Parameters.AddWithValue("@NCStatusMsg", NCStatusMsg);
                    cmd.Parameters.AddWithValue("@NCFacilityCode", NCFacilityCode);
                    cmd.Parameters.AddWithValue("@NCFacilityName", NCFacilityName);
                    cmd.Parameters.AddWithValue("@NCLanguage", NCLanguage);
                    cmd.Parameters.AddWithValue("@NCAnnualIncome", NCAnnualIncome);
                    cmd.Parameters.AddWithValue("@NCDateOfIssue", NCDateOfIssue);
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
                    cmd.Parameters.AddWithValue("@ReservationCategory", ReservationCategory);
                    cmd.Parameters.AddWithValue("@AnnualIncomeInWords", AnnualIncomeInWords);
                    cmd.Parameters.AddWithValue("@Purpose", Purpose);
                    cmd.Parameters.AddWithValue("@ValidPeriod", ValidPeriod);
                    cmd.Parameters.AddWithValue("@SpecialTaluk", SpecialTaluk);
                    cmd.Parameters.AddWithValue("@DocumentsSubmitted", DocumentsSubmitted);
                    cmd.Parameters.AddWithValue("@DisplayDocumentsSubmitted", DisplayDocumentsSubmitted);


                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }
        }
    }
}