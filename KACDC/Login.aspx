<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KACDC.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="CustomCSS/LoginPage.css" rel="stylesheet" />

     <div id="divAdminLogin" class="AdminLogin">
<%--            <asp:Login ID = "Login1" runat = "server" OnAuthenticate="ValidateUser"></asp:Login>--%>
         <asp:Login ID="Login1" runat="server" OnAuthenticate="ValidateUser">
             <LayoutTemplate>
                 <h1>Log In</h1>
                 <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" style="font-weight:700">User Name:</asp:Label>
                 <asp:TextBox ID="UserName" runat="server" class="textbox" ></asp:TextBox>
                 <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                 <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" style="font-weight:700">Password:</asp:Label>
                 <asp:TextBox ID="Password" runat="server" TextMode="Password" class="textbox"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                 <br />
                 <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." /><br />
                 <span  style="font-weight:500;color:red;text-transform:uppercase"><asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></span>
                 
                 <asp:Button ID="LoginButton" runat="server" class="Button" CommandName="Login" Text="Log In" ValidationGroup="Login1" /><br />
                 <asp:LinkButton  ID="Button1" runat="server" href="https://aryavysya.karnataka.gov.in/LMS" class="Button"  Text="Loan Management System" Width="100%" />
             </LayoutTemplate>
         </asp:Login>
        </div>
   
</asp:Content>
