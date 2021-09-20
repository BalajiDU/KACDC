<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CW_Approval.aspx.cs" Inherits="KACDC.ApprovalPage.CW_Approval" MaintainScrollPositionOnPostback="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Case Worker</title>
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
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <nav class="DisplayMenu" id="menu-1" style="display: none;">
                        <div class="navigation">
                            <div class="sidebar bar-block animate-left" id="mySidebar">
                                <ul class="mainmenu">
                                    <li><a>Arivu</a>
                                        <ul class="submenu">
                                            <li><a class="nav-item nav-link" id="nav-NavCWARAppnProcess-tab" data-toggle="tab" href="#nav-NavCWARAppnProcess" role="tab" aria-controls="nav-NavCWARAppnProcess" aria-selected="false">Application Peocess</a></li>
                                            <li><a class="nav-item nav-link" id="nav-NavCWARAppnStatus-tab" data-toggle="tab" href="#nav-NavCWARAppnStatus" role="tab" aria-controls="nav-NavCWARAppnStatus" aria-selected="false">Application Status</a></li>

                                            <%--<li><a class="nav-item nav-link" id="nav-NavCWARAppnProcess-tab1" data-toggle="tab" href="#NavCWARAppnProcess" role="tab" aria-controls="NavCWARAppnProcess" aria-selected="false">Application Peocess</a></li>
                                    <li><a data-toggle="tab" href="#NavCWARAppnStatus" aria-controls="NavCWARAppnStatus" role="tab" aria-selected="false">Application Status</a></li>--%>
                                        </ul>
                                    </li>
                                    <li><a>Self Employment</a>
                                        <ul class="submenu">
                                            <li><a class="nav-item nav-link" id="nav-NavCWSEAppnProcess-tab" data-toggle="tab" href="#nav-NavCWSEAppnProcess" role="tab" aria-controls="nav-NavCWSEAppnProcess" aria-selected="false">Application Peocess</a></li>
                                            <li><a class="nav-item nav-link" id="nav-NavCWSEAppnStatus-tab" data-toggle="tab" href="#nav-NavCWSEAppnStatus" role="tab" aria-controls="nav-NavCWSEAppnStatus" aria-selected="false">Application Status</a></li>

                                            <%-- <li><a data-toggle="tab" href="#NavCWSEAppnProcess">Application Peocess</a></li>
                                    <li><a data-toggle="tab" href="#NavCWSEAppnStatus">Application Status</a></li>
                                    <li><a class="nav-item nav-link" id="nav-NavCWSEAppnProcess-tab1" data-toggle="tab" href="#nav-NavCWSEAppnProcess" role="tab" aria-controls="nav-homePage" aria-selected="true">Application Peocess</a></li>
                                    <li><a class="nav-item nav-link" id="nav-CWSEAppnStatus-tab" data-toggle="tab" href="#nav-CWSEAppnStatus" role="tab" aria-controls="nav-CWSEAppnStatus" aria-selected="false">Application Status</a></li>
                                    <li><a class="nav-item nav-link" id="nav-ARCEODownload-tab" data-toggle="tab" href="#nav-ARCEODownload" role="tab" aria-controls="nav-homePage" aria-selected="true">CEO Document</a></li>--%>
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

                                <li class="DisplayValueType"><a>Arivu</a></li>
                                <li class="items">
                                    <asp:Label CssClass="DisplayStatData" ID="lblArivuStatistics" runat="server"></asp:Label></li>
                                <li class="DisplayValueType"><a>Self Employment</a></li>
                                <li class="items">
                                    <asp:Label CssClass="DisplayStatData" ID="lblSEStatistics" runat="server"></asp:Label></li>
                                <li class="Button">
                                    <asp:Button ID="btnCWLogout" runat="server" Text="Logout" CssClass="logoutButton" OnClick="btnCWLogout_Click" /></li>

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

                                </div>
                                <div class="tab-pane fade" id="nav-NavCWARAppnProcess" role="tabpanel" aria-labelledby="nav-NavCWARAppnProcess-tab">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div class="flex-container">
                                                <div class="navFormHeading">
                                                    <asp:Label runat="server">Arivu Application Process</asp:Label>
                                                </div>
                                                <div class="divGridview">
                                                    <div class="text-center">
                                                        <asp:GridView ID="gvCWARApproveProcess" runat="server" class="GridView" OnRowDataBound="gvCWARApproveProcess_RowDataBound" AutoGenerateColumns="False" DataKeyNames="ApplicationNumber,ApplicantName,RDNumber,AadharNum,ClgHostel" Style="align-content: center;">
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
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Bank Details" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnCWARDisplayBankDetails" class="ViewButton" runat="server" Text="View" OnClick="btnCWARDisplayBankDetails_Click" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="College Details" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnCWARDisplayCollegeDetails" class="ViewButton" runat="server" Text="View" OnClick="btnCWARDisplayCollegeDetails_Click" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="CWStatus" HeaderText="Status" HeaderStyle-Width="10%" ControlStyle-Width="150px" ItemStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="80px" HeaderStyle-CssClass="text-center text-center font-weight-bold" />

                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Action" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnCWARApprove" runat="server" OnClick="btnCWARApprove_Click" class="EligibleButton" Text="Eligible" /><br />
                                                                        <asp:Button ID="btnCWARHold" runat="server" OnClick="btnCWARHold_Click" class="HoldButton" Text="Hold" Visible="false" /><br />
                                                                        <asp:Button ID="btnCWARReject" runat="server" OnClick="btnCWARReject_Click" class="InEligibleButton" Text="Ineligible" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                                                </asp:TemplateField>

                                                            </Columns>
                                                        </asp:GridView>
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
                                                                    <asp:Label ID="lblCWARBDApplicationNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label38" runat="server">Account Holder Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCWARBDAccountHolderName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label16" runat="server">Account Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCWARBDAccountNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label17" runat="server">Bank Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCWARBDBankName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label13" runat="server">Branch Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCWARBDBranchName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label18" runat="server">IFSC Code</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCWARBDIFSCCode" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label14" runat="server">Address</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCWARBDBankAddress" runat="server"></asp:Label>
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
                                                <cc1:ModalPopupExtender ID="CWARBankDetailsPopup" runat="server" TargetControlID="lnkBankDetailsFake" PopupControlID="PnlBankDetails"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlCWARConfirmReject" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
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
                                                                    <asp:Label ID="lblCWARConfirmRejectAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label25" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblCWARConfirmRejectAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label35" runat="server"> Select Reason<span style="color:red"> *</span></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input" style="flex-direction: column">
                                                                    <asp:RadioButton ID="rbCWARConfirmRejectReasonName" runat="server" Class="radioButton" GroupName="CWARConfirmRejectReason" Text="Name Mismatch" AutoPostBack="true" OnCheckedChanged="rbCWARConfirmRejectReasonName_CheckedChanged" /><br />
                                                                    <asp:RadioButton ID="rbCWARConfirmRejectReasonCET" runat="server" Class="radioButton" GroupName="CWARConfirmRejectReason" Text="Invalid CET Certificate" AutoPostBack="true" OnCheckedChanged="rbCWARConfirmRejectReasonName_CheckedChanged" /><br />
                                                                    <asp:RadioButton ID="rbCWARConfirmRejectReasonOther" runat="server" Class="radioButton" GroupName="CWARConfirmRejectReason" Text="Other" AutoPostBack="true" OnCheckedChanged="rbCWARConfirmRejectReasonName_CheckedChanged" /><br />
                                                                    <asp:Label runat="server" ID="lblCWARConfirmRejectAppReasonSelectionError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row" id="divCWARRejectReason" runat="server" visible="false">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCWARRejectLabel" runat="server" Text="Reason"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtCWARConfirmRejectAppReason" CssClass="PopupTextBox" Height="80px" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblCWARConfirmRejectAppReasonError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnCWARConfirmRejectApplication" runat="server" CssClass="ActionButton" Text="Reject" OnClick="btnCWARConfirmRejectApplication_Click" />
                                                                    <asp:Button ID="Button3" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkCWARConfirmRejectFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="CWARConfirmRejectPopup" runat="server" PopupControlID="PnlCWARConfirmReject"
                                                    TargetControlID="lnkCWARConfirmRejectFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlCWARConfirmHold" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
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
                                                                    <asp:Label ID="lblCWARConfirmHoldAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label43" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblCWARConfirmHoldAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label45" runat="server" Text="Reason"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtCWARConfirmHoldAppReason" CssClass="PopupTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblCWARConfirmHoldAppReasonError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnCWARConfirmHoldApplication" runat="server" CssClass="ActionButton" Text="Hold" OnClick="btnCWARConfirmHoldApplication_Click" />
                                                                    <asp:Button ID="Button8" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkCWARConfirmHoldFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="CWARConfirmHoldPopup" runat="server" PopupControlID="PnlCWARConfirmHold"
                                                    TargetControlID="lnkCWARConfirmHoldFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlCWARConfirmApprove" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
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
                                                                    <asp:Label ID="lblCWARConfirmApproveAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label40" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblCWARConfirmApproveAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnCWARConfirmApproveApplication" runat="server" CssClass="ActionButton" Text="Eligible" OnClick="btnCWARConfirmApproveApplication_Click" />
                                                                    <asp:Button ID="Button7" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkCWARConfirmApproveFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="CWARConfirmApprovePopup" runat="server" PopupControlID="PnlCWARConfirmApprove"
                                                    TargetControlID="lnkCWARConfirmApproveFake" BackgroundCssClass="modalBackground">
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
                                                                    <asp:Label ID="lblCWARClgPPApplicationNumber" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label4" runat="server">Name </asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCWARClgPPApplicationName" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label7" runat="server">CET Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCWARClgPPCETTicket" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label19" runat="server">Marks</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCWARClgPPMarks" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label9" runat="server">College</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCWARClgPPCollegeName" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label11" runat="server">Course</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCWARClgPPCourse" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label21" runat="server">Hostel</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCWARClgPPHostel" runat="server" Style="color: brown"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label27" runat="server">Address</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCWARClgPPClgAddress" runat="server" Style="color: brown"></asp:Label>
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
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="tab-pane fade" id="nav-NavCWARAppnStatus" role="tabpanel" aria-labelledby="nav-NavCWARAppnStatus-tab">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div class="flex-container">
                                                <div class="navFormHeading">
                                                    <asp:Label runat="server">Arivu Application Status</asp:Label>
                                                </div>
                                                <div class="navFormBody">
                                                    <div class="formFlex-row">
                                                        <asp:Label runat="server" class="labelStyle1" Text="Application Number"></asp:Label>
                                                        <asp:TextBox ID="txtCWARApplicationStatus" class="textboxStyle1" runat="server"></asp:TextBox>
                                                        <asp:Button ID="btnCWARGetApplicationStatus" runat="server" Text="Get Status" OnClick="btnCWARGetApplicationStatus_Click" />
                                                        <asp:Panel ID="PnlCWARApplicationStatusDetails" runat="server" CssClass="modalPopup PopupPanel" Width="50%" Style="display: none;">
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
                                                                            <asp:Label ID="lblCWARAppStatusApplicationNumber" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-row">
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="Label50" runat="server">Applicant Name</asp:Label>
                                                                        </div>
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="lblCWARAppStatusApplicationName" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-row">
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="Label53" runat="server">Case Worker</asp:Label>
                                                                        </div>
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="lblCWARAppStatusApplicationCWStat" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-row">
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="Label55" runat="server">District Manager</asp:Label>
                                                                        </div>
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="lblCWARAppStatusApplicationDMStat" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-row">
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="Label57" runat="server">CEO Committee</asp:Label>
                                                                        </div>
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="lblCWARAppStatusApplicationCEOStat" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-row">
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="Label59" runat="server">Documentation</asp:Label>
                                                                        </div>
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="lblCWARAppStatusApplicationDOCStat" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>

                                                                    <div class="form-row">
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="Label61" runat="server">Zonal Manager</asp:Label>
                                                                        </div>
                                                                        <div class="Popup-row-label">
                                                                            <asp:Label ID="lblCWARAppStatusApplicationZMStat" runat="server"></asp:Label>
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

                                                        <asp:LinkButton ID="lnkCWARApplicationStatusDetailsFake" runat="server"></asp:LinkButton>
                                                        <cc1:ModalPopupExtender ID="CWARApplicationStatusDetailsPopup" runat="server" TargetControlID="lnkCWARApplicationStatusDetailsFake" PopupControlID="PnlCWARApplicationStatusDetails"
                                                            BackgroundCssClass="modalBackground">
                                                        </cc1:ModalPopupExtender>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="tab-pane fade" id="nav-NavCWSEAppnProcess" role="tabpanel" aria-labelledby="nav-NavCWSEAppnProcess-tab">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <div class="flex-container">
                                                <div class="navFormHeading">
                                                    <asp:Label runat="server">Self Employment Application Process</asp:Label>
                                                </div>
                                                <div class="divGridview">
                                                    <div class="text-center">
                                                        <asp:GridView ID="gvCWSEApproveProcess" runat="server" class="GridView" OnRowDataBound="gvCWSEApproveProcess_RowDataBound" AutoGenerateColumns="False" DataKeyNames="ApplicationNumber,RDNumber,AadharNum,ApplicantName" Style="align-content: center;">
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
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Bank Details" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnCWSEDisplayBankDetails" class="ViewButton" runat="server" Text="View" OnClick="btnCWSEDisplayBankDetails_Click" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="CWStatus" HeaderText="Status" HeaderStyle-Width="10%" ItemStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="80px" HeaderStyle-CssClass="text-center text-center font-weight-bold" />

                                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Action" ItemStyle-Width="220">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnCWSEApprove" runat="server" OnClick="btnCWSEApprove_Click" class="EligibleButton" Text="Eligible" /><br />
                                                                        <asp:Button ID="btnCWSEHold" runat="server" OnClick="btnCWSEHold_Click" class="HoldButton" Text="Hold" Visible="false" /><br />
                                                                        <asp:Button ID="btnCWASEReject" runat="server" OnClick="btnCWSEReject_Click" class="InEligibleButton" Text="Ineligible" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" Width="6%" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:TemplateField>

                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>

                                                <asp:Panel ID="PnlCWSEBankDetails" runat="server" CssClass="modalPopup PopupPanel" Width="50%" Style="display: none;">
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
                                                                    <asp:Label ID="lblCWSEBDApplicationNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label8" runat="server">Account Holder Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCWSEBDAccountHolderName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label10" runat="server">Account Number</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCWSEBDAccountNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label12" runat="server">Bank Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCWSEBDBankName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label20" runat="server">Branch Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCWSEBDBranchName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label22" runat="server">IFSC Code</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCWSEBDIFSCCode" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label28" runat="server">Address</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCWSEBDBankAddress" runat="server"></asp:Label>
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
                                                <asp:LinkButton ID="lnkCWSEBankDetailsFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="CWSEBankDetailsPopup" runat="server" TargetControlID="lnkCWSEBankDetailsFake" PopupControlID="PnlCWSEBankDetails"
                                                    BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlCWSEConfirmHold" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
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
                                                                    <asp:Label ID="lblCWSEConfirmHoldAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label42" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblCWSEConfirmHoldAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label46" runat="server" Text="Reason"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtCWSEConfirmHoldAppReason" CssClass="PopupTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblCWSEConfirmHoldAppReasonError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnCWSEConfirmHoldApplication" runat="server" CssClass="ActionButton" Text="Hold" OnClick="btnCWSEConfirmHoldApplication_Click" />
                                                                    <asp:Button ID="Button5" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkCWSEConfirmHoldFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="CWSEConfirmHoldPopup" runat="server" PopupControlID="PnlCWSEConfirmHold"
                                                    TargetControlID="lnkCWSEConfirmHoldFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlCWSEConfirmApprove" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
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
                                                                    <asp:Label ID="lblCWSEConfirmApproveAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label51" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblCWSEConfirmApproveAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnCWSEConfirmApproveApplication" runat="server" CssClass="ActionButton" Text="Eligible" OnClick="btnCWSEConfirmApproveApplication_Click" />
                                                                    <asp:Button ID="Button10" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkCWSEConfirmApproveFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="CWSEConfirmApprovePopup" runat="server" PopupControlID="PnlCWSEConfirmApprove"
                                                    TargetControlID="lnkCWSEConfirmApproveFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Panel ID="PnlCWSERejectReason" runat="server" CssClass="modalPopup" Width="50%" Style="display: none">
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
                                                                    <asp:Label ID="lblCWSEConfirmRejectAppNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label33" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:Label ID="lblCWSEConfirmRejectAppName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label158" runat="server"> Select Reason<span style="color:red"> *</span></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input" style="flex-direction: column">
                                                                    <asp:RadioButton ID="rbCWSEConfirmRejectReasonName" runat="server" Class="radioButton" GroupName="CWSEConfirmRejectReason" Text="Name Mismatch" AutoPostBack="true" OnCheckedChanged="rbCWSEConfirmRejectReasonName_CheckedChanged" /><br />
                                                                    <asp:RadioButton ID="rbCWSEConfirmRejectReasonOther" runat="server" Class="radioButton" GroupName="CWSEConfirmRejectReason" Text="Other" AutoPostBack="true" OnCheckedChanged="rbCWSEConfirmRejectReasonName_CheckedChanged" /><br />
                                                                    <asp:Label runat="server" ID="lblCWSEConfirmRejectAppReasonSelectionError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row" id="divCWSERejectReason" runat="server" visible="false">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCWSERejectLabel" runat="server" Text="Reason"></asp:Label>
                                                                </div>
                                                                <div class="Popup-row-input">
                                                                    <asp:TextBox ID="txtCWSEConfirmRejectAppReason" CssClass="PopupTextBox" Style="height: 80px" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblCWSEConfirmRejectAppReasonError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-input">
                                                                    <asp:Button ID="btnCWSEConfirmRejectApplication" runat="server" CssClass="ActionButton" Text="Reject" OnClick="btnCWSEConfirmRejectApplication_Click" />
                                                                    <asp:Button ID="Button4" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkCWSERejectReasonFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="CWSEConfirmRejectPopup" runat="server" PopupControlID="PnlCWSERejectReason"
                                                    TargetControlID="lnkCWSERejectReasonFake" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="tab-pane fade" id="nav-NavCWSEAppnStatus" role="tabpanel" aria-labelledby="nav-NavCWSEAppnStatus-tab">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <div class="flex-container">
                                                <div class="navFormHeading">
                                                    <asp:Label runat="server">Self Employment Application Status</asp:Label>
                                                </div>
                                                <div class="navFormBody">
                                                    <div class="formFlex-row">
                                                        <asp:Label runat="server" class="labelStyle1" Text="Application Number"></asp:Label>
                                                        <asp:TextBox ID="txtCWSEApplicationStatus" class="textboxStyle1" runat="server"></asp:TextBox>
                                                        <asp:Button ID="btnCWSEGetApplicationStatus" runat="server" Text="Get Status" OnClick="btnCWSEGetApplicationStatus_Click" />
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
                                                                    <asp:Label ID="lblCWSEAppStatusApplicationNumber" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label56" runat="server">Applicant Name</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCWSEAppStatusApplicationName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label60" runat="server">Case Worker</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCWSEAppStatusApplicationCWStat" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label63" runat="server">District Manager</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCWSEAppStatusApplicationDMStat" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label65" runat="server">CEO Committee</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCWSEAppStatusApplicationCEOStat" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label67" runat="server">Documentation</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCWSEAppStatusApplicationDOCStat" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="form-row">
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="Label69" runat="server">Zonal Manager</asp:Label>
                                                                </div>
                                                                <div class="Popup-row-label">
                                                                    <asp:Label ID="lblCWSEAppStatusApplicationZMStat" runat="server"></asp:Label>
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

