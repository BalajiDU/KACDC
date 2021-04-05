using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace KACDC.Class.CreateLog
{
    public class ApplicationLog
    {
        public void OnlineApplicationLog(string ipaddress, string PageName,string Type,string value,string status,string DateTime)
        {
            
            
            try
            {
                using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spCreateAadhaarLog", kvdConn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@ApplicationNumber", ApplicationNumber);

                        cmd.Parameters.AddWithValue("@ipaddress", ipaddress);
                        cmd.Parameters.AddWithValue("@PageName", PageName);
                        cmd.Parameters.AddWithValue("@Type", Type);
                        cmd.Parameters.AddWithValue("@value", value);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@DateTime", DateTime);
                        

                        kvdConn.Open();
                        cmd.ExecuteNonQuery();
                        
                    }
                }
            }
            catch (SqlException e)
            {
                
            }
            
        }
    }
    }
