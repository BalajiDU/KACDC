<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AadhaarServiceTest.aspx.cs" Async="true" Inherits="KACDC.AadhaarServiceTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css">  
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>  
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js"></script> 

      <link href="../CustomCSS/ApprovalPageCss/ModalDesign.css" rel="stylesheet" />
    <link href="~/CustomCss/ApprovalPageCss/FormStyles.css" rel="stylesheet" type="text/css" />
    <link href="~/CustomCss/ApprovalPageCss/LogoNameAnimation.css" rel="stylesheet" />
    <link href="~/CustomCss/ApprovalPageCss/SideNavBar.css" rel="stylesheet" />
    <link href="~/CustomCss/ApprovalPageCss/ToggleButton.css" rel="stylesheet" />
    <link href="~/CustomCss/ApprovalPageCss/TopNavBar.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div> 
            <asp:TextBox ID="txtAadhaar" runat="server"></asp:TextBox>
            <asp:Button ID="btnAadhaarGetOTP" runat="server" Text="Get OTP" OnClick="btnAadhaarGetOTP_Click"  UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
            <asp:Button ID="btnGetToken" runat="server" Text="Get Token" OnClick="btnGetToken_Click" />
            <asp:Button ID="btnVerifyAge" runat="server" Text="VerifyAge" OnClick="btnVerifyAge_Click" />
            <asp:TextBox ID="txtAadhaarOTP" runat="server"></asp:TextBox>
            <asp:Button ID="btnAadhaarOTPVerify" runat="server" Text="Varify OTP" OnClick="btnAadhaarOTPVerify_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';"/>
            <br />
            OTP trans ID : <asp:Label runat="server" ID="lblTransID"></asp:Label><br />
            Token Up : <asp:Label runat="server" ID="lblToken"></asp:Label>
        </div>

         <br />
        <hr />
        <asp:Button runat="server" Text="Export PDF" ID="btnPDFGenerate" OnClick="btnPDFGenerate_Click" />
        <br />
        <asp:Button ID="Button4" runat="server" Text="Update Taluk" OnClick="btnUpdateTaluk_Click" /><br />
        <asp:UpdatePanel ID="upID" runat="server">
            <ContentTemplate>
                <asp:Button ID="Button5" runat="server" Text="Download Excel" OnClick="btnDownloadExcel_Click" /><br />
                <asp:Label runat="server" ID="lblFileStatus"></asp:Label><br />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress AssociatedUpdatePanelID="upID" runat="server" DisplayAfter="0">
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
        <hr />
            
             Message Sending<br />
             <asp:TextBox ID="txtMobileNumber" runat="server" TextMode="MultiLine" Width="1000px" Height="100px" placeholder="Mobile Number"></asp:TextBox><br />
             <asp:TextBox ID="txtMessage" runat="server"  TextMode="MultiLine" Width="1000px" Height="100px" placeholder="Message"></asp:TextBox>
             <asp:Button ID="btnSendMessage" runat="server" Text="Send Single Message" OnClick="btnSendMessage_Click1" /><br />
             <asp:Button ID="Button1" runat="server" Text="Send Server Bulk Message" OnClick="btnSendMessage_Click2" /><br />
             <asp:Button ID="Button3" runat="server" Text="Send Bulk Message" OnClick="btnSendMessage_Click" /><br />
             <asp:Label ID="lblCountDisplay" runat="server" Text="a"></asp:Label>
             <hr />


        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <Triggers>
       <asp:PostBackTrigger ControlID="btnOutside" />
   </Triggers>
            <ContentTemplate>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                <asp:Button ID="btnOutside" runat="server" Text="outside Button" OnClick="Button1_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <div runat="server" id="divoutside" visible="false">
            <div id="test2"   runat="server">

            <asp:Label ID="Label2" runat="server" Text="Label here"></asp:Label>
            <asp:Button ID="Button2" runat="server" Text="Update Button" OnClick="Button1_Click" OnClientClick="divviZ()" />
                </div>
        </div>
        <script type="text/javascript">
            function ToggleVisibility(elementID) {
                var element = document.getElementByID(elementID);

                if (element.style.display = 'none') {
                    element.style.display = 'inherit';
                }
                else {
                    element.style.display = 'none';
                }
            }
            //Sys.WebForms.PageRequestManager.getInstance().add_pageLoading(PageLoadingHandler);
            //function PageLoadingHandler(sender, args) {
            //    var dataItems = args.get_dataItems();
            //    if ($get('Label1') !== null)
            //        $get('Label1').innerHTML = dataItems['Label1'];
            //    if ($get('Label2') !== null)
            //        $get('Label2').innerHTML = dataItems['Label2'];
            //}

        </script>
        <asp:FileUpload ID="FileUpload1" runat="server" />
<asp:Button ID="btnUpload1" runat="server" Text="Upload"    onclick="btnUpload_Click" />
<hr />
<asp:Image ID="Image1" Visible = "false" runat="server" Height = "100" Width = "100" />
        <asp:Button ID="Value" runat="server" Text="value"    onclick="Value_Click" />

        <hr />
     <%--   <input id="uploadFile" placeholder="Choose File" disabled="disabled" />
<div class="fileUpload btn btn-primary">
    <%--<span>Upload</span>
    <input id="uploadBtn" type="file" class="upload" />
    <br />
    <label class="">
    <span><strong>Upload Image</strong></span>
    <asp:FileUpload ID="FileUpload2" runat="server" >
    </asp:FileUpload>
</label>--%>
    <br />
    <hr />
    <div class="form-group">  
                        <label>Choose File:</label>  
                        <div class="input-group">  
                            <div class="custom-file">  
                                <asp:FileUpload ID="FileUpload3" runat="server" CssClass="custom-file-input" />  
                                <label class="custom-file-label"></label>  
                            </div>  
                            <div class="input-group-append">  
                                <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-secondary" OnClick="btnUploadfile_Click" />  
                            </div>  
                        </div>  
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>  
                    </div>  

        <script type="text/javascript">
            document.getElementById("uploadBtn").onchange = function () {
                document.getElementById("uploadFile").value = this.value;
            };
        </script>
        <hr />
          <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
           
            <ContentTemplate>
                <asp:TextBox ID="txtCollegeCode" runat="server" OnTextChanged="txtCollegeCode_TextChanged" AutoPostBack="true"  ></asp:TextBox>
                <asp:TextBox ID="txtCollegeName" runat="server" ></asp:TextBox>
                <asp:TextBox ID="txtCollegeAddress" runat="server" ></asp:TextBox>
                <div id="divAadhaarChkError"></div>

                <asp:Label ID="lblresp" runat="server"></asp:Label>
                </ContentTemplate>
              </asp:UpdatePanel>
        <script type="text/javascript">
            function AttactEvent() {
                var txt = document.getElementById("<%=txtCollegeCode.ClientID %>");
                txt.setAttribute("onkeyup", txt.getAttribute("onchange"));
                txt.setAttribute("onchange", "");
            }
            window.onload = function () {
                AttactEvent();
                var prm = Sys.WebForms.PageRequestManager.getInstance();
                if (prm != null) {
                    prm.add_endRequest(function (sender, e) {
                        if (sender._postBackSettings.panelsToUpdate != null) {
                            AttactEvent();
                        }
                    });
                }
            };

        </script>
        <script type="text/javascript">
            function SetFocus(id) {
                window.onload = function () {
                    var ctl = document.getElementById(id);
                    ctl.focus();
                    ctl.value = ctl.value;
                }
            }
        </script>
        <script type="text/javascript">
            function setCursorPosition(element, pos) {
                
                var ctrl = document.getElementById(element);

                if (ctrl.setSelectionRange) {
                    ctrl.focus();
                    ctrl.setSelectionRange(pos, pos);
                    //document.getElementById("txtCollegeName").value = CName;
                //document.getElementById("txtCollegeAddress").value = pos;
                }
                else if (ctrl.createTextRange) {
                    var range = ctrl.createTextRange();
                    range.collapse(true);
                    range.moveEnd('character', pos);
                    range.moveStart('character', pos);
                    range.select();
                    //document.getElementById("txtCollegeName").value = CName;
                //document.getElementById("txtCollegeAddress").value = pos;
                }
            }
        </script>
    </form>
</body>
</html>
