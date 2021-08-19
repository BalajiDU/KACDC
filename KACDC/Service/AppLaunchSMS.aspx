<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppLaunchSMS.aspx.cs" Inherits="KACDC.Service.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<%--        <link href="../../CustomCSS/ApplicationPage/ApplicationPage.css" rel="stylesheet" />--%>

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
    </style>

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

            <h1 style="font-size: 50px; text-align: center; margin: -10px"><strong>ಕರ್ನಾಟಕ ಆರ್ಯ ವೈಶ್ಯ ಸಮುದಾಯ ಅಭಿವೃದ್ಧಿ ನಿಗಮ (ನಿ) </strong><div style="font-size:30px"><strong>KARNATAKA ARYA VYSYA COMMUNITY DEVELOPMENT CORPORATION LTD </strong></div></h1>
                
            <br />

            <h1 class="auto-style5 blink_me" style="font-size: 45px; color:#b7009d; margin-top: 0px">ಸಾಲ ಮರುಪಾವತಿ ಮೊಬೈಲ್ ಮತ್ತು ಆರ್ಯ ವೈಶ್ಯ ಪೋರ್ಟಲ್ ಲೋಕಾರ್ಪಣಾ ಕಾರ್ಯಕ್ರಮ</h1>
        </div>
        <div class="flex-container ContantMain" id="divSEApplicationMail" runat="server" style="width: 105%">
            <div class="NeumorphicDiv">

                <div class="row">
                    <div class="column">            <asp:Image ID="Imadge2" runat="server"  Height="610px" Width="450px" ImageUrl="../image/MobileAppImage.png" CssClass="ImageNeumorphic" style="margin-left: 50px" />

<%--                        <img class="auto-style3" width="150px" ImageUrl="../image/MobileAppImage.png" style="margin-left: 50px"  />--%>
                    </div>
                    <div  class="column" style="float: right; margin-right: 50px; align-items: center; align-content: center; align-self: center;">
                        <asp:Button ID="Button1" runat="server" Text="ಸಂದೇಶ ರವಾನಿಸಿ" Height="164px" Width="600px" Style="font-size: 55px; border-radius: 90px; color: white; background-color: #005ea2; font-family: Arial; font-weight: 600; margin-top:-250px" />

                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
