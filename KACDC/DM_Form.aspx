<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="DM_Form.aspx.cs" Inherits="KACDC.DM_Form" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DM Form</title>   
    <style>
        .btn-hover:hover {
            background-position: 100% 0;
            moz-transition: all .6s ease-in-out;
            -o-transition: all .6s ease-in-out;
            -webkit-transition: all .6s ease-in-out;
            transition: all .6s ease-in-out;
            color: black;
        }

        .btn-hover {
            border-radius: 3%;
            width: 100%;
            font-size: 16px;
            font-weight: 600;
            color: #fff;
            cursor: pointer;
            height: 35px;
            text-align: center;
            border: none;
            background-size: 300% 100%;
            color: dimgrey;
            moz-transition: all .4s ease-in-out;
            -o-transition: all .4s ease-in-out;
            -webkit-transition: all .4s ease-in-out;
            transition: all .4s ease-in-out;
        }

        .rowMargin {
            margin: 2%;
        }

        .btn-hover.btncolor {
            background-image: linear-gradient(to right, #80cef2 0%, #aee6fc 51%, #5bc1f0 100%);
        }

        .btn-hover.btnSubcolor {
            background-image: linear-gradient(to right, #80cef2 0%, #aee6fc 51%, #5cf759 100%);
        }

        .txtcolor {
            /*border-image-source: linear-gradient(179deg, #80cef2 30%, #5bc1f0 31%, #aee6fc 30%);*/
            border-radius: 3%;
            border-width: 1pt;
            border-image-slice: 1;
            border-image-source: -moz-linear-gradient(-45deg, #80cef2 0%, #4ccafc 100%, #24c1ff 100%);
            border-image-source: -webkit-linear-gradient(-45deg, #80cef2 0%, #4ccafc 100%, #24c1ff 100%);
            border-image-source: linear-gradient(135deg, #80cef2 0%, #4ccafc 100%, #24c1ff 100%);
        }

            .txtcolor:focus {
                color: #5bc1f0;
                border-width: 1.5pt;
                background-color: #fff;
                border-color: #80bdff;
                outline: 0;
                box-shadow: 0 1px 2px 0 rgba(65, 132, 234, 0.75);
            }
    </style>
    <style type="text/css">
        section {
            padding: 20px 0;
        }

            section .section-title {
                text-align: center;
                color: darkblue;
                margin-bottom: 50px;
                text-transform: uppercase;
            }

        #tabs {
            color: #6b6b6b;
        }

            #tabs h6.section-title {
                color: darkblue;
            }

            #tabs .nav-tabs .nav-item.show .nav-link, .nav-tabs .nav-link.active {
                color: #f3f3f3;
                border-color: transparent transparent #f3f3f3;
                border-bottom: 4px solid !important;
                font-size: 20px;
                font-weight: bold;
            }

            #tabs .nav-tabs .nav-link {
                border: 1px solid transparent;
                border-top-left-radius: .25rem;
                border-top-right-radius: .25rem;
                color: darkslategray;
                font-size: 20px;
            }
    </style>
    <style>
        .btn-hover:hover {
            background-position: 100% 0;
            moz-transition: all .6s ease-in-out;
            -o-transition: all .6s ease-in-out;
            -webkit-transition: all .6s ease-in-out;
            transition: all .6s ease-in-out;
            color: black;
        }

        .btn-hover {
            border-radius: 3%;
            width: 100%;
            font-size: 16px;
            font-weight: 600;
            color: #fff;
            cursor: pointer;
            height: 35px;
            text-align: center;
            border: none;
            background-size: 300% 100%;
            color: dimgrey;
            moz-transition: all .4s ease-in-out;
            -o-transition: all .4s ease-in-out;
            -webkit-transition: all .4s ease-in-out;
            transition: all .4s ease-in-out;
        }

        .rowMargin {
            margin: 2%;
        }

        .btn-hover.btncolor {
            background-image: linear-gradient(to right, #80cef2 0%, #aee6fc 51%, #5bc1f0 100%);
        }

        .btn-hover.btnSubcolor {
            background-image: linear-gradient(to right, #80cef2 0%, #aee6fc 51%, #5cf759 100%);
        }

        .btn-hover.btnModcolor {
            background-image: linear-gradient(to right, #80cef2 0%, #aee6fc 51%, #f75959 100%);
        }

        .btn-hover.btnPricolor {
            background-image: linear-gradient(to right, #80cef2 0%, #aee6fc 51%, #59a5f7 100%);
        }

        .txtcolor {
            /*border-image-source: linear-gradient(179deg, #80cef2 30%, #5bc1f0 31%, #aee6fc 30%);*/
            border-radius: 3%;
            border-width: 1pt;
            border-image-slice: 1;
            border-image-source: -moz-linear-gradient(-45deg, #80cef2 0%, #4ccafc 100%, #24c1ff 100%);
            border-image-source: -webkit-linear-gradient(-45deg, #80cef2 0%, #4ccafc 100%, #24c1ff 100%);
            border-image-source: linear-gradient(135deg, #80cef2 0%, #4ccafc 100%, #24c1ff 100%);
        }
            /*.txtcolor:focus {
            background-position: 100% 0;
            moz-transition: all .6s ease-in-out;
            -o-transition: all .6s ease-in-out;
            -webkit-transition: all .6s ease-in-out;
            transition: all .6s ease-in-out;
            color: black;
        }

         .txtcolor::-ms-expand {
  background-color: transparent;
  border: 0;
}

.txtcolor:-moz-focusring {
  color: transparent;
  text-shadow: 0 0 0 #495057;
}*/

            .txtcolor:focus {
                color: #5bc1f0;
                border-width: 1.5pt;
                background-color: #fff;
                border-color: #80bdff;
                outline: 0;
                box-shadow: 0 1px 2px 0 rgba(65, 132, 234, 0.75);
            }
    </style>
    <style>
        .body{
            font-family:sans-serif;
        }
        .formBox{
            margin-top:15px;
            padding:10px;
            border:thick solid rgba(0,174,255,0.2);
            border-color: rgba(0,174,255,0.5);
            box-sizing:border-box;
            box-shadow:0 0 0 rgba(0,0,0,0.8);
            background-color:rgba(22,158,13,0.05)
        }
        .box {
            position:absolute;
            transform:translate(-50%,-50%);
            width:400px;
            padding:40px;
            background:rgba(0,0,0,0.3);
            box-sizing:border-box;
            box-shadow:0 0 0 rgba(0,0,0,0.1);
            
        }
        .SubBox{
            position:absolute;
            top:75.03%;
            left:46%;
            transform:translate(-50%,-50%);
            width:800px;
            padding:40px;
            background:rgba(0,0,0,0.3);
            box-sizing:border-box;
            box-shadow:0 25px 25px rgba(0,0,0,0.1);
            border-radius: 0 0 5px 5px ;
        }
         h2{
             padding:0;
             text-align:center;
             color:rgba(0,0,0,0.5);
             text-transform:uppercase;
             letter-spacing:1px;
         }

         h5{
             padding:0;
             color:red;
             font-size:15px;
             font-family:Courier New;
             letter-spacing:1px;
             font-weight: bold;
         }
         .InputBox{
             position:relative;
             box-sizing:border-box;
             margin-bottom:5px;
             margin-left:20%;
             width:80%;
         }
         .InputBox input{
             
             width:100%;
             padding:5px 0;
             font-size:16px;
             color:rgba(0,0,0,0.5);
             letter-spacing:1px;
             margin-bottom:10px;
             border:none;
             border-bottom:2px solid rgba(0,0,0,0.5);
             outline:none;
             background:transparent;
             
         }
         .InputBox label{
             position:absolute;
             top:0;left:0;
             padding:10px 0;
             font-size:16px;
             color:rgba(0,0,0,0.5);
             pointer-events:none;
             transition:.5S;
         }
         .InputBox input:focus ~ label,
         .InputBox input:valid ~ label{
             top:-18px;
             left:0;
             color:rgba(0,174,255,1);
             font-size:13px;
         }
         .Button{
             width:80%;
             font-size:16px;
             margin-top:10px;
             margin-left:18%;
             background:transparent;
             border:none;
             outline:none;
             color:#fff;
             background:rgba(3,154,244,0.8);
             padding:10px 20px;
             cursor:pointer;
             border-radius:3px;
         }


        
       .link{
             
             position:absolute;
             left:10%;
             transform:translate(-50%, 50%);
             color:#1670f0;
             padding:25px 60px;
             font-size:30px;
             letter-spacing:1.5px;
             text-transform:uppercase;
             text-decoration:none;
             box-shadow:0 20px 50px rgba(0,0,0,0.5);
			 overflow:hidden;
         }
        .link:before{
            content:'';
            position:absolute;
            top:2px;
            left:2px;
            bottom:2px;
            width:50%;
            background:rgba(255,255,255,0.05);

        }
        .link span:nth-child(1){
           position:absolute;
            top:0;
            left:0;
            width:100%;
            height:2px;
            background:linear-gradient(to right,#0c002b,#1779ff);
			animation: animate1 2s linear infinite;
        }
		
		@keyframes animate1{
			0%
			{
				transform: translateX(-100%);
			}
			100%
			{
				transform: translateX(100%);
			}
		}
		
		.link span:nth-child(2){
            position:absolute;
            top:0;
            right:0;
            width:2px;
            height:100px;
            background:linear-gradient(to bottom,#0c002b,#1779ff);
			
			animation: animate2 2s linear infinite;
        }
		
		@keyframes animate2{
			0%
			{
				transform: translateY(-100%);
			}
			100%
			{
				transform: translateY(100%);
			}
		}
		
		.link span:nth-child(3){
            position:absolute;
            bottom:0;
            left:0;
            width:100%;
            height:2px;
            background:linear-gradient(to left,#0c002b,#1779ff);
			animation: animate3 2s linear infinite;

        }
		@keyframes animate3{
			0%
			{
				transform: translateX(100%);
			}
			100%
			{
				transform: translateX(-100%);
			}
		}
		.link span:nth-child(4){
            position:absolute;
            top:0;
            left:0;
            width:2px;
            height:100px;
            background:linear-gradient(to top,#0c002b,#1779ff);
			
			animation: animate4 2s linear infinite;
        }
		@keyframes animate4{
			0%
			{
				transform: translateY(100%);
			}
			100%
			{
				transform: translateY(-100%);
			}
		}

        .dropdown{
            background:#0563af;
            color:#fff;
            padding:10px;
            width:250px;
            height:40px;
            border:none;
            font-size:15px;
            box-shadow:0 5px 25px rgba(0,0,0,0.5);
            -webkit-appearance:button;
            outline:none;
            align-content:center;
        }
        .GridView{
            border-collapse:collapse;
            text-align:center;
        }
        .GridView td 
        {
                padding: 10px;
                border: 1px solid #c1c1c1;
                font-size: 1em;
        }

        .GridView th {
            padding: 4px 2px;
            text-align :center;
            background-color :#CCCCCC;
            color:black;
            vertical-align :middle;
            text-align :center;
            font-weight: bold;
        }
            .GridView th a {
                color: White;
                text-decoration: none;
            }
        .GridHeader {
            background-color :#CCCCCC;
            color:black;
            vertical-align :middle;
            text-align :center;
            font-weight: bold;
        }
        
        .PopupTextBox{
            box-sizing: border-box;
            width: 280px;
            height: 50px;
            font-size: 18px;
            padding: 7px;
            border: none;
            outline: none;
            display:flex;
            flex-wrap: wrap;
            text-align: center;
            background: #eeecec;
            border-radius: 10px;
            text-shadow: 1px 1px 0 #fff;
            color:#303030;
            box-shadow: inset 5px 5px 10px #dddbdb, inset -5px -5px 10px #fffdfd;
        }
    
        .modalPopup{
  margin: 20px auto 0 auto;
  padding: 30px;
  background-color: #eeecec;
          


  border-radius: 25px;
            box-shadow:  10px 10px 20px #cac9c9, 
             -10px -10px 20px #ffffff;
            margin: 20px;
            margin-top: 10px;
            font-size:20px;
            align-items: center;
            letter-spacing: 1.5px;
            font-family: "poppins", sans-serief;
        }
       
        .form-row {
          padding: 10px 0;
          display: flex;
        }
        .form-row-label {
  padding-right: 10px;
    flex:1;
}

.form-row-input {
  flex: 1;
}
.modalBackground {
	background-color:Black;
	filter:alpha(opacity=90);
	opacity:0.8;
}
    </style>
    <script type="text/javascript">
        $(function () {
            BlockUI("divDMKA");
            $.blockUI.defaults.css = {};
        });
        $(function () {
            BlockUI("divDMEN");
            $.blockUI.defaults.css = {};
        });
        $(function () {
            BlockUI("divZMEN");
            $.blockUI.defaults.css = {};
        });
        $(function () {
            BlockUI("divZMKA");
            $.blockUI.defaults.css = {};
        });
        $(function () {
            BlockUI("divHOEN");
            $.blockUI.defaults.css = {};
        });
        $(function () {
            BlockUI("divHOKA");
            $.blockUI.defaults.css = {};
        });
        $(function () {
            BlockUI("divUsrCre");
            $.blockUI.defaults.css = {};
        });
        $(function () {
            BlockUI("divSliderImg");
            $.blockUI.defaults.css = {};
        });
        function BlockUI(elementID) {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_beginRequest(function () {
                $("#" + elementID).block({
                    message: '<div align = "center">' + '< img src = "Image/loadingAnim.gif" /></div>',
                    css: {},
                    overlayCSS: { backgroundColor: '#000000', opacity: 0.6, border: '3px solid #63B2EB' }
                });
            });
            prm.add_endRequest(function () {
                $("#" + elementID).unblock();
            });
        };
    </script>
    <script type="text/javascript">
        function numeric(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && ((charCode >= 48 && charCode <= 57) || charCode == 46))
                return true;
            else {
                alert('Please Enter Numeric values.');
                return false;
            }
        }

    </script>
    <script type="text/javascript">
        function BlockUI(elementID) {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_beginRequest(function () {
                $("#" + elementID).block({
                    message: '<table align = "center"><tr><td>' +
                        '<img src="Image/loadingAnim.gif"/></td></tr></table>',
                    css: {},
                    overlayCSS: {
                        backgroundColor: '#000000', opacity: 0.6
                    }
                });
            });
            prm.add_endRequest(function () {
                $("#" + elementID).unblock();
            });
        }
        $(document).ready(function () {

            BlockUI("<%=PnlDMSEDocReason.ClientID %>");
            $.blockUI.defaults.css = {};
        });
        function SEDocHidepopup() {
            $find("DMSEDocRejectPopup").hide();
            return false;
        }
        $(document).ready(function () {

            BlockUI("<%=PnlDMSECEOReason.ClientID %>");
            $.blockUI.defaults.css = {};
        });
        function SECEOHidepopup() {
            $find("DMSECEORejectPopup").hide();
            return false;
        }
        $(document).ready(function () {

            BlockUI("<%=PnlDMSECEOWaitingReason.ClientID %>");
            $.blockUI.defaults.css = {};
        });
        function SECEOWaitingHidepopup() {
            $find("DMSECEOWaitingRejectPopup").hide();
            return false;
        }
        $(document).ready(function () {

            BlockUI("<%=PnlDMARCEOReason.ClientID %>");
            $.blockUI.defaults.css = {};
        });
        function ARCEOHidepopup() {
            $find("DMARCEORejectPopup").hide();
            return false;
        }
        $(document).ready(function () {

            BlockUI("<%=PnlDMARCEOWaitingReason.ClientID %>");
            $.blockUI.defaults.css = {};
        });
        function ARCEOWaitingHidepopup() {
            $find("DMARCEOWaitingRejectPopup").hide();
            return false;
        }
        $(document).ready(function () {

            BlockUI("<%=PnlDMARDocReason.ClientID %>");
            $.blockUI.defaults.css = {};
        });
        function ARDocHidepopup() {
            $find("DMARDocRejectPopup").hide();
            return false;
        }
    </script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/1.11.2/jquery.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.blockUI.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link href="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>
    <script type="text/javascript" src="Scripts/jquery.blockUI.js"></script>
    <script type="text/javascript" src="Scripts/jquery-1.3.2.min.js"></script>
</head>
<body>
    <form runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:Button ID="btnLogout" class="btn btn-hover btnSubcolor" Width="10%" runat="server" Text="Logout" OnClick="btnLogout_Click" />

        <div>
            <ul class="nav nav-tabs">
                <li class="active"><a data-toggle="tab" href="#home">Arivu Educational Loan</a></li>
                <li><a data-toggle="tab" href="#menu1">Self Employment Loan</a></li>
                <li><a data-toggle="tab" href="#mpic">MPIC</a></li>
            </ul>

            <div class="tab-content">
                <div id="home" class="tab-pane fade in active">
                    <div>
                        <ul class="nav nav-tabs">
                            <li class="active"><a data-toggle="tab" href="#home1">District Manager</a></li>
                            <li><a data-toggle="tab" href="#menu11">CEO Committee</a></li>
                            <li><a data-toggle="tab" href="#menu21">Document Verification</a></li>
                        </ul>

                        <div class="tab-content">
                            <div id="home1" class="tab-pane fade in active">
                                <div>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div class="text-center">
                                                <asp:GridView ID="ArivugvDMApprove" runat="server" class="GridView" OnRowEditing="ArivugvDMApprove_RowEditing" AutoGenerateColumns="False" DataKeyNames="ApplicationNumber,RDNumber,AadharNum" Style="align-content: center; margin-left: 5px">
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                                                            <ItemTemplate>
                                                                <%# Eval("ApplicationNumber")%>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtArivuDMAppNum" runat="server" Text='<%# Eval("ApplicationNumber") %>' Enabled="false" />
                                                            </EditItemTemplate>
                                                            <HeaderStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="180px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Applicant Name" ItemStyle-Width="220">
                                                            <ItemTemplate>
                                                                <%# Eval("ApplicantName") + "<br />" + Eval("Gender")+ "<br />"+"PH : "+ Eval("PhysicallyChallenged") %>
                                                                <asp:Button ID="btnDispPH" Visible="false" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnDispPH_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("PhysicallyChallenged") %>' />
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="RD Number" ItemStyle-Width="220">
                                                            <ItemTemplate>
                                                                <%# "RD Number: " + Eval("RDNumber")+ "<br />" + " Aadhar: " + Eval("AadharNum")%>
                                                                <%--<%# Eval("RDNumber") %>--%><%--<asp:HyperLink ID="lblProductName" runat="server" Text='<%# Eval("RDNumber") %>' NavigateUrl="#" Target="_blank"  ></asp:HyperLink>--%>
                                                                <asp:Button ID="btnCasteIncome" Visible="false" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnCasteIncome_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5; padding: 1px" Text='<%# Eval("RDNumber") %>' ToolTip="Caste and Incone Certificate" />
                                                                <asp:Button ID="btnDispAadhar" Visible="false" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnDispAadhar_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("AadharNum") %>' ToolTip="Aadhar" />
                                                                <%--<asp:Button ID="HyperLink1" OnClick="ArivugvDMApprove_RowCommand" OnClientClick="aspnetForm.target ='_blank';" runat="server" Text='<%# Eval("RDNumber") %>' CommandArgument="<%# Container.DataItemIndex %>" ></asp:Button>--%><%--<asp:HyperLink  CommandName="PathUpdate" runat="server" Text='<%# Eval("RDNumber")+"abc" %>' Target="_blank" />--%>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="160px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Anual Income &amp; DOB" ItemStyle-Width="220">
                                                            <ItemTemplate>
                                                                <%# Eval("AnualIncome") + "<br />" + Eval("DoB")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="160px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="EmailID &amp; Mobile Number" ItemStyle-Width="220">
                                                            <ItemTemplate>
                                                                <%#"Email ID: " + Eval("EmailID") + "<br />" + " Mobile Number: " + Eval("MobileNumber")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="180px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Address" ItemStyle-Width="220">
                                                            <ItemTemplate>
                                                                <%# Eval("ParmanentAddress") + "<br />" + Eval("ParDistrict")+"(D)"+ "<br />" + Eval("ParTaluk")+"(T)"+ "<br />" + Eval("ParConstituency")+"(C)"+ "<br />" + Eval("ParPincode")+"(P)"%>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="260px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Bank Details" ItemStyle-Width="220">
                                                            <ItemTemplate>
                                                                <%# "A/C No: " + Eval("AccountNumber")+ "<br />"%>
                                                                <asp:Button ID="btnDispPassbook" Visible="false" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnDispPassbook_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("AccountNumber") %>' />
                                                                <%# "Bank: " + Eval("BankName")+ "<br />" + " Branch: " + Eval("Branch")+ "<br />" + " IFSCCode: " + Eval("IFSCCode")+ "<br />" + " Address: " + Eval("BankAddress")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="260px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="College Details" ItemStyle-Width="220">
                                                            <ItemTemplate>
                                                                <%# "CET Ticate: "+Eval("CETAdmissionTicateNum")%>
                                                                <asp:Button ID="btnDispCET" Visible="false" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnDispCET_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("CETAdmissionTicateNum") %>' ToolTip="CET Admission Ticate" />
                                                                <%# "<br />"+" Year: " + Eval("CurrentYear") + "<br />" + " Course: " + Eval("Course")+ "<br />" + " College: " + Eval("CollegeName")+ "<br />" + " Prev Year Marks: " + Eval("PrevYearMarks")+ "<br />" + " Address: " + Eval("CollegeAddress")%><%# "<br />" %>
                                                                <asp:Button ID="btnFeeStruct" Visible="false" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnFeeStruct_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# "Fee Structure" %>' ToolTip="Study Certificate" />
                                                                <%# " " %>
                                                                <asp:Button ID="btnDispClgHostel" runat="server" Visible="false" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnDispClgHostel_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# "Hostel: "+Eval("ClgHostel") %>' ToolTip="Study Certificate" />
                                                                <%# " " %>
                                                                <asp:Button ID="btnStudyCertificate" runat="server" Visible="false" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnStudyCertificate_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# "Study Cert" %>' ToolTip="Study Certificate" />
                                                                <%# " " %>
                                                                <asp:Button ID="btnMarksCard" Visible="false" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnMarksCard_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# "Marks Card" %>' ToolTip="Study Certificate" />
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="CW Status" ItemStyle-Width="50">
                                                            <ItemTemplate>
                                                                <%# "Status: " +Eval("CWApprove") + "<br />" + "Reason: " + Eval("RejectReason") %>
                                                            </ItemTemplate>

                                                            <EditItemTemplate>
                                                                <asp:Label ID="lbl" runat="server" Text="Press Control(Ctrl) to select multiple Reason"></asp:Label>
                                                                <asp:ListBox ID="drpArivuRejectReasonDM" SelectionMode="Multiple" runat="server" Height="100px" Width="250px">
                                                                    <asp:ListItem>Caste and Income Not in Form G</asp:ListItem>
                                                                    <asp:ListItem>Income Mentioned not as per Form G</asp:ListItem>
                                                                    <asp:ListItem>DOB Not Matching</asp:ListItem>
                                                                    <asp:ListItem>Photo Not Matching With Aadhar</asp:ListItem>
                                                                    <asp:ListItem>RD Number Wrongly Entered</asp:ListItem>
                                                                    <asp:ListItem>Account Details Not Matching</asp:ListItem>
                                                                    <asp:ListItem>No Attestation By Principal</asp:ListItem>
                                                                    <asp:ListItem>Wrong CET Admission ticket Number</asp:ListItem>
                                                                    <asp:ListItem>Wrong mark's Entered</asp:ListItem>
                                                                    <asp:ListItem>Address not Mentioned as per Caste and Income</asp:ListItem>
                                                                    <asp:ListItem>Multiple application from a family</asp:ListItem>
                                                                    <asp:ListItem>Documents Not Submitted</asp:ListItem>
                                                                </asp:ListBox>
                                                                <%-- <asp:TextBox ID="txt1Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="1st Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:TextBox ID="txt2Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="2nd Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:TextBox ID="txt3Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="3rd Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:TextBox ID="txt4Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="4th Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:TextBox ID="txt5Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="5th Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:DropDownList ID="drpQuota" Class="rowMargin txtcolor text-uppercase rowMargin txtcolor text-uppercase form-control" runat="server" ClientIDMode="Static">
                                         <asp:ListItem>--SELECT--</asp:ListItem>
                                         <asp:ListItem Value="General"> General</asp:ListItem>
                                         <asp:ListItem Value="Adyakshara">Adyakshara</asp:ListItem>
                                         <asp:ListItem Value="Government">Government</asp:ListItem>
                                     </asp:DropDownList>--%>
                                                            </EditItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="220px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Eligible" ItemStyle-Width="220">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnArivuDMApprovee" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnArivuDMApprovee_Click" ShowHeader="True" Text="Eligible" />
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Ineligible" ItemStyle-Width="120" HeaderStyle-CssClass="text-center text-center font-weight-bold">
                                                            <ItemTemplate>
                                                                <asp:LinkButton Text="Ineligible" class="btn btn-hover btnModcolor" runat="server" CommandName="Edit" />
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:LinkButton  ID="OnUpdateArivuDM" Text="Ineligible" runat="server" class="btn btn-hover btnModcolor" OnClick="OnUpdateArivuDM_Click" OnClientClick="return Validate(this)" />
                                                                <asp:LinkButton ID="btnCancelArivuDM" Text="Cancel" runat="server" class="btn btn-hover btnSubcolor" OnClick="btnCancelArivuDM_Click" />
                                                            </EditItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle Width="90px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:Button ID="btnExportArivu" runat="server" Text="Export" class="btn btn-hover btnSubcolor" Width="15%" OnClick="btnExportArivu_Click" />

                                    <br />
                                    <div id="divArivuReport" runat="server" visible="false">
                                        <rsweb:ReportViewer ID="rvDMReportArivu" runat="server" DocumentMapWidth="100%" ShowBackButton="False" ShowDocumentMapButton="False" ShowExportControls="False" ShowRefreshButton="False" ShowZoomControl="False" Width="100%"></rsweb:ReportViewer>
                                    </div>

                                </div>
                            </div>
                            <div id="menu11" class="tab-pane fade">

                                <div>
                                    <div id="divCEOArivuApprovedDoc">
                                        <asp:FileUpload ID="FileCeoArivu" runat="server" />
                                        <asp:Button ID="btnArivuUploadCeoDoc" runat="server" class="btn btn-hover btnSubcolor" Width="15%" OnClick="btnArivuUploadCeoDoc_Click" Text="Upload CEO Cocument" />
                                        <asp:Label ID="lblID" Text="FIle ID: " runat="server"></asp:Label>
                                        <asp:Label ID="lblFileID" runat="server"></asp:Label>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <div id="divCEOgv" runat="server" class="text-sm-center">
                                                <asp:GridView ID="ArivugvDMCEO" runat="server" class="GridView" OnRowCancelingEdit="ArivugvDMCEO_RowCancelingEdit" OnRowUpdating="btnArivuDMCEOApprove_Click" OnRowEditing="ArivugvDMCEO_RowEditing" AutoGenerateColumns="False" DataKeyNames="ApplicationNumber,ApplicantName">
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                                                            <ItemTemplate>
                                                                <%# Eval("ApplicationNumber")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="220px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Applicant Name" ItemStyle-Width="220">
                                                            <ItemTemplate>
                                                                <%# Eval("ApplicantName")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle Width="220px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Status" ItemStyle-Width="50">
                                                            <ItemTemplate>
                                                                <%# Eval("ApplicationStatus")%>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txt1Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="1st Year Loan" TextMode="Number" MaxLength="6" onkeypress="return numeric(event)" />
                                                                <asp:TextBox ID="txt2Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="2nd Year Loan" TextMode="Number" MaxLength="6" onkeypress="return numeric(event)"/>
                                                                <asp:TextBox ID="txt3Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="3rd Year Loan" TextMode="Number" MaxLength="6" onkeypress="return numeric(event)"/>
                                                                <asp:TextBox ID="txt4Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="4th Year Loan" TextMode="Number" MaxLength="6" onkeypress="return numeric(event)"/>
                                                                <asp:TextBox ID="txt5Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="5th Year Loan" TextMode="Number" MaxLength="6" onkeypress="return numeric(event)" />
                                                                <asp:DropDownList ID="drpQuota" Class="rowMargin txtcolor text-uppercase rowMargin txtcolor text-uppercase form-control" runat="server" ClientIDMode="Static">
                                                                    <asp:ListItem>--SELECT--</asp:ListItem>
                                                                    <asp:ListItem Value="ActionPlan">Action Plan</asp:ListItem>
                                                                    <asp:ListItem Value="Adyakshara">Adyakshara VK</asp:ListItem>
                                                                    <asp:ListItem Value="Government">Government VK</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </EditItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle Width="220px" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Reject" ItemStyle-Width="220">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnArivuDMCEOReject" class="btn btn-hover btnSubcolor" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnArivuDMCEOReject_Click" ShowHeader="True" Text="Reject" />
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle Width="220px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Waiting" ItemStyle-Width="220">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnArivuDMCEOWaiting" class="btn btn-hover btnSubcolor" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnArivuDMCEOWaiting_Click" ShowHeader="True" Text="Waiting" />
                                                                </ItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle Width="220px" />
                                                        </asp:TemplateField>
                                                        <asp:CommandField ButtonType="Button" EditText="ApproveLoan" ShowEditButton="True" />
                                                    </Columns>
                                                </asp:GridView>
                                                <br />
                                                <h2>Waiting List</h2>
                                                <br />
                                                <asp:GridView ID="ArivugvDMCEOWaiting" class="GridView" runat="server" OnRowCancelingEdit="ArivugvDMCEOWaiting_RowCancelingEdit" OnRowUpdating="ArivugvDMCEOWaiting_RowUpdating" OnRowEditing="ArivugvDMCEOWaiting_RowEditing" AutoGenerateColumns="False" DataKeyNames="ApplicationNumber,ApplicantName">
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                                                            <ItemTemplate>
                                                                <%# Eval("ApplicationNumber")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="220px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Applicant Name" ItemStyle-Width="220">
                                                            <ItemTemplate>
                                                                <%# Eval("ApplicantName")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle Width="220px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Status" ItemStyle-Width="50">
                                                            <ItemTemplate>
                                                                <%# Eval("ApplicationStatus")%>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txt1Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="1st Year Loan" TextMode="Number" MaxLength="6" onkeypress="return numeric(event)"/>
                                                                <asp:TextBox ID="txt2Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="2nd Year Loan" TextMode="Number" MaxLength="6" onkeypress="return numeric(event)"/>
                                                                <asp:TextBox ID="txt3Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="3rd Year Loan" TextMode="Number" MaxLength="6" onkeypress="return numeric(event)"/>
                                                                <asp:TextBox ID="txt4Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="4th Year Loan" TextMode="Number" MaxLength="6" onkeypress="return numeric(event)"/>
                                                                <asp:TextBox ID="txt5Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="5th Year Loan" TextMode="Number" MaxLength="6" onkeypress="return numeric(event)"/>
                                                                <asp:DropDownList ID="drpQuota" Class="rowMargin txtcolor text-uppercase rowMargin txtcolor text-uppercase form-control" runat="server" ClientIDMode="Static">
                                                                    <asp:ListItem>--SELECT--</asp:ListItem>
                                                                    <asp:ListItem Value="ActionPlan"> ActionPlan</asp:ListItem>
                                                                    <asp:ListItem Value="Adyakshara">Adyakshara VK</asp:ListItem>
                                                                    <asp:ListItem Value="Government">Government VK</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </EditItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle Width="220px" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Reject" ItemStyle-Width="220">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnArivuDMCEOWaitingReject" class="btn btn-hover btnSubcolor" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnArivuDMCEOWaitingReject_Click" ShowHeader="True" Text="Reject" />
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle Width="220px" />
                                                        </asp:TemplateField>
                                                        <asp:CommandField ButtonType="Button" EditText="ApproveLoan" ShowEditButton="True" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            <asp:Panel ID="PnlDMARCEOReason" runat="server" CssClass="modalPopup" Width="650px" Height="380px" Style="display: none">
                                            <div style="text-align: center; font-size: 25px; letter-spacing: 2px;">
                                                <asp:Label Font-Bold="true" ID="Label24" runat="server" CssClass="form-row-label" Style="text-align: center" Text="Reason"></asp:Label>
                                            </div>
                                            <br />
                                            <div class="">
                                                <div class="flex-row">
                                                    <div class="form-row">
                                                        <div class="form-row-label">
                                                            <asp:Label ID="Label25" runat="server" Text="Application Number"></asp:Label>
                                                        </div>
                                                        <div class="form-row-input">
                                                            <asp:Label ID="lblARCEORejApplicationNumber" Width="40px" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="form-row-label">
                                                            <asp:Label ID="Label26" runat="server" Text="Applicant Name"></asp:Label>
                                                        </div>
                                                        <div class="form-row-input">
                                                            <asp:Label ID="lblARCEORejApplicationName" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="form-row-label">
                                                            <asp:Label ID="Label27" runat="server" Text="Reason"></asp:Label>
                                                        </div>
                                                        <div class="form-row-input">
                                                            <asp:TextBox ID="txtARCEORejectReason" CssClass="PopupTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                            <asp:Label runat="server" ID="lblARCEORejectError" Style="color: red; font-size: 13px"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="form-row-label">
                                                            <asp:Button ID="btnARCEORejectUpdate" runat="server" CssClass="Button" Text="Save" OnClick="btnARCEORejectUpdate_Click" />
                                                        </div>
                                                        <div class="form-row-input">
                                                            <asp:Button ID="Button3" runat="server" CssClass="Button" Text="Cancel" OnClientClick="return ARCEOHidepopup()" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel ID="PnlDMARCEOWaitingReason" runat="server" CssClass="modalPopup" Width="650px" Height="380px" Style="display: none">
                                            <div style="text-align: center; font-size: 25px; letter-spacing: 2px;">
                                                <asp:Label Font-Bold="true" ID="Label28" runat="server" CssClass="form-row-label" Style="text-align: center" Text="Reason"></asp:Label>
                                            </div>
                                            <div class="">
                                                <div class="flex-row">
                                                    <div class="form-row">
                                                        <div class="form-row-label">
                                                            <asp:Label ID="Label29" runat="server" Text="Application Number"></asp:Label>
                                                        </div>
                                                        <div class="form-row-input">
                                                            <asp:Label ID="lblARCEOWaitingRejApplicationNumber" Width="40px" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="form-row-label">
                                                            <asp:Label ID="Label30" runat="server" Text="Applicant Name"></asp:Label>
                                                        </div>
                                                        <div class="form-row-input">
                                                            <asp:Label ID="lblARCEOWaitingRejApplicationName" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="form-row-label">
                                                            <asp:Label ID="Label31" runat="server" Text="Reason"></asp:Label>
                                                        </div>
                                                        <div class="form-row-input">
                                                            <asp:TextBox ID="txtARCEOWaitingRejectReason" CssClass="PopupTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                            <asp:Label runat="server" ID="lblARCEOWaitingRejectError" Style="color: red; font-size: 13px"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="form-row-label">
                                                            <asp:Button ID="btnARCEOWaitingRejectUpdate" runat="server" CssClass="Button" Text="Save" OnClick="btnARCEOWaitingRejectUpdate_Click" />
                                                        </div>
                                                        <div class="form-row-input">
                                                            <asp:Button ID="Button4" runat="server" CssClass="Button" Text="Cancel" OnClientClick="return ARCEOWaitingHidepopup()" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                    <asp:LinkButton ID="lnkDMARCEOSEFake" runat="server"></asp:LinkButton>
                                    <asp:LinkButton ID="lnkDMARCEOWaitingSEFake" runat="server"></asp:LinkButton>
                                        <cc1:ModalPopupExtender ID="DMARCEORejectPopup" runat="server" DropShadow="false"
                                            PopupControlID="PnlDMARCEOReason" TargetControlID="lnkDMARCEOSEFake"
                                            BackgroundCssClass="modalBackground">
                                        </cc1:ModalPopupExtender>
                                        <cc1:ModalPopupExtender ID="DMARCEOWaitingRejectPopup" runat="server" DropShadow="false"
                                            PopupControlID="PnlDMARCEOWaitingReason" TargetControlID="lnkDMARCEOWaitingSEFake"
                                            BackgroundCssClass="modalBackground">
                                        </cc1:ModalPopupExtender>
                                        </ContentTemplate>
                                        <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ArivugvDMCEO" />
                                        <asp:AsyncPostBackTrigger ControlID="btnARCEORejectUpdate" />
                                        <asp:AsyncPostBackTrigger ControlID="ArivugvDMCEOWaiting" />
                                        <asp:AsyncPostBackTrigger ControlID="btnARCEOWaitingRejectUpdate" />
                                    </Triggers>
                                    </asp:UpdatePanel>
                                    <div id="divArivuCEOPrinting">
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                        <ContentTemplate>
                                            <h2>Approved List</h2>
                                            <asp:GridView ID="ArivugvDMCEOApprovedList" class="GridView" runat="server" AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:BoundField ItemStyle-Width="200px" DataField="ApplicationNumber" HeaderText="Application Number" />
                                                    <asp:BoundField ItemStyle-Width="150px" DataField="ApplicantName" HeaderText="Applicant Name " />
                                                    <asp:BoundField ItemStyle-Width="150px" DataField="Quota" HeaderText="Quota" />
                                                    <asp:BoundField ItemStyle-Width="200px" DataField="LoanAmount" HeaderText="Loan Amount" />
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div style="align-items: center">
                                        <asp:Button ID="btnArivuPrintCEOApproved" runat="server" class="Button" Text="Print" Width="20%" OnClick="btnArivuPrintCEOApproved_Click" />
                                    </div>
                                    <br />
                                    <br />

                                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                        <ContentTemplate>
                                            <h2>Waiting List</h2>
                                            <asp:GridView ID="ArivugvDMCEOWaitingList" class="GridView" runat="server" AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:BoundField ItemStyle-Width="200px" DataField="ApplicationNumber" HeaderText="Application Number" />
                                                    <asp:BoundField ItemStyle-Width="100px" DataField="ApplicantName" HeaderText="Applicant Name " />
                                                    <asp:BoundField ItemStyle-Width="50px" DataField="MobileNumber" HeaderText="Mobile Number" />
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div style="align-items: center">
                                        <asp:Button ID="btnArivuPrintCEOWaiting" runat="server" class="Button" Text="Print" Width="20%" OnClick="btnArivuPrintCEOWaiting_Click" />
                                    </div>
                                    <br />
                                    <br />

                                    <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                        <ContentTemplate>
                                            <h2>Rejected List</h2>
                                            <asp:GridView ID="ArivugvDMCEORejectedList" class="GridView" runat="server" AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:BoundField ItemStyle-Width="200px" DataField="ApplicationNumber" HeaderText="Application Number" />
                                                    <asp:BoundField ItemStyle-Width="100px" DataField="ApplicantName" HeaderText="Applicant Name " />
                                                    <asp:BoundField ItemStyle-Width="50px" DataField="MobileNumber" HeaderText="Mobile Number" />
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div style="align-items: center">
                                        <asp:Button ID="btnArivuPrintCEORejected" runat="server" class="Button" Text="Print" Width="20%" OnClick="btnArivuPrintCEORejected_Click" />
                                    </div>
                                </div>
                                </div>

                            </div>
                            <div id="menu21" class="tab-pane fade">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <div>
                                            <%--<div id="divRejectDOCArivu" runat="server" visible="false">
                                            <asp:ListBox ID="drpRejectDOCArivu" Style="width: 35px" SelectionMode="Multiple" runat="server" DataSourceID="SqlArRejectDoc" DataTextField="Reason" DataValueField="Reason" Height="45px" Width="193px"></asp:ListBox>
                                            <asp:Button ID="btnRejectDOCArivu" runat="server" Text="Reject Application" OnClick="btnRejectDOCArivu_Click" />
                                            <asp:SqlDataSource ID="SqlArRejectDoc" runat="server" ConnectionString="<%$ ConnectionStrings:KACDCConnectionString %>" SelectCommand="SELECT * FROM [RejectReason]"></asp:SqlDataSource>
                                        </div>--%>
                                            <div id="divDocArivu" runat="server" class="text-sm-center">

                                                <div id="divUpdateBankAR" style="margin-bottom: 10px">
                                                    <div class="container-fluid">
                                                        <div class="container">
                                                            <div class="formBox">
                                                                <div class="row" style="background-color: rgba(0,0,0,0.05); margin-top: -15px">
                                                                    <div class="col-sm-12">
                                                                        <h2 style="margin-top: 8px">Update Bank Details</h2>
                                                                        <h5 style="float: left; width: 50%">Applicantion Number :
                                                                                <asp:Label runat="server" ID="lblApplicationNumberAR" Text=""></asp:Label></h5>

                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-sm-4">
                                                                        <div class="">
                                                                            <div>
                                                                                <div class="InputBox">
                                                                                    <asp:TextBox class="input" runat="server" ID="txtApplicantNameAR" CausesValidation="false"></asp:TextBox>
                                                                                    <label runat="server" id="Label6" text="Phy Num">Applicant Name</label>
                                                                                </div>
                                                                                <div class="InputBox">
                                                                                    <asp:TextBox class="input" runat="server" ID="txtAccountNumberAR" CausesValidation="false" onkeypress="return numeric(event)"></asp:TextBox>

                                                                                    <label class="Label" runat="server" id="Label7" text="Phy abc">Account Number</label>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <div class="col-sm-4">
                                                                        <div class="">
                                                                            <div>
                                                                                <div class="InputBox">
                                                                                    <asp:TextBox class="input" runat="server" ID="txtBankNameAR" CausesValidation="false"></asp:TextBox>
                                                                                    <label runat="server" id="Label8" text="Phy Num">Bank</label>
                                                                                </div>
                                                                                <div class="InputBox">
                                                                                    <asp:TextBox class="input" runat="server" ID="txtBranchAR"></asp:TextBox>
                                                                                    <label runat="server" id="Label9" text="Phy Num">Branch</label>
                                                                                </div>

                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <div class="">
                                                                            <div>
                                                                                <div class="InputBox">
                                                                                    <asp:TextBox class="input" runat="server" ID="txtIFSCCodeAR"></asp:TextBox>
                                                                                    <label runat="server" id="Label10" text="Phy Num">IFSC Code</label>
                                                                                </div>
                                                                                <div class="InputBox">
                                                                                    <asp:TextBox class="input" runat="server" ID="txtBankAddrAR"></asp:TextBox>
                                                                                    <label class="Label" runat="server" id="Label11" text="Phy abc">Bank Address</label>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="row" style="margin-top: -25px">
                                                                    <div class="col-sm-4">
                                                                        <div class="InputBox">
                                                                            <asp:DropDownList ID="drpARReasonBankModify" runat="server" class="dropdown">
                                                                                <asp:ListItem Value="" >--SELECE REASON--</asp:ListItem>
                                                                                <asp:ListItem Value="Jandhan Account">Jandhan Account</asp:ListItem>
                                                                                <asp:ListItem Value="Invalid IFSC Code">Wrong IFSC Code</asp:ListItem>
                                                                                <asp:ListItem Value="Invalid A/C Number">Invalid A/C Number</asp:ListItem>
                                                                                <asp:ListItem Value="Invalid Branch">Invalid Branch</asp:ListItem>
                                                                                <asp:ListItem Value="Invalid Bank">Invalid Bank</asp:ListItem>
                                                                                <asp:ListItem Value="Invalid Address">Invalid Address</asp:ListItem>
                                                                                <asp:ListItem Value="Invalid Name">Invalid Name</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <div >
                                                                            <asp:Button ID="btnUpdateBankAR" class="Button" runat="server" OnClick="btnUpdateBankAR_Click" Style="margin-left: 40%;" Text="Update Details" CausesValidation="false" />
                                                                    </div></div>
                                                                    <div class="col-sm-4">
                                                                            <asp:Button ID="btnClearAR" class="Button" runat="server" Text="Cancel / Clear" OnClick="btnClearAR_Click" CausesValidation="false" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <asp:GridView ID="ArivugvDMDoc" runat="server" class="GridView" AutoGenerateColumns="False" DataKeyNames="ApplicationNumber,ApplicantName">
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                                                            <ItemTemplate>
                                                                <%# Eval("ApplicationNumber")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="220px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Applicant Name" ItemStyle-Width="220">
                                                            <ItemTemplate>
                                                                <%# Eval("ApplicantName")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle Width="220px" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Quota" ItemStyle-Width="220">
                                                            <ItemTemplate>
                                                                <%# Eval("Quota")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle Width="220px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Bank Details" ItemStyle-Width="220">
                                                            <ItemTemplate>
                                                                <%# "A/C No: " + Eval("AccountNumber")+ "<br />"%>
                                                                <asp:Button ID="btnDispPassbook" Visible="false" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnDispPassbook_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("AccountNumber") %>' />
                                                                <%# "Bank: " + Eval("BankName")+ "<br />" + " Branch: " + Eval("Branch")+ "<br />" + " IFSCCode: " + Eval("IFSCCode")+ "<br />" + " Address: " + Eval("BankAddress")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="260px" />
                                                        </asp:TemplateField>
                                                        <%--   <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Download Documents" ItemStyle-Width="220">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnArivuDocDownload" class="btn btn-hover btnSubcolor" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnArivuDocDownload_Click" ShowHeader="True" Text="Download" />
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle Width="220px" />
                                                        </asp:TemplateField>--%>

                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Accept" ItemStyle-Width="220">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnArivuDocAccept" class="btn btn-hover btnSubcolor" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnArivuDocAccept_Click" ShowHeader="True" Text="Document Verified" />
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle Width="220px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Reject" ItemStyle-Width="220">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnArivuDocReject" runat="server" class="btn btn-hover btnModcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnArivuDocReject_Click" ShowHeader="True" Text="Reject" />
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle Width="220px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Update" ItemStyle-Width="50">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnGVUpdateBankAR" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnGVUpdateBankAR_Click" CausesValidation="false" ShowHeader="True" Text='<%# Eval("REASON") %>' />
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                            </EditItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle Width="220px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                <br />
                                                <br />
                                            </div>
                                            <div id="ARDMDocInfoHidden" visible="false">
                                                    <asp:GridView ID="ARDMDocPrintApprove" Visible="false" runat="server" AutoGenerateColumns="False">
                                                        <Columns>
                                                            <asp:BoundField ItemStyle-Width="200px" DataField="ApplicationNumber" HeaderText="Application Number" />
                                                            <asp:BoundField ItemStyle-Width="100px" DataField="ApplicantName" HeaderText="Applicant Name " />
                                                            <asp:BoundField ItemStyle-Width="50px" DataField="Quota" HeaderText="Quota" />
                                                            <asp:BoundField ItemStyle-Width="200px" DataField="ApprovedApplicationNum" HeaderText="Loan Number" />
                                                        </Columns>
                                                    </asp:GridView>
                                                    <asp:GridView ID="ARDMDocPrintWaiting" Visible="false" runat="server" AutoGenerateColumns="False">
                                                        <Columns>
                                                            <asp:BoundField ItemStyle-Width="200px" DataField="ApplicationNumber" HeaderText="Application Number" />
                                                            <asp:BoundField ItemStyle-Width="100px" DataField="ApplicantName" HeaderText="Applicant Name " />
                                                            <asp:BoundField ItemStyle-Width="50px" DataField="Quota" HeaderText="Quota" />
                                                            <asp:BoundField ItemStyle-Width="200px" DataField="ApprovedApplicationNum" HeaderText="Loan Number" />
                                                        </Columns>
                                                    </asp:GridView>
                                                    <asp:GridView ID="ARDMDocPrintReject" Visible="false" runat="server" AutoGenerateColumns="False">
                                                        <Columns>
                                                            <asp:BoundField ItemStyle-Width="200px" DataField="ApplicationNumber" HeaderText="Application Number" />
                                                            <asp:BoundField ItemStyle-Width="100px" DataField="ApplicantName" HeaderText="Applicant Name " />
                                                            <asp:BoundField ItemStyle-Width="50px" DataField="Quota" HeaderText="Quota" />
                                                            <asp:BoundField ItemStyle-Width="200px" DataField="ApprovedApplicationNum" HeaderText="Loan Number" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                        </div>
                                        <asp:Panel ID="PnlDMARDocReason" runat="server" CssClass="modalPopup" Width="650px" Height="380px" Style="display: none">
                                            <div style="text-align: center; font-size: 25px; letter-spacing: 2px;">
                                                <asp:Label Font-Bold="true" ID="Label32" runat="server" CssClass="form-row-label" Style="text-align: center" Text="Reason"></asp:Label>
                                            </div>
                                            <div class="">
                                                <div class="flex-row">
                                                    <div class="form-row">
                                                        <div class="form-row-label">
                                                            <asp:Label ID="Label33" runat="server" Text="Application Number"></asp:Label>
                                                        </div>
                                                        <div class="form-row-input">
                                                            <asp:Label ID="lblARDocRejApplicationNumber" Width="40px" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="form-row-label">
                                                            <asp:Label ID="Label34" runat="server" Text="Applicant Name"></asp:Label>
                                                        </div>
                                                        <div class="form-row-input">
                                                            <asp:Label ID="lblARDocRejApplicationName" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="form-row-label">
                                                            <asp:Label ID="Label35" runat="server" Text="Reason"></asp:Label>
                                                        </div>
                                                        <div class="form-row-input">
                                                            <asp:TextBox ID="txtARDocRejectReason" CssClass="PopupTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                            <asp:Label runat="server" ID="lblARDocRejectError" Style="color: red; font-size: 13px"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="form-row-label">
                                                            <asp:Button ID="btnARDocRejectUpdate" runat="server" CssClass="Button" Text="Save" OnClick="btnARDocRejectUpdate_Click" />
                                                        </div>
                                                        <div class="form-row-input">
                                                            <asp:Button ID="Button5" runat="server" CssClass="Button" Text="Cancel" OnClientClick="return ARDocHidepopup()" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <asp:LinkButton ID="lnkARDMDocSEFake" runat="server"></asp:LinkButton>
                                        <cc1:ModalPopupExtender ID="DMARDocRejectPopup" runat="server" DropShadow="false"
                                            PopupControlID="PnlDMARDocReason" TargetControlID="lnkARDMDocSEFake"
                                            BackgroundCssClass="modalBackground">
                                        </cc1:ModalPopupExtender>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ArivugvDMDoc" />
                                        <asp:AsyncPostBackTrigger ControlID="btnARDocRejectUpdate" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                 <div style="align-items: center">
                                <asp:Button ID="btnArivuSubmitZM" runat="server" class="Button" Text="Submit to ZM" Width="20%" OnClick="btnArivuSubmitZM_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
                                <asp:Label ID="lblArivuZMSubmitStatus" style="font-weight:bold" runat="server"></asp:Label>
                                 </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="menu1" class="tab-pane fade">
                    <ul class="nav nav-tabs">
                        <li class="active"><a data-toggle="tab" href="#home2">District Manager</a></li>
                        <li><a data-toggle="tab" href="#menu12">CEO Committee</a></li>
                        <li><a data-toggle="tab" href="#menu22">Document Verification</a></li>
                    </ul>

                    <div class="tab-content">
                        <div id="home2" class="tab-pane fade in active">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="text-center">
                                        <asp:GridView ID="SEDMApprove" runat="server" class="GridView" AutoGenerateColumns="False" OnRowEditing="SEDMApprove_RowEditing" DataKeyNames="ApplicationNumber,RDNumber,AadharNum" Style="align-content: center; margin-left: 5px">
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                                                    <ItemTemplate>
                                                        <%# Eval("ApplicationNumber")%>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtSEDMAppNum" runat="server" Text='<%# Eval("ApplicationNumber") %>' Enabled="false" />
                                                    </EditItemTemplate>
                                                    <HeaderStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="220px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Applicant Name" ItemStyle-Width="220">
                                                    <ItemTemplate>
                                                        <%# Eval("ApplicantName") + "<br />" + Eval("Gender")+ "<br />"+"PH : "+ Eval("PhysicallyChallenged") %>
                                                        <asp:Button ID="btnSEDispPH" Visible="false" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnSEDispPH_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("PhysicallyChallenged") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="220px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="RD Number" ItemStyle-Width="220">
                                                    <ItemTemplate>
                                                        <%# "RD Number: " + Eval("RDNumber")+ "<br />" + " Aadhar: " + Eval("AadharNum")%>
                                                        <%--<%# Eval("RDNumber") %>--%><%--<asp:HyperLink ID="lblProductName" runat="server" Text='<%# Eval("RDNumber") %>' NavigateUrl="#" Target="_blank"  ></asp:HyperLink>--%>
                                                        <asp:Button ID="btnSECasteIncome" Visible="false" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnSECasteIncome_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5; padding: 1px" Text='<%# Eval("RDNumber") %>' ToolTip="Caste and Incone Certificate" />
                                                        <asp:Button ID="btnSEDispAadhar" runat="server" Visible="false" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnSEDispAadhar_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("AadharNum") %>' ToolTip="Aadhar" />
                                                        <%--<asp:Button ID="HyperLink1" OnClick="ArivugvDMApprove_RowCommand" OnClientClick="aspnetForm.target ='_blank';" runat="server" Text='<%# Eval("RDNumber") %>' CommandArgument="<%# Container.DataItemIndex %>" ></asp:Button>--%><%--<asp:HyperLink  CommandName="PathUpdate" runat="server" Text='<%# Eval("RDNumber")+"abc" %>' Target="_blank" />--%>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="220px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Anual Income &amp; DOB" ItemStyle-Width="220">
                                                    <ItemTemplate>
                                                        <%# Eval("AnualIncome") + "<br />" + Eval("DoB")%>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="220px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="EmailID &amp; Mobile Number" ItemStyle-Width="220">
                                                    <ItemTemplate>
                                                        <%#"Email ID: " + Eval("EmailID") + "<br />" + " Mobile Number: " + Eval("MobileNumber")%>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="220px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Address" ItemStyle-Width="220">
                                                    <ItemTemplate>
                                                        <%# Eval("ParmanentAddress") + "<br />" + Eval("ParDistrict")+"(D)"+ "<br />" + Eval("ParConstituency")+"(T)"+ "<br />" + Eval("ParConstituency")+"(C)"+ "<br />" + Eval("ParPincode")+"(P)"%>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="260px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Bank Details" ItemStyle-Width="220">
                                                    <ItemTemplate>
                                                        <%# "A/C No: " + Eval("AccountNumber")+ "<br />"%>
                                                        <asp:Button ID="btnSEDispPassbook" Visible="false" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnSEDispPassbook_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("AccountNumber") %>' />
                                                        <%# "Bank: " + Eval("BankName")+ "<br />" + " Branch: " + Eval("Branch")+ "<br />" + " IFSCCode: " + Eval("IFSCCode")+ "<br />" + " Address: " + Eval("BankAddress")%>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Status" ItemStyle-Width="50">
                                                    <ItemTemplate>
                                                        <%# "Status: " +Eval("CWApprove") + "<br />" + "Reason: " + Eval("RejectReason") %>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lbl" runat="server" Text="Press Control(Ctrl) to select multiple Reason"></asp:Label>
                                                        <asp:ListBox ID="drpSEDMRejectReason" SelectionMode="Multiple" runat="server" Height="100px" Width="250px">
                                                            <asp:ListItem>Caste and Income Not in Form G</asp:ListItem>
                                                            <asp:ListItem>Income Mentioned not as per Form G</asp:ListItem>
                                                            <asp:ListItem>DOB Not Matching</asp:ListItem>
                                                            <asp:ListItem>Photo Not Matching With Aadhar</asp:ListItem>
                                                            <asp:ListItem>RD Number Wrongly Entered</asp:ListItem>
                                                            <asp:ListItem>Account Details Not Matching</asp:ListItem>
                                                            <asp:ListItem>Address not Mentioned as per Caste and Income</asp:ListItem>
                                                            <asp:ListItem>Multiple application from a family</asp:ListItem>
                                                            <asp:ListItem>Documents Not Submitted</asp:ListItem>
                                                        </asp:ListBox>
                                                        <%--   <asp:TextBox ID="txt1Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="1st Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:TextBox ID="txt2Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="2nd Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:TextBox ID="txt3Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="3rd Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:TextBox ID="txt4Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="4th Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:TextBox ID="txt5Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="5th Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:DropDownList ID="drpQuota" Class="rowMargin txtcolor text-uppercase rowMargin txtcolor text-uppercase form-control" runat="server" ClientIDMode="Static">
                                         <asp:ListItem>--SELECT--</asp:ListItem>
                                         <asp:ListItem Value="General"> General</asp:ListItem>
                                         <asp:ListItem Value="Adyakshara">Adyakshara</asp:ListItem>
                                         <asp:ListItem Value="Government">Government</asp:ListItem>
                                     </asp:DropDownList>--%>
                                                    </EditItemTemplate>
                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="220px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Approve" ItemStyle-Width="220">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnSEDMApprovee" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnSEDMApprovee_Click" ShowHeader="True" Text="Eligible" />
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ineligible" ItemStyle-Width="120" HeaderStyle-CssClass="text-center text-center font-weight-bold">
                                                    <ItemTemplate>
                                                        <asp:LinkButton Text="Ineligible" class="btn btn-hover btnModcolor" runat="server" CommandName="Edit" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:LinkButton Text="Ineligible" class="btn btn-hover btnModcolor" runat="server" ID="OnUpdateSEDM" OnClick="OnUpdateSEDM_Click" OnClientClick="return Validate(this)" />
                                                        <asp:LinkButton ID="btnCancelSEDM" class="btn btn-hover btnSubcolor" Text="Cancel" runat="server" OnClick="btnCancelSEDM_Click" />
                                                    </EditItemTemplate>
                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                    <ItemStyle Width="90px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:Button ID="btnExportSE" runat="server" Text="Export" class="btn btn-hover btnSubcolor" Width="15%" OnClick="btnExportSE_Click" />

                            <br />
                            <div id="divSEReportExport" runat="server" visible="false">
                                <rsweb:ReportViewer ID="rvDMReportSE" runat="server" DocumentMapWidth="100%" ShowBackButton="False" ShowDocumentMapButton="False" ShowExportControls="False" ShowRefreshButton="False" ShowZoomControl="False" Width="100%"></rsweb:ReportViewer>
                            </div>

                        </div>
                        <div id="menu12" class="tab-pane fade">

                            <div>
                                <div id="divCEOSEApprovedDoc">
                                    <asp:FileUpload ID="FileCeoSE" runat="server" />
                                    <asp:Button ID="btnSEUploadCeoDoc" runat="server" class="btn btn-hover btnSubcolor" OnClick="btnSEUploadCeoDoc_Click" Width="15%" Text="Upload CEO Document" />
                                    <asp:Label ID="lblIDSE" Text="FIle ID: " runat="server"></asp:Label>
                                    <asp:Label ID="lblSEFileID" runat="server"></asp:Label>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                        <div id="DivSERr" runat="server" visible="false">
                                            <asp:ListBox ID="drpSERejectReason" Style="width: 35px" SelectionMode="Multiple" runat="server" DataSourceID="SqlSERejectCeo" DataTextField="Reason" DataValueField="Reason" Height="45px" Width="193px"></asp:ListBox>
                                            <asp:Button ID="btnSERejectAppn" runat="server" Text="Reject Application" OnClick="btnSERejectAppn_Click" />
                                            <asp:SqlDataSource ID="SqlSERejectCeo" runat="server" ConnectionString="<%$ ConnectionStrings:KACDCConnectionString %>" SelectCommand="SELECT * FROM [RejectReason]"></asp:SqlDataSource>
                                        </div>

                                        <div id="divCEOSE" runat="server" class="text-sm-center">
                                            <asp:GridView ID="SEgvDMCEO" runat="server" class="GridView" OnRowCancelingEdit="SEgvDMCEO_RowCancelingEdit" OnRowUpdating="SEgvDMCEO_RowUpdating" OnRowEditing="SEgvDMCEO_RowEditing" AutoGenerateColumns="False" DataKeyNames="ApplicationNumber,ApplicantName">
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                                                        <ItemTemplate>
                                                            <%# Eval("ApplicationNumber")%>
                                                        </ItemTemplate>
                                                        <HeaderStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="220px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Applicant Name" ItemStyle-Width="220">
                                                        <ItemTemplate>
                                                            <%# Eval("ApplicantName")%>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                        <ItemStyle Width="220px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Status" ItemStyle-Width="50">
                                                        <ItemTemplate>
                                                            <%# Eval("ApplicationStatus")%>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtLoanAmt" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="Loan Amount" TextMode="Number" MaxLength="6" onkeypress="return numeric(event)" />
                                                            <asp:DropDownList ID="drpQuota" Class="rowMargin txtcolor text-uppercase rowMargin txtcolor text-uppercase form-control" runat="server" ClientIDMode="Static">
                                                                <asp:ListItem>--SELECT--</asp:ListItem>
                                                                <asp:ListItem Value="ActionPlan"> ActionPlan</asp:ListItem>
                                                                <asp:ListItem Value="Adyakshara">Adyakshara VK</asp:ListItem>
                                                                <asp:ListItem Value="Government">Government VK</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                        <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                        <ItemStyle Width="220px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Reject" ItemStyle-Width="220">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnSECEOReject" class="btn btn-hover btnSubcolor" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnSECEOReject_Click" ShowHeader="True" Text="Reject" />
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                        <ItemStyle Width="220px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Waiting" ItemStyle-Width="220">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnSECEOWaiting" class="btn btn-hover btnSubcolor" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnSECEOWaiting_Click" ShowHeader="True" Text="Waiting" />
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                        <ItemStyle Width="220px" />
                                                    </asp:TemplateField>
                                                    <asp:CommandField ButtonType="Button" EditText="Approve Loan" ShowEditButton="True" />
                                                </Columns>
                                            </asp:GridView>
                                            <br />
                                            <br />
                                            <h2>Waiting List</h2>
                                            <asp:GridView ID="SEgvDMCEOWaiting" runat="server" class="GridView" OnRowCancelingEdit="SEgvDMCEOWaiting_RowCancelingEdit" OnRowUpdating="SEgvDMCEOWaiting_RowUpdating" OnRowEditing="SEgvDMCEOWaiting_RowEditing" AutoGenerateColumns="False" DataKeyNames="ApplicationNumber,ApplicantName">
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                                                        <ItemTemplate>
                                                            <%# Eval("ApplicationNumber")%>
                                                        </ItemTemplate>
                                                        <HeaderStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="220px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Applicant Name" ItemStyle-Width="220">
                                                        <ItemTemplate>
                                                            <%# Eval("ApplicantName")%>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                        <ItemStyle Width="220px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Status" ItemStyle-Width="50">
                                                        <ItemTemplate>
                                                            <%# Eval("ApplicationStatus")%>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtLoanAmt" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="Loan Amount" TextMode="Number" MaxLength="6" onkeypress="return numeric(event)" />
                                                            <asp:DropDownList ID="drpQuota" Class="rowMargin txtcolor text-uppercase rowMargin txtcolor text-uppercase form-control" runat="server" ClientIDMode="Static">
                                                                <asp:ListItem>--SELECT--</asp:ListItem>
                                                                <asp:ListItem Value="ActionPlan"> ActionPlan</asp:ListItem>
                                                                <asp:ListItem Value="Adyakshara">Adyakshara VK</asp:ListItem>
                                                                <asp:ListItem Value="Government">Government VK</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </EditItemTemplate>
                                                        <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                        <ItemStyle Width="220px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Reject" ItemStyle-Width="220">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnSECEOWaitingReject" class="btn btn-hover btnSubcolor" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnSECEOWaitingReject_Click" ShowHeader="True" Text="Reject" />
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                        <ItemStyle Width="220px" />
                                                    </asp:TemplateField>
                                                    <asp:CommandField ButtonType="Button" EditText="Approve Loan" ShowEditButton="True" />
                                                </Columns>
                                            </asp:GridView>
                                            <br />
                                            <br />
                                        </div>
                                        <asp:Panel ID="PnlDMSECEOReason" runat="server" CssClass="modalPopup" Width="650px" Height="380px" Style="display: none">
                                            <div style="text-align: center; font-size: 25px; letter-spacing: 2px;">
                                                <asp:Label Font-Bold="true" ID="Label16" runat="server" CssClass="form-row-label" Style="text-align: center" Text="Reason"></asp:Label>
                                            </div>
                                            <br />
                                            <div class="">
                                                <div class="flex-row">
                                                    <div class="form-row">
                                                        <div class="form-row-label">
                                                            <asp:Label ID="Label17" runat="server" Text="Application Number"></asp:Label>
                                                        </div>
                                                        <div class="form-row-input">
                                                            <asp:Label ID="lblSECEORejApplicationNumber" Width="40px" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="form-row-label">
                                                            <asp:Label ID="Label18" runat="server" Text="Applicant Name"></asp:Label>
                                                        </div>
                                                        <div class="form-row-input">
                                                            <asp:Label ID="lblSECEORejApplicationName" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="form-row-label">
                                                            <asp:Label ID="Label19" runat="server" Text="Reason"></asp:Label>
                                                        </div>
                                                        <div class="form-row-input">
                                                            <asp:TextBox ID="txtSECEORejectReason" CssClass="PopupTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                            <asp:Label runat="server" ID="lblSECEORejectError" Style="color: red; font-size: 13px"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="form-row-label">
                                                            <asp:Button ID="btnSECEORejectUpdate" runat="server" CssClass="Button" Text="Save" OnClick="btnSECEORejectUpdate_Click" />
                                                        </div>
                                                        <div class="form-row-input">
                                                            <asp:Button ID="Button1" runat="server" CssClass="Button" Text="Cancel" OnClientClick="return SECEOHidepopup()" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel ID="PnlDMSECEOWaitingReason" runat="server" CssClass="modalPopup" Width="650px" Height="380px" Style="display: none">
                                            <div style="text-align: center; font-size: 25px; letter-spacing: 2px;">
                                                <asp:Label Font-Bold="true" ID="Label20" runat="server" CssClass="form-row-label" Style="text-align: center" Text="Reason"></asp:Label>
                                            </div>
                                            <div class="">
                                                <div class="flex-row">
                                                    <div class="form-row">
                                                        <div class="form-row-label">
                                                            <asp:Label ID="Label21" runat="server" Text="Application Number"></asp:Label>
                                                        </div>
                                                        <div class="form-row-input">
                                                            <asp:Label ID="lblSECEOWaitingRejApplicationNumber" Width="40px" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="form-row-label">
                                                            <asp:Label ID="Label22" runat="server" Text="Applicant Name"></asp:Label>
                                                        </div>
                                                        <div class="form-row-input">
                                                            <asp:Label ID="lblSECEOWaitingRejApplicationName" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="form-row-label">
                                                            <asp:Label ID="Label23" runat="server" Text="Reason"></asp:Label>
                                                        </div>
                                                        <div class="form-row-input">
                                                            <asp:TextBox ID="txtSECEOWaitingRejectReason" CssClass="PopupTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                            <asp:Label runat="server" ID="lblSECEOWaitingRejectError" Style="color: red; font-size: 13px"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="form-row">
                                                        <div class="form-row-label">
                                                            <asp:Button ID="btnSECEOWaitingRejectUpdate" runat="server" CssClass="Button" Text="Save" OnClick="btnSECEOWaitingRejectUpdate_Click" />
                                                        </div>
                                                        <div class="form-row-input">
                                                            <asp:Button ID="Button2" runat="server" CssClass="Button" Text="Cancel" OnClientClick="return SECEOWaitingHidepopup()" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                    <asp:LinkButton ID="lnkDMCEOSEFake" runat="server"></asp:LinkButton>
                                    <asp:LinkButton ID="lnkDMCEOWaitingSEFake" runat="server"></asp:LinkButton>
                                        <cc1:ModalPopupExtender ID="DMSECEORejectPopup" runat="server" DropShadow="false"
                                            PopupControlID="PnlDMSECEOReason" TargetControlID="lnkDMCEOSEFake"
                                            BackgroundCssClass="modalBackground">
                                        </cc1:ModalPopupExtender>
                                        <cc1:ModalPopupExtender ID="DMSECEOWaitingRejectPopup" runat="server" DropShadow="false"
                                            PopupControlID="PnlDMSECEOWaitingReason" TargetControlID="lnkDMCEOWaitingSEFake"
                                            BackgroundCssClass="modalBackground">
                                        </cc1:ModalPopupExtender>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="SEgvDMCEO" />
                                        <asp:AsyncPostBackTrigger ControlID="btnSECEORejectUpdate" />
                                        <asp:AsyncPostBackTrigger ControlID="SEgvDMCEOWaiting" />
                                        <asp:AsyncPostBackTrigger ControlID="btnSECEOWaitingRejectUpdate" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <div id="divSECEOPrinting">
                                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                        <ContentTemplate>
                                            <h2>Approved List</h2>
                                            <div class="d-flex justify-content-center">
                                            <asp:GridView ID="SEgvDMCEOApprovedList" class="GridView" runat="server" AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:BoundField ItemStyle-Width="200px" DataField="ApplicationNumber" HeaderText="Application Number" >
                                                    <ItemStyle Width="200px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField ItemStyle-Width="150px" DataField="ApplicantName" HeaderText="Applicant Name " >
                                                    <ItemStyle Width="150px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField ItemStyle-Width="150px" DataField="Quota" HeaderText="Quota" >
                                                    <ItemStyle Width="150px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField ItemStyle-Width="200px" DataField="LoanAmount" HeaderText="Loan Amount" >
                                                    <ItemStyle Width="200px" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                                   </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div style="align-items: center">
                                        <asp:Button ID="btnPrintCEOApproved" runat="server" class="Button" Text="Print" Width="20%" OnClick="btnPrintCEOApproved_Click" />
                                    </div>
                                    <br />
                                    <br />

                                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                        <ContentTemplate>
                                            <h2>Waiting List</h2>
                                            <asp:GridView ID="SEgvDMCEOWaitingList" class="GridView" runat="server" AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:BoundField ItemStyle-Width="200px" DataField="ApplicationNumber" HeaderText="Application Number" />
                                                    <asp:BoundField ItemStyle-Width="100px" DataField="ApplicantName" HeaderText="Applicant Name " />
                                                    <asp:BoundField ItemStyle-Width="50px" DataField="MobileNumber" HeaderText="Mobile Number" />
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div style="align-items: center">
                                        <asp:Button ID="btnPrintCEOWaiting" runat="server" class="Button" Text="Print" Width="20%" OnClick="btnPrintCEOWaiting_Click" />
                                    </div>
                                    <br />
                                    <br />

                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <h2>Rejected List</h2>
                                            <asp:GridView ID="SEgvDMCEORejectedList" class="GridView" runat="server" AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:BoundField ItemStyle-Width="200px" DataField="ApplicationNumber" HeaderText="Application Number" />
                                                    <asp:BoundField ItemStyle-Width="100px" DataField="ApplicantName" HeaderText="Applicant Name " />
                                                    <asp:BoundField ItemStyle-Width="50px" DataField="MobileNumber" HeaderText="Mobile Number" />
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div style="align-items: center">
                                        <asp:Button ID="btnPrintCEORejected" runat="server" class="Button" Text="Print" Width="20%" OnClick="btnPrintCEORejected_Click" />
                                    </div>
                                </div>                               
                            </div>
                        </div>                        
                        <div id="menu22" class="tab-pane fade">
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <div>
                                        <div id="divRejectDOCSE" runat="server" visible="false">
                                            <asp:ListBox ID="drpRejectDOCSE" Style="width: 35px" SelectionMode="Multiple" runat="server" DataSourceID="SqlSERejectDoc" DataTextField="Reason" DataValueField="Reason" Height="45px" Width="193px"></asp:ListBox>
                                            <asp:Button ID="btnRejectDOCSE" runat="server" Text="Reject Application" OnClick="btnRejectDOCSE_Click" />
                                            <asp:SqlDataSource ID="SqlSERejectDoc" runat="server" ConnectionString="<%$ ConnectionStrings:KACDCConnectionString %>" SelectCommand="SELECT * FROM [RejectReason]"></asp:SqlDataSource>
                                        </div>
                                        
                                                <div id="divDocSE" runat="server" class="text-sm-center">
                                                    <div id="divUpdateBankSE" style="margin-bottom:10px">
                                                        <div class="container-fluid">
                                                            <div class="container">
                                                                <div class="formBox">
                                                                    <div class="row" style="background-color: rgba(0,0,0,0.05); margin-top: -15px">
                                                                    <div class="col-sm-12" >                        
                                                                        <h2 style="margin-top:8px">Update Bank Details</h2>
                                                                        <h5 style="float:left"; width:50% >Applicantion Number : <asp:Label runat="server" ID="lblApplicationNumberSE" Text=""></asp:Label></h5>
                                                                    
                                                                    </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-sm-4">
                                                                            <div class="">
                                                                                <div>
                                                                                    <div class="InputBox">
                                                                                        <asp:TextBox class="input" runat="server" ID="txtApplicantNameSE"  CausesValidation="false"  ></asp:TextBox>
                                                                                        <label runat="server" id="lbl1" text="Phy Num">Applicant Name</label>
                                                                                    </div>
                                                                                    <div class="InputBox">
                                                                                        <asp:TextBox class="input" runat="server" ID="txtAccountNumberSE"  CausesValidation="false" onkeypress="return numeric(event)"></asp:TextBox>
                                                                                       
                                                                                        <label class="Label" runat="server" id="Label1" text="Phy abc">Account Number</label>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                        <div class="col-sm-4">
                                                                            <div class="">
                                                                                <div>
                                                                                    <div class="InputBox">
                                                                                        <asp:TextBox class="input" runat="server" ID="txtBankNameSE" CausesValidation="false"></asp:TextBox>
                                                                                        <label runat="server" id="Label4" text="Phy Num">Bank</label>
                                                                                    </div>
                                                                                    <div class="InputBox">
                                                                                        <asp:TextBox class="input" runat="server" ID="txtBranchSE" ></asp:TextBox>
                                                                                        <label runat="server" id="Label5" text="Phy Num">Branch</label>
                                                                                    </div>

                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-sm-4">
                                                                            <div class="">
                                                                                <div>
                                                                                    <div class="InputBox">
                                                                                        <asp:TextBox class="input" runat="server" ID="txtIFSCCodeSE" ></asp:TextBox>
                                                                                        <label runat="server" id="Label2" text="Phy Num">IFSC Code</label>
                                                                                    </div>
                                                                                    <div class="InputBox">
                                                                                        <asp:TextBox class="input" runat="server" ID="txtBankAddrSE" ></asp:TextBox>
                                                                                        <label class="Label" runat="server" id="Label3" text="Phy abc">Bank Address</label>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row" style="margin-top: -25px">
                                                                        <div class="col-sm-4">
                                                                            <div class="InputBox">
                                                                            <asp:DropDownList ID="drpSEReasonBankModify" runat="server" class="dropdown">
                                                                                <asp:ListItem Value="">--SELECE REASON--</asp:ListItem>
                                                                                <asp:ListItem Value="Jandhan Account">Jandhan Account</asp:ListItem>
                                                                                <asp:ListItem Value="Invalid IFSC Code">Wrong IFSC Code</asp:ListItem>
                                                                                <asp:ListItem Value="Invalid A/C Number">Invalid A/C Number</asp:ListItem>
                                                                                <asp:ListItem Value="Invalid Branch">Invalid Branch</asp:ListItem>
                                                                                <asp:ListItem Value="Invalid Bank">Invalid Bank</asp:ListItem>
                                                                                <asp:ListItem Value="Invalid Address">Invalid Address</asp:ListItem>
                                                                                <asp:ListItem Value="Invalid Name">Invalid Name</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                            </div>
                                                                        <div class="col-sm-4">
                                                                            <asp:Button ID="btnUpdateBankSE" class="Button" runat="server" OnClick="btnUpdateBankSE_Click" Style="margin-left: 40%;" Text="Update Details" CausesValidation="false" />
                                                                        </div>
                                                                        <div class="col-sm-4">
                                                                            <asp:Button ID="btnClearSE" class="Button" runat="server" Text="Cancel / Clear" OnClick="btnClearSE_Click" CausesValidation="false" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <asp:GridView ID="SEgvDMDoc" runat="server" class="GridView" OnRowCancelingEdit="SEgvDMDoc_RowCancelingEdit" OnRowUpdating="SEgvDMDoc_RowUpdating" OnRowEditing="SEgvDMDoc_RowEditing" AutoGenerateColumns="False" DataKeyNames="ApplicationNumber,ApplicantName">
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                                                                <ItemTemplate>
                                                                    <%# Eval("ApplicationNumber")%>
                                                                </ItemTemplate>
                                                                <HeaderStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="220px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Applicant Name" ItemStyle-Width="220">
                                                                <ItemTemplate>
                                                                    <%# Eval("ApplicantName")%>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                <ItemStyle Width="220px" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Quota" ItemStyle-Width="220">
                                                                <ItemTemplate>
                                                                    <%# Eval("Quota")%>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtApprovedApplicationNumber" Class="rowMargin txtcolor text-uppercase form-control" runat="server" />
                                                                </EditItemTemplate>
                                                                <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                <ItemStyle Width="220px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Bank Details" ItemStyle-Width="220">
                                                                <ItemTemplate>
                                                                    <%# "A/C No: " + Eval("AccountNumber")+ "<br />"%>
                                                                    <asp:Button ID="btnSEDispPassbook" Visible="false" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnSEDispPassbook_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("AccountNumber") %>' />
                                                                    <%# "Bank: " + Eval("BankName")+ "<br />" + " Branch: " + Eval("Branch")+ "<br />" + " IFSCCode: " + Eval("IFSCCode")+ "<br />" + " Address: " + Eval("BankAddress")%>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="text-center font-weight-bold" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                                                            </asp:TemplateField>
                                                            <%-- <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Download Documents" ItemStyle-Width="220">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnSEDocDownload" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnSEDocDownload_Click" ShowHeader="True" Text="Download" />
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                        <ItemStyle Width="220px" />
                                                    </asp:TemplateField>--%>

                                                            <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Accept" ItemStyle-Width="220">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnSEDocAccept" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnSEDocAccept_Click" ShowHeader="True" Text="Document Verified" />
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                <ItemStyle Width="220px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Reject" ItemStyle-Width="220">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnSEDocReject" runat="server" class="btn btn-hover btnModcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnSEDocReject_Click" ShowHeader="True" Text="Reject" />
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                <ItemStyle Width="220px" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Update" ItemStyle-Width="50">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnGVUpdateBankSE" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnGVUpdateBankSE_Click" CausesValidation="false" ShowHeader="True" Text='<%# Eval("REASON") %>' />
<%--                                                                    <asp:Button ID="Button1" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnSeAppNum_Click" CausesValidation="false" ShowHeader="True" Text="popup" />--%>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                </EditItemTemplate>
                                                                <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                <ItemStyle Width="220px" />
                                                            </asp:TemplateField>
<%--                                                            <asp:CommandField ButtonType="Button" EditText="Document Verified" ShowEditButton="True" />--%>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <!-- this is bootstrp modal popup -->  
                                                   
                                                    <br />
                                                    <br />
                                                </div>
                                                <div id="SEDMDocInfoHidden" visible="false">
                                                    <asp:GridView ID="SEDMDocPrintApprove" Visible="false" runat="server" AutoGenerateColumns="False">
                                                        <Columns>
                                                            <asp:BoundField ItemStyle-Width="200px" DataField="ApplicationNumber" HeaderText="Application Number" />
                                                            <asp:BoundField ItemStyle-Width="100px" DataField="ApplicantName" HeaderText="Applicant Name" />
                                                            <asp:BoundField ItemStyle-Width="50px" DataField="Quota" HeaderText="Quota" />
                                                        </Columns>
                                                    </asp:GridView>
                                                    <asp:GridView ID="SEDMDocPrintWaiting"  Visible="false" runat="server" AutoGenerateColumns="False">
                                                        <Columns>
                                                            <asp:BoundField ItemStyle-Width="200px" DataField="ApplicationNumber" HeaderText="Application Number" />
                                                            <asp:BoundField ItemStyle-Width="100px" DataField="ApplicantName" HeaderText="Applicant Name " />
                                                            <asp:BoundField ItemStyle-Width="50px" DataField="Quota" HeaderText="Quota" />
                                                        </Columns>
                                                    </asp:GridView>
                                                    <asp:GridView ID="SEDMDocPrintReject"  Visible="false" runat="server" AutoGenerateColumns="False">
                                                        <Columns>
                                                            <asp:BoundField ItemStyle-Width="200px" DataField="ApplicationNumber" HeaderText="Application Number" />
                                                            <asp:BoundField ItemStyle-Width="100px" DataField="ApplicantName" HeaderText="Applicant Name " />
                                                            <asp:BoundField ItemStyle-Width="50px" DataField="Quota" HeaderText="Quota" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                           
                                    </div>
                                    <asp:Panel ID="PnlDMSEDocReason" runat="server" CssClass="modalPopup" Width="650px" Height="380px" Style="display: none">
                                        <div style="text-align: center; font-size: 25px; letter-spacing: 2px;">
                                            <asp:Label Font-Bold="true" ID="Label12" runat="server" CssClass="form-row-label" Style="text-align: center" Text="Reason"></asp:Label>
                                        </div>
                                        <br />
                                        <div class="">
                                            <div class="flex-row">
                                                <div class="form-row">
                                                    <div class="form-row-label">
                                                        <asp:Label ID="Label13" runat="server" Text="Application Number"></asp:Label>
                                                    </div>
                                                    <div class="form-row-input">
                                                        <asp:Label ID="lblSEDocRejApplicationNumber" Width="40px" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="form-row">
                                                    <div class="form-row-label">
                                                        <asp:Label ID="Label14" runat="server" Text="Applicant Name"></asp:Label>
                                                    </div>
                                                    <div class="form-row-input">
                                                        <asp:Label ID="lblSEDocRejApplicationName" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="form-row">
                                                    <div class="form-row-label">
                                                        <asp:Label ID="Label15" runat="server" Text="Reason"></asp:Label>
                                                    </div>
                                                    <div class="form-row-input">
                                                        <asp:TextBox ID="txtSEDocRejectReason" CssClass="PopupTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                        <asp:Label runat="server" ID="lblSEDocRejectError" style="color:red;font-size:13px"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="form-row">
                                                    <div class="form-row-label">
                                                        <asp:Button ID="btnSEDOCRejectUpdate" runat="server" CssClass="Button" Text="Save" OnClick="btnSEDOCRejectUpdate_Click" />
                                                    </div>
                                                    <div class="form-row-input">
                                                        <asp:Button ID="btnSECancel" runat="server" CssClass="Button" Text="Cancel" OnClientClick="return SEDocHidepopup()" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:LinkButton ID="lnkDMDocSEFake" runat="server"></asp:LinkButton>
                <cc1:ModalPopupExtender ID="DMSEDocRejectPopup" runat="server" DropShadow="false"
                    PopupControlID="PnlDMSEDocReason" TargetControlID="lnkDMDocSEFake"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="SEgvDMDoc" />
                                    <asp:AsyncPostBackTrigger ControlID="btnSEDOCRejectUpdate" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <div style="align-items: center">
                                <asp:Button ID="btnSESubmitZM" runat="server" class="Button" Text="Submit to ZM" Width="20%" OnClick="btnSESubmitZM_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';"/>
                                <asp:Label ID="lblSEZMSubmitStatus" style="font-weight:bold" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    </div>
                </div>
                 <div id="mpic" class="tab-pane fade">
                 </div>
            </div>
        </div>
    </form>
</body>
</html>