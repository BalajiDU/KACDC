<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulkMessageService.aspx.cs" Inherits="KACDC.Service.BulkMessageService" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Message Service</title>
     <link href="../CustomCSS/ApprovalPageCss/ModalDesign.css" rel="stylesheet" />
    <link href="~/CustomCss/ApprovalPageCss/FormStyles.css" rel="stylesheet" type="text/css" />
    <link href="~/CustomCss/ApprovalPageCss/TopNavBar.css" rel="stylesheet" />
        <link href="../../CustomCSS/ApplicationPage/ApplicationPage.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <style>
* {
  box-sizing: border-box;
}

body {
  font-family: Arial, Helvetica, sans-serif;
}

/* Float four columns side by side */
.column {
  float: left;
  width: 32%;
  padding: 0 10px;
}

/* Remove extra left and right margins, due to padding */
.row {margin: 0 -5px;
      margin-top:20px
}

/* Clear floats after the columns */
.row:after {
  content: "";
  display: table;
  clear: both;
}

/* Responsive columns */
@media screen and (max-width: 600px) {
  .column {
    width: 100%;
    display: block;
    margin-bottom: 20px;
  }
}

/* Style the counter cards */
.card {
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
  padding: 16px;
  text-align: center;
  background-color: #f1f1f1;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Popup-flex-container">
            <div class="navFormHeading">
                <asp:Label runat="server">WELCOME</asp:Label>
            </div>
            <div class="navFormWelcomeDistrict">
                <asp:Label ID="lblWelcomeDistCW" runat="server" Text="KACDC - Message Service"></asp:Label>
            </div>
            <div class="form-row text-center">
                <div class="Popup-row-input">
                    <asp:TextBox ID="txtMobileNumber1" runat="server" TextMode="MultiLine" CssClass="PopupTextBox" Width="80%" Height="100px" placeholder="Mobile Number" Style="display: inline-block; margin: 0 auto;"></asp:TextBox><br />
                    <asp:TextBox ID="txtMessage1" runat="server" TextMode="MultiLine" CssClass="PopupTextBox" Width="80%" Height="100px" placeholder="Message" Style="display: inline-block; margin: 0 auto;"></asp:TextBox><br />

                    <asp:Button ID="btnSendMessageOld" runat="server" Text="Send Single Message" OnClick="btnSendSingleMessage_Click" class="DownloadButton" />
                    <asp:Button ID="Button2" runat="server" Text="Send Single Unicode Message" OnClick="btnSendSingleUnicodeMessage_Click" class="DownloadButton" />
                    <asp:Button ID="Button1" runat="server" Text="Send Bulk Message (Non Unicode)" OnClick="btnSendServerBulkMessage_Click" class="DownloadButton" />
<%--                    <asp:Button ID="Button3" runat="server" Visible="false" Text="Send Bulk Unicode Message" OnClick="btnSendMessage_Click" class="DownloadButton" /><br />--%>
                    <asp:Label ID="lblCountDisplay" runat="server" Text=""></asp:Label>
                </div>
            </div>
                    <asp:Button ID="btnMessageLogout" runat="server" Text="Logout" CssClass="logoutButton" OnClick="btnMessageLogout_Click" Style="margin-right:2%;width:25%;position: absolute;right:0;" />
        </div>
        <div class="flex-container ContantMain" id="divSEApplicationMail" runat="server">
            <div class="NeumorphicDiv" style="background-color: rgba(216, 216, 216, 0.19); border-radius: 25px;">
                <div class="navFormHeading">
                    <asp:Label runat="server">WELCOME</asp:Label>
                </div>
                <div class="navFormWelcomeDistrict">
                    <asp:Label ID="Label1" runat="server" Text="KACDC - Message Service"></asp:Label>
                </div>
                <%--<div class="form-row" style="width: 60%">
                    <div class="form-row-label">
                        <asp:Label ID="Label12" class="" Style="color: black" runat="server">Message Type</asp:Label><br />
                    </div>
                    <div class="form-row-input">
                        <%--OnCheckedChanged="LoanType_CheckChanged"
                        <asp:RadioButton ID="rbMale" Class="radioButton" runat="server" GroupName="Gender" Text="Single" />
                        <asp:RadioButton ID="rbFemale" Class="radioButton" runat="server" GroupName="Gender" Text="Bulk" />
                        <asp:Label ID="lblGenderError" runat="server" class="DisplayError" Style="font-size: 18px; font-weight: bold; color: #7b0000"></asp:Label>
                    </div>
                    <div class="form-row-Botton" id="div21" runat="server">
                    </div>
                </div>--%>

                <div class="row">
                    <div class="column">
                        <div class="card">
                            <h3>Language</h3>
                            <p>
                                <asp:RadioButton ID="rbKannada" Class="radioButton" runat="server" GroupName="Language" Text="Kannada" AutoPostBack="true" OnCheckedChanged="Language_CheckedChanged"/>
                                <asp:RadioButton ID="rbEnglish" Class="radioButton" runat="server" GroupName="Language" Text="English" AutoPostBack="true" OnCheckedChanged="Language_CheckedChanged"/>
                            </p>
                        </div>
                    </div>

                    <div class="column">
                        <div class="card">
                            <h3>Message Type</h3>
                            <p>
                                <asp:RadioButton ID="rbSingle" Class="radioButton" runat="server" GroupName="Type" Text="Single" AutoPostBack="true" OnCheckedChanged="rbApplicantPWD_CheckedChanged" />
                                <asp:RadioButton ID="rbBulk" Class="radioButton" runat="server" GroupName="Type" Text="Bulk" AutoPostBack="true" OnCheckedChanged="rbApplicantPWD_CheckedChanged" />
                            </p>
                        </div>
                    </div>

                    <div class="column">
                        <div class="card">
                            <h3>Message Category</h3>
                            <p>
                                <asp:DropDownList ID="drpCategory" Class="" runat="server" AutoPostBack="true" style="width:90%;height:25px;background-color:#f1f1f1;border-radius:5px"><%--NeuoDropdown--%>
                                    <asp:ListItem style="color: red; font-size: large; font-weight: bold; text-align: center" Value="0">--SELECT--</asp:ListItem>
                                    <asp:ListItem Value="student">student</asp:ListItem>
                                    <asp:ListItem Value="business">business</asp:ListItem>
                                    <asp:ListItem Value="employee">employee</asp:ListItem>
                                </asp:DropDownList>
                            </p>

                        </div>
                    </div>


                </div>


                <div class="row">
                    <div class="column" style="width: 100%">
                        <div class="card">
                            <%--<h3>Mobile Number</h3>--%>
                            <p>
                                <asp:TextBox ID="txtMobileNumber" runat="server" TextMode="MultiLine" CssClass="PopupTextBox" Width="100%" Height="100px" placeholder="Mobile Number" Style="display: inline-block; margin: 0 auto; border: 5px solid; border-color: rgba(216, 216, 216, 0.70)"></asp:TextBox><br />

                            </p>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="column" style="width: 100%">
                        <div class="card">
                            <%-- <h3>Message Type</h3>--%>

                            <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" CssClass="PopupTextBox" Width="100%" Height="100px" placeholder="Message" Style="display: inline-block; margin: 0 auto; border: 5px solid; border-color: rgba(216, 216, 216, 0.70)"></asp:TextBox><br />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="column" style="width: 100%">
                        <div class="">
                            <%-- <h3>Message Type</h3>--%>

                    <asp:Button ID="btnSendMessage" runat="server" Text="Send  Message" OnClick="btnSendMessage_Click" class="DownloadButton" Style="background:rgba(216, 216, 216, 0.70);color:brown;height:40px;font-size:25px;border-radius:10px" />
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
