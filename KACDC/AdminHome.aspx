<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="KACDC.AdminHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .btn-hover:hover {
            background-position: 100% 0;
            moz-transition: all .6s ease-in-out;
            -o-transition: all .6s ease-in-out;
            -webkit-transition: all .6s ease-in-out;
            transition: all .6s ease-in-out;
            color: black;
        }

        .btn-hover {
            border-radius: 3%;
            width: 100%;
            font-size: 16px;
            font-weight: 600;
            color: #fff;
            cursor: pointer;
            height: 35px;
            text-align: center;
            border: none;
            background-size: 300% 100%;
            color: dimgrey;
            moz-transition: all .4s ease-in-out;
            -o-transition: all .4s ease-in-out;
            -webkit-transition: all .4s ease-in-out;
            transition: all .4s ease-in-out;
        }

        .rowMargin {
            margin: 2%;
        }

        .btn-hover.btncolor {
            background-image: linear-gradient(to right, #80cef2 0%, #aee6fc 51%, #5bc1f0 100%);
        }

        .btn-hover.btnSubcolor {
            background-image: linear-gradient(to right, #80cef2 0%, #aee6fc 51%, #5cf759 100%);
        }

        .txtcolor {
            /*border-image-source: linear-gradient(179deg, #80cef2 30%, #5bc1f0 31%, #aee6fc 30%);*/
            border-radius: 3%;
            border-width: 1pt;
            border-image-slice: 1;
            border-image-source: -moz-linear-gradient(-45deg, #80cef2 0%, #4ccafc 100%, #24c1ff 100%);
            border-image-source: -webkit-linear-gradient(-45deg, #80cef2 0%, #4ccafc 100%, #24c1ff 100%);
            border-image-source: linear-gradient(135deg, #80cef2 0%, #4ccafc 100%, #24c1ff 100%);
        }

            .txtcolor:focus {
                color: #5bc1f0;
                border-width: 1.5pt;
                background-color: #fff;
                border-color: #80bdff;
                outline: 0;
                box-shadow: 0 1px 2px 0 rgba(65, 132, 234, 0.75);
            }
    </style>
    <style type="text/css">
        .clsSection {
            padding: 20px 0;
        }

            .clsSection .section-title {
                text-align: center;
                color: darkblue;
                margin-bottom: 50px;
                text-transform: uppercase;
            }

        #tabs {
            color: #6b6b6b;
        }

            #tabs h6.section-title {
                color: darkblue;
            }

            #tabs .nav-tabs .nav-item.show .nav-link, .nav-tabs .nav-link.active {
                color: #f3f3f3;
                border-color: transparent transparent #f3f3f3;
                border-bottom: 4px solid !important;
                font-size: 20px;
                font-weight: bold;
            }

            #tabs .nav-tabs .nav-link {
                border: 1px solid transparent;
                border-top-left-radius: .25rem;
                border-top-right-radius: .25rem;
                color: darkslategray;
                font-size: 20px;
            }
    </style>
    <style>
         .GridView{
            border-collapse:collapse;
            text-align:center;
            width:inherit;
        }
        .GridView td 
        {
                padding: 10px;
                border: 1px solid #c1c1c1;
                font-size: 1em;
        }

        .GridView th {
            padding: 4px 2px;
            text-align :center;
            background-color :#CCCCCC;
            color:black;
            vertical-align :middle;
            text-align :center;
            font-weight: bold;
        }
            .GridView th a {
                color: White;
                text-decoration: none;
            }
        .GridHeader {
            background-color :#CCCCCC;
            color:black;
            vertical-align :middle;
            text-align :center;
            font-weight: bold;
        }

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
            display: flex;
            justify-content: center;
            padding: 25px;
            margin: 20px;
            margin-top: 10px;
            text-align: center;
            align-items: center;
            letter-spacing: 1.5px;
            font-family: "poppins", sans-serief;
        }

        .flex-container {
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .SectionMarginTop {
            margin-top: 0;
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

        .flex-container div {
            text-align: center;
        }

        .NeoButton {
            border-radius: 7px;
            height:40px;
            width:150px;
            font-size: 16px;
            background: transparent;
            border: none;
            outline: none;
            color: #fff;
            background: rgba(3,154,244,0.8);
            cursor: pointer;
            border-style: none;
            outline: none;
            background: #eeecec;
            color: black;
            flex-wrap: wrap;
            display:flex;
            margin-left:10px;
            -webkit-appearance: button;
            outline: none;
            box-shadow: 8px 8px 10px #797878, -8px -8px 10px #ffffff;
        }

            .NeoButton:hover {
                box-shadow: 5px 5px 10px #d4d2d2, -5px -5px 10px #ffffff;
            }

            .NeoButton:active {
                box-shadow: inset 5px 5px 10px #d4d2d2, inset -5px -5px 10px #ffffff;
            }

        .NeoTextBox {
            box-sizing: border-box;
            width: 180px;
            height: 40px;
            font-size: 20px;
            border: none;
            padding: 14px;
            margin:30px;
            outline: none;
            display:flex;
            flex-wrap: wrap;
            text-align: center;
            background: #eeecec;
            border-radius: 10px;
            text-shadow: 1px 1px 0 #fff;
            color:#303030;
            box-shadow: inset 5px 5px 10px #dddbdb, inset -5px -5px 10px #fffdfd;
        }

            .NeoTextBox:focus {
                box-shadow: inset 2px 2px 2px #e2e0e0, inset -2px -2px 2px #faf8f8;
            }

            .PopupTextBox{
            box-sizing: border-box;
            width: 280px;
            height: 50px;
            font-size: 18px;
            padding: 7px;
            border: none;
            outline: none;
            display:flex;
            flex-wrap: wrap;
            text-align: center;
            background: #eeecec;
            border-radius: 10px;
            text-shadow: 1px 1px 0 #fff;
            color:#303030;
            box-shadow: inset 5px 5px 10px #dddbdb, inset -5px -5px 10px #fffdfd;
        }

        .modalPopup{
  margin: 20px auto 0 auto;
  padding: 30px;
  background-color: #eeecec;
          
  border-radius: 25px;
            box-shadow:  10px 10px 20px #cac9c9, 
             -10px -10px 20px #ffffff;
            margin: 20px;
            margin-top: 10px;
            font-size:20px;
            align-items: center;
            letter-spacing: 1.5px;
            font-family: "poppins", sans-serief;
        }
       
        .form-row {
          padding: 10px 0;
          display: flex;
        }
        .form-row-label {
  padding-right: 10px;
    flex:1;
}

.form-row-input {
  flex: 1;
}
.modalBackground {
	background-color:Black;
	filter:alpha(opacity=90);
	opacity:0.8;
}
    </style>
    <script type="text/javascript">
        $(function () {
            BlockUI("divDMKA");
            $.blockUI.defaults.css = {};
        });
        $(function () {
            BlockUI("divDMEN");
            $.blockUI.defaults.css = {};
        });
        $(function () {
            BlockUI("divZMEN");
            $.blockUI.defaults.css = {};
        });
        $(function () {
            BlockUI("divZMKA");
            $.blockUI.defaults.css = {};
        });
        $(function () {
            BlockUI("divHOEN");
            $.blockUI.defaults.css = {};
        });
        $(function () {
            BlockUI("divHOKA");
            $.blockUI.defaults.css = {};
        });
         $(function () {
            BlockUI("divUsrCre");
            $.blockUI.defaults.css = {};
        });
         $(function () {
            BlockUI("divSliderImg");
            $.blockUI.defaults.css = {};
        });
        function BlockUI(elementID) {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_beginRequest(function () {
                $("#" + elementID).block({
                    message: '<div align = "center">' + '< img src = "Image/loadingAnim.gif" /></div>',
                    css: {},
                    overlayCSS: { backgroundColor: '#000000', opacity: 0.6, border: '3px solid #63B2EB' }
                });
            });
            prm.add_endRequest(function () {
                $("#" + elementID).unblock();
            });
        };
    </script>

    <style>
        * {
            padding: 0;
            margin: 0;
            list-style: none;
            text-decoration: none;
        }

        body {
            font-family: 'Roboto', sans-serif;
            border-radius: 5px;
        }

        .sidebar {
            position: fixed;
            width: 220px;
            height: 100%;
            z-index: 100;
            left:0;
            background: #042331;
            transition: width .5s ease;
            box-shadow: 4px 7px 10px rgba(0,0,0,.4);
            cursor: pointer;
        }

            .sidebar .AdmHmHeader {
                font-size: 22px;
                color: white;
                line-height: 50px;
                text-align: center;
                background: #063146;
                user-select: none;
                cursor:default;
            }

            .sidebar .AdmHmUl a {
                display: block;
                height: 100%;
                width: 100%;
                /*line-height: 65px;*/
                font-size: 20px;
                color: white;
                padding-left: 30px;
                box-sizing: border-box;
                border-bottom: 1px solid black;
                border-top: 1px solid rgba(255,255,255,.1);
                transition: .4s;
                flex-direction:column;
                top:auto;
                bottom:auto;
            }

       .AdmHmUl .AdmHmLi:hover a {
            padding-left: 50px;
        }

        .sidebar .AdmHmUl a i {
            margin-right: 16px;
        }

        label #btn, label #cancel {
            position: absolute;
            background: #042331;
            border-radius: 3px;
            cursor: pointer;
        }

        label #btn {
            left: 40px;
            top: 25px;
            font-size: 35px;
            color: white;
            padding: 6px 12px;
            transition: all .5s;
        }

        label #cancel {
            z-index: 1111;
            left: -195px;
            top: 17px;
            font-size: 30px;
            color: #0a5275;
            padding: 4px 9px;
            transition: all .5s ease;
        }

        .clsSection {
            background: url(bg.jpeg) no-repeat;
            background-position: center;
            background-size: cover;
            height: 100vh;
            transition: all .5s;
            margin-left: 280px;
        }
        .LogoutButton{
            display: block;
                height: 100%;
                width: 100%;
                line-height: 40px;
                font-size: 20px;
                color: white;
                margin-left: -40px;
                box-sizing: border-box;
                border-bottom: 1px solid black;
                border-top: 1px solid rgba(255,255,255,.1);
                transition: .4s;
                background:transparent;
                color:red;
        }
        .AdmHmLi{
            /*border:2px solid white;*/
            height:40px;
            list-style: none;
        }
    </style>

     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/1.11.2/jquery.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.blockUI.js"></script>
<%--    <asp:Button ID="btnLogout1" runat="server" Text="Logout" OnClick="btnLogout_Click" />--%>
    <div class="Page">
    <div class="sidebar">
        <header class="AdmHmHeader" style="height:50px">KACDC</header>
        <ul class="AdmHmUl" style="flex-direction:column;top: 10px;float:left">
            <li class="AdmHmLi"><a class="nav-item nav-link active fas fa-qrcode" id="nav-homePage-tab" data-toggle="tab" href="#nav-homePage" role="tab" aria-controls="nav-homePage" aria-selected="true">Home Page</a></li>
            <li class="AdmHmLi"><a class="nav-item nav-link" id="nav-DM-tab" data-toggle="tab" href="#nav-DM" role="tab" aria-controls="nav-DM" aria-selected="false">District Manager</a></li>
            <li class="AdmHmLi"><a class="nav-item nav-link" id="nav-ZM-tab" data-toggle="tab" href="#nav-ZM" role="tab" aria-controls="nav-ZM" aria-selected="false">Zonal Manager</a></li>
            <li class="AdmHmLi"><a class="nav-item nav-link" id="nav-HO-tab" data-toggle="tab" href="#nav-HO" role="tab" aria-controls="nav-HO" aria-selected="false">Head Office</a></li>
            <li class="AdmHmLi"><a class="nav-item nav-link" id="nav-User-tab" data-toggle="tab" href="#nav-User" role="tab" aria-controls="nav-User" aria-selected="false">Users</a></li>
            <li class="AdmHmLi"><a class="nav-item nav-link" id="nav-Slider-tab" data-toggle="tab" href="#nav-Slider" role="tab" aria-controls="nav-Slider" aria-selected="false">Slider</a></li>
            <li class="AdmHmLi"><a class="nav-item nav-link" id="nav-MPIC-tab" data-toggle="tab" href="#nav-MPIC" role="tab" aria-controls="nav-MPIC" aria-selected="false">MPIC Target</a></li>
            <li class="AdmHmLi"><a> <asp:Button ID="btnLogout" class="LogoutButton" runat="server" Text="Logout" OnClick="btnLogout_Click" /></a> </li>
        </ul>
    </div>
    <section id="tabs" class="clsSection">    
        <div class="align-content-center">
            <%--<div class="col-xs-12 ">
                <nav>
                    <div class="nav nav-tabs nav-fill" id="nav-tab" role="tablist">
                        <a class="nav-item nav-link active" id="nav-homePage-tab" data-toggle="tab" href="#nav-homePage" role="tab" aria-controls="nav-homePage" aria-selected="true">Home Page</a>
                        <a class="nav-item nav-link" id="nav-DM-tab" data-toggle="tab" href="#nav-DM" role="tab" aria-controls="nav-DM" aria-selected="false">District Manager</a>
                        <a class="nav-item nav-link" id="nav-ZM-tab" data-toggle="tab" href="#nav-ZM" role="tab" aria-controls="nav-ZM" aria-selected="false">Zonal Manager</a>
                        <a class="nav-item nav-link" id="nav-HO-tab" data-toggle="tab" href="#nav-HO" role="tab" aria-controls="nav-HO" aria-selected="false">Head Office</a>
                        <a class="nav-item nav-link" id="nav-User-tab" data-toggle="tab" href="#nav-User" role="tab" aria-controls="nav-User" aria-selected="false">Users</a>
                        <a class="nav-item nav-link" id="nav-Slider-tab" data-toggle="tab" href="#nav-Slider" role="tab" aria-controls="nav-Slider" aria-selected="false">Slider</a>
                    </div>
                </nav>
            </div>--%>
            <div class="">
                <div class="row">
                    <div class="col-md-12">
                        <div class="tab-content py-3 px-3 px-sm-0" id="nav-tabContent">
                            <div class="tab-pane fade  active" id="nav-homePage" role="tabpanel" aria-labelledby="nav-homePage-tab">
                                <table style="width: 100%" class="AdmHmTable">
                                   
                                    <tr>
                                        <td style="height: 26px">CM Name</td>
                                        <td style="height: 26px">
                                            <asp:TextBox ID="txtCMName" Class="rowMargin txtcolor text-uppercase form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td style="height: 26px">
                                            <asp:Button ID="btnCMName" Class="btn btn-hover btncolor" runat="server" Text="Update" OnClick="btnCMName_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>CM Photo</td>
                                        <td>
                                            <asp:Image ID="ImgCM" runat="server" Height="100px" Width="100px" />
                                            <asp:FileUpload ID="FileImgCM" Class="rowMargin txtcolor text-uppercase" accept="image/*" Width="180px" runat="server" ForeColor="Black" />
                                            <asp:Label ID="lblImgCM" runat="server" class="rowMargin text-uppercase txtcolor custom-file-label"></asp:Label>
                                            <asp:RegularExpressionValidator ID="regexValidator" runat="server" ControlToValidate="FileImgCM" ErrorMessage="Only Image file is allowed" ForeColor="Red" ValidationExpression="([a-zA-Z0-9\s_\-:])+(.*\.([jJ][pP][gG]|[jJ][pP][eE][gG]|[Pp][Nn][Gg])$)"></asp:RegularExpressionValidator>

                                        </td>
                                        <td>
                                            <asp:Button ID="btnCMPhoto" Class="btn btn-hover btncolor" runat="server" Text="Update" OnClick="btnCMPhoto_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 26px">Minister Name</td>
                                        <td style="height: 26px">
                                            <asp:TextBox ID="txtMinisterName" Class="rowMargin txtcolor text-uppercase form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td style="height: 26px">
                                            <asp:Button ID="btnMinister" Class="btn btn-hover btncolor" runat="server" Text="Update" OnClick="btnMinister_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Minister Photo</td>
                                        <td>
                                            <asp:Image ID="ImgMinister" runat="server" Height="100px" Width="100px" />
                                            <asp:FileUpload ID="FileImgMinister" Class="rowMargin txtcolor text-uppercase" Width="180px" runat="server" ForeColor="Black" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="FileImgMinister" ErrorMessage="Only Image file is allowed" ForeColor="Red" ValidationExpression="([a-zA-Z0-9\s_\-:])+(.*\.([jJ][pP][gG]|[jJ][pP][eE][gG]|[Pp][Nn][Gg])$)"></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnMinisterPhoto" Class="btn btn-hover btncolor" runat="server" Text="Update" OnClick="btnMinisterPhoto_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Chairman Name</td>
                                        <td style="height: 26px">
                                            <asp:TextBox ID="txtChairmanName" Class="rowMargin txtcolor text-uppercase form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td style="height: 26px">
                                            <asp:Button ID="btnChairman" Class="btn btn-hover btncolor" runat="server" Text="Update" OnClick="btnChairman_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Chairman Photo</td>
                                        <td>
                                            <asp:Image ID="ImgChairman" runat="server" Height="100px" Width="100px" />
                                            <asp:FileUpload ID="FileImgChairman" Class="rowMargin txtcolor text-uppercase" Width="180px" runat="server" ForeColor="Black" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="FileImgChairman" ErrorMessage="Only Image file is allowed" ForeColor="Red" ValidationExpression="([a-zA-Z0-9\s_\-:])+(.*\.([jJ][pP][gG]|[jJ][pP][eE][gG]|[Pp][Nn][Gg])$)"></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnChairmanPhoto" Class="btn btn-hover btncolor" runat="server" Text="Update" OnClick="btnChairmanPhoto_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>GOK LOGO</td>
                                        <td>
                                            <asp:Image ID="ImgGOK" runat="server" Height="100px" Width="100px" />
                                            <asp:FileUpload ID="FileImgGOK" Class="rowMargin txtcolor text-uppercase" Width="180px" runat="server" ForeColor="Black" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="FileImgGOK" ErrorMessage="Only Image file is allowed" ForeColor="Red" ValidationExpression="([a-zA-Z0-9\s_\-:])+(.*\.([jJ][pP][gG]|[jJ][pP][eE][gG]|[Pp][Nn][Gg])$)"></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnGOK" Class="btn btn-hover btncolor" runat="server" Text="Update" OnClick="btnGOK_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>KACDC LOGO</td>
                                        <td>
                                            <asp:Image ID="ImgKACDC" runat="server" Height="100px" Width="100px" />
                                            <asp:FileUpload ID="FileImgKacdc" Class="rowMargin txtcolor text-uppercase" Width="180px" runat="server" ForeColor="Black" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="FileImgKacdc" ErrorMessage="Only Image file is allowed" ForeColor="Red" ValidationExpression="([a-zA-Z0-9\s_\-:])+(.*\.([jJ][pP][gG]|[jJ][pP][eE][gG]|[Pp][Nn][Gg])$)"></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnImgKACDC" Class="btn btn-hover btncolor" runat="server" Text="Update" OnClick="btnImgKACDC_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Arivu Application Enable</td>
                                        <td>
                                            <asp:DropDownList ID="drpArivuEnable" Class="rowMargin txtcolor text-uppercase form-control" runat="server" ClientIDMode="Static">
                                                <asp:ListItem>--SELECT--</asp:ListItem>
                                                <asp:ListItem Value="TRUE">TRUE</asp:ListItem>
                                                <asp:ListItem Value="FALSE">FALSE</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td>
                                            <asp:Button ID="btnArivuEnable" Class="btn btn-hover btncolor" runat="server" Text="Update" OnClick="btnArivuEnable_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Self Employment Enable</td>
                                        <td>
                                            <asp:DropDownList ID="drpSEEnable" Class="rowMargin txtcolor text-uppercase form-control" runat="server" ClientIDMode="Static">
                                                <asp:ListItem>--SELECT--</asp:ListItem>
                                                <asp:ListItem Value="TRUE">TRUE</asp:ListItem>
                                                <asp:ListItem Value="FALSE">FALSE</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td>
                                            <asp:Button ID="btnSEEnable" Class="btn btn-hover btncolor" runat="server" Text="Update" OnClick="btnSEEnable_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Arivu Renewal</td>
                                        <td>
                                            <asp:DropDownList ID="drpARRenewal" Class="rowMargin txtcolor text-uppercase form-control" runat="server" ClientIDMode="Static">
                                                <asp:ListItem>--SELECT--</asp:ListItem>
                                                <asp:ListItem Value="TRUE">TRUE</asp:ListItem>
                                                <asp:ListItem Value="FALSE">FALSE</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td>
                                            <asp:Button ID="btnARRenewalEnable" Class="btn btn-hover btncolor" runat="server" Text="Update" OnClick="btnARRenewalEnable_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </div>
                            <div class="tab-pane fade" id="nav-DM" role="tabpanel" aria-labelledby="nav-DM-tab">
                                <div id="divDMKA" style="padding: 10px; width: 100%">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvDMKan" runat="server" AutoGenerateColumns="false" OnRowDataBound="DMKAOnRowDataBound"
                                                DataKeyNames="SlNo" OnRowEditing="DMKAOnRowEditing" OnRowCancelingEdit="DMKAOnRowCancelingEdit"
                                                PageSize="10" AllowPaging="true" OnPageIndexChanging="DMKAOnPaging" OnRowUpdating="DMKAOnRowUpdating"
                                                OnRowDeleting="DMKAOnRowDeleting" EmptyDataText="No records has been added." Width="100%">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="Sl No" ItemStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDMKASlNo" runat="server" Text='<%# Eval("SlNo")%>' />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="District" ItemStyle-Width="18%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDMKADistrict" runat="server" Text='<%# Eval("District")%>' />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtDMKADistrict" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Text='<%# Eval("District")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Officer and Designation" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDMKAOfficerandDesignation" runat="server" Text='<%# Eval("[OfficerandDesignation]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtDMKAOfficerandDesignation" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Text='<%# Eval("[OfficerandDesignation]")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="EMail" ItemStyle-Width="25%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDMKAEMail" runat="server" Text='<%# Eval("[EMail]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtDMKAEMail" runat="server" Class="rowMargin txtcolor text-uppercase form-control" Text='<%# Eval("[EMail]")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Telephone" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDMKATelephone" runat="server" Text='<%# Eval("[Telephone]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtDMKATelephone" runat="server" Class="rowMargin txtcolor text-uppercase form-control" Text='<%# Eval("[Telephone]")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Address" ItemStyle-Width="30%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDMKAAddress" runat="server" Text='<%# Eval("[Address]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtDMKAAddress" TextMode="MultiLine" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Text='<%# Eval("[Address]")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                                                        ItemStyle-Width="15%" />
                                                </Columns>
                                            </asp:GridView>
                                            <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                                                <tr>
                                                    <td style="width: 10%">
                                                        <br />
                                                    </td>
                                                    <td style="width: 15%">District:<br />
                                                        <asp:TextBox ID="txtDMKADistrict" Class="rowMargin txtcolor text-uppercase form-control" Style="width: 98%" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 15%">Officer and Designation:<br />
                                                        <asp:TextBox ID="txtDMKAOfficerandDesignation" Class="rowMargin txtcolor text-uppercase form-control" Style="width: 98%" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 15%">E Mail:<br />
                                                        <asp:TextBox ID="txtDMKAEMail" Style="width: 98%" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 15%">Telephone:<br />
                                                        <asp:TextBox ID="txtDMKATelephone" Style="width: 98%" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 30%">Address:<br />
                                                        <asp:TextBox ID="txtDMKAAddress" Style="width: 98%" Class="rowMargin txtcolor text-uppercase form-control" TextMode="MultiLine" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 15%">
                                                        <asp:Button ID="btnAdd" Class="btn btn-hover btncolor"  runat="server" Text="Add" OnClick="DMKAInsert" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div id="divDMEN" style="padding: 10px; width: 100%">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvDMENn" runat="server" AutoGenerateColumns="false" OnRowDataBound="DMENOnRowDataBound"
                                                DataKeyNames="SlNo" OnRowEditing="DMENOnRowEditing" OnRowCancelingEdit="DMENOnRowCancelingEdit"
                                                PageSize="10" AllowPaging="true" OnPageIndexChanging="DMENOnPaging" OnRowUpdating="DMENOnRowUpdating"
                                                OnRowDeleting="DMENOnRowDeleting" EmptyDataText="No records has been added." Width="100%">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="Sl No" ItemStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDMENSlNo" runat="server" Text='<%# Eval("SlNo")%>' />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="District" ItemStyle-Width="18%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDMENDistrict" runat="server" Text='<%# Eval("District")%>' />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtDMENDistrict" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Text='<%# Eval("District")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Officer and Designation" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDMENOfficerandDesignation" runat="server" Text='<%# Eval("[OfficerandDesignation]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtDMENOfficerandDesignation" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Text='<%# Eval("[OfficerandDesignation]")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="EMail" ItemStyle-Width="25%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDMENEMail" runat="server" Text='<%# Eval("[EMail]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtDMENEMail" runat="server" Class="rowMargin txtcolor text-uppercase form-control" Text='<%# Eval("[EMail]")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Telephone" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDMENTelephone" runat="server" Text='<%# Eval("[Telephone]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtDMENTelephone" runat="server" Class="rowMargin txtcolor text-uppercase form-control" Text='<%# Eval("[Telephone]")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Address" ItemStyle-Width="30%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDMENAddress" runat="server" Text='<%# Eval("[Address]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtDMENAddress" TextMode="MultiLine" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Text='<%# Eval("[Address]")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                                                        ItemStyle-Width="15%" />
                                                </Columns>
                                            </asp:GridView>
                                            <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                                                <tr>
                                                    <td style="width: 10%">
                                                        <br />
                                                    </td>
                                                    <td style="width: 15%">District:<br />
                                                        <asp:TextBox ID="txtDMENDistrict" Style="width: 98%" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 15%">Officer and Designation:<br />
                                                        <asp:TextBox ID="txtDMENOfficerandDesignation" Style="width: 98%" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 15%">E Mail:<br />
                                                        <asp:TextBox ID="txtDMENEMail" Style="width: 98%" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 15%">Telephone:<br />
                                                        <asp:TextBox ID="txtDMENTelephone" Style="width: 98%" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 30%">Address:<br />
                                                        <asp:TextBox ID="txtDMENAddress" Style="width: 98%" Class="rowMargin txtcolor text-uppercase form-control" TextMode="MultiLine" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 15%">
                                                        <asp:Button ID="btnDMENAdd" Class="btn btn-hover btncolor" runat="server" Text="Add" OnClick="DMENInsert" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="nav-ZM" role="tabpanel" aria-labelledby="nav-ZM-tab">
                                <div id="divZMKA" style="padding: 10px; width: 100%">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvZMKAn" runat="server" AutoGenerateColumns="false" OnRowDataBound="ZMKAOnRowDataBound"
                                                DataKeyNames="SlNo" OnRowEditing="ZMKAOnRowEditing" OnRowCancelingEdit="ZMKAOnRowCancelingEdit"
                                                PageSize="10" AllowPaging="true" OnPageIndexChanging="ZMKAOnPaging" OnRowUpdating="ZMKAOnRowUpdating"
                                                OnRowDeleting="ZMKAOnRowDeleting" EmptyDataText="No records has been added." Width="100%">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="Sl No" ItemStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblZMKASlNo" runat="server" Text='<%# Eval("SlNo")%>' />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="District" ItemStyle-Width="18%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblZMKADistrict" runat="server" Text='<%# Eval("District")%>' />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtZMKADistrict" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Text='<%# Eval("District")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Officer and Designation" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblZMKAOfficerandDesignation" runat="server" Text='<%# Eval("[OfficerandDesignation]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtZMKAOfficerandDesignation" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Text='<%# Eval("[OfficerandDesignation]")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="EMail" ItemStyle-Width="25%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblZMKAEMail" runat="server" Text='<%# Eval("[EMail]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtZMKAEMail" runat="server" Class="rowMargin txtcolor text-uppercase form-control" Text='<%# Eval("[EMail]")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Telephone" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblZMKATelephone" runat="server" Text='<%# Eval("[Telephone]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtZMKATelephone" runat="server" Class="rowMargin txtcolor text-uppercase form-control" Text='<%# Eval("[Telephone]")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Address" ItemStyle-Width="30%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblZMKAAddress" runat="server" Text='<%# Eval("[Address]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtZMKAAddress" TextMode="MultiLine" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Text='<%# Eval("[Address]")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                                                        ItemStyle-Width="15%" />
                                                </Columns>
                                            </asp:GridView>
                                            <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                                                <tr>
                                                    <td style="width: 10%">
                                                        <br />
                                                    </td>
                                                    <td style="width: 15%">District:<br />
                                                        <asp:TextBox ID="txtZMKADistrict" Class="rowMargin txtcolor text-uppercase form-control" Style="width: 98%" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 15%">Officer and Designation:<br />
                                                        <asp:TextBox ID="txtZMKAOfficerandDesignation" Class="rowMargin txtcolor text-uppercase form-control" Style="width: 98%" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 15%">E Mail:<br />
                                                        <asp:TextBox ID="txtZMKAEMail" Style="width: 98%" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 15%">Telephone:<br />
                                                        <asp:TextBox ID="txtZMKATelephone" Style="width: 98%" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 30%">Address:<br />
                                                        <asp:TextBox ID="txtZMKAAddress" Style="width: 98%" Class="rowMargin txtcolor text-uppercase form-control" TextMode="MultiLine" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 15%">
                                                        <asp:Button ID="btnZMKAAdd" Class="btn btn-hover btncolor"  runat="server" Text="Add" OnClick="ZMKAInsert" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div id="divZMEN" style="padding: 10px; width: 100%">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvZMENn" runat="server" AutoGenerateColumns="false" OnRowDataBound="ZMENOnRowDataBound"
                                                DataKeyNames="SlNo" OnRowEditing="ZMENOnRowEditing" OnRowCancelingEdit="ZMENOnRowCancelingEdit"
                                                PageSize="10" AllowPaging="true" OnPageIndexChanging="ZMENOnPaging" OnRowUpdating="ZMENOnRowUpdating"
                                                OnRowDeleting="ZMENOnRowDeleting" EmptyDataText="No records has been added." Width="100%">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="Sl No" ItemStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblZMENSlNo" runat="server" Text='<%# Eval("SlNo")%>' />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="District" ItemStyle-Width="18%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblZMENDistrict" runat="server" Text='<%# Eval("District")%>' />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtZMENDistrict" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Text='<%# Eval("District")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Officer and Designation" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblZMENOfficerandDesignation" runat="server" Text='<%# Eval("[OfficerandDesignation]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtZMENOfficerandDesignation" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Text='<%# Eval("[OfficerandDesignation]")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="EMail" ItemStyle-Width="25%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblZMENEMail" runat="server" Text='<%# Eval("[EMail]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtZMENEMail" runat="server" Class="rowMargin txtcolor text-uppercase form-control" Text='<%# Eval("[EMail]")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Telephone" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblZMENTelephone" runat="server" Text='<%# Eval("[Telephone]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtZMENTelephone" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Text='<%# Eval("[Telephone]")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Address" ItemStyle-Width="30%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblZMENAddress" runat="server" Text='<%# Eval("[Address]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtZMENAddress" Class="rowMargin txtcolor text-uppercase form-control" TextMode="MultiLine" runat="server" Text='<%# Eval("[Address]")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                                                        ItemStyle-Width="15%" />
                                                </Columns>
                                            </asp:GridView>
                                            <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                                                <tr>
                                                    <td style="width: 10%">
                                                        <br />
                                                    </td>
                                                    <td style="width: 15%">District:<br />
                                                        <asp:TextBox ID="txtZMENDistrict" Class="rowMargin txtcolor text-uppercase form-control" Style="width: 98%" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 15%">Officer and Designation:<br />
                                                        <asp:TextBox ID="txtZMENOfficerandDesignation" Class="rowMargin txtcolor text-uppercase form-control" Style="width: 98%" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 15%">E Mail:<br />
                                                        <asp:TextBox ID="txtZMENEMail" Style="width: 98%" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 15%">Telephone:<br />
                                                        <asp:TextBox ID="txtZMENTelephone" Style="width: 98%" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 30%">Address:<br />
                                                        <asp:TextBox ID="txtZMENAddress" Style="width: 98%" Class="rowMargin txtcolor text-uppercase form-control" TextMode="MultiLine" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 15%">
                                                        <asp:Button ID="btnZMENAdd" Class="btn btn-hover btncolor" runat="server" Text="Add" OnClick="ZMENInsert" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="nav-HO" role="tabpanel" aria-labelledby="nav-HO-tab">
                                <div id="divHOKA" style="padding: 10px; width: 100%">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvHOKAn" runat="server" AutoGenerateColumns="false" OnRowDataBound="HOKAOnRowDataBound"
                                                DataKeyNames="SlNo" OnRowEditing="HOKAOnRowEditing" OnRowCancelingEdit="HOKAOnRowCancelingEdit"
                                                PageSize="10" AllowPaging="true" OnPageIndexChanging="HOKAOnPaging" OnRowUpdating="HOKAOnRowUpdating"
                                                OnRowDeleting="HOKAOnRowDeleting" EmptyDataText="No records has been added." Width="100%">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="Sl No" ItemStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHOKASlNo" runat="server" Text='<%# Eval("SlNo")%>' />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Name" ItemStyle-Width="18%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHOKADistrict" runat="server" Text='<%# Eval("District")%>' />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtHOKADistrict" runat="server" Class="rowMargin txtcolor text-uppercase form-control" Text='<%# Eval("District")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Designation" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHOKAOfficerandDesignation" runat="server" Text='<%# Eval("[OfficerandDesignation]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtHOKAOfficerandDesignation" runat="server" Class="rowMargin txtcolor text-uppercase form-control" Text='<%# Eval("[OfficerandDesignation]")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="EMail" ItemStyle-Width="25%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHOKAEMail" runat="server" Text='<%# Eval("[EMail]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtHOKAEMail" runat="server" Class="rowMargin txtcolor text-uppercase form-control" Text='<%# Eval("[EMail]")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Mobile" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHOKATelephone" runat="server" Text='<%# Eval("[Telephone]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtHOKATelephone" runat="server" Class="rowMargin txtcolor text-uppercase form-control" Text='<%# Eval("[Telephone]")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Address" ItemStyle-Width="30%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHOKAAddress" runat="server" Text='<%# Eval("[Address]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtHOKAAddress" TextMode="MultiLine" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Text='<%# Eval("[Address]")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                                                        ItemStyle-Width="15%" />
                                                </Columns>
                                            </asp:GridView>
                                            <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                                                <tr>
                                                    <td style="width: 10%">
                                                        <br />
                                                    </td>
                                                    <td style="width: 15%">Name:<br />
                                                        <asp:TextBox ID="txtHOKADistrict" Class="rowMargin txtcolor text-uppercase form-control" Style="width: 98%" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 15%">Designation:<br />
                                                        <asp:TextBox ID="txtHOKAOfficerandDesignation" Class="rowMargin txtcolor text-uppercase form-control" Style="width: 98%" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 15%">E Mail:<br />
                                                        <asp:TextBox ID="txtHOKAEMail" Style="width: 98%" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 15%">Mobile:<br />
                                                        <asp:TextBox ID="txtHOKATelephone" Style="width: 98%" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 30%">Address:<br />
                                                        <asp:TextBox ID="txtHOKAAddress" Style="width: 98%" Class="rowMargin txtcolor text-uppercase form-control" TextMode="MultiLine" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 15%">
                                                        <asp:Button ID="btnHOKAAdd" Class="btn btn-hover btncolor" runat="server" Text="Add" OnClick="HOKAInsert" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div id="divHOEN" style="padding: 10px; width: 100%">
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvHOENn" runat="server" AutoGenerateColumns="false" OnRowDataBound="HOENOnRowDataBound"
                                                DataKeyNames="SlNo" OnRowEditing="HOENOnRowEditing" OnRowCancelingEdit="HOENOnRowCancelingEdit"
                                                PageSize="10" AllowPaging="true" OnPageIndexChanging="HOENOnPaging" OnRowUpdating="HOENOnRowUpdating"
                                                OnRowDeleting="HOENOnRowDeleting" EmptyDataText="No records has been added." Width="100%">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="Sl No" ItemStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHOENSlNo" runat="server" Text='<%# Eval("SlNo")%>' />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Name" ItemStyle-Width="18%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHOENDistrict" runat="server" Text='<%# Eval("District")%>' />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtHOENDistrict" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Text='<%# Eval("District")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Designation" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHOENOfficerandDesignation" runat="server" Text='<%# Eval("[OfficerandDesignation]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtHOENOfficerandDesignation" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Text='<%# Eval("[OfficerandDesignation]")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="EMail" ItemStyle-Width="25%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHOENEMail" runat="server" Text='<%# Eval("[EMail]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtHOENEMail" runat="server" Class="rowMargin txtcolor text-uppercase form-control" Text='<%# Eval("[EMail]")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Mobile" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHOENTelephone" runat="server" Text='<%# Eval("[Telephone]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtHOENTelephone" runat="server" Class="rowMargin txtcolor text-uppercase form-control" Text='<%# Eval("[Telephone]")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Address" ItemStyle-Width="30%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHOENAddress" runat="server" Text='<%# Eval("[Address]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtHOENAddress" TextMode="MultiLine" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Text='<%# Eval("[Address]")%>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                                                        ItemStyle-Width="15%" />
                                                </Columns>
                                            </asp:GridView>
                                            <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                                                <tr>
                                                    <td style="width: 10%">
                                                        <br />
                                                    </td>
                                                    <td style="width: 15%">Name:<br />
                                                        <asp:TextBox ID="txtHOENDistrict" Style="width: 98%" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 15%">Designation:<br />
                                                        <asp:TextBox ID="txtHOENOfficerandDesignation" Style="width: 98%" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 15%">E Mail:<br />
                                                        <asp:TextBox ID="txtHOENEMail" Style="width: 98%" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Width="140" />
                                                    </td>

                                                    <td style="width: 15%">Mobile:<br />
                                                        <asp:TextBox ID="txtHOENTelephone" Style="width: 98%" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Width="140" />
                                                    </td>

                                                    <td style="width: 30%">Address:<br />
                                                        <asp:TextBox ID="txtHOENAddress" Style="width: 98%" Class="rowMargin txtcolor text-uppercase form-control" TextMode="MultiLine" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 15%">
                                                        <asp:Button ID="btnHOENAdd" Class="btn btn-hover btncolor" runat="server" Text="Add" OnClick="HOENInsert" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="nav-User" role="tabpanel" aria-labelledby="nav-User-tab">
                                <div id="divUsrCre"  style="padding: 10px; width: 100%">
                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvUsrCren" runat="server" style="padding: 10px;" AutoGenerateColumns="false" OnRowDataBound="UsrCreOnRowDataBound"
                                                DataKeyNames="SlNo" OnRowEditing="UsrCreOnRowEditing" OnRowCancelingEdit="UsrCreOnRowCancelingEdit"
                                                PageSize="10" AllowPaging="true" OnPageIndexChanging="UsrCreOnPaging" OnRowUpdating="UsrCreOnRowUpdating"
                                                OnRowDeleting="UsrCreOnRowDeleting" EmptyDataText="No records has been added." Width="100%">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="Sl No" ItemStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUsrCreSlNo" runat="server" Text='<%# Eval("SlNo")%>' />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="District" ItemStyle-Width="18%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUsrCreDistrict" runat="server" Text='<%# Eval("District")%>' />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="User Name" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUsrCreUserName" runat="server" Text='<%# Eval("[UserName]")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="User Type" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUsrCreUserType" runat="server" Text='<%# Eval("[UserType]")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Active" ItemStyle-Width="30%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUsrCreActive" runat="server" Text='<%# Eval("[Active]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <%--<asp:TextBox ID="txtUsrCreActive" TextMode="MultiLine" runat="server" Text='<%# Eval("[Active]")%>' />--%>
                                                            <asp:DropDownList ID="txtUsrCreActive" ItemStyle-Width="30%" Class="rowMargin txtcolor text-uppercase form-control" runat="server" ClientIDMode="Static">
                                                                <asp:ListItem>--SELECT--</asp:ListItem>
                                                                <asp:ListItem Value="TRUE">TRUE</asp:ListItem>
                                                                <asp:ListItem Value="FALSE">FALSE</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                                                        ItemStyle-Width="15%" />
                                                </Columns>
                                            </asp:GridView>
                                            <asp:GridView ID="gvUsers" runat="server" style="padding: 10px;" AutoGenerateColumns="false" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" OnRowDataBound="OnRowDataBound" RowStyle-BackColor="#A1DCF2">
                                                <Columns>
                                                    <asp:BoundField DataField="Username" HeaderText="Username" />
                                                    <asp:BoundField DataField="Password" HeaderText="Encrypted Password" />
                                                </Columns>
                                            </asp:GridView>
                                            <table border="1" cellpadding="0" cellspacing="0"style="padding: 10px; border-collapse: collapse">
                                                <tr>
                                                    <td style="width: 10%">
                                                        <br />
                                                    </td>
                                                    <td style="width: 15%">District:<br />
                                                        <%--                                <asp:TextBox ID="txtUsrCreDistrict" Style="width: 98%" runat="server" Width="140" />--%>
                                                        <asp:DropDownList ID="txtUsrCreDistrict" Class="rowMargin txtcolor text-uppercase form-control" AutoPostBack="true" runat="server" ClientIDMode="Static">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 15%">User Name:<br />
                                                        <asp:TextBox ID="txtUsrCreUserName" Style="width: 98%" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Width="140" />
                                                    </td>
                                                    <td style="width: 15%">Password:<br />
                                                        <asp:TextBox ID="txtUsrCrePassword" Style="width: 98%" Class="rowMargin txtcolor text-uppercase form-control" runat="server" Width="140" />
                                                    </td>

                                                    <td style="width: 15%">User Type:<br />
                                                        <asp:DropDownList ID="txtUsrCreUserType" Class="rowMargin txtcolor text-uppercase form-control" runat="server" ClientIDMode="Static">
                                                            <asp:ListItem>--SELECT--</asp:ListItem>
                                                            <asp:ListItem Value="ADMIN">ADMIN</asp:ListItem>
                                                            <asp:ListItem Value="DISTRICTMANAGER">DISTRICT MANAGER</asp:ListItem>
                                                            <asp:ListItem Value="CASEWORKER">CASE WORKER</asp:ListItem>
                                                            <asp:ListItem Value="ZONALMANAGER">ZONAL MANAGER</asp:ListItem>
                                                            <asp:ListItem Value="DATAVIEW">DATA VIEW</asp:ListItem>
                                                            <asp:ListItem Value="APPDOWNLOAD">APPLICATION DOWNLOAD</asp:ListItem>
                                                            <asp:ListItem Value="ADMINAPPROVE">ADMIN APPROVE</asp:ListItem>
                                                            <asp:ListItem Value="CHECKRD">CHECK RD</asp:ListItem>
                                                            <asp:ListItem Value="MESSAGESERVICE">MESSAGE SERVICE</asp:ListItem>
                                                            <asp:ListItem Value="DASHBOARD">DASHBOARD</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>

                                                    <td style="width: 30%">Active:<br />
                                                        <%--                                <asp:TextBox ID="txtUsrCreActive" Style="width: 98%" TextMode="MultiLine" runat="server" Width="140" />--%>
                                                        <asp:DropDownList ID="txtUsrCreActive" Class="rowMargin txtcolor text-uppercase form-control" runat="server" ClientIDMode="Static">
                                                            <asp:ListItem>--SELECT--</asp:ListItem>
                                                            <asp:ListItem Value="TRUE">TRUE</asp:ListItem>
                                                            <asp:ListItem Value="FALSE">FALSE</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 15%">
                                                        <asp:Button ID="btnUsrCreAdd" Class="btn btn-hover btncolor" runat="server" Text="Add" OnClick="UsrCreInsert" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                   
                                                    <td colspan="6">
                                                        <asp:Label ID="lblAddUserError" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 10%">&nbsp;</td>
                                                    <td colspan="2">
                                                        <asp:DropDownList ID="drpUser" Class="rowMargin txtcolor  form-control" AutoPostBack="true" runat="server" ClientIDMode="Static">
                                                        </asp:DropDownList></td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="txtNewPassword" Class="rowMargin txtcolor form-control" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 30%">&nbsp;</td>
                                                    <td style="width: 15%">
                                                        <asp:Button ID="btnUpdatePwd" runat="server" Class="btn btn-hover btncolor" OnClick="btnUpdatePwd_Click" Text="Update Password" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 10%">&nbsp;</td>
                                                    <td colspan="6">
                                                        <asp:Label ID="lblPwdError" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <br />
                                    <hr />
                                </div>
                            </div>
                            <div class="tab-pane fade" id="nav-Slider" role="tabpanel" aria-labelledby="nav-Slider-tab">
                                <div id="divSliderImg" style="padding: 10px; width: 100%">
                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvSliderImg" runat="server" DataKeyNames="SlNo" PageSize="10" AllowPaging="true" OnPageIndexChanging="SliderOnPaging"
                                                AutoGenerateColumns="false" SliderOnRowDataBound="SliderOnRowDataBound" OnRowDeleting="SliderOnRowDeleting" EmptyDataText="No records has been added."
                                                Width="100%">
                                                <Columns>
                                                    <asp:BoundField DataField="SlNo" HeaderText="Sl No" />
                                                    <asp:BoundField DataField="Heading" HeaderText="Image Id" />
                                                    <asp:BoundField DataField="Captions" HeaderText="Name" />
                                                    <asp:TemplateField HeaderText="Image">
                                                        <ItemTemplate>
                                                            <asp:Image ID="ImgSlider" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:CommandField ButtonType="Link" ShowDeleteButton="true" ItemStyle-Width="15%" />
                                                </Columns>
                                            </asp:GridView>
                                            <br />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                                        <tr>
                                            <td style="width: 10%">
                                                <br />
                                            </td>
                                            <td style="width: 15%">Caption:<br />
                                                <asp:TextBox ID="txtSliderHeading" Class="rowMargin txtcolor text-uppercase form-control" Style="width: 98%" runat="server" Width="140" />
                                            </td>
                                            <td style="width: 15%">Caption:<br />
                                                <asp:TextBox ID="txtSliderCaption" Class="rowMargin txtcolor text-uppercase form-control" Style="width: 98%" runat="server" Width="140" />
                                            </td>
                                            <td style="width: 15%">
                                                <asp:FileUpload ID="FileSliderImg"  runat="server" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnUploadSlider" Class="btn btn-hover btncolor" runat="server" Text="Upload" OnClick="SliderUpload" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="nav-MPIC" role="tabpanel" aria-labelledby="nav-MPIC-tab">
                                <div id="divMpic" style="padding: 10px; width: 100%">
                                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                        <ContentTemplate>

                                            <div class="Neumorphic" style="flex-direction: column;">
                                                <div class="flex-container">
                                                    <asp:Label runat="server" Text="Self Employment"></asp:Label>
                                                </div>
                                                <div class="flex-container">
                                                    <div class="NestedNeumorphic">
                                                        <asp:Label runat="server" Text="Select District"></asp:Label>
                                                    </div>
                                                    <div class="">
                                                        <asp:DropDownList ID="drpSEMPICDistrict" runat="server" class="NeuoDropdown" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="">
                                                        <asp:TextBox ID="txtSEPhysical" Visible="true" CssClass="NeoTextBox" placeholder="Physical" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="">
                                                        <asp:TextBox ID="txtSEFinancial" Visible="true" CssClass="NeoTextBox" placeholder="Financial" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="">
                                                        <asp:Button ID="btnSEMpicUpdate" runat="server" CssClass="NeoButton" Text="Update" OnClick="btnSEMpicUpdate_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="Neumorphic" style="flex-direction: column;">
                                                <div class="flex-container">
                                                    <asp:Label runat="server" Text="Arivu"></asp:Label>
                                                </div>
                                                <div class="flex-container">
                                                    <div class="NestedNeumorphic">
                                                        <asp:Label runat="server" Text="Select District"></asp:Label>
                                                    </div>
                                                    <div class="">
                                                        <asp:DropDownList ID="drpARMPICDistrict" runat="server" class="NeuoDropdown" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="">
                                                        <asp:TextBox ID="txtARPhysical" Visible="true" CssClass="NeoTextBox" placeholder="Physical" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="">
                                                        <asp:TextBox ID="txtARFinancial" Visible="true" CssClass="NeoTextBox" placeholder="Financial" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="">
                                                        <asp:Button ID="btnARMpicUpdate" runat="server" CssClass="NeoButton" Text="Update" OnClick="btnARMpicUpdate_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="flex-container" style="flex-direction: row;font-size: medium">
                                                <div class="Neumorphic" >
                                                    <div id="divArivuDoc" >

                                                        <h2>Arivu</h2>
                                                        <asp:GridView ID="GvARMPICFill"  runat="server" Style="font-size: 20px ; " CssClass="GridView col-lg-offset-2" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                                                            AutoGenerateColumns="false">
                                                            <Columns>
                                                                <asp:BoundField DataField="Id" HeaderText="Sl N0" />
                                                                <asp:BoundField DataField="FinancialYear" HeaderText="Financial Year" />
                                                                <asp:BoundField DataField="District" HeaderText="District" />
                                                                <asp:BoundField DataField="PhysicalTarget" HeaderText="Physical Target" />
                                                                <asp:BoundField DataField="FinancialTarget" HeaderText="Financial Target" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                                <div class="Neumorphic">
                                                    <div id="divSEDoc">
                                                        <h2>Self Employment</h2>
                                                        <asp:GridView ID="GvSEMPICFill" runat="server" Style="font-size: 20px" CssClass="GridView col-lg-offset-2" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                                                            AutoGenerateColumns="false">
                                                            <Columns>
                                                                <asp:BoundField DataField="Id" HeaderText="Sl N0" />
                                                                <asp:BoundField DataField="FinancialYear" HeaderText="Financial Year" />
                                                                <asp:BoundField DataField="District" HeaderText="District" />
                                                                <asp:BoundField DataField="PhysicalTarget" HeaderText="Physical Target" />
                                                                <asp:BoundField DataField="FinancialTarget" HeaderText="Financial Target" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>

                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
              <%--  <div class="tab-pane fade" id="nav-contact" role="tabpanel" aria-labelledby="nav-contact-tab">
                </div>
                <div class="tab-pane fade" id="nav-about" role="tabpanel" aria-labelledby="nav-about-tab">
                </div>--%>
            </div>
        </div>
    </section>
    </div>
   

</asp:Content>
