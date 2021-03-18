<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="KACDC.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
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
            color: #454545;
            text-align:center;
        }

            #tabs #h5 h6.section-title {
                color: darkblue;
            }

            #tabs .nav-tabs .nav-item.show .nav-link, .nav-tabs .nav-link.active {
                color: #292929;
                border-color: transparent transparent #303030;
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
    <div id="divContact" class="container">
        <section id="tabs">
            <div class="align-content-center">
                <div class="col-xs-12 ">
                    <nav>
                        <div class="nav nav-tabs nav-fill" id="nav-tab" role="tablist">
                            <a class="nav-item nav-link active" id="nav-HO-tab" data-toggle="tab" href="#nav-HO" role="tab" aria-controls="nav-HO" aria-selected="true">Head Office</a>
                            <a class="nav-item nav-link" id="nav-ZO-tab" data-toggle="tab" href="#nav-ZO" role="tab" aria-controls="nav-ZO" aria-selected="false">Zonal Office</a>
                            <a class="nav-item nav-link" id="nav-DO-tab" data-toggle="tab" href="#nav-DO" role="tab" aria-controls="nav-DO" aria-selected="false">District Office</a>
                        </div>
                    </nav>
                </div>
                <div class="container">
                    <div class="row">
                        <div class="tab-content py-3 px-3 px-sm-0" id="nav-tabContent">
                            <div class="tab-pane fade show active" id="nav-HO" role="tabpanel" aria-labelledby="nav-HO-tab">
                                <h5 style="color: #666666" class="text-left"><strong>For More Information</strong></h5>
                                <address class="text-left">
                                    <strong style="color: #666666" class="text-left">Support:</strong>   <a href="mailto:Support@example.com">Support.kacdc@karnataka.gov.in</a><br />
                                    <strong style="color: #666666" class="text-left">Support:</strong> <a href="mailto:Marketing@example.com">+91-944 845 1111</a>
                                </address>
                                  <div id="divHOKA" style="padding: 10px; width: 100%">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvHOKAn" runat="server" AutoGenerateColumns="false" DataKeyNames="SlNo"
                                                PageSize="10" AllowPaging="true" EmptyDataText="No records has been added." Width="100%">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="Sl No" ItemStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHOKASlNo" runat="server" Text='<%# Eval("OrderNumber")%>' />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Name" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHOKADistrict" runat="server" Text='<%# Eval("District")%>' />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Designation" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHOKAOfficerandDesignation" runat="server" Text='<%# Eval("[OfficerandDesignation]")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="EMail" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHOKAEMail" runat="server" Text='<%# Eval("[EMail]")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Mobile" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHOKATelephone" runat="server" Text='<%# Eval("[Telephone]")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Address" ItemStyle-Width="35%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHOKAAddress" runat="server" Text='<%# Eval("[Address]")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <br />
                                <div id="divHOEN" style="padding: 10px; width: 100%">
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvHOENn" runat="server" AutoGenerateColumns="false"
                                                DataKeyNames="SlNo" PageSize="10" AllowPaging="true" EmptyDataText="No records has been added." Width="100%">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="Sl No" ItemStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHOENSlNo" runat="server" Text='<%# Eval("OrderNumber")%>' />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Name" ItemStyle-Width="15">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHOENDistrict" runat="server" Text='<%# Eval("District")%>' />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Designation" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHOENOfficerandDesignation" runat="server" Text='<%# Eval("[OfficerandDesignation]")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="EMail" ItemStyle-Width="15">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHOENEMail" runat="server" Text='<%# Eval("[EMail]")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Mobile" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHOENTelephone" runat="server" Text='<%# Eval("[Telephone]")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Address" ItemStyle-Width="35%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHOENAddress" runat="server" Text='<%# Eval("[Address]")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                               


                            </div>
                            <div class="tab-pane fade" id="nav-ZO" role="tabpanel" aria-labelledby="nav-ZO-tab">
                                <h5 style="color: #666666" class="text-left"><strong>For More Information</strong></h5>
                                <address class="text-left">
                                    <strong style="color: #666666" class="text-left">Support:</strong>   <a href="mailto:Support@example.com">Support.kacdc@karnataka.gov.in</a><br />
                                    <strong style="color: #666666" class="text-left">Support:</strong> <a href="mailto:Marketing@example.com">+91-9443 845 1111</a>
                                </address>
                                <div id="divZMKA" style="padding: 10px; width: 100%">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvZMKAn" runat="server" AutoGenerateColumns="false" DataKeyNames="SlNo" PageSize="10" AllowPaging="true"
                                                EmptyDataText="No records has been added." Width="100%">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="Sl No" ItemStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblZMKASlNo" runat="server" Text='<%# Eval("SlNo")%>' />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="District" ItemStyle-Width="15">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblZMKADistrict" runat="server" Text='<%# Eval("District")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Officer and Designation" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblZMKAOfficerandDesignation" runat="server" Text='<%# Eval("[OfficerandDesignation]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="EMail" ItemStyle-Width="15">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblZMKAEMail" runat="server" Text='<%# Eval("[EMail]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Telephone" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblZMKATelephone" runat="server" Text='<%# Eval("[Telephone]")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Address" ItemStyle-Width="35%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblZMKAAddress" runat="server" Text='<%# Eval("[Address]")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <br />
                                <div id="divZMEN" style="padding: 10px; width: 100%">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvZMENn" runat="server" AutoGenerateColumns="false"
                                                DataKeyNames="SlNo" PageSize="10" AllowPaging="true" EmptyDataText="No records has been added." Width="100%">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="Sl No" ItemStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblZMENSlNo" runat="server" Text='<%# Eval("SlNo")%>' />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="District" ItemStyle-Width="15">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblZMENDistrict" runat="server" Text='<%# Eval("District")%>' />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Officer and Designation" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblZMENOfficerandDesignation" runat="server" Text='<%# Eval("[OfficerandDesignation]")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="EMail" ItemStyle-Width="15">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblZMENEMail" runat="server" Text='<%# Eval("[EMail]")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Telephone" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblZMENTelephone" runat="server" Text='<%# Eval("[Telephone]")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Address" ItemStyle-Width="35%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblZMENAddress" runat="server" Text='<%# Eval("[Address]")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="nav-DO" role="tabpanel" aria-labelledby="nav-DO-tab">
                                <h5 style="color: #666666" class="text-left"><strong>More Information</strong></h5>
                                <address class="text-left">
                                    <strong style="color: #666666" class="text-left">Support:</strong>   <a href="mailto:Support@example.com">Support.kacdc@karnataka.gov.in</a><br />
                                    <strong style="color: #666666" class="text-left">Support:</strong> <a href="mailto:Marketing@example.com">+91-9443 845 1111</a>
                                </address>
                               <div id="divDMKA" style="padding: 10px; width: 100%">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvDMKan" runat="server" AutoGenerateColumns="false" DataKeyNames="SlNo"
                                                PageSize="10" AllowPaging="true" EmptyDataText="No records has been added." Width="100%">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="Sl No" ItemStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDMKASlNo" runat="server" Text='<%# Eval("SlNo")%>' />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="District" ItemStyle-Width="15">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDMKADistrict" runat="server" Text='<%# Eval("District")%>' />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Officer and Designation" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDMKAOfficerandDesignation" runat="server" Text='<%# Eval("[OfficerandDesignation]")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="EMail" ItemStyle-Width="15">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDMKAEMail" runat="server" Text='<%# Eval("[EMail]")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Telephone" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDMKATelephone" runat="server" Text='<%# Eval("[Telephone]")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Address" ItemStyle-Width="35%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDMKAAddress" runat="server" Text='<%# Eval("[Address]")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <br />
                                <div id="divDMEN" style="padding: 10px; width: 100%">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvDMENn" runat="server" AutoGenerateColumns="false" DataKeyNames="SlNo" PageSize="10" AllowPaging="true"
                                                EmptyDataText="No records has been added." Width="100%">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="Sl No" ItemStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDMENSlNo" runat="server" Text='<%# Eval("SlNo")%>' />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="District" ItemStyle-Width="15">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDMENDistrict" runat="server" Text='<%# Eval("District")%>' />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Officer and Designation" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDMENOfficerandDesignation" runat="server" Text='<%# Eval("[OfficerandDesignation]")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="EMail" ItemStyle-Width="15">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDMENEMail" runat="server" Text='<%# Eval("[EMail]")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Telephone" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDMENTelephone" runat="server" Text='<%# Eval("[Telephone]")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Address" ItemStyle-Width="35%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDMENAddress" runat="server" Text='<%# Eval("[Address]")%>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
    <br />
</asp:Content>
