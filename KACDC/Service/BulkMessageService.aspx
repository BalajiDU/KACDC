<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulkMessageService.aspx.cs" Inherits="KACDC.Service.BulkMessageService" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Message Service</title>
     <link href="../CustomCSS/ApprovalPageCss/ModalDesign.css" rel="stylesheet" />
    <link href="~/CustomCss/ApprovalPageCss/FormStyles.css" rel="stylesheet" type="text/css" />
    <link href="~/CustomCss/ApprovalPageCss/TopNavBar.css" rel="stylesheet" />
        <link href="../../CustomCSS/ApplicationPage/ApplicationPage.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <style>
* {
  box-sizing: border-box;
}

body {
  font-family: Arial, Helvetica, sans-serif;
}

/* Float four columns side by side */
.column {
  float: left;
  width: 25%;
  padding: 0 10px;
}
.card {
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
  padding: 16px;
  text-align: center;
  background-color: #f1f1f1;
}
.Popupcard {
  padding: 16px;
  text-align: center;
}
.Popupcolumn {
  float: left;
  width: 33%;
  padding: 0 10px;

    /*background-color: white;*/
    border-radius: 20px;
    box-shadow: 1px 1px 2px #cac9c9, -1px -1px 2px #ffffff;
    /*margin: 20px;
            margin-top: 30px;*/
    font-size: 20px;
    align-items: center;
    letter-spacing: 1.5px;
    overflow: auto;
    font-family: sans-serif;
    color: black;
    /*max-Width: 50%;*/
    /*Height: 720px;*/
    max-height: 85%;
    color: whitesmoke;
    backdrop-filter: blur(10px);
    /*-webkit-backdrop-filter: blur(20px);*/
    border: 10px solid #0000005c;
}
.Popupcolumn1 {
  float: left;
  width: 49%;
  padding: 0 10px;

    /*background-color: white;*/
    border-radius: 20px;
    box-shadow: 1px 1px 2px #cac9c9, -1px -1px 2px #ffffff;
    /*margin: 20px;
            margin-top: 30px;*/
    font-size: 20px;
    align-items: center;
    letter-spacing: 1.5px;
    overflow: auto;
    font-family: sans-serif;
    color: black;
    /*max-Width: 50%;*/
    /*Height: 720px;*/
    max-height: 85%;
    color: whitesmoke;
    backdrop-filter: blur(10px);
    /*-webkit-backdrop-filter: blur(20px);*/
    border: 10px solid #0000005c;
}

.Popupcolumn2 {
  float: left;
  width: 99%;
  padding: 0 10px;

    /*background-color: white;*/
    border-radius: 20px;
    box-shadow: 1px 1px 2px #cac9c9, -1px -1px 2px #ffffff;
    /*margin: 20px;
            margin-top: 30px;*/
    font-size: 20px;
    align-items: center;
    letter-spacing: 1.5px;
    overflow: auto;
    font-family: sans-serif;
    color: black;
    /*max-Width: 50%;*/
    /*Height: 720px;*/
    max-height: 85%;
    color: whitesmoke;
    backdrop-filter: blur(10px);
    /*-webkit-backdrop-filter: blur(20px);*/
    border: 10px solid #0000005c;
}
/* Remove extra left and right margins, due to padding */
.row {margin: 0 -5px;
      margin-top:20px
}

/* Clear floats after the columns */
.row:after {
  content: "";
  display: table;
  clear: both;
}

/* Responsive columns */
@media screen and (max-width: 600px) {
  .column {
    width: 100%;
    display: block;
    margin-bottom: 20px;
  }
}

/* Style the counter cards */

</style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="Popup-flex-container">
            <%--<div class="navFormHeading">
                <asp:Label runat="server">WELCOME</asp:Label>
            </div>
            <div class="navFormWelcomeDistrict">
                <asp:Label ID="lblWelcomeDistCW" runat="server" Text="KACDC - Message Service"></asp:Label>
            </div>
            <div class="form-row text-center">
                <div class="Popup-row-input">
                    <asp:TextBox ID="txtMobileNumber1" runat="server" TextMode="MultiLine" CssClass="PopupTextBox" Width="80%" Height="100px" placeholder="Mobile Number" Style="display: inline-block; margin: 0 auto;"></asp:TextBox><br />
                    <asp:TextBox ID="txtMessage1" runat="server" TextMode="MultiLine" CssClass="PopupTextBox" Width="80%" Height="100px" placeholder="Message" Style="display: inline-block; margin: 0 auto;"></asp:TextBox><br />

                    <asp:Button ID="btnSendMessageOld" runat="server" Text="Send Single Message" OnClick="btnSendSingleMessage_Click" class="DownloadButton" />
                    <asp:Button ID="Button2" runat="server" Text="Send Single Unicode Message" OnClick="btnSendSingleUnicodeMessage_Click" class="DownloadButton" />
                    <asp:Button ID="Button1" runat="server" Text="Send Bulk Message (Non Unicode)" OnClick="btnSendServerBulkMessage_Click" class="DownloadButton" />
                    <asp:Label ID="lblCountDisplay" runat="server" Text=""></asp:Label>
                </div>
            </div>--%>
            <asp:Button ID="btnMessageLogout" runat="server" Text="Logout" CssClass="logoutButton" OnClick="btnMessageLogout_Click" Style="margin-right: 2%; width: 25%; position: absolute; right: 0;" />
        </div>
        <div class="flex-container ContantMain" id="divSEApplicationMail" runat="server">
            <div class="NeumorphicDiv" style="background-color: rgba(216, 216, 216, 0.19); border-radius: 25px; width:80%">
                <div class="navFormHeading">
                    <asp:Label runat="server">WELCOME</asp:Label>
                </div>
                <div class="navFormWelcomeDistrict">
                    <asp:Label ID="Label1" runat="server" Text="KACDC - Message Service"></asp:Label>
                </div>
                <%--<div class="form-row" style="width: 60%">
                    <div class="form-row-label">
                        <asp:Label ID="Label12" class="" Style="color: black" runat="server">Message Type</asp:Label><br />
                    </div>
                    <div class="form-row-input">
                        <%--OnCheckedChanged="LoanType_CheckChanged"
                        <asp:RadioButton ID="rbMale" Class="radioButton" runat="server" GroupName="Gender" Text="Single" />
                        <asp:RadioButton ID="rbFemale" Class="radioButton" runat="server" GroupName="Gender" Text="Bulk" />
                        <asp:Label ID="lblGenderError" runat="server" class="DisplayError" Style="font-size: 18px; font-weight: bold; color: #7b0000"></asp:Label>
                    </div>
                    <div class="form-row-Botton" id="div21" runat="server">
                    </div>
                </div>--%>
                <asp:UpdatePanel ID="UpdatePanelMsgService" runat="server" UpdateMode="Conditional">
                    <Triggers>
                    </Triggers>
                    <ContentTemplate>
                        <div class="row">
                            <div class="column">
                                <div class="card">
                                    <h3>Language</h3>
                                    <p>
                                        <asp:RadioButton ID="rbKannada" Class="radioButton" runat="server" GroupName="Language" Text="Kannada" AutoPostBack="true" OnCheckedChanged="Language_CheckedChanged" />
                                        <asp:RadioButton ID="rbEnglish" Class="radioButton" runat="server" GroupName="Language" Text="English" AutoPostBack="true" OnCheckedChanged="Language_CheckedChanged" />
                                    </p>
                                </div>
                            </div>

                            <div class="column">
                                <div class="card">
                                    <h3>Message Type</h3>
                                    <p>
                                        <asp:RadioButton ID="rbSingle" Class="radioButton" runat="server" GroupName="Type" Text="Single" AutoPostBack="true" OnCheckedChanged="Type_CheckedChanged" />
                                        <asp:RadioButton ID="rbBulk" Class="radioButton" runat="server" GroupName="Type" Text="Bulk" AutoPostBack="true" OnCheckedChanged="Type_CheckedChanged" />
                                    </p>
                                </div>
                            </div>

                            <div class="column">
                                <div class="card">
                                    <h3>Target Recipient</h3>
                                    <p>
                                        <asp:RadioButton ID="rbBeneficiary" Class="radioButton" runat="server" GroupName="RecipientType" Text="Beneficiary" AutoPostBack="true" OnCheckedChanged="Recipient_CheckedChanged" />
                                        <asp:RadioButton ID="rbCustom" Class="radioButton" runat="server" GroupName="RecipientType" Text="Custom" AutoPostBack="true" OnCheckedChanged="Recipient_CheckedChanged" />
                                        <asp:RadioButton ID="rbApplicants" Class="radioButton" runat="server" GroupName="RecipientType" Text="Applicants" AutoPostBack="true" OnCheckedChanged="Recipient_CheckedChanged" />
                                    </p>
                                </div>
                            </div>

                            <div class="column">
                                <div class="card">
                                    <h3>Message Category</h3>
                                    <p>
                                        <asp:DropDownList ID="drpCategory" Class="" runat="server" AutoPostBack="true" Style="width: 90%; height: 25px; background-color: #f1f1f1; border-radius: 5px; text-transform: uppercase" OnSelectedIndexChanged="drpCategory_SelectedIndexChanged">
                                            <%--NeuoDropdown--%>
                                        </asp:DropDownList>
                                    </p>

                                </div>
                            </div>


                        </div>


                        <div class="row">
                            <div class="column" style="width: 100%">
                                <div class="card">
                                    <%--<h3>Mobile Number</h3>--%>
                                    <p>
                                        <asp:RadioButton ID="rbDisable" Class="radioButton" runat="server" Checked="true" GroupName="MobEnable" Text="Disable" AutoPostBack="true" OnCheckedChanged="MobEnable_CheckedChanged" />
                                         <asp:RadioButton ID="rbEnable" Class="radioButton" runat="server" GroupName="MobEnable" Text="Enable" AutoPostBack="true" OnCheckedChanged="MobEnable_CheckedChanged" />
                                        <asp:TextBox ID="txtMobileNumber" runat="server" TextMode="MultiLine" CssClass="PopupTextBox" Width="100%" Height="100px" placeholder="Mobile Number" Style="display: inline-block; margin: 0 auto; border: 5px solid; border-color: rgba(216, 216, 216, 0.70)"></asp:TextBox><br />

                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="column" style="width: 100%">
                                <div class="card">
                                    <%-- <h3>Message Type</h3>--%>

                                    <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" CssClass="PopupTextBox" Width="100%" Height="100px" placeholder="Message" Style="display: inline-block; margin: 0 auto; border: 5px solid; border-color: rgba(216, 216, 216, 0.70)"></asp:TextBox><br />
                                </div>
                            </div>
                        </div>


                   






                <div class="row">
                    <div class="column" style="width: 100%">
                        <div class="">
                            <%-- <h3>Message Type</h3>--%>

                            <asp:Button ID="btnSendMessage" runat="server" Text="Send  Message" OnClick="btnSendMessage_Click" class="DownloadButton" Style="background: rgba(216, 216, 216, 0.70); color: brown; height: 40px; font-size: 25px; border-radius: 10px" />
                        </div>
                    </div>
                </div>
                        <div class="row">
                            <div class="column" style="width: 40%; float:right;margin-top:-20px">
                                <div class="">
                                    <%-- <h3>Message Type</h3>--%>

                                    <asp:Button ID="btnRegisterMessageTemplate" runat="server" Text="Register Template" OnClick="btnRegisterMessageTemplate_Click" class="DownloadButton" Style="background: rgba(216, 216, 216, 0.70); color: rgb(30, 117, 0); height: 40px; font-size: 25px; border-radius: 10px" />
                                </div>
                            </div>
                        </div>



                        <asp:Panel ID="PnlRegTemp" runat="server" CssClass="modalPopup" Width="75%" Style="display: none">
                            <div class="Popup-flex-container">
                                <div class="">
                                    <div class="row">
                                        <div class="Popupcolumn1">
                                            <div class="Popupcard">
                                                <h3>Language</h3>
                                                <p>
                                                    <asp:RadioButton ID="rbRegKannada" Class="radioButton" runat="server" GroupName="RegLanguage" Text="Kannada"  OnCheckedChanged="Language_CheckedChanged"  />
                                                    <asp:RadioButton ID="rbRegEnglish" Class="radioButton" runat="server" GroupName="RegLanguage" Text="English" OnCheckedChanged="Language_CheckedChanged"  />
                                                </p>
                                            </div>
                                        </div>

                                        <div class="Popupcolumn1">
                                            <div class="Popupcard">
                                                <h3>User</h3>
                                                <p>
                                                    <asp:RadioButton ID="rbRegKAVDES" Class="radioButton" runat="server" GroupName="RegUser" Text="KAVDES"  />
                                                    <asp:RadioButton ID="rbRegGKACDC" Class="radioButton" runat="server" GroupName="RegUser" Text="GKACDC"  />
                                                </p>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="Popupcolumn">
                                            <div class="Popupcard">
                                                <h3>Template ID</h3>
                                                <p>
                                                    <asp:TextBox ID="txtRegTemplateID" runat="server" TextMode="singleline" CssClass="PopupTextBox" Width="100%" placeholder="Template ID" Style="display: inline-block; margin: 0 auto; border: 5px solid; border-color: rgba(216, 216, 216, 0.70)"></asp:TextBox><br />
                                                </p>
                                            </div>
                                        </div>

                                        <div class="Popupcolumn">
                                            <div class="Popupcard">
                                                <h3>Template Name</h3>
                                                <p>
                                                    <asp:TextBox ID="txtRegTemplateName" runat="server" TextMode="singleline" CssClass="PopupTextBox" Width="100%" placeholder="Template Name" Style="display: inline-block; margin: 0 auto; border: 5px solid; border-color: rgba(216, 216, 216, 0.70)"></asp:TextBox><br />
                                                </p>
                                            </div>
                                        </div>
                                        <div class="Popupcolumn">
                                            <div class="Popupcard">
                                                <h3>Category</h3>
                                                <p>
                                                    <asp:TextBox ID="txtRegCategory" runat="server" TextMode="singleline" CssClass="PopupTextBox" Width="100%" placeholder="Category" Style="display: inline-block; margin: 0 auto; border: 5px solid; border-color: rgba(216, 216, 216, 0.70)"></asp:TextBox><br />
                                                </p>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="Popupcolumn2">
                                            <div class="Popupcard" style="padding: 8px">
                                                <p>
                                                    <asp:TextBox ID="txtRegMessage" runat="server" TextMode="MultiLine" CssClass="PopupTextBox" Width="100%" Height="100px" placeholder="Message" Style="display: inline-block; margin: 0 auto; border: 5px solid; border-color: rgba(216, 216, 216, 0.70)"></asp:TextBox><br />
                                                </p>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-row">
                                        <div class="Popup-row-Button text-center">
                                            <asp:Button ID="btnRegtemplate" runat="server" CssClass="DownloadButton" Text="Submit" OnClick="btnRegtemplate_Click" />
                                            <asp:Button ID="btnRegClear" runat="server" CssClass="ActionButton" Text="Clear" OnClick="btnRegClear_Click" />
                                            <asp:Button ID="Button12" runat="server" CssClass="CancelButton" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>

                <asp:LinkButton ID="lnkRegTemp" runat="server"></asp:LinkButton>
                <cc1:ModalPopupExtender ID="RegTempPopup" runat="server" PopupControlID="PnlRegTemp"
                    TargetControlID="lnkRegTemp" BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
 </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelMsgService" runat="server" DisplayAfter="0">
            <ProgressTemplate>
                <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                    <div style="position: absolute; left: 40%; top: 20%;">
                        <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" style="margin: auto; background: none; display: block; shape-rendering: auto;" width="300px" height="300px" viewBox="0 0 100 100" preserveAspectRatio="xMidYMid">
                            <path fill="none" stroke="#ad0000" stroke-width="8" stroke-dasharray="42.76482137044271 42.76482137044271" d="M24.3 30C11.4 30 5 43.3 5 50s6.4 20 19.3 20c19.3 0 32.1-40 51.4-40 C88.6 30 95 43.3 95 50s-6.4 20-19.3 20C56.4 70 43.6 30 24.3 30z" stroke-linecap="round" style="transform: scale(0.8); transform-origin: 50px 50px">
                                <animate attributeName="stroke-dashoffset" repeatCount="indefinite" dur="2s" keyTimes="0;1" values="0;256.58892822265625"></animate>
                            </path>
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
            </div>
        </div>
    </form>
</body>
</html>
