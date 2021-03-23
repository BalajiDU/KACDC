using KACDC.Class.Declaration.Aadhaar;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace KACDC.Class.DataProcessing.Aadhaar
{
    public class AadhaarEnceyption
    {
        AadhaarServiceData ADSER = new AadhaarServiceData();
        public bool GetAadhaarToken(string AadhaarNumber)
        {
            try
            {
                var client = new RestClient("http://172.31.36.246:8080/tmrest/SafeNetTokenManager/insertToken");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                //request.AddParameter("application/json", "{\"naeUser\":\"tmtestuser\",\"naePassword\":\"P@ssw0rd\",\"dbUser\":\"DBTEST\",\"dbPassword\":\"rndo_1234\",\"value\":\"" + txtAadhaar.Text.Trim() + "\",\"tableName\":\"DBVAULT\",\"format\":\"103\"}", ParameterType.RequestBody);
                request.AddParameter("application/json", "{\"naeUser\":\"" + ConfigurationSettings.AppSettings["naeUser"].ToString() +
                    "\",\"naePassword\":\"" + ConfigurationSettings.AppSettings["naePassword"].ToString() +
                    "\",\"dbUser\":\"" + ConfigurationSettings.AppSettings["dbUser"].ToString() +
                    "\",\"dbPassword\":\"" + ConfigurationSettings.AppSettings["dbPassword"].ToString() +
                    "\",\"value\":\"" + AadhaarNumber +
                    "\",\"tableName\":\"" + ConfigurationSettings.AppSettings["tableName"].ToString() +
                    "\",\"format\":\"" + ConfigurationSettings.AppSettings["format"].ToString() + "\"}", RestSharp.ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                //Response.Write("___response Data" + response.Content);
                string responseData = response.Content;

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    var jObject = JObject.Parse(response.Content);
                    //string token1 = jObject.GetValue("token").ToString();
                    ADSER.AadhaarVaultToken = jObject.GetValue("token").ToString();
                    
                    //Response.Write("___response token is:" + token1);
                }
                else
                {
                    //Response.Write("___response code:" + response.StatusCode.ToString());
                    //Response.Write("___response code:" + response.ErrorMessage);
                }
                return true;
            }
            catch (Exception ex)
            {
                //DisplayAlert(ex.Message, this);
                return false;
            }
        }
    }
}