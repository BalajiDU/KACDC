<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AryaVysyaPortal.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="KACDC.Schemes.AryaVysyaPortal.AryaVysyaPortal" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ARYA VYSYA PORTAL</title>
        <link rel="shortcut icon" type="image/x-icon" href="../../Image/KACDC_PDF.jpg" />
    <link href="../../CustomCSS/ApplicationPage/ApplicationPage.css" rel="stylesheet" />
    <link href="../../CustomCSS/Calender.css" rel="stylesheet" />

<%--    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js" /> --%>


    <style>
        .list-inline {
    list-style: outside none none;
    margin-left: -5px;
    padding-left: 0;
}

.list-inline > li {
    display: inline-block;
    padding-left: 5px;
    padding-right: 5px;
}

.social {
  background: url('http://arunendapally.com/themes/CustomTheme/ss.png');
  width: 32px;
  height: 32px;
  display: inline-block;
  background-repeat: no-repeat;
}

.facebook {
  background-position: -0px -0px;
}

.linkedin {
  background-position: -0px -42px;
}

.twitter {
  background-position: -0px -84px;
}

.googleplus {
  background-position: -0px -126px;
}










.socialsharing {
	 text-align: center;
}
 .socialsharing a {
	 display: inline-block;
	 padding: 0.7em;
	 line-height: 0;
	 margin-bottom: 2em;
}
 .socialsharing path {
	 fill: black;
}
 .socialsharing svg {
	 width: 24px;
	 height: 24px;
}











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
                                <asp:TextBox ID="txt_DOB" runat="server" ClientIDMode="Static" class="NeoTextBox" placeholder="DD-MM-YYYY" AutoPostBack="true" OnTextChanged="txt_DOB_TextChanged"> </asp:TextBox>
                                <cc1:CalendarExtender ID="calDOB" PopupButtonID="image" runat="server" TargetControlID="txt_DOB" Format="dd-MM-yyyy" CssClass= " cal_Theme1"></cc1:CalendarExtender>
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
                                <asp:Button ID="btntest" runat="server" CssClass="SubmitButton" Visible="true" Text="test submit" Style="width: 100%" OnClick="btntest_Click" />
                            </div>
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
                    <div class="form-row">

                        <div class="Popup-row-Button text-center">
                            <ul class="list-inline">
                                <li>
                                    <a target="_blank" href="https://facebook.com/sharer.php?u=https://aryavysya.karnataka.gov.in/Schemes/AryaVysyaPortal/AryaVysyaPortal" class="social facebook"></a>
                                </li>
                                <li>
                                    <a target="_blank" href="https://www.linkedin.com/shareArticle?mini=true&amp;url=https://aryavysya.karnataka.gov.in/Schemes/AryaVysyaPortal/AryaVysyaPortal;title=Protect your source code from decompiling or reverse engineering" class="social linkedin"></a>
                                </li>
                                <li>
                                    <a target="_blank" href="https://twitter.com/intent/tweet?url=https://aryavysya.karnataka.gov.in/Schemes/AryaVysyaPortal/AryaVysyaPortal&amp;text=Protect your source code from decompiling or reverse engineering&amp;via=arunendapally" class="social twitter"></a>
                                </li>
                                <li>
                                    <a target="_blank" href="https://plus.google.com/share?url=https://aryavysya.karnataka.gov.in/Schemes/AryaVysyaPortal/AryaVysyaPortal" class="social googleplus"></a>
                                </li>
                            </ul>

                            <aside class="socialsharing">
    <a href="https://www.facebook.com/sharer/sharer.php?u=@enc" target="_blank" rel="noopener noreferrer nofollow">
        <svg role="img" aria-labelledby="_fb">
            <title id="_fb">Share on Facebook</title>
            <path d="M22.676 0H1.324C.593 0 0 .593 0 1.324v21.352C0 23.408.593 24 1.324 24h11.494v-9.294H9.689v-3.621h3.129V8.41c0-3.099 1.894-4.785 4.659-4.785 1.325 0 2.464.097 2.796.141v3.24h-1.921c-1.5 0-1.792.721-1.792 1.771v2.311h3.584l-.465 3.63H16.56V24h6.115c.733 0 1.325-.592 1.325-1.324V1.324C24 .593 23.408 0 22.676 0"></path>
        </svg>
    </a>
   
    <a href="https://plus.google.com/share?url=@enc" target="_blank" rel="noopener noreferrer nofollow">
        <svg role="img" aria-labelledby="_gp">
            <title id="_gp">Share on Google+</title>
            <path d="M7.635 10.909v2.619h4.335c-.173 1.125-1.31 3.295-4.331 3.295-2.604 0-4.731-2.16-4.731-4.823 0-2.662 2.122-4.822 4.728-4.822 1.485 0 2.479.633 3.045 1.178l2.073-1.994c-1.33-1.245-3.056-1.995-5.115-1.995C3.412 4.365 0 7.785 0 12s3.414 7.635 7.635 7.635c4.41 0 7.332-3.098 7.332-7.461 0-.501-.054-.885-.12-1.265H7.635zm16.365 0h-2.183V8.726h-2.183v2.183h-2.182v2.181h2.184v2.184h2.189V13.09H24"></path>
        </svg>
    </a>
    <a href="mailto:?subject=@Model.Replace(" ", "%20")&amp;body=@enc" target="_blank" rel="noopener noreferrer nofollow">
        <svg role="img" aria-labelledby="_em">
            <title id="_em">Email</title>
            <path d="M24 7.387v10.478c0 .23-.08.424-.238.576-.158.154-.352.23-.58.23h-8.547v-6.959l1.6 1.229c.102.085.229.126.379.126.148 0 .277-.041.389-.127L24 7.387zm-9.365-2.021h8.547c.211 0 .393.063.543.192.15.128.234.3.248.51l-7.369 5.876-1.969-1.549V5.366zM13.404.864v22.271L0 20.819V3.244L13.406.864h-.002zm-4.049 11.18c-.02-1.133-.313-2.072-.879-2.814-.555-.74-1.275-1.131-2.131-1.164-.824.033-1.529.423-2.1 1.164-.57.742-.855 1.682-.87 2.814.015 1.117.315 2.047.885 2.791.571.74 1.274 1.133 2.101 1.176.855-.035 1.574-.424 2.145-1.17.57-.748.87-1.68.885-2.797h-.036zm-3.12-2.482c.431.02.794.256 1.083.717.285.461.435 1.045.435 1.752 0 .721-.149 1.307-.435 1.771-.301.464-.66.704-1.096.704s-.795-.226-1.095-.69-.435-1.05-.435-1.754c0-.705.135-1.291.435-1.74.284-.45.646-.69 1.081-.721l.027-.039z"></path>
        </svg>
    </a>
                                <a href="mailto:?subject=@Model.Replace(" ", "%20")&amp;body=@enc" target="_blank" rel="noopener noreferrer nofollow">
        <svg role="img" aria-labelledby="_em">
            <title id="_em">Email</title>
<path d=" M19.11 17.205c-.372 0-1.088 1.39-1.518 1.39a.63.63 0 0 1-.315-.1c-.802-.402-1.504-.817-2.163-1.447-.545-.516-1.146-1.29-1.46-1.963a.426.426 0 0 1-.073-.215c0-.33.99-.945.99-1.49 0-.143-.73-2.09-.832-2.335-.143-.372-.214-.487-.6-.487-.187 0-.36-.043-.53-.043-.302 0-.53.115-.746.315-.688.645-1.032 1.318-1.06 2.264v.114c-.015.99.472 1.977 1.017 2.78 1.23 1.82 2.506 3.41 4.554 4.34.616.287 2.035.888 2.722.888.817 0 2.15-.515 2.478-1.318.13-.33.244-.73.244-1.088 0-.058 0-.144-.03-.215-.1-.172-2.434-1.39-2.678-1.39zm-2.908 7.593c-1.747 0-3.48-.53-4.942-1.49L7.793 24.41l1.132-3.337a8.955 8.955 0 0 1-1.72-5.272c0-4.955 4.04-8.995 8.997-8.995S25.2 10.845 25.2 15.8c0 4.958-4.04 8.998-8.998 8.998zm0-19.798c-5.96 0-10.8 4.842-10.8 10.8 0 1.964.53 3.898 1.546 5.574L5 27.176l5.974-1.92a10.807 10.807 0 0 0 16.03-9.455c0-5.958-4.842-10.8-10.802-10.8z" fill-rule="evenodd"></path>        </svg>
    </a>
</aside>
<a href="mailto:?subject=@Model.Replace(" ", "%20")&amp;body=@enc" target="_blank" rel="noopener noreferrer nofollow">
        <svg role="img" aria-labelledby="_em">
            <title id="_em">Email</title>
            <path d="M24 7.387v10.478c0 .23-.08.424-.238.576-.158.154-.352.23-.58.23h-8.547v-6.959l1.6 1.229c.102.085.229.126.379.126.148 0 .277-.041.389-.127L24 7.387zm-9.365-2.021h8.547c.211 0 .393.063.543.192.15.128.234.3.248.51l-7.369 5.876-1.969-1.549V5.366zM13.404.864v22.271L0 20.819V3.244L13.406.864h-.002zm-4.049 11.18c-.02-1.133-.313-2.072-.879-2.814-.555-.74-1.275-1.131-2.131-1.164-.824.033-1.529.423-2.1 1.164-.57.742-.855 1.682-.87 2.814.015 1.117.315 2.047.885 2.791.571.74 1.274 1.133 2.101 1.176.855-.035 1.574-.424 2.145-1.17.57-.748.87-1.68.885-2.797h-.036zm-3.12-2.482c.431.02.794.256 1.083.717.285.461.435 1.045.435 1.752 0 .721-.149 1.307-.435 1.771-.301.464-.66.704-1.096.704s-.795-.226-1.095-.69-.435-1.05-.435-1.754c0-.705.135-1.291.435-1.74.284-.45.646-.69 1.081-.721l.027-.039z"></path>
        </svg>
    </a>
                            

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
