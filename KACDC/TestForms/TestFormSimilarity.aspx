<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestFormSimilarity.aspx.cs" Inherits="KACDC.TestForms.TestFormSimilarity" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="txt1"></asp:TextBox>
            <asp:TextBox runat="server" ID="txt2"></asp:TextBox>
            <asp:Button runat="server" ID="btnCheck" Text="Cal" OnClick="btnCheck_Click" />
            <asp:Label runat="server" ID="lblRes"></asp:Label>
        </div>
    </form>
</body>
</html>
