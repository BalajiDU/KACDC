using KACDC.Class.Declaration.WebServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;

namespace KACDC.Controllers.Suvidha
{
    public class KACDCSuvidhaController : ApiController
    {
        [HttpGet]
        //[DataMember(EmitDefaultValue = false)]
        public IHttpActionResult KACDCSuvidhaVerify(string Scheme, string RDNumber = "", string Aadhaar= "")
        {
            WSSuvidha WSS = new WSSuvidha();
            KACDC.Models.WSSuvidha WS = new KACDC.Models.WSSuvidha();
            try
            {

                using (SqlConnection kvdConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnStr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spSuvidhaVerify", kvdConn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                       
                        cmd.Parameters.AddWithValue("@scheme", Scheme.ToUpper());
                       
                        if (RDNumber != "")
                            cmd.Parameters.AddWithValue("@RDNumber", RDNumber);
                        if (Aadhaar != "")
                            cmd.Parameters.AddWithValue("@Aadhaar", Aadhaar);

                        kvdConn.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        switch (Scheme.ToUpper())
                        {
                            case "ARR":
                                while (rdr.Read())
                                {
                                    //WSSuvidha AR = new WSSuvidha();
                                    WSS.ApplicationNumber = rdr["ApplicationNumber"].ToString().ToUpper();
                                    WSS.ApplicantName = rdr["ApplicantName"].ToString().ToUpper();
                                    WSS.RDNumber = rdr["RDNumber"].ToString().ToUpper();
                                    WSS.Aadhaar = rdr["Aadhaar"].ToString().ToUpper();
                                    WSS.FinancialYear = rdr["FinancialYear"].ToString().ToUpper();
                                    WSS.LoanAmount1 = rdr["LoanAmount1"].ToString().ToUpper();
                                    WSS.LoanAmount2 = rdr["LoanAmount2"].ToString().ToUpper();
                                    WSS.LoanAmount3 = rdr["LoanAmount3"].ToString().ToUpper();
                                    WSS.LoanAmount4 = rdr["LoanAmount4"].ToString().ToUpper();
                                    WSS.LoanAmount5 = rdr["LoanAmount5"].ToString().ToUpper();
                                    WSS.LoanAmount6 = rdr["LoanAmount6"].ToString().ToUpper();
                                    WSS.Status = rdr["Status"].ToString().ToUpper();
                                    //WSSuvidha.Add(AR);
                                }
                                break;
                            case "AR":
                                while (rdr.Read())
                                {
                                    WS.Status = rdr["Status"].ToString();
                                }
                                break;
                            case "SE":
                                while (rdr.Read())
                                {
                                    WS.Status = rdr["Status"].ToString();
                                }
                                break;
                        }
                    }
                    if(Scheme.ToUpper() == "ARR") return Ok(WSS); else return Ok(WS);
                }
            }
            catch
            {
                if (Scheme.ToUpper() == "ARR") return Ok(WSS); else return Ok(WS);
            }
        }

    }
}
