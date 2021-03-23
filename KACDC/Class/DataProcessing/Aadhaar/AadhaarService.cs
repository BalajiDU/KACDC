using KACDC.Class.Declaration.Aadhaar;
using krdh.connector;
using krdh.parameters;
using KRDHConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Web;
using System.Web.UI;
using KACDC.Class.Declaration.Aadhaar;
using System.Configuration;
using KACDC.Class.Log;

namespace KACDC.Class.DataProcessing.Aadhaar
{
    public class AadhaarService
    {
        AadhaarServiceData ADSER = new AadhaarServiceData();
        Aadhaarlog ADLOG = new Aadhaarlog(); //Transaction History
        DataLogging DL = new DataLogging();
        AadhaarEnceyption AADENC = new AadhaarEnceyption();
        StoreAadhaarData ADStore = new StoreAadhaarData();
        public bool SendOTP(string AadhaarNumber)
        {
            RequestObject request = new RequestObject();

            request.setAadhaarNumber(ADSER.AadhaarNumber);
            request.setTransaction(Util.generateTransactionId(TypeOfRequest.Others));
            request.setOtpRequestType(OTPRequestType.AADHAAR);
            request.setTimeStamp(Util.getTimeStamp());

            krdh.connector.KRDHConnectorImpl krdhConnector = new KRDHConnectorImpl();
            ResponseObject response = krdhConnector.RequestOTP(request);

            if (response.getStatus().Equals("N"))
            {
                //Response.Write("Failed to generate the request.");
                //Response.Write(response.getError());
                //Response.Write(response.getErrorMessage());
                //Response.Write(response.getUIDToken());
                ADSER.SendOTPErrorMessage = response.getErrorMessage();
                ADSER.SendOTPErrorCode = response.getError();
                //DisplayAlert(response.getErrorMessage(),this);
                ADLOG.AadhaarHistoryLog("OTP", response.getStatus(), response.getTransaction(), response.getTimeStamp().ToString());
                return false;
            }
            else
            {

                if (response.getResponseStatus().ToLower().Equals("y"))
                {
                    //Response.Write(response.getTimeStamp());
                    ADSER.AadhaarOTPResponseTransactionID = response.getTransaction();

                    //Response.Write("SUCCESS");
                    //Response.Write("OTP Sent: " + response.getTransaction() + "\n");

                    //Response.Write("Var OTP Sent: " + ADSER.AadhaarOTPResponseTransactionID + "\n");
                    ADLOG.AadhaarHistoryLog("OTP", response.getStatus(), response.getTransaction(), response.getTimeStamp().ToString());

                    return true;
                }
                else
                {
                    //Response.Write(response.getError());
                    //Response.Write(response.getErrorMessage());
                    //DisplayAlert(response.getErrorMessage(), this);
                    ADSER.SendOTPErrorMessage = response.getErrorMessage();
                    ADSER.SendOTPErrorCode = response.getError();
                    ADLOG.AadhaarHistoryLog("OTP", response.getStatus(), response.getTransaction(), response.getTimeStamp().ToString());

                    return false;

                }
            }
        }

        public bool VerifyAadhaarOTP(string ipaddress,string PageName,string path)
        {
            KYCRequest kYCRequest = new KYCRequest();
            kYCRequest.setAuthenticationType(ResidentAuthenticationType.OTP);
            kYCRequest.setDecryptionRequired(false);
            kYCRequest.setLocalLanguageRequired(false);
            kYCRequest.setPrintFormatRequired(false);

            RequestObject request = new RequestObject();

            request.setAadhaarNumber(ADSER.AadhaarNumber);
            request.setVersion("2.5");
            request.setUdc(ConfigurationSettings.AppSettings["UDCCode"].ToString());
            //request.setUdc("ASBD20171013100000");
            request.setTimeStamp(Util.getTimeStamp());
            request.setResidentConsent(true);

            request.setKycRequest(kYCRequest);

            PinValue pv = new PinValue();

            pv.setOtp(ADSER.AadhaarApplicantOTP);

            request.setTransaction(ADSER.AadhaarOTPResponseTransactionID);
            //Response.Write("Verifying OTP(var): " + ADSER.AadhaarOTPResponseTransactionID + "\n");
            //request.setTransaction(UUID.randomUUID().toString());
            request.setPinValue(pv);


            KRDHConnectorImpl krdhConnector = new KRDHConnectorImpl();

            ResponseObject response = krdhConnector.requestKYC(request);
            //Response.Write("Got Response\n");
            ADLOG.AadhaarHistoryLog("KYC", response.getStatus(), response.getTransaction(), response.getTimeStamp().ToString());

            //Response.Write(response.getInfo());
            if (response.getStatus().Equals("N"))
            {
                //Response.Write("Failed to generate the request.\n");
                //Response.Write(response.getError() + "\n");
                //Response.Write(response.getErrorMessage() + "\n");
                //Response.Write("Var : " + ADSER.AadhaarOTPResponseTransactionID + "\n");
                ADSER.OTPErrorCode = response.getError();
                ADSER.OTPErrorMessage = response.getErrorMessage();
                DL.WriteErrorLog(ADSER.OTPErrorCode, ADSER.OTPErrorMessage, ipaddress, PageName, path);
                return false;
            }
            else
            {
                if (response.getResponseStatus().ToLower().Equals("y"))
                {
                    //Response.Write(response.getTimeStamp() + "\n");
                    //Response.Write(response.getTransaction() + "\n");
                    //Response.Write("SUCCESS" + "\n");

                    //lblToken.Text = ADSER.AadhaarVaultToken;
                    if (AADENC.GetAadhaarToken(ADSER.AadhaarNumber))
                    {
                        ADSER.DOB = response.GetKycRes().UidData.Poi.dob;
                        ADSER.Gender = response.GetKycRes().UidData.Poi.gender;
                        ADSER.Name = response.GetKycRes().UidData.Poi.name;

                        ADSER.State = response.GetKycRes().UidData.Poa.state;

                        ADSER.Photo = response.GetKycRes().UidData.Pht;
                        ADSER.Pincode = response.GetKycRes().UidData.Poa.pc;

                        ADSER.District = response.GetKycRes().UidData.Poa.dist;


                        ADStore.StoreAadhaar(
                            response.getTransaction(),
                            ADSER.AadhaarNumber,ADSER.AadhaarVaultToken, response.GetKycRes().UidData.uid, ADSER.Name, ADSER.DOB, ADSER.Gender,
                            response.GetKycRes().UidData.Poa.co,
                            response.GetKycRes().UidData.Poa.house,
                            response.GetKycRes().UidData.Poa.street,
                            response.GetKycRes().UidData.Poa.lm,
                            response.GetKycRes().UidData.Poa.loc,
                            response.GetKycRes().UidData.Poa.vtc,
                            response.GetKycRes().UidData.Poa.subdist,
                            response.GetKycRes().UidData.Poa.dist,
                            response.GetKycRes().UidData.Poa.state,
                            response.GetKycRes().UidData.Poa.pc,
                            response.GetKycRes().UidData.Poa.po,

                            response.GetKycRes().UidData.LData.name,
                            response.GetKycRes().UidData.LData.co,
                            response.GetKycRes().UidData.LData.house,
                            response.GetKycRes().UidData.LData.street,
                            response.GetKycRes().UidData.LData.lm,
                            response.GetKycRes().UidData.LData.loc,
                            response.GetKycRes().UidData.LData.vtc,
                            response.GetKycRes().UidData.LData.subdist,
                            response.GetKycRes().UidData.LData.dist,
                            response.GetKycRes().UidData.LData.state,
                            response.GetKycRes().UidData.LData.pc,
                            response.GetKycRes().UidData.LData.po);
                        //Response.Write("___" + ADSER.Name + "___" + ADSER.DOB + "_" + ADSER.Gender + "_" + ADSER.District + "_" + ADSER.State);
                        //string fileName = Path.Combine(Server.MapPath("C:\inetpub\wwwroot\AadhaarApplicantPhoto"));

                        return true;
                    }
                    else
                    {

                        return false;
                    }
                }
                else
                {
                    //Response.Write(response.getError() + "\n");
                    //Response.Write(response.getErrorMessage() + "\n");
                    ADSER.OTPErrorCode = response.getError();
                    ADSER.OTPErrorMessage = response.getErrorMessage();
                    DL.WriteErrorLog(ADSER.OTPErrorCode, ADSER.OTPErrorMessage, ipaddress, PageName, path);

                    return false;
                }
            }

        }
    }
}