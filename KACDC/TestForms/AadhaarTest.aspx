<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AadhaarTest.aspx.cs" Inherits="KACDC.TestForms.AadhaarTest" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="form-row">
                            <div class="form-row-label">
                                <asp:Label ID="Label26" class="" runat="server">Aadhaar Number<span style="color:red"> *</span><br />ಆಧಾರ್ ಸಂಖ್ಯೆ</asp:Label><br />
                                <%--<asp:Label runat="server" Style="font-size: 8px; color: red;">(As Per Aadhar)</asp:Label>--%>
                            </div>
                            <%-- TODO onpaste="return false" AutoCompleteType="Disabled" --%>
                            <div class="form-row-input">
                                <asp:TextBox ID="txtAadhaarNumber" CssClass="NeoTextBox" runat="server" placeholder="Aadhaar Number" TextMode="Number" MaxLength="12" ></asp:TextBox>
                                <div id="divAadhaarChkError" class="DisplayError"  style="font-size:18px; font-weight: bold;color:#7b0000"></div>
                            </div>
                            <div class="form-row-Botton" id="divMovileNumberStatus" runat="server">
                                <asp:Button ID="btnAadhaarGetOTP" runat="server" CssClass="NeoButton"  OnClick="btnAadhaarGetOTP_Click" Text="Get OTP" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
                            </div>
                        </div>
                        <%--OTP Verify--%>
                        <div id="divMobileOTP" runat="server" class="form-row">
                            <div class="form-row-label">
                                <asp:Label ID="Label1" class="" runat="server">OTP<br />ಒಟಿಪಿ</asp:Label>
                            </div>
                            <div class="form-row-input">
                                <asp:TextBox ID="txtOTP" CssClass="NeoTextBox" runat="server" MaxLength="8"  placeholder="otp" ></asp:TextBox>
                                <div id="divOTPChkError" class="DisplayError" style="font-size:18px; font-weight: bold;color:#7b0000"></div>
                            </div>
                            <div class="form-row-Botton">
                                <asp:Button ID="btnVerifyAadhaarOTP" runat="server" CssClass="NeoButton" OnClick="btnVerifyAadhaarOTP_Click" Text="Verify" onpaste="return false" AutoCompleteType="Disabled" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
                            </div>
                        </div>
          <%--Aadhaar Details--%>
                <asp:Panel ID="PnlAadhaarDetails" runat="server" CssClass="modalPopup PopupPanel" Style="display: none; width:50%;height:80%; padding: 5px">
                   <div class="flex-container">
                        <div class="">
                            <div class="form-row" style="justify-content:center">
                                <div class="Popup-row-label-Heading">
                                    <asp:Label ID="Label43" class="" Style="font-size: 20px; margin-top: 20px" runat="server" Text="Aadhaar Details"></asp:Label>
                                </div>
                            </div>
                           <div class="form-row">
                               <%-- <div class="Popup-row-label">
                                    <asp:Label ID="Label51" runat="server">Photo<br />ಭಾವಚಿತ್ರ</asp:Label>
                                </div>--%>
                                 <div class="Popup-row-label">
                                    <asp:Image ID="ImgAadhaarPopupPhoto" runat="server" Height="160px" Width="140px" />
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="Popup-row-label">
                                    <asp:Label ID="Label44" runat="server">Name<br />ಹೆಸರು</asp:Label>
                                </div>
                                 <div class="Popup-row-label">
                                    <asp:Label ID="lblAadhaarPopupName"  runat="server"></asp:Label>
                                </div>
                            </div>
                             <div class="form-row">
                                <div class="Popup-row-label">
                                    <asp:Label ID="Label46" runat="server">DOB<br />ಜನ್ಮ ದಿನಾಂಕ</asp:Label>
                                </div>
                                 <div class="Popup-row-label">
                                    <asp:Label ID="lblAadhaarPopupDOB"  runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="Popup-row-label">
                                    <asp:Label ID="Label47" runat="server">Gender<br />ಲಿಂಗ</asp:Label>
                                </div>
                                 <div class="Popup-row-label">
                                    <asp:Label ID="lblAadhaarPopupGender"  runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="Popup-row-label">
                                    <asp:Label ID="Label49" runat="server">District<br />ಜಿಲ್ಲೆ</asp:Label>
                                </div>
                                 <div class="Popup-row-label">
                                    <asp:Label ID="lblAadhaarPopupDistrict"  runat="server"></asp:Label>
                                </div>
                            </div>
                             <div class="form-row">
                                <div class="Popup-row-label">
                                    <asp:Label ID="Label50" runat="server">Pincode<br />ಅಂಚೆ ಸಂಖ್ಯೆ</asp:Label>
                                </div>
                                 <div class="Popup-row-label">
                                    <asp:Label ID="lblAadhaarPopupPincode"  runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="Popup-row-label">
                                    <asp:Label ID="Label48" runat="server">State<br />ರಾಜ್ಯ</asp:Label>
                                </div>
                                 <div class="Popup-row-label">
                                    <asp:Label ID="lblAadhaarPopupState" Width="40px" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-row-Botton">
                                    <asp:Button ID="btnAadhaarkDetailsBack" runat="server" CssClass="NeoButton" Text="Back"  />
                                    <asp:Button ID="btnAadhaarkDetailsProceed" runat="server" CssClass="NeoButton" Text="Proceed"  />
                                </div>
                            </div>

                        </div>
                    </div>
                </asp:Panel>
 <asp:LinkButton ID="lnkAadhaarDetails" runat="server"></asp:LinkButton>
                <cc1:ModalPopupExtender ID="AadhaarPopup" runat="server" TargetControlID="lnkAadhaarDetails" PopupControlID="PnlAadhaarDetails"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>

        <br /><hr />
        <asp:Label runat="server" ID="lblAllError"></asp:Label>
    </form>
</body>
</html>
