<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckRD.aspx.cs" Inherits="KACDC.CheckRD" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validate RD Number</title>
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
    <script src="NewScript/jquery.blockUI.js"></script>
    <script src="https://code.jquery.com/jquery-3.5.1.js" integrity="sha256-QWo7LDvxbWT2tbbQ97B53yJnYU3WhH/C8ycbRAkjPDc=" crossorigin="anonymous"></script>
    <style>
        .CountDown {
            text-align: left;
            font-size: 20px;
            margin-top: 0px;
            margin-top: 0;
            z-index: -1;
            position: absolute;
            display: flex;
        }

        .ChkBoxClass input {
            width: 15px;
            height: 15px;
        }
    </style>


    <script src="Scripts/jquery-3.0.0.js"></script>
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.3/css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.21/css/dataTables.bootstrap4.min.css" />
    <link rel="stylesheet" type="text/css" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.21/css/dataTables.jqueryui.min.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.7/css/jquery.dataTables.min.css" />
    <script src="https://cdn.datatables.net/1.10.7/js/jquery.dataTables.min.js">  </script>


    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.3.1/js/dataTables.buttons.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.3.1/js/buttons.html5.min.js"></script>


    <style>
        .Neumorphic {
            border-radius: 25px;
            background: #d9d9d9;
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
            font-family: "poppins", sans-serief;
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
            font-family: "poppins", sans-serief;
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
            font-size: 20px;
            font-family: "poppins", sans-serief;
        }

        .NeumorphicDiv {
            border-radius: 25px;
            background: #eeecec;
            box-shadow: 10px 10px 10px #797878, -10px -10px 10px #ffffff;
            justify-content: center;
            padding: 25px;
            margin: 20px;
            margin-top: 10px;
            align-items: center;
            letter-spacing: 1.5px;
            font-family: "poppins", sans-serief;
            width: 60%;
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
            width: 40%;
            max-width: 60%;
            font-size: 16px;
            background: transparent;
            border: none;
            outline: none;
            cursor: pointer;
            border-radius: 3px;
            box-shadow: 8px 8px 10px #797878, -8px -8px 10px #ffffff;
        }

        .NeoButton {
            border: none;
            padding: 3px;
            margin: 7px;
            outline: none;
            width: 80%;
            height: 30px;
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
            box-shadow: 5px 5px 10px #797878, -5px -5px 10px #ffffff;
        }

            .NeoButton:hover {
                box-shadow: 5px 5px 10px #d4d2d2, -5px -5px 10px #ffffff;
            }

            .NeoButton:active {
                box-shadow: inset 5px 5px 10px #d4d2d2, inset -5px -5px 10px #ffffff;
            }

        .NeoTextBox {
            letter-spacing: .08em;
            box-sizing: border-box;
            width: 90%;
            height: 30px;
            font-size: 16px;
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
            margin: 20px auto 0 auto;
            padding: 30px;
            background-color: #eeecec;
            border-radius: 25px;
            box-shadow: 10px 10px 20px #cac9c9, -10px -10px 20px #ffffff;
            margin: 20px;
            margin-top: 10px;
            font-size: 20px;
            align-items: center;
            letter-spacing: 1.5px;
            font-family: "poppins", sans-serief;
        }

        .form-row {
            padding: 10px 0;
            display: flex;
            justify-content: flex-end;
            padding: 5px;
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
            font-size: 30px;
        }

        .form-row-label {
            padding-right: 10px;
            flex: 1;
            font-size: 15px;
            padding: 5px;
            font-weight: 300;
            letter-spacing: .09em;
            text-transform: uppercase;
            /*background-color:aquamarine;*/
        }

        .form-row-input {
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

        .PopupPanel {
            Width: 650px;
            Height: 720px;
        }

            .PopupPanel .flex-container {
                margin-bottom: 2%
            }

                .PopupPanel .flex-container .PopupPanel {
                    margin-bottom: 2%
                }

        .Popup-row-label {
            padding-right: 10px;
            flex: 1;
            font-size: 15px;
            padding: 5px;
            padding-top: 2px;
            padding-bottom: 2px;
            font-weight: 300;
            letter-spacing: .09em;
            text-transform: uppercase;
            /*background-color:aquamarine;*/
        }
    </style>
    <style>
        .ui-tooltip {
            font-size: 10pt;
            font-family: Calibri;
            height: 25px;
            padding: 3px;
            padding-top: 0px;
            padding-bottom: 5px;
            background-color: aqua;
        }

        @media (max-width: 768px) {
            .PopupPanel {
                Width: 80%;
                Height: 70%;
            }

            .NeumorphicDiv {
                width: 90%;
            }

            .form-row-label-Heading {
                font-size: 15px;
            }

            .form-row-label {
                font-size: 9px;
                padding-right: 0px;
                /*background-color: antiquewhite;*/
            }

            .form-row-input {
            }

            .form-row-Button {
            }

            .NeoTextBox {
                height: 25px;
                font-size: 12px;
                width: 80%;
            }

                .NeoTextBox:focus {
                    width: 300px;
                    -webkit-transition: width .35s ease-in-out;
                    transition: width .35s ease-in-out;
                }

            .DisplayError {
                font-size: 8px;
            }

            .NeoButton {
                font-size: 10px;
                
            }

            .form-row {
                padding: 5px 0;
            }
        }
        .Button {  
        cursor: pointer;  
        font-size:20px;
        margin-left:3px;
        margin-right:3px;
        border-radius: 5px;
        height:40px;
        border:solid;
        border-color:#c7c7c7;
background: #dbdbdb;
box-shadow:  10px 10px 25px #b0b0b0, 
             -10px -10px 25px #ffffff;

    } 
    </style>
    <script type="text/javascript">
        function CheckRDNumber() {
            $('#txtRDNumber').keyup(function () {
                var RDNumber = $(this).val();
                if (RDNumber.length != 0) {
                    if (RDNumber.length == 15) {
                        if (RDNumber.match(/RD\d{13}/i)) {
                            $.ajax({
                                url: 'Schemes/Arivu/ArivuAadharCheck.asmx/CheckARAadhar',
                                method: 'post',
                                data: { NewAadhar: RDNumber, SPChk: "spArivuRDNumExist", Param: "@NewRDNum" },
                                dataType: 'json',
                                success: function (data) {
                                    var divElement = $('#divRDNumChkError');
                                    if (data.AadharNumInUse) {
                                        divElement.text(data.NewAadhar + ' already Exist');
                                        divElement.css('color', 'red');
                                    }
                                    else {
                                        divElement.text(data.NewAadhar + ' Can Validate')
                                        divElement.css('color', 'green');
                                        document.getElementById("btnVerifyRDNumber").disabled = false;
                                    }
                                },
                                error: function (err) {
                                    alert(err);
                                }
                            });
                        }
                        else {
                            var divElement = $('#divRDNumChkError');
                            divElement.text('RD Number Must be in RD0000000000000 format')
                            divElement.css('color', 'red');
                            document.getElementById("btnVerifyRDNumber").disabled = true;
                        }
                    }
                    else {
                        var divElement = $('#divRDNumChkError');
                        divElement.text('RD Number Must be 15 Characters')
                        divElement.css('color', 'red');
                        document.getElementById("btnVerifyRDNumber").disabled = true;
                    }
                }
                else {
                    var divElement = $('#divRDNumChkError');
                    divElement.text('RD Number Must be Enter')
                    divElement.css('color', 'red');
                    document.getElementById("btnVerifyRDNumber").disabled = true;
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div>
                    <div id="divRDNumber" runat="server" class="form-row">
                        <div class="form-row-label">
                            <asp:Label ID="Label10" class="" runat="server">RD Number(Form - G)<span style="color:red"> *</span><br />ಆರ್.ಡಿ ಸಂಖ್ಯೆ(ನಮೂನೆ - ಜಿ)</asp:Label>
                        </div>
                        <div class="form-row-input">
                            <asp:TextBox ID="txtRDNumber" CssClass="NeoTextBox" runat="server" Style="text-transform: uppercase" MaxLength="15" onkeypress="CheckRDNumber()"></asp:TextBox>
                            <div id="divRDNumChkError" runat="server" class="DisplayError"></div>
                       </div>
                        <div class="form-row-Botton">
                            <asp:Button ID="btnVerifyRDNumber" runat="server" CssClass="NeoButton" OnClick="btnVerifyRDNumber_Click" Text="Verify" onpaste="return false" AutoCompleteType="Disabled" />
                        </div>
                    </div>
                </div>
                <div class="flex-container">
                    <div class="NeumorphicDiv">
                        <div class="form-row">
                            <div class="Popup-row-label">
                                <asp:Label ID="Label1" runat="server">Status</asp:Label>
                            </div>
                            <div class="Popup-row-label">
                                <asp:Label ID="lblEligibility" runat="server" style="font-size:30px;font-weight:500"></asp:Label>
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
                                <asp:Label ID="Label24" runat="server">Anual Income<br />ಕುಟುಂಬದ ವಾರ್ಷಿಕ</asp:Label>
                            </div>
                            <div class="Popup-row-label">
                                <asp:Label ID="lblNCAnnualIncome" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="Popup-row-label">
                                <asp:Label ID="Label27" runat="server">Father/Parent Name<br />ತಂದೆ / ರಕ್ಷಕರ ಹೆಸರು</asp:Label>
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

                        <div id="divButtonSubmitApplication" class="form-row" runat="server">
                            <div class="Popup-row-label">
                            </div>
                            <div class="form-row-Botton">
                            </div>
                            <div class="form-row-Botton">
                            </div>
                            <div class="form-row-Botton">
                            </div>
                        </div>
                        <div id="divPrintApplication" visible="false" class="form-row" runat="server">
                            <asp:Button ID="btnPrintApplication" runat="server" CssClass="NeoButton" Text="Proceed" OnClientClick="return CasteCertificateHidePopup()" />

                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
                        <asp:Button ID="Button1" CssClass="Button" style="margin-left:20px; width:100px;border-color:red;margin-top:10px"  runat="server" Text="Logout" OnClick="btnLogout_Click" />

    </form>
</body>
</html>
