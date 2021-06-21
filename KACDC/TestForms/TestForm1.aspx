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
        <hr />
                                                <asp:RadioButton ID="rbContactAddressYes" Class="radioButton" runat="server" GroupName="ContactAddress" Text="Yes" AutoPostBack="true" OnCheckedChanged="rbContactAddress_CheckedChanged"  />
                                        <asp:RadioButton ID="rbContactAddressNo" Class="radioButton" runat="server" GroupName="ContactAddress" Text="No" AutoPostBack="true" OnCheckedChanged="rbContactAddress_CheckedChanged" />
            <asp:Label ID ="lbl2" runat="server"></asp:Label>
        <hr />
                    <asp:Label ID ="lblStatuscode" runat="server"></asp:Label>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
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
                <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                                            <ItemTemplate>
                                                <%# Eval("ApplicantName")%>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtAppNum" runat="server" Text='<%# Eval("ApplicantName") %>' Enabled="false" />
                                            </EditItemTemplate>
                                            <HeaderStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="180px" />
                                        </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                                            <ItemTemplate>
                                                <%# Eval("FinancialYear")%>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtAppNum" runat="server" Text='<%# Eval("FinancialYear") %>' Enabled="false" />
                                            </EditItemTemplate>
                                            <HeaderStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="180px" />
                                        </asp:TemplateField>

                </Columns>
        </asp:GridView>
        <hr />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="verify substring" OnClick="Button1_Click" />
            <asp:Label ID ="Label1" runat="server"></asp:Label>
        <hr />
        
            <asp:Label ID ="Label2" runat="server"></asp:Label>
        <hr />
        <asp:Button ID="btnExportExcel" runat="server" Text="Export Excel" OnClick="btnExportExcel_Click" />
        <asp:Button ID="btnExportPDFZMApproved" runat="server" Text="Export PDF ZM Approved" OnClick="btnExportPDFZMApproved_Click" />
    </form>
</body>
</html>
