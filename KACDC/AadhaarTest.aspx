<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AadhaarTest.aspx.cs" Inherits="KACDC.AadhaarTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtAadhaar" runat="server"></asp:TextBox>
            <asp:Button ID="btnAadhaarGetOTP" runat="server" Text="Get OTP" OnClick="btnAadhaarGetOTP_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
            <asp:TextBox ID="txtAadhaarOTP" runat="server"></asp:TextBox>
            <asp:Button ID="btnAadhaarOTPVerify" runat="server" Text="Varify OTP" OnClick="btnAadhaarOTPVerify_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
            <br />
            OTP trans ID :
            <asp:Label runat="server" ID="lblTransID"></asp:Label><br />
            Token Up :
            <asp:Label runat="server" ID="lblToken"></asp:Label>
            <br /><hr />
                        <asp:Button ID="btnProcessTest" runat="server" Text="Process Test" OnClick="btnProcessTest_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" />

        </div>
    </form>
</body>
</html>
