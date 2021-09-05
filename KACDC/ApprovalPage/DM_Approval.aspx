<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DM_Approval.aspx.cs" Inherits="KACDC.ApprovalPage.DM_Approval" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>District Manager</title>
    <link href="../CustomCSS/ApprovalPageCss/ModalDesign.css" rel="stylesheet" />
      <link href="~/CustomCss/ApprovalPageCss/FormStyles.css" rel="stylesheet" type="text/css" />
    <link href="~/CustomCss/ApprovalPageCss/LogoNameAnimation.css" rel="stylesheet" />
    <link href="~/CustomCss/ApprovalPageCss/SideNavBar.css" rel="stylesheet" />
    <link href="~/CustomCss/ApprovalPageCss/ToggleButton.css" rel="stylesheet" />
    <link href="~/CustomCss/ApprovalPageCss/TopNavBar.css" rel="stylesheet" />

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
    <script type="text/javascript">
        function CheckNumber(evt,Amount) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (evt.keyCode == 9 || charCode == 8 || charCode == 37 || charCode == 39 || charCode == 13 || charCode == 16 || charCode == 35 || charCode == 36 || charCode == 38 || charCode == 40 || charCode == 46)
                return true;
            if (charCode > 31 && (((charCode >= 48 && charCode <= 57) || (e.keyCode >= 96 && e.keyCode <= 105)) || charCode == 46)) {
                if (Amount.value.length <= 5) {
                    return true;
                } else {
                    alert('Amount Must be less then 100000');
                    return true;
                }

            }
            else {
                //alert('Please Enter Numeric values.');
                return false;
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



   
    <script type="text/javascript">
        function BlockUI(elementID) {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_beginRequest(function () {
                $("#" + elementID).block({
                    message: '<div align = "center">' + '< img src = "../Image/loadingAnim.gif" /></div>',
                    css: {},
                    overlayCSS: { backgroundColor: '#000000', opacity: 0.6, border: '3px solid #63B2EB' }
                });
            });
            prm.add_endRequest(function () {
                $("#" + elementID).unblock();
            });
        };
    </script>
</head>
<body>
   
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div id="topNSideMenu">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <nav class="DisplayMenu" id="menu-1" style="display: none;">
                        <div class="navigation">
                            <div class="sidebar bar-block animate-left" id="mySidebar">
                                <ul class="mainmenu">
                                    <li><a><i class="fas fa-university" style="color:palegoldenrod;width:30px;"></i> Arivu</a>
                                        <ul class="submenu">
                                            <li><a class="nav-item nav-link" id="nav-NavDMARAppnProcess-tab" data-toggle="tab" href="#nav-NavDMARAppnProcess" role="tab" aria-controls="nav-NavDMARAppnProcess" aria-selected="false">District Manager</a></li>
                                            <li><a class="nav-item nav-link" id="nav-NavCEOARAppnProcess-tab" data-toggle="tab" href="#nav-NavCEOARAppnProcess" role="tab" aria-controls="nav-NavCEOARAppnProcess" aria-selected="false">CEO Committee</a></li>
                                            <li><a class="nav-item nav-link" id="nav-NavDOCARAppnProcess-tab" data-toggle="tab" href="#nav-NavDOCARAppnProcess" role="tab" aria-controls="nav-NavDOCARAppnProcess" aria-selected="false">Document Verification</a></li>
                                            <li><a class="nav-item nav-link" id="nav-NavDOCARRenewalProcess-tab" data-toggle="tab" href="#nav-NavDOCARRenewalProcess" role="tab" aria-controls="nav-NavDOCARRenewalProcess" aria-selected="false">Renewal Process</a></li>
                                            <li><a class="nav-item nav-link" id="nav-NavDMARAppnStatus-tab" data-toggle="tab" href="#nav-NavDMARAppnStatus" role="tab" aria-controls="nav-NavDMARAppnStatus" aria-selected="false">Application Status</a></li>
                                        </ul>
                                    </li>
                                    <li><a><i class="fas fa-briefcase" style="color:palegoldenrod;width:30px;"></i> Self Employment</a>
                                        <ul class="submenu">
                                            <li><a class="nav-item nav-link" id="nav-NavDMSEAppnProcess-tab" data-toggle="tab" href="#nav-NavDMSEAppnProcess" role="tab" aria-controls="nav-NavDMSEAppnProcess" aria-selected="false">District Manager</a></li>
                                            <li><a class="nav-item nav-link" id="nav-NavCEOSEAppnProcess-tab" data-toggle="tab" href="#nav-NavCEOSEAppnProcess" role="tab" aria-controls="nav-NavCEOSEAppnProcess" aria-selected="false">CEO Committee</a></li>
                                            <li><a class="nav-item nav-link" id="nav-NavDOCSEAppnProcess-tab" data-toggle="tab" href="#nav-NavDOCSEAppnProcess" role="tab" aria-controls="nav-NavDOCSEAppnProcess" aria-selected="false">Document Verification</a></li>
                                            <li><a class="nav-item nav-link" id="nav-NavDMSEAppnStatus-tab" data-toggle="tab" href="#nav-NavDMSEAppnStatus" role="tab" aria-controls="nav-NavDMSEAppnStatus" aria-selected="false">Application Status</a></li>
                                            <li><a class="nav-item nav-link" id="nav-NavDMSEMobileUpdate-tab" data-toggle="tab" href="#nav-NavDMSEMobileUpdate" role="tab" aria-controls="nav-NavDMSEMobileUpdate" aria-selected="false">Application Update</a></li>
                                        </ul>
                                    </li>
                                    <li><a href="https://www.appsheet.com/start/9c690410-435b-4720-9f3b-1573419b9a40" style="text-decoration: none; color:black; text-align:left"  target="_blank" ><i class="fa fa-inr" style="color:palegoldenrod;width:25px;margin-left: 5px;align-content:center"></i> Recovery Statistics</a></li>
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

                                <li class="DisplayValueType"><a visible="false"></a></li>
                                <li class="items">
                                    <asp:Label CssClass="DisplayStatData" Visible="false" ID="lblArivuStatistics" runat="server"></asp:Label></li>
                                <li class="DisplayValueType"><a visible="false"></a></li>
                                <li class="items">
                                    <asp:Label CssClass="DisplayStatData" Visible="false" ID="lblSEStatistics" runat="server"></asp:Label></li>
                                <li class="Button">
                                    <asp:Button ID="btnDMLogout" runat="server" Text="Logout" CssClass="logoutButton" OnClick="btnDMLogout_Click" /></li>

                            </ul>
                        </nav>
                    </div>
                    <div class="Viewoverlay View-animate-opacity" onclick="w3_close()" id="myOverlay" style="z-index: 1"></div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <section id="tabs">
            <div class="align-content-center">
                <div class="">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="tab-content py-3 px-3 px-sm-0 tab-content" id="nav-tabContent">
                                <div id="NavCwWelcome" class="flex-container tab-pane fade in active " role="tabpanel" aria-labelledby="nav-NavCwWelcome-tab">
                                    <div class="navFormHeading">
                                        <asp:Label runat="server">WELCOME</asp:Label>
                                    </div>
                                    <div class="navFormWelcomeDistrict">
                                        <asp:Label ID="lblWelcomeDistCW" runat="server"></asp:Label>
                                    </div>
                                    <div class="col-xs-8" style="margin-left: 17%; margin-top: 15px">
                                        <nav>
                                            <div class="nav nav-tabs nav-fill" id="nav-tab" role="tablist">
                                                <a class="nav-item nav-link in active" style="margin-right: 2px; border: 2px solid green; color: goldenrod; background-color: #e3fdff; font-size: 15px; font-weight: Bold" id="nav-DMStat-tab" data-toggle="tab" href="#nav-DMStat" role="tab" aria-controls="nav-DMStat" aria-selected="true">District Manager</a>
                                                <a class="nav-item nav-link" id="nav-CeoStat-tab" style="margin-right: 2px; border: 2px solid green; color: goldenrod; background-color: #e3fdff; font-size: 15px; font-weight: Bold" data-toggle="tab" href="#nav-CeoStat" role="tab" aria-controls="nav-CeoStat" aria-selected="false">CEO Committee</a>
                                                <a class="nav-item nav-link" id="nav-DocStat-tab" style="margin-right: 0px; border: 2px solid green; color: goldenrod; background-color: #e3fdff; font-size: 15px; font-weight: Bold" data-toggle="tab" href="#nav-DocStat" role="tab" aria-controls="nav-DocStat" aria-selected="false">Document Verification</a>
                                            </div>
                                        </nav>
                                    </div>
                                    <div class="container" style="margin-top: 50px">
                                        <div class="row">
                                            <div class="col-xs-12">
                                                <div class="tab-content py-3 px-3 px-sm-0" id="nav-tabContent1">
                                                    <div class="tab-pane fade in active" id="nav-DMStat" role="tabpanel" aria-labelledby="nav-DMStat-tab">
                                                        <div class="navFormWelcomeDistrictStat">
                                                            <asp:Label runat="server" Text="District Manager"></asp:Label>
                                                        </div>
                                                        <div id="divWelcomeStatistics">
                                                            <table class="StatisticsTable" border="1">
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td colspan="3">Arivu Education Loan</td>
                                                                    <td colspan="3">Self EmpLoyment Loan</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td>Total Applications</td>
                                                                    <td>Case Worker Approved</td>
                                                                    <td> DM Approved</td>
                                                                    <td>Total Applications</td>
                                                                    <td>Case Worker Approved</td>
                                                                    <td> DM Approved</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Male</td>

                                                                    <td>
                                                                        <asp:Label ID="lblDMARWelMaleCountReceived" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDMARWelMaleCWApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDMARWelMaleCountApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDMSEWelMaleCountReceived" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDMSEWelMaleCWApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDMSEWelMaleCountApproved" runat="server"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Female</td>
                                                                    <td>
                                                                        <asp:Label ID="lblDMARWelFemaleCountReceived" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDMARWelFemaleCWApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDMARWelFemaleCountApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDMSEWelFemaleCountReceived" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDMSEWelFemaleCWApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDMSEWelFemaleCountApproved" runat="server"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Person With Disabilities</td>
                                                                    <td>
                                                                        <asp:Label ID="lblDMARWelPWDCountReceived" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDMARWelPWDCWApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDMARWelPWDCountApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDMSEWelPWDCountReceived" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDMSEWelPWDCWApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDMSEWelPWDCountApproved" runat="server"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Widow</td>
                                                                    <td>NA</td>
                                                                    <td>NA</td>
                                                                    <td>NA</td>
                                                                    <td>
                                                                        <asp:Label ID="lblDMSEWelWidowCountReceived" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDMSEWelWidowCWApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDMSEWelWidowCountApproved" runat="server"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Divorced</td>
                                                                    <td>NA</td>
                                                                    <td>NA</td>
                                                                    <td>NA</td>
                                                                    <td>
                                                                        <asp:Label ID="lblDMSEWelDivorcedCountReceived" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDMSEWelDivorcedCWApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDMSEWelDivorcedCountApproved" runat="server"></asp:Label></td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </div>
                                                    <div class="tab-pane fade" id="nav-CeoStat" role="tabpanel" aria-labelledby="nav-CeoStat-tab">
                                                        <div class="navFormWelcomeDistrictStat">
                                                            <asp:Label runat="server" Text="CEO Committee"></asp:Label>
                                                        </div>
                                                        <div id="divWelcomeStatisticsCEO">
                                                            <table class="StatisticsTable" border="1">
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td colspan="3">Arivu Education Loan</td>
                                                                    <td colspan="3">Self EmpLoyment Loan</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td>Total Applications</td>
                                                                    <td>DM Approved</td>
                                                                    <td>CEO Approved</td>
                                                                    <td>Total Applications</td>
                                                                    <td>DM Approved</td>
                                                                    <td>CEO Approved</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Male</td>

                                                                    <td>
                                                                        <asp:Label ID="lblCEOARWelMaleCountReceived" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblCEOARWelMaleDMApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblCEOARWelMaleCountApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblCEOSEWelMaleCountReceived" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblCEOSEWelMaleDMApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblCEOSEWelMaleCountApproved" runat="server"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Female</td>
                                                                    <td>
                                                                        <asp:Label ID="lblCEOARWelFemaleCountReceived" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblCEOARWelFemaleDMApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblCEOARWelFemaleCountApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblCEOSEWelFemaleCountReceived" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblCEOSEWelFemaleDMApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblCEOSEWelFemaleCountApproved" runat="server"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Person With Disabilities</td>
                                                                    <td>
                                                                        <asp:Label ID="lblCEOARWelPWDCountReceived" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblCEOARWelPWDDMApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblCEOARWelPWDCountApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblCEOSEWelPWDCountReceived" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblCEOSEWelPWDDMApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblCEOSEWelPWDCountApproved" runat="server"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Widow</td>
                                                                    <td>NA</td>
                                                                    <td>NA</td>
                                                                    <td>NA</td>
                                                                    <td>
                                                                        <asp:Label ID="lblCEOSEWelWidowCountReceived" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblCEOSEWelWidowDMApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblCEOSEWelWidowCountApproved" runat="server"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Divorced</td>
                                                                    <td>NA</td>
                                                                    <td>NA</td>
                                                                    <td>NA</td>
                                                                    <td>
                                                                        <asp:Label ID="lblCEOSEWelDivorcedCountReceived" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblCEOSEWelDivorcedDMApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblCEOSEWelDivorcedCountApproved" runat="server"></asp:Label></td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </div>
                                                    <div class="tab-pane fade" id="nav-DocStat" role="tabpanel" aria-labelledby="nav-DocStat-tab">
                                                        <div class="navFormWelcomeDistrictStat">
                                                            <asp:Label runat="server" Text="Documentation"></asp:Label>
                                                        </div>
                                                        <div id="divWelcomeStatisticsDoc">
                                                            <table class="StatisticsTable" border="1">
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td colspan="3">Arivu Education Loan</td>
                                                                    <td colspan="3">Self EmpLoyment Loan</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;</td>
                                                                    <td>Total Applications</td>
                                                                    <td>CEO Approved</td>
                                                                    <td>DOC Approved</td>
                                                                    <td>Total Applications</td>
                                                                    <td>CEO Approved</td>
                                                                    <td>DOC Approved</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Male</td>

                                                                    <td>
                                                                        <asp:Label ID="lblDOCARWelMaleCountReceived" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDOCARWelMaleCEOApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDOCARWelMaleCountApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDOCSEWelMaleCountReceived" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDOCSEWelMaleCEOApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDOCSEWelMaleCountApproved" runat="server"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Female</td>
                                                                    <td>
                                                                        <asp:Label ID="lblDOCARWelFemaleCountReceived" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDOCARWelFemaleCEOApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDOCARWelFemaleCountApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDOCSEWelFemaleCountReceived" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDOCSEWelFemaleCEOApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDOCSEWelFemaleCountApproved" runat="server"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Person With Disabilities</td>
                                                                    <td>
                                                                        <asp:Label ID="lblDOCARWelPWDCountReceived" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDOCARWelPWDCEOApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDOCARWelPWDCountApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDOCSEWelPWDCountReceived" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDOCSEWelPWDCEOApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDOCSEWelPWDCountApproved" runat="server"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Widow</td>
                                                                    <td>NA</td>
                                                                    <td>NA</td>
                                                                    <td>NA</td>
                                                                    <td>
                                                                        <asp:Label ID="lblDOCSEWelWidowCountReceived" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDOCSEWelWidowCEOApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDOCSEWelWidowCountApproved" runat="server"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Divorced</td>
                                                                    <td>NA</td>
                                                                    <td>NA</td>
                                                                    <td>NA</td>
                                                                    <td>
                                                                        <asp:Label ID="lblDOCSEWelDivorcedCountReceived" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDOCSEWelDivorcedCEOApproved" runat="server"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblDOCSEWelDivorcedCountApproved" runat="server"></asp:Label></td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    
                                    <asp:Panel ID="PnlNotification" runat="server" CssClass="modalPopup" Style="display: none; padding: 5px;min-width:50%;min-height:30%;overflow:inherit;max-width:80%;">
                                        <div class="form-row" style="justify-content: center">
                                            <div class="Popup-row-label-Heading">
                                                <asp:Label ID="Label220" class="" Style="margin-top: 20px;" runat="server" Text="Notification"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-row">
                                            <div class="Popup-row-label">
                                                
                                                <asp:Label ID="lblDisplayNotification"  runat="server" style="text-transform: none;" ></asp:Label>
                                            </div>
                                        </div>
                                        <footer>
                                            <div class="form-row" style="margin-bottom:20px;position:absolute;right:    0;bottom:   0;">

                                                <div class="Popup-row-label">
                                                    <asp:Button ID="Button36" runat="server" CssClass="DownloadButton" Text="OK" />
                                                </div>
                                            </div>
                                        </footer>
                                    </asp:Panel>

                            <asp:LinkButton ID="lnkNotification" runat="server"></asp:LinkButton>
                            <cc1:ModalPopupExtender ID="NotificationPopup" runat="server" TargetControlID="lnkNotification" PopupControlID="PnlNotification"
                                BackgroundCssClass="modalBackground">
                            </cc1:ModalPopupExtender>
                                    <div class="text-center">
                                        <asp:Button ID="btnOldProcess" class="DownloadButton" Text="Continue To 2019-20 Process" ForeColor="LightGoldenrodYellow" runat="server" OnClick="btnOldProcess_Click" />
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="nav-NavDMARAppnProcess" role="tabpanel" aria-labelledby="nav-NavDMARAppnProcess-tab">
                                    <asp:UpdatePanel ID="UpdatePanelDMARAppnProcess" runat="server" UpdateMode="Conditional">
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnDMARDownloadExcelForCEO" />
                                        </Triggers>
                                        <ContentTemplate>
                                            <div class="flex-container">
                                                <div class="navFormHeading">
                                                    <asp:Label runat="server">Arivu Application Process - District Manager</asp:Label>
                                                </div>
                                                <div class="divGridview">
                                                    <div class="text-center">
                                                        <asp:GridView ID="gvDMARApproveProcess" runat="server" class="GridView" AutoGenerateColumns="False" OnRowDataBound="gvDMARApproveProcess_RowDataBound" DataKeyNames="ApplicationNumber,ApplicantName,RDNumber,AadharNum,ClgHostel" Style="align-content: center;">
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ApplicationNumber")%>
                                                                    </ItemTemplate>

                                                                    <HeaderStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="180px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Applicant Name" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ApplicantName") + "<br />" + Eval("Gender")+ "<br />"+"PH : "+ Eval("PhysicallyChallenged") %>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="RD Number " ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("RDNumber")+ "<br />"+  Eval("ApplicantNameNC") + "<br />" + "Income: " + Eval("AnualIncome")%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="160px" Font-Bold="true" ForeColor="Red" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="DOB" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%#Eval("ApplicantDob")+ " ("+ Eval("Age") + ")" %>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="160px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Email ID &amp; Mobile Number" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("EmailID") + "<br />" +  Eval("MobileNumber")%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="180px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Address" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ParmanentAddress") + "<br />" + Eval("ParDistrict")+"(D)"+ "<br />" + Eval("ParTaluk")+"(T)"+ "<br />" + Eval("ParConstituency")+"(C)"+ "<br />" + Eval("ParPincode")+"(P)"%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Bank Details" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnDMARDisplayBankDetails" class="ViewButton" runat="server" Text="View" OnClick="btnDMARDisplayBankDetails_Click" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="College Details" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnDMARDisplayCollegeDetails" class="ViewButton" runat="server" Text="View" OnClick="btnDMARDisplayCollegeDetails_Click" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="300px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="CWStatus" HeaderText="Case Worker" HeaderStyle-Width="10%" ItemStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="80px" HeaderStyle-CssClass="text-center text-center font-weight-bold" />
                                                                <asp:BoundField DataField="DMStatus" HeaderText="Status" HeaderStyle-Width="10%" ItemStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="80px" HeaderStyle-CssClass="text-center text-center font-weight-bold" />

                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Action" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnDMARApprove" runat="server" OnClick="btnDMARApprove_Click" class="EligibleButton" Text="Eligible" /><br />
                                                                        <asp:Button ID="btnDMARHold" runat="server" OnClick="btnDMARHold_Click" class="HoldButton" Text="Hold" Visible="false" /><br />
                                                                        <asp:Button ID="btnDMARReject" runat="server" OnClick="btnDMARReject_Click" class="InEligibleButton" Text="Ineligible" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                                </asp:TemplateField>

                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>

                                                <div class="text-center">
                                                    <asp:Button ID="btnDMARDownloadExcelForCEO" class="DownloadButton" Text="Download Excel" runat="server" OnClick="btnDMARDownloadExcelForCEO_Click" />
                                                </div>
                                                <asp:Panel ID="PnlBankDetails" runat="server" CssClass="modalPopup" Width="50%" Style="display: none;">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label15" class="" runat="server" Text="Bank Details"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label1" runat="server">Application Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMARBDApplicationNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label38" runat="server">Account Holder Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMARBDAccountHolderName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label16" runat="server">Account Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMARBDAccountNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label17" runat="server">Bank Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMARBDBankName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label13" runat="server">Branch Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMARBDBranchName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label18" runat="server">IFSC Code</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMARBDIFSCCode" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label14" runat="server">Address</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMARBDBankAddress" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">

                                                                <div class="form-row-Botton">
                                                                    <asp:Button ID="btnBankDetailsBack" runat="server" CssClass="ViewButton" Text="OK" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>

                                                <asp:LinkButton ID="lnkBankDetailsFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="DMARBankDetailsPopup" runat="server" TargetControlID="lnkBankDetailsFake" PopupControlID="PnlBankDetails"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlDMARConfirmReject" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label24" class="" runat="server" Text="Confirm Inelegible"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label36" runat="server">Application Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDMARConfirmRejectAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label25" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDMARConfirmRejectAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label35" runat="server"> Select Reason<span style="color:red"> *</span></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input" style="flex-direction: column">
                                                                    <asp:RadioButton ID="rbDMARConfirmRejectReasonName" runat="server" Class="radioButton" GroupName="DMARConfirmRejectReason" Text="Name Mismatch" AutoPostBack="true" OnCheckedChanged="rbDMARConfirmRejectReasonName_CheckedChanged" /><br />
                                                                    <asp:RadioButton ID="rbDMARConfirmRejectReasonCET" runat="server" Class="radioButton" GroupName="DMARConfirmRejectReason" Text="Invalid CET Certificate" AutoPostBack="true" OnCheckedChanged="rbDMARConfirmRejectReasonName_CheckedChanged" /><br />
                                                                    <asp:RadioButton ID="rbDMARConfirmRejectReasonOther" runat="server" Class="radioButton" GroupName="DMARConfirmRejectReason" Text="Other" AutoPostBack="true" OnCheckedChanged="rbDMARConfirmRejectReasonName_CheckedChanged" /><br />
                                                                    <asp:Label runat="server" ID="lblDMARConfirmRejectAppReasonSelectionError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row" id="divDMARRejectReason" runat="server" visible="false">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMARRejectLabel" runat="server" Text="Reason"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtDMARConfirmRejectAppReason" CssClass="PopupTextBox" Height="70px" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblDMARConfirmRejectAppReasonError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnDMARConfirmRejectApplication" runat="server" CssClass="ActionButton" Text="Reject" OnClick="btnDMARConfirmRejectApplication_Click" />
                                                                    <asp:Button ID="Button3" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkDMARConfirmRejectFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="DMARConfirmRejectPopup" runat="server" PopupControlID="PnlDMARConfirmReject"
                                                    TargetControlID="lnkDMARConfirmRejectFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlDMARConfirmHold" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label23" class="" runat="server" Text="Confirm Hold"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label41" runat="server" Text="Application Number"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDMARConfirmHoldAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label43" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDMARConfirmHoldAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label45" runat="server" Text="Reason"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtDMARConfirmHoldAppReason" CssClass="PopupTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblDMARConfirmHoldAppReasonError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnDMARConfirmHoldApplication" runat="server" CssClass="ActionButton" Text="Hold" OnClick="btnDMARConfirmHoldApplication_Click" />
                                                                    <asp:Button ID="Button8" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkDMARConfirmHoldFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="DMARConfirmHoldPopup" runat="server" PopupControlID="PnlDMARConfirmHold"
                                                    TargetControlID="lnkDMARConfirmHoldFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlDMARConfirmApprove" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label29" class="" runat="server" Text="Confirm Eligible"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label37" runat="server" Text="Application Number"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDMARConfirmApproveAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label40" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDMARConfirmApproveAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnDMARConfirmApproveApplication" runat="server" CssClass="ActionButton" Text="Eligible" OnClick="btnDMARConfirmApproveApplication_Click" />
                                                                    <asp:Button ID="Button7" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkDMARConfirmApproveFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="DMARConfirmApprovePopup" runat="server" PopupControlID="PnlDMARConfirmApprove"
                                                    TargetControlID="lnkDMARConfirmApproveFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlDMCollegeDetails" runat="server" CssClass="modalPopup PopupPanel" Style="display: none; height: 90%; width: 80%;">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label2" class="" runat="server" Text="College Details"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label3" runat="server">Application Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMARClgPPApplicationNumber" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label4" runat="server">Name </asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMARClgPPApplicationName" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label7" runat="server">CET Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMARClgPPCETTicket" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label19" runat="server">Marks</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMARClgPPMarks" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label9" runat="server">College</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMARClgPPCollegeName" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label11" runat="server">Course</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMARClgPPCourse" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label21" runat="server">Hostel</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMARClgPPHostel" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label27" runat="server">Address</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMARClgPPClgAddress" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div>
                                                                <iframe id="application" runat="server" width="90%" height="400"></iframe>
                                                            </div>

                                                            <div class="form-row">
                                                                <%-- <div class="Popup-row-label">
                            <asp:Button ID="btnZMSERejectUpdate" runat="server" CssClass="Button" Text="Save and Proceed" />
                        </div>--%>
                                                                <div class="form-row-Botton">
                                                                    <asp:Button ID="btnDMPnlCollegeDetailsClose" runat="server" CssClass="ActionButton" Text="Close" OnClick="btnDMPnlCollegeDetailsClose_Click" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkCollegeDetailsFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="CollegeDetailsPopup" runat="server" TargetControlID="lnkCollegeDetailsFake" PopupControlID="PnlDMCollegeDetails"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                     <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelDMARAppnProcess" runat="server" DisplayAfter="0">
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
                                </div>
                                <div class="tab-pane fade" id="nav-NavCEOARAppnProcess" role="tabpanel" aria-labelledby="nav-NavCEOARAppnProcess-tab">
                                    <asp:UpdatePanel ID="UpdatePanelCEOARAppnProcess" runat="server">
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnArivuUploadCeoDoc" />
                                            <asp:PostBackTrigger ControlID="btDMARCEODownloadApproved" />
                                            <asp:PostBackTrigger ControlID="btDMARCEODownloadWaiting" />
                                            <asp:PostBackTrigger ControlID="btDMARCEODownloadHold" />
                                            <asp:PostBackTrigger ControlID="btDMARCEODownloadReject" />
                                        </Triggers>
                                        <ContentTemplate>
                                            <div class="flex-container">
                                                <div class="navFormHeading">
                                                    <asp:Label runat="server">Arivu Application Process - CEO Committee</asp:Label>
                                                </div>
                                                <div id="divCEOARFileUpload" class="text-center" runat="server">
                                                    <asp:FileUpload ID="FileCeoArivu" runat="server" style="margin-left:45%"/>
                                                    <asp:Button ID="btnArivuUploadCeoDoc" runat="server" class="DownloadButton" Width="15%" OnClick="btnArivuUploadCeoDoc_Click" Text="Upload CEO Cocument" />
                                                </div>
                                                <div class="divGridview" runat="server" id="divCEOARApplicationProcess" >
                                                    <div class="text-center">
                                                        <asp:GridView ID="gvCEOARApproveProcess" runat="server" class="GridView" OnRowDataBound="gvCEOARApproveProcess_RowDataBound" AutoGenerateColumns="False" DataKeyNames="ApplicationNumber,ApplicantName,RDNumber,AadharNum,ClgHostel" Style="align-content: center;">
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ApplicationNumber")%>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtAppNum" runat="server" Text='<%# Eval("ApplicationNumber") %>' Enabled="false" />
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="180px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Applicant Name" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ApplicantName") + "<br />" + Eval("Gender")+ "<br />"+"PH : "+ Eval("PhysicallyChallenged") %>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="RD Number " ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("RDNumber")+ "<br />"+  Eval("ApplicantNameNC") + "<br />" + "Income: " + Eval("AnualIncome")%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="160px" Font-Bold="true" ForeColor="Red" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="DOB" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%#Eval("ApplicantDob")+ " ("+ Eval("Age") + ")" %>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="160px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Email ID &amp; Mobile Number" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("EmailID") + "<br />" +  Eval("MobileNumber")%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="180px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Address" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ParmanentAddress") + "<br />" + Eval("ParDistrict")+"(D)"+ "<br />" + Eval("ParTaluk")+"(T)"+ "<br />" + Eval("ParConstituency")+"(C)"+ "<br />" + Eval("ParPincode")+"(P)"%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Bank Details" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnCEOARDisplayBankDetails" class="ViewButton" runat="server" Text="View" OnClick="btnCEOARDisplayBankDetails_Click" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="College Details" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnCEOARDisplayCollegeDetails" class="ViewButton" runat="server" Text="View" OnClick="btnCEOARDisplayCollegeDetails_Click" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="300px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="CEOStatus" HeaderText="Status" HeaderStyle-Width="10%" ItemStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="80px" HeaderStyle-CssClass="text-center text-center font-weight-bold" />


                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Action" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnCEOARApprove" runat="server" OnClick="btnCEOARApprove_Click" class="EligibleButton" Text="Approve" /><br />
                                                                        <asp:Button ID="btnCEOARWaiting" runat="server" OnClick="btnCEOARWaiting_Click" class="WaitingButton" Text="Waiting" /><br />
                                                                        <asp:Button ID="btnCEOARHold" runat="server" OnClick="btnCEOARHold_Click" class="HoldButton" Text="Hold" /><br />
                                                                        <asp:Button ID="btnCEOARReject" runat="server" OnClick="btnCEOARReject_Click" class="InEligibleButton" Text="Reject" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                                </asp:TemplateField>

                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                    <div class="text-center">
                                                        <asp:Button ID="btnDMARCEOGenerateReport" class="DownloadButton" Text="Generate Report" runat="server" style="width:30%;color:burlywood" UseSubmitBehavior="false" OnClick="btnDMARCEOGenerateReport_Click" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
                                                    </div>
                                                </div>
                                                
                                                <div id="divDMARCEOReportDownload" runat="server"  visible="false">
                                                    <div class="text-center">
                                                        <asp:Button ID="btDMARCEODownloadApproved" class="DownloadButton" Text="Download Approved" runat="server" UseSubmitBehavior="false" OnClick="btDMARCEODownloadApproved_Click"  />
                                                        <asp:Button ID="btDMARCEODownloadWaiting" class="DownloadButton" Text="Download Waiting" runat="server" UseSubmitBehavior="false" OnClick="btDMARCEODownloadWaiting_Click"  />
                                                        <asp:Button ID="btDMARCEODownloadHold" class="DownloadButton" Text="Download Hold" runat="server" UseSubmitBehavior="false" OnClick="btDMARCEODownloadHold_Click"  />
                                                        <asp:Button ID="btDMARCEODownloadReject" class="DownloadButton" Text="Download Reject" runat="server" UseSubmitBehavior="false" OnClick="btDMARCEODownloadReject_Click"  />
                                                    </div>
                                                </div>
                                                <asp:Panel ID="PnlCEOARBankDetails" runat="server" CssClass="modalPopup PopupPanel" Width="50%" Style="display: none;">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label54" class="" runat="server" Text="Bank Details"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label58" runat="server">Application Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCEOARBDApplicationNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label62" runat="server">Account Holder Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCEOARBDAccountHolderName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label64" runat="server">Account Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCEOARBDAccountNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label66" runat="server">Bank Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCEOARBDBankName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label68" runat="server">Branch Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCEOARBDBranchName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label70" runat="server">IFSC Code</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCEOARBDIFSCCode" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label71" runat="server">Address</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCEOARBDBankAddress" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">

                                                                <div class="form-row-Botton">
                                                                    <asp:Button ID="Button9" runat="server" CssClass="ViewButton" Text="OK" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>

                                                <asp:LinkButton ID="lnkCEOARBankDetailsFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="CEOARBankDetailsPopup" runat="server" TargetControlID="lnkCEOARBankDetailsFake" PopupControlID="PnlCEOARBankDetails"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlCEOARConfirmReject" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label72" class="" runat="server" Text="Confirm Inelegible"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label73" runat="server">Application Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblCEOARConfirmRejectAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label74" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblCEOARConfirmRejectAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label110" runat="server"> Select Reason<span style="color:red"> *</span></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input" style="flex-direction: column">
                                                                    <asp:RadioButton ID="rbCEOARConfirmRejectReasonNotSelected" runat="server" Class="radioButton" GroupName="CEOARConfirmRejectReason" Text="Not Selected" AutoPostBack="true" OnCheckedChanged="rbCEOARConfirmRejectReasonName_CheckedChanged" /><br />
                                                                    <asp:RadioButton ID="rbCEOARConfirmRejectReasonOther" runat="server" Class="radioButton" GroupName="CEOARConfirmRejectReason" Text="Other" AutoPostBack="true" OnCheckedChanged="rbCEOARConfirmRejectReasonName_CheckedChanged" /><br />
                                                                    <asp:Label runat="server" ID="lblCEOARConfirmRejectAppReasonSelectionError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row" runat="server" id="divCEOARRejectReason">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCEOARRejectLabel" runat="server" Text="Reason"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtCEOARConfirmRejectAppReason" CssClass="PopupTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblCEOARConfirmRejectAppReasonError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnCEOARConfirmRejectApplication" runat="server" CssClass="ActionButton" Text="Reject" OnClick="btnCEOARConfirmRejectApplication_Click" />
                                                                    <asp:Button ID="Button11" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkCEOARConfirmRejectFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="CEOARConfirmRejectPopup" runat="server" PopupControlID="PnlCEOARConfirmReject"
                                                    TargetControlID="lnkCEOARConfirmRejectFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlCEOARConfirmHold" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label76" class="" runat="server" Text="Confirm Hold"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label77" runat="server" Text="Application Number"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblCEOARConfirmHoldAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label78" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblCEOARConfirmHoldAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label79" runat="server" Text="Reason"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtCEOARConfirmHoldAppReason" CssClass="PopupTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblCEOARConfirmHoldAppReasonError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnCEOARConfirmHoldApplication" runat="server" CssClass="ActionButton" Text="Hold" OnClick="btnCEOARConfirmHoldApplication_Click" />
                                                                    <asp:Button ID="Button12" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkCEOARConfirmHoldFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="CEOARConfirmHoldPopup" runat="server" PopupControlID="PnlCEOARConfirmHold"
                                                    TargetControlID="lnkCEOARConfirmHoldFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlCEOARConfirmApprove" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label80" class="" runat="server" Text="Confirm Eligible"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label81" runat="server" Text="Application Number"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblCEOARConfirmApproveAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label82" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblCEOARConfirmApproveAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label170" runat="server" Text="Quota"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:DropDownList ID="drpCEOARQuota" Class="NeuoDropdown" runat="server">
                                                                        <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                                                                        <asp:ListItem Value="ActionPlan">Action Plan</asp:ListItem>
                                                                        <asp:ListItem Value="Adyakshara">Adyakshara VK</asp:ListItem>
                                                                        <asp:ListItem Value="Government">Government VK</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:Label runat="server" ID="lblCEOARQuotaError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label164" runat="server" Text="1st Instalment"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtInstalment1" TextMode="Number" CssClass="PopupTextBoxSingleLine" runat="server" onkeypress="return CheckNumber(event,this)" onKeyUp="return CheckNumber(event,this)" onChange="return CheckNumber(event,this)" AutoPostBack="true" OnTextChanged="txtInstalment1_TextChanged"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblInstalmentError1" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label165" runat="server" Text="2nd Instalment"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtInstalment2" TextMode="Number" CssClass="PopupTextBoxSingleLine" runat="server" MaxLength="5" onkeypress="return CheckNumber(event,this)" onKeyUp="return CheckNumber(event,this)" onChange="return CheckNumber(event,this)" AutoPostBack="true" OnTextChanged="txtInstalment2_TextChanged"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblInstalmentError2" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label166" runat="server" Text="3rd Instalment"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtInstalment3" TextMode="Number" CssClass="PopupTextBoxSingleLine" runat="server" MaxLength="5" onkeypress="return CheckNumber(event,this)" onKeyUp="return CheckNumber(event,this)" onChange="return CheckNumber(event,this)" AutoPostBack="true" OnTextChanged="txtInstalment3_TextChanged"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblInstalmentError3" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label167" runat="server" Text="4th Instalment"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtInstalment4" TextMode="Number" CssClass="PopupTextBoxSingleLine" runat="server" MaxLength="5" onkeypress="return CheckNumber(event,this)" onKeyUp="return CheckNumber(event,this)" onChange="return CheckNumber(event,this)" AutoPostBack="true" OnTextChanged="txtInstalment4_TextChanged"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblInstalmentError4" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label168" runat="server" Text="5th Instalment"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtInstalment5" TextMode="Number" CssClass="PopupTextBoxSingleLine" runat="server" MaxLength="5" onkeypress="return CheckNumber(event,this)" onKeyUp="return CheckNumber(event,this)" onChange="return CheckNumber(event,this)" AutoPostBack="true" OnTextChanged="txtInstalment5_TextChanged"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblInstalmentError5" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label169" runat="server" Text="6th Instalment"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtInstalment6" TextMode="Number" CssClass="PopupTextBoxSingleLine" runat="server" MaxLength="5" onkeypress="return CheckNumber(event,this)" onKeyUp="return CheckNumber(event,this)" onChange="return CheckNumber(event,this)" AutoPostBack="true" OnTextChanged="txtInstalment6_TextChanged"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblInstalmentError6" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnCEOARConfirmApproveApplication" runat="server" CssClass="ActionButton" Text="Eligible" OnClick="btnCEOARConfirmApproveApplication_Click" />
                                                                    <asp:Button ID="Button13" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkCEOARConfirmApproveFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="CEOARConfirmApprovePopup" runat="server" PopupControlID="PnlCEOARConfirmApprove"
                                                    TargetControlID="lnkCEOARConfirmApproveFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlCEOARConfirmWaiting" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label161" class="" runat="server" Text="Confirm Eligible"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label162" runat="server" Text="Application Number"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblCEOARConfirmWaitingAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label163" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblCEOARConfirmWaitingAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnCEOARConfirmWaitingApplication" runat="server" CssClass="ActionButton" Text="Waiting" OnClick="btnCEOARConfirmWaitingApplication_Click" />
                                                                    <asp:Button ID="Button28" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkCEOARConfirmWaitingFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="CEOARConfirmWaitingPopup" runat="server" PopupControlID="PnlCEOARConfirmWaiting"
                                                    TargetControlID="lnkCEOARConfirmWaitingFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlCEOARCollegeDetails" runat="server" CssClass="modalPopup PopupPanel" Style="display: none; height: 90%; width: 80%;">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label83" class="" runat="server" Text="College Details"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label84" runat="server">Application Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCEOARClgPPApplicationNumber" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label85" runat="server">Name </asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCEOARClgPPApplicationName" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label86" runat="server">CET Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCEOARClgPPCETTicket" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label87" runat="server">Marks</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCEOARClgPPMarks" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label88" runat="server">College</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCEOARClgPPCollegeName" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label89" runat="server">Course</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCEOARClgPPCourse" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label90" runat="server">Hostel</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCEOARClgPPHostel" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label91" runat="server">Address</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCEOARClgPPClgAddress" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div>
                                                                <iframe id="IframeCEOCollegeFile" runat="server" width="90%" height="400"></iframe>
                                                            </div>

                                                            <div class="form-row">

                                                                <div class="form-row-Botton">
                                                                    <asp:Button ID="btnCEOPnlCollegeDetailsClose" runat="server" CssClass="ActionButton" Text="Close" OnClick="btnCEOPnlCollegeDetailsClose_Click" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkCEOARCollegeDetailsFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="CEOARCollegeDetailsPopup" runat="server" TargetControlID="lnkCEOARCollegeDetailsFake" PopupControlID="PnlCEOARCollegeDetails"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelCEOARAppnProcess" runat="server" DisplayAfter="0">
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
                                </div>
                                <div class="tab-pane fade" id="nav-NavDOCARAppnProcess" role="tabpanel" aria-labelledby="nav-NavDOCARAppnProcess-tab">
                                    <asp:UpdatePanel ID="UpdatePanelDOCARAppnProcess" runat="server">
                                        <ContentTemplate>
                                            <div class="flex-container">
                                                <div class="navFormHeading">
                                                    <asp:Label runat="server">Arivu Application Process - Documentation</asp:Label>
                                                </div>
                                                <div class="divGridview">
                                                    <div class="text-center">
                                                        <asp:GridView ID="gvDOCARApproveProcess" runat="server" class="GridView" OnRowDataBound="gvDOCARApproveProcess_RowDataBound" AutoGenerateColumns="False" DataKeyNames="ApplicationNumber,ApplicantName,RDNumber,AadharNum,ClgHostel" Style="align-content: center;">
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ApplicationNumber")%>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtAppNum" runat="server" Text='<%# Eval("ApplicationNumber") %>' Enabled="false" />
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="180px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Applicant Name" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ApplicantName") + "<br />" + Eval("Gender")+ "<br />"+"PH : "+ Eval("PhysicallyChallenged") %>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="RD Number " ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("RDNumber")+ "<br />"+  Eval("ApplicantNameNC") + "<br />" + "Income: " + Eval("AnualIncome")%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="160px" Font-Bold="true" ForeColor="Red" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="DOB" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%#Eval("ApplicantDob")+ " ("+ Eval("Age") + ")" %>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="160px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Email ID &amp; Mobile Number" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("EmailID") + "<br />" +  Eval("MobileNumber")%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="180px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Address" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ParmanentAddress") + "<br />" + Eval("ParDistrict")+"(D)"+ "<br />" + Eval("ParTaluk")+"(T)"+ "<br />" + Eval("ParConstituency")+"(C)"+ "<br />" + Eval("ParPincode")+"(P)"%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Bank Details" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnDOCARDisplayBankDetails" class="ViewButton" runat="server" Text="View" OnClick="btnDOCARDisplayBankDetails_Click" />
                                                                        <asp:Button ID="btnDOCARDisplayBankDetailsUpdate" class="ViewButton" runat="server" Text='<%# Eval("BDStatus") %>' OnClick="btnDOCARDisplayBankDetailsUpdate_Click" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="College Details" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnDOCARDisplayCollegeDetails" class="ViewButton" runat="server" Text="View" OnClick="btnDOCARDisplayCollegeDetails_Click" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="300px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="DOCStatus" HeaderText="Status" HeaderStyle-Width="10%" ItemStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="80px" HeaderStyle-CssClass="text-center text-center font-weight-bold" />
                                                                <asp:ImageField HeaderText="Image" DataImageUrlField="ImgPath" ControlStyle-Height="80" ControlStyle-Width="65" ItemStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-center font-weight-bold"></asp:ImageField>


                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Action" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnDOCARApprove" runat="server" OnClick="btnDOCARApprove_Click" class="EligibleButton" Text="Document Verified" /><br />
                                                                        <asp:Button ID="btnDOCARHold" runat="server" OnClick="btnDOCARHold_Click" class="HoldButton" Text="Hold" /><br />
                                                                        <asp:Button ID="btnDOCARReject" runat="server" OnClick="btnDOCARReject_Click" class="InEligibleButton" Text="Reject" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                                </asp:TemplateField>
                                                                
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                                <div class="text-center">
                                                    <asp:Button ID="btnDMARSubmitToZM" class="DownloadButton" Text="Submit To ZM" runat="server" OnClick="btnDMARSubmitToZM_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
                                                </div>
                                                <asp:Panel ID="PnlDOCARBankDetails" runat="server" CssClass="modalPopup PopupPanel" Width="50%" Style="display: none;">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label111" class="" runat="server" Text="Bank Details"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label112" runat="server">Application Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDOCARBDApplicationNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label113" runat="server">Account Holder Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDOCARBDAccountHolderName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label114" runat="server">Account Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDOCARBDAccountNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label115" runat="server">Bank Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDOCARBDBankName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label116" runat="server">Branch Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDOCARBDBranchName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label117" runat="server">IFSC Code</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDOCARBDIFSCCode" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label118" runat="server">Address</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDOCARBDBankAddress" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">

                                                                <div class="form-row-Botton">
                                                                    <asp:Button ID="Button19" runat="server" CssClass="ViewButton" Text="OK" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>

                                                <asp:LinkButton ID="lnkDOCARBankDetailsFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="DOCARBankDetailsPopup" runat="server" TargetControlID="lnkDOCARBankDetailsFake" PopupControlID="PnlDOCARBankDetails"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlDOCARConfirmReject" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label119" class="" runat="server" Text="Confirm Inelegible"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label120" runat="server">Application Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDOCARConfirmRejectAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label121" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDOCARConfirmRejectAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label122" runat="server" Text="Reason"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtDOCARConfirmRejectAppReason" CssClass="PopupTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblDOCARConfirmRejectAppReasonError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnDOCARConfirmRejectApplication" runat="server" CssClass="ActionButton" Text="Reject" OnClick="btnDOCARConfirmRejectApplication_Click" />
                                                                    <asp:Button ID="Button20" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkDOCARConfirmRejectFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="DOCARConfirmRejectPopup" runat="server" PopupControlID="PnlDOCARConfirmReject"
                                                    TargetControlID="lnkDOCARConfirmRejectFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlDOCARConfirmHold" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label123" class="" runat="server" Text="Confirm Hold"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label124" runat="server" Text="Application Number"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDOCARConfirmHoldAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label125" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDOCARConfirmHoldAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label126" runat="server" Text="Reason"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtDOCARConfirmHoldAppReason" CssClass="PopupTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblDOCARConfirmHoldAppReasonError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnDOCARConfirmHoldApplication" runat="server" CssClass="ActionButton" Text="Hold" OnClick="btnDOCARConfirmHoldApplication_Click" />
                                                                    <asp:Button ID="Button21" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkDOCARConfirmHoldFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="DOCARConfirmHoldPopup" runat="server" PopupControlID="PnlDOCARConfirmHold"
                                                    TargetControlID="lnkDOCARConfirmHoldFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlDOCARConfirmApprove" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label127" class="" runat="server" Text="Confirm Eligible"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label128" runat="server" Text="Application Number"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDOCARConfirmApproveAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label129" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDOCARConfirmApproveAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnDOCARConfirmApproveApplication" runat="server" CssClass="ActionButton" Text="Document Verified" OnClick="btnDOCARConfirmApproveApplication_Click" />
                                                                    <asp:Button ID="Button22" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkDOCARConfirmApproveFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="DOCARConfirmApprovePopup" runat="server" PopupControlID="PnlDOCARConfirmApprove"
                                                    TargetControlID="lnkDOCARConfirmApproveFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlDOCARCollegeDetails" runat="server" CssClass="modalPopup PopupPanel" Style="display: none; height: 90%; width: 80%;">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label130" class="" runat="server" Text="College Details"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label131" runat="server">Application Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDOCARClgPPApplicationNumber" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label132" runat="server">Name </asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDOCARClgPPApplicationName" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label133" runat="server">CET Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDOCARClgPPCETTicket" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label134" runat="server">Marks</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDOCARClgPPMarks" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label135" runat="server">College</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDOCARClgPPCollegeName" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label136" runat="server">Course</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDOCARClgPPCourse" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label137" runat="server">Hostel</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDOCARClgPPHostel" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label138" runat="server">Address</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDOCARClgPPClgAddress" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div>
                                                                <iframe id="IframeDOCCollegeFile" runat="server" width="90%" height="400"></iframe>
                                                            </div>

                                                            <div class="form-row">
                                                                <%-- <div class="Popup-row-label">
                            <asp:Button ID="btnZMSERejectUpdate" runat="server" CssClass="Button" Text="Save and Proceed" />
                        </div>--%>
                                                                <div class="form-row-Botton">
                                                                    <asp:Button ID="Button23" runat="server" CssClass="ActionButton" Text="Close" OnClick="btnPnlCollegeDetailsClose_Click" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkDOCARCollegeDetailsFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="DOCARCollegeDetailsPopup" runat="server" TargetControlID="lnkDOCARCollegeDetailsFake" PopupControlID="PnlDOCARCollegeDetails"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlDOCARBankDetailsUpdate" runat="server" CssClass="modalPopup PopupPanel" Width="50%" Style="display: none;">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label183" class="" runat="server" Text="Update Bank Details"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label184" runat="server">Application Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDOCARBDUpdateApplicationNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label185" runat="server">Account Holder Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDOCARBDUpdateAccountHolderName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label186" runat="server">Account Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtDOCARBDUpdateAccountNumber" CssClass="PopupTextBoxSingleLine" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label187" runat="server">Bank Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtDOCARBDUpdateBankName" CssClass="PopupTextBoxSingleLine" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label188" runat="server">Branch Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtDOCARBDUpdateBranchName" CssClass="PopupTextBoxSingleLine" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label189" runat="server">IFSC Code</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtDOCARBDUpdateIFSCCode" CssClass="PopupTextBoxSingleLine" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label190" runat="server">Address</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtDOCARBDUpdateBankAddress" CssClass="PopupTextBox" Height="80px" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label191" runat="server">Select Reason</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:DropDownList ID="drpDOCARBankModifyReason" runat="server" class="NeuoDropdown">
                                                                        <asp:ListItem Value="0">--SELECE REASON--</asp:ListItem>
                                                                        <asp:ListItem Value="Jandhan Account">Jandhan Account</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid IFSC Code">Wrong IFSC Code</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid A/C Number">Invalid A/C Number</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid Branch">Invalid Branch</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid Bank">Invalid Bank</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid Address">Invalid Address</asp:ListItem>
                                                                    </asp:DropDownList><br />
                                                                    <asp:Label runat="server" ID="lblDOCARBDUpdateError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="form-row-Botton">
                                                                    <asp:Button ID="btnDOCARBDUpdate" runat="server" CssClass="ActionButton" Text="Update" OnClick="btnDOCARBDUpdate_Click" />
                                                                    <asp:Button ID="Button30" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkDOCARBankDetailsUpdateFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="DOCARBankDetailsUpdatePopup" runat="server" TargetControlID="lnkDOCARBankDetailsUpdateFake" PopupControlID="PnlDOCARBankDetailsUpdate"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelDOCARAppnProcess" runat="server" DisplayAfter="0">
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
                                </div>
                                <div class="tab-pane fade" id="nav-NavDOCARRenewalProcess" role="tabpanel" aria-labelledby="nav-NavDOCARRenewalProcess-tab">
                                    <asp:UpdatePanel ID="UpdatePanelDOCARRenewalProcess" runat="server">
                                        <ContentTemplate>
                                            <div class="flex-container">
                                                <div class="navFormHeading">
                                                    <asp:Label runat="server">Arivu Renewal Process</asp:Label>
                                                </div>
                                                <div class="text-center">
                                                    <div class="form-row" runat="server">
                                                        <div class="form-row-label">
                                                            <asp:Label runat="server" Text="Select Installment" style="color:black"></asp:Label>
                                                        </div>
                                                        <div class="form-row-label">
                                                            <asp:DropDownList ID="drpARRenewalInstalment" Class="NeuoDropdown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpARRenewalInstalment_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                                                                <asp:ListItem Value="2ND_INSTALMENT">2ND_INSTALMENT</asp:ListItem>
                                                                <asp:ListItem Value="3RD_INSTALMENT">3RD_INSTALMENT</asp:ListItem>
                                                                <asp:ListItem Value="4TH_INSTALMENT">4TH_INSTALMENT</asp:ListItem>
                                                                <asp:ListItem Value="5TH_INSTALMENT">5TH_INSTALMENT</asp:ListItem>
                                                                <asp:ListItem Value="6TH_INSTALMENT">6TH_INSTALMENT</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="divGridview" id="divRenewalGridview" runat="server" visible="false">
                                                    <div class="text-center">
                                                        <asp:GridView ID="gvARRenewalProcess" runat="server" class="GridView"  AutoGenerateColumns="False" DataKeyNames="ApplicationNumber,ApplicantName,RDNumber,AadharNum,ClgHostel" Style="align-content: center;">
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ApplicationNumber")%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="180px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Approved Loan Number" ItemStyle-Width="100">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ApprovedApplicationNum")%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="180px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Applicant Name" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ApplicantName")  %>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                                                </asp:TemplateField>
                                                               
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Loan Amount" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("LOANAMOUNTREL")%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="160px" Font-Bold="true" ForeColor="Red" />
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Quota" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("Quota")%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="160px" Font-Bold="true" ForeColor="Red" />
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Applicant Details" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnARRenewalViewDetails" class="ViewButton" runat="server" Text="View" OnClick="btnARRenewalViewDetails_Click" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="300px" />
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Bank Details" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnARRenewalDisplayBankDetails" class="ViewButton" runat="server" Text="View" OnClick="btnARRenewalDisplayBankDetails_Click" />
                                                                        <asp:Button ID="btnARRenewalDisplayBankDetailsUpdate" class="ViewButton" runat="server" Text='<%# Eval("BDStatus") %>' OnClick="btnARRenewalDisplayBankDetailsUpdate_Click" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="College Details" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnARRenewalDisplayCollegeDetails" class="ViewButton" runat="server" Text="View" OnClick="btnARRenewalDisplayCollegeDetails_Click" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="300px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="RenewalStatus" HeaderText="Status" HeaderStyle-Width="10%" ItemStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="80px" HeaderStyle-CssClass="text-center text-center font-weight-bold" />
<%--                                                                <asp:ImageField HeaderText="Image" DataImageUrlField="ImgPath" ControlStyle-Height="80" ControlStyle-Width="65" ItemStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-center font-weight-bold"></asp:ImageField>--%>


                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Action" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnARRenewalApprove" runat="server" OnClick="btnARRenewalApprove_Click" class="EligibleButton" Text="Document Verified" /><br />
                                                                        <asp:Button ID="btnARRenewalHold" runat="server" OnClick="btnARRenewalHold_Click" class="HoldButton" Text="Hold" /><br />
                                                                        <asp:Button ID="btnARRenewalReject" runat="server" OnClick="btnARRenewalReject_Click" class="InEligibleButton" Text="Reject" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                                </asp:TemplateField>
                                                                
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>

                                                <div class="text-center">
                                                    <asp:Button ID="btnARRenewalSubmitToZM" class="DownloadButton" Text="Submit To ZM" runat="server" OnClick="btnARRenewalSubmitToZM_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
                                                </div>

                                                <asp:Panel ID="PnlARRenewalBankDetails" runat="server" CssClass="modalPopup PopupPanel" Width="50%" Style="display: none;">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label157" class="" runat="server" Text="Bank Details"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label193" runat="server">Application Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblARRenewalBDApplicationNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label194" runat="server">Account Holder Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblARRenewalBAccountHolderName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label195" runat="server">Account Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblARRenewalBAccountNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label196" runat="server">Bank Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblARRenewalBBankName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label197" runat="server">Branch Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblARRenewalBBranch" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label198" runat="server">IFSC Code</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblARRenewalBIFSCCode" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label199" runat="server">Address</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblARRenewalBBankAddress" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">

                                                                <div class="form-row-Botton">
                                                                    <asp:Button ID="Button31" runat="server" CssClass="ViewButton" Text="OK" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>

                                                <asp:LinkButton ID="lnkARRenewalBankDetailsFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="ARRenewalBankDetailsPopup" runat="server" TargetControlID="lnkARRenewalBankDetailsFake" PopupControlID="PnlARRenewalBankDetails"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlARRenewalBankDetailsUpdate" runat="server" CssClass="modalPopup PopupPanel" Width="50%" Style="display: none;">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label200" class="" runat="server" Text="Update Bank Details"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label201" runat="server">Application Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblARRenewalBDUpdateApplicationNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label202" runat="server">Account Holder Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblARRenewalBDUpdateAccountHolderName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label206" runat="server">IFSC Code</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtARRenewalBDUpdateIFSCCode" CssClass="PopupTextBoxSingleLine" runat="server" OnTextChanged="txtARRenewalBDUpdateIFSCCode_TextChanged"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label203" runat="server">Account Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtARRenewalBDUpdateAccountNumber" CssClass="PopupTextBoxSingleLine" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label204" runat="server">Bank Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtARRenewalBDUpdateBankName" CssClass="PopupTextBoxSingleLine" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label205" runat="server">Branch Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtARRenewalBDUpdateBranchName" CssClass="PopupTextBoxSingleLine" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label207" runat="server">Address</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtARRenewalBDUpdateBankAddress" CssClass="PopupTextBox" Height="80px" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label208" runat="server">Select Reason</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:DropDownList ID="drpARRenewalBankModifyReason" runat="server" class="NeuoDropdown">
                                                                        <asp:ListItem Value="0">--SELECE REASON--</asp:ListItem>
                                                                        <asp:ListItem Value="Jandhan Account">Jandhan Account</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid IFSC Code">Wrong IFSC Code</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid A/C Number">Invalid A/C Number</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid Branch">Invalid Branch</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid Bank">Invalid Bank</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid Address">Invalid Address</asp:ListItem>
                                                                    </asp:DropDownList><br />
                                                                    <asp:Label runat="server" ID="lblARRenewalBDUpdateError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="form-row-Botton">
                                                                    <asp:Button ID="btnARRenewalBDUpdate" runat="server" CssClass="ActionButton" Text="Update" OnClick="btnARRenewalBDUpdate_Click" />
                                                                    <asp:Button ID="Button32" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkARRenewalBankDetailsUpdateFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="ARRenewalBankDetailsUpdatePopup" runat="server" TargetControlID="lnkARRenewalBankDetailsUpdateFake" PopupControlID="PnlARRenewalBankDetailsUpdate"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                 <asp:Panel ID="PnlARRenewalConfirmApprove" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label209" class="" runat="server" Text="Confirm Renewal Approve"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label210" runat="server" Text="Application Number"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblARRenewalConfirmApproveAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label211" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblARRenewalConfirmApproveAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnARRenewalConfirmApproveApplication" runat="server" CssClass="ActionButton" Text="Document Verified" OnClick="btnARRenewalConfirmApproveApplication_Click" />
                                                                    <asp:Button ID="Button33" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkARRenewalConfirmApproveFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="ARRenewalConfirmApprovePopup" runat="server" PopupControlID="PnlARRenewalConfirmApprove"
                                                    TargetControlID="lnkARRenewalConfirmApproveFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                 <asp:Panel ID="PnlARRenewalConfirmHold" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label212" class="" runat="server" Text="Confirm Hold"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label213" runat="server" Text="Application Number"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblARRenewalConfirmHoldAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label214" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblARRenewalConfirmHoldAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label215" runat="server" Text="Reason"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtARRenewalConfirmHoldAppReason" CssClass="PopupTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblARRenewalConfirmHoldAppReasonError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnARRenewalConfirmHoldApplication" runat="server" CssClass="ActionButton" Text="Hold" OnClick="btnARRenewalConfirmHoldApplication_Click" />
                                                                    <asp:Button ID="Button34" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkARRenewalConfirmHoldFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="ARRenewalConfirmHoldPopup" runat="server" PopupControlID="PnlARRenewalConfirmHold"
                                                    TargetControlID="lnkARRenewalConfirmHoldFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlARRenewalConfirmReject" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label216" class="" runat="server" Text="Confirm Inelegible"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label217" runat="server">Application Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblARRenewalConfirmRejectAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label218" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblARRenewalConfirmRejectAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label219" runat="server" Text="Reason"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtARRenewalConfirmRejectAppReason" CssClass="PopupTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblARRenewalConfirmRejectAppReasonError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnARRenewalConfirmRejectApplication" runat="server" CssClass="ActionButton" Text="Reject" OnClick="btnARRenewalConfirmRejectApplication_Click" />
                                                                    <asp:Button ID="Button35" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkARRenewalConfirmRejectFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="ARRenewalConfirmRejectPopup" runat="server" PopupControlID="PnlARRenewalConfirmReject"
                                                    TargetControlID="lnkARRenewalConfirmRejectFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlARRenewalCollegeDetails" runat="server" CssClass="modalPopup PopupPanel" Style="display: none; height: 90%; width: 80%;">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label222" class="" runat="server" Text="College Details"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label223" runat="server">Application Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblARRenewalClgPPApplicationNumber" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label224" runat="server">Name </asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblARRenewalClgPPApplicationName" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label225" runat="server">CET Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblARRenewalClgPPCETTicket" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label226" runat="server">Marks</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblARRenewalClgPPMarks" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label227" runat="server">College</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblARRenewalClgPPCollegeName" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label228" runat="server">Course</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblARRenewalClgPPCourse" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label229" runat="server">Hostel</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblARRenewalClgPPHostel" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label230" runat="server">Address</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblARRenewalClgPPClgAddress" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div>
                                                                <iframe id="IframeARRenewalCollegeFile" runat="server" width="90%" height="400"></iframe>
                                                            </div>

                                                            <div class="form-row">
                                                                <%-- <div class="Popup-row-label">
                            <asp:Button ID="btnZMSERejectUpdate" runat="server" CssClass="Button" Text="Save and Proceed" />
                        </div>--%>
                                                                <div class="form-row-Botton">
                                                                    <asp:Button ID="Button37" runat="server" CssClass="ActionButton" Text="Close" OnClick="btnPnlCollegeDetailsClose_Click" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkARRenewalCollegeDetailsFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="ARRenewalCollegeDetailsPopup" runat="server" TargetControlID="lnkARRenewalCollegeDetailsFake" PopupControlID="PnlARRenewalCollegeDetails"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                 <asp:Panel ID="PnlARRenewalViewDetails" runat="server" CssClass="modalPopup PopupPanel" Width="50%" Style="display: none;">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label231" class="" runat="server" Text="Details"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label232" runat="server">Application Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblARRenewalViewApplicationNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label233" runat="server">Applicant Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblARRenewalViewApplicantName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label241" runat="server">Loan Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblARRenewalViewLoanNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label234" runat="server">RD Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblARRenewalViewRDNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label235" runat="server">Email ID</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblARRenewalEmail" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label236" runat="server">Mobile Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblARRenewalViewMobileNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label237" runat="server">Alternate Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblARRenewalViewAlternateNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
															<div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label238" runat="server">Quota</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblARRenewalViewQuota" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label239" runat="server">Total Amount</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblARRenewalViewTotalAmount" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
															<div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label240" runat="server">Loan Amount</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblARRenewalViewLoanAmount" runat="server" style="font-weight:bolder; color:#ab1111; Font-Size:20px;"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">

                                                                <div class="form-row-Botton">
                                                                    <asp:Button ID="Button38" runat="server" CssClass="ViewButton" Text="OK" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>

                                                <asp:LinkButton ID="lnkARRenewalViewDetailsFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="ARRenewalViewDetailsPopup" runat="server" TargetControlID="lnkARRenewalViewDetailsFake" PopupControlID="PnlARRenewalViewDetails"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelDOCARRenewalProcess" runat="server" DisplayAfter="0">
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
                                </div>
                                <div class="tab-pane fade" id="nav-NavDMARAppnStatus" role="tabpanel" aria-labelledby="nav-NavDMARAppnStatus-tab">
                                    <asp:UpdatePanel ID="UpdatePanelDMARAppnStatus" runat="server">
                                        <ContentTemplate>
                                            <div class="flex-container">
                                                <div class="navFormHeading">
                                                    <asp:Label runat="server">Arivu Application Status</asp:Label>
                                                </div>
                                                <div class="navFormBody">
                                                    <div class="formFlex-row">
                                                        <asp:Label runat="server" class="labelStyle1" Text="Application Number"></asp:Label>
                                                        <asp:TextBox ID="txtDMARApplicationStatus" class="textboxStyle1" runat="server"></asp:TextBox>
                                                        <asp:Button ID="btnDMARGetApplicationStatus" runat="server" Text="Get Status" OnClick="btnDMARGetApplicationStatus_Click" />
                                                        <asp:Panel ID="PnlDMARApplicationStatusDetails" runat="server" CssClass="modalPopup PopupPanel" Width="50%" Style="display: none;">
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
                                                                            <asp:Label ID="lblDMARAppStatusApplicationNumber" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-row">
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="Label50" runat="server">Applicant Name</asp:Label>
                                                                        </div>
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="lblDMARAppStatusApplicationName" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-row">
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="Label53" runat="server">Case Worker</asp:Label>
                                                                        </div>
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="lblDMARAppStatusApplicationCWStat" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-row">
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="Label55" runat="server">District Manager</asp:Label>
                                                                        </div>
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="lblDMARAppStatusApplicationDMStat" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-row">
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="Label57" runat="server">CEO Committee</asp:Label>
                                                                        </div>
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="lblDMARAppStatusApplicationCEOStat" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-row">
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="Label59" runat="server">Documentation</asp:Label>
                                                                        </div>
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="lblDMARAppStatusApplicationDOCStat" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>

                                                                    <div class="form-row">
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="Label61" runat="server">Zonal Manager</asp:Label>
                                                                        </div>
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="lblDMARAppStatusApplicationZMStat" runat="server"></asp:Label>
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

                                                        <asp:LinkButton ID="lnkDMARApplicationStatusDetailsFake" runat="server"></asp:LinkButton>
                                                        <cc1:ModalPopupExtender ID="DMARApplicationStatusDetailsPopup" runat="server" TargetControlID="lnkDMARApplicationStatusDetailsFake" PopupControlID="PnlDMARApplicationStatusDetails"
                                                            BackgroundCssClass="modalBackground">
                                                        </cc1:ModalPopupExtender>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelDMARAppnStatus" runat="server" DisplayAfter="0">
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
                                </div>
                                <div class="tab-pane fade" id="nav-NavDMSEAppnProcess" role="tabpanel" aria-labelledby="nav-NavDMSEAppnProcess-tab">
                                    <asp:UpdatePanel ID="UpdatePanelDMSEAppnProcess" runat="server">
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnDMSEDownloadExcelForCEO" />
                                        </Triggers>
                                        <ContentTemplate>
                                            <div class="flex-container">
                                                <div class="navFormHeading">
                                                    <asp:Label runat="server">Self Employment Application Process - District Manager</asp:Label>
                                                </div>
                                                <div class="divGridview">
                                                    <div class="text-center">
                                                        <asp:GridView ID="gvDMSEApproveProcess" runat="server" class="GridView" AutoGenerateColumns="False" OnRowDataBound="gvDMSEApproveProcess_RowDataBound" DataKeyNames="ApplicationNumber,RDNumber,AadharNum,ApplicantName" Style="align-content: center;">
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ApplicationNumber")%>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtAppNum" runat="server" Text='<%# Eval("ApplicationNumber") %>' Enabled="false" />
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="180px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Applicant Name" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ApplicantName") + "<br />" + Eval("Gender")+ "<br />"+"PH : "+ Eval("PhysicallyChallenged") %>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="RD Number " ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("RDNumber")+ "<br />"+  Eval("ApplicantNameNC") + "<br />" + "Income: " + Eval("AnualIncome")%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="160px" Font-Bold="true" ForeColor="Red" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="DOB" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%#Eval("ApplicantDob")+ " ("+ Eval("Age") + ")" %>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="160px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Email ID &amp; Mobile Number" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("EmailID") + "<br />" +  Eval("MobileNumber")%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="180px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Address" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ParmanentAddress") + "<br />" + Eval("ParDistrict")+"(D)"+ "<br />" + Eval("ParTaluk")+"(T)"+ "<br />" + Eval("ParConstituency")+"(C)"+ "<br />" + Eval("ParPincode")+"(P)"%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Bank Details" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnDMSEDisplayBankDetails" class="ViewButton" runat="server" Text="View" OnClick="btnDMSEDisplayBankDetails_Click" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="CWStatus" HeaderText="Case Worker" HeaderStyle-Width="10%" ItemStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="80px" HeaderStyle-CssClass="text-center text-center font-weight-bold" />
                                                                <asp:BoundField DataField="DMStatus" HeaderText="Status" HeaderStyle-Width="10%" ItemStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="80px" HeaderStyle-CssClass="text-center text-center font-weight-bold" />
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Action" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnDMSEApprove" runat="server" OnClick="btnDMSEApprove_Click" class="EligibleButton" Text="Eligible" /><br />
                                                                        <asp:Button ID="btnDMSEHold" runat="server" OnClick="btnDMSEHold_Click" class="HoldButton" Text="Hold" Visible="false" /><br />
                                                                        <asp:Button ID="btnDMSEReject" runat="server" OnClick="btnDMSEReject_Click" class="InEligibleButton" Text="Ineligible" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                                </asp:TemplateField>

                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                                <div class="text-center">
                                                    <asp:Button ID="btnDMSEDownloadExcelForCEO" class="DownloadButton" Text="Download Excel" runat="server" OnClick="btnDMSEDownloadExcelForCEO_Click" />
                                                </div>
                                                <asp:Panel ID="PnlDMSEBankDetails" runat="server" CssClass="modalPopup PopupPanel" Width="50%" Style="display: none;">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label5" class="" runat="server" Text="Bank Details"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label6" runat="server">Application Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMSEBDApplicationNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label8" runat="server">Account Holder Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMSEBDAccountHolderName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label10" runat="server">Account Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMSEBDAccountNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label12" runat="server">Bank Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMSEBDBankName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label20" runat="server">Branch Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMSEBDBranchName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label22" runat="server">IFSC Code</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMSEBDIFSCCode" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label28" runat="server">Address</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMSEBDBankAddress" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="form-row-Botton">
                                                                    <asp:Button ID="Button1" runat="server" CssClass="ActionButton" Text="OK" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkDMSEBankDetailsFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="DMSEBankDetailsPopup" runat="server" TargetControlID="lnkDMSEBankDetailsFake" PopupControlID="PnlDMSEBankDetails"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlDMSEConfirmHold" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label32" class="" runat="server" Text="Confirm Hold"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label34" runat="server" Text="Application Number"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDMSEConfirmHoldAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label42" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDMSEConfirmHoldAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label46" runat="server" Text="Reason"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtDMSEConfirmHoldAppReason" CssClass="PopupTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblDMSEConfirmHoldAppReasonError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnDMSEConfirmHoldApplication" runat="server" CssClass="ActionButton" Text="Hold" OnClick="btnDMSEConfirmHoldApplication_Click" />
                                                                    <asp:Button ID="Button5" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkDMSEConfirmHoldFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="DMSEConfirmHoldPopup" runat="server" PopupControlID="PnlDMSEConfirmHold"
                                                    TargetControlID="lnkDMSEConfirmHoldFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlDMSEConfirmApprove" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label39" class="" runat="server" Text="Confirm Eligible"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label49" runat="server" Text="Application Number"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDMSEConfirmApproveAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label51" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDMSEConfirmApproveAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnDMSEConfirmApproveApplication" runat="server" CssClass="ActionButton" Text="Eligible" OnClick="btnDMSEConfirmApproveApplication_Click" />
                                                                    <asp:Button ID="Button10" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkDMSEConfirmApproveFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="DMSEConfirmApprovePopup" runat="server" PopupControlID="PnlDMSEConfirmApprove"
                                                    TargetControlID="lnkDMSEConfirmApproveFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlDMSERejectReason" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label30" class="" runat="server" Text="Confirm Inelegible"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label31" runat="server" Text="Application Number"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDMSEConfirmRejectAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label33" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDMSEConfirmRejectAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label158" runat="server"> Select Reason<span style="color:red"> *</span></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input" style="flex-direction: column">
                                                                    <asp:RadioButton ID="rbDMSEConfirmRejectReasonName" runat="server" Class="radioButton" GroupName="DMSEConfirmRejectReason" Text="Name Mismatch" AutoPostBack="true" OnCheckedChanged="rbDMSEConfirmRejectReasonName_CheckedChanged" /><br />
                                                                    <asp:RadioButton ID="rbDMSEConfirmRejectReasonOther" runat="server" Class="radioButton" GroupName="DMSEConfirmRejectReason" Text="Other" AutoPostBack="true" OnCheckedChanged="rbDMSEConfirmRejectReasonName_CheckedChanged" /><br />
                                                                    <asp:Label runat="server" ID="lblDMSEConfirmRejectAppReasonSelectionError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row" id="divDMSERejectReason" runat="server" visible="false">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMSERejectLabel" runat="server"><span style="color:red"> *</span></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtDMSEConfirmRejectAppReason" CssClass="PopupTextBox" Style="height: 80px" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblDMSEConfirmRejectAppReasonError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnDMSEConfirmRejectApplication" runat="server" CssClass="ActionButton" Text="Reject" OnClick="btnDMSEConfirmRejectApplication_Click" />
                                                                    <asp:Button ID="Button4" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkDMSERejectReasonFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="DMSEConfirmRejectPopup" runat="server" PopupControlID="PnlDMSERejectReason"
                                                    TargetControlID="lnkDMSERejectReasonFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelDMSEAppnStatus" runat="server" DisplayAfter="0">
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
                                </div>
                                <div class="tab-pane fade" id="nav-NavCEOSEAppnProcess" role="tabpanel" aria-labelledby="nav-NavCEOSEAppnProcess-tab">
                                    <asp:UpdatePanel ID="UpdatePanelCEOSEAppnProcess" runat="server">
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnSEUploadCeoDoc" />
                                            <asp:PostBackTrigger ControlID="btDMSECEODownloadApproved" />
                                            <asp:PostBackTrigger ControlID="btDMSECEODownloadWaiting" />
                                            <asp:PostBackTrigger ControlID="btDMSECEODownloadHold" />
                                            <asp:PostBackTrigger ControlID="btDMSECEODownloadReject" />
                                        </Triggers>
                                        <ContentTemplate>
                                            <div class="flex-container">
                                                <div class="navFormHeading">
                                                    <asp:Label runat="server">Self Employment Application Process - CEO Committee</asp:Label>
                                                </div>
                                                <div id="divCEOSEFileUpload" class="text-center" runat="server">
                                                    <asp:FileUpload ID="FileCeoSE" runat="server" style="margin-left:45%" />
                                                    <asp:Button ID="btnSEUploadCeoDoc" runat="server" class="DownloadButton" OnClick="btnSEUploadCeoDoc_Click" Width="15%" Text="Upload CEO Document" />
                                                </div>
                                                <div class="divGridview" id="divCEOSEApplicationProcess" runat="server">
                                                    <div class="text-center">
                                                        <asp:GridView ID="gvCEOSEApproveProcess" runat="server" class="GridView" OnRowDataBound="gvCEOSEApproveProcess_RowDataBound" AutoGenerateColumns="False" DataKeyNames="ApplicationNumber,RDNumber,AadharNum,ApplicantName" Style="align-content: center;">
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ApplicationNumber")%>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtAppNum" runat="server" Text='<%# Eval("ApplicationNumber") %>' Enabled="false" />
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="180px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Applicant Name" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ApplicantName") + "<br />" + Eval("Gender")+ "<br />"+"PH : "+ Eval("PhysicallyChallenged") %>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="RD Number " ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("RDNumber")+ "<br />"+  Eval("ApplicantNameNC") + "<br />" + "Income: " + Eval("AnualIncome")%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="160px" Font-Bold="true" ForeColor="Red" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="DOB" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%#Eval("ApplicantDob")+ " ("+ Eval("Age") + ")" %>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="160px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Email ID &amp; Mobile Number" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("EmailID") + "<br />" +  Eval("MobileNumber")%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="180px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Address" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ParmanentAddress") + "<br />" + Eval("ParDistrict")+"(D)"+ "<br />" + Eval("ParTaluk")+"(T)"+ "<br />" + Eval("ParConstituency")+"(C)"+ "<br />" + Eval("ParPincode")+"(P)"%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Bank Details" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnCEOSEDisplayBankDetails" class="ViewButton" runat="server" Text="View" OnClick="btnCEOSEDisplayBankDetails_Click" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="CEOStatus" HeaderText="Status" HeaderStyle-Width="10%" ItemStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="80px" HeaderStyle-CssClass="text-center text-center font-weight-bold" />
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Action" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnCEOSEApprove" runat="server" OnClick="btnCEOSEApprove_Click" class="EligibleButton" Text="Approve" /><br />
                                                                        <asp:Button ID="btnCEOSEWaiting" runat="server" OnClick="btnCEOSEWaiting_Click" class="WaitingButton" Text="Waiting" /><br />
                                                                        <asp:Button ID="btnCEOSEHold" runat="server" OnClick="btnCEOSEHold_Click" class="HoldButton" Text="Hold" /><br />
                                                                        <asp:Button ID="btnCEOASEReject" runat="server" OnClick="btnCEOSEReject_Click" class="InEligibleButton" Text="Reject" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                                </asp:TemplateField>

                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                    <div class="text-center">
                                                        <asp:Button ID="btnDMSECEOGenerateReport" class="DownloadButton" Text="Generate Report" runat="server" OnClick="btnDMSECEOGenerateReport_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
                                                    </div>
                                                </div>
                                                
                                                <div id="divDMSECEOReportDownload" runat="server"  visible="false">
                                                    <div class="text-center">
                                                        <asp:Button ID="btDMSECEODownloadApproved" class="DownloadButton" Text="Download Approved" runat="server" UseSubmitBehavior="false" OnClick="btDMSECEODownloadApproved_Click"  />
                                                        <asp:Button ID="btDMSECEODownloadWaiting" class="DownloadButton" Text="Download Waiting" runat="server" UseSubmitBehavior="false" OnClick="btDMSECEODownloadWaiting_Click"  />
                                                        <asp:Button ID="btDMSECEODownloadHold" class="DownloadButton" Text="Download Hold" runat="server" UseSubmitBehavior="false" OnClick="btDMSECEODownloadHold_Click"  />
                                                        <asp:Button ID="btDMSECEODownloadReject" class="DownloadButton" Text="Download Reject" runat="server" UseSubmitBehavior="false" OnClick="btDMSECEODownloadReject_Click"  />
                                                    </div>
                                                </div>

                                                <asp:Panel ID="PnlCEOSEBankDetails" runat="server" CssClass="modalPopup PopupPanel" Width="50%" Style="display: none;">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label92" class="" runat="server" Text="Bank Details"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label93" runat="server">Application Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCEOSEBDApplicationNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label94" runat="server">Account Holder Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCEOSEBDAccountHolderName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label95" runat="server">Account Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCEOSEBDAccountNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label96" runat="server">Bank Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCEOSEBDBankName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label97" runat="server">Branch Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCEOSEBDBranchName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label98" runat="server">IFSC Code</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCEOSEBDIFSCCode" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label99" runat="server">Address</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCEOSEBDBankAddress" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="form-row-Botton">
                                                                    <asp:Button ID="Button15" runat="server" CssClass="ActionButton" Text="OK" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkCEOSEBankDetailsFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="CEOSEBankDetailsPopup" runat="server" TargetControlID="lnkCEOSEBankDetailsFake" PopupControlID="PnlCEOSEBankDetails"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlCEOSEConfirmHold" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label100" class="" runat="server" Text="Confirm Hold"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label101" runat="server" Text="Application Number"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblCEOSEConfirmHoldAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label102" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblCEOSEConfirmHoldAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label103" runat="server" Text="Reason"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtCEOSEConfirmHoldAppReason" CssClass="PopupTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblCEOSEConfirmHoldAppReasonError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnCEOSEConfirmHoldApplication" runat="server" CssClass="ActionButton" Text="Hold" OnClick="btnCEOSEConfirmHoldApplication_Click" />
                                                                    <asp:Button ID="Button16" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkCEOSEConfirmHoldFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="CEOSEConfirmHoldPopup" runat="server" PopupControlID="PnlCEOSEConfirmHold"
                                                    TargetControlID="lnkCEOSEConfirmHoldFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlCEOSEConfirmApprove" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label104" class="" runat="server" Text="Confirm Approve"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label105" runat="server" Text="Application Number"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblCEOSEConfirmApproveAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label106" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblCEOSEConfirmApproveAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label171" runat="server" Text="Quota"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:DropDownList ID="drpCEOSEQuota" Class="NeuoDropdown" runat="server">
                                                                        <asp:ListItem Value="0">--SELECT--</asp:ListItem>
                                                                        <asp:ListItem Value="ActionPlan">Action Plan</asp:ListItem>
                                                                        <asp:ListItem Value="Adyakshara">Adyakshara VK</asp:ListItem>
                                                                        <asp:ListItem Value="Government">Government VK</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:Label runat="server" ID="Label172" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label173" runat="server" Text="Approved Loan Amount"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtCEOLoanAmount" runat="server" TextMode="Number" Class="PopupTextBoxSingleLine"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblCEOLoanAmountError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnCEOSEConfirmApproveApplication" runat="server" CssClass="ActionButton" Text="Approve" OnClick="btnCEOSEConfirmApproveApplication_Click" />
                                                                    <asp:Button ID="Button17" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkCEOSEConfirmApproveFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="CEOSEConfirmApprovePopup" runat="server" PopupControlID="PnlCEOSEConfirmApprove"
                                                    TargetControlID="lnkCEOSEConfirmApproveFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlCEOSEConfirmWaiting" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label26" class="" runat="server" Text="Confirm Waiting"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label159" runat="server" Text="Application Number"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblCEOSEConfirmWaitingAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label160" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblCEOSEConfirmWaitingAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnCEOSEConfirmWaitingApplication" runat="server" CssClass="ActionButton" Text="Waiting" OnClick="btnCEOSEConfirmWaitingApplication_Click" />
                                                                    <asp:Button ID="Button14" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkCEOSEConfirmWaitingFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="CEOSEConfirmWaitingPopup" runat="server" PopupControlID="PnlCEOSEConfirmWaiting"
                                                    TargetControlID="lnkCEOSEConfirmWaitingFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlCEOSERejectReason" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label107" class="" runat="server" Text="Confirm Inelegible"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label108" runat="server" Text="Application Number"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblCEOSEConfirmRejectAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label109" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblCEOSEConfirmRejectAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label192" runat="server">Select Reason<span style="color:red"> *</span></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input" style="flex-direction: column">
                                                                    <asp:RadioButton ID="rbCEOSEConfirmRejectReasonNotSelected" runat="server" Class="radioButton" GroupName="CEOSEConfirmRejectReason" Text="Not Selected" AutoPostBack="true" OnCheckedChanged="rbCEOSEConfirmRejectReasonNotSelected_CheckedChanged" /><br />
                                                                    <asp:RadioButton ID="rbCEOSEConfirmRejectReasonOther" runat="server" Class="radioButton" GroupName="CEOSEConfirmRejectReason" Text="Other" AutoPostBack="true" OnCheckedChanged="rbCEOSEConfirmRejectReasonNotSelected_CheckedChanged" /><br />
                                                                    <asp:Label runat="server" ID="lblCEOSEConfirmRejectAppReasonSelectionError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row" id="divCEOSERejectReason" runat="server">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCEOSERejectLabel" runat="server" Text="Reason"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtCEOSEConfirmRejectAppReason" CssClass="PopupTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblCEOSEConfirmRejectAppReasonError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnCEOSEConfirmRejectApplication" runat="server" CssClass="ActionButton" Text="Reject" OnClick="btnCEOSEConfirmRejectApplication_Click" />
                                                                    <asp:Button ID="Button18" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkCEOSERejectReasonFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="CEOSEConfirmRejectPopup" runat="server" PopupControlID="PnlCEOSERejectReason"
                                                    TargetControlID="lnkCEOSERejectReasonFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelCEOSEAppnProcess" runat="server" DisplayAfter="0">
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
                                </div>
                                <div class="tab-pane fade" id="nav-NavDOCSEAppnProcess" role="tabpanel" aria-labelledby="nav-NavDOCSEAppnProcess-tab">
                                    <asp:UpdatePanel ID="UpdatePanelDOCSEAppnProcess" runat="server">
                                        <ContentTemplate>
                                            <div class="flex-container">
                                                <div class="navFormHeading">
                                                    <asp:Label runat="server">Self Employment Application Process - Documentation</asp:Label>
                                                </div>
                                                <div class="divGridview">
                                                    <div class="text-center">
                                                        <asp:GridView ID="gvDOCSEApproveProcess" runat="server" class="GridView" OnRowDataBound="gvDOCSEApproveProcess_RowDataBound" AutoGenerateColumns="False" DataKeyNames="ApplicationNumber,RDNumber,AadharNum,ApplicantName" Style="align-content: center;">
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ApplicationNumber")%>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtAppNum" runat="server" Text='<%# Eval("ApplicationNumber") %>' Enabled="false" />
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="180px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Applicant Name" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ApplicantName") + "<br />" + Eval("Gender")+ "<br />"+"PH : "+ Eval("PhysicallyChallenged") %>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="RD Number " ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("RDNumber")+ "<br />"+  Eval("ApplicantNameNC") + "<br />" + "Income: " + Eval("AnualIncome")%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="160px" Font-Bold="true" ForeColor="Red" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="DOB" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%#Eval("ApplicantDob")+ " ("+ Eval("Age") + ")" %>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="160px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Email ID &amp; Mobile Number" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("EmailID") + "<br />" +  Eval("MobileNumber")%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="180px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Address" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ParmanentAddress") + "<br />" + Eval("ParDistrict")+"(D)"+ "<br />" + Eval("ParTaluk")+"(T)"+ "<br />" + Eval("ParConstituency")+"(C)"+ "<br />" + Eval("ParPincode")+"(P)"%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Bank Details" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnDOCSEDisplayBankDetails" class="ViewButton" runat="server" Text="View" OnClick="btnDOCSEDisplayBankDetails_Click" /><br />
                                                                        <asp:Button ID="btnDOCSEDisplayBankDetailsUpdate" class="ViewButton" runat="server" Text='<%# Eval("BDStatus") %>' OnClick="btnDOCSEDisplayBankDetailsUpdate_Click" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="DOCStatus" HeaderText="Status" HeaderStyle-Width="10%" ItemStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="80px" HeaderStyle-CssClass="text-center text-center font-weight-bold" />
                                                                <asp:ImageField HeaderText="Image" DataImageUrlField="ImgPath" ControlStyle-Height="80" ControlStyle-Width="65" ItemStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-center font-weight-bold"></asp:ImageField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Action" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnDOCSEApprove" runat="server" OnClick="btnDOCSEApprove_Click" class="EligibleButton" Text="Document Verified" /><br />
                                                                        <asp:Button ID="btnDOCSEHold" runat="server" OnClick="btnDOCSEHold_Click" class="HoldButton" Text="Hold" /><br />
                                                                        <asp:Button ID="btnDOCSEReject" runat="server" OnClick="btnDOCSEReject_Click" class="InEligibleButton" Text="Reject" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                                <div class="text-center">
                                                    <asp:Button ID="btnDMSESubmitToZM" class="DownloadButton" Text="Submit To ZM" runat="server" OnClick="btnDMSESubmitToZM_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
                                                </div>
                                                <asp:Panel ID="PnlDOCSEBankDetails" runat="server" CssClass="modalPopup PopupPanel" Width="50%" Style="display: none;">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label139" class="" runat="server" Text="Bank Details"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label140" runat="server">Application Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDOCSEBDApplicationNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label141" runat="server">Account Holder Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDOCSEBDAccountHolderName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label142" runat="server">Account Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDOCSEBDAccountNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label143" runat="server">Bank Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDOCSEBDBankName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label144" runat="server">Branch Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDOCSEBDBranchName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label145" runat="server">IFSC Code</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDOCSEBDIFSCCode" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label146" runat="server">Address</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDOCSEBDBankAddress" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="form-row-Botton">
                                                                    <asp:Button ID="Button24" runat="server" CssClass="ActionButton" Text="OK" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkDOCSEBankDetailsFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="DOCSEBankDetailsPopup" runat="server" TargetControlID="lnkDOCSEBankDetailsFake" PopupControlID="PnlDOCSEBankDetails"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlDOCSEConfirmHold" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label147" class="" runat="server" Text="Confirm Hold"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label148" runat="server" Text="Application Number"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDOCSEConfirmHoldAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label149" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDOCSEConfirmHoldAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label150" runat="server" Text="Reason"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtDOCSEConfirmHoldAppReason" CssClass="PopupTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblDOCSEConfirmHoldAppReasonError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnDOCSEConfirmHoldApplication" runat="server" CssClass="ActionButton" Text="Hold" OnClick="btnDOCSEConfirmHoldApplication_Click" />
                                                                    <asp:Button ID="Button25" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkDOCSEConfirmHoldFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="DOCSEConfirmHoldPopup" runat="server" PopupControlID="PnlDOCSEConfirmHold"
                                                    TargetControlID="lnkDOCSEConfirmHoldFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlDOCSEConfirmApprove" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label151" class="" runat="server" Text="Confirm Eligible"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label152" runat="server" Text="Application Number"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDOCSEConfirmApproveAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label153" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDOCSEConfirmApproveAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnDOCSEConfirmApproveApplication" runat="server" CssClass="ActionButton" Text="Document Verified" OnClick="btnDOCSEConfirmApproveApplication_Click" />
                                                                    <asp:Button ID="Button26" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkDOCSEConfirmApproveFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="DOCSEConfirmApprovePopup" runat="server" PopupControlID="PnlDOCSEConfirmApprove"
                                                    TargetControlID="lnkDOCSEConfirmApproveFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlDOCSERejectReason" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label154" class="" runat="server" Text="Confirm Inelegible"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label155" runat="server" Text="Application Number"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDOCSEConfirmRejectAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label156" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDOCSEConfirmRejectAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label75" runat="server"> Select Reason<span style="color:red"> *</span></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input" style="flex-direction: column">
                                                                    <asp:RadioButton ID="rbDOCSEConfirmRejectReasonNotInterested" runat="server" Class="radioButton" GroupName="DOCSEConfirmRejectReason" Text="Not Selected" AutoPostBack="true" OnCheckedChanged="rbDOCSEConfirmReject_CheckedChanged" /><br />
                                                                    <asp:RadioButton ID="rbDOCSEConfirmRejectReasonFamilyMember" runat="server" Class="radioButton" GroupName="DOCSEConfirmRejectReason" Text="Family Member Availed" AutoPostBack="true" OnCheckedChanged="rbDOCSEConfirmReject_CheckedChanged" /><br />
                                                                    <asp:RadioButton ID="rbDOCSEConfirmRejectReasonVoluntarilyrejected" runat="server" Class="radioButton" GroupName="DOCSEConfirmRejectReason" Text="Voluntarily Rejected" AutoPostBack="true" OnCheckedChanged="rbDOCSEConfirmReject_CheckedChanged" /><br />
                                                                    <asp:RadioButton ID="rbDOCSEConfirmRejectReasonDeath" runat="server" Class="radioButton" GroupName="DOCSEConfirmRejectReason" Text="Applicant Died" AutoPostBack="true" OnCheckedChanged="rbDOCSEConfirmReject_CheckedChanged" /><br />
                                                                    <asp:RadioButton ID="rbDOCSEConfirmRejectReasonOther" runat="server" Class="radioButton" GroupName="DOCSEConfirmRejectReason" Text="Other" AutoPostBack="true" OnCheckedChanged="rbDOCSEConfirmReject_CheckedChanged" /><br />
                                                                    <asp:Label runat="server" ID="lblDOCSEConfirmRejectAppReasonSelectionError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row" id="divDOCSERejectReason" runat="server">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDOCSERejectLabel" runat="server" Text="Reason"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtDOCSEConfirmRejectAppReason" CssClass="PopupTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblDOCSEConfirmRejectAppReasonError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnDOCSEConfirmRejectApplication" runat="server" CssClass="ActionButton" Text="Reject" OnClick="btnDOCSEConfirmRejectApplication_Click" />
                                                                    <asp:Button ID="Button27" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkDOCSERejectReasonFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="DOCSEConfirmRejectPopup" runat="server" PopupControlID="PnlDOCSERejectReason"
                                                    TargetControlID="lnkDOCSERejectReasonFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlDOCSEBankDetailsUpdate" runat="server" CssClass="modalPopup PopupPanel" Width="50%" Style="display: none;">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label174" class="" runat="server" Text="Update Bank Details"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label175" runat="server">Application Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDOCSEBDUpdateApplicationNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label176" runat="server">Account Holder Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblDOCSEBDUpdateAccountHolderName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label177" runat="server">Account Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtDOCSEBDUpdateAccountNumber" CssClass="PopupTextBoxSingleLine" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label178" runat="server">Bank Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtDOCSEBDUpdateBankName" CssClass="PopupTextBoxSingleLine" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label179" runat="server">Branch Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtDOCSEBDUpdateBranchName" CssClass="PopupTextBoxSingleLine" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label180" runat="server">IFSC Code</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtDOCSEBDUpdateIFSCCode" CssClass="PopupTextBoxSingleLine" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label181" runat="server">Address</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtDOCSEBDUpdateBankAddress" CssClass="PopupTextBox" Height="80px" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label182" runat="server">Select Reason</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:DropDownList ID="drpDOCSEBankModifyReason" runat="server" class="NeuoDropdown">
                                                                        <asp:ListItem Value="0">--SELECE REASON--</asp:ListItem>
                                                                        <asp:ListItem Value="Jandhan Account">Jandhan Account</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid IFSC Code">Wrong IFSC Code</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid A/C Number">Invalid A/C Number</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid Branch">Invalid Branch</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid Bank">Invalid Bank</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid Address">Invalid Address</asp:ListItem>
                                                                    </asp:DropDownList><br />
                                                                    <asp:Label runat="server" ID="lblDOCSEBDUpdateError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="form-row-Botton">
                                                                    <asp:Button ID="btnDOCSEBDUpdate" runat="server" CssClass="ActionButton" Text="Update" OnClick="btnDOCSEBDUpdate_Click" />
                                                                    <asp:Button ID="Button29" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkDOCSEBankDetailsUpdateFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="DOCSEBankDetailsUpdatePopup" runat="server" TargetControlID="lnkDOCSEBankDetailsUpdateFake" PopupControlID="PnlDOCSEBankDetailsUpdate"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelDOCSEAppnProcess" runat="server" DisplayAfter="0">
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
                                </div>
                                <div class="tab-pane fade" id="nav-NavDMSEAppnStatus" role="tabpanel" aria-labelledby="nav-NavDMSEAppnStatus-tab">
                                    <asp:UpdatePanel ID="UpdatePanelDMSEAppnStatus" runat="server">
                                        <ContentTemplate>
                                            <div class="flex-container">
                                                <div class="navFormHeading">
                                                    <asp:Label runat="server">Self Employment Application Status</asp:Label>
                                                </div>
                                                <div class="navFormBody">
                                                    <div class="formFlex-row">
                                                        <asp:Label runat="server" class="labelStyle1" Text="Application Number"></asp:Label>
                                                        <asp:TextBox ID="txtDMSEApplicationStatus" class="textboxStyle1" runat="server"></asp:TextBox>
                                                        <asp:Button ID="btnDMSEGetApplicationStatus" runat="server" Text="Get Status" OnClick="btnDMSEGetApplicationStatus_Click" />
                                                    </div>
                                                </div>
                                                <asp:Panel ID="PnlDMSEApplicationStatusDetails" runat="server" CssClass="modalPopup PopupPanel" Width="50%" Style="display: none;">
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
                                                                    <asp:Label ID="lblDMSEAppStatusApplicationNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label56" runat="server">Applicant Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMSEAppStatusApplicationName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label60" runat="server">Case Worker</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMSEAppStatusApplicationCWStat" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label63" runat="server">District Manager</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMSEAppStatusApplicationDMStat" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label65" runat="server">CEO Committee</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMSEAppStatusApplicationCEOStat" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label67" runat="server">Documentation</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMSEAppStatusApplicationDOCStat" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label69" runat="server">Zonal Manager</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblDMSEAppStatusApplicationZMStat" runat="server"></asp:Label>
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

                                                <asp:LinkButton ID="lnkDMSEApplicationStatusDetailsFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="DMSEApplicationStatusDetailsPopup" runat="server" TargetControlID="lnkDMSEApplicationStatusDetailsFake" PopupControlID="PnlDMSEApplicationStatusDetails"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                     <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelDMSEAppnStatus" runat="server" DisplayAfter="0">
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
                                </div>
                                <div class="tab-pane fade" id="nav-NavDMSEMobileUpdate" role="tabpanel" aria-labelledby="nav-NavDMSEMobileUpdate-tab">
                                    <asp:UpdatePanel ID="UpdatePanelDMSEMobileUpdate" runat="server">
                                        <ContentTemplate>
                                            <div class="flex-container ContantMain" id="divSEApplicationMail" runat="server">
                                                <div class="NeumorphicDiv">
                                                    <div class="navFormHeading">
                                                        <asp:Label runat="server">Self Employment Application - Update</asp:Label>
                                                    </div>
                                                    
                                                    <div id="divSEUD" class="form-row" runat="server">
                                                        <div class="form-row-label">
                                                            <asp:Label runat="server">Application Number<span style="color:red"> *</span></asp:Label>
                                                        </div>
                                                        <div class="form-row-input">
                                                            <asp:TextBox ID="txtSEUDApplicationNumber" CssClass="NeoTextBox" runat="server"></asp:TextBox><br />
                                                            <asp:Label ID="lblSEUDApplicationNumberError" runat="server" class="labelStyle1"></asp:Label>
                                                        </div>
                                                        <div class="form-row-Botton">
                                                            <asp:Button ID="btnSEUDGetDetails" runat="server" CssClass="DownloadButton" Text="Get Application" OnClick="btnSEUDGetDetails_Click" />
                                                        </div>
                                                    </div>
                                                    <div id="divSEUDDetails" runat="server" visible="false">
                                                        <div id="divSEUDApplicantDetails" class="form-row" runat="server">
                                                            <div class="form-row-label">
                                                                <asp:Label runat="server">Application Number</asp:Label>
                                                            </div>
                                                            <div class="form-row-input">
                                                                <asp:Label ID="lblSEUDApplicationNumber" runat="server" class="labelStyle1"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div id="div2" class="form-row" runat="server">
                                                            <div class="form-row-label">
                                                                <asp:Label runat="server">Applicant Name</asp:Label>
                                                            </div>
                                                            <div class="form-row-input">
                                                                <asp:Label ID="lblSEUDApplicantName" runat="server" class="labelStyle1"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div id="div3" class="form-row" runat="server">
                                                            <div class="form-row-label">
                                                                <asp:Label runat="server">Mobile Number</asp:Label>
                                                            </div>
                                                            <div class="form-row-input">
                                                                <asp:Label ID="lblSEUDApplicantMobileNumber" runat="server" class="labelStyle1"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div id="div1" class="form-row" runat="server">
                                                            <div class="form-row-label">
                                                                <asp:Label runat="server">Email ID</asp:Label>
                                                            </div>
                                                            <div class="form-row-input">
                                                                <asp:Label ID="lblSEUDEmailID" runat="server" class="labelStyle1"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div id="divSEUDMobileNumberUpdate" class="form-row" runat="server" >
                                                            <div class="form-row-label">
                                                                <asp:Label runat="server">New Mobile Number<span style="color:red"> *</span></asp:Label>
                                                            </div>
                                                            <div class="form-row-input">
                                                                <asp:TextBox ID="txtSEUDNewMobileNumber" CssClass="NeoTextBox" runat="server"></asp:TextBox><br />
                                                                <asp:Label ID="lblSEUDNewMobileNumberError" runat="server" class="labelStyle1"></asp:Label>
                                                            </div>
                                                            <div class="form-row-Botton">
                                                                <asp:Button ID="btnSEUDNewMobileNumber" runat="server" CssClass="DownloadButton" Text="Get Application" OnClick="btnSEUDNewMobileNumber_Click" />
                                                            </div>
                                                        </div>
                                                        <div id="div4" class="form-row" runat="server" >
                                                            <div class="form-row-label">
                                                                <asp:Label runat="server">New Alternate Number<span style="color:red"> *</span></asp:Label>
                                                            </div>
                                                            <div class="form-row-input">
                                                                <asp:TextBox ID="txtSEUDNewAlternateNumber" CssClass="NeoTextBox" runat="server"></asp:TextBox><br />
                                                                <asp:Label ID="lblSEUDNewMobileAlternateError" runat="server" class="labelStyle1"></asp:Label>
                                                            </div>
                                                            <div class="form-row-Botton">
                                                                <asp:Button ID="btnSEUDNewAlternateNumber" runat="server" CssClass="DownloadButton" Text="Get Application" OnClick="btnSEUDNewAlternateNumber_Click" />
                                                            </div>
                                                        </div>
                                                        <div id="div5" class="form-row" runat="server" >
                                                            <div class="form-row-label">
                                                                <asp:Label runat="server">New Email ID<span style="color:red"> *</span></asp:Label>
                                                            </div>
                                                            <div class="form-row-input">
                                                                <asp:TextBox ID="txtSEUDNewEmailID" CssClass="NeoTextBox" runat="server"></asp:TextBox><br />
                                                                <asp:Label ID="lblSEUDNewEmailIDError" runat="server" class="labelStyle1"></asp:Label>
                                                            </div>
                                                            <div class="form-row-Botton">
                                                                <asp:Button ID="btnSEUDNewEmailID" runat="server" CssClass="DownloadButton" Text="Get Application" OnClick="btnSEUDNewEmailID_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                      <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelDMSEMobileUpdate" runat="server" DisplayAfter="0">
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
