<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Arivu_Renewal.aspx.cs" Inherits="KACDC.Schemes.Arivu.Arivu_Renewal" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Arivu Renewal</title>
    <%--
         <link href="../CustomCSS/ApprovalPageCss/ModalDesign.css" rel="stylesheet" />
        <link href="~/CustomCss/ApprovalPageCss/FormStyles.css" rel="stylesheet" type="text/css" />
    <link href="~/CustomCss/ApprovalPageCss/LogoNameAnimation.css" rel="stylesheet" />
    <link href="~/CustomCss/ApprovalPageCss/SideNavBar.css" rel="stylesheet" />
    <link href="~/CustomCss/ApprovalPageCss/ToggleButton.css" rel="stylesheet" />
    <link href="~/CustomCss/ApprovalPageCss/TopNavBar.css" rel="stylesheet" />--%>

    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <link href="~/CustomCss/ArivuRenewal.css" rel="stylesheet" />
    <script src="../../Scripts/bootstrap.js"></script>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />

   

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btnUploadPrevMarksCard" />
                <asp:PostBackTrigger ControlID="btnUploadStudyCertificate" />
                <asp:PostBackTrigger ControlID="btntest" />
                <asp:PostBackTrigger ControlID="btnDownloadAcknolegdement" />
                <asp:PostBackTrigger ControlID="btnDownloadFormat" />
                <%--<asp:PostBackTrigger ControlID="btnSubmitRenewalRequest" />--%>
            </Triggers>
            <ContentTemplate>
                <asp:Button runat="server" Text="test" Visible="false" ID="btntest" OnClick="btntest_click" />
                <div>
                    <asp:Button ID="btnconfirm" runat="server" Visible="false" CssClass="Button" Text="Get OTP" OnClick="btnconfirm_Click" />

                    <div class="flex-container ContantMain" id="divSEApplicationMail" runat="server">
                        <div class="NeumorphicDiv">
                            <div class="form-row">
                                <div class="form-row-label-Heading" style="border-radius: 15px;">
                                    <asp:Label ID="Label5" class="" runat="server" Text="Arivu Educational loan"></asp:Label>
                                    <asp:Label class="navFormHeading" runat="server">Renewal Process</asp:Label>
                                </div>
                            </div>


                            <div id="divGetOTP" class="form-row" runat="server">
                                <div class="form-row-label">
                                    <asp:Label runat="server">Application Number<span style="color:red"> *</span></asp:Label>
                                </div>
                                <div class="form-row-input">
                                    <asp:TextBox ID="txtApplicationNumber" CssClass="NeoTextBox" runat="server"></asp:TextBox><br />
                                    <asp:Label ID="lblApplicationNumberError" runat="server" class="labelStyle1"></asp:Label>
                                </div>
                                <div class="form-row-Botton">
                                    <asp:Button ID="btnGetOTP" runat="server" CssClass="Button" Text="Get Application" OnClick="btnGetOTP_Click"  UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
                                </div>
                            </div>
                            <div id="divVerifyOTP" class="form-row" runat="server" visible="false">
                                <div class="form-row-label">
                                    <asp:Label runat="server" class="">Enter Passcode<span style="color:red"> *</span></asp:Label>
                                </div>
                                <div class="form-row-input">
                                    <asp:TextBox ID="txtOTP" class="NeoTextBox" runat="server"></asp:TextBox><br />
                                    <asp:Label ID="lblOTPError" runat="server" class="labelStyle1"></asp:Label>
                                    <asp:Label ID="Label1" runat="server" class="labelStyle1" style="color:lightgoldenrodyellow"><br />Passcode Format:<br />Mobile Number: 98765<u><b>43210</b></u><br />DOB: 24/11/<u><b>1994</b></u><br />Loan Number:KACDC/AR/20/CR-01(<u><b>000005</b></u>)2019-20/03-07-2020<br /><h3 style="font-weight:600">Then Passcode will be:432101994000005</h3></asp:Label>
                                </div>
                                <div class="form-row-Botton">
                                    <asp:Button ID="btnVerifyOTP" runat="server" CssClass="Button" Text="Verify Passcode" OnClick="btnVerifyOTP_Click"  UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" /><br />
                                </div>
                            </div>

                            <div id="divUploadFiles" class="" runat="server"  visible="false">
                                <div class="form-row" runat="server">
                                    <div class="form-row-label">
                                        <asp:Label runat="server" Text="Application Number"></asp:Label>
                                    </div>
                                    <div class="form-row-label">
                                        <asp:Label runat="server" ID="lblApplicationNumber" ForeColor="Gold">Number</asp:Label>
                                    </div>
                                </div>
                                <div class="form-row" runat="server">
                                    <div class="form-row-label">
                                        <asp:Label runat="server" Text="Applicant Name"></asp:Label>
                                    </div>

                                    <div class="form-row-label">
                                        <asp:Label runat="server" ID="lblApplicantName" ForeColor="Gold">Name</asp:Label>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-row-label"  style="flex:2" >
                                        <asp:Label ID="Label34" runat="server">Are You Staying in College Hostel?<span style="color:#a30000"> *</span></asp:Label>
                                    </div>
                                    <div class="form-row-input">
                                         <asp:RadioButton ID="rbCollegeHostelYes" runat="server" Class="radioButton" GroupName="Widow" Text="Yes" AutoPostBack="true" OnCheckedChanged="rbCollegeHostel_CheckedChanged"  />
                                        <asp:RadioButton ID="rbCollegeHostelNo" runat="server" Class="radioButton" GroupName="Widow" Text="No" AutoPostBack="true" OnCheckedChanged="rbCollegeHostel_CheckedChanged" />

                                    </div>
                                </div>


                                <div class="form-row">
                                    <div class="form-row-label" style="flex: 2;">
                                        <asp:Label ID="Label68" runat="server">Previous Year Marks Card<span style="color:#a30000"> *</span></asp:Label>
                                    </div>
                                    <div class="form-row-input">
                                        <div class="input-group">
                                            <div class="custom-file">
                                                <asp:FileUpload ID="FilePrevMarksCard" class="custom-file-input" runat="server" />
                                                <asp:Label ID="lblFilePrevMarksCard" runat="server" class="custom-file-label"></asp:Label>
                                            </div>
                                            <div class="input-group-append">
                                                <asp:Button ID="btnUploadPrevMarksCard" runat="server" Visible="true" CssClass="btn btn-secondary" Text="Upload" OnClick="btnUploadPrevMarksCard_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
                                            </div>
                                        </div>
                                        <span style="font-size: 18px; font-weight: bold; color: #7b0000">Less then 500 KB</span>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-row-label" style="flex: 2;">
                                        <asp:Label ID="Label67" runat="server">Current Year Study Certificate<span style="color:#a30000"> *</span></asp:Label>
                                    </div>
                                    <div class="form-row-input">
                                        <div class="input-group">
                                            <div class="custom-file">
                                                <asp:FileUpload ID="FileStudyCertificate" class="custom-file-input" runat="server" />
                                                <asp:Label ID="lblFileStudyCertificate" runat="server" class="custom-file-label"></asp:Label>
                                            </div>
                                            <div class="input-group-append">
                                                <asp:Button ID="btnUploadStudyCertificate" runat="server" Visible="true" CssClass="btn btn-secondary" Text="Upload" OnClick="btnUploadStudyCertificate_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
                                            </div>
                                        </div>
                                        <span style="font-size: 18px; font-weight: bold; color: #7b0000">Less then 500 KB</span>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <asp:Button ID="btnSubmitRenewalRequest" runat="server" CssClass="SubmitButton" Text="Submit Application" OnClick="btnSubmitRenewalRequest_Click" UseSubmitBehavior="false"  /><%--OnClientClick="this.disabled='true'; this.value='Please wait...';"--%>
                                </div>
                            </div>


                            <div id="divDownloadAcknolegdement" class="" runat="server" visible="false">
                                <div class="form-row" runat="server">
                                    <asp:Button ID="btnDownloadAcknolegdement" runat="server" CssClass="Button" Text="Download Acknolegdement" OnClick="btnDownloadAcknolegdement_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
                                </div>
                            </div>

                            <asp:Panel ID="PnlOtherDetails" runat="server" CssClass="modalPopup" Style="display: none; padding: 5px">
                                <div class="form-row" style="justify-content: center">
                                    <div class="Popup-row-label-Heading">
                                        <asp:Label ID="Label19" class="" Style="margin-top: 20px;" runat="server" Text="OTP Expired"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="Popup-row-label">
                                        <asp:Label ID="Label20" runat="server">You want to try again</asp:Label>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="Popup-row-label">
                                        <asp:Button ID="btnTryAgain" runat="server" CssClass="SubmitButton" Text="Yes" OnClick="btnTryAgain_Click" />
                                    </div>
                                    <div class="Popup-row-label">
                                        <asp:Button ID="Button2" runat="server" CssClass="SubmitButton" Text="No" />
                                    </div>
                                </div>

                            </asp:Panel>

                            <asp:LinkButton ID="lnkOtherDetails" runat="server"></asp:LinkButton>
                            <cc1:ModalPopupExtender ID="OtherDetailsPopup" runat="server" TargetControlID="lnkOtherDetails" PopupControlID="PnlOtherDetails"
                                BackgroundCssClass="modalBackground">
                            </cc1:ModalPopupExtender>

                            <asp:Panel ID="PnlNotification" runat="server" CssClass="modalPopup" Style="display: none; padding: 5px;width:30%;min-height:35%;overflow:inherit;max-width:80%;">
                                        <div class="form-row" style="justify-content: center">
                                            <div class="Popup-row-label-Heading">
                                                <asp:Label ID="Label26" class="" Style="margin-top: 20px;font-weight:bold" runat="server" Text="Notification"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-row">
                                            <div class="Popup-row-label">
                                                
                                                <asp:Label ID="lblDisplayNotification"  runat="server" style="text-transform: none" >College hostel has to be certified in STUDY CRETIFICATE, if you are staying in college hostel.</asp:Label>
                                            </div>
                                        </div>
                                        <footer>
                                            <div class="form-row" style="margin-bottom:20px;position:absolute;right:    0;bottom:   0;">

                                                <div class="Popup-row-label"><br /><br />
                                                    <asp:Button ID="Button9" runat="server" CssClass="SubmitButton" Text="OK" />
                                                     <asp:Button ID="btnDownloadFormat" runat="server" CssClass="SubmitButton" Text="Download" OnClick="btnDownloadFormat_Click" />
                                                </div>
                                            </div>
                                        </footer>
                                    </asp:Panel>

                            <asp:LinkButton ID="lnkNotification" runat="server"></asp:LinkButton>
                            <cc1:ModalPopupExtender ID="NotificationPopup" runat="server" TargetControlID="lnkNotification" PopupControlID="PnlNotification"
                                BackgroundCssClass="modalBackground">
                            </cc1:ModalPopupExtender>
                        </div>
                    </div>
                </div>
            </ContentTemplate>

        </asp:UpdatePanel>
    </form>
</body>
</html>

