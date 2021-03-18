<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZM_Form.aspx.cs" Inherits="KACDC.ZM_Form" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Zonal Manager</title>
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
            BlockUI("<%=PnlZMSEReason.ClientID %>");
            $.blockUI.defaults.css = {};
        });
        function ZMSEHidepopup() {
            $find("ZMSERejectPopup").hide();
            return false;
        }
        $(document).ready(function () {

            BlockUI("<%=PnlZMARReason.ClientID %>");
            $.blockUI.defaults.css = {};
        });
        function ZMARHidepopup() {
            $find("ZMARRejectPopup").hide();
            return false;
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
<body style="background:#ededed;">
    <form runat="server">

        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:Button ID="btnLogout" class="btn btn-hover btnSubcolor" Width="10%" runat="server" Text="Logout" OnClick="btnLogout_Click" />
        <div class="sidebar">
            <header>
                <span>K</span>
                <span>A</span>
                <span>C</span>
                <span>D</span>
                <span>C</span>
            </header>
            <ul class="mainmenu">
                <li><a>Arivu</a>
                    <ul class="submenu">
                        <li><a class="nav-item nav-link" id="nav-ARCEODownload-tab" data-toggle="tab" href="#nav-ARCEODownload" role="tab" aria-controls="nav-homePage" aria-selected="true">CEO Document</a></li>
                        <li><a class="nav-item nav-link" id="nav-ArApprove-tab" data-toggle="tab" href="#nav-ArApprove" role="tab" aria-controls="nav-ArApprove" aria-selected="false">Approval Page</a></li>
                        <li><a class="nav-item nav-link" id="nav-ArRelease-tab" data-toggle="tab" href="#nav-ArRelease" role="tab" aria-controls="nav-ArRelease" aria-selected="false">RTGS Release</a></li>

                    </ul>
                </li>
                <li><a>Self Employment</a>
                    <ul class="submenu">
                        <li><a class="nav-item nav-link" id="nav-SECEODownload-tab" data-toggle="tab" href="#nav-SECEODownload" role="tab" aria-controls="nav-homePage" aria-selected="true">CEO Document</a></li>
                        <li><a class="nav-item nav-link" id="nav-SEApprove-tab" data-toggle="tab" href="#nav-SEApprove" role="tab" aria-controls="nav-SEApprove" aria-selected="false">Approval Page</a></li>
                        <li><a class="nav-item nav-link" id="nav-SERelease-tab" data-toggle="tab" href="#nav-SERelease" role="tab" aria-controls="nav-SERelease" aria-selected="false">RTGS Release</a></li>
                    </ul>
                </li>
                <li><a>
                    <asp:Button ID="Button1" class="LogoutButton" runat="server" Text="Logout" OnClick="btnLogout_Click" /></a> </li>
            </ul>
        </div>
        <section id="tabs">    
            <div class="align-content-center">
                <div class="">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="tab-content py-3 px-3 px-sm-0" id="nav-tabContent">
                                <div class="tab-pane fade active" id="nav-ARCEODownload" role="tabpanel" aria-labelledby="nav-ARCEODownload-tab">
                                    <div class="NeumorphicDiv">
                                        <asp:GridView ID="GvArivuCEODoc" CssClass="GridView col-lg-offset-2" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
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
                                <div class="tab-pane fade" id="nav-ArApprove" role="tabpanel" aria-labelledby="nav-ArApprove-tab">
                                    
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div class="NeumorphicDiv">
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
                                                                                <asp:ListItem Value="">--SELECT REASON--</asp:ListItem>
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
                                                                        <div>
                                                                            <asp:Button ID="btnUpdateBankAR" class="Button" runat="server" OnClick="btnUpdateBankAR_Click" Style="margin-left: 40%;" Text="Update Details" CausesValidation="false" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <asp:Button ID="btnClearAR" class="Button" runat="server" Text="Cancel / Clear" OnClick="btnClearAR_Click" CausesValidation="false" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="NeumorphicDiv">
                                                <div class="flex-container">
                                                    <div class="Neumorphic">
                                                        <div class="NestedNeumorphic">
                                                            <asp:Label runat="server" Text="Select District"></asp:Label>
                                                        </div>
                                                        <div class="">
                                                            
                                                            <asp:DropDownList ID="drpArivuDistrict" runat="server" class="NeuoDropdown" AutoPostBack="True" OnSelectedIndexChanged="drpArivuDistrict_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                            
                                                        </div>
                                                    </div>
                                                    <div class="Neumorphic">
                                                        <div class="NestedNeumorphic">
                                                            <asp:Label runat="server" Text="Select Instalment"></asp:Label>
                                                        </div>
                                                        <div class="">
                                                            <asp:DropDownList ID="drpArivuSelectYear" runat="server" class="NeuoDropdown" AutoPostBack="True" OnSelectedIndexChanged="drpArivuSelectYear_SelectedIndexChanged">
                                                                <asp:ListItem Value="Year1Loan">1ST Instalment</asp:ListItem>
                                                                <%--<asp:ListItem Value="Year2Loan">2ND Instalment</asp:ListItem>
                                                                <asp:ListItem Value="Year3Loan">3RD Instalment</asp:ListItem>
                                                                <asp:ListItem Value="Year4Loan">4TH Instalment</asp:ListItem>
                                                                <asp:ListItem Value="Year5Loan">5TH Instalment</asp:ListItem>--%>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>

                                                    <div class="Neumorphic">
                                                        <div class="NestedNeumorphic">
                                                            <asp:Label runat="server" Text="Select Type"></asp:Label>
                                                        </div>
                                                        <div class="">
                                                            <asp:DropDownList ID="drpArivuReleased" runat="server" class="NeuoDropdown" AutoPostBack="True" OnSelectedIndexChanged="drpArivuReleased_SelectedIndexChanged">
                                                                <asp:ListItem Value="">Not Released</asp:ListItem>
                                                                <asp:ListItem Value="NOT">Released</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="NeumorphicDiv">
                                                <div class="flex-container">
                                                    <div class="Neumorphic">
                                                        <div class="NestedNeumorphic">
                                                            <asp:Label ID="Label2" runat="server" Text="Approved Applications"></asp:Label>
                                                        </div>
                                                        <div class="NestedNeumorphic">
                                                            <asp:Label ID="lblARTotalApplications" Width="250px" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="Neumorphic">
                                                        <div class="NestedNeumorphic">
                                                            <asp:Label ID="Label4" runat="server" Text="Total Approved Fund"></asp:Label>
                                                        </div>
                                                        <div class="NestedNeumorphic">
                                                            <asp:Label ID="lblARTotalSum" Width="250px" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="NeumorphicDiv">
                                                <div class="flex-container">
                                                    <div class="Neumorphic">
                                                        <div class="NestedNeumorphic">
                                                            <asp:Label ID="lblZMARDistrictDisplayCount" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="NestedNeumorphic">
                                                            <asp:Label ID="lblZMARDistrictApplicationCount" Width="250px" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="Neumorphic">
                                                        <div class="NestedNeumorphic">
                                                            <asp:Label ID="lblZMARDistrictDisplayTotal" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="NestedNeumorphic">
                                                            <asp:Label ID="lblZMARDistrictApplicationTotal" Width="250px" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="NeumorphicDiv">
                                                <div>
                                                    <asp:GridView ID="ArivugvZMApprove" runat="server" class="GridView" AutoGenerateColumns="False" DataKeyNames="ApplicationNumber,ApplicantName" Style="align-content: center;">
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                                                                <ItemTemplate>
                                                                    <%# Eval("ApplicationNumber")%>
                                                                </ItemTemplate>
                                                                <HeaderStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Applicant Name" ItemStyle-Width="220">
                                                                <ItemTemplate>
                                                                    <%# Eval("ApplicantName") + "<br />" + Eval("Gender")+ "<br />"+"PH : "+ Eval("PhysicallyChallenged") %>
                                                                    <%--<asp:Button ID="btnZMDispPH" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnZMDispPH_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("PhysicallyChallenged") %>' />--%>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="RD Number" ItemStyle-Width="220">
                                                                <ItemTemplate>
                                                                    <%# "RD Number: " + Eval("RDNumber")+ "<br />" + " Aadhar: " + Eval("AadharNum")%>
                                                                    <%--<%# Eval("RDNumber") %>--%><%--<asp:HyperLink ID="lblProductName" runat="server" Text='<%# Eval("RDNumber") %>' NavigateUrl="#" Target="_blank"  ></asp:HyperLink>--%>
                                                                    <asp:Button ID="btnZMCasteIncome" Visible="false" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnZMCasteIncome_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5; padding: 1px" Text='<%# Eval("RDNumber") %>' ToolTip="Caste and Incone Certificate" />
                                                                    <asp:Button ID="btnZMDispAadhar" Visible="false" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnZMDispAadhar_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("AadharNum") %>' ToolTip="Aadhar" />
                                                                    <%--<asp:Button ID="HyperLink1" OnClick="ArivugvCWApprove_RowCommand" OnClientClick="aspnetForm.target ='_blank';" runat="server" Text='<%# Eval("RDNumber") %>' CommandArgument="<%# Container.DataItemIndex %>" ></asp:Button>--%><%--<asp:HyperLink  CommandName="PathUpdate" runat="server" Text='<%# Eval("RDNumber")+"abc" %>' Target="_blank" />--%>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
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
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Address" ItemStyle-Width="220">
                                                                <ItemTemplate>
                                                                    <%# Eval("ParmanentAddress") + "<br />" + Eval("ParDistrict")+"(D)"+ "<br />" + Eval("ParTaluk")+"(T)"+ "<br />" + Eval("ParConstituency")+"(C)"+ "<br />" + Eval("ParPincode")+"(P)"%>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="220px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Bank Details" ItemStyle-Width="220">
                                                                <ItemTemplate>
                                                                    <%# "A/C No: " + Eval("AccountNumber")+ "<br />"%>
                                                                    <asp:Button ID="btnZMDispPassbook" Visible="false" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnZMDispPassbook_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("AccountNumber") %>' />
                                                                    <%# "Bank: " + Eval("BankName")+ "<br />" + " Branch: " + Eval("Branch")+ "<br />" + " IFSCCode: " + Eval("IFSCCode")+ "<br />" + " Address: " + Eval("BankAddress")%>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="College Details" ItemStyle-Width="220">
                                                                <ItemTemplate>
                                                                    <%# "CET Ticate: "+Eval("CETAdmissionTicateNum") + "<br />"%>
                                                                    <asp:Button ID="btnZMDispCET" Visible="false" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnZMDispCET_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("CETAdmissionTicateNum") %>' ToolTip="CET Admission Ticate" />
                                                                    <%# "<br />"+" Year: " + Eval("CurrentYear") + "<br />" + " Course: " + Eval("Course")+ "<br />" +" College Hostel: " + " ClgHostel: " + Eval("Course") + Eval("CollegeName")+ "<br />" + " Prev Year Marks: " + Eval("PrevYearMarks")+ "<br />" + " Address: " + Eval("CollegeAddress") +"<BR /> "%>
                                                                    <asp:Button ID="btnZMFeeStruct" Visible="false" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnZMFeeStruct_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# "Fee Structure" %>' ToolTip="Study Certificate" />
                                                                    <%# " " %>
                                                                    <asp:Button ID="btnZMDispClgHostel" Visible="false" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnZMDispClgHostel_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# "Hostel: "+Eval("ClgHostel") %>' ToolTip="Study Certificate" />
                                                                    <%# " " %>
                                                                    <asp:Button ID="btnZMStudyCertificate" Visible="false" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnZMStudyCertificate_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# "Study Cert" %>' ToolTip="Study Certificate" />
                                                                    <%# " " %>
                                                                    <asp:Button ID="btnZMMarksCard" runat="server" Visible="false" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnZMMarksCard_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# "Marks Card" %>' ToolTip="Study Certificate" />
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Quota & Loan Amount" ItemStyle-Width="50">
                                                                <ItemTemplate>
                                                                    <%# Eval("Quota")+"<br />"+"Loan Amount:"+"<br />"+Eval("LAmount")%>
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
                                                            <%--<asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Loan Amount" ItemStyle-Width="50">
                                                                <ItemTemplate>
                                                                    <%# Eval("LAmount")%>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                                            </asp:TemplateField>--%>
                                                            <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Approve" ItemStyle-Width="220">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnZMArivuCWApprovee" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnZMArivuApprovee_Click" ShowHeader="True" Text="Approve" />
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Reject" ItemStyle-Width="220">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnZMArivuCEReject" runat="server" class="btn btn-hover btnModcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnZMArivuReject_Click" ShowHeader="True" Text="Reject" />
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Update" ItemStyle-Width="50">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnGVUpdateBankAR" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnGVUpdateBankAR_Click" CausesValidation="false" ShowHeader="True" Text='<%# Eval("REASON") %>' />
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
                                            <div class="NeumorphicDiv">
                                                <div id="SEARZMInfoHidden" visible="false">
                                                    <h2>Approved List</h2>
                                                    <asp:GridView ID="ARZMPrintApprove" class="GridView" runat="server" AutoGenerateColumns="False" ShowFooter="true">
                                                        <Columns>
                                                            <asp:BoundField ItemStyle-Width="200px" DataField="ApprovedApplicationNum" HeaderText="Application Number" />
                                                            <asp:BoundField ItemStyle-Width="150px" DataField="ApplicantName" HeaderText="Applicant Name" />
                                                            <asp:BoundField ItemStyle-Width="150px" DataField="AadharNum" HeaderText="Aadhar Number" />
                                                            <asp:BoundField ItemStyle-Width="150px" DataField="MobileNumber" HeaderText="Mobile Number" />
                                                            <asp:BoundField ItemStyle-Width="150px" DataField="BankName" HeaderText="BankName" />
                                                            <asp:BoundField ItemStyle-Width="200px" DataField="AccountNumber" HeaderText="AccountNumber" />
                                                            <asp:BoundField ItemStyle-Width="200px" DataField="IFSCCode" HeaderText="IFSCCode" />
                                                            <asp:BoundField ItemStyle-Width="200px" DataField="Branch" HeaderText="Branch" />
                                                            <asp:BoundField ItemStyle-Width="200px" DataField="BankAddress" HeaderText="BankAddress" />
                                                            <asp:BoundField ItemStyle-Width="200px" DataField="LAmount" HeaderText="LoanAmount" />
                                                        </Columns>
                                                    </asp:GridView>
                                                    <h2>Rejected List</h2>
                                                    <asp:GridView ID="ARZMPrintReject" class="GridView" runat="server" AutoGenerateColumns="False">
                                                        <Columns>
                                                            <asp:BoundField ItemStyle-Width="200px" DataField="ApplicationNumber" HeaderText="Application Number" />
                                                            <asp:BoundField ItemStyle-Width="150px" DataField="ApplicantName" HeaderText="Applicant Name" />
                                                            <asp:BoundField ItemStyle-Width="150px" DataField="ZMRejectReason" HeaderText="Reject Reason" />
                                                           
                                                        </Columns>
                                                    </asp:GridView>
                                                    <br />

                                                </div>
                                            </div>
                                            <asp:Panel ID="PnlZMARReason" runat="server" CssClass="modalPopup" Width="650px" Height="380px" Style="display: none">
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
                                                                <asp:Label ID="lblZMARRejApplicationNumber" Width="40px" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="form-row">
                                                            <div class="form-row-label">
                                                                <asp:Label ID="Label25" runat="server" Text="Applicant Name"></asp:Label>
                                                            </div>
                                                            <div class="form-row-input">
                                                                <asp:Label ID="lblZMARRejApplicationName" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="form-row">
                                                            <div class="form-row-label">
                                                                <asp:Label ID="Label26" runat="server" Text="Reason"></asp:Label>
                                                            </div>
                                                            <div class="form-row-input">
                                                                <asp:TextBox ID="txtZMARRejectReason" CssClass="PopupTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                <asp:Label runat="server" ID="lblZMARRejectError" Style="color: red; font-size: 13px"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="form-row">
                                                            <div class="form-row-label">
                                                                <asp:Button ID="btnZMARRejectUpdate" runat="server" CssClass="Button" Text="Save" OnClick="btnZMARRejectUpdate_Click" />
                                                            </div>
                                                            <div class="form-row-input">
                                                                <asp:Button ID="Button3" runat="server" CssClass="Button" Text="Cancel" OnClientClick="return ZMARHidepopup()" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </asp:Panel>
                                            <asp:LinkButton ID="lnkZMARFake" runat="server"></asp:LinkButton>
                                          <cc1:ModalPopupExtender ID="ZMARRejectPopup" runat="server" PopupControlID="PnlZMARReason" 
                                              TargetControlID="lnkZMARFake" BackgroundCssClass="modalBackground">

                                          </cc1:ModalPopupExtender>
                                        </ContentTemplate>
                                      
                                    </asp:UpdatePanel>
                                    <div class="NeumorphicDiv">
                                        <div class="flex-container">
                                            <div class="Neumorphic">
                                                <div class="">
                                                    <div class="">
                                                        <asp:TextBox ID="txtARZMChequeNumber" Visible="true" CssClass="NeoTextBox" placeholder="Cheque Number" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="">
                                                    <asp:Button ID="btnARZM" runat="server" CssClass="NeoButton" Text="Proceed to Payment" OnClick="btnARZM_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
                                                </div>
                                                <div class="">
                                                    <asp:Button ID="btnARZMExportExcel" runat="server" CssClass="NeoButton" Text="Excel" OnClick="btnARZMExportExcel_Click" UseSubmitBehavior="false"  />
                                                </div>
                                                  <asp:Button ID="btnZMArivuPrintReject" runat="server" CssClass="NeoButton" style="color:red;" Text="Print Reject" OnClick="btnZMArivuPrintReject_Click" />

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="nav-ArRelease" role="tabpanel" aria-labelledby="nav-ArRelease-tab">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <div class="NeumorphicDiv">
                                                <div id="divUpdateBankReleaseAR" style="margin-bottom: 10px">
                                                    <div class="container-fluid">
                                                        <div class="container">
                                                            <div class="formBox">
                                                                <div class="row" style="background-color: rgba(0,0,0,0.05); margin-top: -15px">
                                                                    <div class="col-sm-12">
                                                                        <h2 style="margin-top: 8px">Update Bank Details</h2>
                                                                        <h5 style="float: left; width: 50%">Applicantion Number :
                                                                                <asp:Label runat="server" ID="lblApplicationNumberReleaseAR" Text=""></asp:Label></h5>

                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-sm-4">
                                                                        <div class="">
                                                                            <div>
                                                                                <div class="InputBox">
                                                                                    <asp:TextBox class="input" runat="server" ID="txtApplicantNameReleaseAR" CausesValidation="false"></asp:TextBox>
                                                                                    <label runat="server" id="Label19" text="Phy Num">Applicant Name</label>
                                                                                </div>
                                                                                <div class="InputBox">
                                                                                    <asp:TextBox class="input" runat="server" ID="txtAccountNumberReleaseAR" CausesValidation="false" onkeypress="return numeric(event)"></asp:TextBox>
                                                                                    <label class="Label" runat="server" id="Label20" text="Phy abc">Account Number</label>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <div class="col-sm-4">
                                                                        <div class="">
                                                                            <div>
                                                                                <div class="InputBox">
                                                                                    <asp:TextBox class="input" runat="server" ID="txtBankNameReleaseAR"></asp:TextBox>
                                                                                    <label runat="server" id="Label21" text="Phy Num">Bank</label>
                                                                                </div>
                                                                                <div class="InputBox">
                                                                                    <asp:TextBox class="input" runat="server" ID="txtBranchReleaseAR"></asp:TextBox>
                                                                                    <label runat="server" id="Label22" text="Phy Num">Branch</label>
                                                                                </div>

                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <div class="">
                                                                            <div>
                                                                                <div class="InputBox">
                                                                                    <asp:TextBox class="input" runat="server" ID="txtIFSCCodeReleaseAR"></asp:TextBox>
                                                                                    <label runat="server" id="Label27" text="Phy Num">IFSC Code</label>
                                                                                </div>
                                                                                <div class="InputBox">
                                                                                    <asp:TextBox class="input" runat="server" ID="txtBankAddrReleaseAR"></asp:TextBox>
                                                                                    <label class="Label" runat="server" id="Label28" text="Phy abc">Bank Address</label>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="row" style="margin-top: -25px">
                                                                    <div class="col-sm-4">
                                                                        <div class="InputBox">
                                                                            <asp:DropDownList ID="drpReasonBankModifyReleaseAR" runat="server" class="dropdown">
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
                                                                        <div>
                                                                            <asp:Button ID="btnUpdateBankReleaseAR" class="Button" runat="server" OnClick="btnUpdateBankReleaseAR_Click" Style="margin-left: 40%;" Text="Update Details" CausesValidation="false" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <asp:Button ID="btnClearReleaseAR" class="Button" runat="server" Text="Cancel / Clear" OnClick="btnClearReleaseAR_Click" CausesValidation="false" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="NeumorphicDiv">
                                                <div class="flex-container">
                                                    <div class="Neumorphic">
                                                        <div class="NestedNeumorphic">
                                                            <asp:Label runat="server" Text="Select District"></asp:Label>
                                                        </div>
                                                        <div class="">
                                                            <asp:DropDownList ID="drpZMArReleaseDistrict" runat="server" class="NeuoDropdown" AutoPostBack="True" OnSelectedIndexChanged="drpZMArReleaseDistrict_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="Neumorphic">
                                                    <div class="NestedNeumorphic">
                                                        <asp:Label runat="server" Text="Select Instalment"></asp:Label>
                                                    </div>
                                                    <div class="">
                                                        <asp:DropDownList ID="drpArivuSelectYearRelease" runat="server" class="NeuoDropdown" AutoPostBack="True" OnSelectedIndexChanged="drpArivuSelectYearRelease_SelectedIndexChanged">
                                                            <asp:ListItem Value="Year1Loan">1ST Instalment</asp:ListItem>
                                                            <%--<asp:ListItem Value="Year2Loan">2ND Instalment</asp:ListItem>
                                                                <asp:ListItem Value="Year3Loan">3RD Instalment</asp:ListItem>
                                                                <asp:ListItem Value="Year4Loan">4TH Instalment</asp:ListItem>
                                                                <asp:ListItem Value="Year5Loan">5TH Instalment</asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="Neumorphic">
                                                    <div class="NestedNeumorphic">
                                                        <asp:Label ID="Label29" runat="server" Text="Pending RTGS"></asp:Label>
                                                    </div>
                                                    <div class="NestedNeumorphic">
                                                        <asp:Label ID="lblPendingRTGS" Width="250px" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="NestedNeumorphic">
                                                        <asp:Label ID="lblPendingRTGSCount" Width="250px" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                
                                            </div>
                                            <div class="NeumorphicDiv">
                                                <asp:GridView ID="gvZMArRelease" runat="server" class="GridView" AutoGenerateColumns="False" DataKeyNames="ApplicationNumber,ApplicantName" Style="align-content: center;">
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                                                            <ItemTemplate>
                                                                <%# Eval("ApplicationNumber") + "<br />" + Eval("ApprovedApplicationNum")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="240px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Applicant Name" ItemStyle-Width="220">
                                                                <ItemTemplate>
                                                                    <%# Eval("ApplicantName") %>
                                                                    <%--<asp:Button ID="btnZMDispPH" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnZMDispPH_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("PhysicallyChallenged") %>' />--%>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                                            </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Bank Details" ItemStyle-Width="220">
                                                                <ItemTemplate>
                                                                    <%# "A/C No: " + Eval("AccountNumber")+ "<br />"%>
                                                                    <%# "Bank: " + Eval("BankName")+ "<br />" + " Branch: " + Eval("Branch")+ "<br />" + " IFSCCode: " + Eval("IFSCCode")+ "<br />" + " Address: " + Eval("BankAddress")%>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                                                            </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Approve" ItemStyle-Width="220">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnZMArivuReleased" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnZMArivuReleased_Click" ShowHeader="True" Text="RTGS Successful" />
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Update" ItemStyle-Width="50">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnGVUpdateBankReleaseAR" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnGVUpdateBankReleaseAR_Click" CausesValidation="false" ShowHeader="True" Text='<%# Eval("REASON") %>' />
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                </EditItemTemplate>
                                                                <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            <asp:GridView ID="ARZMPrintRelease" Visible="false" class="GridView" runat="server" AutoGenerateColumns="False" ShowFooter="true">
                                                        <Columns>
                                                            <asp:BoundField ItemStyle-Width="200px" DataField="ApprovedApplicationNum" HeaderText="Application Number" />
                                                            <asp:BoundField ItemStyle-Width="150px" DataField="ApplicantName" HeaderText="Applicant Name" />
                                                            <asp:BoundField ItemStyle-Width="150px" DataField="AadharNum" HeaderText="Aadhar Number" />
                                                            <asp:BoundField ItemStyle-Width="150px" DataField="MobileNumber" HeaderText="Mobile Number" />
                                                            <asp:BoundField ItemStyle-Width="150px" DataField="BankName" HeaderText="BankName" />
                                                            <asp:BoundField ItemStyle-Width="200px" DataField="AccountNumber" HeaderText="AccountNumber" />
                                                            <asp:BoundField ItemStyle-Width="200px" DataField="IFSCCode" HeaderText="IFSCCode" />
                                                            <asp:BoundField ItemStyle-Width="200px" DataField="Branch" HeaderText="Branch" />
                                                            <asp:BoundField ItemStyle-Width="200px" DataField="BankAddress" HeaderText="BankAddress" />
                                                            <asp:BoundField ItemStyle-Width="200px" DataField="LAmount" HeaderText="LoanAmount" />
                                                        </Columns>
                                                    </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div class="NeumorphicDiv">
                                        <div class="flex-container">
                                            <div class="Neumorphic">
                                                <div class="">
                                                    <div class="">
                                                        <asp:TextBox ID="txtReleaseChequeNumber" Visible="true" CssClass="NeoTextBox" placeholder="Cheque Number" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="">
                                                    <asp:Button ID="btnPrintRelease" runat="server" CssClass="NeoButton" Text="Proceed to Payment" OnClick="btnPrintRelease_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="nav-SECEODownload" role="tabpanel" aria-labelledby="nav-SECEODownload-tab">
                                    <div class="NeumorphicDiv">
                                        <asp:GridView ID="GvSECEODoc" runat="server" CssClass="GridView col-lg-offset-2" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
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
                                <div class="tab-pane fade" id="nav-SEApprove" role="tabpanel" aria-labelledby="nav-SEApprove-tab">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <div class="NeumorphicDiv">
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
                                                                                       
                                                                                        <label class="Label" runat="server" id="Label3" text="Phy abc">Account Number</label>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                        <div class="col-sm-4">
                                                                            <div class="">
                                                                                <div>
                                                                                    <div class="InputBox">
                                                                                        <asp:TextBox class="input" runat="server" ID="txtBankNameSE" CausesValidation="false"></asp:TextBox>
                                                                                        <label runat="server" id="Label5" text="Phy Num">Bank</label>
                                                                                    </div>
                                                                                    <div class="InputBox">
                                                                                        <asp:TextBox class="input" runat="server" ID="txtBranchSE" ></asp:TextBox>
                                                                                        <label runat="server" id="Label12" text="Phy Num">Branch</label>
                                                                                    </div>

                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-sm-4">
                                                                            <div class="">
                                                                                <div>
                                                                                    <div class="InputBox">
                                                                                        <asp:TextBox class="input" runat="server" ID="txtIFSCCodeSE" ></asp:TextBox>
                                                                                        <label runat="server" id="Label13" text="Phy Num">IFSC Code</label>
                                                                                    </div>
                                                                                    <div class="InputBox">
                                                                                        <asp:TextBox class="input" runat="server" ID="txtBankAddrSE" ></asp:TextBox>
                                                                                        <label class="Label" runat="server" id="Label14" text="Phy abc">Bank Address</label>
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
                                                 </div>
                                                <div class="NeumorphicDiv">
                                                    <div class="flex-container">
                                                        <div class="Neumorphic">
                                                            <div class="NestedNeumorphic">
                                                                <asp:Label runat="server" Text="Select District"></asp:Label>
                                                            </div>
                                                            <div class="">
                                                                <asp:DropDownList ID="drpSEDistrict" runat="server"  class="NeuoDropdown" AutoPostBack="True" OnSelectedIndexChanged="drpSEDistrict_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    <div class="Neumorphic">
                                                        <div class="NestedNeumorphic">
                                                            <asp:Label ID="lblDisplay" runat="server" Text="Approved Applications"></asp:Label>
                                                        </div>
                                                        <div class="NestedNeumorphic">
                                                            <asp:Label ID="lblSETotalApplications" Width="250px" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="Neumorphic">
                                                        <div class="NestedNeumorphic">
                                                            <asp:Label ID="Label1" runat="server" Text="Total Approved Fund"></asp:Label>
                                                        </div>
                                                        <div class="NestedNeumorphic">
                                                            <asp:Label ID="lblSETotalSum" Width="250px" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                </div>
                                                <div class="NeumorphicDiv">
                                                    <div class="flex-container">
                                                        <div class="Neumorphic">
                                                            <div class="NestedNeumorphic">
                                                                <asp:Label ID="lblZMSEDistrictDisplayCount" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="NestedNeumorphic">
                                                                <asp:Label ID="lblZMSEDistrictApplicationCount" Width="250px" runat="server"></asp:Label>
                                                            </div> 
                                                        </div>
                                                        <div class="Neumorphic">
                                                            <div class="NestedNeumorphic">
                                                                <asp:Label ID="lblZMSEDistrictDisplayTotal" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="NestedNeumorphic">
                                                                <asp:Label ID="lblZMSEDistrictApplicationTotal" Width="250px" runat="server"></asp:Label>
                                                            </div> 
                                                        </div>
                                                    </div>
                                                </div>
                                                 <div class="NeumorphicDiv">
                                                    <asp:GridView ID="gvSEZMpprove" runat="server" class="GridView" AutoGenerateColumns="False" DataKeyNames="ApplicationNumber,ApplicantName" Style="align-content: center; margin-left: 5px">
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
                                                                    <asp:Button ID="btnZMSEDispPH"  Visible="false" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnZMSEDispPH_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("PhysicallyChallenged") %>' />
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="220px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="RD Number" ItemStyle-Width="220">
                                                                <ItemTemplate>
                                                                    <%# "RD Number: " + Eval("RDNumber")+ "<br />" + " Aadhar: " + Eval("AadharNum")%>

                                                                    <%--<%# Eval("RDNumber") %>--%><%--<asp:HyperLink ID="lblProductName" runat="server" Text='<%# Eval("RDNumber") %>' NavigateUrl="#" Target="_blank"  ></asp:HyperLink>--%>
                                                                    <asp:Button ID="btnZMSECasteIncome" Visible="false" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnZMSECasteIncome_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5; padding: 1px" Text='<%# Eval("RDNumber") %>' ToolTip="Caste and Incone Certificate" />
                                                                    <asp:Button ID="btnZMSEDispAadhar" Visible="false" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnZMSEDispAadhar_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("AadharNum") %>' ToolTip="Aadhar" />
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
                                                                    <%# "A/C No: " + Eval("AccountNumber")+ "<br />"%>
                                                                    <asp:Button ID="btnZMSEDispPassbook" Visible="false" runat="server" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnZMSEDispPassbook_Click" ShowHeader="True" Style="background-color: #E5E5E5; border-color: #B6B5B5" Text='<%# Eval("AccountNumber") %>' />
                                                                    <%# "Bank: " + Eval("BankName")+ "<br />" + " Branch: " + Eval("Branch")+ "<br />" + " IFSCCode: " + Eval("IFSCCode")+ "<br />" + " Address: " + Eval("BankAddress")%>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Quota" ItemStyle-Width="50">
                                                                <ItemTemplate>
                                                                    <%# Eval("Quota")%>
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
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Loan Amount" ItemStyle-Width="50">
                                                                <ItemTemplate>
                                                                    <%# Eval("LoanAmount")%>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Approve" ItemStyle-Width="220">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnZMSECWApprovee" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnZMSEApprovee_Click" ShowHeader="True" Text="Approve" />
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="170px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Reject" ItemStyle-Width="220">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnZMSECWReject" runat="server" class="btn btn-hover btnModcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnZMSEReject_Click" ShowHeader="True" Text="Reject" />
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="170px" />
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
                                                            <%-- <asp:TemplateField   HeaderText="Download Documents" ItemStyle-Width="220" HeaderStyle-CssClass="text-center text-center font-weight-bold">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnZMDonloadDoc" runat="server" OnClick="btnZMDonloadDoc_Click" ShowHeader="True" Text="Download" HeaderStyle-CssClass="text-center text-center font-weight-bold" />
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                    <ItemStyle Width="220px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>--%>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                                 <div class="NeumorphicDiv">
                                                    <div id="SEZMInfoHidden" visible="false">
                                                        <h2>Approved List</h2>
                                                        <asp:GridView ID="SEZMPrintApprove" class="GridView" runat="server" AutoGenerateColumns="False" ShowFooter="true">
                                                            <Columns>
                                                                <asp:BoundField ItemStyle-Width="200px" DataField="ApprovedApplicationNum" HeaderText="Application Number" />
                                                                <asp:BoundField ItemStyle-Width="150px" DataField="ApplicantName" HeaderText="Applicant Name" />
                                                                <asp:BoundField ItemStyle-Width="150px" DataField="AadharNum" HeaderText="Aadhar Number" />
                                                                <asp:BoundField ItemStyle-Width="150px" DataField="MobileNumber" HeaderText="Mobile Number" />
                                                                <asp:BoundField ItemStyle-Width="150px" DataField="BankName" HeaderText="BankName" />
                                                                <asp:BoundField ItemStyle-Width="200px" DataField="AccountNumber" HeaderText="AccountNumber" />
                                                                <asp:BoundField ItemStyle-Width="200px" DataField="IFSCCode" HeaderText="IFSCCode" />
                                                                <asp:BoundField ItemStyle-Width="200px" DataField="Branch" HeaderText="Branch" />
                                                                <asp:BoundField ItemStyle-Width="200px" DataField="BankAddress" HeaderText="BankAddress" />
                                                                <asp:BoundField ItemStyle-Width="200px" DataField="LoanAmount" HeaderText="LoanAmount" />
                                                            </Columns>
                                                        </asp:GridView>
                                                        <h2>Rejected List</h2>
                                                        <asp:GridView ID="SEZMPrintReject" class="GridView" runat="server" AutoGenerateColumns="False">
                                                            <Columns>
                                                                <asp:BoundField ItemStyle-Width="200px" DataField="ApplicationNumber" HeaderText="Application Number" />
                                                                <asp:BoundField ItemStyle-Width="150px" DataField="ApplicantName" HeaderText="Applicant Name" />
                                                                <asp:BoundField ItemStyle-Width="150px" DataField="ZMRejectReason" HeaderText="Reject Reason" />

                                                            </Columns>
                                                        </asp:GridView>
                                                        <br />
                                
                                                    </div>
                                                 </div>
                                               <asp:Panel ID="PnlZMSEReason" runat="server" CssClass="modalPopup" Width="650px" Height="380px" Style="display: none">
                                                    <div style="text-align: center; font-size: 25px; letter-spacing: 2px;">
                                                        <asp:Label Font-Bold="true" ID="Label15" runat="server" CssClass="form-row-label" Style="text-align: center" Text="Reason"></asp:Label>
                                                    </div>
                                                    <br />
                                                    <div class="">
                                                        <div class="flex-row">
                                                            <div class="form-row">
                                                                <div class="form-row-label">
                                                                    <asp:Label ID="Label16" runat="server" Text="Application Number"></asp:Label>
                                                                </div>
                                                                <div class="form-row-input">
                                                                    <asp:Label ID="lblZMSERejApplicationNumber" Width="40px" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="form-row-label">
                                                                    <asp:Label ID="Label17" runat="server" Text="Applicant Name"></asp:Label>
                                                                </div>
                                                                <div class="form-row-input">
                                                                    <asp:Label ID="lblZMSERejApplicationName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="form-row-label">
                                                                    <asp:Label ID="Label18" runat="server" Text="Reason"></asp:Label>
                                                                </div>
                                                                <div class="form-row-input">
                                                                    <asp:TextBox ID="txtZMSERejectReason" CssClass="PopupTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                    <asp:Label runat="server" ID="lblZMSERejectError" Style="color: red; font-size: 13px"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="form-row">
                                                                <div class="form-row-label">
                                                                    <asp:Button ID="btnZMSERejectUpdate" runat="server" CssClass="Button" Text="Save" OnClick="btnZMSERejectUpdate_Click" />
                                                                </div>
                                                                <div class="form-row-input">
                                                                    <asp:Button ID="btnSECancel" runat="server" CssClass="Button" Text="Cancel" OnClientClick="return ZMSEHidepopup()" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                                <asp:LinkButton ID="lnkZMSEFake" runat="server"></asp:LinkButton>
                                                <cc1:ModalPopupExtender ID="ZMSERejectPopup" runat="server" TargetControlID="lnkZMSEFake" PopupControlID="PnlZMSEReason"
                                                    BackgroundCssClass="modalBackground">

                                                </cc1:ModalPopupExtender>
                                            </ContentTemplate>
                                           
                                        </asp:UpdatePanel>
                                        
                                    <div class="NeumorphicDiv">
                                        <div class="flex-container">
                                            <div class="Neumorphic">
                                                <div class="">
                                                    <div class="">
                                                        <asp:TextBox ID="txtSEZMChequeNumber" Visible="true" CssClass="NeoTextBox" placeholder="Cheque Number" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="">
                                                    <asp:Button ID="btnSEZM" runat="server" CssClass="NeoButton" OnClick="btnSEZM_Click" Text="Proceed to Payment" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
                                                </div>
                                                <div class="">
                                                    <asp:Button ID="btnSEZMExportExcel" runat="server" CssClass="NeoButton" Text="Excel" OnClick="btnSEZMExportExcel_Click" UseSubmitBehavior="false"  />
                                                </div>
                                                <asp:Button ID="btnZMSEPrintReject" runat="server" CssClass="NeoButton" style="color:red;" Text="Print Reject" OnClick="btnZMSEPrintReject_Click" />


                                            </div>
                                        </div>
                                    </div>
                                    <div class="NeumorphicDiv">
                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                            <ContentTemplate>

                                                <div class="flex-container">
                                                    <div class="">
                                                        <asp:GridView ID="gvZMSEBankDifferApproved" Style="font-size: 20px ; " class="GridView" runat="server" AutoGenerateColumns="False" ShowFooter="true">
                                                            <Columns>
                                                                <asp:BoundField ItemStyle-Width="200px" DataField="ApprovedApplicationNum" HeaderText="Application Number" />
                                                                <asp:BoundField ItemStyle-Width="150px" DataField="ApplicantName" HeaderText="Applicant Name" />
                                                                <asp:BoundField ItemStyle-Width="150px" DataField="AadharNum" HeaderText="Aadhar Number" />
                                                                <asp:BoundField ItemStyle-Width="150px" DataField="MobileNumber" HeaderText="Mobile Number" />
                                                                <asp:BoundField ItemStyle-Width="150px" DataField="BankName" HeaderText="BankName" />
                                                                <asp:BoundField ItemStyle-Width="200px" DataField="AccountNumber" HeaderText="AccountNumber" />
                                                                <asp:BoundField ItemStyle-Width="200px" DataField="IFSCCode" HeaderText="IFSCCode" />
                                                                <asp:BoundField ItemStyle-Width="200px" DataField="Branch" HeaderText="Branch" />
                                                                <asp:BoundField ItemStyle-Width="200px" DataField="BankAddress" HeaderText="BankAddress" />
                                                                <asp:BoundField ItemStyle-Width="200px" DataField="LoanAmount" HeaderText="LoanAmount" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        </div>
                                    <div class="NeumorphicDiv">
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                        
                                        <div class="flex-container">
                                            <div class="Neumorphic">
                                                <div class="NestedNeumorphic">
                                                    <asp:Label runat="server" Text="Select Type"></asp:Label>
                                                </div>
                                                <div class="">
                                                    <asp:DropDownList ID="drpZMSEPrintBankType" runat="server" class="NeuoDropdown" AutoPostBack="True" OnSelectedIndexChanged="drpZMSEPrintBankType_SelectedIndexChanged">
                                                        <asp:ListItem Value="">--SELECE--</asp:ListItem>
                                                        <asp:ListItem Value="Only">Only</asp:ListItem>
                                                        <asp:ListItem Value="Except">Except</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="Neumorphic">
                                                <div class="NestedNeumorphic">
                                                    <asp:Label runat="server" Text="Select Bank"></asp:Label>
                                                </div>
                                                <div class="">
                                                    <asp:DropDownList ID="drpZMSEPrintBank" runat="server" class="NeuoDropdown" AutoPostBack="True" OnSelectedIndexChanged="drpZMSEPrintBank_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="Neumorphic">
                                                <div class="NestedNeumorphic">
                                                    <asp:Label ID="Label37" runat="server" Text="Approved Count"></asp:Label>
                                                </div>
                                                <div class="NestedNeumorphic">
                                                    <asp:Label ID="lblBankDifferCount" Width="50px" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="Neumorphic">
                                                <div class="NestedNeumorphic">
                                                    <asp:Label ID="Label39" runat="server" Text="Approved Fund"></asp:Label>
                                                </div>
                                                <div class="NestedNeumorphic">
                                                    <asp:Label ID="lblBankDifferTotal" Width="100px" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        <br />
                                            <div class="flex-container">
                                            <div class="Neumorphic">
                                                <div class="">
                                                    <div class="">
                                                        <asp:TextBox ID="btnZMSEBankDifferChequeNumber" Visible="true" CssClass="NeoTextBox" placeholder="Cheque Number" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="">
                                                    <asp:Button ID="btnZMSEBankDifferProceedtoPaymentPDF" runat="server" CssClass="NeoButton" OnClick="btnZMSEBankDifferProceedtoPaymentPDF_Click" Text="Proceed to Payment" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
                                                </div>
                                                <div class="">
                                                    <asp:Button ID="btnZMSEBankDifferProceedtoPaymentExcel" runat="server" CssClass="NeoButton" Text="Excel" OnClick="btnZMSEBankDifferProceedtoPaymentExcel_Click" UseSubmitBehavior="false"  />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="nav-SERelease" role="tabpanel" aria-labelledby="nav-SERelease-tab">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <div class="NeumorphicDiv">
                                                <div id="divUpdateBankReleaseSE" style="margin-bottom: 10px">
                                                    <div class="container-fluid">
                                                        <div class="container">
                                                            <div class="formBox">
                                                                <div class="row" style="background-color: rgba(0,0,0,0.05); margin-top: -15px">
                                                                    <div class="col-sm-12">
                                                                        <h2 style="margin-top: 8px">Update Bank Details</h2>
                                                                        <h5 style="float: left; width: 50%">Applicantion Number :
                                                                                <asp:Label runat="server" ID="lblApplicationNumberReleaseSE" Text=""></asp:Label></h5>

                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-sm-4">
                                                                        <div class="">
                                                                            <div>
                                                                                <div class="InputBox">
                                                                                    <asp:TextBox class="input" runat="server" ID="txtApplicantNameReleaseSE" CausesValidation="false"></asp:TextBox>
                                                                                    <label runat="server" id="Label30" text="Phy Num">Applicant Name</label>
                                                                                </div>
                                                                                <div class="InputBox">
                                                                                    <asp:TextBox class="input" runat="server" ID="txtAccountNumberReleaseSE" CausesValidation="false" onkeypress="return numeric(event)"></asp:TextBox>
                                                                                    <label class="Label" runat="server" id="Label31" text="Phy abc">Account Number</label>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <div class="col-sm-4">
                                                                        <div class="">
                                                                            <div>
                                                                                <div class="InputBox">
                                                                                    <asp:TextBox class="input" runat="server" ID="txtBankNameReleaseSE"></asp:TextBox>
                                                                                    <label runat="server" id="Label32" text="Phy Num">Bank</label>
                                                                                </div>
                                                                                <div class="InputBox">
                                                                                    <asp:TextBox class="input" runat="server" ID="txtBranchReleaseSE"></asp:TextBox>
                                                                                    <label runat="server" id="Label33" text="Phy Num">Branch</label>
                                                                                </div>

                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <div class="">
                                                                            <div>
                                                                                <div class="InputBox">
                                                                                    <asp:TextBox class="input" runat="server" ID="txtIFSCCodeReleaseSE"></asp:TextBox>
                                                                                    <label runat="server" id="Label34" text="Phy Num">IFSC Code</label>
                                                                                </div>
                                                                                <div class="InputBox">
                                                                                    <asp:TextBox class="input" runat="server" ID="txtBankAddrReleaseSE"></asp:TextBox>
                                                                                    <label class="Label" runat="server" id="Label35" text="Phy abc">Bank Address</label>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="row" style="margin-top: -25px">
                                                                    <div class="col-sm-4">
                                                                        <div class="InputBox">
                                                                            <asp:DropDownList ID="drpReasonBankModifyReleaseSE" runat="server" class="dropdown">
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
                                                                        <div>
                                                                            <asp:Button ID="btnUpdateBankReleaseSE" class="Button" runat="server" OnClick="btnUpdateBankReleaseSE_Click" Style="margin-left: 40%;" Text="Update Details" CausesValidation="false" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-4">
                                                                        <asp:Button ID="btnClearSEReleaseSE" class="Button" runat="server" Text="Cancel / Clear" OnClick="btnClearSEReleaseSE_Click" CausesValidation="false" />
                                                                    </div>

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="NeumorphicDiv">
                                                <div class="flex-container">
                                                    <div class="Neumorphic">
                                                        <div class="NestedNeumorphic">
                                                            <asp:Label runat="server" Text="Select District"></asp:Label>
                                                        </div>
                                                        <div class="">
                                                            <asp:DropDownList ID="drpZMSEReleaseDistrict" runat="server" class="NeuoDropdown" AutoPostBack="True" OnSelectedIndexChanged="drpZMSEReleaseDistrict_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="Neumorphic">
                                                    <div class="NestedNeumorphic">
                                                        <asp:Label ID="Label36" runat="server" Text="Pending RTGS"></asp:Label>
                                                    </div>
                                                    <div class="NestedNeumorphic">
                                                        <asp:Label ID="lblSEPendingRTGS" Width="250px" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="NestedNeumorphic">
                                                        <asp:Label ID="lblSEPendingRTGSCount" Width="250px" runat="server"></asp:Label>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="NeumorphicDiv">
                                                <asp:GridView ID="gvZMSERelease" runat="server" class="GridView" AutoGenerateColumns="False" DataKeyNames="ApplicationNumber,ApplicantName" Style="align-content: center;">
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center font-weight-bold" HeaderText="Application Number" ItemStyle-Width="100">
                                                            <ItemTemplate>
                                                                <%# Eval("ApplicationNumber") + "<br />" + Eval("ApprovedApplicationNum")%>
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
                                                                <%# "A/C No: " + Eval("AccountNumber")+ "<br />"%>
                                                                <%# "Bank: " + Eval("BankName")+ "<br />" + " Branch: " + Eval("Branch")+ "<br />" + " IFSCCode: " + Eval("IFSCCode")+ "<br />" + " Address: " + Eval("BankAddress")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="280px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Approve" ItemStyle-Width="220">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnZMSEReleased" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnZMSEReleased_Click" ShowHeader="True" Text="RTGS Successful" />
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center text-center font-weight-bold" HeaderText="Update" ItemStyle-Width="50">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnGVUpdateBankReleaseSE" runat="server" class="btn btn-hover btnSubcolor" CommandArgument="<%# Container.DataItemIndex %>" HeaderStyle-CssClass="text-center text-center font-weight-bold" OnClick="btnGVUpdateBankReleaseSE_Click" CausesValidation="false" ShowHeader="True" Text='<%# Eval("REASON") %>' />
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                            </EditItemTemplate>
                                                            <HeaderStyle CssClass="text-center text-center font-weight-bold" />
                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            <asp:GridView ID="gvZMPrintSERelease" Visible="false" class="GridView" runat="server" AutoGenerateColumns="False" ShowFooter="true">
                                                <Columns>
                                                    <asp:BoundField ItemStyle-Width="200px" DataField="ApprovedApplicationNum" HeaderText="Application Number" />
                                                    <asp:BoundField ItemStyle-Width="150px" DataField="ApplicantName" HeaderText="Applicant Name" />
                                                    <asp:BoundField ItemStyle-Width="150px" DataField="AadharNum" HeaderText="Aadhar Number" />
                                                    <asp:BoundField ItemStyle-Width="150px" DataField="MobileNumber" HeaderText="Mobile Number" />
                                                    <asp:BoundField ItemStyle-Width="150px" DataField="BankName" HeaderText="BankName" />
                                                    <asp:BoundField ItemStyle-Width="200px" DataField="AccountNumber" HeaderText="AccountNumber" />
                                                    <asp:BoundField ItemStyle-Width="200px" DataField="IFSCCode" HeaderText="IFSCCode" />
                                                    <asp:BoundField ItemStyle-Width="200px" DataField="Branch" HeaderText="Branch" />
                                                    <asp:BoundField ItemStyle-Width="200px" DataField="BankAddress" HeaderText="BankAddress" />
                                                    <asp:BoundField ItemStyle-Width="200px" DataField="LoanAmount" HeaderText="LoanAmount" />
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div class="NeumorphicDiv">
                                        <div class="flex-container">
                                            <div class="Neumorphic">
                                                <div class="">
                                                    <div class="">
                                                        <asp:TextBox ID="txtSEReleaseChequeNumber" Visible="true" CssClass="NeoTextBox" placeholder="Cheque Number" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="">
                                                    <asp:Button ID="btnSEPrintRelease" runat="server" CssClass="NeoButton" Text="Proceed to Payment" OnClick="btnSEPrintRelease_Click" UseSubmitBehavior="false" OnClientClick="this.disabled='true'; this.value='Please wait...';" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                      </div>
                </div>
            </div>
        </section>       
    </form>
</body>
</html>
