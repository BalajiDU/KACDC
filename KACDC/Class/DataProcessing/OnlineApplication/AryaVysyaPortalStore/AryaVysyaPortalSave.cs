using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KACDC.Class.DataProcessing.OnlineApplication.AryaVysyaPortalStore
{
    public class AryaVysyaPortalSave
    {
        public string StoreAV(string Name, string FatherName, string Gender, string Address,
            string District, string Taluk, string Pincode, string DoB, string MobileNumber, string WhatssAppNumber, string EmailID, string Occupation,
            string OccupationDetails, string Declaration)
        {
            try
            {
                using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spAryaVysyaPortalApplicaton", kvdConn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", Name);
                        cmd.Parameters.AddWithValue("@FatherName", FatherName);
                        cmd.Parameters.AddWithValue("@Gender", Gender);
                        cmd.Parameters.AddWithValue("@Address", Address);
                        cmd.Parameters.AddWithValue("@District", District);
                        cmd.Parameters.AddWithValue("@Taluk", Taluk);
                        cmd.Parameters.AddWithValue("@Pincode", Pincode);
                        cmd.Parameters.AddWithValue("@DoB", Convert.ToDateTime(DoB));
                        cmd.Parameters.AddWithValue("@MobileNumber", MobileNumber);
                        cmd.Parameters.AddWithValue("@WhatsAppNumber", WhatssAppNumber);
                        cmd.Parameters.AddWithValue("@EmailID ", EmailID);
                        cmd.Parameters.AddWithValue("@Occupation", Occupation);
                        cmd.Parameters.AddWithValue("@OccupationDetails", OccupationDetails);
                        cmd.Parameters.AddWithValue("@Declaration", Declaration);
                        cmd.Parameters.Add("@ApplicationNumber", SqlDbType.NVarChar, 20);
                        cmd.Parameters["@ApplicationNumber"].Direction = ParameterDirection.Output;
                        kvdConn.Open();
                        cmd.ExecuteScalar();
                        kvdConn.Close();
                        string num = cmd.Parameters["@ApplicationNumber"].Value.ToString();
                        return num;

                    }
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return err;
            }

        }

        public bool CheckMobileNumExist(string MobileNumber)
        {
            using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select CAST(COUNT(MobileNumber)AS int) from  AryaVysyaPortal where MobileNumber=@MobileNumber", kvdConn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@MobileNumber", MobileNumber);
                    kvdConn.Open();
                    int count = (Int32)cmd.ExecuteScalar();
                    kvdConn.Close();
                    if (count==0)
                        return true;
                    else
                        return false;
                }
            }
        }
    }
}