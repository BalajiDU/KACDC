<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminApprove.aspx.cs" Inherits="KACDC.AdminApprove" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Approval</title>
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
        body{
            font-family:sans-serif;
            background:#ededed;
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
    </style>
    <style>
       .divOverflow{
        overflow: auto;
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
            margin-top: 10px;
            text-align: center;
            align-items: center;
            letter-spacing: 1.5px;
            font-family: "poppins", sans-serief;
            width:98%;
        }

        .flex-container {
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .SectionMarginTop {
            margin-top: 0;
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

        .flex-container div {
            text-align: center;
        }

        .NeoButton {
            border-radius: 7px;
            height:40px;
            width:150px;
            font-size: 16px;
            background: transparent;
            border: none;
            outline: none;
            color: #fff;
            background: rgba(3,154,244,0.8);
            cursor: pointer;
            border-style: none;
            outline: none;
            background: #eeecec;
            color: black;
            flex-wrap: wrap;
            display:flex;
            margin-left:10px;
            -webkit-appearance: button;
            outline: none;
            box-shadow: 8px 8px 10px #797878, -8px -8px 10px #ffffff;
        }

            .NeoButton:hover {
                box-shadow: 5px 5px 10px #d4d2d2, -5px -5px 10px #ffffff;
            }

            .NeoButton:active {
                box-shadow: inset 5px 5px 10px #d4d2d2, inset -5px -5px 10px #ffffff;
            }

        .NeoTextBox {
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

            .NeoTextBox:focus {
                box-shadow: inset 2px 2px 2px #e2e0e0, inset -2px -2px 2px #faf8f8;
            }

            .PopupTextBox{
            box-sizing: border-box;
            width: 280px;
            
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
    <style>
        @import url('https://fonts.googleapis.com/css?family=Roboto:300,400,400i,500');

        * {
            padding: 0;
            margin: 0;
            list-style: none;
            text-decoration: none;
        }

        body {
            font-family: 'Roboto', sans-serif;
            border-radius: 5px;
            background: #ededed;
        }

        .sidebar {
            position: fixed;
            width: 250px;
            height: 100%;
            z-index: 100;
            top: 0;
            background: #042331;
            transition: width .5s ease;
            box-shadow: 4px 7px 10px rgba(0,0,0,.4);
            cursor: pointer;
            &:hover

        {
            width: 300px;
        }

        @media screen and (min-width: 600px) {
            width: 80px;
        }

        }

        .sidebar header {
            font-size: 28px;
            line-height: 70px;
            text-align: center;
            background: #063146;
            user-select: none;
            color: #ababab;
            font-weight: bold;
        }

            .sidebar header span {
                animation: animate 1s linear infinite;
            }

        header span {
        }

            header span:nth-child(1) {
                animation-delay: 0s;
            }

            header span:nth-child(2) {
                animation-delay: 0.2s;
            }

            header span:nth-child(3) {
                animation-delay: 0.3s;
            }

            header span:nth-child(4) {
                animation-delay: 0.4s;
            }

            header span:nth-child(5) {
                animation-delay: 0.5s;
            }

        @keyframes animate {
            0%,80% {
                color: #ababab;
                text-shadow: none;
            }

            100% {
                color: #fff;
                text-shadow: 0 0 10px #fff, 0 0 20px #fff, 0 0 40px #fff, 0 0 80px #fff, 0 0 120px #fff, 0 0 160px #fff,
            }
        }


        .sidebar ul a {
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
        }

        ul li:hover a {
            padding-left: 50px;
        }

        .sidebar ul a i {
            margin-right: 16px;
        }

        label #btn, label #cancel {
            position: absolute;
            background: #042331;
            border-radius: 3px;
            cursor: pointer;
        }

        label #btn {
            left: 40px;
            top: 25px;
            font-size: 35px;
            color: white;
            padding: 6px 12px;
            transition: all .5s;
        }

        label #cancel {
            z-index: 1111;
            left: -195px;
            top: 17px;
            font-size: 30px;
            color: #0a5275;
            padding: 4px 9px;
            transition: all .5s ease;
        }

        section {
            background: url(bg.jpeg) no-repeat;
            background-position: center;
            background-size: cover;
            height: 100vh;
            transition: all .9s;
            margin-left: 280px;
        }

        .mainmenu {
        }

        .mainmenu, .submenu {
            list-style: none;
            padding: 0;
            margin: 0;
            height: 100%;
            letter-spacing: 2px;
        }

            /* make ALL links (main and submenu) have padding and background color */
            .mainmenu a {
                display: block;
                background-color: #CCC;
                text-decoration: none;
                padding: 10px;
                color: white;
                background: #042331;
                transition: width .9s ease;
                z-index: 100;
                top: 0;
            }

                /* add hover behaviour */
                .mainmenu a:hover {
                    background-color: #063145;
                }

            .mainmenu li:hover .submenu {
                display: block;
                max-height: 500px;
            }

            /*
  we now overwrite the background-color for .submenu links only.
  CSS reads down the page, so code at the bottom will overwrite the code at the top.
*/

            .submenu a {
                background-color: #063145;
            }

                /* hover behaviour for links inside .submenu */
                .submenu a:hover {
                    background-color: #084a69;
                }

        /* this is the initial state of all submenus.
  we set it to max-height: 0, and hide the overflowed content.
*/
        .submenu {
            overflow: hidden;
            max-height: 0;
            -webkit-transition: all 0.5s ease-out;
        }

        header {
            background-color: white;
        }
    </style>
    <script type="text/javascript">
        //$('#myTab a').on('click', function (e) {
        //  e.preventDefault()
        //  $(this).tab('show')
        //})

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

            BlockUI("<%=PnlAdminReason.ClientID %>");
            $.blockUI.defaults.css = {};
        });
        function ZMARHidepopup() {
            $find("ZMARRejectPopup").hide();
            return false;
        }
    </script>

    <script type="text/javascript">
        function CheckNumber(evt,Amount) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (evt.keyCode == 9 || charCode == 8 || charCode == 37 || charCode == 39)
                return true;
            if (charCode > 31 && (((charCode >= 48 && charCode <= 57) || (e.keyCode >= 96 && e.keyCode <= 105)) || charCode == 46)) {
                if (Amount.value.length <= 5) {
                    return true;
                } else {
                    alert('Amount Must be less then 100000');
                    return true;
                }

            }
            else {
                alert(charCode+'Please Enter Numeric values.');
                return false;
            }

        }

    </script>
    <link href="NewScript/bootstrap-multiselect.css" rel="stylesheet" />
    <script src="NewScript/bootstrap-multiselect.js"></script>
    <link href="NewScript/bootstrap.min.css" rel="stylesheet" />
    <script src="NewScript/bootstrap.min.js"></script>
    <link href="NewScript/bootstrap1.min.css" rel="stylesheet" />
    <script src="NewScript/bootstrap3.min.js"></script>
    <script src="NewScript/jquery.js"></script>
    <script src="NewScript/jquery.min.js"></script>
    <script src="NewScript/jquery2.min.js"></script>
    <script src="NewScript/jquery1.min.js"></script>
    <script src="NewScript/jquery3.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/1.11.2/jquery.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>   
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link href="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>
    <%--<script src="//code.jquery.com/jquery-1.12.0.min.js"></script>
    <script src="//code.jquery.com/jquery-migrate-1.2.1.min.js"></script>--%>

   <script type="text/javascript" src="Scripts/jquery.blockUI.js"></script>
    <script type="text/javascript" src="Scripts/jquery-1.3.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
                <asp:Button ID="btnLogout" CssClass="Button" style="margin-left:20px; width:100px;border-color:red;margin-top:10px"  runat="server" Text="Logout" OnClick="btnLogout_Click" />

        <asp:ScriptManager runat="server"></asp:ScriptManager>

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="NeumorphicDiv">
                    <div class="divOverflow">
                        <asp:GridView ID="ArivugvZMApprove" runat="server" class="GridView" AutoGenerateColumns="False" DataKeyNames="ApplicationNumber,ApplicantName,Year1Loan,Year2Loan,Year3Loan,Year4Loan,Year5Loan" Style="align-content: center;" >
                            <Columns>
                                <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="30" >
                                    <ItemTemplate>
                                        <%# Eval("ApplicationNumber")%>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle"  />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Applicant Name" ItemStyle-Width="80">
                                    <ItemTemplate>
                                        <%# Eval("ApplicantName") + "<br />" + Eval("Gender")+ "<br />"+"PH : "+ Eval("PhysicallyChallenged") %>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="RD Number" ItemStyle-Width="80">
                                    <ItemTemplate>
                                        <%# "RD Number: " + Eval("RDNumber")+ "<br />" + " Aadhar: " + Eval("AadharNum")%>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Anual Income &amp; DOB" ItemStyle-Width="80">
                                    <ItemTemplate>
                                        <%# Eval("AnualIncome") + "<br />" + Eval("DoB")%>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"  />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="EmailID &amp; Mobile Number" ItemStyle-Width="80">
                                    <ItemTemplate>
                                        <%# Eval("EmailID") + "<br />" + Eval("MobileNumber")%>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="text-center text-center font-weight-bold"  />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Address" ItemStyle-Width="80">
                                    <ItemTemplate>
                                        <%# Eval("ParmanentAddress") + "<br />" + Eval("ParDistrict")+"(D)"+ "<br />" + Eval("ParTaluk")+"(T)"+ "<br />" + Eval("ParConstituency")+"(C)"+ "<br />" + Eval("ParPincode")+"(P)"%>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"  />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Bank Details" ItemStyle-Width="80">
                                    <ItemTemplate>
                                        <%# "A/C No: " + Eval("AccountNumber")+ "<br />"%>
                                        <%# "Bank: " + Eval("BankName")+ "<br />" + " Branch: " + Eval("Branch")+ "<br />" + " IFSCCode: " + Eval("IFSCCode")+ "<br />" + " Address: " + Eval("BankAddress")%>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="College Details" ItemStyle-Width="80">
                                    <ItemTemplate>
                                        <%# "CET Ticate: "+Eval("CETAdmissionTicateNum") + "<br />"%>
                                        <%# "<br />"+" Year: " + Eval("CurrentYear") + "<br />" + " Course: " + Eval("Course")+ "<br />" +" College Hostel: " + " ClgHostel: " + Eval("Course") + Eval("CollegeName")+ "<br />" + " Prev Year Marks: " + Eval("PrevYearMarks")+ "<br />" + " Address: " + Eval("CollegeAddress") +"<BR /> "%>
                                     
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Quota & Instalment" ItemStyle-Width="90px">
                                    <ItemTemplate>
                                        <%# Eval("Quota")+"<br />"%>
                                        <%# "1st : ("+Eval("Year1Loan")+")<br />"%>
                                        <%# "2nd : ("+Eval("Year2Loan")+")<br />"%>
                                        <%# "3rd : ("+Eval("Year3Loan")+")<br />"%>
                                        <%# "4th : ("+Eval("Year4Loan")+")<br />"%>
                                        <%# "5th : ("+Eval("Year5Loan")+")"%>
                                    </ItemTemplate>

                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Edit" ItemStyle-Width="80">
                                    <ItemTemplate>
                                        <asp:Button ID="btnAdminEditLoan" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnAdminEditLoan_Click" ShowHeader="True" Text="Loan Amount" />
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Reject" ItemStyle-Width="80">
                                    <ItemTemplate>
                                        <asp:Button ID="btnAdminReject" runat="server" class="btn btn-hover btnModcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnAdminReject_Click" ShowHeader="True" Text="Reject" />
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Approve" ItemStyle-Width="50">
                                    <ItemTemplate>
                                        <asp:Button ID="btnAdminApprove" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnAdminApprove_Click" CausesValidation="false" ShowHeader="True" Text="Approve" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                    </EditItemTemplate>
                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>

                    </div>
                </div>


                <asp:Panel ID="PnlAdminReason" runat="server" CssClass="modalPopup" Width="650px" Height="380px" Style="display: none">
                    <div style="text-align: center; font-size: 25px; letter-spacing: 2px;">
                        <asp:Label Font-Bold="true" ID="Label23" runat="server" CssClass="form-row-label" Style="text-align: center" Text="Reason"></asp:Label>
                    </div>
                    <br />
                    <div class="">
                        <div class="flex-row">
                            <div class="form-row">
                                <div class="form-row-label">
                                    <asp:Label ID="Label24" runat="server" Text="Application Number"></asp:Label>
                                </div>
                                <div class="form-row-input">
                                    <asp:Label ID="lblAdminRejApplicationNumber" Width="40px" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-row-label">
                                    <asp:Label ID="Label25" runat="server" Text="Applicant Name"></asp:Label>
                                </div>
                                <div class="form-row-input">
                                    <asp:Label ID="lblAdminRejApplicationName" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-row-label">
                                    <asp:Label ID="Label26" runat="server" Text="Reason"></asp:Label>
                                </div>
                                <div class="form-row-input">
                                    <asp:TextBox ID="txtAdminRejectReason" CssClass="PopupTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    <asp:Label runat="server" ID="lblAdminRejectError" Style="color: red; font-size: 13px"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-row-label">
                                    <asp:Button ID="btnAdminRejectUpdate" runat="server" CssClass="Button" OnClick="btnAdminRejectUpdate_Click" Text="Save" />
                                </div>
                                <div class="form-row-input">
                                    <asp:Button ID="Button3" runat="server" CssClass="Button" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:LinkButton ID="lnkAdminFake" runat="server"></asp:LinkButton>
                <cc1:ModalPopupExtender ID="AdminRejectPopup" runat="server" PopupControlID="PnlAdminReason"
                    TargetControlID="lnkAdminFake" BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>



                <asp:Panel ID="PnlAdminEditLoan" runat="server" CssClass="modalPopup" Width="650px" Height="90%" Style="display: none">
                    <div style="text-align: center; font-size: 25px; letter-spacing: 2px;">
                        <asp:Label Font-Bold="true" ID="Label1" runat="server" CssClass="form-row-label" Style="text-align: center" Text="Reason"></asp:Label>
                    </div>
                    <div class="">
                        <div class="flex-row">
                            <div class="form-row">
                                <div class="form-row-label">
                                    <asp:Label ID="Label2" runat="server" Text="Application Number"></asp:Label>
                                </div>
                                <div class="form-row-input">
                                    <asp:Label ID="lblAdminEditApplicationNumber" Width="40px" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-row-label">
                                    <asp:Label ID="Label4" runat="server" Text="Applicant Name"></asp:Label>
                                </div>
                                <div class="form-row-input">
                                    <asp:Label ID="lblAdminEditApplicantName" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-row-label">
                                    <asp:Label ID="Label6" runat="server" Text="1st Instalment"></asp:Label>
                                </div>
                                <div class="form-row-input">
                                    <asp:TextBox ID="txtInstalment1" TextMode="Number" CssClass="PopupTextBox" runat="server" onkeypress="return CheckNumber(event,this)" onKeyUp="return CheckNumber(event,this)" onChange="return CheckNumber(event,this)" AutoPostBack="true" OnTextChanged="txtInstalment1_TextChanged"></asp:TextBox>
                                    <asp:Label runat="server" ID="lblInstalmentError1" Style="color: red; font-size: 13px" ></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-row-label">
                                    <asp:Label ID="Label3" runat="server" Text="2nd Instalment"></asp:Label>
                                </div>
                                <div class="form-row-input">
                                    <asp:TextBox ID="txtInstalment2" TextMode="Number" CssClass="PopupTextBox" runat="server" MaxLength="5" onkeypress="return CheckNumber(event,this)" onKeyUp="return CheckNumber(event,this)" onChange="return CheckNumber(event,this)"  AutoPostBack="true" OnTextChanged="txtInstalment2_TextChanged" ></asp:TextBox>
                                    <asp:Label runat="server" ID="lblInstalmentError2" Style="color: red; font-size: 13px"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-row-label">
                                    <asp:Label ID="Label7" runat="server" Text="3rd Instalment"></asp:Label>
                                </div>
                                <div class="form-row-input">
                                    <asp:TextBox ID="txtInstalment3" TextMode="Number" CssClass="PopupTextBox" runat="server" MaxLength="5" onkeypress="return CheckNumber(event,this)" onKeyUp="return CheckNumber(event,this)" onChange="return CheckNumber(event,this)" AutoPostBack="true" OnTextChanged="txtInstalment3_TextChanged"></asp:TextBox>
                                    <asp:Label runat="server" ID="lblInstalmentError3" Style="color: red; font-size: 13px"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-row-label">
                                    <asp:Label ID="Label9" runat="server" Text="4th Instalment"></asp:Label>
                                </div>
                                <div class="form-row-input">
                                    <asp:TextBox ID="txtInstalment4" TextMode="Number" CssClass="PopupTextBox" runat="server" MaxLength="5" onkeypress="return CheckNumber(event,this)" onKeyUp="return CheckNumber(event,this)" onChange="return CheckNumber(event,this)"  AutoPostBack="true" OnTextChanged="txtInstalment4_TextChanged"></asp:TextBox>
                                    <asp:Label runat="server" ID="lblInstalmentError4" Style="color: red; font-size: 13px"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-row-label">
                                    <asp:Label ID="Label11" runat="server" Text="5th Instalment"></asp:Label>
                                </div>
                                <div class="form-row-input">
                                    <asp:TextBox ID="txtInstalment5" TextMode="Number" CssClass="PopupTextBox" runat="server" MaxLength="5" onkeypress="return CheckNumber(event,this)" onKeyUp="return CheckNumber(event,this)" onChange="return CheckNumber(event,this)"  AutoPostBack="true" OnTextChanged="txtInstalment5_TextChanged"></asp:TextBox>
                                    <asp:Label runat="server" ID="lblInstalmentError5" Style="color: red; font-size: 13px"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-row-label">
                                    <asp:Button ID="btnUpdateLoanAmount" runat="server" CssClass="Button" Text="Save" OnClick="btnUpdateLoanAmount_Click" />
                                </div>
                                <div class="form-row-input">
                                    <asp:Button ID="Button2" runat="server" CssClass="Button" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:LinkButton ID="lnkAdminEditFake" runat="server"></asp:LinkButton>
                <cc1:ModalPopupExtender ID="AdminEditPopup" runat="server" PopupControlID="PnlAdminEditLoan"
                    TargetControlID="lnkAdminEditFake" BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>



            </ContentTemplate>

        </asp:UpdatePanel>
    </form>
</body>
</html>
