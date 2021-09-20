<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserTracker.aspx.cs" Inherits="KACDC.Service.UserTracker" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>KACDC Tracker</title>
         <link href="../CustomCSS/ApprovalPageCss/ModalDesign.css" rel="stylesheet" />
    <link href="~/CustomCss/ApprovalPageCss/FormStyles.css" rel="stylesheet" type="text/css" />
    <link href="~/CustomCss/ApprovalPageCss/TopNavBar.css" rel="stylesheet" />
        <link href="../../CustomCSS/ApplicationPage/ApplicationPage.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1">



      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.47/css/bootstrap-datetimepicker.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.24.0/moment.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.47/js/bootstrap-datetimepicker.min.js"></script>

    <script type="text/javascript">
        $(function() {
            $('#dtSart').datetimepicker();
        });
        $(function () {
            $('#dtEnd').datetimepicker();
        });
    </script>

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
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="Popup-flex-container">

                <asp:Button ID="btnMessageLogout" runat="server" Text="Logout" CssClass="logoutButton" OnClick="btnLogout_Click" Style="margin-right: 2%; width: 25%; position: absolute; right: 0;" />
            </div>
            <div class="flex-container ContantMain" id="divSEApplicationMail" runat="server">
                <div class="NeumorphicDiv" style="background-color: rgba(216, 216, 216, 0.19); border-radius: 25px; width: 80%">
                    <div class="navFormHeading">
                        <asp:Label runat="server">WELCOME</asp:Label>
                    </div>
                    <div class="navFormWelcomeDistrict">
                        <asp:Label ID="Label1" runat="server" Text="KACDC - Tracker Service"></asp:Label>
                    </div>

                    <asp:UpdatePanel ID="UpdatePanelMsgService" runat="server" UpdateMode="Conditional">
                        <Triggers>
                        </Triggers>
                        <ContentTemplate>
                            <div class="row">
                                <div class="column">
                                    <div class="card">
                                        <h3>Work</h3>
                                        <p>
                                            <asp:TextBox ID="txtWok" runat="server" ClientIDMode="Static" class="NeuoDropdown" placeholder="Work/Task" Style="width: 100%"> </asp:TextBox>
                                        </p>
                                    </div>
                                </div>
                                <div class="column">
                                    <div class="card">
                                        <h3>Start Time</h3>
                                        <p>
                                            <%--   <asp:TextBox ID="txtZMARReleaseChequeDate" runat="server" ClientIDMode="Static" class="NeuoDropdown" placeholder="DD-MM-YYYY" style="width:100%"> </asp:TextBox>
                                        
                                     <asp:TextBox ID="txtZMARReleasdfgseChequeDate" runat="server" ClientIDMode="Static" class="NeuoDropdown" textmode="DateTime"  style="width:100%"> </asp:TextBox>
                                                        <cc1:CalendarExtender ID="calZMARReleaseChequeDate" PopupButtonID="image" runat="server" TargetControlID="txtZMARReleaseChequeDate" Format="dd-MM-yyyy"></cc1:CalendarExtender>--%>

                                            <div class="form-group">
                                                <div class='input-group date' id='dtSart' runat="server">
                                                    <asp:TextBox type='text' class="form-control" runat="server" ID="txtStart"></asp:TextBox>
                                                    <span class="input-group-addon">
                                                        <span class="glyphicon glyphicon-calendar"></span>
                                                    </span>
                                                </div>
                                            </div>
                                            <p>
                                            </p>
                                            <p>
                                            </p>
                                        </p>
                                    </div>
                                </div>

                                <div class="column">
                                    <div class="card">
                                        <h3>End Time</h3>
                                        <p>
                                            <div class="form-group">
                                                <div class='input-group date' id='dtEnd'>
                                                    <asp:TextBox type='text' class="form-control" runat="server" ID="txtEnd"></asp:TextBox>
                                                    <span class="input-group-addon">
                                                        <span class="glyphicon glyphicon-calendar"></span>
                                                    </span>
                                                </div>
                                            </div>
                                            <p>
                                            </p>
                                            <p>
                                            </p>
                                        </p>
                                    </div>
                                </div>



                                <div class="column">
                                    <div class="card">
                                        <h3>Message Category</h3>
                                        <p>
                                            <asp:DropDownList ID="drpStatus" Class="" runat="server" AutoPostBack="true" Style="width: 90%; height: 25px; background-color: #f1f1f1; border-radius: 5px; text-transform: uppercase">
                                                <asp:ListItem Text="Completed"></asp:ListItem>
                                                <asp:ListItem Text="Pending"></asp:ListItem>
                                                <asp:ListItem Text="Assigned"></asp:ListItem>
                                                <asp:ListItem Text="Discussed"></asp:ListItem>
                                            </asp:DropDownList>
                                        </p>

                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="column" style="width: 100%">
                                    <div class="card">

                                        <asp:TextBox ID="txtDisciption" runat="server" TextMode="MultiLine" CssClass="PopupTextBox" Width="100%" Height="100px" placeholder="Disciption" Style="display: inline-block; margin: 0 auto; border: 5px solid; border-color: rgba(216, 216, 216, 0.70)"></asp:TextBox><br />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="column" style="width: 100%">
                                    <div class="">
                                        <asp:Button ID="btnAddTask" runat="server" Text="Save Work" OnClick="btnAddTask_Click" class="DownloadButton" Style="background: rgba(216, 216, 216, 0.70); color: rgb(30, 117, 0); height: 40px; font-size: 25px; border-radius: 10px" />
                                    </div>
                                </div>
                            </div>
                            <asp:GridView ID="gvSavedTaks" runat="server" class="GridView" AutoGenerateColumns="False"  Style="align-content: center;width:100%" DataKeyNames="Id" BorderColor="#333333" Font-Names="Times New Roman" >
                                
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" Visible="FALSE" ReadOnly="True" SortExpression="Id" />
                                    <asp:BoundField DataField="SlNo" HeaderText="SlNo" SortExpression="SlNo" />
                                    <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                                    <asp:BoundField DataField="Work" HeaderText="Work" SortExpression="Work" />
                                    <asp:BoundField DataField="StartTime" HeaderText="StartTime" SortExpression="StartTime" />
                                    <asp:BoundField DataField="EndTime" HeaderText="EndTime" SortExpression="EndTime" />
                                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                    <asp:BoundField DataField="Discription" HeaderText="Discription" SortExpression="Discription" />
                                </Columns>
                                
                                <HeaderStyle BorderStyle="Outset" Font-Bold="True" Font-Names="Times New Roman" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <PagerStyle Font-Bold="True" Font-Italic="True" Font-Names="Times New Roman" />
                                
                            </asp:GridView>

                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KACDCConnectionString %>" SelectCommand="SELECT * FROM [KACDCTracker] WHERE ([UserName] = @UserName)">
                                <SelectParameters>
                                    <asp:SessionParameter DefaultValue="" Name="UserName" SessionField="Name" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>

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
        </div>
    </form>
</body>
</html>
