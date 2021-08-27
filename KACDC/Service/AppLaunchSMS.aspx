<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppLaunchSMS.aspx.cs" Inherits="KACDC.Service.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<%--        <link href="../../CustomCSS/ApplicationPage/ApplicationPage.css" rel="stylesheet" />--%>
    <script src="//code.jquery.com/jquery-2.1.4.min.js"></script>
<script src="jQuery-plugin-progressbar.js"></script>
 <style>
#myProgress {
  width: 100%;
  background-color: #ddd;
}

#myBar {
  width: 0%;
  height: 60px;
  background-color: #04AA6D;
  text-align: center;
  line-height: 60px;
  color: white;
  font-size:40px;
}



</style>


<style>
    @import url('https://fonts.googleapis.com/css?family=Poppins:400,500,600,700&display=swap');

.circular{
  height: 100px;
  width: 100px;
  position: relative;
}
.circular .inner, .circular .outer, .circular .circle{
  position: absolute;
  z-index: 6;
  height: 100%;
  width: 100%;
  border-radius: 100%;
  box-shadow: inset 0 1px 0 rgba(0,0,0,0.2);
}
.circular .inner{
  top: 50%;
  left: 50%;
  height: 80px;
  width: 80px;
  margin: -40px 0 0 -40px;
  background-color: #dde6f0;
  border-radius: 100%;
  box-shadow: 0 1px 0 rgba(0,0,0,0.2);
}
.circular .circle{
  z-index: 1;
  box-shadow: none;
}
.circular .numb{
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  z-index: 10;
  font-size: 18px;
  font-weight: 500;
  color: #4158d0;
}
.circular .bar{
  position: absolute;
  height: 100%;
  width: 100%;
  background: #fff;
  -webkit-border-radius: 100%;
  clip: rect(0px, 100px, 100px, 50px);
}
.circle .bar .progress{
  position: absolute;
  height: 100%;
  width: 100%;
  -webkit-border-radius: 100%;
  clip: rect(0px, 50px, 100px, 0px);
}
.circle .bar .progress, .dot span{
  background: #4158d0;
}
.circle .left .progress{
  z-index: 1;
  animation: left 4s linear both;
}
@keyframes left {
  100%{
    transform: rotate(180deg);
  }
}
.circle .right{
  z-index: 3;
  transform: rotate(180deg);
}
.circle .right .progress{
  animation: right 4s linear both;
  animation-delay: 4s;
}
@keyframes right {
  100%{
    transform: rotate(180deg);
  }
}
.circle .dot{
  z-index: 2;
  position: absolute;
  left: 50%;
  top: 50%;
  width: 50%;
  height: 10px;
  margin-top: -5px;
  animation: dot 8s linear both;
  transform-origin: 0% 50%;
}
.circle .dot span {
  position: absolute;
  right: 0;
  width: 10px;
  height: 10px;
  border-radius: 100%;
}
@keyframes dot{
  0% {
    transform: rotate(-90deg);
  }
  50% {
    transform: rotate(90deg);
    z-index: 4;
  }
  100% {
    transform: rotate(270deg);
    z-index: 4;
  }
}
</style>

    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 405px;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            width: 583px;
            height: 798px;
        }
        .auto-style4 {
            text-align: center;
            width: 435px;
        }
        .auto-style5 {
            text-align: center;
            height: 49px;
        }

         .form-row {
        padding: 2px;
        flex-wrap: wrap;
        flex-direction: column;
        align-content: center;
        /*width: 95%;*/
        margin: 2px;
    }
         .form-row-label {
        font-size: 9px;
        padding-right: 0px;
        align-content: center;
        text-align: center;
        font-size: 16px;
        align-self: center;
        width:50%;
        /*background-color: antiquewhite;*/
    }
         .flex-container {
        margin-top: 5px;
        align-items: center;
        align-content: center;
    }
        
    .form-row-Botton{
        align-self:center;
        width:90%;
    }
     .NeumorphicDiv {
        width: 100%;
        padding: 5px;
        margin: 5px;
        align-self: center;
    }
     .form-row-input {
        width: 90%;
        text-align: center;
        align-items: center;
        align-content: center;
        align-self: center;
        width:50%;
    }
     .row {
  display: flex;
}

.column {
  flex: 50%;
}


.blink_me {
  animation: blinker 2s linear infinite;
}

@keyframes blinker {
  50% {
    opacity: 0;
  }
}


.wrapper {
  position: absolute;
  width: 400px;
  height: 400px;
  margin: auto;
  top: 0;
  left: 0;
  bottom: 0;
  right: 0;
  display: flex;
}
.container {
  font: 1px;
  padding: 0 20px;
}

    </style>
    <script>
var i = 0;
function move() {
    if (i == 0) {
        i = 1;
        var elem = document.getElementById("myBar");
        var thanksdiv = document.getElementById("thanks");
        var buttondiv = document.getElementById("Button1");
        var width = 10;
        var id = setInterval(frame, 10);
        function frame() {
            if (width >= 100) {
                if (thanksdiv.style.display === "none") {
                    x.style.display = "block";
                } else {
                    thanksdiv.style.display = "none";
                }

                if (buttondiv.style.display === "none") {
                    x.style.display = "block";
                } else {
                    buttondiv.style.display = "none";
                }

                thanksdiv.style.display = "none";
                elem.innerText = "ಸಂದೇಶ ರವಾನಿಸಿದೆ - ಧನ್ಯವಾದಗಳು";
                clearInterval(id);
                i = 0;
            } else {
                width++;
                elem.style.width = width + "%";
                elem.innerHTML = width + "%";
            }
        }
    }
}
</script>
</head>
<body>
    <form id="form1" runat="server">

        <%--<table class="auto-style1">
            <tr>
                <td>
                    <asp:Image ID="ImgGOK" runat="server" Height="110px" Width="114px" ImageUrl="https://aryavysya.karnataka.gov.in/image/GOK.jpeg" CssClass="ImageNeumorphic" /></td>
                <td class="auto-style2" colspan="2">
                    <h2 style="font-size: 40px"><strong>KARNATAKA ARYA VYSYA COMMUNITY DEVELOPMENT CORPORATION LTD 
                    <br />
                        ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ ಸಮುದಾಯ ಅಭಿವೃದ್ಧಿ ನಿಗಮ (ನಿ)</strong></h2>
                </td>
                <td>
                    <asp:Image ID="Image1" runat="server" Height="110px" Width="114px" ImageUrl="https://aryavysya.karnataka.gov.in/image/KACDC.png" CssClass="ImageNeumorphic" /></td>
            </tr>
            <tr style="height: 100px">
                <td>&nbsp;</td>
                <td colspan="2">
                    <h1 class="auto-style5" style="font-size: 50px">ಸಾಲ ಮರುಪಾವತಿ ಮೆಬೈಲ್ ಆಪ್ ಗೆ ಚಾಲನಾ ಸಂದೇಶ</h1>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style4">
                    <img class="auto-style3" src="https://aryavysya.karnataka.gov.in/image/poster.jpg" /></td>
                <td class="auto-style2">
                    <asp:Button ID="Button1" runat="server" Text="SEND MESSAGE" Height="164px" Width="600px" Style="font-size: 55px; border-radius: 90px; color: white; background-color: #005ea2; font-family: Arial; font-weight: 600" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>--%>

        <div class="form-row">
            <asp:Image ID="Imdfage2" runat="server" Height="110px" Width="114px" ImageUrl="../image/GOK.png" CssClass="ImageNeumorphic" Style="float: left;" />

            <asp:Image ID="Image1" runat="server" Height="110px" Width="114px" ImageUrl="../image/KACDC.png" CssClass="ImageNeumorphic" Style="float: right;" />

            <h1 style="font-size: 50px; text-align: center; margin: -10px"><strong style="color:#002df9">ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ ಸಮುದಾಯ ಅಭಿವೃದ್ಧಿ ನಿಗಮ (ನಿ) </strong><div style="font-size:25px;font-family:Calibri"><strong>KARNATAKA ARYA VYSYA COMMUNITY DEVELOPMENT CORPORATION LTD </strong></div></h1>
                
            <br />

            <h1 class="auto-style5 blink_me" style="font-size: 45px; color:#b7009d; margin-top: 0px">ಸಾಲ ಮರುಪಾವತಿ ಮೊಬೈಲ್ ಆ್ಯಪ್ ಮತ್ತು ಆರ್ಯ ವೈಶ್ಯ ಪೋರ್ಟಲ್ ಲೋಕಾರ್ಪಣಾ ಕಾರ್ಯಕ್ರಮ</h1>
        </div>
        <div class="flex-container ContantMain" id="divSEApplicationMail" runat="server" style="width: 105%">
            <div class="NeumorphicDiv">

                <div class="row">
                    <div class="column" style="flex: 30%;">
                        <asp:Image ID="Imadge2" runat="server" Height="610px" Width="450px" ImageUrl="../image/MobileAppImage.png" CssClass="ImageNeumorphic" Style="margin-left: 50px" />

                        <%--                        <img class="auto-style3" width="150px" ImageUrl="../image/MobileAppImage.png" style="margin-left: 50px"  />--%>
                    </div>
                    <div class="column" style="float: right; margin-right: 50px; align-items: center; align-content: center; align-self: center;">
                        <div>
                            <div id="myProgress" style="width: 90%;  overflow: hidden; float: left; margin-top:-100px" >
                                <div id="myBar">0%</div>
                            </div>
                        </div>
                        <br /><br /><br /><br /><br />
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanelAVPortal" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Button ID="Button1" runat="server" Text="ಸಂದೇಶ ರವಾನಿಸಿ" OnClientClick="move()" Height="164px" Width="600px" Style="font-size: 55px; border-radius: 90px; color: white; background-color: #005ea2; font-family: Arial; font-weight: 600; margin-top: -250px;margin-left:100px" />
<div id="thanks" class="auto-style5 " style="font-size: 60px;  color:#b74800; margin-top: 0px;margin-left:-90px"> </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
            </div>
                        </div>
                    
            <!DOCTYPE html>
<!-- Created By CodingNepal -->


        </div>
        </div>
         
          
    </form>
</body>
</html>
