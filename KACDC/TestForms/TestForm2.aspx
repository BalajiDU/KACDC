<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestForm2.aspx.cs" Inherits="KACDC.TestForms.TestForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ApplicationNumber"  RowHeaderColumn="ApplicationNumber" Font-Size="Larger" Visible="false" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="ApplicationNumber" HeaderText="Application Number" ReadOnly="True" SortExpression="ApplicationNumber" />
                    <asp:BoundField DataField="ApplicantName" HeaderText="Applicant Name" SortExpression="ApplicantName" />
                    <asp:BoundField DataField="LoanAmount" HeaderText="Loan Amount" SortExpression="LoanAmount" />
                    <asp:BoundField DataField="ReleaseDate" HeaderText="Release Date" SortExpression="ReleaseDate" />
                    <%--<asp:BoundField DataField="ZMApprove" HeaderText="ZMApprove" SortExpression="ZMApprove" />
                    <asp:BoundField DataField="DISTRICT" HeaderText="DISTRICT" SortExpression="DISTRICT" />
                    <asp:BoundField DataField="ZONE" HeaderText="ZONE" SortExpression="ZONE" />--%>
                    <asp:BoundField DataField="LOANNUMBER" HeaderText="LOAN NUMBER" SortExpression="LOANNUMBER" />
                    <asp:BoundField DataField="TOTALPAID" HeaderText="TOTAL PAID" ReadOnly="True" SortExpression="TOTALPAID" />
                    <asp:BoundField DataField="LASTPAID" HeaderText="LAST PAID" ReadOnly="True" SortExpression="LASTPAID" />
                    <asp:BoundField DataField="SINSCNOTPAID" HeaderText="SINSC NO TPAID" ReadOnly="True" SortExpression="SINSCNOTPAID" />
                    <asp:BoundField DataField="INSTALMENT" HeaderText="INSTALMENT" ReadOnly="True" SortExpression="INSTALMENT" />
                    <asp:BoundField DataField="PAYABLEINSTALMENTS" HeaderText="PAYABLE INSTALMENTS" ReadOnly="True" SortExpression="PAYABLEINSTALMENTS" />
                    <asp:BoundField DataField="PAYABLEAMOUNT" HeaderText="PAYABLE AMOUNT" ReadOnly="True" SortExpression="PAYABLEAMOUNT" />
                    <asp:BoundField DataField="REMAININGAMOUNT" HeaderText="REMAINING AMOUNT" ReadOnly="True" SortExpression="REMAININGAMOUNT" />
                </Columns>
                <HeaderStyle BackColor="#666666" ForeColor="white" HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Larger" />
                <RowStyle BackColor="#E7E7E7" BorderColor="#333333" BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KACDCConnectionString %>" SelectCommand="spGetRcoveryStats" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue=" " Name="District" SessionField="District" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>

        </div>
    </form>
</body>
</html>
