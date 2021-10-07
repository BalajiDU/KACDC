<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TallyReporting.aspx.cs" Inherits="KACDC.Service.TallyReporting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tally Reporting</title>
<style>
    @import url('https://fonts.googleapis.com/css?family=poppins');
    @import url('https://fonts.googleapis.com/css?family=Kalam');

    .container{
        width:50vw;
        padding:2em;
        margin:15vh auto 0;

        display:flex;
        flex-direction:column;
        background-color:aliceblue;
        /*flex-grow:1;
        flex-shrink:1;
        flex-wrap:wrap;*/
        justify-content:space-between;
        border-radius:15px;
        vertical-align:middle;
        font-family: "poppins", sans-serief;
        
    }
    .row{
        /*padding:15rem;
        position:relative;
        margin-left:25rem;*/
        flex-direction:row;
        width:100%
    }
    .item{
        border-radius:5px;
        margin:.5em;
        background-color:rgba(241, 238, 233, 0.63);
        padding:10px;
        width:22%;
        height:100%;
        font-size:large;
        text-align:center;
        border: none;
        font-size:15px;
        letter-spacing: 1px;
        /*
        align-self:center*/
    }
    .Button{
        font-weight: bold;
        padding-top:10px;
        letter-spacing: 1.2px;
        cursor: pointer;
        background: linear-gradient(to bottom, #009ac9 5%, #009ac9 100%);
    }
    .Button:hover {
        background: linear-gradient(to bottom, #007fa5 5%, #007296 100%);
        color:antiquewhite;
        /*background-color: #076fc0;*/
    }
    .heading{
        font-family: 'Kalam', cursive;
        font-size: 48px;
        text-shadow: 4px 4px 4px #aaa;
        text-align: center;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="heading">Self Employment Reporting</div>
            <div class="row">
            <asp:DropDownList ID="drpFinancialYear" Class="item NeuoDropdown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpFinancialYear_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:DropDownList ID="drpZone" runat="server" class="item NeuoDropdown" AutoPostBack="True" OnSelectedIndexChanged="drpZone_SelectedIndexChanged" >
                <asp:ListItem Value="0">Zone</asp:ListItem>
                <asp:ListItem Value="Belagavi">Belagavit</asp:ListItem>
                <asp:ListItem Value="Bengaluru">Bengaluru</asp:ListItem>
                <asp:ListItem Value="Kalaburgi">Kalaburgi</asp:ListItem>
                <asp:ListItem Value="Mysuru">Mysuru</asp:ListItem>
            </asp:DropDownList>

            <asp:DropDownList ID="drpDistrict" Class="item NeuoDropdown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpDistrict_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:Button ID="btnDownloadExcel" Text="Download Excel" class="item Button" runat="server" OnClick="btnDownloadExcel_Click" />
                </div>
        </div>
    </form>
</body>
</html>
