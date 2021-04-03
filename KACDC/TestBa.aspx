<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestBa.aspx.cs" Inherits="KACDC.TestBa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
        .NeoTextBox1 {
            box-sizing: border-box;
            width: 180px;
            height: 40px;
            font-size: 20px;
            border: none;
            padding: 14px;
            margin:30px;
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
        .NeoTextBox {
            letter-spacing: .08em;
            box-sizing: border-box;
            width: 90%;
            height: 30px;
            font-size: 16px;
            border-style: solid;
            border-width:3px;
            border-color:#9dff80;
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
        }
    </style>

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
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8"\>
      

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

    <script type="text/javascript">
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
                    $('#example tbody').on( 'click', 'button', function () {
                        var data = table.row( $(this).parents('tr') ).data();
                        alert( data[0] +"'s salary is: "+ data[ 5 ] );
                    } );

                    //column search
                    $('#datatable thead th').each(function () {
                        var title = $('#datatable tfoot th').eq($(this).index()).text();
                        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
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
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#SEDataTable').DataTable( {
            "ajax":{
                url: 'WebServices/SelfEmploymentData.asmx/GetSelfEmployment',
                method: 'post',
                Type: 'json',
                success: function (data) {
                    var datatableInstance = $('#datatable').dataTable({
                                       
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
                    $('#example tbody').on( 'click', 'button', function () {
                        var data = table.row( $(this).parents('tr') ).data();
                        alert( data[0] +"'s salary is: "+ data[ 5 ] );
                    } );

                    //column search
                    $('#datatable thead th').each(function () {
                        var title = $('#datatable tfoot th').eq($(this).index()).text();
                        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
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
            };
        });
    </script>
     <script type="text/javascript">
<!--
    function Check_Click(objRef) {
        //Get the Row based on checkbox
        var row = objRef.parentNode.parentNode;

        //Get the reference of GridView
        var GridView = row.parentNode;

        //Get all input elements in Gridview
        var inputList = GridView.getElementsByTagName("input");

        for (var i = 0; i < inputList.length; i++) {
            //The First element is the Header Checkbox
            var headerCheckBox = inputList[0];

            //Based on all or none checkboxes
            //are checked check/uncheck Header Checkbox
            var checked = true;
            if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                if (!inputList[i].checked) {
                    checked = false;
                    break;
                }
            }
        }
        headerCheckBox.checked = checked;

    }
    function checkAll(objRef) {
        var GridView = objRef.parentNode.parentNode.parentNode;
        var inputList = GridView.getElementsByTagName("input");
        for (var i = 0; i < inputList.length; i++) {
            var row = inputList[i].parentNode.parentNode;
            if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                if (objRef.checked) {
                    inputList[i].checked = true;
                }
                else {
                    if (row.rowIndex % 2 == 0) {
                        row.style.backgroundColor = "#C2D69B";
                    }
                    else {
                        row.style.backgroundColor = "white";
                    }
                    inputList[i].checked = false;
                }
            }
        }
    }
//-->
    </script>
     <script type="text/javascript">
         $(document).ready(function () {
            $('#txtRDNum').keyup(function () {
                var NewAadhar = $(this).val();
                divElement.text(' Enter')
                if (NewAadhar.length != 0) {
                    $.ajax({
                        url: 'WebServices/NadaKacheri_GetData.asmx/GetXmlDataWoDSCV',
                        method: 'post',
                        data: {  NewAadhar },
                        dataType: 'json',
                        success: function (data) {
                            var divElement = $('#divMobileChkError');
                            if (data.AadharNumInUse) {
                                divElement.text(data.NewAadhar + ' already Exist');
                                divElement.css('color', 'red');
                            }
                            else {
                                divElement.text(data.NewAadhar + ' Can Aplay')
                                divElement.css('color', 'green');
                            }
                        },
                        error: function (err) {
                            alert(err);
                        }
                    });
                }
                else {
                    var divElement = $('#divMobileChkError');
                     divElement.text('Mobile Number Must be Enter')
                     divElement.css('color', 'red');
                }
            });
        });
    </script>
   <script>
        $('#btnGetBranch').click(function () {
            getBankDetails();
        });
        var getBankDetails = function () {
            debugger;
            if ($('#IFSCCode').val().length > 0 && $('#IFSCCode').val() != '') {
               $('#IFSCCode').keyup(function () {
                var NewIFSC = $(this).val();
                divElement.text(' Enter')
                if (NewIFSC.length != 0) {
                    $.ajax({
                        url: 'https://ifsc.razorpay.com/'+NewIFSC,
                        method: 'GET',
                        data: {  NewIFSC },
                        dataType: 'json',
                        success: function (data) {
                            var divif = $('#divIFSC');
                            divif.text(data);
                            var divElement = $('#divMobileChkError');
                            if (data.AadharNumInUse) {
                                divElement.text(data.NewAadhar + ' already Exist');
                                divElement.css('color', 'red');
                            }
                            else {
                                divElement.text(data.NewAadhar + ' Can Aplay')
                                divElement.css('color', 'green');
                            }
                        },
                        error: function (err) {
                            alert(err);
                        }
                    });
                }
                else {
                    var divElement = $('#divMobileChkError');
                     divElement.text('Mobile Number Must be Enter')
                     divElement.css('color', 'red');
                }
            });
            }
        }
    </script> 
    Test Nadakacheri
    <div class="container-fluid" >
        <div class="container" >
            <div class="formBox" >
                <div class="row"  style="background-color:rgba(0,0,0,0.05) ; margin-top:-15px">
                    <div class="col-sm-12" >                        
                        <h2 style="margin-top:8px">Update Bank Details</h2>
                        <h5 style="float:right"; width:50%>Application Number cannot modify</h5>
                        <h5 style="float:left"; width:50% >Applicantion Number : <asp:Label runat="server" ID="lblApplicationNumberSE" Text=""></asp:Label></h5>
                    </div>
                </div>
                <div class="row" >
                    <div class="col-sm-4">
                        <div class="">
                            <div>
                                <div class="InputBox">
                                    <asp:TextBox class="input" runat="server" ID="txtApplicantNameSE"  CausesValidation="false" Enabled="false"></asp:TextBox>
                                    <label runat="server" id="lbl1" text="Phy Num">Applicant Name</label>
                                </div>
                                <div class="InputBox">
                                    <asp:TextBox class="input" runat="server" ID="txtAccountNumberSE"  CausesValidation="false" onkeypress="return numeric(event)"></asp:TextBox>
                                   
                                    <label class="Label" runat="server" id="Label1" text="Phy abc">Account Number</label>
                                </div>
                            </div>
                        </div>
                    </div>
                   
                    <div class="col-sm-4" >
                        <div class="">
                            <div>
                                 <div class="InputBox" >
                                    <asp:TextBox class="input" runat="server" ID="txtBankNameSE"  ></asp:TextBox>
                                    <label runat="server" id="Label4" text="Phy Num">Bank</label>
                                </div>
                                 <div class="InputBox" >
                                    <asp:TextBox class="input" runat="server" ID="txtBranchSE"  ></asp:TextBox>
<%--                                    <label runat="server" id="Label5" text="Phy Num">Branch</label>--%>
                                </div>
                               
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="">
                            <div>
                                 <div class="InputBox" >
                                    <asp:TextBox class="input" runat="server" ID="txtIFSCCodeSE"  ></asp:TextBox>
                                    <label runat="server" id="Label2" text="Phy Num">IFSC Code</label>
                                </div>
                                <div class="InputBox">
                                    <asp:TextBox class="input" runat="server" ID="txtBankAddrSE"  ></asp:TextBox>
                                    <label class="Label" runat="server" id="Label3" text="Phy abc">Bank Address</label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row" style="margin-top: -25px">
                    <div class="col-sm-6">
                        <asp:Button ID="btnUpdateBankSE" class="Button" runat="server" style="margin-left:40%;" Text="Update Details" CausesValidation="false" />
                    </div>
                    <div class="col-sm-6">
                        <asp:Button ID="btnClearSE" class="Button" runat="server" Text="Cancel / Clear"  CausesValidation="false" />
                    </div>
                </div>
            </div>
        </div>



         <div>
        <hr />
        jhsdhfbasd<br />
             PDF Generate
        <asp:Button ID="btnpdfprint" runat="server" Text="print pdf" OnClick="btnpdfprint_Click" />
              <asp:Button ID="btnPdfTable" runat="server" Text="print pdf table" OnClick="btnPdfTable_Click" />
             <asp:Button ID="btnIRONPdf" runat="server" Text="Iron PDF" OnClick="btnIRONPdf_Click" />
             <span lang="KN"><asp:Label ID="lblKannadaTest" runat="server">ಕನ್ನಡ ಬರವಣಿಗೆ ಮೇಲ್ಕಂಡ ಮಾಹಿತಿಗಳು </asp:Label></span>
             <br />
             <asp:DropDownList ID="drpCourse" Class="rowMargin txtcolor text-uppercase form-control" style="width: 90%;padding: 2px; margin: 10px" runat="server" ClientIDMode="Static" Visible="True">
                                            <asp:ListItem style="color:red;font-size:large;font-weight: bold;" Value="0">--SELECT--</asp:ListItem>
                                            <asp:ListItem style="color:red;font-size:large;font-weight: bold;" Value="0">UG</asp:ListItem>
                                            <asp:ListItem Value="Engineering">Engineering(B.E)</asp:ListItem>
                                            <asp:ListItem Value="Medical">Medical</asp:ListItem>
                                            <asp:ListItem Value="DentalISMH">Dental & ISMH</asp:ListItem>
                                            <asp:ListItem Value="FarmScience">Farm Science</asp:ListItem>
                                            <asp:ListItem Value="Pharmacy">Pharmacy</asp:ListItem>
                                            <asp:ListItem style="color:red;font-size:large;font-weight: bold;" Value="0">PG</asp:ListItem>
                                            <asp:ListItem Value="Engineering">Engineering(M.E)</asp:ListItem>
                                            <asp:ListItem Value="M'Tech">M'tech</asp:ListItem>
                                            <asp:ListItem Value="PGDM">PGDM</asp:ListItem>
                                            <asp:ListItem style="color:red;font-size:large;font-weight: bold;" Value="0">Ph.D</asp:ListItem>
                                            <asp:ListItem Value="PHD">Technical Ph.D</asp:ListItem>
                                        </asp:DropDownList>
             <asp:DropDownList ID="ddlItems" runat="server">
    </asp:DropDownList>
             <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
             <script type="text/javascript">
            $(function () {
                GroupDropdownlist('ddlCategories')
            });
            function GroupDropdownlist(id) {
                var selectControl = $('#' + id);
                var groups = [];
                $(selectControl).find('option').each(function () {
                    groups.push($(this).attr('data-group'));
                });
                var uniqueGroup = groups.filter(function (itm, i, a) {
                    return i == a.indexOf(itm);
                });
                $(uniqueGroup).each(function () {
                    var Group = jQuery('<optgroup/>', {
                        label: $(this)[0]
                    }).appendTo(selectControl);
                    var grpItems = $(selectControl).find('option[data-group="' + $(this)[0] + '"]');
                    $(grpItems).each(function () {
                        var item = $(this);
                        item.appendTo(Group);
                    });
                });
            }
             </script>
             <p id="demo"><asp:Label ID="lbldate" runat="server"></asp:Label></p>

             <br /><hr />
            
             Message Sending<br />
             <asp:TextBox ID="txtMobileNumber" runat="server" TextMode="MultiLine" Width="1000px" Height="100px" placeholder="Mobile Number"></asp:TextBox><br />
             <asp:TextBox ID="txtMessage" runat="server"  TextMode="MultiLine" Width="1000px" Height="100px" placeholder="Message"></asp:TextBox>
             <asp:Button ID="btnSendMessage" runat="server" Text="Send Message" OnClick="btnSendMessage_Click" /><br />
             <asp:Label ID="lblCountDisplay" runat="server" Text="a"></asp:Label>
             <hr />
              
             <script>
            

            $(function () {

                var d = new Date();
                var n = d.getFullYear();
                var min = n - 18;
                var max = n - 45;
                var d = max + ":" + min;
                $('#<%= txtDOB.ClientID %>').datepicker(
                    {
                        //showOptions: { direction: "down" },
                        yearRange: d,
                        //buttonImage: "/Image/calendar.jfif",
                        buttonImageOnly: true,
                        buttonText: " ",
                        //showOn: "both",
                        maxDate: "-18Y",
                        minDate: "-45Y",
                        showAnim: "slideDown",
                        changeMonth: true,
                        changeYear: true
                    });

            });
            
  </script>
             <p>Date: <input type="text" id="datepicker"><i class="icon-calendar icon-large"></i></p>
             <asp:TextBox ID="txtDOB" runat="server" OnTextChanged="txtDate_TextChanged" AutoPostBack="true"></asp:TextBox>
             <br />
             <asp:Button ID="btnwrap" runat="server" OnClick="btnwrap_Click" Text="wrap" /><br />
             <asp:Label ID="lblwrap1" runat="server"></asp:Label>
             <asp:TextBox runat="server" ID="txtwrap" TextMode="MultiLine" Width="500px" Height="200px"></asp:TextBox>
             <br />
             <asp:CalendarExtender ID="calDOB" PopupButtonID="image" runat="server" TargetControlID="txt_DOB"  Format="dd-MM-yyyy"></asp:CalendarExtender>
<asp:TextBox ID="txt_DOB" runat="server" ClientIDMode="Static" class="text-uppercase rowMargin txtcolor form-control " placeholder="DD-MM-YYYY"> </asp:TextBox>
              <asp:DropDownList ID="drpContDistrict" Class="rowMargin txtcolor text-uppercase form-control" AutoPostBack="true" runat="server" ClientIDMode="Static">
                                                            </asp:DropDownList>
<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
<link href="//netdna.bootstrapcdn.com/font-awesome/3.2.1/css/font-awesome.css" rel="stylesheet">
    </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
            <ContentTemplate>
                <hr />
                <br />
                <div id="divElement"></div>
                <asp:Label ID="lblresult" runat="server"></asp:Label>
                <asp:TextBox ID="txtRDNum" runat="server"></asp:TextBox>
                <asp:Button ID="btnTestGetData" Text="get" runat="server" OnClick="btnTestGetData_Click" />
        <br />
        decoded: <asp:Label ID="lbldecode" runat="server"></asp:Label>
        <asp:Button ID="btnDisplayOutside" runat="server" Text="DisplayOutside" OnClick="btnDisplayOutside_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>

        <div id="divOutside" runat="server" visible="false"> 
            kahbdf ajsdhf iasdf
        </div>
        <hr />
        <div class="form-row">
    <div class="col-md-8">
        <div class="form-group">
            <div id="divIFSC"></div>
            <asp:Label ID="lblIFSCData" runat="server"></asp:Label>

            <input class="form-control py-4" id="IFSCCode" 
                   placeholder="Enter IFSC Cide" />
            <asp:TextBox runat="server" ID="txtIFSC"></asp:TextBox>
        </div>
    </div>
    <div class="col-md-4">
        <div class="form-group">
            <label class="small mb-1"></label>
            <button id="btnGetBranch" class="btn btn-primary btn-block mt-2">Check IFSC Code</button>
            <asp:Button runat="server" id="btnGetBankData" Text=" IFSC Code" OnClick="btnGetBankData_Click" />
        </div>
    </div>
</div> 
        <asp:GridView ID = "GridView1" runat = "server">
</asp:GridView>
        <hr />
    </div>
    <div style="display:none">
        <table id="SEDataTable" class=" nowrap row-border display hover table table-striped table-bordered" style="margin-left: 5px; text-align: center">
            <thead>
                <tr>
                    <th>Application Number</th>
                    <th>Applicant Name</th>
                    <th>RD Number</th>
                    <th>Mobile Number</th>
                    <th>Income & DOB</th>
                    <th>ADDRESS</th>
                    <th>Quota</th>
                    <th>Status</th>
                </tr>
            </thead>
            <tfoot>
                <tr>
                    <th>Application Number</th>
                    <th>Applicant Name</th>
                    <th>RD Number</th>
                    <th>Mobile Number</th>
                    <th>Income & DOB</th>
                    <th>ADDRESS</th>
                    <th>Quota</th>
                    <th>Status</th>

                </tr>
            </tfoot>
        </table>
    </div>
    <div style="display:none">
        <table id="datatable" class=" nowrap row-border display hover table table-striped table-bordered" style="margin-left: 5px; text-align: center">
            <thead>
                <tr>
                    <th>Application Number</th>
                    <th>Applicant Name</th>
                    <th>RD Number</th>
                    <th>Mobile Number</th>
                    <th>Income & DOB</th>
                    <th>ADDRESS</th>
                    <th>Quota</th>
                    <th>Status</th>
                </tr>
            </thead>
            <tfoot>
                <tr>
                    <th>Application Number</th>
                    <th>Applicant Name</th>
                    <th>RD Number</th>
                    <th>Mobile Number</th>
                    <th>Income & DOB</th>
                    <th>ADDRESS</th>
                    <th>Quota</th>
                    <th>Status</th>

                </tr>
            </tfoot>
        </table>
    </div>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnConvert" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <asp:TextBox runat="server" ID="txtInput" placeholder="Input"></asp:TextBox>

            <asp:Button runat="server" Text="Convert" ID="btnConvert" OnClick="btnConvert_Click" />
            <asp:Label runat="server" ID="lblOutput"></asp:Label><br />
            <asp:Button runat="server" Text="Inside OutSide" ID="btnSessionUpdate" OnClick="btnSessionUpdate_Click" />


            <div class="flex-container">
                        <div class="NeumorphicDiv">
                            <div class="form-row">
                                <div class="form-row-label-Heading" style="background-color: aquamarine;">
                                    <asp:Label ID="Label6" class="" runat="server" Text="Self employment application"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-row-label">
                                    <asp:Label ID="Label26" class="" runat="server">Mobile Number<br />ಮೊಬೈಲ್ ಸಂಖ್ಯೆ</asp:Label><br />
                                    <%--<asp:Label runat="server" Style="font-size: 8px; color: red;">(As Per Aadhar)</asp:Label>--%>
                                </div>
                                <%-- TODO onpaste="return false AutoCompleteType="Disabled" --%>
                                <div class="form-row-input">
                                    <asp:TextBox ID="txtApplicantMobileNumber" CssClass="NeoTextBox" runat="server" onpaste="return false" MaxLength="10" onkeypress="return CheckMobileNumber(event)" Title="As Per Aadhaar"></asp:TextBox>
                                    <div id="divMobileChkError" class="DisplayError"></div>
                                </div>
                                <div class="form-row-Botton" id="divMovileNumberStatus" runat="server">
                                    <asp:Button ID="btnGetOTP" runat="server" CssClass="NeoButton" OnClick="btnGetOTP_Click" Text="Get OTP" />
                                    <asp:Label ID="lblVerifiedMobile" Visible="false" runat="server" Text=" Verified" CssClass=" fa fa-check VerifiedLabel"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>







        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button runat="server" Text="Session Update OutSide" ID="Button1" OnClick="btnSessionUpdate_Click" />
    Display Quota Selection
    <div>
       <%-- <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>--%>
                <div class="NeumorphicDiv">
                    <asp:GridView ID="gvZMSERelease" runat="server" class="GridView" AutoGenerateColumns="False" DataKeyNames="ApplicationNumber,ApplicantName" Style="align-content: center;">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk" runat="server" onclick="Check_Click(this)" AutoPostBack="true" OnCheckedChanged="chk_CheckedChanged" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                                <ItemTemplate>
                                    <%# Eval("ApplicationNumber") %>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="240px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Applicant Name" ItemStyle-Width="220">
                                <ItemTemplate>
                                    <%# Eval("ApplicantName") %>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Bank Details" ItemStyle-Width="220">
                                <ItemTemplate>
                                    <%# "A/C No: " + Eval("AccountNumber")%>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                            </asp:TemplateField>
                            
                        </Columns>
                    </asp:GridView>
                </div>
                <hr />

                selected Application
        <asp:Button runat="server" Text="Show" OnClick="ViewApplication" />
        <div class="NeumorphicDiv">
            <asp:GridView ID="gvSelected" runat="server" class="GridView" AutoGenerateColumns="False" DataKeyNames="ApplicationNumber,ApplicantName" Style="align-content: center;">
                <Columns>
                    <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                        <ItemTemplate>
                            <%# Eval("ApplicationNumber") %>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="240px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Applicant Name" ItemStyle-Width="220">
                        <ItemTemplate>
                            <%# Eval("ApplicantName") %>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Bank Details" ItemStyle-Width="220">
                        <ItemTemplate>
                            <%# "A/C No: " + Eval("AccountNumber")%>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                    </asp:TemplateField>
                    
                </Columns>
            </asp:GridView>
        </div>

       <%-- <script type="text/javascript">

                var t;
                window.onload = resetTimer;
                document.onkeypress = resetTimer;

                function logout() {
                    alert("You are now logged out.")
                    location.href = 'Logoff.php'
                }
                function resetTimer() {
                    clearTimeout(t);
                    t = setTimeout(logout, 6000) //logs out in 10 min
                }

        </script>--%>


        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <h3 runat="server" visible="false">Session Idle:&nbsp;<span id="MinutesIdle"><span id="secondsIdle"></span>&nbsp;seconds.</h3>
                <asp:LinkButton ID="lnkFake" runat="server" />
                    <asp:ModalPopupExtender ID="mpeTimeout" BehaviorID ="mpeTimeout" runat="server" PopupControlID="pnlPopup" TargetControlID="lnkFake"
                        OkControlID="btnYes" CancelControlID="btnNo" BackgroundCssClass="modalBackground" OnCancelScript="SessionExpireSoon()" OnOkScript = "ResetSession()">
                    </asp:ModalPopupExtender>

                
                <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">
                    <div class="header">
                        Session Expiring!
                    </div>
                    <div class="body">
                        Your Session will expire in&nbsp;<span id="seconds"></span>&nbsp;seconds.<br />
                        Do you want to reset?
                    </div>
                    <div class="footer" style="align-items:center">
                        <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="yes" />
                        <asp:Button ID="btnNo" runat="server" Text="No" CssClass="no" />
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
         
        <hr />
       
        <hr />
        <center>
<div>

</div>

<div>

</div>
</center>
<%--        <script type="text/javascript">
                function SessionExpireAlert(timeout) {
                    var seconds = timeout / 1000;
                    var Minutes = timeout % 60;
                    document.getElementsByName("MinutesIdle").innerHTML = Minutes;
                    //document.getElementsByName("secondsIdle").innerHTML = seconds;
                    document.getElementsByName("seconds").innerHTML = seconds;
                    setInterval(function () {
                        seconds--;
                        document.getElementById("seconds").innerHTML = seconds;
                        document.getElementById("secondsIdle").innerHTML = seconds;
                        //document.getElementById("MinutesIdle").innerHTML = Minutes;
                    }, 1000);
                    setTimeout(function () {
                        //Show Popup before 20 seconds of timeout.
                        $find("mpeTimeout").show();
                    }, timeout - 20 * 1000);
                    setTimeout(function () {
                        window.location = "Expired.aspx";
                        //PageMethods.AlertFromServer();
                    }, timeout);
                };
                function ResetSession() {
                    //Redirect to refresh Session.
                    window.location = window.location.href;
                }
                function SessionExpireSoon() {
                    //Redirect to refresh Session.
                    document.getElementById("/*Count*/Down").innerHTML = "Session Will Expire Now";
                }


            //1111111111111111
//            $(function() {
//    var timeout = 15; // in seconds
//    $(document).bind("idle.idleTimer", function() {
//    // function you want to fire when the user goes idle
//     $.timeoutDialog({ timeout: 0.25, countdown: 15, logout_redirect_url: 'http://www.google.com', restart_on_yes: true });
//    });
//    $(document).bind("active.idleTimer", function() {
//    // function you want to fire when the user becomes active again
//    });
//    $.idleTimer(timeout);
//});
        </script>--%>
        
        <br />
                
        <iframe src="MapHandler.ashx?pdf=text.pdf" id="application" runat="server" width="80%" height="500" ></iframe>
        
        <div id="dvTable">
    <table >
        <tr>
            <th scope="col" style="width: 120px;background-color:#D20B0C">
                Customer Id
            </th>
            <th scope="col" style="width: 150px;background-color:#D20B0C">
                Name
            </th>
            <th scope="col" style="width: 100px;background-color:#D20B0C">
                Country
            </th>
        </tr>
        <tr>
            <td>
                ALFKI
            </td>
            <td>
                Maria Anders
            </td>
            <td>
                Germany
            </td>
        </tr>
        <tr>
            <td>
                ANATR
            </td>
            <td>
                Ana Trujillo
            </td>
            <td>
                Mexico
            </td>
        </tr>
    </table>
</div>
<asp:HiddenField ID="hfGridHtml" runat="server" />
<asp:Button ID="btnExport" runat="server" Text="Export To PDF XML" OnClick="ExportToPDF" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
    $(function () {
        $("[id*=btnExport]").click(function () {
            $("[id*=hfGridHtml]").val($("#Grid").html());
        });
    });
</script>
        <br />
       
                           <div id = "Grid">
                                            <table runat="server" class="auto-style1" border="1" id="tblPreview">
                                                <tr>
                                                    <td class="auto-style2" colspan="2" style="text-align: center">
                                                        <asp:Image ID="GOK" runat="server" Height="86px" Width="85px" ImageUrl="~/Image/GOK.png" />
                                                    </td>
                                                    <td class="auto-style14" colspan="2">
                                                        <strong>
                                                        <asp:Label ID="Label5" runat="server" Text="KARNATAKA ARYA VYASYA COMMUNITY DEVELOPMANT CORPORATION"></asp:Label>
                                                        <br />
                                                        <asp:Label ID="Label7" runat="server" style="text-align:center" Text="Self Employment Loan Application"></asp:Label>
                                                        </strong>
                                                    </td>
                                                    <td colspan="2" style="text-align: center">
                                                        <asp:Image ID="Image4" runat="server" Height="86px" Width="85px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style3">&nbsp;</td>
                                                    <td colspan="2" class="auto-style4">&nbsp;</td>
                                                    <td colspan="2" class="auto-style7">&nbsp;</td>
                                                    <td class="auto-style12">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style3">
                                                        <asp:Label ID="lblDispAppNum"  runat="server">Application Number<br />ಅರ್ಜಿ ಸಂಖ್ಯೆ</asp:Label>
                                                        </td>
                                                    <td colspan="2" class="auto-style4">
                                                         <asp:Label ID="lblApplicationNum"  runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="2" class="auto-style7">
                                                        <asp:Label ID="lblDispDate"  runat="server">Application Date<br />ಅರ್ಜಿ ದಿನಾಂಕ</asp:Label>
                                                        </td>
                                                    <td class="auto-style12">
                                                        <asp:Label ID="lblApplicationDate" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style3">NAME<br />ಹೆಸರು</td>
                                                    <td colspan="2" class="auto-style4">
                                                        <asp:Label ID="lblName" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="2" class="auto-style7">&nbsp;</td>
                                                    <td rowspan="5" class="auto-style5">
                                                        <asp:Image ID="ImgCandPhoto" runat="server" Height="220px" Width="200px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style3">Father / Guardian Name<br />ತಂದೆ / ರಕ್ಷಕರ ಹೆಸರು</td>
                                                    <td colspan="2" class="auto-style4">
                                                        <asp:Label ID="lblFatherName" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="2" class="auto-style7">&nbsp;</td>
                                                </tr>
                                                
                                                <tr>
                                                    <td class="auto-style3">Gender<br />ಲಿಂಗ</td>
                                                    <td colspan="2" class="auto-style4">
                                                        <asp:Label ID="lblGender" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="2" class="auto-style7">&nbsp;</td>
                                                </tr>
                                                <tr >
                                                     
                                                    <td class="auto-style3">
                                                        <asp:Label id="lblWiDi" Visible="false" runat="server">Widowed<br />ವಿಧವೆ<hr />Divorced<br />ವಿಚ್ಚೇದನ</asp:Label>

                                                    </td>
                                                    <td colspan="2" class="auto-style4">
                                                        <asp:Label Visible="false" ID="lblWidowed" runat="server"></asp:Label><br />
                                                         <asp:Label Visible="false" ID="lblDivorced" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="2" class="auto-style7">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style3">DOB<br />ಜನ್ಮ ದಿನಾಂಕ</td>
                                                    <td colspan="2" class="auto-style4">
                                                        <asp:Label ID="lblDOB" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="2" class="auto-style7">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style8">Physically Challenged</td>
                                                    <td colspan="2" class="auto-style11">
                                                        <asp:Label ID="lblPhysicallyCha" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="2" class="auto-style8">RD Number</td>
                                                    <td class="auto-style10">
                                                        <asp:Label ID="lblRDNum" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style8">Anual Income<br />ವಾರ್ಷಿಕ ಆದಾಯ</td>
                                                    <td colspan="2" class="auto-style11">
                                                        <asp:Label ID="lblAnualIncome" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="2" class="auto-style8">Purpose of Loan<br />ಸಾಲದ ಉದ್ದೇಶ</td>
                                                    <td class="auto-style10">
                                                        <asp:Label ID="lblPurpose" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style3">Mobile Number<br />ಮೊಬೈಲ್ ಸಂಖ್ಯೆ</td>
                                                    <td colspan="2" class="auto-style4">
                                                        <asp:Label ID="lblMobileNum" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="2" class="auto-style7">Alternate Number<br />ಪರ್ಯಾಯ ಮೊಬೈಲ್ ಸಂಖ್ಯೆ</td>
                                                    <td class="auto-style12">
                                                        <asp:Label ID="lblAlternateNum" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style3">Emai ID<br />ಇ-ಮೇಲ್ ಐಡಿ</td>
                                                    <td colspan="2" class="auto-style4">
                                                        <asp:Label ID="lblEmailID" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="2" class="auto-style7">Aadhar Number<br />ಆಧಾರ್ ಸಂಖ್ಯೆ</td>
                                                    <td class="auto-style12">
                                                        <asp:Label ID="lblAadhar" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style3">Occupation<br />ಉದ್ಯೋಗ</td>
                                                    <td colspan="2" class="auto-style4">
                                                        <asp:Label ID="lblOccupation" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="2" class="auto-style7">&nbsp;</td>
                                                    <td class="auto-style12">&nbsp;</td>
                                                </tr>
                                                 <tr>
                                                    <td class="auto-style8">Contact Address<br />ಸಂಪರ್ಕ ವಿಳಾಸ</td>
                                                    <td colspan="2" class="auto-style13">
                                                        <asp:Label ID="lblContactAddr" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="2" class="auto-style13">Parmanent Address<br />ಶಾಶ್ವತ ವಿಳಾಸ</td>
                                                    <td class="auto-style10">
                                                        <asp:Label ID="lblParmanentAddr" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style3">District<br />ಜಿಲ್ಲೆ</td>
                                                    <td colspan="2" class="auto-style4">
                                                        <asp:Label ID="lblContDistrict" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="2" class="auto-style7">District<br />ಜಿಲ್ಲೆ</td>
                                                    <td class="auto-style12">
                                                        <asp:Label ID="lblParDistrict" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td class="auto-style3">Taluk<br />
                                                        ತಾಲ್ಲೂಕು</td>
                                                    <td colspan="2" class="auto-style4">
                                                        <asp:Label ID="lblContTaluk" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="2" class="auto-style7">Taluk<br />
                                                        ತಾಲ್ಲೂಕು</td>
                                                    <td class="auto-style12">
                                                        <asp:Label ID="lblParTaluk" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td class="auto-style3">Pin code<br />ಪಿನ್ ಕೋಡ್</td>
                                                    <td colspan="2" class="auto-style4">
                                                        <asp:Label ID="lblContPincode" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="2" class="auto-style7">Pin code<br />ಪಿನ್ ಕೋಡ್</td>
                                                    <td class="auto-style12">
                                                         <asp:Label ID="lblParPincode" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                
                                                    <td class="auto-style3">&nbsp;</td>
                                                    <td colspan="2" class="auto-style4">&nbsp;</td>
                                                    <td colspan="2" class="auto-style7">Constituency<br />ಕ್ಷೇತ್ರ</td>
                                                    <td class="auto-style12">
                                                        <asp:Label ID="lblParConstituency" runat="server"></asp:Label>
                                                    </td>
                                                </tr>

                                               <tr>
                                                    <td class="auto-style3">&nbsp;</td>
                                                    <td colspan="2" class="auto-style4">&nbsp;</td>
                                                    <td colspan="2" class="auto-style7">&nbsp;</td>
                                                    <td class="auto-style12">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style3" style="text-decoration: underline;"><strong>Bank Details<br />ಬ್ಯಾಂಕ್ ವಿವರಗಳು</strong></td>
                                                    <td colspan="2" class="auto-style4">&nbsp;</td>
                                                    <td colspan="2" class="auto-style7">&nbsp;</td>
                                                    <td class="auto-style12">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style3">&nbsp;</td>
                                                    <td colspan="2" class="auto-style4">&nbsp;</td>
                                                    <td colspan="2" class="auto-style7">&nbsp;</td>
                                                    <td class="auto-style12">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style3">Account Holder Name<br />ಖಾತೆದಾರರ ಹೆಸರು</td>
                                                    <td colspan="2" class="auto-style4">
                                                        <asp:Label ID="lblAccountHolder" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="2" class="auto-style7">A/C Number<br />ಖಾತೆ ಸಂಖ್ಯೆ</td>
                                                    <td class="auto-style12">
                                                        <asp:Label ID="lblAccountNum" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style3">Bank <br />ಬ್ಯಾಂಕ್</td>
                                                    <td colspan="2" class="auto-style4">
                                                        <asp:Label ID="lblBank" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="2" class="auto-style7">Branch<br />ಶಾಖೆ</td>
                                                    <td class="auto-style12">
                                                        <asp:Label ID="lblBranch" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style3">IFSC Code<br />ಐಎಫ್‌ಎಸ್‌ಸಿ ಕೋಡ್</td>
                                                    <td colspan="2" class="auto-style4">
                                                        <asp:Label ID="lblIFCSCode" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="2" class="auto-style7">Address<br />ವಿಳಾಸ</td>
                                                    <td class="auto-style12">
                                                        <asp:Label ID="lblBankAddr" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style3">&nbsp;</td>
                                                    <td colspan="2" class="auto-style4">&nbsp;</td>
                                                    <td colspan="2" class="auto-style7">&nbsp;</td>
                                                    <td class="auto-style12">&nbsp;</td>
                                                </tr>
                                               
                                                <tr>
                                                    <td class="auto-style3">&nbsp;</td>
                                                    <td colspan="2" class="auto-style4">&nbsp;</td>
                                                    <td colspan="2" class="auto-style7">&nbsp;</td>
                                                    <td class="auto-style5">
                                                        <asp:Image ID="ImgApplicantSignature" runat="server" Height="65px" Width="250px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                   <td colspan="6"><p> I hereby provide my consent to Karnataka Arya Vysya Community Development Corporation, (Government of Karnataka Undertaking), to use my Aadhaar number for performing all such validations which may be, required to verify the correctness of the data either provided by me or associated with me under schemes with whom I am enrolled for. I understand that the use of my Aadhaar number will be restricted to the extent required for efficient delivery of benefits to me by the State Government.  <br />ಕರ್ನಾಟಕ ಸರ್ಕಾರದ ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ ಸಮುದಾಯ ಸಭಿವೃಧಿ ನಿಗಮ ಕ್ಕೆ ನನ್ನ ಆಧಾರ್ ಸಂಖ್ಯೆಯನ್ನು ಬಳಸಲು ನಾನು ಈ ಮೂಲಕ ನನ್ನ ಒಪ್ಪಿಗೆ ಯನ್ನು ನೀಡುತ್ತೇನೆ, ಅದು ನನ್ನಿಂದ ಒದಗಿಸಲಾದ ಅಥವಾ ನನ್ನೊಂದಿಗೆ ಸಂಯೋಜಿತವಾಗಿರುವ ಮಾಹಿತಿ ನಿಖರತೆಯನ್ನು ಪರಿಶೀಲಿಸಲು ಅಗತ್ಯವಿರುವ ಎಲ್ಲ ಮೌಲ್ಯ ಮಾಪನ ಗಳನ್ನು ನಿರ್ವಹಿಸಲು ಅಗತ್ಯವಾಗಿರುತ್ತದೆ. ನನ್ನ ಆಧಾರ್ ಸಂಖ್ಯೆಯ ಬಳಕೆ ಯನ್ನು ರಾಜ್ಯ ಸರ್ಕಾರವು ನನಗೆ ಸವಲತ್ತುಗಳನ್ನು ಸಮರ್ಥವಾಗಿ ತಲುಪಿಸಲು ಮಿತಗೊಂಡಿರುತ್ತದೆ ಎಂದು ನಾನು ಅರ್ಥಮಾಡಿಕೊಂಡಿದ್ದೇನೆ</p>
                                                </td>
                                                </tr>
                                                 <tr>
                                                   <td colspan="6"><p> I hereby certify that the above furnished information is true to my knowledge. I shall abide by the terms and conditions of the sanction of the Self Employment Loan. If any discrepancies are found later, I agree to take legal action against me.<br />ಈ ಮೇಲ್ಕಂಡ ಮಾಹಿತಿಗಳು ನನಗೆ ತಿಳಿದ ಮಟ್ಟಿಗೆ ಸತ್ಯ ಮತ್ತು ಸರಿಯಾಗಿವೆಯೆಂದು ಪ್ರಮಾಣಿಕರಿಸುತ್ತೇನೆ. ಒಂದು ವೇಳೆ ಮೇಲ್ಕಂಡ ಮಾಹಿತಿಗಳು ಸುಳ್ಳು ಎಂದು ಕಂಡುಬಂದಲ್ಲಿ ನನ್ನ ವಿರುದ್ಧ ಕಾನೂನು ರೀತಿ ಕ್ರಮ ಜರುಗಿಸಲು ನಾನು ಒಪ್ಪಿರುತ್ತೇನೆ.</p>
                                               </td>
                                                </tr>
                                                 <tr>
                                                    <td colspan="6">&nbsp;</td>
                                                </tr>
                                            </table>
                                           </div>

      <%--  <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.js"></script>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.js"></script>
<script type="text/javascript" src="js/jquery.idle-timer.js"></script>
<script type="text/javascript" src="js/timeout-dialog.js"></script>--%>
         <%--   </ContentTemplate>
        </asp:UpdatePanel>--%>
<%--        <p id="CountDown"></p>--%>
<%--       <script>
            $(document).ready(function () {
                 CreateCountDown()
            });
            // Set the date we're counting down to
            function CreateCountDown() {
                var countDownDate = new Date();
                countDownDate.setMinutes(countDownDate.getMinutes() + 1);
                // Update the count down every 1 second
                var x = setInterval(function () {

                    // Get today's date and time
                    var now = new Date().getTime();

                    // Find the distance between now and the count down date
                    var distance = countDownDate - now;

                    // Time calculations for days, hours, minutes and seconds
                    var days = Math.floor(distance / (1000 * 60 * 60 * 24));
                    var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
                    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
                    var seconds = Math.floor((distance % (1000 * 60)) / 1000);

                    // Output the result in an element with id="demo"
                    document.getElementById("CountDown").innerHTML = "" + minutes + "m " + seconds + "s ";
                    document.getElementById("Popupseconds").innerHTML = "" + minutes + "m " + seconds + "s ";
                    
                     //If the count down is over, write some text 
                    //if (minutes == 0 && seconds <50) {
                    //    clearInterval(x);
                    //    document.getElementById("CountDown").innerHTML = "";
                    //    $find("mpeTimeout").show();
                    //    //document.getElementById("CountDown").innerHTML = "EXPIRED";
                    //    //window.location = window.location.href;
                    //    //CreateCountDown()
                    //}
                    //setTimeout(function () {
                    //    //Show Popup before 20 seconds of timeout.
                    //    $find("TimeoutPopup").show();
                    //}, timeout - 1 * 1000);
                }, 1000);
            }
            //function ResetSession() {
            //        //Redirect to refresh Session.
            //    window.location = window.location.href;
            //     CreateCountDown()
            //}
        </script>--%>
    </div>
   
    
    
</asp:Content>
