<%@ Page Title="Application Information" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="KACDC_AppInfo.aspx.cs" Inherits="KACDC.KACDC_AppInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
       
     
<%--      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KACDCConnectionString %>" SelectCommand="GetArivuData" SelectCommandType="StoredProcedure"></asp:SqlDataSource>--%>
  <style>
      
        .GridView{
            border-collapse:collapse;
            text-align:center;
            width:inherit;
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
        .Neumorphic {
            border-radius: 25px;
            background: #d9d9d9;
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
            font-family: "poppins", sans-serief;
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
            font-family: "poppins", sans-serief;
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
            font-size: 20px;
            font-family: "poppins", sans-serief;
        }

        .NeumorphicDiv {
            border-radius: 25px;
            background: #eeecec;
            box-shadow: 10px 10px 10px #797878, -10px -10px 10px #ffffff;
            display: flex;
            justify-content: center;
            padding: 25px;
            margin: 20px;
            margin-top:10px;
            text-align: center;
            align-items: center;
            letter-spacing: 1.5px;
            font-family: "poppins", sans-serief;
        }

        .flex-container {
            display: flex;
            justify-content: center;
            align-items: center;
        }
        .SectionMarginTop{
            margin-top:0;
        }
        .LogoutButton{
            display: block;
                height: 100%;
                width: 100%;
                line-height: 65px;
                font-size: 20px;
                color: white;
                padding-left: 40px;
                box-sizing: border-box;
                border-bottom: 1px solid black;
                border-top: 1px solid rgba(255,255,255,.1);
                transition: .4s;
                background:transparent;
                color:red;
        }

            .flex-container div {
                text-align: center;
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
       .auto-style5 {
           width: 99%;
           height: 36px;
       }
    </style>
    <script src="Scripts/jquery-3.0.0.js"></script>
    <link rel="stylesheet" type="text/css"   href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.3/css/bootstrap.css" />
<link rel="stylesheet" type="text/css"   href="https://cdn.datatables.net/1.10.21/css/dataTables.bootstrap4.min.css" />
    <link rel="stylesheet" type="text/css"   href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
<link rel="stylesheet" type="text/css"   href="https://cdn.datatables.net/1.10.21/css/dataTables.jqueryui.min.css" />
     <link rel="stylesheet" type="text/css"   href="https://cdn.datatables.net/1.10.7/css/jquery.dataTables.min.css" />
    <script src="https://cdn.datatables.net/1.10.7/js/jquery.dataTables.min.js">  </script>

    <script src="https://code.jquery.com/jquery-3.5.1.js ">  </script>
<script src="https://cdn.datatables.net/1.10.21/js/jquery.dataTables.min.js ">  </script>
<script src="https://cdn.datatables.net/buttons/1.6.2/js/dataTables.buttons.min.js ">  </script>
<script src="https://cdn.datatables.net/buttons/1.6.2/js/buttons.flash.min.js ">  </script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js ">  </script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js ">  </script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js ">  </script>
<script src="https://cdn.datatables.net/buttons/1.6.2/js/buttons.html5.min.js ">  </script>
<script src="https://cdn.datatables.net/buttons/1.6.2/js/buttons.print.min.js">  </script>
    <script src="https://cdn.datatables.net/1.10.7/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/tabletools/2.2.4/js/dataTables.tableTools.min.js"> </script>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.7/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/tabletools/2.2.4/css/dataTables.tableTools.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.21/css/jquery.dataTables.min.css" />
<link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/1.6.2/css/buttons.dataTables.min.css" />


    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.3.1/js/dataTables.buttons.min.js"></script> 
<script type="text/javascript" src="https://cdn.datatables.net/buttons/1.3.1/js/buttons.html5.min.js"></script>
    <style type="text/css">
    .showHideColumn {
        cursor: pointer;
        color:darkblue;
        background-color:rgba(22,158,13,0.05);
        text-transform:uppercase;
        letter-spacing:1px;
    }
    .divOverflow{
        overflow: auto;
    }
</style>

    <%--<script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                url: 'WebServices/SelfEmploymentData.asmx/GetSelfEmployment',
                method: 'post',
                dataType: 'json',
                success: function (data) {
                    var datatableInstance = $('#datatable').dataTable({
                        paging: true,
                        sort: true,
                        searching: true,
                        //scrollY: 700,
                        buttons: [
                            'copyHtml5',
                            'excelHtml5',
                            'csvHtml5',
                            'pdfHtml5'
                        ],
                        data: data,
                        columns: [
                            { 'data': 'ApplicationNumber' },
                            { 'data': 'ApplicantName' },
                            { 'data': 'RDNumber' },
                            { 'data': 'MobileNumber' },
                            { 'data': 'IncomeDoB' },
                            
                            { 'data': 'ParmanentAddress' ,
                                //'searchable': false,
                                'sortable': false
                            },
                            { 'data': 'BankDetails' },
                            { 'data': 'Quota' },
                            {
                                'data': 'Status'
                                 //'render':  {
                                 //   _: '[^ ].CWStatus'
                                 //}
                                //'render': function (data) {
                                //    return data.map(function (o) {
                                //        return o.CWStatus + '' + o.MobileNumber;
                                //    });
                                //}
                            },
                        ]
                    });
                    //button
                    $('#datatable tbody').on( 'click', 'button', function () {
                        var data = table.row( $(this).parents('tr') ).data();
                        alert( data[0] +"'s salary is: "+ data[ 5 ] );
                    } );

                    //column search
                    $('#datatable thead th').each(function () {  
                     var placeHolderTitle = $('#datatable thead th').eq($(this).index()).text();  
                     $(this).html('<input type="text" class="form-control input input-sm" placeholder = "Search ' + placeHolderTitle + '" />');
                    });

                    datatableInstance.api().columns().every(function () {
                        var dataTableColumn = this;
                        var searchTextBoxes = $(this.header()).find('input');

                        searchTextBoxes.on('keyup change', function () {
                            dataTableColumn.search(this.value).draw();
                        });

                        searchTextBoxes.on('click', function (e) {
                            e.stopPropagation();
                        });
                    });
                    //hide show column
                    $('.showHideColumn').on('click', function () {
                        var tableColumn = datatableInstance.column($(this).attr('data-columnindex'));
                        tableColumn.visible(!tableColumn.visible());
                    });
                    $('.showHide').on('click', function () {  
                     var tableColumn = datatableVariable.column($(this).attr('data-columnindex'));  
                     tableColumn.visible(!tableColumn.visible());  
                 });  
                    //print
                    var tableTools = new $.fn.dataTable.TableTools(datatableInstance, {
                        'sSwfPath': '//cdn.datatables.net/tabletools/2.2.4/swf/copy_csv_xls_pdf.swf',
                        'aButtons':  [
                            {
                                'sExtends': 'print',
                                'sButtonText': 'Print',
                                'bShowAll': true,
                                'sFileName': 'Data.xls'
                            },
                            {
                                'sExtends': 'xls',
                                'sButtonText': 'Save as Excel',
                                'bShowAll': true,
                            },
                            {
                                'sExtends': 'pdf',
                                'sButtonText': 'Save as PDF',
                                'bShowAll': true,
                            },
                            'copy',
                            'csv'
                        ]
                    });
                    $(tableTools.fnContainer()).insertBefore('#datatable_wrapper');
                }
            });
        });
    </script>--%>
    <script type="text/javascript">  
     $(document).ready(function () {  
         $.ajax({  
             type: "POST",  
             dataType: "json",  
                url: 'WebServices/SelfEmploymentData.asmx/GetSelfEmployment',
             success: function (data) {  
                 var datatableVariable = $('#datatable').DataTable({  
                     data: data,  
                     columns: [
                            { 'data': 'ApplicationNumber' },
                            { 'data': 'ApplicantName' },
                            { 'data': 'RDNumber' },
                            { 'data': 'MobileNumber' },
                            { 'data': 'IncomeDoB' },
                            
                            { 'data': 'ParmanentAddress' ,
                                //'searchable': false,
                                'sortable': false
                            },
                            { 'data': 'BankDetails' },
                            { 'data': 'Quota' },
                            {
                                'data': 'Status'
                                 //'render':  {
                                 //   _: '[^ ].CWStatus'
                                 //}
                                //'render': function (data) {
                                //    return data.map(function (o) {
                                //        return o.CWStatus + '' + o.MobileNumber;
                                //    });
                                //}
                            },
                        ] 
                 });  
                 $('#datatable tfoot th').each(function () {  
                     var placeHolderTitle = $('#datatable thead th').eq($(this).index()).text();  
                     $(this).html('<input type="text" class="form-control input input-sm" placeholder = "Search ' + placeHolderTitle + '" />');  
                 });  
                 datatableVariable.columns().every(function () {  
                     var column = this;  
                     $(this.footer()).find('input').on('keyup change', function () {  
                         column.search(this.value).draw();  
                     });  
                 });  
                 $('.showHide').on('click', function () {  
                     var tableColumn = datatableVariable.column($(this).attr('data-columnindex'));  
                     tableColumn.visible(!tableColumn.visible());  
                 });  
             }  
         });  
  
     });  
 </script>
    <style>  
    .Button {  
        cursor: pointer;  
        font-size:20px;
        margin-left:3px;
        margin-right:3px;
        border-radius: 5px;
        height:40px;
        border:solid;
        border-color:#c7c7c7;
background: #dbdbdb;
box-shadow:  10px 10px 25px #b0b0b0, 
             -10px -10px 25px #ffffff;

    } 
        .showHide {  
        cursor: pointer;  
        font-size:20px;
        margin:3px;
        border-radius: 5px;
        height:40px;
        border:solid;
        border-color:#c7c7c7;
background: #dbdbdb;
box-shadow:  10px 10px 25px #b0b0b0, 
             -10px -10px 25px #ffffff;

    } 
    .NeumorphicDiv input {
        width: 100%;
        box-sizing: border-box;
    }
    .dataTables_filter input {
    margin-left: 0.5em;
    display: inline-block;
    width: 5px;
    box-sizing: border-box;
     }
    .dataTables_length {
font-size:20px;
    }
    .dataTables_filter{
font-size:20px;
    }
    .dataTables_info {
font-size:20px;
    }
    .dataTables_paginate{
font-size:20px;
    }
    .current{
        font-size:20px;
        margin-left:3px;
        margin-right:3px;
        border-radius: 5px;
        height:40px;
        border:none;
        text-align:center;
        vertical-align:central;
        display: inline-block;
        min-width: 1em;
        padding: 0.5em 1em;
        border-color:#c7c7c7;
background: #dbdbdb;
box-shadow:  10px 10px 25px #b0b0b0, 
             -10px -10px 25px #ffffff;
    }
    .LogoutButton{
            display: block;
                height: 100%;
                width: 100%;
                line-height: 65px;
                font-size: 20px;
                color: white;
                padding-left: 40px;
                box-sizing: border-box;
                border-bottom: 1px solid black;
                border-top: 1px solid rgba(255,255,255,.1);
                transition: .4s;
                background:transparent;
                color:red;
        }
</style>  
        <asp:Button ID="btnLogout" CssClass="LogoutButton" style="margin-left:8px" runat="server" Text="Logout" OnClick="btnLogout_Click" />
    <section id="tabs">
        <div class="align-content-center">
            <div class="col-xs-12 ">
                <nav>
                    <div class="nav nav-tabs nav-fill" id="nav-tab" role="tablist">
                        <a class="nav-item nav-link active" id="nav-homePage-tab" data-toggle="tab" href="#nav-homePage" role="tab" aria-controls="nav-homePage" aria-selected="true">Arivu</a>
                        <a class="nav-item nav-link" id="nav-DM-tab" data-toggle="tab" href="#nav-DM" role="tab" aria-controls="nav-DM" aria-selected="false">Self Employment</a>
                        <a class="nav-item nav-link" id="nav-CEO-Doc" data-toggle="tab" href="#nav-DM-Doc" role="tab" aria-controls="nav-DM" aria-selected="false">CEO Committee Documents</a>
                        <a class="nav-item nav-link" id="nav-Reporting-tab" data-toggle="tab" href="#nav-Reporting" role="tab" aria-controls="nav-Reporting" aria-selected="false">Report</a>
                        <a class="nav-item nav-link" id="nav-Statistics-tab" data-toggle="tab" href="#nav-Statistics" role="tab" aria-controls="nav-Statistics" aria-selected="false">Statistics</a>
                        <a class="nav-item nav-link" id="nav-MPIC-tab" data-toggle="tab" href="#nav-MPIC" role="tab" aria-controls="nav-MPIC" aria-selected="false">MPIC</a>
                    </div>
                </nav>
            </div>
            <div class="">
                <div class="row">
                    <div class="col-xl-12">
                        <div class="tab-content py-3 px-3 px-sm-0" id="nav-tabContent">
                            <div class="tab-pane fade show active" id="nav-homePage" role="tabpanel" aria-labelledby="nav-homePage-tab">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                       
                                        <div  runat="server">
                                            <table class="auto-style5" style="width: 40%">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchArivu" OnTextChanged="txtSearchArivu_TextChanged" runat="server" AutoPostBack="true" Class="rowMargin txtcolor text-uppercase form-control" placeholder="Application Number"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchMobileArivu" OnTextChanged="txtSearchArivu_TextChanged" runat="server" AutoPostBack="true" Class="rowMargin txtcolor text-uppercase form-control" placeholder="Aadhar Number"></asp:TextBox>
                                                    </td>

                                                    <td>
                                                        <asp:DropDownList ID="drpArivuDistrict" runat="server" Class="btn btncolor" Style="border: thin" AutoPostBack="True" OnSelectedIndexChanged="drpArivuDistrict_SelectedIndexChanged"></asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnClear" Text="Clear" runat="server" OnClick="btnClear_Click" Class="btn btn-hover btncolor" />
                                                    </td>
                                                </tr>
                                            </table>

                                        </div>

                                        <div id="divCWArivuRejectReason" runat="server" visible="false">
                                            <asp:ListBox ID="drpArivuRejectReason" Style="width: 35px" SelectionMode="Multiple" runat="server" DataSourceID="SqlArivuRejectCW" DataTextField="Reason" DataValueField="Reason" Height="45px" Width="193px"></asp:ListBox>
                                            <asp:SqlDataSource ID="SqlArivuRejectCW" runat="server" ConnectionString="<%$ ConnectionStrings:KACDCConnectionString %>" SelectCommand="SELECT * FROM [RejectReason]"></asp:SqlDataSource>
                                        </div>
                                        <div class="text-center">
                                            <asp:GridView ID="ArivugvCWApprove" runat="server" OnPageIndexChanging="gvArivu_PageIndexChanging" AutoGenerateColumns="False" AllowPaging="true" DataKeyNames="ApplicationNumber,RDNumber,AadharNum" Style="align-content: center; margin-left: 5px">
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                                                        <ItemTemplate>
                                                            <%# Eval("ApplicationNumber")%>
                                                        </ItemTemplate>
                                                        <HeaderStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="180px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Applicant Name" ItemStyle-Width="220">
                                                        <ItemTemplate>
                                                            <%# Eval("ApplicantName") + "<br />" + Eval("Gender")+ "<br />"+"PH : "+ Eval("PhysicallyChallenged") %>
                                                            <asp:Button ID="btnDispPH" class="btn btn-hover btnSubcolor" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnDispPH_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("PhysicallyChallenged") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="RD Number" ItemStyle-Width="220">
                                                        <ItemTemplate>
                                                            <%--<%# Eval("RDNumber") %>--%><%--<asp:HyperLink ID="lblProductName" runat="server" Text='<%# Eval("RDNumber") %>' NavigateUrl="#" Target="_blank"  ></asp:HyperLink>--%>
                                                            <asp:Button ID="btnCasteIncome" class="btn btn-hover btnSubcolor" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnCasteIncome_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5; padding: 1px" Text='<%# Eval("RDNumber") %>' ToolTip="Caste and Incone Certificate" />
                                                            <asp:Button ID="btnDispAadhar" class="btn btn-hover btnSubcolor" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnDispAadhar_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("AadharNum") %>' ToolTip="Aadhar" />
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
                                                            <%# Eval("EmailID") + "<br />" + Eval("MobileNumber")%>
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
                                                            <%# "A/C No:" %>
                                                            <asp:Button ID="btnDispPassbook" class="btn btn-hover btnSubcolor" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnDispPassbook_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("AccountNumber") %>' />
                                                            <%# "Bank: " + Eval("BankName")+ "<br />" + " Branch: " + Eval("Branch")+ "<br />" + " IFSCCode: " + Eval("IFSCCode")+ "<br />" + " Address: " + Eval("BankAddress")%>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="College Details" ItemStyle-Width="220">
                                                        <ItemTemplate>
                                                            <%# "CET Ticate: "%>
                                                            <asp:Button ID="btnDispCET" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnDispCET_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("CETAdmissionTicateNum") %>' ToolTip="CET Admission Ticate" />
                                                            <%# "<br />"+" Year: " + Eval("CurrentYear") + "<br />" + " Course: " + Eval("Course")+ "<br />" + " College: " + Eval("CollegeName")+ "<br />" + " Prev Year Marks: " + Eval("PrevYearMarks")+ "<br />" + " Address: " + Eval("CollegeAddress")%><%# "<br />" %>
                                                            <asp:Button ID="btnFeeStruct" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnFeeStruct_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# "Fee Structure" %>' ToolTip="Study Certificate" />
                                                            <%# " " %>
                                                            <asp:Button ID="btnDispClgHostel" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnDispClgHostel_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# "Hostel: "+Eval("ClgHostel") %>' ToolTip="Study Certificate" />
                                                            <%# " " %>
                                                            <asp:Button ID="btnStudyCertificate" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnStudyCertificate_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# "Study Cert" %>' ToolTip="Study Certificate" />
                                                            <%# " " %>
                                                            <asp:Button ID="btnMarksCard" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnMarksCard_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# "Marks Card" %>' ToolTip="Study Certificate" />
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="300px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Case Worker" ItemStyle-Width="50">
                                                        <ItemTemplate>
                                                            <%# Eval("CWApprove") + "<br />" + " Reason: " + Eval("RejectReason")%>
                                                        </ItemTemplate>
                                                        <%--<EditItemTemplate>
                                     <asp:TextBox ID="txt1Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="1st Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:TextBox ID="txt2Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="2nd Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:TextBox ID="txt3Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="3rd Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:TextBox ID="txt4Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="4th Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:TextBox ID="txt5Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="5th Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:DropDownList ID="drpQuota" Class="rowMargin txtcolor text-uppercase rowMargin txtcolor text-uppercase form-control" runat="server" ClientIDMode="Static">
                                         <asp:ListItem>--SELECT--</asp:ListItem>
                                         <asp:ListItem Value="General"> General</asp:ListItem>
                                         <asp:ListItem Value="Adyakshara">Adyakshara</asp:ListItem>
                                         <asp:ListItem Value="Government">Government</asp:ListItem>
                                     </asp:DropDownList>
                                 </EditItemTemplate>--%>
                                                        <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="District Manager" ItemStyle-Width="50">
                                                        <ItemTemplate>
                                                            <%# Eval("DMApprove") + "<br />" + " Reason: " + Eval("DMRejectReason")%>
                                                        </ItemTemplate>
                                                        <%--<EditItemTemplate>
                                     <asp:TextBox ID="txt1Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="1st Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:TextBox ID="txt2Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="2nd Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:TextBox ID="txt3Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="3rd Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:TextBox ID="txt4Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="4th Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:TextBox ID="txt5Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="5th Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:DropDownList ID="drpQuota" Class="rowMargin txtcolor text-uppercase rowMargin txtcolor text-uppercase form-control" runat="server" ClientIDMode="Static">
                                         <asp:ListItem>--SELECT--</asp:ListItem>
                                         <asp:ListItem Value="General"> General</asp:ListItem>
                                         <asp:ListItem Value="Adyakshara">Adyakshara</asp:ListItem>
                                         <asp:ListItem Value="Government">Government</asp:ListItem>
                                     </asp:DropDownList>
                                 </EditItemTemplate>--%>
                                                        <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="CEO Committee" ItemStyle-Width="50">
                                                        <ItemTemplate>
                                                            <%# Eval("DMCEOApprove") + "<br />" + " Loan Amount: " + "<br />" + " Y1: " + Eval("Year1Loan") + "<br />" + " Y2: " + Eval("Year2Loan") + "<br />" + " Y3: " + Eval("Year3Loan") + "<br />" + " Y4: " + Eval("Year4Loan") + "<br />" + " Y5: " + Eval("Year5Loan") %>
                                                        </ItemTemplate>

                                                        <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Document Verification" ItemStyle-Width="50">
                                                        <ItemTemplate>
                                                            <%# Eval("DMDocApprove") %>
                                                        </ItemTemplate>

                                                        <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Zonal Manager" ItemStyle-Width="50">
                                                        <ItemTemplate>
                                                            <%# Eval("ZMApprove") %>
                                                        </ItemTemplate>

                                                        <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
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
                            <div class="tab-pane fade" id="nav-DM" role="tabpanel" aria-labelledby="nav-DM-tab">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <div style="display:none">
                                            <table class="auto-style5" style="width: 40%">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchSE" OnTextChanged="txtSESearchAppNum_TextChanged" runat="server" AutoPostBack="true" Class="rowMargin txtcolor text-uppercase form-control" placeholder="Application Number"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchMobileSE" OnTextChanged="txtSESearchMob_TextChanged" runat="server" AutoPostBack="true" Class="rowMargin txtcolor text-uppercase form-control" placeholder="Aadhar Number"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="drpSEDistrict" runat="server" Class="btn btncolor" Style="border: thin" AutoPostBack="true" OnSelectedIndexChanged="drpSEDistrict_SelectedIndexChanged"></asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnClearSE" Text="Clear" runat="server" OnClick="btnClearSE_Click" Class="btn btn-hover btncolor" />
                                                    </td>
                                                </tr>
                                            </table>

                                        </div>
                                        <div class="text-center">
                                            <asp:GridView ID="SECWApprove" Visible="false" runat="server" AllowPaging="true" OnPageIndexChanging="gvSE_PageIndexChanging" AutoGenerateColumns="False" DataKeyNames="ApplicationNumber,RDNumber,AadharNum" Style="align-content: center; margin-left: 5px">
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
                                                            <%# Eval("ApplicantName") + "<br />" + Eval("Gender")+ "<br />"+"PH : "+ Eval("PhysicallyChallenged") %>
                                                            <asp:Button ID="btnSEDispPH" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnSEDispPH_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("PhysicallyChallenged") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="220px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="RD Number" ItemStyle-Width="220">
                                                        <ItemTemplate>
                                                            <%--<%# Eval("RDNumber") %>--%><%--<asp:HyperLink ID="lblProductName" runat="server" Text='<%# Eval("RDNumber") %>' NavigateUrl="#" Target="_blank"  ></asp:HyperLink>--%>
                                                            <asp:Button ID="btnSECasteIncome" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnSECasteIncome_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5; padding: 1px" Text='<%# Eval("RDNumber") %>' ToolTip="Caste and Incone Certificate" />
                                                            <asp:Button ID="btnSEDispAadhar" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnSEDispAadhar_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("AadharNum") %>' ToolTip="Aadhar" />
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
                                                            <%# Eval("EmailID") + "<br />" + Eval("MobileNumber")%>
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
                                                            <%# "A/C No:" %>
                                                            <asp:Button ID="btnSEDispPassbook" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnSEDispPassbook_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("AccountNumber") %>' />
                                                            <%# "Bank: " + Eval("BankName")+ "<br />" + " Branch: " + Eval("Branch")+ "<br />" + " IFSCCode: " + Eval("IFSCCode")+ "<br />" + " Address: " + Eval("BankAddress")%>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Case Worker" ItemStyle-Width="50">
                                                        <ItemTemplate>
                                                            <%# Eval("CWApprove") + "<br />" + " Reason: " + Eval("RejectReason")%>
                                                        </ItemTemplate>
                                                        <%--<EditItemTemplate>
                                     <asp:TextBox ID="txt1Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="1st Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:TextBox ID="txt2Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="2nd Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:TextBox ID="txt3Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="3rd Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:TextBox ID="txt4Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="4th Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:TextBox ID="txt5Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="5th Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:DropDownList ID="drpQuota" Class="rowMargin txtcolor text-uppercase rowMargin txtcolor text-uppercase form-control" runat="server" ClientIDMode="Static">
                                         <asp:ListItem>--SELECT--</asp:ListItem>
                                         <asp:ListItem Value="General"> General</asp:ListItem>
                                         <asp:ListItem Value="Adyakshara">Adyakshara</asp:ListItem>
                                         <asp:ListItem Value="Government">Government</asp:ListItem>
                                     </asp:DropDownList>
                                 </EditItemTemplate>--%>
                                                        <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="District Manager" ItemStyle-Width="50">
                                                        <ItemTemplate>
                                                            <%# Eval("DMApprove") + "<br />" + " Reason: " + Eval("DMRejectReason")%>
                                                        </ItemTemplate>
                                                        <%--<EditItemTemplate>
                                     <asp:TextBox ID="txt1Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="1st Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:TextBox ID="txt2Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="2nd Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:TextBox ID="txt3Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="3rd Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:TextBox ID="txt4Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="4th Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:TextBox ID="txt5Year" Class="rowMargin txtcolor text-uppercase form-control" runat="server" placeholder="5th Year Loan" TextMode="Number" MaxLength="6"/>
                                     <asp:DropDownList ID="drpQuota" Class="rowMargin txtcolor text-uppercase rowMargin txtcolor text-uppercase form-control" runat="server" ClientIDMode="Static">
                                         <asp:ListItem>--SELECT--</asp:ListItem>
                                         <asp:ListItem Value="General"> General</asp:ListItem>
                                         <asp:ListItem Value="Adyakshara">Adyakshara</asp:ListItem>
                                         <asp:ListItem Value="Government">Government</asp:ListItem>
                                     </asp:DropDownList>
                                 </EditItemTemplate>--%>
                                                        <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="CEO Committee" ItemStyle-Width="50">
                                                        <ItemTemplate>
                                                            <%# Eval("DMCEOApprove") + "<br />" + " Loan Amount: " + "<br />"  + Eval("LoanAmount") %>
                                                        </ItemTemplate>

                                                        <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Document Verification" ItemStyle-Width="50">
                                                        <ItemTemplate>
                                                            <%# Eval("DMDocApprove") %>
                                                        </ItemTemplate>

                                                        <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Zonal Manager" ItemStyle-Width="50">
                                                        <ItemTemplate>
                                                            <%# Eval("ZMApprove") %>
                                                        </ItemTemplate>

                                                        <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
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
                                            <div>
                                                <%--<div style="padding: 5px; padding-left: 10px">
                                                    <b>Show/Hide Column : </b>
                                                    <a class="showHideColumn" data-columnindex="0">Application Number</a>
                                                    <a class="showHideColumn" data-columnindex="1">Applicant Name</a>
                                                    <a class="showHideColumn" data-columnindex="2">RD Number</a>
                                                    <a class="showHideColumn" data-columnindex="3">Mobile Number</a>
                                                    <a class="showHideColumn" data-columnindex="4">Income & DOB</a>
                                                    <a class="showHideColumn" data-columnindex="5">ADDRESS</a>
                                                    <a class="showHideColumn" data-columnindex="6">Quota</a>
                                                    <a class="showHideColumn" data-columnindex="7">Status</a>
                                                </div>--%>
                                                <div class="NeumorphicDiv " >
                                                <div class="flex-container">
                                                    <div class="" style="margin-left:5px">
                                                    <label class="NeoNameLabel" style="text-decoration:solid">Show / Hide Details</label></div>
                                                    <div style="font-size:20px">
                                                    <a class="showHide btn" data-columnindex="0">Application Number</a>
                                                    <a class="showHide btn" data-columnindex="1">Applicant Details</a>
                                                    <a class="showHide btn" data-columnindex="2">RD Number</a>
                                                    <a class="showHide btn" data-columnindex="3">Contact Details</a>
                                                    <a class="showHide btn" data-columnindex="4">Income & DOB</a>
                                                    <a class="showHide btn" data-columnindex="5">Address</a>
                                                    <a class="showHide btn" data-columnindex="6">Bank Details</a>
                                                    <a class="showHide btn" data-columnindex="7">Quota</a>
                                                    <a class="showHide btn" data-columnindex="8">Status</a>
                                                   <%-- <a class="showHide btn btn btn-primary" data-columnindex="9">ID</a>
                                                    <a class="showHide btn btn btn-primary" data-columnindex="10">ID</a>
                                                    <a class="showHide btn btn btn-primary" data-columnindex="11">ID</a>
                                                    <a class="showHide btn btn btn-primary" data-columnindex="12">ID</a>
                                                    <a class="showHide btn btn btn-primary" data-columnindex="13">ID</a>--%>
                                                </div></div></div>
                                                <div class="NeumorphicDiv divOverflow" style="border-radius: 8px; padding: 10px; align-content: center; align-items: center;">
                                                    <table id="datatable" class=" nowrap row-border display hover table table-striped table-bordered" style="width:100%;max-width:90%; margin-top:3px; text-align: center;font-size:15px;">
                                                        <thead>
                                                            <tr>
                                                                <th>Application Number</th>
                                                                <th>Applicant Details</th>
                                                                <th>RD Number</th>
                                                                <th style="max-width:120px;word-break:break-all">Contact Details</th>
                                                                <th>Income & DOB</th>
                                                                <th style="max-width:160px;width:160px">Address</th>
                                                                <th style="max-width:160px">Bank Details</th>
                                                                <th>Quota</th>
                                                                <th style="max-width:100px">Status</th>
                                                            </tr>
                                                        </thead>
                                                        <tfoot>
                                                            <tr>
                                                                <th>Application Number</th>
                                                                <th>Applicant Name</th>
                                                                <th>RD Number</th>
                                                                <th>Mobile Number</th>
                                                                <th>Income & DOB</th>
                                                                <th>Address</th>
                                                                <th>Bank Details</th>
                                                                <th>Quota</th>
                                                                <th>Status</th>

                                                            </tr>
                                                        </tfoot>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="tab-pane fade" id="nav-DM-Doc" role="tabpanel" aria-labelledby="nav-DM-Doc">
                                <div class="row flex-container" style="font-size: medium">
                                    <div class="Neumorphic">
                                        <div id="divArivuDoc">
                                            <h2>Arivu</h2>
                                            <asp:GridView ID="GvArivuCEODoc" Style="font-size: 20px" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                                                RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000"
                                                AutoGenerateColumns="false">
                                                <Columns>
                                                    <asp:BoundField DataField="Id" HeaderText="File Number" />
                                                    <asp:BoundField DataField="District" HeaderText="District" />
                                                    <asp:BoundField DataField="DateTime" HeaderText="Uploded Date & Time" />
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkbtnArivuCEODoc" runat="server" Text="Download" OnClick="lnkbtnArivuCEODoc_Click"
                                                                CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="Neumorphic">
                                        <div id="divSEDoc">
                                            <h2>Self Employment</h2>
                                            <asp:GridView ID="GvSECEODoc" runat="server" Style="font-size: 20px" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                                                RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000"
                                                AutoGenerateColumns="false">
                                                <Columns>
                                                    <asp:BoundField DataField="Id" HeaderText="File Number" />
                                                    <asp:BoundField DataField="District" HeaderText="District" />
                                                    <asp:BoundField DataField="DateTime" HeaderText="Uploded Date & Time" />
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkbtnSECEODoc" runat="server" Text="Download" OnClick="lnkbtnSECEODoc_Click"
                                                                CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="nav-Reporting" role="tabpanel" aria-labelledby="nav-Reporting-tab">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="NeumorphicDiv">
                                            <div class="flex-container">
                                                <div class="Neumorphic">
                                                    <div class="">
                                                        <asp:DropDownList ID="drpRepLoanName" runat="server" class="NeuoDropdown" AutoPostBack="True" OnSelectedIndexChanged="drpRepLoanName_SelectedIndexChanged">
                                                            <asp:ListItem Value="ArivuEduLoan">Arivu Educational Loan</asp:ListItem>
                                                            <asp:ListItem Value="SelfEmpLoan">Self Employment Loan</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="Neumorphic">
                                                    <%-- <div class="NestedNeumorphic">
                                                <asp:Label runat="server" Text="Select District"></asp:Label>
                                            </div>--%>
                                                    <div class="">
                                                        <asp:DropDownList ID="drpRepDistrict" runat="server" class="NeuoDropdown" AutoPostBack="True" OnSelectedIndexChanged="drpRepDistrict_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="Neumorphic">
                                                    <div class="">
                                                        <asp:DropDownList ID="drpRepStage" runat="server" class="NeuoDropdown" AutoPostBack="True" OnSelectedIndexChanged="drpRepStage_SelectedIndexChanged">
                                                            <asp:ListItem Value="CWApprove">Case Worker</asp:ListItem>
                                                            <asp:ListItem Value="DMApprove">District Manager</asp:ListItem>
                                                            <asp:ListItem Value="DMCEOApprove">CEO Commitee</asp:ListItem>
                                                            <asp:ListItem Value="DMDocApprove">Document Verification</asp:ListItem>
                                                            <asp:ListItem Value="ZMApprove">Zonal Manager</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="Neumorphic">
                                                    <div class="">
                                                        <asp:DropDownList ID="drpRepStatus" runat="server" class="NeuoDropdown" AutoPostBack="True" OnSelectedIndexChanged="drpRepStatus_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="flex-container">
                                            <asp:GridView ID="gvPrintReport" class="GridView" runat="server" AutoGenerateColumns="False" CssClass="GridView" OnRowDataBound="gvPrintReport_RowDataBound">
                                                <Columns>
                                                    <asp:BoundField ItemStyle-Width="50px" DataField="SlNo" HeaderText="Sl No" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                                    <asp:BoundField ItemStyle-Width="200px" DataField="ApplicationNumber" HeaderText="Application Number" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                                    <asp:BoundField ItemStyle-Width="150px" DataField="ApplicantName" HeaderText="Applicant Name " ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                                    <asp:BoundField ItemStyle-Width="80px" DataField="MobileNumber" HeaderText="Mobile Number" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                                    <%--<asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Status" >
                                                    <ItemTemplate>
                                                        <%#"CW : " + Eval("CWStatus") + "<br />DM : " + Eval("DMStatus")+ "<br /> CEO : " + Eval("CEOStatus")+ "<br />DOC : " + Eval("DOCStatus")+ "<br />ZM : " + Eval("ZMStatus")%>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="160px" />
                                                </asp:TemplateField>--%>
                                                    <asp:BoundField ItemStyle-Width="500px" DataField="" HeaderText="Status" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="NeumorphicDiv">
                                    <div class="flex-container">
                                        <div class="Neumorphic">

                                            <div class="NestedNeumorphic">
                                                <asp:Button ID="btnReportPrint" runat="server" OnClick="btnReportPrint_Click" CssClass="" Text="Print" />
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="nav-Statistics" role="tabpanel" aria-labelledby="nav-Reporting-tab">
                                <div class="col-xs-12 ">
                                    <nav>
                                        <div class="nav nav-tabs nav-fill" id="nav-tabSub" role="tablist">
                                            <a class="nav-item nav-link active" id="nav-home-tab" data-toggle="tab" href="#nav-home" role="tab" aria-controls="nav-home" aria-selected="true">Arivu</a>
                                            <a class="nav-item nav-link" id="nav-profile-tab" data-toggle="tab" href="#nav-profile" role="tab" aria-controls="nav-profile" aria-selected="false">Self Employment</a>
                                        </div>
                                    </nav>
                                </div>

                                <div class="" style="text-align: center">
                                    <div class="row flex-container">
                                        <div class="divOverflow" style="width:100%; padding:20px; ">
                                            <div class="tab-content py-3 px-3 px-sm-0" id="nav-tabContentSub">
                                                <div class="tab-pane fade show active " id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">
                                                    <asp:GridView ID="dgvArivuStat" runat="server" BorderColor="#000066" BorderWidth="5px" CellPadding="1" CellSpacing="1" DataSourceID="FillArivu" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" Font-Underline="False" Height="159px" HorizontalAlign="Center" ForeColor="#666666">
                                                        <FooterStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
                                                        <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Italic="False" Font-Names="Rockwell" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" Font-Underline="False" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                                        <PagerStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
                                                    </asp:GridView>
                                                    <br />
                                                    <div>
                                                        <asp:Button ID="btnArivuReport" runat="server" Text="Print" OnClick="btnArivuReport_Click" />
                                                    </div>
                                                </div>
                                                <div class="tab-pane fade" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">
                                                    <asp:GridView ID="dgvSEStat" runat="server" BorderColor="#000066" BorderWidth="5px" CellPadding="1" CellSpacing="1" DataSourceID="FillSelfEmp" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" Font-Underline="False" Height="159px" HorizontalAlign="Center" ForeColor="#666666">
                                                        <FooterStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
                                                        <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Italic="False" Font-Names="Rockwell" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" Font-Underline="False" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                                        <PagerStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
                                                    </asp:GridView>
                                                    <div>
                                                    <asp:Button ID="btnSEReport" runat="server" Text="Print" OnClick="btnSEReport_Click" />
                                                
                                                    </div>
                                                    </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div>
                    <br />
                    <asp:SqlDataSource ID="FillSelfEmp" runat="server" ConnectionString="<%$ ConnectionStrings:KACDCConnectionString %>" SelectCommand="spGetSEStatistics" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="FillArivu" runat="server" ConnectionString="<%$ ConnectionStrings:KACDCConnectionString %>" SelectCommand="spGetArivuStatistics" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </div>
                            </div>
                            <div class="tab-pane fade" id="nav-MPIC" role="tabpanel" aria-labelledby="nav-MPIC-tab">
                                <div class="col-xs-12 ">
                                    <nav>
                                        <div class="nav nav-tabs nav-fill" id="nav-tabMpic" role="tablist">
                                            <a class="nav-item nav-link active" id="nav-MpicArivu-tab" data-toggle="tab" href="#nav-MpicArivu" role="tab" aria-controls="nav-MpicArivu" aria-selected="true">Arivu</a>
                                            <a class="nav-item nav-link" id="nav-MpicSE-tab" data-toggle="tab" href="#nav-MpicSE" role="tab" aria-controls="nav-MpicSE" aria-selected="false">Self Employment</a>
                                        </div>
                                    </nav>
                                </div>
                                <div class="container">
                                    <div class="row">
                                        <div class="col-md-5">
                                            <div class="tab-content py-3 px-3 px-sm-0" id="nav-tabContentMPIC">
                                                <div class="tab-pane fade show active" id="nav-MpicArivu" role="tabpanel" aria-labelledby="nav-MpicArivu-tab">
                                                    <asp:DataGrid ID="DataGrid1" runat="server" BorderColor="#000066" BorderWidth="5px" CellPadding="1" CellSpacing="1" DataSourceID="FillMPICArivu" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" Font-Underline="False" Height="159px" HorizontalAlign="Center" Width="887px" ForeColor="#666666">
                                                        <FooterStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
                                                        <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Italic="False" Font-Names="Rockwell" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" Font-Underline="False" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                        <PagerStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
                                                    </asp:DataGrid>
                                                </div>
                                                <div class="tab-pane fade" id="nav-MpicSE" role="tabpanel" aria-labelledby="nav-MpicSE-tab">
                                                    <asp:DataGrid ID="dgvArivuView0" runat="server" BorderColor="#000066" BorderWidth="5px" CellPadding="1" CellSpacing="1" DataSourceID="FillMPICSelfEmp" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" Font-Underline="False" Height="159px" HorizontalAlign="Center" Width="887px" ForeColor="#666666">
                                                        <FooterStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
                                                        <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Italic="False" Font-Names="Rockwell" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" Font-Underline="False" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                        <PagerStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
                                                    </asp:DataGrid>
                                                </div>
                                            </div>
                                        </div>
                                                <asp:SqlDataSource ID="FillMPICSelfEmp" runat="server" ConnectionString="<%$ ConnectionStrings:KACDCConnectionString %>" SelectCommand="spGetMpicSE" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                                <asp:SqlDataSource ID="FillMPICArivu" runat="server" ConnectionString="<%$ ConnectionStrings:KACDCConnectionString %>" SelectCommand="spGetMpicArivu" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                                    </div>
                                    <div class="tab-pane fade" id="nav-contact" role="tabpanel" aria-labelledby="nav-contact-tab">
                                    </div>
                                    <div class="tab-pane fade" id="nav-about" role="tabpanel" aria-labelledby="nav-about-tab">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                
                <div class="tab-pane fade" id="nav-contact" role="tabpanel" aria-labelledby="nav-contact-tab">
                </div>
                <div class="tab-pane fade" id="nav-about" role="tabpanel" aria-labelledby="nav-about-tab">
                </div>
            </div>
        </div>
    </section>
</asp:Content>
