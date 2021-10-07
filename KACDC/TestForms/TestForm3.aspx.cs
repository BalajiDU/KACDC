using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using CrystalDecisions.CrystalReports.Engine;
//using CrystalDecisions.Shared;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace KACDC.TestForms
{
    public partial class TestForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void rept_Click(object sender, EventArgs e)
        {
            //ReportDocument cryRpt = new ReportDocument();
            //cryRpt.Load(Server.MapPath("~/CrystalReports/RTGS.rpt"));
            //CrystalReportViewer1.ReportSource = cryRpt;
            //cryRpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "crystal");
        }
        protected void button2_Click(object sender, EventArgs e)
        {
            //ReportDocument cryRpt = new ReportDocument();
            ////RTGSOrderLetter RTGS = new RTGSOrderLetter();
            //cryRpt.Load(Server.MapPath("~/CrystalReports/RTGS.rpt"));
            //cryRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            ////cryRpt.SetParameterValue("txtBeneficeryName", "sdjklfkas");
            ////cryRpt.SetParameterValue("txtApplicationNumber", "sdjklfkas");
            ////cryRpt.SetParameterValue("txtLoanNumber", "sdjklfkas");

            //CrystalReportViewer1.ReportSource = cryRpt;

            //CrystalReportViewer1.RefreshReport();

            //cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Server.MapPath("~/DownloadFiles/") + "RDLC_PDFNew.pdf");

            ////MessageBox.Show("Exported Successful");
        }
    }
}

