<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="KACDC._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <link rel="shortcut icon" type="image/x-icon" href="../../Image/KACDC_PDF.jpg" />  

        <link href="AddScript/bootstrap341.min.css" rel="stylesheet" />
  <script src="AddScript/Ajaxjquery341.min.js"></script>
  <script src="AddScript/maxcdnbootstrap.min.js"></script>
    
    
    <link href="CustomCSS/HomePage/Card.css" rel="stylesheet" />
    <style type="text/css">
        .carousel .item {
            height: 100px;
        }

    </style>
    <div>
        <marquee direction="left" onmouseover="this.stop()" onmouseout="this.start()" scrolldelay="80" style="height: 20px;">
       <asp:Literal ID="Scroll1" runat="server" Text="KACDC1"></asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Literal ID="Scroll2" runat="server" Text=""></asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Literal ID="Scroll3" runat="server" Text="KACDC3"></asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Literal ID="Scroll4" runat="server" Text="KACDC4"></asp:Literal>
            <p>

            </p>
     </marquee>
    </div>
    <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
        <ol class="carousel-indicators">
            <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="3"></li>
        </ol>
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img class="d-block w-100 " style="height:350px" src="Image/img1.jpeg" alt="First slide">
                <div class="carousel-caption d-none d-md-block">
                    <h3 id="ScrollIMGHeadind1" runat="server">Heading</h3>
                    <p id="ScrollIMGCaption1" runat="server">captions</p>
                </div>
            </div>
            <div class="carousel-item">
                <img class="d-block w-100 "  style="height:350px" src="Image/img2.jpeg" alt="Second slide">
                <div class="carousel-caption d-none d-md-block">
                    <h3 id="H2" runat="server">Heading</h3>
                    <p id="P2" runat="server">captions</p>
                </div>
            </div>
            <div class="carousel-item">
                <img class="d-block w-100 " style="height:350px" src="Image/img1.jpeg" alt="Third slide">
                <div class="carousel-caption d-none d-md-block">
                    <h3 id="H3" runat="server">Heading</h3>
                    <p id="P3" runat="server">captions</p>
                </div>
            </div>
            <div class="carousel-item">
                <img class="d-block w-100 "  style="height:350px" src="Image/img2.jpeg" alt="Fourth slide">
                <div class="carousel-caption d-none d-md-block">
                    <h3 id="H4" runat="server">Heading</h3>
                    <p id="P4" runat="server">captions</p>
                </div>
            </div>
        </div>
        <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>

    <%--<div class="row">
        <div class="col-md-4 auto-style2">
            <h2>About</h2>
            <p class="">
                Karnataka Aryavysya Community Development Corporation (KACDC) started in 2019 to empower aryavysya community people to grow in socity with all the help by government scheme.
            </p>
            <p>
                <a href="About.aspx">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4 auto-style2">
            <h2>Scheme</h2>
            <p>
                The Corporation help Community people to get government facility like
            </p>
            <p>
                <p>Arivu </p>
                <p> Self Emplyment </p>
            </p>
        </div>
    
    </div>--%>
    <div class="container">
        <div class="card">
            <div class="ImgBx">
                <img src="Image/KACDC.png" />
            </div>
            <div class="ContentBox">
                <h2>About</h2>
                <p>
             Karnataka Aryavysya Community Development Corporation (KACDC) started in 2019 to empower aryavysya community people to grow in socity with all the help by government scheme.
                </p>
                <a href="About.aspx">Read Moread More</a>
            </div>
        </div>

        <div class="card">
            <div class="ImgBx">
                <img src="Image/Loan.png" />
            </div>
            <div class="ContentBox">
                <h2>Scheme</h2>
                <h3>Arivu </h3>
                <a runat="server" href="Schemes/Arivu/AboutArivu.aspx">Read More</a><br />
                <h3> Self Emplyment </h3>
                <a runat="server"  href="Schemes/Self%20Employment/AboutSelfEmployment.aspx">Read More</a>
            </div>
        </div>
        <div class="card">
            <div class="ImgBx">
                <img src="Image/KACDC.png" />
            </div>
            <div class="ContentBox">
                <h2>About</h2>
                <p>
                    Karnataka Aryavysya Community Development Corporation (KACDC) started in 2019 to empower aryavysya community people to grow in socity with all the help by government scheme.
                </p>
                <a href="About.aspx">Read More</a>
            </div>
        </div>
        <%--<div class="card">
            <div class="ImgBx">
                <img src="Image/KACDC.png" />
            </div>
            <div class="ContentBox">
                <h2>About</h2>
                <p>
                    Karnataka Aryavysya Community Development Corporation (KACDC) started in 2019 to empower aryavysya community people to grow in socity with all the help by government scheme.
                </p>
                <a href="About.aspx">Read More</a>
            </div>
        </div>--%>
    </div>
</asp:Content>
