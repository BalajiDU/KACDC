<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Dashboard.aspx.cs" Inherits="KACDC.Service.Admin_Dashboard" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard KACDC</title>
     <link href="../CustomCSS/ApprovalPageCss/ModalDesign.css" rel="stylesheet" />
    <link href="~/CustomCss/ApprovalPageCss/FormStyles.css" rel="stylesheet" type="text/css" />
    <link href="~/CustomCss/ApprovalPageCss/LogoNameAnimation.css" rel="stylesheet" />
    <link href="~/CustomCss/ApprovalPageCss/SideNavBar.css" rel="stylesheet" />
    <link href="~/CustomCss/ApprovalPageCss/ToggleButton.css" rel="stylesheet" />
    <link href="~/CustomCss/ApprovalPageCss/TopNavBar.css" rel="stylesheet" />
    <link href="~/CustomCss/Dashboard.css" rel="stylesheet" />

     <script type="text/javascript">
    function myFunction(val) {
            val.classList.toggle('opened');
            val.setAttribute('aria-expanded', val.classList.contains('opened'));
            var x = document.getElementById("menu-1");
            if (x.style.display === "none") {
                x.style.display = "block";
                document.getElementById("myOverlay").style.display = "block";
            } else {
                x.style.display = "none";
                document.getElementById("myOverlay").style.display = "none";
            }
        }
    </script>
   
  <script src="https://code.jquery.com/jquery-3.4.1.js"></script>
    <script src="https://kit.fontawesome.com/a076d05399.js"></script>
    <link rel="shortcut icon" type="image/x-icon" href="../../Image/KACDC_PDF.jpg" />  
    <script src="../../Scripts/bootstrap.js"></script>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/1.11.2/jquery.js"></script>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.9.1/themes/base/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script src="http://code.jquery.com/ui/1.9.1/jquery-ui.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.5.1.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div id="topNSideMenu">
            <asp:UpdatePanel runat="server"><ContentTemplate>
            <nav class="DisplayMenu" id="menu-1" style="display: none;">
                <div class="navigation">
                    <div class="sidebar bar-block animate-left" id="mySidebar">
                        <ul class="mainmenu">
                            <li><a class="nav-item nav-link" id="nav-NavDashArAppnStatus-tab" data-toggle="tab" href="#nav-NavDashArAppnStatus" role="tab" aria-controls="nav-NavDashArAppnStatus" aria-selected="false">Arivu Application Status</a></li>
                            <li><a class="nav-item nav-link" id="nav-NavDashSeAppnStatus-tab" data-toggle="tab" href="#nav-NavDashSeAppnStatus" role="tab" aria-controls="nav-NavDashSeAppnStatus" aria-selected="false">Self Employment Application Status</a></li>
                            <li><a class="nav-item nav-link" id="nav-NavDashNotofication-tab" data-toggle="tab" href="#nav-NavDashNotofication" role="tab" aria-controls="nav-NavDashNotofication" aria-selected="false">Notification</a></li>
                           <%-- <li><a>Arivu</a>
                                <ul class="submenu">
                                    <li><a class="nav-item nav-link" id="nav-NavDashArAppnProcess-tab" data-toggle="tab" href="#nav-NavDashArAppnProcess" role="tab" aria-controls="nav-NavDashArAppnProcess" aria-selected="false">Application Peocess</a></li>
                                </ul>
                            </li>
                            <li><a>Self Employment</a>
                                <ul class="submenu">
                                    <li><a class="nav-item nav-link" id="nav-NavDashSeAppnProcess-tab" data-toggle="tab" href="#nav-NavDashSeAppnProcess" role="tab" aria-controls="nav-NavDashSeAppnProcess" aria-selected="false">Application Peocess</a></li>
                                </ul>
                            </li>--%>
                        </ul>
                    </div>
                </div>
            </nav>
            
            <div id="TopDataMenu">
                <nav class="NavBarInfo" style="z-index: 1;">
                    <ul>
                        <li>
                            <div class="toggleMenuButton" onclick="myFunction(this)" aria-label="Main Menu" style="z-index: 1; margin-top: -3px">
                                <svg width="75" height="60" viewBox="25 20 80 75">
                                    <path class="line line1" d="M 20,29.000046 H 80.000231 C 80.000231,29.000046 94.498839,28.817352 94.532987,66.711331 94.543142,77.980673 90.966081,81.670246 85.259173,81.668997 79.552261,81.667751 75.000211,74.999942 75.000211,74.999942 L 25.000021,25.000058" />
                                    <path class="line line2" d="M 20,50 H 80" />
                                    <path class="line line3" d="M 20,70.999954 H 80.000231 C 80.000231,70.999954 94.498839,71.182648 94.532987,33.288669 94.543142,22.019327 90.966081,18.329754 85.259173,18.331003 79.552261,18.332249 75.000211,25.000058 75.000211,25.000058 L 25.000021,74.999942" />
                                </svg>
                            </div>
                        </li>
                        <li class="logo">
                            <div class="GlowLogo">
                                <div class="HeaderClass">
                                    <span>K</span>
                                    <span>A</span>
                                    <span>C</span>
                                    <span>D</span>
                                    <span>C</span>
                                </div>
                            </div>
                        </li>
                        
                        <li class="Button">
                            <asp:Button ID="btnCWLogout" runat="server" Text="Logout" CssClass="logoutButton" OnClick="btnCWLogout_Click" /></li>
                        
                    </ul>
                </nav>
            </div>
            <div class="Viewoverlay View-animate-opacity" onclick="w3_close()" id="myOverlay" style="z-index:1"></div>
                </ContentTemplate></asp:UpdatePanel>
        </div>
        <section id="tabs">
            <div class="align-content-center">
                <div class="">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="tab-content py-3 px-3 px-sm-0 tab-content" id="nav-tabContent">
                                <div id="NavDashWelcome" class="flex-container tab-pane fade  " role="tabpanel" aria-labelledby="nav-NavDashWelcome-tab">
                                    <div class="navFormHeading">
                                        <asp:Label runat="server">WELCOME</asp:Label>
                                    </div>
                                    <div class="navFormWelcomeDistrict">
                                        <asp:Label ID="lblWelcomeDistCW" runat="server"></asp:Label>
                                    </div>
                                    <div id="divWelcomeStatistics">
                                        <table class="StatisticsTable" border="1">
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td colspan="2">Arivu Education Loan</td>
                                                <td colspan="2">Self EmpLoyment Loan</td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>Received</td>
                                                <td>Approved</td>
                                                <td>Received</td>
                                                <td>Approved</td>
                                            </tr>
                                            <tr>
                                                <td>Male</td>
                                                <td>
                                                    <asp:Label ID="lblCWARWelMaleCountReceived" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblCWARWelMaleCountApproved" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblCWSEWelMaleCountReceived" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblCWSEWelMaleCountApproved" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Female</td>
                                                <td>
                                                    <asp:Label ID="lblCWARWelFemaleCountReceived" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblCWARWelFemaleCountApproved" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblCWSEWelFemaleCountReceived" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblCWSEWelFemaleCountApproved" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Person With Disabilities</td>
                                                <td>
                                                    <asp:Label ID="lblCWARWelPWDCountReceived" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblCWARWelPWDCountApproved" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblCWSEWelPWDCountReceived" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblCWSEWelPWDCountApproved" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Widow</td>
                                                <td>NA</td>
                                                <td>NA</td>
                                                <td>
                                                    <asp:Label ID="lblCWSEWelWidowCountReceived" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblCWSEWelWidowCountApproved" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Divorced</td>
                                                <td>NA</td>
                                                <td>NA</td>
                                                <td>
                                                    <asp:Label ID="lblCWSEWelDivorcedCountReceived" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblCWSEWelDivorcedCountApproved" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </div>

                                    <asp:Panel ID="PnlNotification" runat="server" CssClass="modalPopup" Style="display: none; padding: 5px;min-width:50%;min-height:30%;overflow:inherit;max-width:80%;">
                                        <div class="form-row" style="justify-content: center">
                                            <div class="Popup-row-label-Heading">
                                                <asp:Label ID="Label26" class="" Style="margin-top: 20px;" runat="server" Text="Notification"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-row">
                                            <div class="Popup-row-label">
                                                
                                                <asp:Label ID="lblDisplayNotification"  runat="server" ></asp:Label>
                                            </div>
                                        </div>
                                        <footer>
                                            <div class="form-row" style="margin-bottom:20px;position:absolute;right:    0;bottom:   0;">

                                                <div class="Popup-row-label">
                                                    <asp:Button ID="Button9" runat="server" CssClass="DownloadButton" Text="OK" />
                                                </div>
                                            </div>
                                        </footer>
                                    </asp:Panel>

                            <asp:LinkButton ID="lnkNotification" runat="server"></asp:LinkButton>
                            <cc1:ModalPopupExtender ID="NotificationPopup" runat="server" TargetControlID="lnkNotification" PopupControlID="PnlNotification"
                                BackgroundCssClass="modalBackground">
                            </cc1:ModalPopupExtender>

                                </div>
                                <div class="tab-pane fade" id="nav-NavDashArAppnProcess" role="tabpanel" aria-labelledby="nav-NavDashArAppnProcess-tab">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div class="flex-container">
                                                <div class="navFormHeading">
                                                    <asp:Label runat="server">Arivu Application Process</asp:Label>
                                                </div>
                                                <div class="divGridview">
                                                    <div class="text-center">
                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="tab-pane fade" id="nav-NavDashArAppnStatus" role="tabpanel" aria-labelledby="nav-NavDashArAppnStatus-tab">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div class="flex-container">
                                                <div class="NeumorphicDiv">
                                                    <div class="form-row">
                                                        <div class="form-row-label-Heading" style="border-radius: 15px;">
                                                            <asp:Label runat="server">Arivu Application Status</asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="navFormBody">
                                                        <div class="formFlex-row">
                                                            <br />
                                                            <asp:Label runat="server" class="labelStyle1" Text="Application Number"></asp:Label>
                                                            <asp:TextBox ID="txtCwArApplicationStatus" class="textboxStyle1" runat="server"></asp:TextBox>
                                                            <asp:Button ID="btnCwArGetApplicationStatus" runat="server" Text="Get Status" OnClick="btnCwArGetApplicationStatus_Click" />
                                                            <asp:Panel ID="PnlCWArApplicationStatusDetails" runat="server" CssClass="modalPopup PopupPanel" Width="50%" Style="display: none;">
                                                                <div class="Popup-flex-container">
                                                                    <div class="">
                                                                        <div class="form-row" style="justify-content: center">
                                                                            <div class="Popup-row-label-Heading">
                                                                                <asp:Label ID="Label44" class="" runat="server" Text="Application Status"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-row">
                                                                            <div class="Popup-row-label">
                                                                                <asp:Label ID="Label47" runat="server">Application Number</asp:Label>
                                                                            </div>
                                                                            <div class="Popup-row-label">
                                                                                <asp:Label ID="lblCwARAppStatusApplicationNumber" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-row">
                                                                            <div class="Popup-row-label">
                                                                                <asp:Label ID="Label50" runat="server">Applicant Name</asp:Label>
                                                                            </div>
                                                                            <div class="Popup-row-label">
                                                                                <asp:Label ID="lblCwARAppStatusApplicationName" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-row">
                                                                            <div class="Popup-row-label">
                                                                                <asp:Label ID="Label53" runat="server">Case Worker</asp:Label>
                                                                            </div>
                                                                            <div class="Popup-row-label">
                                                                                <asp:Label ID="lblCwARAppStatusApplicationCWStat" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-row">
                                                                            <div class="Popup-row-label">
                                                                                <asp:Label ID="Label55" runat="server">District Manager</asp:Label>
                                                                            </div>
                                                                            <div class="Popup-row-label">
                                                                                <asp:Label ID="lblCwARAppStatusApplicationDMStat" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-row">
                                                                            <div class="Popup-row-label">
                                                                                <asp:Label ID="Label57" runat="server">CEO Committee</asp:Label>
                                                                            </div>
                                                                            <div class="Popup-row-label">
                                                                                <asp:Label ID="lblCwARAppStatusApplicationCEOStat" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                        <div class="form-row">
                                                                            <div class="Popup-row-label">
                                                                                <asp:Label ID="Label59" runat="server">Documentation</asp:Label>
                                                                            </div>
                                                                            <div class="Popup-row-label">
                                                                                <asp:Label ID="lblCwARAppStatusApplicationDOCStat" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>

                                                                        <div class="form-row">
                                                                            <div class="Popup-row-label">
                                                                                <asp:Label ID="Label61" runat="server">Zonal Manager</asp:Label>
                                                                            </div>
                                                                            <div class="Popup-row-label">
                                                                                <asp:Label ID="lblCwARAppStatusApplicationZMStat" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>

                                                                        <div class="form-row">

                                                                            <div class="form-row-Botton">
                                                                                <asp:Button ID="Button2" runat="server" CssClass="ViewButton" Text="OK" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </asp:Panel>

                                                            <asp:LinkButton ID="lnkCWArApplicationStatusDetailsFake" runat="server"></asp:LinkButton>
                                                            <cc1:ModalPopupExtender ID="CWArApplicationStatusDetailsPopup" runat="server" TargetControlID="lnkCWArApplicationStatusDetailsFake" PopupControlID="PnlCWArApplicationStatusDetails"
                                                                BackgroundCssClass="modalBackground">
                                                            </cc1:ModalPopupExtender>
                                                        </div>
                                                    </div>
                                                </div>
                                                </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="tab-pane fade in active" id="nav-NavDashNotofication" role="tabpanel" aria-labelledby="nav-NavDashNotofication-tab">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <div class="flex-container">
                                                <div class="NeumorphicDiv">
                                                    <div class="form-row">
                                                        <div class="form-row-label-Heading" style="border-radius: 15px;">
                                                            <asp:Label ID="Label2" class="" runat="server" Text="Case Worker"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="divGridview">
                                                        <div class="text-center">
                                                            <div id="divGetOTP" class="form-row" runat="server">
                                                                <div class="form-row-label"><br /><br />
                                                                    <asp:DropDownList ID="drpCWDistrict" Class="rowMargin txtcolor text-uppercase form-control" AutoPostBack="true" runat="server" ClientIDMode="Static" >
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="form-row-input">
                                                                    <asp:TextBox ID="txtCWNotificationMessage"  CssClass="NeoTextBox" TextMode="MultiLine" runat="server"></asp:TextBox><br />
                                                                </div>
                                                                <div class="form-row-Botton"><br /><br />
                                                                    <asp:Button ID="btnSetCwNotification" runat="server" CssClass="SubButton" Text="Set Notification" OnClick="btnSetCwNotification_Click" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="NeumorphicDiv">
                                                    <div class="form-row">
                                                        <div class="form-row-label-Heading" style="border-radius: 15px;">
                                                            <asp:Label ID="Label5" class="" runat="server" Text="District Manager"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="divGridview">
                                                        <div class="text-center">
                                                            <div id="div1" class="form-row" runat="server">
                                                                <div class="form-row-label">
                                                                    <br /><br />
                                                                    <asp:DropDownList ID="drpDMDistrict" Class="rowMargin txtcolor text-uppercase form-control" AutoPostBack="true" runat="server" ClientIDMode="Static">
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="form-row-input">
                                                                    <asp:TextBox ID="txtDMNotificationMessage" CssClass="NeoTextBox" TextMode="MultiLine" runat="server"></asp:TextBox><br />
                                                                </div>
                                                                <div class="form-row-Botton"><br /><br />
                                                                    <asp:Button ID="btnSetDmNotification" runat="server" CssClass="SubButton" Text="Set Notification" OnClick="btnSetDmNotification_Click" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="tab-pane fade" id="nav-NavDashSeAppnStatus" role="tabpanel" aria-labelledby="nav-NavDashSeAppnStatus-tab">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <div class="flex-container">
                                                <div class="NeumorphicDiv">
                                                    <div class="form-row">
                                                        <div class="form-row-label-Heading" style="border-radius: 15px;">
                                                            <asp:Label runat="server">Self Employment Application Status</asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="navFormBody">
                                                        <div class="formFlex-row">
                                                            <asp:Label runat="server" class="labelStyle1" Text="Application Number"></asp:Label>
                                                            <asp:TextBox ID="txtCwSEApplicationStatus" class="textboxStyle1" runat="server"></asp:TextBox>
                                                            <asp:Button ID="btnCwSEGetApplicationStatus" runat="server" Text="Get Status" OnClick="btnCwSEGetApplicationStatus_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                                 <asp:Panel ID="PnlCWSEApplicationStatusDetails" runat="server" CssClass="modalPopup PopupPanel" Width="50%" Style="display: none;">
                                                            <div class="Popup-flex-container">
                                                                <div class="">
                                                                    <div class="form-row" style="justify-content: center">
                                                                        <div class="Popup-row-label-Heading">
                                                                            <asp:Label ID="Label48" class="" runat="server" Text="Application Status"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-row">
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="Label52" runat="server">Application Number</asp:Label>
                                                                        </div>
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="lblCwSEAppStatusApplicationNumber" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-row">
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="Label56" runat="server">Applicant Name</asp:Label>
                                                                        </div>
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="lblCwSEAppStatusApplicationName" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-row">
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="Label60" runat="server">Case Worker</asp:Label>
                                                                        </div>
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="lblCwSEAppStatusApplicationCWStat" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-row">
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="Label63" runat="server">District Manager</asp:Label>
                                                                        </div>
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="lblCwSEAppStatusApplicationDMStat" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-row">
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="Label65" runat="server">CEO Committee</asp:Label>
                                                                        </div>
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="lblCwSEAppStatusApplicationCEOStat" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-row">
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="Label67" runat="server">Documentation</asp:Label>
                                                                        </div>
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="lblCwSEAppStatusApplicationDOCStat" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>

                                                                    <div class="form-row">
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="Label69" runat="server">Zonal Manager</asp:Label>
                                                                        </div>
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="lblCwSEAppStatusApplicationZMStat" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>

                                                                    <div class="form-row">

                                                                        <div class="form-row-Botton">
                                                                            <asp:Button ID="Button6" runat="server" CssClass="ViewButton" Text="OK" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </asp:Panel>

                                                <asp:LinkButton ID="lnkCWSEApplicationStatusDetailsFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="CWSEApplicationStatusDetailsPopup" runat="server" TargetControlID="lnkCWSEApplicationStatusDetailsFake" PopupControlID="PnlCWSEApplicationStatusDetails"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </form>
</body>
</html>
