<%@ Page  Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="CW_Form.aspx.cs" Inherits="KACDC.CW_Form" %>
  
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Case Worker</title>
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
  
    <script type="text/javascript">
        $(function () {
            $('[id*=lstArivuCWReject11]').multiselect({
                includeSelectAllOption: true
            });
        });
        $(function () {
            $('[id*=drpArivuRejectReason11]').multiselect({
                includeSelectAllOption: true
            });
        });

    </script>

</head>
<body>
    <form runat="server">

        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div class="text-sm-right">
            <asp:Button ID="btnLogout" class="btn btn-hover btnSubcolor" Width="10%" runat="server" Text="Logout" OnClick="btnLogout_Click" />
            <ul class="nav nav-tabs">
                <li class="active"><a data-toggle="tab" href="#home">Arivu Education Loan</a></li>
                <li><a data-toggle="tab" href="#menu1">Self Employment Loan</a></li>
            </ul>
            <div class="tab-content">
                <div id="home" class="tab-pane fade in active">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="text-center">
                                <asp:GridView ID="ArivugvCWApprove" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="ArivugvCW_RowCancelingEdit" OnRowEditing="btnArivuRowEditing" DataKeyNames="ApplicationNumber,RDNumber,AadharNum" Style="align-content: center; margin-left: 5px">
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
                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Applicant Name" ItemStyle-Width="220">
                                            <ItemTemplate>
                                                <%# Eval("ApplicantName") + "<br />" + Eval("Gender")+ "<br />"+"PH : "+ Eval("PhysicallyChallenged") %>
<%--                                                <asp:Button ID="btnDispPH" class="btn btn-hover btnSubcolor" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnDispPH_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("PhysicallyChallenged") %>' />--%>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="RD & AadharNumber " ItemStyle-Width="220">
                                            <ItemTemplate>
                                                <%# "RD Number: " + Eval("RDNumber")+ "<br />" + " Aadhar: " + Eval("AadharNum")%>
                                                <asp:Button ID="btnCasteIncome" Visible="false" class="btn btn-hover btnSubcolor" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnCasteIncome_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5; padding: 1px" Text='<%# Eval("RDNumber") %>' ToolTip="Caste and Incone Certificate" />
                                                <asp:Button ID="btnDispAadhar" Visible="false" class="btn btn-hover btnSubcolor" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnDispAadhar_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("AadharNum") %>' ToolTip="Aadhar" />
                                                <%--<asp:Button ID="HyperLink1" OnClick="ArivugvCWApprove_RowCommand" OnClientClick="aspnetForm.target ='_blank';" runat="server" Text='<%# Eval("RDNumber") %>' CommandArgument="<%# Container.DataItemIndex %>" ></asp:Button>--%><%--<asp:HyperLink  CommandName="PathUpdate" runat="server" Text='<%# Eval("RDNumber")+"abc" %>' Target="_blank" />--%>
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
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Bank Details" ItemStyle-Width="220">
                                            <ItemTemplate>
                                                <%# "A/C No: " + Eval("AccountNumber")+ "<br />"%>
                                                <asp:Button ID="btnDispPassbook" Visible="false" class="btn btn-hover btnSubcolor" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnDispPassbook_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("AccountNumber") %>' />
                                                <%# "Bank: " + Eval("BankName")+ "<br />" + " Branch: " + Eval("Branch")+ "<br />" + " IFSCCode: " + Eval("IFSCCode")+ "<br />" + " Address: " + Eval("BankAddress")%>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="College Details" ItemStyle-Width="220">
                                            <ItemTemplate>
                                                <%# "CET Ticate: "+Eval("CETAdmissionTicateNum") + "<br />"%>
                                                <asp:Button ID="btnDispCET" Visible="false" class="btn btn-hover btnSubcolor" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnDispCET_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("CETAdmissionTicateNum") %>' ToolTip="CET Admission Ticate" />
                                                <%# "<br />"+" Year: " + Eval("CurrentYear") + "<br />" + " Course: " + Eval("Course")+ "<br />" +" College Hostel: " + " ClgHostel: " + Eval("Course") + Eval("CollegeName")+ "<br />" + " Prev Year Marks: " + Eval("PrevYearMarks")+ "<br />" + " Address: " + Eval("CollegeAddress") +"<BR /> "%>
                                                <asp:Button ID="btnFeeStruct" Visible="false" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnFeeStruct_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# "Fee Structure" %>' ToolTip="Study Certificate" />
                                                <%# " " %>
                                                <asp:Button ID="btnDispClgHostel" Visible="false" class="btn btn-hover btnSubcolor" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnDispClgHostel_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# "Hostel: "+Eval("ClgHostel") %>' ToolTip="Study Certificate" />
                                                <%# " " %>
                                                <asp:Button ID="btnStudyCertificate" Visible="false" class="btn btn-hover btnSubcolor" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnStudyCertificate_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# "Study Cert" %>' ToolTip="Study Certificate" />
                                                <%# " " %>
                                                <asp:Button ID="btnMarksCard" runat="server" Visible="false" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnMarksCard_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# "Marks Card" %>' ToolTip="Study Certificate" />
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="300px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Status" ItemStyle-Width="50">
                                            <ItemTemplate>
                                                <%# Eval("ApplicationStatus")%>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lbl" runat="server" Text="Press Control(Ctrl) to select multiple Reason"></asp:Label>
                                                <asp:ListBox ID="drpArivuRejectReason" SelectionMode="Multiple" runat="server" Height="100px" Width="250px">
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


                                            </EditItemTemplate>
                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Accept" ItemStyle-Width="220">
                                            <ItemTemplate>
                                                <asp:Button ID="btnArivuCWApprovee" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnArivuCWApprovee_Click" ShowHeader="True" Text="Eligible" />
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Reject" ItemStyle-Width="220">
                                            <ItemTemplate>
                                                <asp:LinkButton Text="Ineligible" class="btn btn-hover btnModcolor" runat="server" CommandName="Edit" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:LinkButton Text="Ineligible" runat="server" class="btn btn-hover btnSubcolor" OnClick="OnUpdate" OnClientClick="return Validate(this)" />
                                                <asp:LinkButton ID="btnCancelArivuCW" Text="Cancel" class="btn btn-hover btnSubcolor" runat="server" OnClick="CancelArivuCW_Click" />
                                            </EditItemTemplate>
                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        </asp:TemplateField>
                                        <%-- <asp:TemplateField   HeaderText="Accept / Reject" ItemStyle-Width="220" HeaderStyle-CssClass="text-center text-center font-weight-bold">
                                <ItemTemplate>
                                    <asp:Button ID="btnDonloadDoc" runat="server" OnClick="btnDonloadDoc_Click" ShowHeader="True" Text="Download" HeaderStyle-CssClass="text-center text-center font-weight-bold" />
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                <ItemStyle Width="220px" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div id="menu1" class="tab-pane fade">

                    <div id="divCWSERejectReason" runat="server" visible="false">
                        <asp:ListBox ID="drpSERejectReason" Style="width: 35px" SelectionMode="Multiple" runat="server" DataSourceID="SqlSERejectCW" DataTextField="Reason" DataValueField="Reason" Height="45px" Width="193px"></asp:ListBox>
                        <asp:Button ID="btnSERejectAppn" runat="server" Text="Reject Application" OnClick="btnSERejectAppn_Click" />
                        <asp:SqlDataSource ID="SqlSERejectCW" runat="server" ConnectionString="<%$ ConnectionStrings:KACDCConnectionString %>" SelectCommand="SELECT * FROM [RejectReason]"></asp:SqlDataSource>
                    </div>
                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                    <div class="text-center">
                        <asp:GridView ID="SECWApprove" runat="server" AutoGenerateColumns="False" DataKeyNames="ApplicationNumber,RDNumber,AadharNum" OnRowEditing="SECWApprove_RowEditing" Style="align-content: center; margin-left: 5px">
                            <Columns>
                                <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                                    <ItemTemplate>
                                        <%# Eval("ApplicationNumber")%>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtSEAppNum" runat="server" Text='<%# Eval("ApplicationNumber") %>' Enabled="false" />
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
                                        <asp:Button ID="btnSEDispAadhar" Visible="false" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnSEDispAadhar_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("AadharNum") %>' ToolTip="Aadhar" />
                                        <%--<asp:Button ID="HyperLink1" OnClick="ArivugvCWApprove_RowCommand" OnClientClick="aspnetForm.target ='_blank';" runat="server" Text='<%# Eval("RDNumber") %>' CommandArgument="<%# Container.DataItemIndex %>" ></asp:Button>--%><%--<asp:HyperLink  CommandName="PathUpdate" runat="server" Text='<%# Eval("RDNumber")+"abc" %>' Target="_blank" />--%>
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
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="320px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Bank Details" ItemStyle-Width="220">
                                    <ItemTemplate>
                                                <%# "A/C No: " + Eval("AccountNumber")+ "<br />"%>
                                        <asp:Button ID="btnSEDispPassbook" Visible="false" class="btn btn-hover btnSubcolor" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnSEDispPassbook_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("AccountNumber") %>' />
                                        <%# "Bank: " + Eval("BankName")+ "<br />" + " Branch: " + Eval("Branch")+ "<br />" + " IFSCCode: " + Eval("IFSCCode")+ "<br />" + " Address: " + Eval("BankAddress")%>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Status" ItemStyle-Width="50">
                                    <ItemTemplate>
                                        <%# Eval("ApplicationStatus")%>
                                    </ItemTemplate>
                                    <ItemTemplate>
                                        <%# Eval("ApplicationStatus")%>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lbl" runat="server" Text="Press Control(Ctrl) to select multiple Reason"></asp:Label>
                                        <asp:ListBox ID="drpSERejectReason" SelectionMode="Multiple" runat="server" Height="250px" Width="250px">
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
                                    </EditItemTemplate>
                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Accept" ItemStyle-Width="220">
                                    <ItemTemplate>
                                        <asp:Button ID="btnSECWApprovee" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnSECWApprovee_Click" ShowHeader="True" Text="Eligible" />
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="170px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ineligible" ItemStyle-Width="220" HeaderStyle-CssClass="text-center text-center font-weight-bold">
                                    <ItemTemplate>
                                        <asp:LinkButton Text="Ineligible" class="btn btn-hover btnModcolor" runat="server" CommandName="Edit" />

                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton Text="Ineligible" runat="server" class="btn btn-hover btnModcolor" OnClick="OnUpdateSE" OnClientClick="return Validate(this)" />
                                        <asp:LinkButton ID="btnCancelSECW" Text="Cancel" class="btn btn-hover btnSubcolor" runat="server" OnClick="CancelSECW_Click" />
                                    </EditItemTemplate>
                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                    <ItemStyle Width="220px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                            </ContentTemplate>
                    </asp:UpdatePanel>
                    <triggers>
                    <asp:PostBackTrigger ControlID="btnSEDispPassbook_Click"></asp:PostBackTrigger>
        <asp:PostBackTrigger ControlID="btnCasteIncome_Click"></asp:PostBackTrigger>
    </triggers>
                </div>

            </div>
        </div>


    </form>
</body>
</html>
