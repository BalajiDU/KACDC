using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KACDC.Class.DataProcessing.OnlineApplication
{
    public class StoreSEApplication
    {
        public string StoreSE(string ApplicantName, string FatherName, string Gender, string Widowed, string Divorced, string PhysicallyChallenged, string AnualIncome, string RDNumber, string EmailID, string MobileNumber, string AlternateNumber, string DoB, string LoanPurpose, string AadharNum, string Occupation,
            string ContactAddress, string ContDistrict, string ContPincode, string ParmanentAddress, string ParDistrict, string ParConstituency, string ParPincode, string AccHolderName, string AccountNumber, string BankName, string Branch, 
            string IFSCCode, string BankAddress, string AppliedDate, string ModifiedDate, string ParTaluk, string ContTaluk, string LoanDescription, string ApplicantNameNC)
        {
            try
            {
                using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spCreateAadhaarLog", kvdConn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);

                        SqlParameter ApplicationNumberOUT = new SqlParameter("@ApplicationNumber", SqlDbType.NVarChar);
                        ApplicationNumberOUT.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(ApplicationNumberOUT);

                        cmd.Parameters.AddWithValue("@ApplicantName", ApplicantName);
                        cmd.Parameters.AddWithValue("@FatherName", FatherName);
                        cmd.Parameters.AddWithValue("@Gender", Gender);
                        cmd.Parameters.AddWithValue("@Widowed", Widowed);
                        cmd.Parameters.AddWithValue("@Divorced", Divorced);
                        cmd.Parameters.AddWithValue("@PhysicallyChallenged", PhysicallyChallenged);
                        cmd.Parameters.AddWithValue("@AnualIncome", AnualIncome);
                        cmd.Parameters.AddWithValue("@RDNumber", RDNumber);
                        cmd.Parameters.AddWithValue("@EmailID", EmailID);
                        cmd.Parameters.AddWithValue("@MobileNumber", MobileNumber);
                        cmd.Parameters.AddWithValue("@AlternateNumber", AlternateNumber);
                        cmd.Parameters.AddWithValue("@DoB", Convert.ToDateTime(DoB));
                        cmd.Parameters.AddWithValue("@LoanPurpose", LoanPurpose);
                        cmd.Parameters.AddWithValue("@AadharNum", AadharNum);
                        cmd.Parameters.AddWithValue("@Occupation", Occupation);
                        cmd.Parameters.AddWithValue("@ContactAddress", ContactAddress);
                        cmd.Parameters.AddWithValue("@ContDistrict", ContDistrict);
                        cmd.Parameters.AddWithValue("@ContPincode", ContPincode);
                        cmd.Parameters.AddWithValue("@ParmanentAddress", ParmanentAddress);
                        cmd.Parameters.AddWithValue("@ParDistrict", ParDistrict);
                        cmd.Parameters.AddWithValue("@ParConstituency", ParConstituency);
                        cmd.Parameters.AddWithValue("@ParPincode", ParPincode);
                        cmd.Parameters.AddWithValue("@AccHolderName", AccHolderName);
                        cmd.Parameters.AddWithValue("@AccountNumber", AccountNumber);
                        cmd.Parameters.AddWithValue("@BankName", BankName);
                        cmd.Parameters.AddWithValue("@Branch", Branch);
                        cmd.Parameters.AddWithValue("@IFSCCode", IFSCCode);
                        cmd.Parameters.AddWithValue("@BankAddress", BankAddress);
                        cmd.Parameters.AddWithValue("@AppliedDate", Convert.ToDateTime(AppliedDate));
                        cmd.Parameters.AddWithValue("@ModifiedDate", Convert.ToDateTime(ModifiedDate));
                        cmd.Parameters.AddWithValue("@ModifiedDate", ParTaluk);
                        cmd.Parameters.AddWithValue("@ModifiedDate", ContTaluk);
                        cmd.Parameters.AddWithValue("@ImgCandidate", DBNull.Value);
                        cmd.Parameters.AddWithValue("@ImgSignature", DBNull.Value);
                        cmd.Parameters.AddWithValue("@ImgAadharFront", DBNull.Value);
                        cmd.Parameters.AddWithValue("@ImgAadharBack", DBNull.Value);
                        cmd.Parameters.AddWithValue("@DocBankPassbook", DBNull.Value);
                        cmd.Parameters.AddWithValue("@DocCasteIncome", DBNull.Value);
                        cmd.Parameters.AddWithValue("@DocPhyCha", DBNull.Value);
                        cmd.Parameters.AddWithValue("@LoanDescription", LoanDescription);
                        cmd.Parameters.AddWithValue("@ApplicantNameNC", ApplicantNameNC);


                        kvdConn.Open();
                        cmd.ExecuteNonQuery();
                        string ReceivedApplicationNumber = (string)cmd.Parameters["@ApplicationNumber"].Value;
                        kvdConn.Close();
                        return ReceivedApplicationNumber;
                    }
                }
            }
            catch(SqlException e)
            {
                return e.Message;
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
    }
}