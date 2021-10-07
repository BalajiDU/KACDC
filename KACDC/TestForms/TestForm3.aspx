<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestForm3.asp=cs" Inherits="KACDC.TestForms.TestForm3" %>

<%--<%@ Register assembly="CrystalDecisions.Web" namespace="CrystalDecisions.Web" tagprefix="CR" %>--%>

<%--<%@ Register Assembly="CrystalDecisions.Web" Namespace="CrystalDecisions.Reporting.WebControls" TagPrefix="cc1" %>
    --%>

<%--<%@ Register Assembly="CrystalDecisions.Web" Namespace="CrystalDecisions.Web"  TagPrefix="CR" %>--%>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304"PublicKeyToken=692FBEA5521E1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">4r65t                    *-+/
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">

    

</head>
<body>
    <form id="form1" runat="server">


        <asp:Button ID="btnprintjtest" runat="server" Text="export print" OnClick="rept_Click" />
                    <asp:Button ID="rept" runat="server" Text="Crystal report" OnClick="button2_Click" />
        
        <div>
<%--            <CR:crystalreportviewer ID="CrystalReportViewer1" runat="server" autodatabind="true"></CR:crystalreportviewer>--%>
<%--            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />--%>
<%--            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />--%>
        </div>

    </form>
</body>
</html>
