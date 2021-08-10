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
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="viewport" content="width=device-width">

    <style>
        .list-inline {
    list-style: outside none none;
    margin-left: -5px;
    padding-left: 0;
}

.list-inline > li {
    display: inline-block;
    padding-left: 5px;
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

function Numeric2(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (((charCode >= 48 && charCode <= 57)|| (e.keyCode >= 96 && e.keyCode <= 105)) || charCode == 46)) {
                return true;}
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

          function OTPNumeric(evt) {
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
                                <asp:Label ID="Label11" class="" runat="server">Pincode<span style="color:red"> *</span><br />ಅಂಚೆ ಸಂಖ್ಯೆ</asp:Label><br />
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
                            </div>
                            </div>
                        <div class="Popup-row-Button text-center">
                            <ul class="list-inline">
                                <li>
                                    <a target="_blank" href="https://facebook.com/sharer.php?u=https://aryavysya.karnataka.gov.in/Schemes/AryaVysyaPortal/AryaVysyaPortal" class="social facebook"></a>
                                </li>
                                <li>
                                    <a target="_blank" href="https://www.linkedin.com/shareArticle?mini=true&amp;url=https://aryavysya.karnataka.gov.in/Schemes/AryaVysyaPortal/AryaVysyaPortal;title=Arya Vysya Portal" class="social linkedin"></a>
                                </li>
                                <li>
                                    <a target="_blank" href="https://twitter.com/intent/tweet?url=https://aryavysya.karnataka.gov.in/Schemes/AryaVysyaPortal/AryaVysyaPortal&amp;text=Arya Vysya Portal" class="social twitter"></a>
                                </li>
                                <li>
                                    <a href="whatsapp://send?text=Arya Vysya Portal "
                                        data-action="share/whatsapp/share"
                                        target="_blank">
                                        <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="32px" height="32px" viewBox="0 0 1219.547 1225.016">
                                            <path fill="#E0E0E0" d="M1041.858 178.02C927.206 63.289 774.753.07 612.325 0 277.617 0 5.232 272.298 5.098 606.991c-.039 106.986 27.915 211.42 81.048 303.476L0 1225.016l321.898-84.406c88.689 48.368 188.547 73.855 290.166 73.896h.258.003c334.654 0 607.08-272.346 607.222-607.023.056-162.208-63.052-314.724-177.689-429.463zm-429.533 933.963h-.197c-90.578-.048-179.402-24.366-256.878-70.339l-18.438-10.93-191.021 50.083 51-186.176-12.013-19.087c-50.525-80.336-77.198-173.175-77.16-268.504.111-278.186 226.507-504.503 504.898-504.503 134.812.056 261.519 52.604 356.814 147.965 95.289 95.36 147.728 222.128 147.688 356.948-.118 278.195-226.522 504.543-504.693 504.543z" />
                                            <linearGradient id="a" gradientUnits="userSpaceOnUse" x1="609.77" y1="1190.114" x2="609.77" y2="21.084">
                                                <stop offset="0" stop-color="#20b038" />
                                                <stop offset="1" stop-color="#60d66a" />
                                            </linearGradient><path fill="url(#a)" d="M27.875 1190.114l82.211-300.18c-50.719-87.852-77.391-187.523-77.359-289.602.133-319.398 260.078-579.25 579.469-579.25 155.016.07 300.508 60.398 409.898 169.891 109.414 109.492 169.633 255.031 169.57 409.812-.133 319.406-260.094 579.281-579.445 579.281-.023 0 .016 0 0 0h-.258c-96.977-.031-192.266-24.375-276.898-70.5l-307.188 80.548z" /><image overflow="visible" opacity=".08" width="682" height="639" xlink:href="FCC0802E2AF8A915.png" transform="translate(270.984 291.372)" /><path fill-rule="evenodd" clip-rule="evenodd" fill="#FFF" d="M462.273 349.294c-11.234-24.977-23.062-25.477-33.75-25.914-8.742-.375-18.75-.352-28.742-.352-10 0-26.25 3.758-39.992 18.766-13.75 15.008-52.5 51.289-52.5 125.078 0 73.797 53.75 145.102 61.242 155.117 7.5 10 103.758 166.266 256.203 226.383 126.695 49.961 152.477 40.023 179.977 37.523s88.734-36.273 101.234-71.297c12.5-35.016 12.5-65.031 8.75-71.305-3.75-6.25-13.75-10-28.75-17.5s-88.734-43.789-102.484-48.789-23.75-7.5-33.75 7.516c-10 15-38.727 48.773-47.477 58.773-8.75 10.023-17.5 11.273-32.5 3.773-15-7.523-63.305-23.344-120.609-74.438-44.586-39.75-74.688-88.844-83.438-103.859-8.75-15-.938-23.125 6.586-30.602 6.734-6.719 15-17.508 22.5-26.266 7.484-8.758 9.984-15.008 14.984-25.008 5-10.016 2.5-18.773-1.25-26.273s-32.898-81.67-46.234-111.326z" /><path fill="#FFF" d="M1036.898 176.091C923.562 62.677 772.859.185 612.297.114 281.43.114 12.172 269.286 12.039 600.137 12 705.896 39.633 809.13 92.156 900.13L7 1211.067l318.203-83.438c87.672 47.812 186.383 73.008 286.836 73.047h.255.003c330.812 0 600.109-269.219 600.25-600.055.055-160.343-62.328-311.108-175.649-424.53zm-424.601 923.242h-.195c-89.539-.047-177.344-24.086-253.93-69.531l-18.227-10.805-188.828 49.508 50.414-184.039-11.875-18.867c-49.945-79.414-76.312-171.188-76.273-265.422.109-274.992 223.906-498.711 499.102-498.711 133.266.055 258.516 52 352.719 146.266 94.195 94.266 146.031 219.578 145.992 352.852-.118 274.999-223.923 498.749-498.899 498.749z" /></svg>
                                    </a></li>
                             
                              
                            </ul>

                        
                            

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
                                    <asp:TextBox ID="txtOTP"  runat="server" CssClass="OTPTextBox" TextMode="number" MaxLength="8" onChange="javascript:Count(this);" onkeyup="javascript:Count(this);" onkeypress="javascript:Count(this);"></asp:TextBox>
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

                <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Width="35%" Style="display: none">
                    <div class="Popup-flex-container">
                        <div class="">
                            <div class="form-row" style="justify-content:center">
                                <div class="Popup-row-label-Heading">
                                    <asp:Label ID="lblNotificationHeadingNew" class="" Style="font-size: 20px; margin-top: 20px;" runat="server" Text=" "></asp:Label>
                                                                <asp:Label ID="lblNotificationContentNew" class="" runat="server"></asp:Label><br />

                                </div>
                            </div>
                            <div class="Popup-row-label">
                                <asp:Label ID="lblNotificationHeading" class="" runat="server"></asp:Label><br />
                                <asp:Label ID="lblNotificationContent" class="" runat="server"></asp:Label><br />

                            </div>
                            <div class="form-row">

                                <div class="Popup-row-Button text-center">
                                    <asp:Button ID="btnReset" runat="server" CssClass="CancelButton" Text="Ok" />
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>

                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                <cc1:ModalPopupExtender ID="NotifyOtherDestailsPopup" runat="server" PopupControlID="Panel1"
                    TargetControlID="LinkButton1" BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>


                <asp:Panel ID="PnlNotifyOtherDetails" runat="server" CssClass="modalPopup" Width="35%" Style="display: none">
                    <asp:Label ID="lblNotificationHeading1" runat="server" Text=""></asp:Label>
                     <asp:Label ID="lblNotificationContent1" runat="server"></asp:Label>
                </asp:Panel>

                <asp:LinkButton ID="lnkNotifyOtherDetails" runat="server"></asp:LinkButton>
                <cc1:ModalPopupExtender ID="NotifyOtherDetailsPopup1" runat="server" PopupControlID="PnlNotifyOtherDetails"
                    TargetControlID="lnkNotifyOtherDetails" BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>



                <asp:Panel ID="PnlSuccess" runat="server" CssClass="modalPopup" Style="display: none; padding: 5px; min-width:25%">
                    <div class="Popup-flex-container">
                    <div class="form-row" style="justify-content: center">
                        <div class="Popup-row-label-Heading">
                            <asp:Label ID="lblSuccessHead" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="Popup-row-label">
                            <asp:Label ID="lblSuccessMessage" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-row">

                        <div class="Popup-row-Button text-center">
                            <asp:Button ID="Button1" runat="server" CssClass="CancelButton" Text="Ok"  />
                        </div>
                    </div>
                    <div class="form-row" runat="server" visible="false" id="divsuccess">
                        <div class="Popup-row-Button text-center">
                            <ul class="list-inline">
                                <li>
                                    <a target="_blank" href="https://facebook.com/sharer.php?u=https://aryavysya.karnataka.gov.in/Schemes/AryaVysyaPortal/AryaVysyaPortal" class="social facebook"></a>
                                </li>
                                <li>
                                    <a target="_blank" href="https://www.linkedin.com/shareArticle?mini=true&amp;url=https://aryavysya.karnataka.gov.in/Schemes/AryaVysyaPortal/AryaVysyaPortal;title=Arya Vysya Portal" class="social linkedin"></a>
                                </li>
                                <li>
                                    <a target="_blank" href="https://twitter.com/intent/tweet?url=https://aryavysya.karnataka.gov.in/Schemes/AryaVysyaPortal/AryaVysyaPortal&amp;text=Arya Vysya Portal" class="social twitter"></a>
                                </li>
                                <li>
                                    <a href="whatsapp://send?text=Arya Vysya Portal "
                                        data-action="share/whatsapp/share"
                                        target="_blank">
                                        <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="32px" height="32px" viewBox="0 0 1219.547 1225.016">
                                            <path fill="#E0E0E0" d="M1041.858 178.02C927.206 63.289 774.753.07 612.325 0 277.617 0 5.232 272.298 5.098 606.991c-.039 106.986 27.915 211.42 81.048 303.476L0 1225.016l321.898-84.406c88.689 48.368 188.547 73.855 290.166 73.896h.258.003c334.654 0 607.08-272.346 607.222-607.023.056-162.208-63.052-314.724-177.689-429.463zm-429.533 933.963h-.197c-90.578-.048-179.402-24.366-256.878-70.339l-18.438-10.93-191.021 50.083 51-186.176-12.013-19.087c-50.525-80.336-77.198-173.175-77.16-268.504.111-278.186 226.507-504.503 504.898-504.503 134.812.056 261.519 52.604 356.814 147.965 95.289 95.36 147.728 222.128 147.688 356.948-.118 278.195-226.522 504.543-504.693 504.543z" />
                                            <linearGradient id="a" gradientUnits="userSpaceOnUse" x1="609.77" y1="1190.114" x2="609.77" y2="21.084">
                                                <stop offset="0" stop-color="#20b038" />
                                                <stop offset="1" stop-color="#60d66a" />
                                            </linearGradient><path fill="url(#a)" d="M27.875 1190.114l82.211-300.18c-50.719-87.852-77.391-187.523-77.359-289.602.133-319.398 260.078-579.25 579.469-579.25 155.016.07 300.508 60.398 409.898 169.891 109.414 109.492 169.633 255.031 169.57 409.812-.133 319.406-260.094 579.281-579.445 579.281-.023 0 .016 0 0 0h-.258c-96.977-.031-192.266-24.375-276.898-70.5l-307.188 80.548z" /><image overflow="visible" opacity=".08" width="682" height="639" xlink:href="FCC0802E2AF8A915.png" transform="translate(270.984 291.372)" /><path fill-rule="evenodd" clip-rule="evenodd" fill="#FFF" d="M462.273 349.294c-11.234-24.977-23.062-25.477-33.75-25.914-8.742-.375-18.75-.352-28.742-.352-10 0-26.25 3.758-39.992 18.766-13.75 15.008-52.5 51.289-52.5 125.078 0 73.797 53.75 145.102 61.242 155.117 7.5 10 103.758 166.266 256.203 226.383 126.695 49.961 152.477 40.023 179.977 37.523s88.734-36.273 101.234-71.297c12.5-35.016 12.5-65.031 8.75-71.305-3.75-6.25-13.75-10-28.75-17.5s-88.734-43.789-102.484-48.789-23.75-7.5-33.75 7.516c-10 15-38.727 48.773-47.477 58.773-8.75 10.023-17.5 11.273-32.5 3.773-15-7.523-63.305-23.344-120.609-74.438-44.586-39.75-74.688-88.844-83.438-103.859-8.75-15-.938-23.125 6.586-30.602 6.734-6.719 15-17.508 22.5-26.266 7.484-8.758 9.984-15.008 14.984-25.008 5-10.016 2.5-18.773-1.25-26.273s-32.898-81.67-46.234-111.326z" /><path fill="#FFF" d="M1036.898 176.091C923.562 62.677 772.859.185 612.297.114 281.43.114 12.172 269.286 12.039 600.137 12 705.896 39.633 809.13 92.156 900.13L7 1211.067l318.203-83.438c87.672 47.812 186.383 73.008 286.836 73.047h.255.003c330.812 0 600.109-269.219 600.25-600.055.055-160.343-62.328-311.108-175.649-424.53zm-424.601 923.242h-.195c-89.539-.047-177.344-24.086-253.93-69.531l-18.227-10.805-188.828 49.508 50.414-184.039-11.875-18.867c-49.945-79.414-76.312-171.188-76.273-265.422.109-274.992 223.906-498.711 499.102-498.711 133.266.055 258.516 52 352.719 146.266 94.195 94.266 146.031 219.578 145.992 352.852-.118 274.999-223.923 498.749-498.899 498.749z" /></svg>
                                    </a></li>
                             
                              
                            </ul>

                        
                            

                        </div>
                    </div>
                        </div>
                </asp:Panel>

                <asp:LinkButton ID="lnkSuccess" runat="server"></asp:LinkButton>
                <cc1:ModalPopupExtender ID="SuccessPopup" runat="server" TargetControlID="lnkSuccess" PopupControlID="PnlSuccess"
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
