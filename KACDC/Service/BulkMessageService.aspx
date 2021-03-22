<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulkMessageService.aspx.cs" Inherits="KACDC.Service.BulkMessageService" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Message Service</title>
     <link href="../CustomCSS/ApprovalPageCss/ModalDesign.css" rel="stylesheet" />
    <link href="~/CustomCss/ApprovalPageCss/FormStyles.css" rel="stylesheet" type="text/css" />
    <link href="~/CustomCss/ApprovalPageCss/TopNavBar.css" rel="stylesheet" />

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
                    <asp:TextBox ID="txtMobileNumber" runat="server" TextMode="MultiLine" CssClass="PopupTextBox" Width="80%" Height="100px" placeholder="Mobile Number" Style="display: inline-block; margin: 0 auto;"></asp:TextBox><br />
                    <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" CssClass="PopupTextBox" Width="80%" Height="100px" placeholder="Message" Style="display: inline-block; margin: 0 auto;"></asp:TextBox><br />

                    <asp:Button ID="btnSendMessage" runat="server" Text="Send Single Message" OnClick="btnSendSingleMessage_Click" class="DownloadButton" />
                    <asp:Button ID="Button2" runat="server" Text="Send Single Unicode Message" OnClick="btnSendSingleUnicodeMessage_Click" class="DownloadButton" />
                    <asp:Button ID="Button1" runat="server" Text="Send Bulk Message (Non Unicode)" OnClick="btnSendServerBulkMessage_Click" class="DownloadButton" />
<%--                    <asp:Button ID="Button3" runat="server" Visible="false" Text="Send Bulk Unicode Message" OnClick="btnSendMessage_Click" class="DownloadButton" /><br />--%>
                    <asp:Label ID="lblCountDisplay" runat="server" Text=""></asp:Label>
                </div>
            </div>
                    <asp:Button ID="btnMessageLogout" runat="server" Text="Logout" CssClass="logoutButton" OnClick="btnMessageLogout_Click" Style="margin-right:2%;width:25%;position: absolute;right:0;" />
        </div>
    </form>
</body>
</html>
