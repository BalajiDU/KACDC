<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestForm1.aspx.cs" Inherits="KACDC.TestForms.TestForm1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Form</title>
        <link href="../../CustomCSS/Success_Animation.css" rel="stylesheet" />

    <script type="text/javascript">
            
        </script>
  <style>
      tr, td {
  padding: 8px;
}
        .Neumorphic {
            border-radius: 25px;
            background: #00a2ed;
            box-shadow: 10px 10px 20px #bdbdbd, -10px -10px 20px #f5f5f5;
            display: flex;
            justify-content: center;
            margin-right: 4rem;
            padding: 10px;
            margin: 20px;
            text-align: center;
            align-items: center;
            letter-spacing: 1.5px;
            font-size: 40px;
            font-family:sans-serif;
            font-family:sans-serif;
        }

        .NestedNeumorphic {
            background: #d9d9d9;
            box-shadow: inset 5px 5px 10px #bdbdbd, inset -5px -5px 10px #f5f5f5;
            border-radius: 10px;
            display: flex;
            justify-content: center;
            margin-right: 4rem;
            padding: 5px;
            margin: 5px;
            text-align: center;
            align-items: center;
            letter-spacing: 1.5px;
            font-size: 20px;
            font-family:sans-serif;
        }

        .NeuoDropdown {
            outline: none;
            border: none;
            background: #d9d9d9;
            box-shadow: inset 5px 5px 10px #bdbdbd, inset -5px -5px 10px #f5f5f5;
            border-radius: 10px;
            display: flex;
            justify-content: center;
            margin-right: 4rem;
            padding: 5px;
            margin: 5px;
            text-align: center;
            align-items: center;
            letter-spacing: 1.5px;
            font-size: 15px;
            font-family:sans-serif;
        }
        
        .form-row-label-Heading {
            padding-right: 10px;
            flex: 1;
            padding: 10px;
            width: 50%;
            font-weight: 300;
            letter-spacing: .2em;
            text-transform: uppercase;
            text-align: center;
            font-size: 35px;
            color:#7b0000;
            Background:white;
            font-family:sans-serif;
            font-weight:600;
        }

        .NeumorphicDiv {
            border-radius: 25px;
            background: #3B77BC;;
            box-shadow: 10px 10px 10px #797878, -10px -10px 10px #ffffff;
            justify-content: center;
            padding: 25px;
            margin: 20px;
            margin-top: 10px;
            align-items: center;
            letter-spacing: 1.5px;
            font-family:sans-serif;
            width: 60%;
            color:#620000;
        }

        .flex-container {
            display: flex;
            justify-content: space-around;
            align-items: center;
            flex-direction: row;
        }

        .flex-container-column {
            justify-content: space-around;
            display: flex;
            flex-direction: column;
        }

        .SectionMarginTop {
            margin-top: 0;
        }

        .NestedLabel {
            font-size: 20px;
            padding: 10px;
        }

        .LogoutButton {
            display: block;
            height: 100%;
            width: 100%;
            line-height: 65px;
            font-size: 20px;
            color: white;
            padding-left: -40px;
            box-sizing: border-box;
            border-bottom: 1px solid black;
            border-top: 1px solid rgba(255,255,255,.1);
            transition: .4s;
            background: transparent;
            color: red;
        }

        .NeoButton1 {
            padding: 5px;
            margin: 10px;
            outline: none;
            /*width: 40%;*/
            max-width: 60%;
            font-size: 16px;
            background: transparent;
            border: none;
            outline: none;
            cursor: pointer;
            border-radius: 3px;
            /*box-shadow: 8px 8px 10px #797878, -8px -8px 10px #ffffff;*/
        }

        .NeoButton {
            border: none;
            padding: 3px;
            margin: 7px;
            outline: none;
            /*width: 80%;*/
            padding-right:20px;
            padding-left:20px;
            height: 35px;
            align-items: center;
            align-content: center;
            border-radius: 3px;
            letter-spacing: .05em;
            text-transform: uppercase;
            font-size: 13px;
            background: transparent;
            color: #fff;
            background: rgba(3,154,244,0.8);
            cursor: pointer;
            border-style: none;
            outline: none;
            background: #dbdbdb;
            color: black;
            flex-wrap: wrap;
            -webkit-appearance: button;
            outline: none;
            /*box-shadow: 5px 5px 10px #797878, -5px -5px 10px #ffffff;*/
            font-size: 15px;
        }

            .NeoButton:hover {
                box-shadow: 5px 5px 10px white, -5px -5px 10px white;
            }

            .NeoButton:active {
                box-shadow: inset 5px 5px 10px #d4d2d2, inset -5px -5px 10px #ffffff;
            }

        .NeoTextBox {
           letter-spacing: .08em;
            box-sizing: border-box;
            width: 90%;
            height: 35px;
            font-size: 18px;
            border: none;
            padding: 5px;
            margin: 10px;
            outline: none;
            display: flex;
            flex-wrap: wrap;
            text-align: center;
            background: #eeecec;
            border-radius: 6px;
            text-shadow: 1px 1px 0 #fff;
            color: #303030;
            box-shadow: inset 5px 5px 10px #dddbdb, inset -5px -5px 10px #fffdfd;
            text-transform:uppercase;
        }

            .NeoTextBox:focus {
                box-shadow: inset 2px 2px 2px #e2e0e0, inset -2px -2px 2px #faf8f8;
            }

        .PopupTextBox {
            box-sizing: border-box;
            height: 50px;
            font-size: 18px;
            padding: 7px;
            border: none;
            outline: none;
            display: flex;
            flex-wrap: wrap;
            text-align: center;
            background: #eeecec;
            border-radius: 10px;
            text-shadow: 1px 1px 0 #fff;
            color: #303030;
            box-shadow: inset 5px 5px 10px #dddbdb, inset -5px -5px 10px #fffdfd;
        }
       
        .modalPopup {
            margin: 35px 5px 0px 10px;
            padding: 10px;
            background-color: white;
            border-radius: 25px;
            box-shadow: 1px 1px 2px #cac9c9,
                        -1px -1px 2px #ffffff;
            /*margin: 20px;
            margin-top: 30px;*/
            font-size: 20px;
            align-items: center;
            letter-spacing: 1.5px;
            overflow: auto;
            font-family:sans-serif;
            color:black;
        }
      

        .PopupPanel {
            max-Width: 50%;
            /*Height: 720px;*/
            max-height: 85%;
        }
        .form-row {
            padding: 10px 0;
            display: flex;
            justify-content: flex-end;
            padding: 5px;
        }

        .form-row-label {
            padding-right: 10px;
            flex: 1;
            font-size: 15px;
            padding: 5px;
            font-weight: 600;
            letter-spacing: .09em;
            text-transform: uppercase;
            color:white;
            /*background-color:aquamarine;*/
        }
        
        .Popup-row-label {
          padding-right: 10px;
            flex: 1;
            font-size: 13px;
            padding: 5px;
            font-weight: 600;
            letter-spacing: .09em;
            text-transform: uppercase;
            color:black;
            /*background-color:aquamarine;*/
        }
         .Popup-row-label-Heading{
            font-size: 25px;
            font-weight: bold;
            font-family:sans-serif;
            letter-spacing: 1.5px;
            text-transform: uppercase;
            color:#7b0a0a;
        }
        .form-row-input {
            flex: 2;
            justify-content: center;
            align-content: center;
            align-items: center;
        }
        .Popup-form-row-input{
            flex: 2;
            justify-content: center;
            align-content: center;
            align-items: center;
        }
        .form-row-Button {
            flex: 1;
            justify-content: center;
            align-content: center;
            align-items: center;
        }

        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
         .radioButton label{
             margin-left: 5px;
             color :BLACK;
             font-weight:bold;
         }
        .VerifiedLabel {
            padding-right: 10px;
            flex: 1;
            font-size: 15px;
            padding: 10px;
            width: 50%;
            letter-spacing: .09em;
            color: green;
            font-weight: 800;
        }

        .NotVerifiedLabel {
            padding-right: 10px;
            flex: 1;
            font-size: 20px;
            padding: 10px;
            width: 50%;
            font-weight: 300;
            letter-spacing: .09em;
            color: red;
            font-weight: 800;
        }

        .form-tooltip {
            display: block;
            visibility: hidden;
            overflow: hidden;
            box-sizing: border-box;
            height: 0;
            margin-bottom: -8px;
            cursor: help;
            animation-name: fold;
            animation-duration: 500ms;
            animation-timing-function: ease-in;
            animation-direction: reverse;
        }


            .PopupPanel .flex-container {
                margin-bottom: 2%
            }

                .PopupPanel .flex-container .PopupPanel {
                    margin-bottom: 2%
                }

        .PopupPanel .flex-container .form-row{
            padding:0;
        }
        
         .MobileCountDown{
                font-weight:500;
                font-size: 35px;
                text-align: center;
                justify-content: center;
            }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div>
            <asp:textbox id="txt1" runat="server"></asp:textbox>
            <asp:button id="btn1" runat="server" text="verify substring" onclick="btn1_Click" />
            <asp:label id="lbl1" runat="server"></asp:label>
        </div>
        <hr />
        <asp:radiobutton id="rbContactAddressYes" class="radioButton" runat="server" groupname="ContactAddress" text="Yes" autopostback="true" oncheckedchanged="rbContactAddress_CheckedChanged" />
        <asp:radiobutton id="rbContactAddressNo" class="radioButton" runat="server" groupname="ContactAddress" text="No" autopostback="true" oncheckedchanged="rbContactAddress_CheckedChanged" />
        <asp:label id="lbl2" runat="server"></asp:label>
        <hr />
        <asp:label id="lblStatuscode" runat="server"></asp:label>
        <br />
        <hr />
        <asp:button id="btnsepdfgeneratetest" runat="server" text="pdf generate test" onclick="btnsepdfgeneratetest_click" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Visible="false">
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
        <asp:textbox id="TextBox1" runat="server"></asp:textbox>
        <asp:button id="Button1" runat="server" text="verify substring" onclick="Button1_Click" />
        <asp:label id="Label1" runat="server"></asp:label>
        <hr />

        <asp:label id="Label2" runat="server"></asp:label>
        <hr />
        <asp:button id="btnExportExcel" runat="server" text="Export Excel 22-01-22" onclick="btnExportExcel_Click" />
        <asp:button id="btnExportPDFZMApproved" runat="server" text="Export PDF ZM Approved" onclick="btnExportPDFZMApproved_Click" />
        <hr />

        <hr />

        <div>



            <asp:textbox id="txtAppdfgNum" runat="server" maxlengt="1" pattern="[0-9]{1}" />
            <asp:regularexpressionvalidator runat="server" controltovalidate="txtAppdfgNum" validationexpression="[0-9]{1}" errormessage="wrong"></asp:regularexpressionvalidator>

        </div>

        <hr />
        RD Number Test
         <asp:scriptmanager id="ScriptManager1" runat="server"></asp:scriptmanager>
        <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
             <ContentTemplate>--%>
        <div id="divRDNumber" runat="server" visible="true" class="form-row">
            <div class="form-row-label">
                <asp:label id="Label10" class="" runat="server">RD Number(Form - G)<span style="color:red"> *</span><br />ಆರ್.ಡಿ ಸಂಖ್ಯೆ(ನಮೂನೆ - ಜಿ)</asp:label>
            </div>
            <div class="form-row-input">
                <asp:textbox id="txtRDNumber" cssclass="NeoTextBox" runat="server" placeholder="rd number" style="text-transform: uppercase" maxlength="15" autocompletetype="Disabled"></asp:textbox>
                <div id="divRDNumChkError" runat="server" class="DisplayError" style="font-size: 18px; font-weight: bold; color: #7b0000"></div>
            </div>
            <div class="form-row-Botton">
                <asp:button id="btnVerifyRdNumber" runat="server" cssclass="NeoButton" onclick="btnVerifyRDNumber_Click" text="Verify" onpaste="return false" usesubmitbehavior="false" onclientclick="this.disabled='true'; this.value='Please wait...';" />
                <asp:label id="lblRDNumberVerified" visible="false" runat="server" text=" Verified" cssclass=" fa fa-check VerifiedLabel"></asp:label>
            </div>
        </div>

        <%--        <asp:Panel ID="PnlCasteCertificate" runat="server" CssClass="modalPopup PopupPanel" Style="display: none; ">--%>

        <div class="flex-container" runat="server" id="divCasteCertificate">
            <div class="">
                <div class="form-row" style="justify-content: center">
                    <div class="Popup-row-label-Heading">
                        <asp:label id="Label19" class="" style="font-size: 20px; margin-top: 20px;" runat="server" text="Caste And Income Certificate Details"></asp:label>
                    </div>
                </div>
                <div class="form-row">
                    <div class="Popup-row-label">
                        <asp:label id="Label20" runat="server">RD Number<br />ಆರ್.ಡಿ ಸಂಖ್ಯೆ</asp:label>
                    </div>
                    <div class="Popup-row-label">
                        <asp:label id="lblNCGSCNumber" width="40px" runat="server"></asp:label>
                    </div>
                </div>
                <div class="form-row">
                    <div class="Popup-row-label">
                        <asp:label id="Label22" runat="server">Name<br />ಹೆಸರು</asp:label>
                    </div>
                    <div class="Popup-row-label">
                        <asp:label id="lblNCApplicantName" runat="server"></asp:label>
                    </div>
                </div>
                <div class="form-row">
                    <div class="Popup-row-label">
                        <asp:label id="Label24" runat="server">Annual Income<br />ವಾರ್ಷಿಕ ಆದಾಯ</asp:label>
                    </div>
                    <div class="Popup-row-label">
                        <asp:label id="lblNCAnnualIncome" runat="server"></asp:label>
                    </div>
                </div>
                <div class="form-row">
                    <div class="Popup-row-label">
                        <asp:label id="Label39" runat="server">Constituency<span style="color:red"> *</span><br />ಕ್ಷೇತ್ರ</asp:label>
                    </div>
                    <div class="Popup-row-label">
                        <asp:dropdownlist id="drpConst" class="rowMargin txtcolor text-uppercase form-control" autopostback="true" runat="server" clientidmode="Static"></asp:dropdownlist>
                    </div>
                </div>
                <div class="form-row">
                    <div class="Popup-row-label">
                        <asp:label id="Label27" runat="server">Father / Guardian Name<br />ತಂದೆ / ಪೋಷಕರ ಹೆಸರು</asp:label>
                    </div>
                    <div class="Popup-row-label">
                        <asp:label id="lblNCApplicantFatherName" runat="server"></asp:label>
                    </div>
                </div>

                <div class="form-row">
                    <div class="Popup-row-label">
                        <asp:label id="Label29" runat="server">Address<br />ವಿಳಾಸ</asp:label>
                    </div>
                    <div class="Popup-row-label">
                        <asp:label id="lblNCFullAddress" runat="server"></asp:label>
                    </div>
                </div>
                <div class="form-row">
                    <div class="Popup-row-label">
                        <asp:label id="Label9" runat="server">Taluk<br />ತಾಲ್ಲೂಕು</asp:label>
                    </div>
                    <div class="Popup-row-label">
                        <asp:label id="lblNCTaluk" runat="server"></asp:label>
                    </div>
                </div>
                <div class="form-row">
                    <div class="Popup-row-label">
                        <asp:label id="Label23" runat="server">District<br />ಜಿಲ್ಲೆ</asp:label>
                    </div>
                    <div class="Popup-row-label">
                        <asp:label id="lblNCDistrict" runat="server"></asp:label>
                    </div>
                </div>
                <div id="divContactAddressOption" visible="true" runat="server" class="form-row">
                    <div class="Popup-row-label">
                        <asp:label id="Label21" runat="server">Contact Address same as above<span style="color:red"> *</span></asp:label>
                    </div>
                    <div class="Popup-row-label">
                        <%-- <asp:DropDownList ID="drpContactAddress" Visible="false" Class="rowMargin txtcolor text-uppercase NeuoDropdown" runat="server"  AutoPostBack="true">
                                        <asp:ListItem>--SELECT--</asp:ListItem>
                                        <asp:ListItem Value="YES">YES</asp:ListItem>
                                        <asp:ListItem Value="NO">NO</asp:ListItem>
                                    </asp:DropDownList>--%>
                        <asp:radiobutton id="RadioButton1" class="radioButton" runat="server" groupname="ContactAddress" text="Yes" autopostback="true" oncheckedchanged="rbContactAddress_CheckedChanged" />
                        <asp:radiobutton id="RadioButton2" class="radioButton" runat="server" groupname="ContactAddress" text="No" autopostback="true" oncheckedchanged="rbContactAddress_CheckedChanged" />
                    </div>
                </div>
                <div id="divContactAddress" runat="server" visible="false">
                    <div runat="server" class="form-row" style="padding: 1px">
                        <div class="Popup-row-label">
                            <asp:label id="Label25" runat="server">Contact Address<br />ಸಂಪರ್ಕಿಸುವ ವಿಳಾಸ</asp:label>
                        </div>
                        <div class="Popup-row-label">
                            <asp:textbox id="txtContactAddress" cssclass="NeoTextBox" placeholder="contact address" textmode="MultiLine" height="50px" runat="server" onpaste="return false" autocompletetype="Disabled"></asp:textbox>
                        </div>
                    </div>
                    <div runat="server" class="form-row" style="padding: 1px">
                        <div class="Popup-row-label">
                            <asp:label id="Label53" runat="server">District  ಜಿಲ್ಲೆ <span style="color:red"> *</span></asp:label>
                        </div>
                        <div class="Popup-row-label">
                            <asp:dropdownlist id="drpContDistrict" class="rowMargin txtcolor text-uppercase form-control NeuoDropdown" autopostback="true" runat="server" clientidmode="Static">
                                        </asp:dropdownlist>
                        </div>
                    </div>
                    <div runat="server" class="form-row" style="padding: 1px">
                        <div class="Popup-row-label">
                            <asp:label id="Label54" runat="server">Taluk  ತಾಲ್ಲೂಕು <span style="color:red"> *</span></asp:label>
                        </div>
                        <div class="Popup-row-label">
                            <asp:dropdownlist id="drpContTaluk" class="text-uppercase rowMargin txtcolor form-control NeuoDropdown" autopostback="true" runat="server" clientidmode="Static">
                                        </asp:dropdownlist>
                        </div>
                    </div>
                    <div runat="server" class="form-row" style="padding: 1px">
                        <div class="Popup-row-label">
                            <asp:label id="Label55" runat="server">Pin code  ಅಂಚೆ ಸಂಖ್ಯೆ <span style="color:red"> *</span></asp:label>
                        </div>
                        <div class="Popup-row-label">
                            <asp:textbox id="txtContPincode" cssclass="NeoTextBox" placeholder="Pin code" onkeypress="return CheckPinCode(event)" runat="server" forecolor="Black" textmode="Number" maxlength="6" onpaste="return false" autocompletetype="Disabled"></asp:textbox>
                        </div>
                    </div>
                </div>
                <div id="divButtonSubmitApplication" class="form-row" runat="server" style="justify-content: center">
                    <%--<div class="Popup-row-label">
                                </div>--%>
                    <div class="form-row-Botton">
                        <asp:button id="btnNadakachriBack" runat="server" cssclass="NeoButton" text="Back" />
                    </div>
                    <div class="form-row-Botton">
                        <asp:button id="btnSaveContactAddress" runat="server" cssclass="NeoButton" text="Save and Proceed" usesubmitbehavior="false" onclientclick="this.disabled='true'; this.value='Please wait...';" />
                    </div>
                    <div class="form-row-Botton">
                        <asp:button id="btnNadakachriOK" runat="server" cssclass="NeoButton" text="Proceed" onclientclick="return CasteCertificateHidePopup()" />
                    </div>
                </div>

            </div>
        </div>
        <%--   </asp:Panel>

                <asp:LinkButton ID="lnkCasteCertificate" runat="server"></asp:LinkButton>
                <cc1:ModalPopupExtender ID="CasteCertificatePopup" runat="server" TargetControlID="lnkCasteCertificate" PopupControlID="PnlCasteCertificate"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>--%>
        <%--  </ContentTemplate>
            </asp:UpdatePanel>--%>


        Aadhaar Number Test


        <%--Aadhaar Number--%>
        <div class="form-row">
            <div class="form-row-label">
                <asp:label id="Label26" class="" runat="server">Aadhaar Number<span style="color:red"> *</span><br />ಆಧಾರ್ ಸಂಖ್ಯೆ</asp:label>
                <br />
                <%--<asp:Label runat="server" Style="font-size: 8px; color: red;">(As Per Aadhar)</asp:Label>--%>
            </div>
            <%-- TODO onpaste="return false" AutoCompleteType="Disabled" --%>
            <div class="form-row-input">
                <asp:textbox id="txtAadhaarNumber" cssclass="NeoTextBox" runat="server" placeholder="Aadhaar Number" textmode="Number" maxlength="12"></asp:textbox>
                <div id="divAadhaarChkError" class="DisplayError" style="font-size: 18px; font-weight: bold; color: #7b0000"></div>
            </div>
            <div class="form-row-Botton" id="divMovileNumberStatus" runat="server">
                <asp:button id="btnAadhaarGetOTP" runat="server" cssclass="NeoButton" onclick="btnAadhaarGetOTP_Click" text="Get OTP" usesubmitbehavior="false" onclientclick="this.disabled='true'; this.value='Please wait...';" />
            </div>
        </div>
        <%--OTP Verify--%>
        <div id="divMobileOTP" runat="server" visible="TRUE" class="form-row">
            <div class="form-row-label">
                <asp:label id="Label3" class="" runat="server">OTP<br />ಒಟಿಪಿ</asp:label>
            </div>
            <div class="form-row-input">
                <asp:textbox id="txtOTP" cssclass="NeoTextBox" runat="server" maxlength="8" placeholder="otp" onkeypress="return CheckOTP(event)" onpaste="return false" autocompletetype="Disabled"></asp:textbox>
                <div id="divOTPChkError" class="DisplayError" style="font-size: 18px; font-weight: bold; color: #7b0000"></div>
            </div>
            <div class="form-row-Botton">
                <asp:button id="btnVerifyAadhaarOTP" runat="server" cssclass="NeoButton" onclick="btnVerifyAadhaarOTP_Click" text="Verify" onpaste="return false" autocompletetype="Disabled" usesubmitbehavior="false" onclientclick="this.disabled='true'; this.value='Please wait...';" />
            </div>
        </div>



        <%--          <asp:Panel ID="PnlAadhaarDetails" runat="server" CssClass="modalPopup PopupPanel" Style="display: none; width:50%;height:80%; padding: 5px">--%>
        <div class="flex-container">
            <div class="">
                <div class="form-row" style="justify-content: center">
                    <div class="Popup-row-label-Heading">
                        <asp:label id="Label43" class="" style="font-size: 20px; margin-top: 20px" runat="server" text="Aadhaar Details"></asp:label>
                    </div>
                </div>
                <div class="form-row">
                    <%-- <div class="Popup-row-label">
                                    <asp:Label ID="Label51" runat="server">Photo<br />ಭಾವಚಿತ್ರ</asp:Label>
                                </div>--%>
                    <div class="Popup-row-label">
                        <asp:image id="ImgAadhaarPopupPhoto" runat="server" height="160px" width="140px" />
                    </div>
                </div>
                <div class="form-row">
                    <div class="Popup-row-label">
                        <asp:label id="Label44" runat="server">Name<br />ಹೆಸರು</asp:label>
                    </div>
                    <div class="Popup-row-label">
                        <asp:label id="lblAadhaarPopupName" runat="server"></asp:label>
                    </div>
                </div>
                <div class="form-row">
                    <div class="Popup-row-label">
                        <asp:label id="Label46" runat="server">DOB<br />ಜನ್ಮ ದಿನಾಂಕ</asp:label>
                    </div>
                    <div class="Popup-row-label">
                        <asp:label id="lblAadhaarPopupDOB" runat="server"></asp:label>
                    </div>
                </div>
                <div class="form-row">
                    <div class="Popup-row-label">
                        <asp:label id="Label47" runat="server">Gender<br />ಲಿಂಗ</asp:label>
                    </div>
                    <div class="Popup-row-label">
                        <asp:label id="lblAadhaarPopupGender" runat="server"></asp:label>
                    </div>
                </div>
                <div class="form-row">
                    <div class="Popup-row-label">
                        <asp:label id="Label49" runat="server">District<br />ಜಿಲ್ಲೆ</asp:label>
                    </div>
                    <div class="Popup-row-label">
                        <asp:label id="lblAadhaarPopupDistrict" runat="server"></asp:label>
                    </div>
                </div>
                <div class="form-row">
                    <div class="Popup-row-label">
                        <asp:label id="Label50" runat="server">Pincode<br />ಅಂಚೆ ಸಂಖ್ಯೆ</asp:label>
                    </div>
                    <div class="Popup-row-label">
                        <asp:label id="lblAadhaarPopupPincode" runat="server"></asp:label>
                    </div>
                </div>
                <div class="form-row">
                    <div class="Popup-row-label">
                        <asp:label id="Label48" runat="server">State<br />ರಾಜ್ಯ</asp:label>
                    </div>
                    <div class="Popup-row-label">
                        <asp:label id="lblAadhaarPopupState" width="40px" runat="server"></asp:label>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-row-Botton">
                        <asp:button id="btnAadhaarkDetailsBack" runat="server" cssclass="NeoButton" text="Back" />
                        <asp:button id="btnAadhaarkDetailsProceed" runat="server" cssclass="NeoButton" text="Proceed" />
                    </div>
                </div>

            </div>
        </div>
        <%--  </asp:Panel>

                 <asp:LinkButton ID="lnkAadhaarDetails" runat="server"></asp:LinkButton>
                <cc1:ModalPopupExtender ID="AadhaarPopup" runat="server" TargetControlID="lnkAadhaarDetails" PopupControlID="PnlAadhaarDetails"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>--%>
    </form>



</body>
</html>
