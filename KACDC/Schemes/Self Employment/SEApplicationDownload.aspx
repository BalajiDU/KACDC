<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SEApplicationDownload.aspx.cs" Inherits="KACDC.Schemes.Self_Employment.SEApplicationDownload" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Application Download</title>
      <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
       <link href="../../CustomCSS/DownloadApplication.css" rel="stylesheet" />
    <script src="../../Scripts/bootstrap.js"></script>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />

    <script type="text/javascript">
        $(document).ready(function () {

            $('#txtOTP').keyup(function () {
                var OTP = $(this).val();

                if (OTP.length != 8) {
                    var divElement = $('#divOTPError');
                    divElement.text('OTP Must be 8 digit')
                    divElement.css('color', 'red');
                }
            });
        });

    </script>
      <!--MobileNumber Verify -->
    <script type="text/javascript">
        function CheckOTP(evt) {

            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (((charCode >= 48 && charCode <= 57) || (e.keyCode >= 96 && e.keyCode <= 105)) || charCode == 46)) {
                $('#txtOTP').keyup(function () {
                    var NewAadhar = $(this).val();
                    if (NewAadhar.length != 0) {
                        if (NewAadhar.length == 8) {
                            var divElement = $('#divMobileChkError');
                            divElement.text(' ')
                            divElement.css('color', '#7b0000');
                        }
                        else if (NewAadhar.length < 8) {
                        }
                        else {
                            var divElement = $('#divMobileChkError');
                            divElement.text('Enter 10 Digit Mobile Number')
                            divElement.css('color', '#7b0000');
                        }
                    }
                    else {
                        var divElement = $('#divMobileChkError');
                        divElement.text('Mobile Number Must be Enter')
                        divElement.css('color', '#7b0000');
                    }
                });

            }
            else {
                alert('Please Enter Numeric values.');
                return false;
            }

        }
        function Count(text) {
            //asp.net textarea maxlength doesnt work; do it by hand
            var maxlength = 8; //set your value here (or add a parm and pass it in)
            var object = document.getElementById(text.id)  //get your object
            if (object.value.length > maxlength) {
                object.focus(); //set focus to prevent jumping
                object.value = text.value.substring(0, maxlength); //truncate the value
                object.scrollTop = object.scrollHeight; //scroll to the end to prevent jumping
                object.blur();
                document.getElementById("btnVerifyOTP").focus();
                return false;
            }
            return true;
        }
    </script>

 <%--  <script type="text/javascript">
        function PrintGridData() {
        var prtGrid = document.getElementById('<%=tblPreview.ClientID%>');
        prtGrid.border = 0;
        var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
        prtwin.document.write(prtGrid.outerHTML);
        prtwin.document.close();
        prtwin.focus();
        prtwin.print();
        prtwin.close();
        }
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       <%-- <asp:UpdatePanel runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btnApplicationDownload" />
            </Triggers>
            <ContentTemplate>--%>
                <div>
                    <div class="flex-container ContantMain" id="divSEApplicationMain" runat="server">
                        <div class="NeumorphicDiv">
                            <div class="form-row">
                            <div class="form-row-label-Heading" style=" border-radius: 15px;">
                                <asp:Label ID="Label5" class="" runat="server" Text="application download"></asp:Label>
                            </div>
                        </div>
                            <div id="divLoanSelection" class="form-row" runat="server" visible="true">
                                <div class="form-row-label">
                                    <asp:Label runat="server">Select Loan Type: <span style="color:red"> *</span></asp:Label>
                                </div>
                                <div class="form-row-input" runat="server">
                                    <asp:RadioButton ID="rbArivu" Class="radioButton" runat="server" GroupName="ContactAddress" Text="Arivu Education Loan" AutoPostBack="true" OnCheckedChanged="LoanType_CheckChanged" />
                                    <asp:RadioButton ID="rbSelfEmployment" Class="radioButton" runat="server" GroupName="ContactAddress" Text="Self Emplyment Loan" AutoPostBack="true" OnCheckedChanged="LoanType_CheckChanged" />
                                    <asp:Label ID="Label2" runat="server" class="labelStyle1"></asp:Label>
                                </div>
                                <div class="form-row-Botton">
                                </div>
                            </div>
                            <div id="divGetOTP" class="form-row" runat="server" visible="false">
                                <div class="form-row-label">
                                    <asp:Label runat="server">Application Number<span style="color:red"> *</span></asp:Label>
                                </div>
                                <div class="form-row-input" runat="server">
                                    <asp:TextBox runat="server" ID="txtApplicationNumber" MaxLength='17' class="ApplicationNumber" ReadOnly="false"  onpaste="return false" AutoCompleteType="Disabled"></asp:TextBox>
                                    <asp:Label ID="lblApplicationNumberError" runat="server" class="labelStyle1"></asp:Label>
                                </div>

                                <div class="form-row-Botton">
                                    <asp:Button ID="btnGetOTP" runat="server" CssClass="Button" Text="Get Application" OnClick="btnGetOTP_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" onpaste="return false" AutoCompleteType="Disabled" />
                                </div>
                            </div>
                            <div id="divVerifyOTP" class="form-row" runat="server" visible="false">
                                <div class="form-row-label">
                                    <asp:Label runat="server" class="">Enter OTP<span style="color:red"> *</span></asp:Label>
                                </div>
                                <div class="form-row-input" style="justify-content: center">
                                    <asp:TextBox ID="txtOTP" class="OTPTextBox" MaxLength='8' placeholder="00000000" TextMode="NUMBER" runat="server" onChange="javascript:Count(this);" onkeyup="javascript:Count(this);" onkeypress="javascript:Count(this);"></asp:TextBox><br />
                                    <asp:Label ID="lblOTPError" runat="server" class="labelStyle1"></asp:Label>
                                    <asp:Label ID="Label1" runat="server" Visible="false" class="labelStyle1" Style="color: lightgoldenrodyellow"><br />Passcode Format:<br />Mobile Number: 98765<u><b>43210</b></u><br />DOB: 24/11/<u><b>1994</b></u><br />Loan Number:KACDC/AR/20/CR-01(<u><b>000005</b></u>)2019-20/03-07-2020<br /><h3 style="font-weight:600">Then Passcode will be:432101994000005</h3></asp:Label>
                                </div>
                                <div class="form-row-Botton">
                                    <asp:Button ID="btnVerifyOTP" runat="server" CssClass="Button" Text="Verify OTP" OnClick="btnVerifyOTP_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" /><br />
                                    <asp:Button ID="btnResendOTP" runat="server" CssClass="Button" Text="Resend OTP" OnClick="btnResendOTP_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
                                </div>
                            </div>
                            <div id="divDownloadApplication" runat="server" visible="false">
                                <div id="div1" class="form-row" runat="server">
                                    <div class="form-row-label">
                                        <asp:Label runat="server">Applicat Name</asp:Label>
                                    </div>
                                    <div class="form-row-label" runat="server">
                                        <asp:Label ID="lblApplicantName" runat="server"></asp:Label>
                                    </div>
                                    <br />
                                    <div id="div2" class="form-row" runat="server">
                                        <div class="form-row-label">
                                            <asp:Button ID="btnApplicationDownload" runat="server" CssClass="Button" Text="Download Application" OnClick="btnApplicationDownload_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" /><br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <asp:Panel ID="PnlOtherDetails" runat="server" CssClass="modalPopup" Style="display: none; padding: 5px">
                        <div class="form-row" style="justify-content: center">
                            <div class="Popup-row-label-Heading">
                                <asp:Label ID="lblNotificationHeading"  runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="Popup-row-label">
                                <asp:Label ID="lblNotificationContent" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-row">

                            <div class="Popup-row-label">
                                <asp:Button ID="Button1" runat="server" CssClass="SubmitButton" Text="Ok" />
                            </div>
                        </div>

                    </asp:Panel>

                    <asp:LinkButton ID="lnkOtherDetails" runat="server"></asp:LinkButton>
                    <cc1:ModalPopupExtender ID="OtherDetailsPopup" runat="server" TargetControlID="lnkOtherDetails" PopupControlID="PnlOtherDetails"
                        BackgroundCssClass="modalBackground">
                    </cc1:ModalPopupExtender>
                </div>
           <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
    </form>
</body>
</html>
