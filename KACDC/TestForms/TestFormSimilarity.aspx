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
        <hr />
        <div>
            <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
            <asp:Button runat="server" ID="btnExist" Text="Cal" OnClick="btnExist_Click" />
            <asp:Label runat="server" ID="Label1"></asp:Label>
        </div>
        <hr />
        <div>
            <asp:TextBox runat="server" ID="TextBox2"></asp:TextBox>
            <asp:Button runat="server" ID="Button1" Text="UPDATE VAULT TOKEN" Visible="false" OnClick="Button1_Click" />
            <asp:Button runat="server" ID="Button2" Text="UPDATE VAULT TOKEN for 5" Visible="false" OnClick="Button2_Click" />
            <asp:Button runat="server" ID="Button3" Text="Test VAULT TOKEN " Visible="false" OnClick="Button3_Click" />
            <asp:Label runat="server" ID="Label2"></asp:Label>
        </div>
    </form>
</body>
</html>
