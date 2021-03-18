<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SelfEmploymentPrerequisite.aspx.cs" Inherits="KACDC.Schemes.Self_Employment.SelfEmploymentPrerequisite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <div>
            <br />
            <br />
            <table border="1" style="width: 49%; align-content: center; height: 187px;" cellpadding="0" cellspacing="0" style="width: 481.7pt; border-collapse: collapse; border: 1.0pt solid windowtext; mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 1184; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt; font-size: 11.0pt; font-family: Calibri, sans-serif;" align="center">
                <tr>
                    <td width="56" style="font-size: large">
                        <p align="center" class="MsoNormal" style="mso-margin-top-alt: auto; mso-margin-bottom-alt: auto; text-align: center; line-height: normal; width: 110px;">
                            <span lang="KN"><strong>ಕ್ರ ಸಂ</strong></span><span><o:p></o:p></span>
                        </p>
                    </td>
                    <td width="227" style="text-align: center">
                        <p align="center" class="MsoNormal" style="mso-margin-top-alt: auto; mso-margin-bottom-alt: auto; text-align: center; line-height: normal; width: 660px;">
                            <span lang="KN"><strong>ಬೇಕಾದ ದಾಖಲೆಗಳು</strong></span><span><o:p></o:p></span>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td width="56" class="auto-style3">
                        <p class="MsoNormal" style="mso-margin-top-alt: auto; mso-margin-bottom-alt: auto; line-height: normal">
                            <span>1<o:p></o:p></span>
                        </p>
                    </td>
                    <td width="227" style="text-align: center">
                        <p class="MsoNormal" style="mso-margin-top-alt: auto; mso-margin-bottom-alt: auto; line-height: normal; width: 668px;">
                            <span lang="KN">ಜಾತಿ ಮತ್ತು ಆದಾಯ ಪ್ರಮಾಣ ಪತ್ರ ಸಂಖ್ಯೆ (ನಮೂನೆ ಜಿ)</span></p>
                    </td>
                </tr>
                <tr>
                    <td width="56" class="auto-style3">
                        <p class="MsoNormal" style="mso-margin-top-alt: auto; mso-margin-bottom-alt: auto; line-height: normal">
                            <span>2<o:p></o:p></span>
                        </p>
                    </td>
                    <td width="227" style="text-align: center">
                        <p class="MsoNormal" style="mso-margin-top-alt: auto; mso-margin-bottom-alt: auto; line-height: normal; width: 648px;">
                            <span><o:p>
                            <span lang="KN">ಆಧಾರ್</span></o:p></span>&nbsp; ಸಂಖ್ಯೆ</p>
                    </td>
                </tr>
                <tr>
                    <td width="56" class="auto-style3">
                        <p class="MsoNormal" style="mso-margin-top-alt: auto; mso-margin-bottom-alt: auto; line-height: normal">
                            <span>3<o:p></o:p></span>
                        </p>
                    </td>
                    <td width="227" style="text-align: center">
                        <p class="MsoNormal" style="mso-margin-top-alt: auto; mso-margin-bottom-alt: auto; line-height: normal; width: 648px;">
                            <span><o:p><span lang="KN">ಬ್ಯಾಂಕ್ ಖಾತೆ ಸಂಖ್ಯೆ ಮತ್ತು ಐಎಫ್‌ಎಸ್‌ಸಿ ಕೋಡ್</span></o:p></span>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td width="56" class="auto-style3">
                        <p class="MsoNormal" style="mso-margin-top-alt: auto; mso-margin-bottom-alt: auto; line-height: normal">
                            <span>4<o:p></o:p></span>
                        </p>
                    </td>
                    <td width="227" style="text-align: center">
                        <p class="MsoNormal" style="mso-margin-top-alt: auto; mso-margin-bottom-alt: auto; line-height: normal; width: 653px;">
                            <span lang="KN">ವಿಶೇಷಚೇತನರಿಗೆ – ಅಂಗವಿಕಲ ಪ್ರಮಾಣ ಪತ್ರ</span><span><o:p></o:p></span>
                            ಸಂಖ್ಯೆ</p>
                    </td>
                </tr>
                </table>


        </div>

        <br />
        <br />
        <asp:Button ID="btnSE" runat="server" class="btn btn-default" BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" OnClick="btnSE_Click" Text="Online Application"></asp:Button>
                    <a href="~/DownloadAppn.aspx" BackColor="#CCCCCC" BorderStyle="Solid" runat="server" visible="false" ForeColor="Black">Download Application</a>
    </div>
</asp:Content>

