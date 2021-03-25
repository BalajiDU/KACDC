<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestForm1.aspx.cs" Inherits="KACDC.TestForms.TestForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txt1" runat="server"></asp:TextBox>
            <asp:Button ID="btn1" runat="server" Text="verify substring" OnClick="btn1_Click" />
            <asp:Label ID ="lbl1" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
