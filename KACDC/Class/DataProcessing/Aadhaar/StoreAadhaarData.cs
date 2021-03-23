using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KACDC.Class.DataProcessing.Aadhaar
{
    public class StoreAadhaarData
    {
        public void StoreAadhaar(string TransactionID,string AadhaarNumber,string AadhaarTocken,string UID, string Name,string DOB,string Gender,string CO, string House, string Street, string LandMark,string Loc, string Vtc, string SubDistrict, string District,
            string State, string PostalCode, string PostOffice, string LName, string LCO, string LHouse, string LStreet, string LLandMark,string LLoc, string LVtc, string LSubDistrict, string LDistrict, string LState, string LPostalCode, string LPostOffice)
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spCreateAadhaarLog", kvdConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransactionID", TransactionID);
                    cmd.Parameters.AddWithValue("@AadhaarNumber", AadhaarNumber);
                    cmd.Parameters.AddWithValue("@AadhaarTocken", AadhaarTocken);
                    cmd.Parameters.AddWithValue("@UID", UID);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@DOB", DOB);
                    cmd.Parameters.AddWithValue("@Gender", Gender);
                    cmd.Parameters.AddWithValue("@CO", CO);
                    cmd.Parameters.AddWithValue("@House", House);
                    cmd.Parameters.AddWithValue("@Street", Street);
                    cmd.Parameters.AddWithValue("@LandMark", LandMark);
                    cmd.Parameters.AddWithValue("@Loc", Loc);
                    cmd.Parameters.AddWithValue("@Vtc", Vtc);
                    cmd.Parameters.AddWithValue("@SubDistrict", SubDistrict);
                    cmd.Parameters.AddWithValue("@District", District);
                    cmd.Parameters.AddWithValue("@State", State);
                    cmd.Parameters.AddWithValue("@PostalCode", PostalCode);
                    cmd.Parameters.AddWithValue("@PostOffice", PostOffice);

                    cmd.Parameters.AddWithValue("@LName", LName);
                    cmd.Parameters.AddWithValue("@LCO", LCO);
                    cmd.Parameters.AddWithValue("@LHouse", LHouse);
                    cmd.Parameters.AddWithValue("@LStreet", LStreet);
                    cmd.Parameters.AddWithValue("@LLandMark", LLandMark);
                    cmd.Parameters.AddWithValue("@LLoc", LLoc);
                    cmd.Parameters.AddWithValue("@LVtc", LVtc);
                    cmd.Parameters.AddWithValue("@LSubDistrict", LSubDistrict);
                    cmd.Parameters.AddWithValue("@LDistrict", LDistrict);
                    cmd.Parameters.AddWithValue("@LState", LState);
                    cmd.Parameters.AddWithValue("@LPostalCode", LPostalCode);
                    cmd.Parameters.AddWithValue("@LPostOffice", LPostOffice);
                    kvdConn.Open();
                    cmd.ExecuteNonQuery();
                    kvdConn.Close();
                }
            }
        }
    }
}