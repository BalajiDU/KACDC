<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZM_Approval.aspx.cs" Async="true" Inherits="KACDC.ApprovalPage.ZM_Approval" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Zonal Manager</title>
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

    <meta http-equiv="Content-Security-Policy" content="upgrade-insecure-requests">

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
            <asp:UpdatePanel runat="server" ID="UpdatePanelTopSidebar">
                <ContentTemplate>
                    <nav class="DisplayMenu" id="menu-1" style="display: none;">
                        <div class="navigation">
                            <div class="sidebar bar-block animate-left" id="mySidebar">
                                <ul class="mainmenu">
                                    <li><a>Arivu</a>
                                        <ul class="submenu">
                                            <li><a class="nav-item nav-link" id="nav-NavZMARCEODocument-tab" data-toggle="tab" href="#nav-NavZMARCEODocument" role="tab" aria-controls="nav-NavZMARCEODocument" aria-selected="false">CEO Document</a></li>
                                            <li><a class="nav-item nav-link" id="nav-NavZMARAppnProcess-tab" data-toggle="tab" href="#nav-NavZMARAppnProcess" role="tab" aria-controls="nav-NavZMARAppnProcess" aria-selected="false">Application Peocess</a></li>
                                            <li><a class="nav-item nav-link" id="nav-NavZMARRTGSRelease-tab" data-toggle="tab" href="#nav-NavZMARRTGSRelease" role="tab" aria-controls="nav-NavZMARRTGSRelease" aria-selected="false">RTGS Release</a></li>
<%--                                            <li><a class="nav-item nav-link" id="nav-NavZMARSanctionCopy-tab" data-toggle="tab" href="#nav-NavZMARSanctionCopy" role="tab" aria-controls="nav-NavZMARSanctionCopy" aria-selected="false">Sanctioned Copy</a></li>--%>
                                            <li><a class="nav-item nav-link" id="nav-NavZMARAppnStatus-tab" data-toggle="tab" href="#nav-NavZMARAppnStatus" role="tab" aria-controls="nav-NavZMARAppnStatus" aria-selected="false">Application Status</a></li>
                                        </ul>
                                    </li>
                                    <li><a>Self Employment</a>
                                        <ul class="submenu">
                                            <li><a class="nav-item nav-link" id="nav-NavZMSECEODocument-tab" data-toggle="tab" href="#nav-NavZMSECEODocument" role="tab" aria-controls="nav-NavZMSECEODocument" aria-selected="false">CEO Document</a></li>
                                            <li><a class="nav-item nav-link" id="nav-NavZMSEAppnProcess-tab" data-toggle="tab" href="#nav-NavZMSEAppnProcess" role="tab" aria-controls="nav-NavZMSEAppnProcess" aria-selected="false">Application Peocess</a></li>
                                            <li><a class="nav-item nav-link" id="nav-NavZMSERTGSRelease-tab" data-toggle="tab" href="#nav-NavZMSERTGSRelease" role="tab" aria-controls="nav-NavZMSERTGSRelease" aria-selected="false">RTGS Release</a></li>
<%--                                            <li><a class="nav-item nav-link" id="nav-NavZMSESanctionCopy-tab" data-toggle="tab" href="#nav-NavZMSESanctionCopy" role="tab" aria-controls="nav-NavZMSESanctionCopy" aria-selected="false">Sanctioned Copy</a></li>--%>
                                            <li><a class="nav-item nav-link" id="nav-NavZMSEAppnStatus-tab" data-toggle="tab" href="#nav-NavZMSEAppnStatus" role="tab" aria-controls="nav-NavZMSEAppnStatus" aria-selected="false">Application Status</a></li>
                                        </ul>
                                    </li>
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

                                
                                <li class="DisplayValueType"><a>Select District</a></li>
                                <li class="items">
                                    <asp:DropDownList ID="drpZoneSelDistrict" Class="NeuoDropdown" runat="server" OnSelectedIndexChanged="drpZoneSelDistrict_SelectedIndexChanged" AutoPostBack="true"  >
                                    </asp:DropDownList></li>
                                <li class="DisplayValueType"><a>Select Instalment</a></li>
                                <li class="items">
                                    <asp:DropDownList ID="drpArivuSelectYear" runat="server" class="NeuoDropdown" AutoPostBack="True" OnSelectedIndexChanged="drpArivuSelectYear_SelectedIndexChanged">
                                        <asp:ListItem Value="">--Select--</asp:ListItem>
                                        <asp:ListItem Value="1ST_INSTALMENT">1ST Instalment</asp:ListItem>
                                        <asp:ListItem Value="2ND_INSTALMENT">2ND Instalment</asp:ListItem>
                                        <asp:ListItem Value="3RD_INSTALMENT">3RD Instalment</asp:ListItem>
                                        <asp:ListItem Value="4TH_INSTALMENT">4TH Instalment</asp:ListItem>
                                        <asp:ListItem Value="5TH_INSTALMENT">5TH Instalment</asp:ListItem>
                                        <asp:ListItem Value="6TH_INSTALMENT">6TH Instalment</asp:ListItem>
                                    </asp:DropDownList></li>
                                <li class="Button">
                                    <asp:Button ID="btnCWLogout" runat="server" Text="Logout" CssClass="logoutButton" OnClick="btnCWLogout_Click" /></li>

                            </ul>
                        </nav>
                    </div>
                    <div class="Viewoverlay View-animate-opacity" onclick="w3_close()" id="myOverlay" style="z-index: 1"></div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelTopSidebar" runat="server" DisplayAfter="0">
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
                                                    <asp:Label ID="lblZMARWelMaleCountReceived" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblZMARWelMaleCountApproved" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblZMSEWelMaleCountReceived" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblZMSEWelMaleCountApproved" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Female</td>
                                                <td>
                                                    <asp:Label ID="lblZMARWelFemaleCountReceived" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblZMARWelFemaleCountApproved" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblZMSEWelFemaleCountReceived" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblZMSEWelFemaleCountApproved" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Person With Disabilities</td>
                                                <td>
                                                    <asp:Label ID="lblZMARWelPWDCountReceived" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblZMARWelPWDCountApproved" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblZMSEWelPWDCountReceived" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblZMSEWelPWDCountApproved" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Widow</td>
                                                <td>NA</td>
                                                <td>NA</td>
                                                <td>
                                                    <asp:Label ID="lblZMSEWelWidowCountReceived" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblZMSEWelWidowCountApproved" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Divorced</td>
                                                <td>NA</td>
                                                <td>NA</td>
                                                <td>
                                                    <asp:Label ID="lblZMSEWelDivorcedCountReceived" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblZMSEWelDivorcedCountApproved" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </div>

                                    <asp:Panel ID="PnlNotification" runat="server" CssClass="modalPopup" Style="display: none; padding: 5px; min-width: 50%; min-height: 30%; overflow: inherit; max-width: 80%;">
                                        <div class="form-row" style="justify-content: center">
                                            <div class="Popup-row-label-Heading">
                                                <asp:Label ID="Label26" class="" Style="margin-top: 20px;" runat="server" Text="Notification"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-row">
                                            <div class="Popup-row-label">

                                                <asp:Label ID="lblDisplayNotification" runat="server" Style="text-transform: none"></asp:Label>
                                            </div>
                                        </div>
                                        <footer>
                                            <div class="form-row" style="margin-bottom: 20px; position: absolute; right: 0; bottom: 0;">

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

                                    <div class="text-center">
                                        <asp:Button ID="btnOldProcess" class="DownloadButton" Text="Continue To 2019-20 Process" ForeColor="LightGoldenrodYellow" runat="server" OnClick="btnOldProcess_Click" />
                                    </div>

                                </div>
                                <div class="tab-pane fade active" id="nav-NavZMARCEODocument" role="tabpanel" aria-labelledby="nav-NavZMARCEODocument-tab">
                                    <div class="NeumorphicDiv" style="margin-top:5%">
                                        <asp:GridView ID="GvArivuCEODoc" CssClass="GridView col-lg-offset-2" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                                            RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000"
                                            AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="Id" HeaderText="File Number" />
                                                <asp:BoundField DataField="District" HeaderText="District" />
                                                <asp:BoundField DataField="DateTime" HeaderText="Uploded Date & Time" />
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkbtnArivuCEODoc" runat="server" Text="Download" OnClick="lnkbtnArivuCEODoc_Click"
                                                            CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="nav-NavZMARAppnProcess" role="tabpanel" aria-labelledby="nav-NavZMARAppnProcess-tab">
                                    <asp:UpdatePanel ID="UpdatePanelARApplicationProcess" runat="server">
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnARZMSubmit" />
                                            <asp:PostBackTrigger ControlID="btnARZMExportExcel" />
                                            <asp:PostBackTrigger ControlID="btnARZMPrintReject" />
                                        </Triggers>
                                        <ContentTemplate>
                                            <div class="flex-container">
                                                <div class="navFormHeading">
                                                    <asp:Label runat="server">Arivu Application Process</asp:Label>
                                                </div>
                                                
                                                <div class="divGridview">
                                                    <div class="text-center">
                                                        <asp:GridView ID="gvZMARApproveProcess" runat="server" class="GridView" OnRowDataBound="gvZMARApproveProcess_RowDataBound" AutoGenerateColumns="False" DataKeyNames="ApplicationNumber,ApplicantName,RDNumber,AadharNum,ClgHostel" Style="align-content: center;">
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ApplicationNumber")+ "<br />"+"<br />"+ Eval("ApprovedApplicationNum") %>
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
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="EmailID &amp; Mobile Number" ItemStyle-Width="220">
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
                                                                <asp:ImageField HeaderText="Image" DataImageUrlField="ImgPath" ControlStyle-Height="80" ControlStyle-Width="65" ItemStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-center font-weight-bold"></asp:ImageField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Bank Details" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnZMARDisplayBankDetails" class="ViewButton" runat="server" Text="View" OnClick="btnZMARDisplayBankDetails_Click" />
                                                                        <asp:Button ID="btnZMARDisplayBankDetailsUpdate" class="ViewButton" runat="server" Text='<%# Eval("BDStatus") %>' OnClick="btnZMARDisplayBankDetailsUpdate_Click" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="College Details" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnZMARDisplayCollegeDetails" class="ViewButton" runat="server" Text="View" OnClick="btnZMARDisplayCollegeDetails_Click" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                                                </asp:TemplateField>

                                                                <asp:BoundField DataField="ZMStatus" HeaderText="Status" HeaderStyle-Width="10%" ControlStyle-Width="150px" ItemStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="80px" HeaderStyle-CssClass="text-center text-center font-weight-bold" />

                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Action" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnZMARApprove" runat="server" OnClick="btnZMARApprove_Click" class="EligibleButton" Text="Approve" /><br />
                                                                        <asp:Button ID="btnZMARHold" runat="server" OnClick="btnZMARHold_Click" class="HoldButton" Text="Hold"  /><br />
                                                                        <asp:Button ID="btnZMARReject" runat="server" OnClick="btnZMARReject_Click" class="InEligibleButton" Text="Reject" />
                                                                        <asp:Button ID="btnZMARReturn" runat="server" OnClick="btnZMARReturn_Click" class="InEligibleButton" Text="Return to DM"  /><br />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                                </asp:TemplateField>

                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>


                                                <div class="flex-container" style="margin-top: 0">
                                                    <div class="NeumorphicDiv" style="width: 96%; display: flex; justify-content: space-around">
                                                        <div class="row">
                                                             <div class="">
                                                                <asp:Label ID="lblARZMApplicationCount" Width="250px" runat="server" CssClass="labelStyle1" style="color:whitesmoke" Text=""></asp:Label>
                                                            </div>
                                                            <div class="">
                                                                <asp:Label ID="lblARZMTotalSum" Width="250px" runat="server"  CssClass="labelStyle1" style="color:whitesmoke" Text=""></asp:Label>
                                                            </div>
                                                            <div class="">
                                                                <asp:TextBox ID="txtARZMChequeNumber" Visible="true" CssClass="NeoTextBox" placeholder="Cheque Number" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="">
                                                                <asp:Button ID="btnARZMGenerateReport" runat="server" CssClass="EligibleButton" Text="Generate Report" UseSubmitBehavior="false" OnClick="btnARZMGenerateReport_Click" /><%--OnClientClick="this.disabled='true'; this.value='Please wait...';"--%>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div id="divARZMReportDownload" class="flex-container" style="margin-top: 0" runat="server" visible="false">
                                                    <div class=" NeumorphicDiv text-center" style="width: 96%; display: flex; justify-content: space-around;">
                                                        <asp:Button ID="btnARZMSubmit" runat="server" CssClass="EligibleButton" Text="Download Bank Report" UseSubmitBehavior="false" OnClick="btnARZMSubmit_Click" Style="width: 80%" /><%--OnClientClick="this.disabled='true'; this.value='Please wait...';"--%>
                                                        <asp:Button ID="btnARZMExportExcel" runat="server" CssClass="ViewButton " Text="Excel" UseSubmitBehavior="false" OnClick="btnARZMExportExcel_Click" Style="width: 80%" />
                                                        <asp:Button ID="btnARZMPrintReject" runat="server" CssClass="InEligibleButton" OnClick="btnARZMPrintReject_Click" Text="Print Reject" Style="width: 80%" />
                                                    </div>
                                                </div>

                                                <asp:Panel ID="PnlBankDetails" runat="server" CssClass="modalPopup PopupPanel" Width="50%" Style="display: none;">
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
                                                                    <asp:Label ID="lblZMARBDApplicationNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label38" runat="server">Account Holder Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblZMARBAccountHolderName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label16" runat="server">Account Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblZMARBAccountNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label17" runat="server">Bank Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblZMARBBankName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label13" runat="server">Branch Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblZMARBBranch" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label18" runat="server">IFSC Code</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblZMARBIFSCCode" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label14" runat="server">Address</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblZMARBBankAddress" runat="server"></asp:Label>
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
                                                <cc1:ModalPopupExtender ID="ZMARBankDetailsPopup" runat="server" TargetControlID="lnkBankDetailsFake" PopupControlID="PnlBankDetails"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlZMARConfirmReject" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
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
                                                                    <asp:Label ID="lblZMARConfirmRejectAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label25" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblZMARConfirmRejectAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label35" runat="server"> Select Reason<span style="color:red"> *</span></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input" style="flex-direction: column">
                                                                    <asp:RadioButton ID="rbZMARConfirmRejectReasonName" runat="server" Class="radioButton" GroupName="ZMARConfirmRejectReason" Text="Name Mismatch" AutoPostBack="true" OnCheckedChanged="rbZMARConfirmRejectReasonName_CheckedChanged" /><br />
                                                                    <asp:RadioButton ID="rbZMARConfirmRejectReasonCET" runat="server" Class="radioButton" GroupName="ZMARConfirmRejectReason" Text="Invalid CET Certificate" AutoPostBack="true" OnCheckedChanged="rbZMARConfirmRejectReasonName_CheckedChanged" /><br />
                                                                    <asp:RadioButton ID="rbZMARConfirmRejectReasonOther" runat="server" Class="radioButton" GroupName="ZMARConfirmRejectReason" Text="Other" AutoPostBack="true" OnCheckedChanged="rbZMARConfirmRejectReasonName_CheckedChanged" /><br />
                                                                    <asp:Label runat="server" ID="lblZMARConfirmRejectAppReasonSelectionError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row" id="divZMARRejectReason" runat="server" visible="false">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblZMARRejectLabel" runat="server" Text="Reason"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtZMARConfirmRejectAppReason" CssClass="PopupTextBox" Height="80px" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblZMARConfirmRejectAppReasonError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnZMARConfirmRejectApplication" runat="server" CssClass="ActionButton" Text="Reject" OnClick="btnZMARConfirmRejectApplication_Click" />
                                                                    <asp:Button ID="Button3" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkZMARConfirmRejectFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="ZMARConfirmRejectPopup" runat="server" PopupControlID="PnlZMARConfirmReject"
                                                    TargetControlID="lnkZMARConfirmRejectFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlZMARConfirmHold" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
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
                                                                    <asp:Label ID="lblZMARConfirmHoldAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label43" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblZMARConfirmHoldAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label45" runat="server" Text="Reason"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtZMARConfirmHoldAppReason" CssClass="PopupTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblZMARConfirmHoldAppReasonError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnZMARConfirmHoldApplication" runat="server" CssClass="ActionButton" Text="Hold" OnClick="btnZMARConfirmHoldApplication_Click" />
                                                                    <asp:Button ID="Button8" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkZMARConfirmHoldFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="ZMARConfirmHoldPopup" runat="server" PopupControlID="PnlZMARConfirmHold"
                                                    TargetControlID="lnkZMARConfirmHoldFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                 <asp:Panel ID="PnlZMARConfirmReturn" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label103" class="" runat="server" Text="Confirm Return"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label104" runat="server" Text="Application Number"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblZMARConfirmReturnAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label105" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblZMARConfirmReturnAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label106" runat="server" Text="Reason"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtZMARConfirmReturnAppReason" CssClass="PopupTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblZMARConfirmReturnAppReasonError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnZMARConfirmReturnApplication" runat="server" CssClass="ActionButton" Text="Return" OnClick="btnZMARConfirmReturnApplication_Click" />
                                                                    <asp:Button ID="Button19" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkZMARConfirmReturnFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="ZMARConfirmReturnPopup" runat="server" PopupControlID="PnlZMARConfirmReturn"
                                                    TargetControlID="lnkZMARConfirmReturnFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlZMARConfirmApprove" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
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
                                                                    <asp:Label ID="lblZMARConfirmApproveAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label40" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblZMARConfirmApproveAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnZMARConfirmApproveApplication" runat="server" CssClass="ActionButton" Text="Eligible" OnClick="btnZMARConfirmApproveApplication_Click" />
                                                                    <asp:Button ID="Button7" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkZMARConfirmApproveFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="ZMARConfirmApprovePopup" runat="server" PopupControlID="PnlZMARConfirmApprove"
                                                    TargetControlID="lnkZMARConfirmApproveFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlCollegeDetails" runat="server" CssClass="modalPopup PopupPanel" Style="display: none; height: 90%; width: 80%;">
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
                                                                    <asp:Label ID="lblZMARClgPPApplicationNumber" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label4" runat="server">Name </asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblZMARClgPPApplicationName" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label7" runat="server">CET Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblZMARClgPPCETTicket" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label19" runat="server">Marks</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblZMARClgPPMarks" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label9" runat="server">College</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblZMARClgPPCollegeName" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label11" runat="server">Course</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblZMARClgPPCourse" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label21" runat="server">Hostel</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblZMARClgPPHostel" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label27" runat="server">Address</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblZMARClgPPClgAddress" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div>
                                                                <iframe id="application" runat="server" width="90%" height="400"></iframe>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="form-row-Botton">
                                                                    <asp:Button ID="btnPnlCollegeDetailsClose" runat="server" CssClass="ActionButton" Text="Close" OnClick="btnPnlCollegeDetailsClose_Click" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkCollegeDetailsFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="CollegeDetailsPopup" runat="server" TargetControlID="lnkCollegeDetailsFake" PopupControlID="PnlCollegeDetails"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>


                                                <asp:Panel ID="PnlAROtherDetails" runat="server" CssClass="modalPopup" Style="display: none; padding: 5px">
                                                    <div class="form-row" style="justify-content: center">
                                                        <div class="Popup-row-label-Heading">
                                                            <asp:Label ID="lblARNotificationHeading" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="Popup-row-label">
                                                            <asp:Label ID="lblARNotificationContent" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="form-row">

                                                        <div class="Popup-row-label">
                                                            <asp:Button ID="Button11" runat="server" CssClass="SubmitButton" Text="Ok" />
                                                        </div>
                                                    </div>

                                                </asp:Panel>

                                                <asp:LinkButton ID="lnkAROtherDetails" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="AROtherDetailsPopup" runat="server" TargetControlID="lnkAROtherDetails" PopupControlID="PnlAROtherDetails"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlZMARBankDetailsUpdate" runat="server" CssClass="modalPopup PopupPanel" Width="50%" Style="display: none;">
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
                                                                    <asp:Label ID="lblZMARBDUpdateApplicationNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label176" runat="server">Account Holder Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblZMARBDUpdateAccountHolderName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label177" runat="server">Account Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtZMARBDUpdateAccountNumber" CssClass="PopupTextBoxSingleLine" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label178" runat="server">Bank Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtZMARBDUpdateBankName" CssClass="PopupTextBoxSingleLine" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label179" runat="server">Branch Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtZMARBDUpdateBranchName" CssClass="PopupTextBoxSingleLine" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label180" runat="server">IFSC Code</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtZMARBDUpdateIFSCCode" CssClass="PopupTextBoxSingleLine" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label181" runat="server">Address</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtZMARBDUpdateBankAddress" CssClass="PopupTextBox" Height="80px" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label182" runat="server">Select Reason</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:DropDownList ID="drpZMARBankModifyReason" runat="server" class="NeuoDropdown">
                                                                        <asp:ListItem Value="0">--SELECE REASON--</asp:ListItem>
                                                                        <asp:ListItem Value="Jandhan Account">Jandhan Account</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid IFSC Code">Wrong IFSC Code</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid A/C Number">Invalid A/C Number</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid Branch">Invalid Branch</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid Bank">Invalid Bank</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid Address">Invalid Address</asp:ListItem>
                                                                    </asp:DropDownList><br />
                                                                    <asp:Label runat="server" ID="lblZMARBDUpdateError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="form-row-Botton">
                                                                    <asp:Button ID="btnZMARBDUpdate" runat="server" CssClass="ActionButton" Text="Update" OnClick="btnZMARBDUpdate_Click" />
                                                                    <asp:Button ID="Button29" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkZMARBankDetailsUpdateFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="ZMARBankDetailsUpdatePopup" runat="server" TargetControlID="lnkZMARBankDetailsUpdateFake" PopupControlID="PnlZMARBankDetailsUpdate"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelARApplicationProcess" runat="server" DisplayAfter="0">
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
                                <div class="tab-pane fade" id="nav-NavZMARRTGSRelease" role="tabpanel" aria-labelledby="nav-NavZMARRTGSRelease-tab">
                                    <asp:UpdatePanel ID="UpdatePanelZMARRTGSRelease" runat="server">
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnARZMReleaseSubmit" />
                                            <asp:PostBackTrigger ControlID="btnARZMReleaseExportExcel" />
                                            <asp:PostBackTrigger ControlID="btnARZMReleasePrintReject" />
                                        </Triggers>
                                        <ContentTemplate>
                                            <div class="flex-container">

                                                <div class="navFormHeading">
                                                    <asp:Label runat="server">Arivu Application RTGS Release </asp:Label>
                                                </div>

                                               <div class="divGridview">
                                                    <div class="text-center">
                                                        <asp:GridView ID="gvZMARReleaseProcess" runat="server" class="GridView" AutoGenerateColumns="False" DataKeyNames="ApplicationNumber,ApplicantName,ApprovedApplicationNum" Style="align-content: center; ">
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ApplicationNumber") + "<br />" + Eval("ApprovedApplicationNum")%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="240px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Applicant Name" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ApplicantName") %>
                                                                        <%--<asp:Button ID="btnZMDispPH" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnZMDispPH_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("PhysicallyChallenged") %>' />--%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Bank Details" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# "A/C No: " + Eval("AccountNumber")+ "<br />"%>
                                                                        <%# "Bank: " + Eval("BankName")+ "<br />" + " Branch: " + Eval("Branch")+ "<br />" + " IFSCCode: " + Eval("IFSCCode")+ "<br />" + " Address: " + Eval("BankAddress")%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Approve" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnZMArivuReleased" runat="server" class="EligibleButton" OnClick="btnZMArivuReleased_Click" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" ShowHeader="True" Text="RTGS Successful" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Bank Details Update" ItemStyle-Width="50">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnZMARDReleaseBankDetailsUpdate" runat="server" class="ViewButton" CommandArgument="<%# Container.DataItemIndex %>" OnClick="btnZMARReleaseBankDetailsUpdate_Click" HeaderStyle-CssClass="text-center text-center font-weight-bold" CausesValidation="false" ShowHeader="True" Text='<%# Eval("BDStatus") %>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>

                                                <div class="flex-container" style="margin-top: 0">
                                                    <div class="NeumorphicDiv" style="width: 96%; display: flex; justify-content: space-around">
                                                        <div class="row">
                                                            <div class="">
                                                                <asp:Label ID="lblARZMReleaseApplicationCount" Width="250px" runat="server" CssClass="labelStyle1" Style="color: whitesmoke" Text=""></asp:Label>
                                                            </div>
                                                            <div class="">
                                                                <asp:Label ID="lblARZMReleaseTotalSum" Width="250px" runat="server" CssClass="labelStyle1" Style="color: whitesmoke" Text=""></asp:Label>
                                                            </div>
                                                            <div class="">
                                                                <asp:TextBox ID="txtARZMReleaseChequeNumber" Visible="true" CssClass="NeoTextBox" placeholder="Cheque Number" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="">
                                                                <asp:Button ID="btnARZMReleaseGenerateReport" runat="server" CssClass="EligibleButton" Text="Generate Report" UseSubmitBehavior="false" OnClick="btnARZMReleaseGenerateReport_Click" /><%--OnClientClick="this.disabled='true'; this.value='Please wait...';"--%>
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div id="divARZMReleaseReportDownload" class="flex-container" style="margin-top: 0" runat="server" visible="false">
                                                    <div class=" NeumorphicDiv text-center" style="width: 96%; display: flex; justify-content: space-around;">
                                                        <asp:Button ID="btnARZMReleaseSubmit" runat="server" CssClass="EligibleButton" Text="Download Bank Report" UseSubmitBehavior="false" OnClick="btnARZMSubmit_Click" Style="width: 80%" /><%--OnClientClick="this.disabled='true'; this.value='Please wait...';"--%>
                                                        <asp:Button ID="btnARZMReleaseExportExcel" runat="server" CssClass="ViewButton " Text="Excel" UseSubmitBehavior="false" OnClick="btnARZMExportExcel_Click" Style="width: 80%" />
                                                        <asp:Button ID="btnARZMReleasePrintReject" runat="server" CssClass="InEligibleButton" OnClick="btnARZMPrintReject_Click" Text="Print Reject" Style="width: 80%" />
                                                    </div>
                                                </div>


                                                <asp:Panel ID="PnlZMARConfirmRelease" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label77" class="" runat="server" Text="Confirm Approve"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label78" runat="server" Text="Application Number"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblZMARConfirmReleaseAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label81" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblZMARConfirmReleaseAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label82" runat="server" Text="Loan Number"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblZMARConfirmReleaseLoanNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnZMARConfirmReleaseApplication" runat="server" CssClass="ActionButton" Text="Released" OnClick="btnZMARConfirmReleaseApplication_Click" />
                                                                    <asp:Button ID="Button14" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkZMARConfirmReleaseFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="ZMARConfirmReleasePopup" runat="server" PopupControlID="PnlZMARConfirmRelease"
                                                    TargetControlID="lnkZMARConfirmReleaseFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>


                                                <asp:Panel ID="PnlZMARBankDetailsUpdateRelease" runat="server" CssClass="modalPopup PopupPanel" Width="50%" Style="display: none;">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label92" class="" runat="server" Text="UpdateRelease Bank Details"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label93" runat="server">Application Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblZMARBDUpdateReleaseApplicationNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label94" runat="server">Account Holder Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblZMARBDUpdateReleaseAccountHolderName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label95" runat="server">Account Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtZMARBDUpdateReleaseAccountNumber" CssClass="PopupTextBoxSingleLine" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label96" runat="server">Bank Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtZMARBDUpdateReleaseBankName" CssClass="PopupTextBoxSingleLine" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label97" runat="server">Branch Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtZMARBDUpdateReleaseBranchName" CssClass="PopupTextBoxSingleLine" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label98" runat="server">IFSC Code</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtZMARBDUpdateReleaseIFSCCode" CssClass="PopupTextBoxSingleLine" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label99" runat="server">Address</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtZMARBDUpdateReleaseBankAddress" CssClass="PopupTextBox" Height="80px" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label100" runat="server">Select Reason</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:DropDownList ID="drpZMARBankModifyReleaseReason" runat="server" class="NeuoDropdown">
                                                                        <asp:ListItem Value="0">--SELECE REASON--</asp:ListItem>
                                                                        <asp:ListItem Value="Jandhan Account">Jandhan Account</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid IFSC Code">Wrong IFSC Code</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid A/C Number">Invalid A/C Number</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid Branch">Invalid Branch</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid Bank">Invalid Bank</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid Address">Invalid Address</asp:ListItem>
                                                                    </asp:DropDownList><br />
                                                                    <asp:Label runat="server" ID="lblZMARBDUpdateReleaseError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="form-row-Botton">
                                                                    <asp:Button ID="btnZMARBDUpdateRelease" runat="server" CssClass="ActionButton" Text="UpdateRelease" OnClick="btnZMARBDUpdateRelease_Click" />
                                                                    <asp:Button ID="Button16" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkZMARBankDetailsUpdateReleaseFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="ZMARBankDetailsUpdateReleasePopup" runat="server" TargetControlID="lnkZMARBankDetailsUpdateReleaseFake" PopupControlID="PnlZMARBankDetailsUpdateRelease"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelZMARRTGSRelease" runat="server" DisplayAfter="0">
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
                               
                                <div class="tab-pane fade" id="nav-NavZMARSanctionCopy" role="tabpanel" aria-labelledby="nav-NavZMARSanctionCopy-tab">
                                    <asp:UpdatePanel ID="UpdatePanelARSanctionCopy" runat="server">
                                        <ContentTemplate>
                                            <div class="flex-container">
                                                <div class="navFormHeading">
                                                    <asp:Label runat="server">Arivu Application Sanctioned Copy Download </asp:Label>
                                                </div>
                                                </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelARSanctionCopy" runat="server" DisplayAfter="0">
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
                                <div class="tab-pane fade" id="nav-NavZMARAppnStatus" role="tabpanel" aria-labelledby="nav-NavZMARAppnStatus-tab">
                                    <asp:UpdatePanel ID="UpdatePanelZMARAppnStatus" runat="server">
                                        <ContentTemplate>
                                            <div class="flex-container">
                                                <div class="navFormHeading">
                                                    <asp:Label runat="server">Arivu Application Status</asp:Label>
                                                </div>
                                                <div class="navFormBody">
                                                    <div class="formFlex-row">
                                                        <asp:Label runat="server" class="labelStyle1" Text="Application Number"></asp:Label>
                                                        <asp:TextBox ID="txtZMARApplicationStatus" class="textboxStyle1" runat="server"></asp:TextBox>
                                                        <asp:Button ID="btnZMARGetApplicationStatus" runat="server" Text="Get Status" OnClick="btnZMARGetApplicationStatus_Click" />
                                                        <asp:Panel ID="PnlZMARApplicationStatusDetails" runat="server" CssClass="modalPopup PopupPanel" Width="50%" Style="display: none;">
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
                                                                            <asp:Label ID="lblZMARAppStatusApplicationNumber" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-row">
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="Label50" runat="server">Applicant Name</asp:Label>
                                                                        </div>
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="lblZMARAppStatusApplicationName" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-row">
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="Label53" runat="server">Case Worker</asp:Label>
                                                                        </div>
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="lblZMARAppStatusApplicationCWStat" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-row">
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="Label55" runat="server">District Manager</asp:Label>
                                                                        </div>
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="lblZMARAppStatusApplicationDMStat" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-row">
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="Label57" runat="server">CEO Committee</asp:Label>
                                                                        </div>
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="lblZMARAppStatusApplicationCEOStat" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-row">
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="Label59" runat="server">Documentation</asp:Label>
                                                                        </div>
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="lblZMARAppStatusApplicationDOCStat" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>

                                                                    <div class="form-row">
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="Label61" runat="server">Zonal Manager</asp:Label>
                                                                        </div>
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="lblZMARAppStatusApplicationZMStat" runat="server"></asp:Label>
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

                                                        <asp:LinkButton ID="lnkZMARApplicationStatusDetailsFake" runat="server"></asp:LinkButton>
                                                        <cc1:ModalPopupExtender ID="ZMARApplicationStatusDetailsPopup" runat="server" TargetControlID="lnkZMARApplicationStatusDetailsFake" PopupControlID="PnlZMARApplicationStatusDetails"
                                                            BackgroundCssClass="modalBackground">
                                                        </cc1:ModalPopupExtender>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelZMARAppnStatus" runat="server" DisplayAfter="0">
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
                                <div class="tab-pane fade" id="nav-NavZMSECEODocument" role="tabpanel" aria-labelledby="nav-NavZMSECEODocument-tab">
                                    <div class="NeumorphicDiv" style="margin-top:10%">
                                        <asp:GridView ID="GvSECEODoc" runat="server" CssClass="GridView col-lg-offset-2" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                                            RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000"
                                            AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="Id" HeaderText="File Number" />
                                                <asp:BoundField DataField="District" HeaderText="District" />
                                                <asp:BoundField DataField="DateTime" HeaderText="Uploded Date & Time" />
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkbtnSECEODoc" runat="server" Text="Download" OnClick="lnkbtnSECEODoc_Click"
                                                            CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="nav-NavZMSEAppnProcess" role="tabpanel" aria-labelledby="nav-NavZMSEAppnProcess-tab">
                                    <asp:UpdatePanel ID="UpdatePanelZMSEAppnProcess" runat="server">
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnSEZMSubmit" />
                                            <asp:PostBackTrigger ControlID="btnSEZMExportExcel" />
                                            <asp:PostBackTrigger ControlID="btnSEZMPrintReject" />
                                        </Triggers>
                                        <ContentTemplate>
                                            <div class="flex-container">
                                                <div class="navFormHeading">
                                                    <asp:Label runat="server">Self Employment Application Process</asp:Label>
                                                </div>
                                                <div class="divGridview">
                                                    <div class="text-center">
                                                        <asp:GridView ID="gvZMSEApproveProcess" runat="server" class="GridView" OnRowDataBound="gvZMSEApproveProcess_RowDataBound" AutoGenerateColumns="False" DataKeyNames="ApplicationNumber,RDNumber,AadharNum,ApplicantName" Style="align-content: center;margin-top:0%">
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                                                                    <ItemTemplate>
                                                                         <%# Eval("ApplicationNumber")+ "<br />"+"<br />"+ Eval("ApprovedApplicationNum") %>
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
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="EmailID &amp; Mobile Number" ItemStyle-Width="220">
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
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Quota &amp; Loan Amount" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("Quota") + "<br />" +  Eval("LoanAmount")%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="180px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Purpose &amp; Description" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("LoanPurpose") + "<br />" +  Eval("LoanDescription")%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="180px" />
                                                                </asp:TemplateField>
                                                                <asp:ImageField HeaderText="Image" DataImageUrlField="ImgPath" ControlStyle-Height="80" ControlStyle-Width="65" ItemStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center text-center font-weight-bold"></asp:ImageField>

                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Bank Details" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnZMSEDisplayBankDetails" class="ViewButton" runat="server" Text="View" OnClick="btnZMSEDisplayBankDetails_Click" />
                                                                        <asp:Button ID="btnZMSEDisplayBankDetailsUpdate" class="ViewButton" runat="server" Text='<%# Eval("BDStatus") %>' OnClick="btnZMSEDisplayBankDetailsUpdate_Click" />

                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                                                </asp:TemplateField>

                                                                <asp:BoundField DataField="ZMStatus" HeaderText="Status" HeaderStyle-Width="10%" ItemStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="80px" HeaderStyle-CssClass="text-center text-center font-weight-bold" />

                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Action" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnZMSEApprove" runat="server" OnClick="btnZMSEApprove_Click" class="EligibleButton" Text="Approve" /><br />
                                                                        <asp:Button ID="btnZMSEHold" runat="server" OnClick="btnZMSEHold_Click" class="HoldButton" Text="Hold"  /><br />
                                                                        <asp:Button ID="btnZMASEReject" runat="server" OnClick="btnZMASEReject_Click" class="InEligibleButton" Text="Reject" />
                                                                        <asp:Button ID="btnZMASEReturn" runat="server" OnClick="btnZMASEReturn_Click" class="InEligibleButton" Text="Return to DM" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" Width="6%" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:TemplateField>

                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>

                                                <div class="flex-container" style="margin-top: 0">
                                                    <div class="NeumorphicDiv" style="width: 96%; display: flex; justify-content: space-around">
                                                        <div class="row">
                                                            <div class="">
                                                                <asp:Label ID="lblSEZMApplicationCount" Width="250px" runat="server" CssClass="labelStyle1" style="color:whitesmoke" Text=""></asp:Label>
                                                            </div>
                                                            <div class="">
                                                                <asp:Label ID="lblSEZMTotalSum" Width="250px" runat="server"  CssClass="labelStyle1" style="color:whitesmoke" Text=""></asp:Label>
                                                            </div>
                                                            <div class="">
                                                                <asp:TextBox ID="txtSEZMChequeNumber" Visible="true" CssClass="NeoTextBox" placeholder="Cheque Number" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="">
                                                                <asp:Button ID="btnSEZMGenerateReport" runat="server" CssClass="EligibleButton" Text="Generate Report" UseSubmitBehavior="false" OnClick="btnSEZMGenerateReport_Click" /><%--OnClientClick="this.disabled='true'; this.value='Please wait...';"--%>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div id="divSEZMReportDownload" class="flex-container" style="margin-top: 0" runat="server" visible="false">
                                                    <div class=" NeumorphicDiv text-center" style="width: 96%; display: flex; justify-content: space-around;">
                                                        <asp:Button ID="btnSEZMSubmit" runat="server" CssClass="EligibleButton" Text="Download Bank Report" UseSubmitBehavior="false" OnClick="btnSEZMSubmit_Click" Style="width: 80%" /><%--OnClientClick="this.disabled='true'; this.value='Please wait...';"--%>
                                                        <asp:Button ID="btnSEZMExportExcel" runat="server" CssClass="ViewButton " Text="Excel" UseSubmitBehavior="false" OnClick="btnSEZMExportExcel_Click" Style="width: 80%" />
                                                        <asp:Button ID="btnSEZMPrintReject" runat="server" CssClass="InEligibleButton" OnClick="btnSEZMPrintReject_Click" Text="Print Reject" Style="width: 80%" />
                                                    </div>
                                                </div>

                                                <asp:Panel ID="PnlZMSEBankDetails" runat="server" CssClass="modalPopup PopupPanel" Width="50%" Style="display: none;">
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
                                                                    <asp:Label ID="lblZMSEBDApplicationNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label8" runat="server">Account Holder Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblZMSEBAccountHolderName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label10" runat="server">Account Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblZMSEBAccountNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label12" runat="server">Bank Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblZMSEBBankName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label20" runat="server">Branch Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblZMSEBBranch" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label22" runat="server">IFSC Code</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblZMSEBIFSCCode" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label28" runat="server">Address</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblZMSEBBankAddress" runat="server"></asp:Label>
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
                                                <asp:LinkButton ID="lnkZMSEBankDetailsFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="ZMSEBankDetailsPopup" runat="server" TargetControlID="lnkZMSEBankDetailsFake" PopupControlID="PnlZMSEBankDetails"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlZMSEConfirmHold" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
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
                                                                    <asp:Label ID="lblZMSEConfirmHoldAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label42" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblZMSEConfirmHoldAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label46" runat="server" Text="Reason"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtZMSEConfirmHoldAppReason" CssClass="PopupTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblZMSEConfirmHoldAppReasonError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnZMSEConfirmHoldApplication" runat="server" CssClass="ActionButton" Text="Hold" OnClick="btnZMSEConfirmHoldApplication_Click" />
                                                                    <asp:Button ID="Button5" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkZMSEConfirmHoldFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="ZMSEConfirmHoldPopup" runat="server" PopupControlID="PnlZMSEConfirmHold"
                                                    TargetControlID="lnkZMSEConfirmHoldFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                 <asp:Panel ID="PnlZMSEConfirmReturn" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label79" class="" runat="server" Text="Confirm Return"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label80" runat="server" Text="Application Number"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblZMSEConfirmReturnAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label101" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblZMSEConfirmReturnAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label102" runat="server" Text="Reason"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtZMSEConfirmReturnAppReason" CssClass="PopupTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblZMSEConfirmReturnAppReasonError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnZMSEConfirmReturnApplication" runat="server" CssClass="ActionButton" Text="Return" OnClick="btnZMSEConfirmReturnApplication_Click" />
                                                                    <asp:Button ID="Button18" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkZMSEConfirmReturnFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="ZMSEConfirmReturnPopup" runat="server" PopupControlID="PnlZMSEConfirmReturn"
                                                    TargetControlID="lnkZMSEConfirmReturnFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlZMSEConfirmApprove" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
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
                                                                    <asp:Label ID="lblZMSEConfirmApproveAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label51" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblZMSEConfirmApproveAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnZMSEConfirmApproveApplication" runat="server" CssClass="ActionButton" Text="Eligible" OnClick="btnZMSEConfirmApproveApplication_Click" />
                                                                    <asp:Button ID="Button10" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkZMSEConfirmApproveFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="ZMSEConfirmApprovePopup" runat="server" PopupControlID="PnlZMSEConfirmApprove"
                                                    TargetControlID="lnkZMSEConfirmApproveFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlZMSERejectReason" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
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
                                                                    <asp:Label ID="lblZMSEConfirmRejectAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label33" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblZMSEConfirmRejectAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label158" runat="server"> Select Reason<span style="color:red"> *</span></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input" style="flex-direction: column">
                                                                    <asp:RadioButton ID="rbZMSEConfirmRejectReasonName" runat="server" Class="radioButton" GroupName="ZMSEConfirmRejectReason" Text="Name Mismatch" AutoPostBack="true" OnCheckedChanged="rbZMSEConfirmRejectReasonName_CheckedChanged" /><br />
                                                                    <asp:RadioButton ID="rbZMSEConfirmRejectReasonOther" runat="server" Class="radioButton" GroupName="ZMSEConfirmRejectReason" Text="Other" AutoPostBack="true" OnCheckedChanged="rbZMSEConfirmRejectReasonName_CheckedChanged" /><br />
                                                                    <asp:Label runat="server" ID="lblZMSEConfirmRejectAppReasonSelectionError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row" id="divZMSERejectReason" runat="server" visible="false">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblZMSERejectLabel" runat="server" Text="Reason"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtZMSEConfirmRejectAppReason" CssClass="PopupTextBox" Style="height: 80px" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblZMSEConfirmRejectAppReasonError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnZMSEConfirmRejectApplication" runat="server" CssClass="ActionButton" Text="Reject" OnClick="btnZMSEConfirmRejectApplication_Click" />
                                                                    <asp:Button ID="Button4" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkZMSERejectReasonFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="ZMSEConfirmRejectPopup" runat="server" PopupControlID="PnlZMSERejectReason"
                                                    TargetControlID="lnkZMSERejectReasonFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>


                                                <asp:Panel ID="PnlZMSEBankDetailsUpdate" runat="server" CssClass="modalPopup PopupPanel" Width="50%" Style="display: none;">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label54" class="" runat="server" Text="Update Bank Details"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label58" runat="server">Application Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblZMSEBDUpdateApplicationNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label62" runat="server">Account Holder Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblZMSEBDUpdateAccountHolderName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label64" runat="server">Account Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtZMSEBDUpdateAccountNumber" CssClass="PopupTextBoxSingleLine" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label66" runat="server">Bank Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtZMSEBDUpdateBankName" CssClass="PopupTextBoxSingleLine" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label68" runat="server">Branch Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtZMSEBDUpdateBranchName" CssClass="PopupTextBoxSingleLine" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label70" runat="server">IFSC Code</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtZMSEBDUpdateIFSCCode" CssClass="PopupTextBoxSingleLine" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label71" runat="server">Address</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtZMSEBDUpdateBankAddress" CssClass="PopupTextBox" Height="80px" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label72" runat="server">Select Reason</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:DropDownList ID="drpZMSEBankModifyReason" runat="server" class="NeuoDropdown">
                                                                        <asp:ListItem Value="0">--SELECE REASON--</asp:ListItem>
                                                                        <asp:ListItem Value="Jandhan Account">Jandhan Account</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid IFSC Code">Wrong IFSC Code</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid A/C Number">Invalid A/C Number</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid Branch">Invalid Branch</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid Bank">Invalid Bank</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid Address">Invalid Address</asp:ListItem>
                                                                    </asp:DropDownList><br />
                                                                    <asp:Label runat="server" ID="lblZMSEBDUpdateError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="form-row-Botton">
                                                                    <asp:Button ID="btnZMSEBDUpdate" runat="server" CssClass="ActionButton" Text="Update" OnClick="btnZMSEBDUpdate_Click" />
                                                                    <asp:Button ID="Button12" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMSEHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkZMSEBankDetailsUpdateFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="ZMSEBankDetailsUpdatePopup" runat="server" TargetControlID="lnkZMSEBankDetailsUpdateFake" PopupControlID="PnlZMSEBankDetailsUpdate"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlSEOtherDetails" runat="server" CssClass="modalPopup" Style="display: none; padding: 5px">
                                                    <div class="form-row" style="justify-content: center">
                                                        <div class="Popup-row-label-Heading">
                                                            <asp:Label ID="lblSENotificationHeading" runat="server" Text=""></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="Popup-row-label">
                                                            <asp:Label ID="lblSENotificationContent" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="form-row">

                                                        <div class="Popup-row-label">
                                                            <asp:Button ID="Button17" runat="server" CssClass="SubmitButton" Text="Ok" />
                                                        </div>
                                                    </div>

                                                </asp:Panel>

                                                <asp:LinkButton ID="lnkSEOtherDetails" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="SEOtherDetailsPopup" runat="server" TargetControlID="lnkSEOtherDetails" PopupControlID="PnlSEOtherDetails"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelZMSEAppnProcess" runat="server" DisplayAfter="0">
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
                                <div class="tab-pane fade" id="nav-NavZMSERTGSRelease" role="tabpanel" aria-labelledby="nav-NavZMSERTGSRelease-tab">
                                    <asp:UpdatePanel ID="UpdatePanelZMSERTGSRelease" runat="server">
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnSEZMReleaseSubmit" />
                                            <asp:PostBackTrigger ControlID="btnSEZMReleaseExportExcel" />
                                            <asp:PostBackTrigger ControlID="btnSEZMReleasePrintReject" />
                                        </Triggers>
                                        <ContentTemplate>
                                           
                                            <div class="flex-container">
                                                <div class="navFormHeading">
                                                    <asp:Label runat="server">Self Employment Application RTGS Release </asp:Label>
                                                </div>
                                                <div class="form-row">
                                                    <div class="Popup-row-input"></div>
                                                    <div class="Popup-row-label">
                                                        <asp:Label runat="server" Text="Cheque Number :  "></asp:Label>
                                                        <asp:TextBox ID="txtZMSEReleaseChequeNumber" runat="server" CssClass="text-info" placeholder="Cheque Number" TextMode="number"></asp:TextBox>
                                                    </div>
                                                    <div class="Popup-row-input">
                                                        <asp:TextBox ID="txtZMSEReleaseChequeDate" runat="server" ClientIDMode="Static" class="NeuoDropdown" placeholder="DD-MM-YYYY (Cheque Date)" style="width:450px"> </asp:TextBox>
                                                        <cc1:CalendarExtender ID="calZMSEReleaseChequeDate" PopupButtonID="image" runat="server" TargetControlID="txtZMSEReleaseChequeDate" Format="dd-MM-yyyy"></cc1:CalendarExtender>
                                                        <div class="Popup-row-input"></div>
                                                    </div>
                                                </div>
                                                <div class="divGridview">
                                                    <div class="text-center">
                                                        <asp:GridView ID="gvZMSEReleaseProcess" runat="server" class="GridView" AutoGenerateColumns="False" DataKeyNames="ApplicationNumber,ApplicantName,ApprovedApplicationNum" Style="align-content: center;">
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ApplicationNumber") + "<br />" + Eval("ApprovedApplicationNum")%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="240px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Applicant Name" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# Eval("ApplicantName") %>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Bank Details" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <%# "A/C No: " + Eval("AccountNumber")+ "<br />"%>
                                                                        <%# "Bank: " + Eval("BankName")+ "<br />" + " Branch: " + Eval("Branch")+ "<br />" + " IFSCCode: " + Eval("IFSCCode")+ "<br />" + " Address: " + Eval("BankAddress")%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Approve" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnZMSEReleased" runat="server" class="EligibleButton" OnClick="btnZMSEReleased_Click" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" ShowHeader="True" Text="RTGS Successful" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Update" ItemStyle-Width="50">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnZMSEDReleaseBankDetailsUpdate" runat="server" class="ViewButton" CommandArgument="<%# Container.DataItemIndex %>" OnClick="btnZMSEReleaseBankDetailsUpdate_Click" HeaderStyle-CssClass="text-center text-center font-weight-bold" CausesValidation="false" ShowHeader="True" Text='<%# Eval("BDStatus") %>' />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>

                                                    </div>
                                                </div>

                                                <div class="flex-container" style="margin-top: 0">
                                                    <div class="NeumorphicDiv" style="width: 96%; display: flex; justify-content: space-around">
                                                        <div class="row">
                                                            <div class="">
                                                                <asp:Label ID="lblSEZMReleaseApplicationCount" Width="250px" runat="server" CssClass="labelStyle1" Style="color: whitesmoke" Text=""></asp:Label>
                                                            </div>
                                                            <div class="">
                                                                <asp:Label ID="lblSEZMReleaseTotalSum" Width="250px" runat="server" CssClass="labelStyle1" Style="color: whitesmoke" Text=""></asp:Label>
                                                            </div>
                                                            <div class="">
                                                                <asp:TextBox ID="txtSEZMReleaseChequeNumber" Visible="true" CssClass="NeoTextBox" placeholder="Cheque Number" runat="server"></asp:TextBox>
                                                            </div>
                                                            <div class="">
                                                                <asp:Button ID="btnSEZMReleaseGenerateReport" runat="server" CssClass="EligibleButton" Text="Generate Report" UseSubmitBehavior="false" OnClick="btnSEZMReleaseGenerateReport_Click" /><%--OnClientClick="this.disabled='true'; this.value='Please wait...';"--%>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div id="divSEZMReleaseReportDownload" class="flex-container" style="margin-top: 0" runat="server" visible="false">
                                                    <div class=" NeumorphicDiv text-center" style="width: 96%; display: flex; justify-content: space-around;">
                                                        <asp:Button ID="btnSEZMReleaseSubmit" runat="server" CssClass="EligibleButton" Text="Download Bank Report" UseSubmitBehavior="false" OnClick="btnSEZMSubmit_Click" Style="width: 80%" /><%--OnClientClick="this.disabled='true'; this.value='Please wait...';"--%>
                                                        <asp:Button ID="btnSEZMReleaseExportExcel" runat="server" CssClass="ViewButton " Text="Excel" UseSubmitBehavior="false" OnClick="btnSEZMExportExcel_Click" Style="width: 80%" />
                                                        <asp:Button ID="btnSEZMReleasePrintReject" runat="server" CssClass="InEligibleButton" OnClick="btnSEZMPrintReject_Click" Text="Print Reject" Style="width: 80%" />
                                                    </div>
                                                </div>

                                                <asp:Panel ID="PnlZMSEConfirmRelease" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label73" class="" runat="server" Text="Confirm Eligible"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label74" runat="server" Text="Application Number"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblZMSEConfirmReleaseAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label75" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblZMSEConfirmReleaseAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label76" runat="server" Text="Loan Number"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblZMSEConfirmReleaseLoanNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label7a6" runat="server" Text="Cheque Number"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblZMSEConfirmReleaseChequeNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label7z6" runat="server" Text="Cheque Date"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblZMSEConfirmReleaseChequeDate" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnZMSEConfirmReleaseApplication" runat="server" CssClass="ActionButton" Text="Released" OnClick="btnZMSEConfirmReleaseApplication_Click" />
                                                                    <asp:Button ID="Button13" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkZMSEConfirmReleaseFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="ZMSEConfirmReleasePopup" runat="server" PopupControlID="PnlZMSEConfirmRelease"
                                                    TargetControlID="lnkZMSEConfirmReleaseFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>


                                                <asp:Panel ID="PnlZMSEBankDetailsUpdateRelease" runat="server" CssClass="modalPopup PopupPanel" Width="50%" Style="display: none;">
                                                    <div class="Popup-flex-container">
                                                        <div class="">
                                                            <div class="form-row" style="justify-content: center">
                                                                <div class="Popup-row-label-Heading">
                                                                    <asp:Label ID="Label83" class="" runat="server" Text="UpdateRelease Bank Details"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label84" runat="server">Application Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblZMSEBDUpdateReleaseApplicationNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label85" runat="server">Account Holder Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblZMSEBDUpdateReleaseAccountHolderName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label86" runat="server">Account Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtZMSEBDUpdateReleaseAccountNumber" CssClass="PopupTextBoxSingleLine" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label87" runat="server">Bank Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtZMSEBDUpdateReleaseBankName" CssClass="PopupTextBoxSingleLine" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label88" runat="server">Branch Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtZMSEBDUpdateReleaseBranchName" CssClass="PopupTextBoxSingleLine" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label89" runat="server">IFSC Code</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtZMSEBDUpdateReleaseIFSCCode" CssClass="PopupTextBoxSingleLine" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label90" runat="server">Address</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtZMSEBDUpdateReleaseBankAddress" CssClass="PopupTextBox" Height="80px" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label91" runat="server">Select Reason</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:DropDownList ID="drpZMSEBankModifyReleaseReason" runat="server" class="NeuoDropdown">
                                                                        <asp:ListItem Value="0">--SELECE REASON--</asp:ListItem>
                                                                        <asp:ListItem Value="Jandhan Account">Jandhan Account</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid IFSC Code">Wrong IFSC Code</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid A/C Number">Invalid A/C Number</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid Branch">Invalid Branch</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid Bank">Invalid Bank</asp:ListItem>
                                                                        <asp:ListItem Value="Invalid Address">Invalid Address</asp:ListItem>
                                                                    </asp:DropDownList><br />
                                                                    <asp:Label runat="server" ID="lblZMSEBDUpdateReleaseError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="form-row-Botton">
                                                                    <asp:Button ID="btnZMSEBDUpdateRelease" runat="server" CssClass="ActionButton" Text="UpdateRelease" OnClick="btnZMSEBDUpdateRelease_Click" />
                                                                    <asp:Button ID="Button15" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMSEHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkZMSEBankDetailsUpdateReleaseFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="ZMSEBankDetailsUpdateReleasePopup" runat="server" TargetControlID="lnkZMSEBankDetailsUpdateReleaseFake" PopupControlID="PnlZMSEBankDetailsUpdateRelease"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:GridView ID="gvZMPrintSERelease" Visible="false" class="GridView" runat="server" AutoGenerateColumns="False" ShowFooter="true">
                                                    <Columns>
                                                        <asp:BoundField ItemStyle-Width="200px" DataField="ApprovedApplicationNum" HeaderText="Application Number" />
                                                        <asp:BoundField ItemStyle-Width="150px" DataField="ApplicantName" HeaderText="Applicant Name" />
                                                        <asp:BoundField ItemStyle-Width="150px" DataField="MobileNumber" HeaderText="Mobile Number" />
                                                        <asp:BoundField ItemStyle-Width="150px" DataField="BankName" HeaderText="BankName" />
                                                        <asp:BoundField ItemStyle-Width="200px" DataField="AccountNumber" HeaderText="AccountNumber" />
                                                        <asp:BoundField ItemStyle-Width="200px" DataField="IFSCCode" HeaderText="IFSCCode" />
                                                        <asp:BoundField ItemStyle-Width="200px" DataField="Branch" HeaderText="Branch" />
                                                        <asp:BoundField ItemStyle-Width="200px" DataField="BankAddress" HeaderText="BankAddress" />
                                                        <asp:BoundField ItemStyle-Width="200px" DataField="LoanAmount" HeaderText="LoanAmount" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelZMSERTGSRelease" runat="server" DisplayAfter="0">
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
                                <div class="tab-pane fade" id="nav-NavZMSESanctionCopy" role="tabpanel" aria-labelledby="nav-NavZMSESanctionCopy-tab">
                                    <asp:UpdatePanel ID="UpdatePanelSESanctionCopy" runat="server">
                                        <ContentTemplate>
                                            <div class="flex-container">
                                                <div class="navFormHeading">
                                                    <asp:Label runat="server">Self Employment Application Sanctioned Copy Download </asp:Label>
                                                </div>
                                                <div class="navFormBody">
                                                    <div class="formFlex-row">
                                                        <asp:Label runat="server" class="labelStyle1" Text="Application Number"></asp:Label>
                                                        <%--<asp:TextBox ID="TextBox1" class="textboxStyle1" runat="server"></asp:TextBox>--%>
                                                        <asp:DropDownList ID="drpZoneSESanction" Class="ac" Style="width: 40%" runat="server" OnSelectedIndexChanged="drpZoneSESanction_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <asp:TextBox runat="SERVER" ></asp:TextBox>
                                                        <asp:Button ID="Button20" runat="server" Text="Get Details" OnClick="btnZMSEGetApplicationStatus_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="flex-container ContantMain" id="divSEApplicationMail" runat="server">
                                                <div class="">
                                                    <div class="form-row">
                                                        <div class="form-row-label" style="color: black">
                                                            <asp:Label ID="Label107" class="" runat="server">Aplication Number</asp:Label><br />
                                                        </div>
                                                        <div class="form-row-input">
                                                            <asp:Label ID="Label108" class="" runat="server">Father / Guardian Name</asp:Label><br />
                                                        </div>
                                                        <div class="form-row-Botton" id="div2" runat="server">
                                                        </div>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="form-row-label" style="color: black">
                                                            <asp:Label ID="Labesl107" class="" runat="server">Aplication Number</asp:Label><br />
                                                        </div>
                                                        <div class="form-row-input">
                                                            <asp:Label ID="Labaecl108" class="" runat="server">Father / Guardian Name</asp:Label><br />
                                                        </div>
                                                        <div class="form-row-Botton" id="diva" runat="server">
                                                        </div>
                                                    </div>

                                                    <div class="form-row">
                                                        <div class="form-row-label" style="color: black">
                                                            <asp:Label ID="Labeal107" class="" runat="server">Name</asp:Label><br />
                                                        </div>
                                                        <div class="form-row-input">
                                                            <asp:Label ID="Label109" class="" runat="server">Father / Guardian Name</asp:Label><br />
                                                        </div>
                                                        <div class="form-row-Botton" id="daiv2" runat="server">
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelSESanctionCopy" runat="server" DisplayAfter="0">
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
                                <div class="tab-pane fade" id="nav-NavZMSEAppnStatus" role="tabpanel" aria-labelledby="nav-NavZMSEAppnStatus-tab">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <div class="flex-container">
                                                <div class="navFormHeading">
                                                    <asp:Label runat="server">Self Employment Application Status</asp:Label>
                                                </div>
                                                <div class="navFormBody">
                                                    <div class="formFlex-row">
                                                        <asp:Label runat="server" class="labelStyle1" Text="Application Number"></asp:Label>
                                                        <asp:TextBox ID="txtZMSEApplicationStatus" class="textboxStyle1" runat="server"></asp:TextBox>
                                                        <asp:Button ID="btnZMSEGetApplicationStatus" runat="server" Text="Get Status" OnClick="btnZMSEGetApplicationStatus_Click" />
                                                    </div>
                                                </div>
                                                <asp:Panel ID="PnlZMSEApplicationStatusDetails" runat="server" CssClass="modalPopup PopupPanel" Width="50%" Style="display: none;">
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
                                                                    <asp:Label ID="lblZMSEAppStatusApplicationNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label56" runat="server">Applicant Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblZMSEAppStatusApplicationName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label60" runat="server">Case Worker</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblZMSEAppStatusApplicationCWStat" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label63" runat="server">District Manager</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblZMSEAppStatusApplicationDMStat" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label65" runat="server">CEO Committee</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblZMSEAppStatusApplicationCEOStat" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label67" runat="server">Documentation</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblZMSEAppStatusApplicationDOCStat" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label69" runat="server">Zonal Manager</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblZMSEAppStatusApplicationZMStat" runat="server"></asp:Label>
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

                                                <asp:LinkButton ID="lnkZMSEApplicationStatusDetailsFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="ZMSEApplicationStatusDetailsPopup" runat="server" TargetControlID="lnkZMSEApplicationStatusDetailsFake" PopupControlID="PnlZMSEApplicationStatusDetails"
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
