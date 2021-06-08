<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AryaVysyaPortal.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="KACDC.Schemes.AryaVysyaPortal.AryaVysyaPortal" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ARYA VYSYA PORTAL</title>
        <link rel="shortcut icon" type="image/x-icon" href="../../Image/KACDC_PDF.jpg" />
    <link href="../../CustomCSS/ApplicationPage/ApplicationPage.css" rel="stylesheet" />

<%--    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js" /> --%>


    <style>
       .NeuoDropdown {
        outline: none;
        border: none;
        background: #eeecec;
        border-radius: 10px;
        text-shadow: 1px 1px 0 #fff;
        display: flex;
        justify-content: center;
        /*margin-right: 4rem;*/
        padding: 7px;
        /*margin: 5px;*/
        text-align: center;
        align-items: center;
        letter-spacing: 1.5px;
        font-size: 20px;
        font-family: "poppins", sans-serief;
        color: black;
        width: 100%;
        font-family: 'Piazzolla', serif;
        font-size: 23px;
        letter-spacing: 1px;
        width: 25%;
        box-sizing: border-box;
        height: 30px;
        width: 98%;
        font-size: 18px;
        border: none;
        padding: 5px;
        margin: 10px;
        outline: none;
        flex-wrap: wrap;
        text-align: center;
        background: #eeecec;
        border-radius: 6px;
        text-shadow: 1px 1px 0 #fff;
        color: #303030;
        /*box-shadow: inset 5px 5px 10px #dddbdb, inset -5px -5px 10px #fffdfd;*/
        text-transform: uppercase;
    }
    </style>
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

    <script type="text/javascript">

function Numeric(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (((charCode >= 48 && charCode <= 57)|| (e.keyCode >= 96 && e.keyCode <= 105)) || charCode == 46)) {
                return true;
            else {
                alert('Please Enter Numeric values.');
                return false;
            }
        }

</script>

    <!--Allow Numerical Value-->
    <script type="text/javascript">
    function Numeric(evt) {
        var specialKeys = new Array();
        specialKeys.push(8); //Backspace
        var charCode = (evt.which) ? evt.which : event.keyCode;
        
        if (charCode > 31 && (((charCode >= 48 && charCode <= 57) || specialKeys.indexOf(charCode) != -1 || (charCode >= 96 && charCode <= 105)|| charCode == 8) || charCode == 46 || charCode == 8)) {
            return true;
        }
        else {
            if (charCode == 8||charCode == 9)
                return true;
                alert('Please Enter Numeric values.'+charCode);
                return false;
            }
    }
    
    </script>
    <script type="text/javascript">
        var specialKeys = new Array();
        specialKeys.push(8); //Backspace
        function IsNumeric(e) {
            var keyCode = e.which ? e.which : e.keyCode
            var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
            document.getElementById("divMobileChkError").style.display = ret ? "none" : "inline";
            return ret;
        }
    </script>
    <script type="text/javascript">
        function CheckMobileNumber(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (((charCode >= 48 && charCode <= 57)|| (e.keyCode >= 96 && e.keyCode <= 105)) || charCode == 46)) {
                $('#txtApplicantMobileNumber').keyup(function () {
                    var NewAadhar = $(this).val();
                    if (NewAadhar.length != 0) {
                        if (NewAadhar.length == 10) {
                            var divElement = $('#divMobileChkError');
                            divElement.text(' ')
                            divElement.css('color', '#7b0000');
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

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanelAVPortal" runat="server" UpdateMode="Conditional">
            <Triggers>
            </Triggers>
            <ContentTemplate>
                <div class="flex-container ContantMain" id="divSEApplicationMail" runat="server">
                    <div class="NeumorphicDiv">
                        <div class="form-row">
                            <div class="form-row-label-Heading" style="border-radius: 15px;">
                                <asp:Label ID="Label5" class="" runat="server" Text="arya vysya portal"></asp:Label>
                            </div>
                        </div>
                        <%--Mobile Number--%>
                        <div class="form-row">
                            <div class="form-row-label">
                                <asp:Label ID="Label26" class="" runat="server">Name<span style="color:red"> *</span><br />ಹೆಸರು</asp:Label><br />
                            </div>
                            <div class="form-row-input">
                                <asp:TextBox ID="txtName" CssClass="NeoTextBox" runat="server" placeholder="name" onpaste="return false" AutoCompleteType="Disabled"></asp:TextBox>
                                <asp:Label id="lblNameError" runat="server" class="DisplayError" style="font-size: 18px; font-weight: bold; color: #7b0000"></asp:Label>
                            </div>
                            <div class="form-row-Botton" id="divMovileNumberStatus" runat="server">
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-row-label">
                                <asp:Label ID="Label2" class="" runat="server">Father / Guardian Name<span style="color:red"> *</span><br />ತಂದೆ / ರಕ್ಷಕರ ಹೆಸರು</asp:Label><br />
                            </div>
                            <div class="form-row-input">
                                <asp:TextBox ID="txtFatherName" CssClass="NeoTextBox" runat="server" placeholder="Father / Guardian Name" onpaste="return false" AutoCompleteType="Disabled"></asp:TextBox>
                                <asp:Label id="lblFatherNameError" runat="server" class="DisplayError" style="font-size: 18px; font-weight: bold; color: #7b0000"></asp:Label>
                            </div>
                            <div class="form-row-Botton" id="div2" runat="server">
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-row-label">
                                <asp:Label ID="Label12" class="" runat="server">Gender<span style="color:red"> *</span><br />ಲಿಂಗ</asp:Label><br />
                            </div>
                            <div class="form-row-input"><%--OnCheckedChanged="LoanType_CheckChanged"--%>
                                <asp:RadioButton ID="rbMale" Class="radioButton" runat="server" GroupName="Gender" Text="MALE"  />
                                    <asp:RadioButton ID="rbFemale" Class="radioButton" runat="server" GroupName="Gender" Text="FEMALE"  />
                                <asp:Label id="lblGenderError" runat="server" class="DisplayError" style="font-size: 18px; font-weight: bold; color: #7b0000"></asp:Label>
                            </div>
                            <div class="form-row-Botton" id="div21" runat="server">
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-row-label">
                                <asp:Label ID="Label1" class="" runat="server">address<span style="color:red"> *</span><br />ವಿಳಾಸ</asp:Label><br />
                            </div>
                            <div class="form-row-input">
                                <asp:TextBox ID="txtAddress" CssClass="NeoTextBox" runat="server" placeholder="address" TextMode="multiline" MaxLength="12" Style="height: 70px" onpaste="return false" AutoCompleteType="Disabled"></asp:TextBox>
                                <div id="divAadhaarChkError1" class="DisplayError" style="font-size: 18px; font-weight: bold; color: #7b0000"></div>
                            </div>
                            <div class="form-row-Botton" id="div1" runat="server">
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-row-label">
                                <asp:Label ID="Label11" class="" runat="server">Pincode<span style="color:red"> *</span><br />ತಂದೆ / ರಕ್ಷಕರ ಹೆಸರು</asp:Label><br />
                            </div>
                            <div class="form-row-input">
                                <asp:TextBox ID="txtPincode" CssClass="NeoTextBox" runat="server" placeholder="Pincode" onpaste="return false" AutoCompleteType="Disabled" MaxLength="6" onkeypress="return Numeric(event)" onkeyup="return Numeric(event)"></asp:TextBox>
                                <asp:Label ID="lblPincodeError" class="" runat="server" style="color:red"></asp:Label><br />
                            </div>
                            <div class="form-row-Botton" id="div13" runat="server">
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-row-label">
                                <asp:Label ID="Label3" class="" runat="server">District<span style="color:red"> *</span><br />ಜಿಲ್ಲೆ</asp:Label><br />
                            </div>
                            <div class="form-row-input">
                                <asp:DropDownList ID="drpDistrict" CssClass="NeuoDropdown" AutoPostBack="true" runat="server" OnSelectedIndexChanged="drpDistrict_SelectedIndexChanged">
                                </asp:DropDownList>
                                <div id="divAadhaarChkErrwaor" class="DisplayError" style="font-size: 18px; font-weight: bold; color: #7b0000"></div>
                            </div>
                            <div class="form-row-Botton" id="div3" runat="server">
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-row-label">
                                <asp:Label ID="Label4" class="" runat="server">Taluk<span style="color:red"> *</span><br />ತಾಲ್ಲೂಕು</asp:Label><br />
                            </div>
                            <div class="form-row-input">
                                <asp:DropDownList ID="drpTaluk" Class="NeuoDropdown" runat="server" AutoPostBack="true">
                                </asp:DropDownList>
                                <div id="divAadhaarxChkErrwor" class="DisplayError" style="font-size: 18px; font-weight: bold; color: #7b0000"></div>
                            </div>
                            <div class="form-row-Botton" id="div4" runat="server">
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-row-label">
                                <asp:Label ID="Label10" class="" runat="server">DOB<span style="color:red"> *</span><br />ಜನ್ಮ ದಿನಾಂಕ</asp:Label><br />
                            </div>
                            <div class="form-row-input">
                                <asp:TextBox ID="txt_DOB" runat="server" ClientIDMode="Static" class="NeoTextBox" placeholder="DD-MM-YYYY"> </asp:TextBox>
                                <cc1:CalendarExtender ID="calDOB" PopupButtonID="image" runat="server" TargetControlID="txt_DOB" Format="dd-MM-yyyy"></cc1:CalendarExtender>
                                <div id="divAadhaarChkzErrwor" class="DisplayError" style="font-size: 18px; font-weight: bold; color: #7b0000"></div>
                            </div>
                            <div class="form-row-Botton" id="div9" runat="server">
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-row-label">
                                <asp:Label ID="Label6" class="" runat="server">Mobile Number<span style="color:red"> *</span><br />ಮೊಬೈಲ್ ಸಂಖ್ಯೆ</asp:Label><br />
                            </div>
                            <div class="form-row-input">
                                <asp:TextBox ID="txtMobileNumber" CssClass="NeoTextBox" runat="server" placeholder="Mobile Number" onpaste="return false" AutoCompleteType="Disabled" MaxLength="10" onkeypress="return Numeric(event);"></asp:TextBox>
                                <div id="divMobileChkError" class="DisplayError" style="font-size: 18px; font-weight: bold; color: #7b0000"></div>


<%--                                Numeric Value: <asp:Textbox type="text" id="text1" runat="server" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;" ></asp:Textbox>
    <span id="error" style="color: Red; display: none">* Input digits (0 - 9)</span>

                                
                                Numeric Value: <asp:Textbox type="text" id="Textbox1" runat="server" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;" ></asp:Textbox>
    <span id="error" style="color: Red; display: none">* Input digits (0 - 9)</span>
--%>


                            </div>
                            <div class="form-row-Botton" id="div5" runat="server">
                                <asp:Button ID="btnVerifyMobileNumber" runat="server" CssClass="NeoButton" Text="VERIFY" OnClick="btnVerifyMobileNumber_Click" />
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-row-label">
                                <asp:Label ID="Label7" class="" runat="server">Whatsapp Number<span style="color:red"> *</span><br />ವಾಟ್ಸಾಪ್ ಸಂಖ್ಯೆ</asp:Label><br />
                            </div>
                            <div class="form-row-input">
                                <asp:TextBox ID="txtWhatsAppNumber" CssClass="NeoTextBox" runat="server" placeholder="Whatsapp Number" onpaste="return false" AutoCompleteType="Disabled" MaxLength="10" onkeypress="return Numeric(event)" onkeyup="return Numeric(event)"></asp:TextBox>
                                <div id="divAadhaarCjhkErrwor" class="DisplayError" style="font-size: 18px; font-weight: bold; color: #7b0000"></div>
                            </div>
                            <div class="form-row-Botton" id="div6" runat="server">
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-row-label">
                                <asp:Label ID="Label8" class="" runat="server">Email ID<span style="color:red"> *</span><br />ಇಮೇಲ್ - ಐಡಿ</asp:Label><br />
                            </div>
                            <div class="form-row-input">
                                <asp:TextBox ID="txtEmailID" CssClass="NeoTextBox" runat="server" placeholder="Email ID" onpaste="return false" AutoCompleteType="Disabled"></asp:TextBox>
                                <div id="divAadhaarChkErrrwor" class="DisplayError" style="font-size: 18px; font-weight: bold; color: #7b0000"></div>
                            </div>
                            <div class="form-row-Botton" id="div7" runat="server">
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-row-label">
                                <asp:Label ID="Label9" class="" runat="server">Occupation<span style="color:red"> *</span><br />ಉದ್ಯೋಗ</asp:Label><br />
                            </div>
                            <div class="form-row-input">
                                <asp:DropDownList ID="drpOccupation" Class="NeuoDropdown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpOccupation_SelectedIndexChange">
                                    <asp:ListItem style="color: red; font-size: large; font-weight: bold; text-align: center" Value="0">--SELECT--</asp:ListItem>
                                    <asp:ListItem Value="student">student</asp:ListItem>
                                    <asp:ListItem Value="business">business</asp:ListItem>
                                    <asp:ListItem Value="employee">employee</asp:ListItem>
                                </asp:DropDownList>
                                <div id="divAadhaarChkrErrewor" class="DisplayError" style="font-size: 18px; font-weight: bold; color: #7b0000"></div>
                            </div>
                            <div class="form-row-Botton" id="div8" runat="server">
                            </div>
                        </div>
                        <div class="form-row" id="divOccupationDetails" runat="server" visible="false">
                            <div class="form-row-label">
                                <asp:Label ID="lblOccupationDetails1" class="" Visible="false" runat="server">Email ID<span style="color:red"> *</span><br />ಇಮೇಲ್ - ಐಡಿ</asp:Label><br />
                                <asp:Label ID="lblOccupationDetails" class="" runat="server">Email ID<span style="color:red"> *</span><br />ಇಮೇಲ್ - ಐಡಿ</asp:Label><br />
                            </div>
                            <div class="form-row-input">
                                <asp:TextBox ID="txtOccupationDetails" CssClass="NeoTextBox" runat="server" placeholder="Occupation Details" onpaste="return false" AutoCompleteType="Disabled"></asp:TextBox>
                                <div id="divAadhaasdfrChkErrrwor" class="DisplayError" style="font-size: 18px; font-weight: bold; color: #7b0000"></div>
                            </div>
                            <div class="form-row-Botton" id="div10" runat="server">
                            </div>
                        </div>
                        <div class="form-row" runat="server">
                                <p style="text-align:justify"><asp:CheckBox runat="server" CssClass="ChkBoxClass" ID="ChkSelfDeclaration"  /> I hereby certify that the above furnished information is true to my knowledge. I shall abide by the terms and conditions of the sanction of the Self Employment Loan. If any discrepancies are found later, I agree to take legal action against me.<br />ಈ ಮೇಲ್ಕಂಡ ಮಾಹಿತಿಗಳು ನನಗೆ ತಿಳಿದ ಮಟ್ಟಿಗೆ ಸತ್ಯ ಮತ್ತು ಸರಿಯಾಗಿವೆಯೆಂದು ಪ್ರಮಾಣಿಕರಿಸುತ್ತೇನೆ. ಒಂದು ವೇಳೆ ಮೇಲ್ಕಂಡ ಮಾಹಿತಿಗಳು ಸುಳ್ಳು ಎಂದು ಕಂಡುಬಂದಲ್ಲಿ ನನ್ನ ವಿರುದ್ಧ ಕಾನೂನು ರೀತಿ ಕ್ರಮ ಜರುಗಿಸಲು ನಾನು ಒಪ್ಪಿರುತ್ತೇನೆ.</p>
                        </div>
                        <div class="form-row" id="div11" runat="server">
                            <div class="form-row-label">
                            </div>
                            <div class="form-row-input">
                                <asp:Button ID="btnSubmit" runat="server" CssClass="SubmitButton" Visible="true" Text="submit" Style="width: 100%" OnClick="btnSubmit_Click" />
                            </div>
                            <div class="form-row-Botton" id="div12" runat="server">
                            </div>
                        </div>
                        
                    </div>
                </div>

                <asp:Panel ID="PnlAVPMobileNumVerify" runat="server" CssClass="modalPopup" Width="35%" Style="display: none">
                    <div class="Popup-flex-container">
                        <div class="">
                            <div class="form-row" style="justify-content: center">
                                <div class="Popup-row-label-Heading">
                                    <asp:Label ID="Label76" class="" runat="server" Text="Verify OTP"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="Popup-row-label">
                                    <asp:Label ID="Label78" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="Popup-row-input">
                                    <asp:Label ID="lblOTPMobDisp" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="Popup-row-label">
                                    <asp:Label ID="Label79" runat="server" Text="OTP"></asp:Label>
                                </div>
                                <div class="otp-input">
                                    <asp:TextBox ID="txtOTP" CssClass="OTPTextBox" runat="server" TextMode="number" MaxLength="8" onChange="javascript:Count(this);" onkeyup="javascript:Count(this);" onkeypress="javascript:Count(this);"></asp:TextBox>
                                    <asp:Label runat="server" ID="lblOTPError" Style="color: red; font-size: 13px"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="Popup-row-Button text-center">
                                    <asp:Button ID="btnAVPVerifyOTP" runat="server" CssClass="DownloadButton" Text="Verify" OnClick="btnAVPVerifyOTP_Click" />
                                    <asp:Button ID="btnAVPOTPResend" runat="server" CssClass="ActionButton" Text="Resend" OnClick="btnAVPOTPResend_Click" />
                                    <asp:Button ID="Button12" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:LinkButton ID="lnkAVPMobileNumVerify" runat="server"></asp:LinkButton>
                <cc1:ModalPopupExtender ID="AVPMobileNumVerifyPopup" runat="server" PopupControlID="PnlAVPMobileNumVerify"
                    TargetControlID="lnkAVPMobileNumVerify" BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>

                <asp:Panel ID="PnlOtherDetails" runat="server" CssClass="modalPopup" Style="display: none; padding: 5px; min-width:25%">
                    <div class="form-row" style="justify-content: center">
                        <div class="Popup-row-label-Heading">
                            <asp:Label ID="lblNotificationHeading" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="Popup-row-label">
                            <asp:Label ID="lblNotificationContent" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-row">

                        <div class="Popup-row-Button text-center">
                            <asp:Button ID="Button1" runat="server" CssClass="CancelButton" Text="Ok" />
                        </div>
                    </div>

                </asp:Panel>

                <asp:LinkButton ID="lnkOtherDetails" runat="server"></asp:LinkButton>
                <cc1:ModalPopupExtender ID="OtherDetailsPopup" runat="server" TargetControlID="lnkOtherDetails" PopupControlID="PnlOtherDetails"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>

            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelAVPortal" runat="server" DisplayAfter="0">
            <ProgressTemplate>
                <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                    <div style="position: absolute; left: 40%; top: 20%;">
                        <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" style="margin: auto; background: none; display: block; shape-rendering: auto;" width="300px" height="300px" viewBox="0 0 100 100" preserveAspectRatio="xMidYMid">
                            <path fill="none" stroke="#ad0000" stroke-width="8" stroke-dasharray="42.76482137044271 42.76482137044271" d="M24.3 30C11.4 30 5 43.3 5 50s6.4 20 19.3 20c19.3 0 32.1-40 51.4-40 C88.6 30 95 43.3 95 50s-6.4 20-19.3 20C56.4 70 43.6 30 24.3 30z" stroke-linecap="round" style="transform: scale(0.8); transform-origin: 50px 50px">
                                <animate attributeName="stroke-dashoffset" repeatCount="indefinite" dur="2s" keyTimes="0;1" values="0;256.58892822265625"></animate>
                            </path>
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </form>
</body>
</html>
