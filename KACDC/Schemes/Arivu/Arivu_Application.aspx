<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Arivu_Application.aspx.cs" Inherits="KACDC.Schemes.Arivu.Arivu_Application" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Arivu Education Loan</title>
    <link rel="shortcut icon" type="image/x-icon" href="../../Image/KACDC_PDF.jpg" />  
    <link href="../../CustomCSS/Success_Animation.css" rel="stylesheet" />
    <script src="../../Scripts/bootstrap.js"></script>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/1.11.2/jquery.js"></script>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.9.1/themes/base/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script src="http://code.jquery.com/ui/1.9.1/jquery-ui.js"></script>
    <script type="text/javascript" src="Scripts/jquery.blockUI.js"></script>
    <script type="text/javascript" src="Scripts/jquery-1.3.2.min.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-1.9.0.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-1.9.0.min.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <style type="text/css">
        tr, td {
            padding: 8px;
        }

        .auto-style1 {
            width: 100%;
            height: 100%;
        }

        .auto-style2 {
            width: 20%;
        }

        .auto-style3 {
            width: 20%;
        }

        .auto-style4 {
            width: 30%;
        }

        .auto-style5 {
            text-align: center;
            width: 268435344px;
        }

        .auto-style7 {
            width: 20%;
        }

        .auto-style8 {
            width: 20%;
            height: 23px;
        }

        .auto-style10 {
            height: 23px;
            width: 268435344px;
        }

        .auto-style11 {
            width: 30%;
            height: 23px;
        }

        .auto-style12 {
            width: 268435344px;
        }

        .auto-style13 {
            height: 23px;
        }

        .auto-style14 {
            text-align: center;
        }
    </style>
  
    <style>
      

        .ChkBoxClass input {
            width: 15px;
            height: 15px;
        }
    </style>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"  />


    <script src="Scripts/jquery-3.0.0.js"></script>
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.3/css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.21/css/dataTables.bootstrap4.min.css" />
    <link rel="stylesheet" type="text/css" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.21/css/dataTables.jqueryui.min.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.7/css/jquery.dataTables.min.css" />
    <script src="https://cdn.datatables.net/1.10.7/js/jquery.dataTables.min.js">  </script>


    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.3.1/js/dataTables.buttons.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.3.1/js/buttons.html5.min.js"></script>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css">  
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>  
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js"></script> 

    <style>
        .Neumorphic {
            border-radius: 25px;
            background: #00a2ed;
            box-shadow: 10px 10px 20px #bdbdbd, -10px -10px 20px #f5f5f5;
            display: flex;
            justify-content: center;
            margin-right: 4rem;
            padding: 10px;
            margin: 20px;
            text-align: center;
            align-items: center;
            letter-spacing: 1.5px;
            font-size: 40px;
            font-family:sans-serif;
            font-family:sans-serif;
        }

        .NestedNeumorphic {
            background: #d9d9d9;
            box-shadow: inset 5px 5px 10px #bdbdbd, inset -5px -5px 10px #f5f5f5;
            border-radius: 10px;
            display: flex;
            justify-content: center;
            margin-right: 4rem;
            padding: 5px;
            margin: 5px;
            text-align: center;
            align-items: center;
            letter-spacing: 1.5px;
            font-size: 20px;
            font-family:sans-serif;
        }

        .NeuoDropdown {
            outline: none;
            border: none;
            background: #d9d9d9;
            box-shadow: inset 5px 5px 10px #bdbdbd, inset -5px -5px 10px #f5f5f5;
            border-radius: 10px;
            display: flex;
            justify-content: center;
            margin-right: 4rem;
            padding: 5px;
            margin: 5px;
            text-align: center;
            align-items: center;
            letter-spacing: 1.5px;
            font-size: 15px;
            font-family:sans-serif;
        }
        
        .form-row-label-Heading {
            padding-right: 10px;
            flex: 1;
            padding: 10px;
            width: 50%;
            font-weight: 300;
            letter-spacing: .2em;
            text-transform: uppercase;
            text-align: center;
            font-size: 35px;
            color:#7b0000;
            Background:white;
            font-family:sans-serif;
            font-weight:600;
        }

        .NeumorphicDiv {
            border-radius: 25px;
            background: #229179;
            box-shadow: 10px 10px 10px #797878, -10px -10px 10px #ffffff;
            justify-content: center;
            padding: 25px;
            margin: 20px;
            margin-top: 10px;
            align-items: center;
            letter-spacing: 1.5px;
            font-family:sans-serif;
            width: 60%;
            color:#620000;
        }

        .flex-container {
            display: flex;
            justify-content: space-around;
            align-items: center;
            flex-direction: row;
        }

        .flex-container-column {
            justify-content: space-around;
            display: flex;
            flex-direction: column;
        }

        .SectionMarginTop {
            margin-top: 0;
        }

        .NestedLabel {
            font-size: 20px;
            padding: 10px;
        }

        .LogoutButton {
            display: block;
            height: 100%;
            width: 100%;
            line-height: 65px;
            font-size: 20px;
            color: white;
            padding-left: -40px;
            box-sizing: border-box;
            border-bottom: 1px solid black;
            border-top: 1px solid rgba(255,255,255,.1);
            transition: .4s;
            background: transparent;
            color: red;
        }

        .NeoButton1 {
            padding: 5px;
            margin: 10px;
            outline: none;
            /*width: 40%;*/
            max-width: 60%;
            font-size: 16px;
            background: transparent;
            border: none;
            outline: none;
            cursor: pointer;
            border-radius: 3px;
            /*box-shadow: 8px 8px 10px #797878, -8px -8px 10px #ffffff;*/
        }

        .NeoButton {
            border: none;
            padding: 3px;
            margin: 7px;
            outline: none;
            /*width: 80%;*/
            padding-right:20px;
            padding-left:20px;
            height: 35px;
            align-items: center;
            align-content: center;
            border-radius: 3px;
            letter-spacing: .05em;
            text-transform: uppercase;
            font-size: 13px;
            background: transparent;
            color: #fff;
            background: rgba(3,154,244,0.8);
            cursor: pointer;
            border-style: none;
            outline: none;
            background: #dbdbdb;
            color: black;
            flex-wrap: wrap;
            -webkit-appearance: button;
            outline: none;
            /*box-shadow: 5px 5px 10px #797878, -5px -5px 10px #ffffff;*/
            font-size: 15px;
        }

            .NeoButton:hover {
                box-shadow: 5px 5px 10px white, -5px -5px 10px white;
            }

            .NeoButton:active {
                box-shadow: inset 5px 5px 10px #d4d2d2, inset -5px -5px 10px #ffffff;
            }

        .NeoTextBox {
           letter-spacing: .08em;
            box-sizing: border-box;
            width: 90%;
            height: 35px;
            font-size: 18px;
            border: none;
            padding: 5px;
            margin: 10px;
            outline: none;
            display: flex;
            flex-wrap: wrap;
            text-align: center;
            background: #eeecec;
            border-radius: 6px;
            text-shadow: 1px 1px 0 #fff;
            color: #303030;
            box-shadow: inset 5px 5px 10px #dddbdb, inset -5px -5px 10px #fffdfd;
            text-transform:uppercase;
        }

            .NeoTextBox:focus {
                box-shadow: inset 2px 2px 2px #e2e0e0, inset -2px -2px 2px #faf8f8;
            }

        .PopupTextBox {
            box-sizing: border-box;
            height: 50px;
            font-size: 18px;
            padding: 7px;
            border: none;
            outline: none;
            display: flex;
            flex-wrap: wrap;
            text-align: center;
            background: #eeecec;
            border-radius: 10px;
            text-shadow: 1px 1px 0 #fff;
            color: #303030;
            box-shadow: inset 5px 5px 10px #dddbdb, inset -5px -5px 10px #fffdfd;
        }
       
        .modalPopup {
            margin: 35px 5px 0px 10px;
            padding: 10px;
            background-color: white;
            border-radius: 25px;
            box-shadow: 1px 1px 2px #cac9c9,
                        -1px -1px 2px #ffffff;
            /*margin: 20px;
            margin-top: 30px;*/
            font-size: 20px;
            align-items: center;
            letter-spacing: 1.5px;
            overflow: auto;
            font-family:sans-serif;
            color:black;
        }
      

        .PopupPanel {
            max-Width: 50%;
            /*Height: 720px;*/
            max-height: 85%;
        }
        .form-row {
            padding: 10px 0;
            display: flex;
            justify-content: flex-end;
            padding: 5px;
        }

        .form-row-label {
            padding-right: 10px;
            flex: 1;
            font-size: 15px;
            padding: 5px;
            font-weight: 600;
            letter-spacing: .09em;
            text-transform: uppercase;
            color:white;
            /*background-color:aquamarine;*/
        }
        
        .Popup-row-label {
          padding-right: 10px;
            flex: 1;
            font-size: 13px;
            padding: 5px;
            font-weight: 600;
            letter-spacing: .09em;
            text-transform: uppercase;
            color:black;
            /*background-color:aquamarine;*/
        }
         .Popup-row-label-Heading{
            font-size: 25px;
            font-weight: bold;
            font-family:sans-serif;
            letter-spacing: 1.5px;
            text-transform: uppercase;
            color:#7b0a0a;
        }
        .form-row-input {
            flex: 2;
            justify-content: center;
            align-content: center;
            align-items: center;
        }
        .Popup-form-row-input{
            flex: 2;
            justify-content: center;
            align-content: center;
            align-items: center;
        }
        .form-row-Button {
            flex: 1;
            justify-content: center;
            align-content: center;
            align-items: center;
        }

        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
         .radioButton label{
             margin-left: 5px;
             color :BLACK;
             font-weight:bold;
         }
        .VerifiedLabel {
            padding-right: 10px;
            flex: 1;
            font-size: 15px;
            padding: 10px;
            width: 50%;
            letter-spacing: .09em;
            color: green;
            font-weight: 800;
        }

        .NotVerifiedLabel {
            padding-right: 10px;
            flex: 1;
            font-size: 20px;
            padding: 10px;
            width: 50%;
            font-weight: 300;
            letter-spacing: .09em;
            color: red;
            font-weight: 800;
        }

        .form-tooltip {
            display: block;
            visibility: hidden;
            overflow: hidden;
            box-sizing: border-box;
            height: 0;
            margin-bottom: -8px;
            cursor: help;
            animation-name: fold;
            animation-duration: 500ms;
            animation-timing-function: ease-in;
            animation-direction: reverse;
        }


            .PopupPanel .flex-container {
                margin-bottom: 2%
            }

                .PopupPanel .flex-container .PopupPanel {
                    margin-bottom: 2%
                }

        .PopupPanel .flex-container .form-row{
            padding:0;
        }
        
         .MobileCountDown{
                font-weight:500;
                font-size: 35px;
                text-align: center;
                justify-content: center;
            }
    </style>
    <style>
        .ui-tooltip {
            font-size: 10pt;
            font-family:sans-serif;
            height: 25px;
            padding: 3px;
            padding-top: 0px;
            padding-bottom: 5px;
            background-color: aqua;
        }

        .ContantMain {
            margin-top: 0;
        }

        .CountDown {
            text-align: center;
            font-size: 35px;
            margin-top: 0px;
            margin-top: 0;
            z-index: -1;
            display: flex;
            font-weight: 500;
        }
        input::-webkit-input-placeholder { /* WebKit browsers */
        
        opacity: .5;
    }
         input:-moz-placeholder { /* Mozilla Firefox 4 to 18 */
        opacity: .5;
    }
    input::-moz-placeholder { /* Mozilla Firefox 19+ */
        opacity: .5;
    }
    input:-ms-input-placeholder { /* Internet Explorer 10+ */
        opacity: .5;
    }
         @media (max-width: 768px){
            .PopupPanel {
                Width: 80%;
                Height: 70%;
            }


            .NeumorphicDiv {
                width: 90%;
                padding: 5px;
                margin:5px;
            }

            .form-row-label {
                font-size: 9px;
                padding-right: 0px;
                /*background-color: antiquewhite;*/
            }

            .MobileCountDown {
                text-align: center;
                margin-top: 0px;
                margin-top: 0;
                z-index: -1;
                 font-weight: 500;
                font-size: 22px;
                text-align: center;
                /*position: absolute;*/
                /*display: flex;*/
            }

            .NeoButton{
                width:95%;
                align-content:center;
            }
            .form-row-label{
                align-content:center;
                text-align:center;
                font-size:16px;
            }
            .form-row-label-Heading{
                /*text-align:center;
                font-size:20px;
                align-items:center;
                align-content:center;*/
                width:90%;
                align-content:center;
                text-align:center;
                font-size:16px;
            }
            .form-row-input {
                width:100%;
                text-align: center;
                 align-items:center;
                align-content:center;
            }

            .form-row-Button {
                width:95%;
                align-items:center;
                align-content:center;
                text-align:center;
            }

            .flex-container {
                margin-top: 5px;
                align-items:center;
                align-content:center;
            }
            .NeoTextBox{
                width: 95%;
            }
            .NeoTextBox:focus {
                width: 100%;
                -webkit-transition: width .35s ease-in-out;
                transition: width .35s ease-in-out;
            }

            .DisplayError {
                font-size: 114px;
            }

            .form-row {
                padding: 2px;
                flex-wrap: wrap;
                flex-direction: column;
                align-content:center;
                /*width: 95%;*/
                margin:2px;
            }
        }
    </style>
    <!-- fETCH cOLLEGE dATA -->
     <script type="text/javascript">
            function AttactEvent() {
                var txt = document.getElementById("<%=txtCollegeCode.ClientID %>");
                txt.setAttribute("onkeyup", txt.getAttribute("onchange"));
                txt.setAttribute("onchange", "");
            }
            window.onload = function () {
                AttactEvent();
                var prm = Sys.WebForms.PageRequestManager.getInstance();
                if (prm != null) {
                    prm.add_endRequest(function (sender, e) {
                        if (sender._postBackSettings.panelsToUpdate != null) {
                            AttactEvent();
                        }
                    });
                }
            };

        </script>
        <script type="text/javascript">
            function SetFocus(id) {
                window.onload = function () {
                    var ctl = document.getElementById(id);
                    ctl.focus();
                    ctl.value = ctl.value;
                }
            }
        </script>
        <script type="text/javascript">
            function setCursorPosition(element, pos) {
                
                var ctrl = document.getElementById(element);

                if (ctrl.setSelectionRange) {
                    ctrl.focus();
                    ctrl.setSelectionRange(pos, pos);
                    //document.getElementById("txtCollegeName").value = CName;
                //document.getElementById("txtCollegeAddress").value = pos;
                }
                else if (ctrl.createTextRange) {
                    var range = ctrl.createTextRange();
                    range.collapse(true);
                    range.moveEnd('character', pos);
                    range.moveStart('character', pos);
                    range.select();
                    //document.getElementById("txtCollegeName").value = CName;
                //document.getElementById("txtCollegeAddress").value = pos;
                }
            }
        </script>
    <!--Countdown -->
    <script>
        // Set the date we're counting down to
        var countDownDate = new Date();
        countDownDate.setMinutes(countDownDate.getMinutes() + 20);
        // Update the count down every 1 second
        var x = setInterval(function () {

            // Get today's date and time
            var now = new Date().getTime();

            // Find the distance between now and the count down date
            var distance = countDownDate - now;

            // Time calculations for days, hours, minutes and seconds
            var days = Math.floor(distance / (1000 * 60 * 60 * 24));
            var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
            var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
            var seconds = Math.floor((distance % (1000 * 60)) / 1000);

            // Output the result in an element with id="demo"
            document.getElementById("CountDown").innerHTML = "" + minutes + "m " + seconds + "s ";

            // If the count down is over, write some text 
            if (minutes == 0 && seconds < 20) {
                clearInterval(x);
                document.getElementById("CountDown").innerHTML = "EXPIRING ! ! !";
            }
        }, 1000);
    </script>
    <script type="text/javascript">
        function SessionExpireAlert(timeout) {
            var seconds = timeout / 1000;
            var Minutes = timeout % 60;
            document.getElementsByName("MinutesIdle").innerHTML = Minutes;
            //document.getElementsByName("secondsIdle").innerHTML = seconds;
            document.getElementsByName("seconds").innerHTML = seconds;
            setInterval(function () {
                seconds--;
                document.getElementById("seconds").innerHTML = seconds;
                document.getElementById("secondsIdle").innerHTML = seconds;
                //document.getElementById("MinutesIdle").innerHTML = Minutes;
            }, 1000);
            setTimeout(function () {
                //Show Popup before 20 seconds of timeout.
                $find("mpeTimeout").show();
            }, timeout - 20 * 1000);
            setTimeout(function () {
                window.location = "/Default.aspx";
                //PageMethods.AlertFromServer();
            }, timeout);
        };
        function ResetSession() {
            //Redirect to refresh Session.
            window.location = window.location.href;
        }
        function SessionExpireSoon() {
            //Redirect to refresh Session.

            document.getElementById("lblCountDownHeader").style.display = "none";
            document.getElementById("CountDown").innerHTML = "Session Will Expire Now";
        }

    </script>
    <!-- Onload Disable -->
    <script type="text/javascript">

        function Disable() {
           // document.getElementById("btnGetOTP").disabled = true;
            document.getElementById("btnVerifyOTP").disabled = true;
            document.getElementById("btnVerifyRDNumber").disabled = true;
            document.getElementById("btnGetBankDetails").disabled = true;
            document.getElementById("btnAadhaarGetOTP").disabled = true;
        }
    </script>
    <!--Bank Check-->
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtAccountNumber').keyup(function () {
                var AccountNumber = $(this).val();
                if (AccountNumber.length > 8) {
                    BankDetailsVerifyEnable()
                }

            });
        });
        $(document).ready(function () {
            $('#txtIFSCCode').keyup(function () {
                var IFSCCode = $(this).val();
                if (IFSCCode.length > 10) {
                    BankDetailsVerifyEnable()
                }

            });
        });
        function BankDetailsVerifyEnable() {
            if ($('#txtAccountNumber').length > 8 && $('#txtIFSCCode').length >= 10) {
                document.getElementById("btnGetBankDetails").disabled = false;
            }
        }
    </script>
    <!--Allow Numerical Value-->
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
    <!--Bank Details Popup -->
    <script type="text/javascript">

        $(document).ready(function () {
            BlockUI("<%=PnlBankDetails.ClientID %>");
            $.blockUI.defaults.css = {};
        });
        function BankDetailsHidePopup() {
            $find("BankDetailsPopup").hide();
            return false;
        }
    </script>
    <!--RD Number Popup -->
    <script type="text/javascript">

        $(document).ready(function () {
            BlockUI("<%=PnlCasteCertificateAR.ClientID %>");
            $.blockUI.defaults.css = {};
        });
        function CasteCertificatePopup() {
            $find("CasteCertificatePopup").hide();
            return false;
        }
    </script>
    <!--Other Details Popup -->
    <script type="text/javascript">

        $(document).ready(function () {
            BlockUI("<%=PnlOtherDetails.ClientID %>");
            $.blockUI.defaults.css = {};
        });
        function OtherDetailsPopup() {
            $find("OtherDetailsPopup").hide();
            return false;
        }
    </script>
    <!--Submit Application Popup -->
    <script type="text/javascript">

        $(document).ready(function () {
            BlockUI("<%=PnlSubmitApplication.ClientID %>");
            $.blockUI.defaults.css = {};
        });
        function SubmitApplicationPopup() {
            $find("SubmitApplicationPopup").hide();
            return false;
        }
    </script>
    <!--Display Wait Popup -->
    <script type="text/javascript">

        $(document).ready(function () {
            BlockUI("<%=PnlDisplayWait.ClientID %>");
            $.blockUI.defaults.css = {};
        });
        function DisplayWaitPopup() {
            $find("DisplayWaitPopup").hide();
            return false;
        }
    </script>
     <!--Aadhaar Application Popup -->
    <script type="text/javascript">

        $(document).ready(function () {
            BlockUI("<%=PnlAadhaarDetails.ClientID %>");
            $.blockUI.defaults.css = {};
        });
        function AadhaarPopup() {
            $find("AadhaarPopup").hide();
            return false;
        }
    </script>
    <!--Tool Tip -->
    <script type="text/javascript">
        $(function () {
            $(document).tooltip({
                track: true
            });
        });
    </script>

    <script type="text/javascript">
        function CheckNumber(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && ((charCode >= 48 && charCode <= 57) || charCode == 46))
                return true;
            else {
                alert('Please Enter Numeric values.');
                return false;
            }
        }
    </script>
    <!--RD Number Verify -->

    <script type="text/javascript">
        function CheckNumber(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && ((charCode >= 48 && charCode <= 57) || charCode == 46))
                return true;
            else {
                alert('Please Enter Numeric values.');
                return false;
            }
        }


        function CheckRDNumber() {
            $('#txtRDNumber').keyup(function () {
                var RDNumber = $(this).val();
                if (RDNumber.length != 0) {
                    if (RDNumber.length == 15) {
                        if (RDNumber.match(/RD\d{13}/i)) {
                            //$.ajax({
                            //    url: '../Arivu/ArivuAadharCheck.asmx/CheckARAadhar',
                            //    method: 'post',
                            //    data: { NewAadhar: RDNumber, SPChk: "spArivuRDNumExist", Param: "@NewRDNum" },
                            //    dataType: 'json',
                            //    success: function (data) {
                            //        var divElement = $('#divRDNumChkError');
                            //        if (data.AadharNumInUse) {
                            //            divElement.text('You already avail the loan in 2019-20');
                            //            divElement.css('color', '#7b0000');
                            //            document.getElementById("btnVerifyRDNumber").focus();
                            //        }
                            //        else {
                            //            divElement.text('Eligible for Loan')
                            //            divElement.css('color', 'green');
                            //            document.getElementById("btnVerifyRDNumber").disabled = false;
                            //        }
                            //    },
                            //    error: function (err) {
                            //        alert(err);
                            //    }
                            //});
                             var divElement = $('#divRDNumChkError');
                            divElement.text('RD Number Must be in RD0000000000000 format')
                            divElement.css('color', '#7b0000');
                            document.getElementById("btnVerifyRDNumber").disabled = false;
                        }
                        else {
                            var divElement = $('#divRDNumChkError');
                            divElement.text('RD Number Must be in RD0000000000000 format')
                            divElement.css('color', '#7b0000');
                            document.getElementById("btnVerifyRDNumber").disabled = true;
                        }
                    }
                    else {
                        var divElement = $('#divRDNumChkError');
                        divElement.text('RD Number Must be 15 Characters')
                        divElement.css('color', '#7b0000');
                        document.getElementById("btnVerifyRDNumber").disabled = true;
                    }
                }
                else {
                    var divElement = $('#divRDNumChkError');
                    divElement.text('RD Number Must be Enter')
                    divElement.css('color', '#7b0000');
                    document.getElementById("btnVerifyRDNumber").disabled = true;
                }
            });
        }

    </script>
    <!--MobileNumber Verify -->
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
    <!--MobileNumber Verify -->
    <script type="text/javascript">
       

        function CheckAadhaarNumber(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (((charCode >= 48 && charCode <= 57)|| (e.keyCode >= 96 && e.keyCode <= 105)) || charCode == 46)) {
                $('#txtAadhaarNumber').keyup(function () {
                    var NewAadhar = $(this).val();
                    if (NewAadhar.length != 0) {
                        if (NewAadhar.length == 12) {
                            $.ajax({
                                url: '../Arivu/ArivuAadharCheck.asmx/CheckARAadhar',
                                method: 'post',
                                data: { NewAadhar: NewAadhar, SPChk: "spAadharNumValidate", Param: "@AadharNumChk" },
                                dataType: 'json',
                                success: function (data) {
                                    var divElement = $('#divAadhaarChkError');
                                    if (data.AadharNumInUse) {
                                        divElement.text('Valid Aadhaar Number');
                                        divElement.css('color', '#25b13d');
                                        document.getElementById("btnAadhaarGetOTP").disabled = false;
                                        document.getElementById("btnAadhaarGetOTP").focus();
                                    }
                                    else {
                                        divElement.text(data.NewAadhar + ' is Invalid Aadhaar')
                                        divElement.css('color', '#7b0000');
                                        
                                    }
                                },
                                error: function (err) {
                                    alert(err);
                                }
                            });
                        }
                        else if(NewAadhar.length > 12) {
                            var divElement = $('#divAadhaarChkError');
                            divElement.text('Enter 12 Digit Aadhaar Number')
                                        divElement.css('color', '#7b0000');
                        }
                        else {
                            var divElement = $('#divAadhaarChkError');
                            divElement.text('Enter 12 Digit Aadhaar Number')
                                        divElement.css('color', '#7b0000');
                        }
                    }
                    else {
                        var divElement = $('#divAadhaarChkError');
                        divElement.text('Aadhaar Number to be Entered')
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
    <!--Check OTP -->
    <script type="text/javascript">
        function CheckOTP(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (((charCode >= 48 && charCode <= 57)|| (e.keyCode >= 96 && e.keyCode <= 105)) || charCode == 46)) {
                $('#txtOTP').keyup(function () {
                    var OTP = $(this).val();
                    if (OTP.length == 6) {
                        document.getElementById("btnVerifyOTP").disabled = false;
                        document.getElementById("btnVerifyOTP").focus();
                        var divElement = $('#divOTPChkError');
                        divElement.text('Submit OTP')
                    }
                    else {
                        var divElement = $('#divOTPChkError');
                        divElement.text('ENTER 6 DIGIT OTP')
                        divElement.css('color', '#7b0000');
                        document.getElementById("btnVerifyOTP").disabled = true;
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
<body onload="Disable()"> <%--  onload="Disable()" --%>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:PostBackTrigger ControlID="btnPreviewSubmitApplication"  />
                <asp:PostBackTrigger ControlID = "btnUploadCETAdmission" />
                <asp:PostBackTrigger ControlID = "btnUploadPrevMarksCard" />
                <asp:PostBackTrigger ControlID = "btnUploadStudyCertificate" />
                <asp:PostBackTrigger ControlID = "btnUploadFeesStructure" />
                <asp:PostBackTrigger ControlID = "btnUploadCollegeHostel" />
                <asp:AsyncPostBackTrigger ControlID="rbCollegeHostelYes" />
                <asp:AsyncPostBackTrigger ControlID="rbCollegeHostelNo" />
                <asp:AsyncPostBackTrigger ControlID="txtCollegeCode" EventName="TextChanged" />
            </Triggers>
            <ContentTemplate>
               <div class="MobileCountDown form-row">
                    <asp:Label runat="server" ID="lblCountDownHeader"  Text="Time Left to Submit : "></asp:Label><p style="color: red" id="CountDown"></p>
                </div>
                <%--Main Display--%>
                <div class="flex-container ContantMain" id="divSEApplicationMail" runat="server">
                    <div class="NeumorphicDiv">
                        <div class="form-row">
                            <div class="form-row-label-Heading" style=" border-radius: 15px;">
                                <asp:Label ID="Label5" class="" runat="server" Text="Arivu Educational loan application"></asp:Label>
                            </div>
                        </div>
                        <%--Mobile Number--%>
                        <div class="form-row">
                            <div class="form-row-label">
                                <asp:Label ID="Label26" class="" runat="server">Aadhaar Number<span style="color:#a30000"> *</span><br />ಆಧಾರ್ ಸಂಖ್ಯೆ</asp:Label><br />
                                <%--<asp:Label runat="server" Style="font-size: 8px; color: red;">(As Per Aadhar)</asp:Label>--%>
                            </div>
                            <%-- TODO onpaste="return false" AutoCompleteType="Disabled" --%>
                            <div class="form-row-input">
                                <asp:TextBox ID="txtAadhaarNumber" CssClass="NeoTextBox" runat="server" TextMode="Number" MaxLength="12" placeholder="Aadhaar Number" onkeypress="return CheckAadhaarNumber(event)" onpaste="return false" AutoCompleteType="Disabled"></asp:TextBox>
                                <div id="divAadhaarChkError" class="DisplayError" style="font-size:18px; font-weight: bold;color:#7b0000"></div>
                            </div>
                            <div class="form-row-Botton" id="divMovileNumberStatus" runat="server">
                                <asp:Button ID="btnAadhaarGetOTP" runat="server" CssClass="NeoButton"  OnClick="btnAadhaarGetOTP_Click" Text="Get OTP" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
                            </div>
                        </div>
                        <%--OTP Verify--%>
                        <div id="divMobileOTP" runat="server" visible="false" class="form-row">
                            <div class="form-row-label">
                                <asp:Label ID="Label1" class="" runat="server">OTP<br />ಒಟಿಪಿ</asp:Label>
                            </div>
                            <div class="form-row-input">
                                <asp:TextBox ID="txtOTP" CssClass="NeoTextBox" runat="server" MaxLength="8" placeholder="OTP" onkeypress="return CheckOTP(event)" onpaste="return false" AutoCompleteType="Disabled"></asp:TextBox>
                                <div id="divOTPChkError" class="DisplayError" style="font-size:18px; font-weight: bold;color:#7b0000"></div>
                            </div>
                            <div class="form-row-Botton">
                                <asp:Button ID="btnVerifyAadhaarOTP" runat="server" CssClass="NeoButton" OnClick="btnVerifyAadhaarOTP_Click" Text="Verify" onpaste="return false" AutoCompleteType="Disabled" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
                            </div>
                        </div>
                        <%--Button to Display RD--%>
                        <div id="divButtonToRDNum" runat="server" visible="true" class="form-row">
                            <div class="form-row-label">
                            </div>
                            <div class="form-row-input">
                                <asp:Button ID="btnNextDisplayRDNum" runat="server" CssClass="NeoButton"  OnClick="btnNextDisplayRDNum_Click" Text="Confirm and Continue" onpaste="return false" AutoCompleteType="Disabled" />
                            </div>
                            <div class="form-row-Botton">
                            </div>
                        </div>
                        <%--RD Number--%>
                        <div id="divRDNumber" runat="server" visible="false" class="form-row">
                            <div class="form-row-label">
                                <asp:Label ID="Label10" class="" runat="server">RD Number(Form - G)<span style="color:#a30000"> *</span><br />ಆರ್.ಡಿ ಸಂಖ್ಯೆ(ನಮೂನೆ - ಜಿ)</asp:Label>
                            </div>
                            <div class="form-row-input">
                                <asp:TextBox ID="txtRDNumber" CssClass="NeoTextBox" runat="server"  placeholder="RD Number" style="text-transform:uppercase" MaxLength="15" onkeypress="CheckRDNumber()" onpaste="return false" AutoCompleteType="Disabled"></asp:TextBox>
                                <div id="divRDNumChkError" runat="server" class="DisplayError" style="font-size:18px; font-weight: bold;color:#7b0000"></div>
                            </div>
                            <div class="form-row-Botton">
                                <asp:Button ID="btnVerifyRDNumber" runat="server" CssClass="NeoButton" OnClick="btnVerifyRDNumber_Click" Text="Verify" onpaste="return false" AutoCompleteType="Disabled" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
                                <asp:Button ID="btnViewRDNumber" runat="server" Visible="false" CssClass="NeoButton" OnClick="btnViewRDNumber_Click" Text="View" />
                                <asp:Label ID="lblRDNumberVerified" Visible="false" runat="server" Text=" Verified" CssClass=" fa fa-check VerifiedLabel"></asp:Label>
                            </div>
                        </div>
                        <%--Button to Bank Details THIS SECTION HAS TO BE REMOVED AND SHOULD BE ADDED IN Button to College Details--%>
                        <div id="divButtonBankDetails" runat="server" visible="false" class="form-row"><%--MAKING THIS TRUE--%>
                            <div class="form-row-label">
                            </div>
                            <div class="form-row-input">
                                <asp:Button ID="btnNextChangeRDNumber" runat="server" CssClass="NeoButton"  OnClick="btnNextChangeRDNumber_Click" Text="Modify" onpaste="return false" AutoCompleteType="Disabled" />
                                <asp:Button ID="btnNextDisplayBankDetails" runat="server" CssClass="NeoButton"  OnClick="btnNextDisplayBankDetails_Click" Text="Confirm and Continue" onpaste="return false" AutoCompleteType="Disabled" />
                            </div>
                            <div class="form-row-Botton">
                            </div>
                        </div>


                        <%--Bank Details--%>
                       <div id="divBankDetails" class="form-row" runat="server" visible="false"> <%--MAKING THIS TRUE --%>
                            <div class="form-row-label">
                                <asp:Label ID="Label12" class="" runat="server">Bank Details<span style="color:#a30000"> *</span><br />ಬ್ಯಾಂಕ್ ವಿವರಗಳು</asp:Label><br />
                                <asp:Label ID="Label56" class="" runat="server"><span style="color:#7b0000">ಕರ್ನಾಟಕ ರಾಜ್ಯಕ್ಕೆ ಸಂಬಂಧ ಪಟ್ಟ ಬ್ಯಾಂಕ್ ಖಾತೆಯ ವಿವರ</span></asp:Label><br />
                            </div>
                            <div class="form-row-input">
                                <asp:TextBox ID="txtAccountNumber" CssClass="NeoTextBox" runat="server" MaxLength="15" Placeholder="Account Number" onkeypress="return Numeric(event)" onpaste="return false" AutoCompleteType="Disabled"></asp:TextBox>
                                <asp:TextBox ID="txtIFSCCode" CssClass="NeoTextBox" runat="server" MaxLength="15" Placeholder="IFSC Code" onpaste="return false" AutoCompleteType="Disabled"></asp:TextBox>
                                <div id="divBankError" class="DisplayError" runat="server" style="font-size:18px; font-weight: bold;color:#7b0000"></div>
                                <asp:Label ID="lblBankError" class="DisplayError" runat="server" style="font-size:18px; font-weight: bold;color:#7b0000"></asp:Label>
                            </div>
                            <div class="form-row-Botton" id="div1" runat="server">
                                <asp:Button ID="btnGetBankDetails" runat="server" CssClass="NeoButton" OnClick="btnGetBankDetails_Click" Text="Verify" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
                                <asp:Button ID="btnViewBankDetails" runat="server" Visible="false" CssClass="NeoButton" OnClick="btnViewBankDetails_Click" Text="View" />
                                <div id="divBankVerifyStatus" class="DisplayError" runat="server" style="font-size:18px; font-weight: bold;color:#7b0000"></div>
                            </div>
                        </div>--%>
                         <%--Button to College Details--%>
                        <div id="divButtonToCollegeDetails" runat="server" visible="false" class="form-row">
                            <div class="form-row-label">
                            </div>
                            <div class="form-row-input">
                                <asp:Button ID="btnNextShowRDNumber1" runat="server" CssClass="NeoButton" Visible="false"  OnClick="btnNextShowRDNumber_Click" Text="Back" onpaste="return false" AutoCompleteType="Disabled" />
                                <asp:Button ID="btnNextChangeBankDetails" runat="server" CssClass="NeoButton"  OnClick="btnNextChangeBankDetails_Click" Text="Modify" onpaste="return false" AutoCompleteType="Disabled" />
                                <asp:Button ID="btnNextDisplayCollegeDetails" runat="server" CssClass="NeoButton"  OnClick="btnNextDisplayCollegeDetails_Click" Text="Confirm and Continue" onpaste="return false" AutoCompleteType="Disabled" />
                            </div>
                            <div class="form-row-Botton">
                            </div>
                        </div>
                        
                        <%--Collage Details--%>
                        <div id="divCollegeDetails" runat="server" visible="false" class="form-row">
                            <div class="form-row-label">
                                <asp:Label ID="Label37" class="" runat="server">Educational Details<span style="color:#a30000">*</span><br />ಶೈಕ್ಷಣಿಕ ವಿವರಗಳು</asp:Label>
                            </div>
                            <div class="form-row-label">
                                <asp:Label ID="Label58" class="" runat="server" Text=""></asp:Label>
                                <div id="divOTPChkError11" class="DisplayError" style="font-size:18px; font-weight: bold;color:#7b0000"></div>
                            </div>
                            <div class="form-row-Botton">
                                <asp:Button ID="btnCollegeDetailsUpdate" runat="server" Visible="false" CssClass="NeoButton" OnClick="btnCollegeDetailsUpdate_Click" Text="Confirm and Continue" />
                                <asp:Button ID="btnViewCollegeDetails" runat="server" Visible="true" CssClass="NeoButton" OnClick="btnViewCollegeDetails_Click" Text="View" />
                            </div>
                        </div>
                        <%-- Fill College Details--%>
                        <div class="" id="divCollegeDetailsFill" runat="server" visible="false">
                            <div class="">
                                <div class="form-row" style="justify-content: center">
                                    <div class="Popup-row-label-Heading">
                                        <asp:Label ID="Label60" class="" Style=" margin-top: 30px" runat="server" Text="Educational Details"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-row-label" style="flex:2" >
                                        <asp:Label ID="Label59" runat="server">College Code<span style="color:#a30000"> *</span><br /> ಸಂಖ್ಯೆ</asp:Label>
                                    </div>
                                    <div class="form-row-input">
                                        <asp:TextBox ID="txtCollegeCode" runat="server" CssClass="NeoTextBox" OnTextChanged="txtCollegeCode_TextChanged" AutoPostBack="true" onpaste="return false" AutoCompleteType="Disabled"></asp:TextBox>
                                        <asp:Label ID="lblCollegeCodeError" runat="server" class="DisplayError" Style="font-size: 18px; font-weight: bold; color: #7b0000"></asp:Label>
                                        
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-row-label" style="flex:2" >
                                        <asp:Label ID="Label92" runat="server">CET Admission Ticket Number<span style="color:#a30000"> *</span><br />ಸಿಇಟಿ ಪ್ರವೇಶ ಪತ್ರ ಸಂಖ್ಯೆ</asp:Label>
                                    </div>
                                    <div class="form-row-input">
                                        <asp:TextBox ID="txtCETAdmTicNum" CssClass="NeoTextBox"  placeholder="CET Admission Ticket"  runat="server" onpaste="return false" AutoCompleteType="Disabled"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-row-label"  style="flex:2" >
                                        <asp:Label ID="Label102" runat="server">CET Application Number<span style="color:#a30000"> *</span><br />ಸಿಇಟಿ ಅರ್ಜಿ ಸಂಖ್ಯೆ</asp:Label>
                                    </div>
                                    <div class="form-row-input">
                                        <asp:TextBox ID="txtCETAppNum" CssClass="NeoTextBox"  placeholder="CET Application Number" runat="server" onpaste="return false" AutoCompleteType="Disabled"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-row">
                                    <div class="form-row-label"  style="flex:2" >
                                        <asp:Label ID="Label61" runat="server">College Name<span style="color:#a30000"> *</span><br />ವ್ಯಾಸಂಗ ಮಾಡುತ್ತಿರುವ ಕಾಲೇಜಿನ ಹೆಸರು</asp:Label>
                                    </div>
                                    <div class="form-row-input">
                                        <asp:TextBox ID="txtCollegeName" CssClass="NeoTextBox"  placeholder="College Name" runat="server" onpaste="return false" AutoCompleteType="Disabled"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-row-label"  style="flex:2" >
                                        <asp:Label ID="Label66" runat="server">College Address<span style="color:#a30000"> *</span><br />ಕಾಲೇಜಿನ ವಿಳಾಸ</asp:Label>
                                    </div>
                                    <div class="form-row-input">
                                        <asp:TextBox ID="txtClgAddress" CssClass="NeoTextBox"  placeholder="College Address" style="height:50px" TextMode="MultiLine" runat="server" onpaste="return false" AutoCompleteType="Disabled"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-row">
                                    <div class="form-row-label"  style="flex:2" >
                                        <asp:Label ID="Label62" runat="server">Required Loan Amount (Complete Course)<span style="color:#a30000"> *</span><br />ಅಗತ್ಯವಿರುವ ಸಾಲದ ಮೊತ್ತ (ಸಂಪೂರ್ಣ ಕೋರ್ಸ್‌ಗೆ)</asp:Label>
                                    </div>
                                    <div class="form-row-input">
                                        <asp:TextBox ID="txtRequierdLoanAmount" CssClass="NeoTextBox" MaxLength="6" placeholder="Required Loan Amount" runat="server" TextMode="Number" onpaste="return false" AutoCompleteType="Disabled"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-row-label"  style="flex:2" >
                                        <asp:Label ID="Label65" runat="server">Marks Obtained in Previous Year<span style="color:#a30000"> *</span><br />ಹಿಂದಿನ ವರ್ಷದಲ್ಲಿ ಪಡೆದ ಅಂಕಗಳು</asp:Label>
                                    </div>
                                    <div class="form-row-input">
                                        <asp:TextBox ID="txtPreviousMarks" CssClass="NeoTextBox"  placeholder="Previous Year Marks" runat="server" TextMode="Number" onpaste="return false" AutoCompleteType="Disabled"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-row-label"  style="flex:2" >
                                        <asp:Label ID="Label63" runat="server">Course<span style="color:#a30000"> *</span><br />ಕೋರ್ಸ್</asp:Label>
                                    </div>
                                    <div class="form-row-input">
                                        <asp:DropDownList ID="drpCourse" Class="rowMargin txtcolor text-uppercase form-control NeuoDropdown" style="width: 90%;padding: 2px; margin: 10px" runat="server" ClientIDMode="Static" Visible="True">
                                         <asp:ListItem style="color:red;font-size:large;font-weight: bold;" Value="0">--SELECT--</asp:ListItem>
                                            <asp:ListItem style="color:red;font-size:large;font-weight: bold;" Value="0">UG</asp:ListItem>
                                            <asp:ListItem Value="Engineering">Engineering(B.E)</asp:ListItem>
                                            <asp:ListItem Value="Medical">Medical</asp:ListItem>
                                            <asp:ListItem Value="DentalISMH">Dental & ISMH</asp:ListItem>
                                            <asp:ListItem Value="FarmScience">Farm Science</asp:ListItem>
                                            <asp:ListItem Value="Pharmacy">Pharmacy</asp:ListItem>
                                            <asp:ListItem style="color:red;font-size:large;font-weight: bold;" Value="0">PG</asp:ListItem>
                                            <asp:ListItem Value="Engineering">Engineering(M.E)</asp:ListItem>
                                            <asp:ListItem Value="M'Tech">M'tech</asp:ListItem>
                                            <asp:ListItem Value="PGDM">PGDM</asp:ListItem>
                                            <asp:ListItem style="color:red;font-size:large;font-weight: bold;" Value="0">Ph.D</asp:ListItem>
                                            <asp:ListItem Value="PHD">Technical Ph.D</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-row-label"  style="flex:2" >
                                        <asp:Label ID="Label64" runat="server">Year<span style="color:#a30000"> *</span><br />ವರ್ಷ</asp:Label>
                                    </div>
                                    <div class="form-row-input">
                                        <asp:DropDownList ID="drpYear" Class="rowMargin txtcolor text-uppercase form-control NeuoDropdown" runat="server" style="width: 90%;padding: 2px; margin: 10px" ClientIDMode="Static" Visible="True">
                                            <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                                            <asp:ListItem Value="1st Year">1st Year</asp:ListItem>
                                            <asp:ListItem Value="2nd Year">2nd Year</asp:ListItem>
                                            <asp:ListItem Value="3rd Year">3rd Year</asp:ListItem>
                                            <asp:ListItem Value="4th Year">4th Year</asp:ListItem>
                                            <asp:ListItem Value="5th Year">5th Year</asp:ListItem>
                                            <asp:ListItem Value="6th Year">6th Year</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-row-label"  style="flex:2" >
                                        <asp:Label ID="Label34" runat="server">Are You Staying in College Hostel?<span style="color:#a30000"> *</span><br />ಕಾಲೇಜು ವಿದ್ಯಾರ್ಥಿ ನಿಲಯದಲ್ಲಿ ವಾಸವಿದ್ದೀರಾ?</asp:Label>
                                    </div>
                                    <div class="form-row-input">
                                         <asp:RadioButton ID="rbCollegeHostelYes" runat="server" Class="radioButton" GroupName="Widow" Text="Yes" AutoPostBack="true" OnCheckedChanged="rbCollegeHostel_CheckChanged"  />
                                        <asp:RadioButton ID="rbCollegeHostelNo" runat="server" Class="radioButton" GroupName="Widow" Text="No" AutoPostBack="true" OnCheckedChanged="rbCollegeHostel_CheckChanged" />

                                    </div>
                                </div>
                               
                                
                                <div class="form-row" style="justify-content: center">
                                    <div class="Popup-row-label-Heading">
                                        <asp:Label ID="Label51" class="" Style=" margin-top: 30px" runat="server" Text="Documents to be Uploaded"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-row-label" style="flex: 2;">
                                        <asp:Label ID="Label69" runat="server">CET Admission Ticket<span style="color:#a30000"> *</span><br />ಸಿಇಟಿ ಪ್ರವೇಶ ಪತ್ರ<br /></asp:Label>
                                    </div>
                                    <div class="form-row-input">
                                        <div class="input-group">
                                            <div class="custom-file">
                                                <asp:FileUpload ID="FileCETAdmission" class="custom-file-input" runat="server" />
                                                <asp:Label ID="lblFileCETAdmission" runat="server" class="custom-file-label"></asp:Label>
                                            </div>
                                            <div class="input-group-append">
                                                <asp:Button ID="btnUploadCETAdmission" runat="server" Visible="true" CssClass="btn btn-secondary" Text="Upload" OnClick="btnUploadCETAdmission_Click" />
                                            </div>
                                        </div>
                                        <span  style="font-size:18px; font-weight: bold;color:#7b0000">Less then 500 KB</span>
                                    </div>
                                </div>
                               <%-- <div class="form-row">
                                    <div class="form-row-label" style="flex: 2;"></div>
                                    <div class="form-row-input">
                                        <div class="input-group">
                                            <div class="custom-file">
                                                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="custom-file-input" />
                                                <label class="custom-file-label"></label>
                                            </div>
                                            <div class="input-group-append">
                                                <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-secondary" />
                                            </div>
                                        </div>
                                    </div>
                                </div>--%>
                                <div class="form-row">
                                    <div class="form-row-label" style="flex: 2;">
                                        <asp:Label ID="Label68" runat="server">Previous Year Marks Card<span style="color:#a30000"> *</span><br />ಹಿಂದಿನ ವರ್ಷದ ಅಂಕ ಪಟ್ಟಿ<br /></asp:Label>
                                    </div>
                                    <div class="form-row-input">
                                        <div class="input-group">
                                            <div class="custom-file">
                                                <asp:FileUpload ID="FilePrevMarksCard" class="custom-file-input" runat="server" />
                                                <asp:Label ID="lblFilePrevMarksCard" runat="server" class="custom-file-label"></asp:Label>
                                            </div>
                                            <div class="input-group-append">
                                                <asp:Button ID="btnUploadPrevMarksCard" runat="server" Visible="true" CssClass="btn btn-secondary" Text="Upload" OnClick="btnUploadPrevMarksCard_Click" />
                                            </div>
                                        </div>
                                        <span style="font-size:18px; font-weight: bold;color:#7b0000">Less then 500 KB</span>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-row-label" style="flex: 2;">
                                        <asp:Label ID="Label67" runat="server">Current Year Study Certificate<span style="color:#a30000"> *</span><br />ಪ್ರಸ್ತುತ ವರ್ಷದ ವ್ಯಾಸಂಗ ಪ್ರಮಾಣಪತ್ರ</asp:Label>
                                    </div>
                                    <div class="form-row-input">
                                        <div class="input-group">
                                            <div class="custom-file">
                                                <asp:FileUpload ID="FileStudyCertificate" class="custom-file-input" runat="server" />
                                                <asp:Label ID="lblFileStudyCertificate" runat="server" class="custom-file-label"></asp:Label>
                                            </div>
                                            <div class="input-group-append">
                                                <asp:Button ID="btnUploadStudyCertificate" runat="server" Visible="true" CssClass="btn btn-secondary" Text="Upload" OnClick="btnUploadStudyCertificate_Click" />
                                            </div>
                                        </div>
                                        <span style="font-size:18px; font-weight: bold;color:#7b0000">Less then 500 KB</span>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-row-label" style="flex: 2;">
                                        <asp:Label ID="Label72" runat="server">Fee Structure (Complete Course)<span style="color:#a30000"> *</span><br />ಶುಲ್ಕದ ವಿವರಗಳು (ಸಂಪೂರ್ಣ ಕೋರ್ಸ್‌ಗೆ)</asp:Label>
                                    </div>
                                    <div class="form-row-input">
                                        <div class="input-group">
                                            <div class="custom-file">
                                                <asp:FileUpload ID="FileFeesStructure" class="custom-file-input" runat="server" />
                                                <asp:Label ID="lblFileFeesStructure" runat="server" class="custom-file-label"></asp:Label>
                                            </div>
                                            <div class="input-group-append">
                                                <asp:Button ID="btnUploadFeesStructure" runat="server" Visible="true" CssClass="btn btn-secondary" Text="Upload" OnClick="btnUploadFeesStructure_Click" />
                                            </div>
                                        </div>
                                        <span style="font-size:18px; font-weight: bold;color:#7b0000">Less then 500 KB</span>
                                    </div>
                                </div>
                                <div class="form-row" id="divCollegeHostelFile" runat="server" visible="false">
                                    <div class="form-row-label" style="flex: 2;">
                                        <asp:Label ID="Label45" runat="server">College Hostel Certificate<span style="color:#a30000"> *</span><br />ವಿದ್ಯಾರ್ಥಿ ನಿಲಯ ಪ್ರಮಾಣಪತ್ರ</asp:Label>
                                    </div>
                                    <div class="form-row-input">
                                        <div class="input-group">
                                            <div class="custom-file">
                                                <asp:FileUpload ID="FileCollegeHostel" class="custom-file-input" runat="server" />
                                                <asp:Label ID="lblFileCollegeHostel" runat="server" class="custom-file-label"></asp:Label>
                                            </div>
                                            <div class="input-group-append">
                                                <asp:Button ID="btnUploadCollegeHostel" runat="server" Visible="true" CssClass="btn btn-secondary" Text="Upload" OnClick="btnUploadCollegeHostel_Click" />
                                            </div>
                                        </div>
                                        <span style="font-size:18px; font-weight: bold;color:#7b0000">Less then 500 KB</span>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="Popup-row-label">
                                    </div>
                                    <div class="Popup-row-label">
                                        <asp:Button ID="btnCollegeDetailsSaveReturnToPreview" Visible="false" runat="server" CssClass="NeoButton" Text="Save and Proceed" OnClick="btnCollegeDetailsSaveReturnToPreview_Click" />
                                        <asp:Button ID="btnCollegeDetailsSave" runat="server" Visible="true" CssClass="NeoButton" Text="Save and Proceed" OnClick="btnCollegeDetailsSave_Click" />
                                        <asp:Button ID="btnCollegeDetailsTemp" runat="server" Visible="true" CssClass="NeoButton" Text="Save and Proceed Temp" OnClick="btnCollegeDetailsSaveTemp_Click" />
                                    </div>
                                    <div class="form-row-label">
                                        <asp:Button ID="btnCollegeDetailsOk" runat="server" Visible="false" CssClass="NeoButton" Text="Proceed" OnClick="btnCollegeDetailsOk_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%--Button to Other Details--%>
                        <div id="divButtonToOtherDetails" runat="server" visible="false" class="form-row">
                            <div class="form-row-label">
                            </div>
                            <div class="form-row-input">
                                <asp:Button ID="btnNextShowRDNumber" runat="server" CssClass="NeoButton" Visible="false"  OnClick="btnNextShowRDNumber_Click" Text="Back" onpaste="return false" AutoCompleteType="Disabled" />
                                <asp:Button ID="btnNextChangeCollegeDetails" runat="server" CssClass="NeoButton"  OnClick="btnNextChangeCollegeDetails_Click" Text="Modify" onpaste="return false" AutoCompleteType="Disabled" />
                                <asp:Button ID="btnNextDisplayOtherDetails" runat="server" CssClass="NeoButton"  OnClick="btnNextDisplayOtherDetails_Click" Text="Confirm and Continue" onpaste="return false" AutoCompleteType="Disabled" />
                            </div>
                            <div class="form-row-Botton">
                            </div>
                        </div>
                        <%--Other Details--%>
                        <div id="divOtherDetails" runat="server" visible="false" class="form-row">
                            <div class="form-row-label">
                                <asp:Label ID="Label28" class="" runat="server">Mandatory Personal Details<span style="color:#a30000">*</span><br />ಇತರೆ ವಿವರಗಳು</asp:Label>
                            </div>
                            <div class="form-row-label">
                                <asp:Label ID="lblOtherDetailsUpdate" class="" runat="server" Text=""></asp:Label>
                                <div id="divOTPChkError1" class="DisplayError" style="font-size:18px; font-weight: bold;color:#7b0000"></div>
                            </div>
                            <div class="form-row-Botton">
                                <asp:Button ID="btnOtherDetailsUpdate" runat="server" CssClass="NeoButton" OnClick="btnOtherDetailsUpdate_Click" Text="Confirm and Continue" />
                                <asp:Button ID="btnOtherDetailsView" runat="server" Visible="false" CssClass="NeoButton" OnClick="btnOtherDetailsView_Click" Text="View" />
                            </div>
                        </div>


                         <%-- Fill Other Details--%>
                        <div class="" id="divOtherDetailsNew" runat="server" visible="false">
                            <div class="">
                                <div class="form-row" style="justify-content: center">
                                    <div class="Popup-row-label-Heading">
                                        <asp:Label ID="Label30" class="" Style=" margin-top: 30px" runat="server" Text="Other Mandatory Details"></asp:Label>
                                    </div>
                                </div>

                                <div class="form-row">
                                    <div class="form-row-label">
                                        <asp:Label ID="Label31" runat="server">E-mail ID<span style="color:#a30000"> *</span><br />ಇ-ಮೇಲ್ ಐಡಿ</asp:Label>
                                    </div>
                                    <div class="Popup-form-row-input">
                                        <asp:TextBox ID="txtEmailID" CssClass="NeoTextBox" TextMode="Email" placeholder="E-Mail ID" runat="server" onpaste="return false" AutoCompleteType="Disabled"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-row-label">
                                        <asp:Label ID="Label42" runat="server">Mobile Number<span style="color:#a30000"> *</span><br />ಮೊಬೈಲ್ ಸಂಖ್ಯೆ</asp:Label>
                                    </div>
                                    <div class="Popup-form-row-input">
                                        <asp:TextBox ID="txtApplicantMobileNumber" CssClass="NeoTextBox"  placeholder="Mobile Number" runat="server" MaxLength="10" onkeypress="return CheckMobileNumber(event)" Title="As Per Aadhaar" onpaste="return false" AutoCompleteType="Disabled"></asp:TextBox>
                                        <div id="divMobileChkError" class="DisplayError" style="font-size:18px; font-weight: bold;color:#7b0000"></div>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="form-row-label">
                                        <asp:Label ID="Label32" runat="server">Alternate Mobile Number<span style="color:#a30000"> *</span><br />ಪರ್ಯಾಯ ಮೊಬೈಲ್ ಸಂಖ್ಯೆ</asp:Label>
                                    </div>
                                    <div class="Popup-form-row-input">
                                        <asp:TextBox ID="txtAlternateMobileNumber" CssClass="NeoTextBox"  placeholder="Alternate Mobile Number" MaxLength="10" onkeypress="return Numeric(event)" runat="server" onpaste="return false" AutoCompleteType="Disabled"></asp:TextBox>
                                    </div>
                                </div>
                                
                                <div class="form-row">
                                    <div class="form-row-label">
                                        <asp:Label ID="Label89" runat="server">Father / Guardian Occupation<br />ತಂದೆ / ಪೋಷಕರ ಉದ್ಯೋಗ</asp:Label>
                                    </div>
                                    <div class="Popup-form-row-input">
                                        <asp:TextBox ID="txtFatherOccupation" CssClass="NeoTextBox"  placeholder="Occupation" MaxLength="20" runat="server" onpaste="return false" AutoCompleteType="Disabled"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-row">
                                    <div class="form-row-label">
                                        <asp:Label ID="Label35" runat="server">Is Applicant with Disabilities?<span style="color:#a30000"> *</span><br />ಅರ್ಜಿದಾರರು ವಿಶೇಷ ಚೇತನರೇ?</asp:Label>
                                    </div>
                                    <div class="Popup-row-label">
                                        <%--<asp:DropDownList ID="drpApplicantPWD" Class="rowMargin txtcolor text-uppercase NeuoDropdown" AutoPostBack="true" OnSelectedIndexChanged="rbApplicantPWD_CheckedChanged" runat="server">
                                        <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                                        <asp:ListItem Value="YES">YES</asp:ListItem>
                                        <asp:ListItem Value="NO">NO</asp:ListItem>
                                    </asp:DropDownList>--%>
                                        <asp:RadioButton ID="rbApplicantPWDYes" runat="server"  Class="radioButton" GroupName="ApplicantPWD" Text="Yes" AutoPostBack="true" OnCheckedChanged="rbApplicantPWD_CheckedChanged"  />
                                        <asp:RadioButton ID="rbApplicantPWDNo" runat="server"  Class="radioButton" GroupName="ApplicantPWD" Text="No" AutoPostBack="true" OnCheckedChanged="rbApplicantPWD_CheckedChanged" />

                                    </div>
                                </div>
                                <div id="divPWDIdNumber" visible="false" class="form-row" runat="server">
                                    <div class="form-row-label">
                                        <asp:Label ID="Label36" runat="server">Disabilities Certificate Number<span style="color:#a30000"> *</span><br />ವಿಶೇಷ ಚೇತನರ ಪ್ರಮಾಣ ಪತ್ರ ಸಂಖ್ಯೆ</asp:Label>
                                    </div>
                                    <div class="Popup-form-row-input">
                                        <asp:TextBox ID="txtPwdIdNumber" CssClass="NeoTextBox"  placeholder="Certificate Number" TextMode="SingleLine" MaxLength="100" runat="server" onpaste="return false" AutoCompleteType="Disabled"></asp:TextBox>
                                    </div>
                                </div>

                                

                                <div class="form-row">
                                    <div class="Popup-row-label">
                                    </div>
                                    <div class="form-row-Botton">
                                        <asp:Button ID="btnOtherDetailsSaveReturnToPreview" Visible="false" runat="server" CssClass="NeoButton" Text="Save and Proceed" OnClick="btnOtherDetailsSaveReturnToPreview_Click" />
                                        <asp:Button ID="btnOtherDetailsSave" runat="server" Visible="true" CssClass="NeoButton" Text="Save and Proceed" OnClick="btnOtherDetailsSave_Click" />
                                    </div>
                                    <div class="form-row-Botton">
                                        <asp:Button ID="btnOtherDetailsOk" runat="server" Visible="false" CssClass="NeoButton" Text="Proceed" OnClick="btnOtherDetailsOk_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>


                        <%--Button to Agrement--%>
                        <div id="divButtonToAgrement" runat="server" visible="false" class="form-row">
                            <div class="form-row-label">
                            </div>
                            <div class="form-row-input">
                                <asp:Button ID="btnNextShowBankDetails" runat="server" CssClass="NeoButton" Visible="false"  OnClick="btnNextShowBankDetails_Click" Text="Back" onpaste="return false" AutoCompleteType="Disabled" />
                                <asp:Button ID="btnNextChangeOtherDetails" runat="server" CssClass="NeoButton"  OnClick="btnNextChangeOtherDetails_Click" Text="Modify" onpaste="return false" AutoCompleteType="Disabled" />
                                <asp:Button ID="btnNextDisplayAgrement" runat="server" CssClass="NeoButton"  OnClick="btnNextDisplayAgrement_Click" Text="Confirm and Continue" onpaste="return false" AutoCompleteType="Disabled" />
                            </div>
                            <div class="form-row-Botton">
                            </div>
                        </div>

                        <%--Agrement--%>
                        <div id="divApproveAggrement" visible="false" runat="server" class="form-row" style="color:white">
                            <div class="">
                                <p style="text-align:justify"><asp:CheckBox runat="server" CssClass="ChkBoxClass" ID="ChkSelfDeclaration" OnCheckedChanged="ChkDeclarationChange" AutoPostBack="true" /> I hereby provide my consent to Karnataka Arya Vysya Community Development Corporation, (Government of Karnataka Undertaking), to use my Aadhaar number for performing all such validations which may be, required to verify the correctness of the data either provided by me or associated with me under schemes with whom I am enrolled for. I understand that the use of my Aadhaar number will be restricted to the extent required for efficient delivery of benefits to me by the State Government.  <br />ಕರ್ನಾಟಕ ಸರ್ಕಾರದ ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ ಸಮುದಾಯ ಸಭಿವೃಧಿ ನಿಗಮ ಕ್ಕೆ ನನ್ನ ಆಧಾರ್ ಸಂಖ್ಯೆಯನ್ನು ಬಳಸಲು ನಾನು ಈ ಮೂಲಕ ನನ್ನ ಒಪ್ಪಿಗೆ ಯನ್ನು ನೀಡುತ್ತೇನೆ, ಅದು ನನ್ನಿಂದ ಒದಗಿಸಲಾದ ಅಥವಾ ನನ್ನೊಂದಿಗೆ ಸಂಯೋಜಿತವಾಗಿರುವ ಮಾಹಿತಿ ನಿಖರತೆಯನ್ನು ಪರಿಶೀಲಿಸಲು ಅಗತ್ಯವಿರುವ ಎಲ್ಲ ಮೌಲ್ಯ ಮಾಪನ ಗಳನ್ನು ನಿರ್ವಹಿಸಲು ಅಗತ್ಯವಾಗಿರುತ್ತದೆ. ನನ್ನ ಆಧಾರ್ ಸಂಖ್ಯೆಯ ಬಳಕೆ ಯನ್ನು ರಾಜ್ಯ ಸರ್ಕಾರವು ನನಗೆ ಸವಲತ್ತುಗಳನ್ನು ಸಮರ್ಥವಾಗಿ ತಲುಪಿಸಲು ಮಿತಗೊಂಡಿರುತ್ತದೆ ಎಂದು ನಾನು ಅರ್ಥಮಾಡಿಕೊಂಡಿದ್ದೇನೆ</p>
                                <p style="text-align:justify"><asp:CheckBox runat="server" CssClass="ChkBoxClass" ID="ChkAadharDeclaration"  OnCheckedChanged="ChkDeclarationChange" AutoPostBack="true" /> I hereby certify that the above furnished information is true to my knowledge. I shall abide by the terms and conditions of the sanction of the Arivu Education Loan. If any discrepancies are found later, I agree to take legal action against me.<br />ಈ ಮೇಲ್ಕಂಡ ಮಾಹಿತಿಗಳು ನನಗೆ ತಿಳಿದ ಮಟ್ಟಿಗೆ ಸತ್ಯ ಮತ್ತು ಸರಿಯಾಗಿವೆಯೆಂದು ಪ್ರಮಾಣಿಕರಿಸುತ್ತೇನೆ. ಒಂದು ವೇಳೆ ಮೇಲ್ಕಂಡ ಮಾಹಿತಿಗಳು ಸುಳ್ಳು ಎಂದು ಕಂಡುಬಂದಲ್ಲಿ ನನ್ನ ವಿರುದ್ಧ ಕಾನೂನು ರೀತಿ ಕ್ರಮ ಜರುಗಿಸಲು ನಾನು ಒಪ್ಪಿರುತ್ತೇನೆ.</p>
                                <p style="text-align:justify"><asp:CheckBox runat="server" CssClass="ChkBoxClass" ID="ChkAgreetoProvideData"  OnCheckedChanged="ChkDeclarationChange" AutoPostBack="true" /> I hereby agree to provide my details to avail any government facilities. If any discrepancies are found later, I agree to take legal action against me.<br />ಈ ಮೇಲ್ಕಂಡ ಮಾಹಿತಿಗಳು ನನಗೆ ತಿಳಿದ ಮಟ್ಟಿಗೆ ಸತ್ಯ ಮತ್ತು ಸರಿಯಾಗಿವೆಯೆಂದು ಪ್ರಮಾಣಿಕರಿಸುತ್ತೇನೆ. ಒಂದು ವೇಳೆ ಮೇಲ್ಕಂಡ ಮಾಹಿತಿಗಳು ಸುಳ್ಳು ಎಂದು ಕಂಡುಬಂದಲ್ಲಿ ನನ್ನ ವಿರುದ್ಧ ಕಾನೂನು ರೀತಿ ಕ್ರಮ ಜರುಗಿಸಲು ನಾನು ಒಪ್ಪಿರುತ್ತೇನೆ.</p>
                            </div>
                        </div>
                        <%--Preview--%>`
                        <div id="divPreviewButton" runat="server" visible="false" class="form-row">
                            <div class="form-row-label">
                                <asp:Label ID="Label57" class="" runat="server"><span style="color:#a30000"><br />Click check-box to agree to the agreement </span></asp:Label>

                            </div>
                            <div class="form-row-label">
                                <asp:Button ID="btnPreviewApplication" runat="server" CssClass="NeoButton" OnClick="btnPreviewApplication_Click" Text="Preview Application" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
                            </div>
                            <div class="form-row-Botton">
                            </div>
                        </div>
                        
                    </div>
                    
                </div>
                 
                <div class="flex-container" runat="server" visible="false" id="divPreviewApplication">
                    <div class="NeumorphicDiv" style="width:70%; background-color:#f1f1f1; color:black">
                        <table runat="server" class="auto-style1" style="border: 3px solid" border="0" id="tblPreview">
                            <tr>
                                <td colspan="6">
                                    <div class="flex-container" style="width: 100%; display: flex">
                                        <div>
                                            <asp:Image ID="GOK" runat="server" Height="86px" Width="85px" ImageUrl="~/Image/GOK.png" />
                                        </div>
                                        <div class="" style="text-align: center; font-family: 'Lucida Sans'">
                                            <strong>
                                                <strong>
                                                    <asp:Label ID="Label40" runat="server" Style="font-size: 150%" Text="KARNATAKA ARYA VYSYA COMMUNITY DEVELOPMENT CORPORATION"></asp:Label>
                                                    <br />
                                                    <asp:Label ID="Label41" runat="server" Style="font-size: 120%" Text="Arivu Educational Loan Application"></asp:Label>
                                                </strong>
                                            </strong>
                                        </div>
                                        <div>
                                            <asp:Image ID="Image4" runat="server" Height="86px" Width="85px" ImageUrl="~/Image/KACDC_App.png" />

                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td colspan="2" class="auto-style4">&nbsp;</td>
                                <td colspan="2" class="auto-style7">&nbsp;</td>
                                <td class="auto-style12">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3" colspan="6" style="font-size:20px;text-align:center" ><strong>APPLICANT DETAILS</strong></td>
                                
                            </tr>
                            <tr>
                                <td class="auto-style3">
                                    <asp:Label ID="lblDispAppNum" Visible="false" runat="server">Application Number<br />ಅರ್ಜಿ ಸಂಖ್ಯೆ</asp:Label>
                                </td>
                                <td colspan="2" class="auto-style4">
                                    <asp:Label ID="lblApplicationNum" Visible="false" runat="server"></asp:Label>
                                </td>
                                <td colspan="2" class="auto-style7">
                                    <asp:Label ID="lblDispDate" Visible="false" runat="server">Application Date<br />ಅರ್ಜಿ ದಿನಾಂಕ</asp:Label>
                                </td>
                                <td class="auto-style12">
                                    <asp:Label ID="lblApplicationDate" Visible="false" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">NAME<br />
                                    ಹೆಸರು</td>
                                <td colspan="2" class="auto-style4">
                                    <asp:Label ID="lblName" runat="server"></asp:Label>
                                </td>
                                <td colspan="2" class="auto-style7">&nbsp;</td>
                                <td rowspan="5" class="auto-style5">
                                    <asp:Image ID="ImgCandPhoto" runat="server" Height="220px" Width="200px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">Father / Guardian Name<br />
                                    ತಂದೆ / ಪೋಷಕರ ಹೆಸರು</td>
                                <td colspan="2" class="auto-style4">
                                    <asp:Label ID="lblFatherName" runat="server"></asp:Label>
                                </td>
                                <td colspan="2" class="auto-style7">&nbsp;</td>
                            </tr>

                            <tr>
                                <td class="auto-style3">Gender<br />
                                    ಲಿಂಗ</td>
                                <td colspan="2" class="auto-style4">
                                    <asp:Label ID="lblGender" runat="server"></asp:Label>
                                </td>
                                <td colspan="2" class="auto-style7">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3">DOB<br />
                                    ಜನ್ಮ ದಿನಾಂಕ</td>
                                <td colspan="2" class="auto-style4">
                                    <asp:Label ID="lblDOB" runat="server"></asp:Label>
                                </td>
                                <td colspan="2" class="auto-style7">&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="2" class="auto-style8">R D Number<br />ಆರ್ ಡಿ ಸಂಖ್ಯೆ</td>
                                <td class="auto-style10">
                                    <asp:Label ID="lblRDNum" runat="server"></asp:Label>
                                </td>
                                <td colspan="2" class="auto-style7">&nbsp;</td>
                            </tr>

                            <tr>
                                <td class="auto-style8">Person With Disabilities<br />
                                    ಅರ್ಜಿದಾರ ವಿಶೇಷ ಚೇತನ</td>
                                <td colspan="2" class="auto-style11">
                                    <asp:Label ID="lblPhysicallyCha" runat="server"></asp:Label>
                                </td>
                                <td class="auto-style8">Anunal Income<br />
                                    ವಾರ್ಷಿಕ ಆದಾಯ</td>
                                <td colspan="2" class="auto-style11">
                                    <asp:Label ID="lblAnualIncome" runat="server"></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td class="auto-style3">Mobile Number<br />
                                    ಮೊಬೈಲ್ ಸಂಖ್ಯೆ</td>
                                <td colspan="2" class="auto-style4">
                                    <asp:Label ID="lblMobileNum" runat="server"></asp:Label>
                                </td>
                                <td colspan="2" class="auto-style7">Alternate Number<br />
                                    ಪರ್ಯಾಯ ಮೊಬೈಲ್ ಸಂಖ್ಯೆ</td>
                                <td class="auto-style12">
                                    <asp:Label ID="lblAlternateNum" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">E-mail ID<br />
                                    ಇ-ಮೇಲ್ ಐಡಿ</td>
                                <td colspan="2" class="auto-style4">
                                    <asp:Label ID="lblEmailID" runat="server"></asp:Label>
                                </td>
                                <td colspan="2" class="auto-style7">Aadhaar Details<br />
                                    ಆಧಾರ್ ವಿವರಗಳು</td>
                                <td class="auto-style12">
                                    <asp:Label ID="lblAadhar" runat="server"></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td class="auto-style3">Father / Guardian Occupation<br />
                                    ತಂದೆ / ಪೋಷಕರ ಉದ್ಯೋಗ</td>
                                <td colspan="2" class="auto-style4">
                                    <asp:Label ID="lblOccupation" runat="server"></asp:Label>
                                </td>
                                <td colspan="2" class="auto-style7">&nbsp;</td>
                                <td class="auto-style12">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style8">Contact Address<br />
                                    ಸಂಪರ್ಕಿಸುವ ವಿಳಾಸ</td>
                                <td colspan="2" class="auto-style13">
                                    <asp:Label ID="lblContactAddr" runat="server"></asp:Label>
                                </td>
                                <td colspan="2" class="auto-style13">Permanent Address<br />
                                    ಶಾಶ್ವತ ವಿಳಾಸ</td>
                                <td class="auto-style10">
                                    <asp:Label ID="lblParmanentAddr" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">District<br />
                                    ಜಿಲ್ಲೆ</td>
                                <td colspan="2" class="auto-style4">
                                    <asp:Label ID="lblContDistrict" runat="server"></asp:Label>
                                </td>
                                <td colspan="2" class="auto-style7">District<br />
                                    ಜಿಲ್ಲೆ</td>
                                <td class="auto-style12">
                                    <asp:Label ID="lblParDistrict" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">Taluk<br />
                                    ತಾಲ್ಲೂಕು</td>
                                <td colspan="2" class="auto-style4">
                                    <asp:Label ID="lblContTaluk" runat="server"></asp:Label>
                                </td>
                                <td colspan="2" class="auto-style7">Taluk<br />
                                    ತಾಲ್ಲೂಕು</td>
                                <td class="auto-style12">
                                    <asp:Label ID="lblParTaluk" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">Pin code<br />
                                    ಅಂಚೆ ಸಂಖ್ಯೆ</td>
                                <td colspan="2" class="auto-style4">
                                    <asp:Label ID="lblContPincode" runat="server"></asp:Label>
                                </td>
                                <td colspan="2" class="auto-style7">Pin code<br />
                                    ಅಂಚೆ ಸಂಖ್ಯೆ</td>
                                <td class="auto-style12">
                                    <asp:Label ID="lblParPincode" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>

                                <td class="auto-style3">&nbsp;</td>
                                <td colspan="2" class="auto-style4">&nbsp;</td>
                                <td colspan="2" class="auto-style7">Constituency<br />
                                    ಕ್ಷೇತ್ರ</td>
                                <td class="auto-style12">
                                    <asp:Label ID="lblParConstituency" runat="server"></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td colspan="2" class="auto-style4">&nbsp;</td>
                                <td colspan="2" class="auto-style7">&nbsp;</td>
                                <td class="auto-style12">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3" colspan="6" style="font-size:20px;text-align:center" ><strong>EDUCATIONAL DETAILS</strong></td>
                                
                            </tr>
                           
                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td colspan="2" class="auto-style4">&nbsp;</td>
                                <td colspan="2" class="auto-style7">&nbsp;</td>
                                <td class="auto-style12">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3">CET Admission Ticket Number<br />
                                    ಸಿಇಟಿ ಪ್ರವೇಶ ಟಿಕೆಟ್ ಸಂಖ್ಯೆ</td>
                                <td colspan="2" class="auto-style4">
                                    <asp:Label ID="lblCETAdmissionTicate" runat="server"></asp:Label>
                                </td>
                                <td colspan="2" class="auto-style7">CET Application Number<br />
                                    ಸಿಇಟಿ ಅರ್ಜಿ ಸಂಖ್ಯೆ</td>
                                <td class="auto-style12">
                                    <asp:Label ID="lblCETApplicationNumber" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">College Name<br />
                                    ಕಾಲೇಜಿನ ಹೆಸರು</td>
                                <td colspan="2" class="auto-style4">
                                    <asp:Label ID="lblCollegeName" runat="server"></asp:Label>
                                </td>
                                <td colspan="2" class="auto-style7">College Name and Address<br />
                                    ಕಾಲೇಜಿನ ಹೆಸರು ಮತ್ತು ವಿಳಾಸ</td>
                                <td class="auto-style12">
                                    <asp:Label ID="lblClgNameAddr" runat="server"></asp:Label>
                                </td>

                            </tr>
                            <tr>
                                <td class="auto-style3">Course<br />
                                    ಕೋರ್ಸ್</td>
                                <td colspan="2" class="auto-style4">
                                    <asp:Label ID="lblCourse" runat="server"></asp:Label>
                                </td>
                                <td colspan="2" class="auto-style7">Year<br />
                                    ವರ್ಷ</td>
                                <td class="auto-style12">
                                    <asp:Label ID="lblYear" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">Marks Obtained in Previous Year<br />
                                    ಹಿಂದಿನ ವರ್ಷದಲ್ಲಿ ಪಡೆದ ಅಂಕಗಳು</td>
                                <td colspan="2" class="auto-style4">
                                    <asp:Label ID="lblPrevYearMarks" runat="server"></asp:Label>
                                </td>
                                <td colspan="2" class="auto-style7">Required Loan Amount<br />
                                    ಅಗತ್ಯವಿರುವ ಸಾಲದ ಮೊತ್ತ</td>
                                <td class="auto-style12">
                                    <asp:Label ID="lblLoanAmount" runat="server"></asp:Label>
                                </td>

                            </tr>
                            <tr>
                                <td class="auto-style3">College Hostel
                                                            <br />
                                    ಕಾಲೇಜು ವಿದ್ಯಾರ್ಥಿ ನಿಲಯದಲ್ಲಿ ವಾಸವಿದ್ದೀರಾ? </td>
                                <td colspan="2" class="auto-style4">
                                    <asp:Label ID="lblClgHostel" runat="server"></asp:Label>
                                </td>
                                <td colspan="2" class="auto-style7">&nbsp;</td>
                                <td class="auto-style12">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td colspan="2" class="auto-style4">&nbsp;</td>
                                <td colspan="2" class="auto-style7">&nbsp;</td>
                                <td class="auto-style12">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3" colspan="6" style="font-size:20px;text-align:center" ><strong>BANK DETAILS</strong></td>

                            </tr>
                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td colspan="2" class="auto-style4">&nbsp;</td>
                                <td colspan="2" class="auto-style7">&nbsp;</td>
                                <td class="auto-style12">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3">Account Holder Name<br />
                                    ಖಾತೆದಾರರ ಹೆಸರು</td>
                                <td colspan="2" class="auto-style4">
                                    <asp:Label ID="lblAccountHolder" runat="server"></asp:Label>
                                </td>
                                <td colspan="2" class="auto-style7">A/C Number<br />
                                    ಖಾತೆ ಸಂಖ್ಯೆ</td>
                                <td class="auto-style12">
                                    <asp:Label ID="lblAccountNum" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">Bank
                                     <br />
                                    ಬ್ಯಾಂಕ್</td>
                                <td colspan="2" class="auto-style4">
                                    <asp:Label ID="lblBank" runat="server"></asp:Label>
                                </td>
                                <td colspan="2" class="auto-style7">Branch<br />
                                    ಶಾಖೆ</td>
                                <td class="auto-style12">
                                    <asp:Label ID="lblBranchName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">IFSC Code<br />
                                    ಐಎಫ್‌ಎಸ್‌ಸಿ ಕೋಡ್</td>
                                <td colspan="2" class="auto-style4">
                                    <asp:Label ID="lblIFCSCode" runat="server"></asp:Label>
                                </td>
                                <td colspan="2" class="auto-style7">Address<br />
                                    ವಿಳಾಸ</td>
                                <td class="auto-style12">
                                    <asp:Label ID="lblBankAddr" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td colspan="2" class="auto-style4">&nbsp;</td>
                                <td colspan="2" class="auto-style7">&nbsp;</td>
                                <td class="auto-style12">&nbsp;</td>
                            </tr>


                            <tr>
                                <td colspan="6">
                                    <p>
                                        I hereby provide my consent to Karnataka Arya Vysya Community Development Corporation (Government of Karnataka Undertaking) to use my Aadhaar Number for performing all such validations, which may be required to verify the correctness of the data either provided by me or associated with me under schemes with whom I am enrolled for. I understand that the use of my Aadhaar Number will be restricted to the extent required for efficient delivery of benefits to me by the State Government.
                                         <br />
                                        ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ ಸಮುದಾಯ ಅಭಿವೃದ್ಧಿ ನಿಗಮ (ಕರ್ನಾಟಕ ಸರ್ಕಾರದ ಉದ್ಯಮ) ಕ್ಕೆ ನನ್ನ ಆಧಾರ್ ಸಂಖ್ಯೆಯನ್ನು ಬಳಸಲು ಈ ಮೂಲಕ ನಾನು ಒಪ್ಪಿಗೆಯನ್ನು ನೀಡುತ್ತಿದ್ದೇನೆ. ನನ್ನಿಂದ ಒದಗಿಸಲಾದ ಅಥವಾ ನನ್ನೊಂದಿಗೆ ಸಂಯೋಜಿತವಾಗಿರುವ ಮಾಹಿತಿ ನಿಖರತೆಯನ್ನು ಪರಿಶೀಲಿಸಲು ಅಗತ್ಯವಿರುವ ಎಲ್ಲಾ ಮೌಲ್ಯಮಾಪನಗಳನ್ನು ನಿರ್ವಹಿಸಲು ಅಗತ್ಯವಾಗಿರುವುದರಿಂದ ನನ್ನ ಆಧಾರ್ ಸಂಖ್ಯೆಯ ಬಳಕೆಯನ್ನು ರಾಜ್ಯ ಸರ್ಕಾರವು ನನಗೆ ಸವಲತ್ತುಗಳನ್ನು ಸಮರ್ಪಕವಾಗಿ ತಲುಪಿಸಲು ಮಿತಗೊಂಡಿರುತ್ತದೆ ಎಂದು ನಾನು ಅರ್ಥಮಾಡಿಕೊಂಡಿರುತ್ತೇನೆ.
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <p>
                                         I hereby certify that the above furnished information is true to my knowledge. I shall abide by the terms and conditions of the sanction of the Arivu Education Loan. If any discrepancies are found later, I agree to take legal action against me.<br />
                                        ಈ ಮೇಲ್ಕಂಡ ಮಾಹಿತಿಗಳು ನನಗೆ ತಿಳಿದ ಮಟ್ಟಿಗೆ ಸತ್ಯ ಮತ್ತು ಸರಿಯಾಗಿವೆಯೆಂದು ಪ್ರಮಾಣೀಕರಿಸುತ್ತೇನೆ. ಒಂದು ವೇಳೆ ಮೇಲ್ಕಂಡ ಮಾಹಿತಿಗಳು ಸುಳ್ಳು ಎಂದು ಕಂಡುಬಂದಲ್ಲಿ ನನ್ನ ವಿರುದ್ಧ ಕಾನೂನು ರೀತಿಯ ಕ್ರಮ ಜರುಗಿಸಲು ಒಪ್ಪಿರುತ್ತೇನೆ.
                                    </p>
                                </td>
                            </tr>

                        </table>

                        <div id="divSubmitandEdit" runat="server" class="form-row">
                            <div class="form-row-Button">
                                <asp:Button ID="btnPreviewEditOtherDetails" runat="server" CssClass="NeoButton" OnClick="btnPreviewEditOtherDetails_Click1" Text="Edit Personal Details" onpaste="return false" AutoCompleteType="Disabled" />
                            </div>
                            <div class="form-row-Button">
                                <asp:Button ID="btnPreviewEditCollegeDetails" runat="server" CssClass="NeoButton"  OnClick="btnPreviewEditCollegeDetails_Click" Text="Edit College Details" onpaste="return false" AutoCompleteType="Disabled" />
                            </div>
                            <div class="form-row-Button">
                                <asp:Button ID="btnPreviewSubmitApplication" runat="server" CssClass="NeoButton"  OnClick="btnPreviewSubmitApplication_Click" Text="Submit Application" onpaste="return false" AutoCompleteType="Disabled" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
                            </div>

                        </div>
                    </div>
                </div>

                <asp:Panel ID="PnlOtherDetailsa" CssClass="modalPopup PopupPanel" runat="server" Visible="false">
                    <div class="flex-container">
                         <div class="form-row">
                    <div class="Popup-row-label">
                                                    <asp:TextBox ID="txtDOB" runat="server" CssClass="NeoTextBox" AutoPostBack="true"></asp:TextBox>
                        </div></div></div>
                    </asp:Panel>

             <%--Pop-Up--%>
                <%--Bank Details--%>
                <asp:Panel ID="PnlBankDetails" runat="server" CssClass="modalPopup PopupPanel" Style="display: none; ">
                    <div class="flex-container">
                        <div class="">
                            <div class="form-row" style="justify-content:center">
                                <div class="Popup-row-label-Heading">
                                    <asp:Label ID="Label15" class="" runat="server" Text="Bank Details"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="Popup-row-label">
                                    <asp:Label ID="Label38" runat="server">Account Holder Name<br />ಖಾತೆದಾರರ ಹೆಸರು</asp:Label>
                                </div>
                                <div class="Popup-row-label">
                                    <asp:Label ID="lblAccountHolderName" Width="40px" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="Popup-row-label">
                                    <asp:Label ID="Label16" runat="server">Account Number<br />ಖಾತೆ ಸಂಖ್ಯೆ</asp:Label>
                                </div>
                                <div class="Popup-row-label">
                                    <asp:Label ID="lblAccountNumber" Width="40px" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="Popup-row-label">
                                    <asp:Label ID="Label17" runat="server">Bank Name<br />ಬ್ಯಾಂಕ್ ಹೆಸರು</asp:Label>
                                </div>
                                <div class="Popup-row-label">
                                    <asp:Label ID="lblBankName" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="Popup-row-label">
                                    <asp:Label ID="Label13" runat="server">Branch Name<br />ಶಾಖೆಯ ಹೆಸರು</asp:Label>
                                </div>
                                <div class="Popup-row-label">
                                    <asp:Label ID="lblBranch" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="Popup-row-label">
                                    <asp:Label ID="Label18" runat="server">IFSC Code<br />ಐಎಫ್‌ಎಸ್‌ಸಿ ಕೋಡ್</asp:Label>
                                </div>
                                <div class="Popup-row-label">
                                    <asp:Label ID="lblIFSCCode" runat="server"></asp:Label>
                                </div>
                            </div>

                            <div class="form-row">
                                <div class="Popup-row-label">
                                    <asp:Label ID="Label14" runat="server">Address<br />ವಿಳಾಸ</asp:Label>
                                </div>
                                <div class="Popup-row-label">
                                    <asp:Label ID="lblBankAddress" runat="server"></asp:Label>
                                </div>
                            </div>

                            <div class="form-row">
                                <%-- <div class="Popup-row-label">
                            <asp:Button ID="btnZMSERejectUpdate" runat="server" CssClass="Button" Text="Save and Proceed" />
                        </div>--%>
                                <div class="form-row-Botton">
                                    <asp:Button ID="btnBankDetailsBack" runat="server" CssClass="NeoButton" Text="Back" OnClick="btnBankDetailsBack_Click" />
                                    <asp:Button ID="btnSECancel" runat="server" CssClass="NeoButton" Text="Confirm and Continue" OnClientClick="return BankDetailsHidePopup()" />
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>

                <asp:LinkButton ID="lnkBankDetailsFake" runat="server"></asp:LinkButton>
                <cc1:ModalPopupExtender ID="BankDetailsPopup" runat="server" TargetControlID="lnkBankDetailsFake" PopupControlID="PnlBankDetails"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>

                <%--Caste Certificate--%>
                <asp:Panel ID="PnlCasteCertificateAR" runat="server" CssClass="modalPopup PopupPanel" Style="display: none; ">

                    <div class="flex-container">
                        <div class="">
                            <div class="form-row" style="justify-content:center">
                                <div class="Popup-row-label-Heading">
                                    <asp:Label ID="Label19" class="" Style=" margin-top: 20px;" runat="server" Text="Caste And Income Certificate Details"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="Popup-row-label">
                                    <asp:Label ID="Label20" runat="server">RD Number<br />ಆರ್.ಡಿ ಸಂಖ್ಯೆ</asp:Label>
                                </div>
                                <div class="Popup-row-label">
                                    <asp:Label ID="lblNCGSCNumber" Width="40px" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="Popup-row-label">
                                    <asp:Label ID="Label22" runat="server">Name<br />ಹೆಸರು</asp:Label>
                                </div>
                                <div class="Popup-row-label">
                                    <asp:Label ID="lblNCApplicantName" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="Popup-row-label">
                                    <asp:Label ID="Label24" runat="server">Annual Income<br />ವಾರ್ಷಿಕ ಆದಾಯ</asp:Label>
                                </div>
                                <div class="Popup-row-label">
                                    <asp:Label ID="lblNCAnnualIncome" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="Popup-row-label">
                                    <asp:Label ID="Label39" runat="server">Constituency<span style="color:#a30000"> *</span><br />ಕ್ಷೇತ್ರ</asp:Label>
                                </div>
                                <div class="Popup-row-label">
                                    <asp:DropDownList ID="drpConst" Class="rowMargin txtcolor text-uppercase form-control" AutoPostBack="true" runat="server" ClientIDMode="Static" OnSelectedIndexChanged="drpConst_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="Popup-row-label">
                                    <asp:Label ID="Label27" runat="server">Father / Guardian Name<br />ತಂದೆ / ಪೋಷಕರ ಹೆಸರು</asp:Label>
                                </div>
                                <div class="Popup-row-label">
                                    <asp:Label ID="lblNCApplicantFatherName" runat="server"></asp:Label>
                                </div>
                            </div>

                            <div class="form-row">
                                <div class="Popup-row-label">
                                    <asp:Label ID="Label29" runat="server">Address<br />ವಿಳಾಸ</asp:Label>
                                </div>
                                <div class="Popup-row-label">
                                    <asp:Label ID="lblNCFullAddress" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="Popup-row-label">
                                    <asp:Label ID="Label9" runat="server">Taluk<br />ತಾಲ್ಲೂಕು</asp:Label>
                                </div>
                                <div class="Popup-row-label">
                                    <asp:Label ID="lblNCTaluk" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="Popup-row-label">
                                    <asp:Label ID="Label23" runat="server">District<br />ಜಿಲ್ಲೆ</asp:Label>
                                </div>
                                <div class="Popup-row-label">
                                    <asp:Label ID="lblNCDistrict" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div id="divContactAddressOption" visible="true" runat="server" class="form-row">
                                <div class="Popup-row-label">
                                    <asp:Label ID="Label21" runat="server" >Contact Address same as above<span style="color:#a30000"> *</span></asp:Label>
                                </div>
                                <div class="Popup-row-label">
                                   <%-- <asp:DropDownList ID="drpContactAddress" Visible="false" Class="rowMargin txtcolor text-uppercase NeuoDropdown" runat="server"  AutoPostBack="true">
                                        <asp:ListItem>--SELECT--</asp:ListItem>
                                        <asp:ListItem Value="YES">YES</asp:ListItem>
                                        <asp:ListItem Value="NO">NO</asp:ListItem>
                                    </asp:DropDownList>--%>
                                        <asp:RadioButton ID="rbContactAddressYes" runat="server"  Class="radioButton" GroupName="ContactAddress" Text="Yes" AutoPostBack="true" OnCheckedChanged="rbContactAddress_CheckedChanged"  />
                                        <asp:RadioButton ID="rbContactAddressNo" runat="server" Class="radioButton" GroupName="ContactAddress" Text="No" AutoPostBack="true" OnCheckedChanged="rbContactAddress_CheckedChanged" />
                                </div>
                            </div>
                            <div id="divContactAddress" runat="server" visible="false">
                                <div runat="server" class="form-row" style="padding:1px">
                                    <div class="Popup-row-label">
                                        <asp:Label ID="Label25" runat="server">Contact Address<br />ಸಂಪರ್ಕಿಸುವ ವಿಳಾಸ</asp:Label>
                                    </div>
                                    <div class="Popup-row-label">
                                        <asp:TextBox ID="txtContactAddress" CssClass="NeoTextBox" TextMode="MultiLine" Height="50px" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div runat="server" class="form-row"  style="padding:1px">
                                    <div class="Popup-row-label">
                                        <asp:Label ID="Label53" runat="server">District  ಜಿಲ್ಲೆ <span style="color:#a30000"> *</span></asp:Label>
                                    </div>
                                    <div class="Popup-row-label">
                                        <asp:DropDownList ID="drpContDistrict" Class="rowMargin txtcolor text-uppercase form-control NeuoDropdown" AutoPostBack="true" runat="server" ClientIDMode="Static" OnSelectedIndexChanged="drpContDistrict_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div runat="server" class="form-row"  style="padding:1px">
                                    <div class="Popup-row-label">
                                        <asp:Label ID="Label54" runat="server">Taluk  ತಾಲ್ಲೂಕು <span style="color:#a30000"> *</span></asp:Label>
                                    </div>
                                    <div class="Popup-row-label">
                                        <asp:DropDownList ID="drpContTaluk" Class="text-uppercase rowMargin txtcolor form-control NeuoDropdown" AutoPostBack="true" OnSelectedIndexChanged="drpContTaluk_SelectedIndexChanged" runat="server" ClientIDMode="Static">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div runat="server" class="form-row"  style="padding:1px">
                                    <div class="Popup-row-label">
                                        <asp:Label ID="Label55" runat="server">Pin code  ಅಂಚೆ ಸಂಖ್ಯೆ <span style="color:#a30000"> *</span></asp:Label>
                                    </div>
                                    <div class="Popup-row-label">
                                        <asp:TextBox ID="txtContPincode" CssClass="NeoTextBox" placeholder="Pin code" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);" runat="server" ForeColor="Black" TextMode="Number" MaxLength="6" onpaste="return false" AutoCompleteType="Disabled"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div id="divButtonSubmitApplication" class="form-row" runat="server" style="justify-content:center">
                                <%--<div class="Popup-row-label">
                                </div>--%>
                                <div class="form-row-Botton">
                                    <asp:Button ID="btnNadakachriBack" runat="server"   CssClass="NeoButton" Text="Back" OnClick="btnNadakachriBack_Click" />
                                </div>
                                <div class="form-row-Botton">
                                    <asp:Button ID="btnSaveContactAddress" runat="server"   CssClass="NeoButton" Text="Save and Proceed" OnClick="btnSaveContactAddress_Click" />
                                </div>
                                <div class="form-row-Botton">
                                    <asp:Button ID="btnNadakachriOK" runat="server" CssClass="NeoButton" Text="Proceed" OnClientClick="return CasteCertificateHidePopup()" />
                                </div>
                            </div>
                               
                            </div>
                    </div>
                </asp:Panel>

                <asp:LinkButton ID="lnkCasteCertificate" runat="server"></asp:LinkButton>
                <cc1:ModalPopupExtender ID="CasteCertificatePopup" runat="server" TargetControlID="lnkCasteCertificate" PopupControlID="PnlCasteCertificateAR"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>

                <%--Other Details--%>
                <asp:Panel ID="PnlOtherDetails" runat="server" CssClass="modalPopup PopupPanel" Style="display: none; padding: 5px">

                    
                </asp:Panel>

                <asp:LinkButton ID="lnkOtherDetails" runat="server"></asp:LinkButton>
                <cc1:ModalPopupExtender ID="OtherDetailsPopup" runat="server" TargetControlID="lnkOtherDetails" PopupControlID="PnlOtherDetails"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>

                 <%--Submit Application--%>
                <asp:Panel ID="PnlSubmitApplication" runat="server" CssClass="modalPopup PopupPanel" Style="display: none; width:50%;height:25%; padding: 5px">

                    <div class="flex-container">
                        <div class="form-row">
                            <div class="Popup-row-label">
                                <asp:Label ID="lblSubmitApplicationStatus" runat="server">E-mail ID<span style="color:#a30000"> *</span><br />ಇ-ಮೇಲ್ ಐಡಿ</asp:Label>
                            </div>
                        </div>
                    </div>
                </asp:Panel>

                 <asp:LinkButton ID="lnkSubmitApplication" runat="server"></asp:LinkButton>
                <cc1:ModalPopupExtender ID="SubmitApplicationPopup" runat="server" TargetControlID="lnkSubmitApplication" PopupControlID="PnlSubmitApplication"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>

                 <%--Wait Display--%>
                <asp:Panel ID="PnlDisplayWait" runat="server" CssClass="modalPopup PopupPanel" Style="display: none; width: 50%; height: 25%; padding: 5px">

                    <div class="flex-container">
                        <div class="form-row" style="justify-content:center">
                            <div class="Popup-row-label-Heading">
                                <asp:Label ID="Label52" runat="server" Text="Please Wait . . ."></asp:Label>
                            </div>
                        </div>
                    </div>
                </asp:Panel>

                 <asp:LinkButton ID="lnkDisplayWait" runat="server"></asp:LinkButton>
                <cc1:ModalPopupExtender ID="DisplayWaitPopup" runat="server" TargetControlID="lnkDisplayWait" PopupControlID="PnlDisplayWait"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>

                 <%--Confirm Preview Display--%>
                <asp:Panel ID="PnlConfirmPreview" runat="server" CssClass="modalPopup PopupPanel" Style="display: none; width: 50%; height: 25%; padding: 5px">

                    <div class="flex-container">
                        <div class="form-row" style="justify-content: center">
                            <div class="Popup-row-label-Heading">
                                <asp:Label ID="lbldfgsdfg" runat="server" Text="Please Wait . . ."></asp:Label>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="Popup-row-label">
                                <asp:Label ID="Label70" runat="server" Text="Are you sure, you don't want to provide your details to avail any other government facility"></asp:Label>
                            </div>
                            <div class="Popup-row-label">
                                <asp:Label ID="Label71" runat="server" Text="ನಿಮಗೆ ಖಚಿತವಾಗಿದೆಯೇ, ಸರ್ಕಾರದ ಯಾವುದೇ ಸೌಲಭ್ಯವನ್ನು ಪಡೆಯಲು ನಿಮ್ಮ ವಿವರಗಳನ್ನು ಒದಗಿಸಲು ನೀವು ಬಯಸುವುದಿಲ್ಲ"></asp:Label>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-row-Botton">
                                <asp:Button ID="btnProvideDetailsYes" runat="server" CssClass="NeoButton" Text="Back" OnClick="btnProvideDetailsYes_Click" />
                                <asp:Button ID="btnProvideDetailsNo" runat="server" CssClass="NeoButton" Text="Proceed" OnClick="btnProvideDetailsNo_Click" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>

                 <asp:LinkButton ID="lnkConfirmPreview" runat="server"></asp:LinkButton>
                <cc1:ModalPopupExtender ID="ConfirmPreviewPopup" runat="server" TargetControlID="lnkConfirmPreview" PopupControlID="PnlConfirmPreview"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>

                 <%--Aadhaar Details--%>
                <asp:Panel ID="PnlAadhaarDetails" runat="server" CssClass="modalPopup PopupPanel" Style="display: none; width:50%;height:80%; padding: 5px">
                   <div class="flex-container">
                        <div class="">
                            <div class="form-row" style="justify-content:center">
                                <div class="Popup-row-label-Heading">
                                    <asp:Label ID="Label43" class="" Style=" margin-top: 20px" runat="server" Text="Aadhaar Details"></asp:Label>
                                </div>
                            </div>
                           <div class="form-row">
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
                                    <asp:Button ID="btnAadhaarkDetailsBack" runat="server" CssClass="NeoButton" Text="Back" OnClick="btnAadhaarkDetailsBack_Click" />
                                    <asp:Button ID="btnAadhaarkDetailsProceed" runat="server" CssClass="NeoButton" Text="Proceed" OnClick="btnAadhaarkDetailsProceed_Click" />
                                </div>
                            </div>

                        </div>
                    </div>
                </asp:Panel>

                 <asp:LinkButton ID="lnkAadhaarDetails" runat="server"></asp:LinkButton>
                <cc1:ModalPopupExtender ID="AadhaarPopup" runat="server" TargetControlID="lnkAadhaarDetails" PopupControlID="PnlAadhaarDetails"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>



                <%-- CountDown Session Popup --%>

                <h3 runat="server" visible="false">Session Idle:&nbsp;<span id="MinutesIdle"><span id="secondsIdle"></span>&nbsp;seconds.</h3>
                <asp:LinkButton ID="lnkFake" runat="server" />
                <cc1:ModalPopupExtender ID="mpeTimeout" BehaviorID="mpeTimeout" runat="server" PopupControlID="pnlPopup" TargetControlID="lnkFake"
                    OkControlID="btnYes" CancelControlID="btnNo" BackgroundCssClass="modalBackground" OnCancelScript="SessionExpireSoon()" OnOkScript="ResetSession()">
                </cc1:ModalPopupExtender>

                <%-- Server Timeout Popup --%>
                <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">
                    <div class="header">
                        Session Expiring!
                    </div>
                    <div class="body">
                        Your Session will expire in&nbsp;<span id="seconds"></span>&nbsp;seconds.<br />
                        Do you want to reset?
                    </div>
                    <div class="footer" style="align-items: center">
                        <asp:Button ID="btnYes" runat="server" Text="Yes" Visible="false" CssClass="yes" />
                        <asp:Button ID="btnNo" runat="server" Text="No" CssClass="OK" />
                    </div>
                </asp:Panel>
                <div visible="false">
                    <%-- Testing
                RD0038109138130<br />
                    RD0038208475888
                RD0038287185809--%>
                    <br />
                    <asp:Label runat="server" ID="lblDispRDData" Visible="false"></asp:Label>
                    <asp:Label ID="lblOTP" runat="server" Visible="false" Text="OTP "></asp:Label>
                    <div style="display: none">

                        <div class="form-row">
                            <div class="Popup-row-label">
                                <asp:Label ID="Label33" runat="server" Text="E-mail ID"></asp:Label>
                            </div>
                            <div class="Popup-row-label">
                                <asp:TextBox ID="TextBox7" CssClass="NeoTextBox" TextMode="Email" Height="50px" runat="server" onpaste="return false" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                        <hr />
                        <span style="color: green"><i class="fa fa-check"></i></span>
                        <asp:Label ID="Label6" runat="server" Text="Verified" CssClass="VerifiedLabel"></asp:Label>
                        <asp:Label ID="Label7" runat="server" Text="Not Verified check" CssClass="NotVerifiedLabel"></asp:Label>
                        <asp:Label ID="Label8" runat="server" Text="Not Verified" CssClass=" fa fa-times NotVerifiedLabel"></asp:Label>
                        <asp:Label ID="lblSuccess" runat="server" Text="Verified" CssClass="text-success"></asp:Label>

                        <div id="Mydiv" runat="server">a</div>
                        <div class="success-checkmark">
                            <div class="check-icon">
                                <span class="icon-line line-tip"></span>
                                <span class="icon-line line-long"></span>
                                <div class="icon-circle"></div>
                                <div class="icon-fix"></div>
                            </div>
                        </div>
                        <asp:Label ID="Label11" runat="server" Text="Reason"></asp:Label>







                        <div class="NeumorphicDiv" style="display: none">
                            <div class="form-row">
                                <asp:Label ID="Label2" runat="server" Text="Reason"></asp:Label>
                                <asp:TextBox ID="TextBox2" CssClass="PopupTextBox" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-row">
                                <asp:Label ID="Label3" runat="server" Text="Reason"></asp:Label>
                                <asp:TextBox ID="TextBox3" CssClass="PopupTextBox" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-row">
                                <asp:Label ID="Label4" runat="server" Text="Reason"></asp:Label>
                                <asp:TextBox ID="TextBox4" CssClass="PopupTextBox" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-row">
                                <button type="submit">Submit</button>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="flex-container" id="divPrintApplication" visible="false" runat="server">
            <div class="NeumorphicDiv" >
                <div id="div"   runat="server">
                    <div   style="align-items:center;" align="center">
                        <asp:Button ID="btnPrintApplication" runat="server" style="align-self:center" CssClass="NeoButton" Text="Download Application" OnClick="btnPrintApplication_Click" />
                    </div>
                   
                </div>
            </div>
        </div>
        <%--<div>
        <div class="form-row-label">
                                <asp:Label ID="Label43" class="" runat="server">Mobile Number<span style="color:#a30000"> *</span><br />ಮೊಬೈಲ್ ಸಂಖ್ಯೆ</asp:Label><br />
                                <%--<asp:Label runat="server" Style="font-size: 8px; color: red;">(As Per Aadhar)</asp:Label>
                            </div>
							<div class="form-row-input">
                                <asp:TextBox ID="TextBox1" CssClass="NeoTextBox" runat="server"  MaxLength="10" onkeypress="return CheckMobileNumber(event)" Title="As Per Aadhaar"></asp:TextBox>
                                <div id="divMobileChkError1" class="DisplayError" style="font-size:18px; font-weight: bold;color:#7b0000"></div>
                            </div>
                            <div class="form-row-Botton" id="div3" runat="server">
                                <asp:Button ID="btnGetOTP" runat="server" CssClass="NeoButton"  OnClick="btnGetOTP_Click" Text="Get OTP" />
                            </div>
							
 <div id="div4" runat="server" visible="false" class="form-row">
                            <div class="form-row-label">
                                <asp:Label ID="Label44" class="" runat="server">OTP<br />ಒಟಿಪಿ</asp:Label>
                            </div>
                            <div class="form-row-input">
                                <asp:TextBox ID="TextBox5" CssClass="NeoTextBox" runat="server" MaxLength="8"  onkeypress="return CheckOTP(event)"></asp:TextBox>
                                <div id="divOTPChkErrorold" class="DisplayError" style="font-size:18px; font-weight: bold;color:#7b0000"></div>
                            </div>
                            <div class="form-row-Botton">
                                <asp:Button ID="Button2" runat="server" CssClass="NeoButton" OnClick="btnVerifyOTP_Click" Text="Verify" onpaste="return false" AutoCompleteType="Disabled" />
                            </div>
                        </div>
            </div>--%>
    </form>
</body>
</html>

