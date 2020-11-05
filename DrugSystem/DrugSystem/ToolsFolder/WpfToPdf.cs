using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BLL.BE;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace DrugSystem
{
    public class WpfToPdf
    { 
        public WpfToPdf(Prescription prescription)
        {
            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = "Prescription" + prescription.PrescriptionID;
            PdfPage pdfPage = pdf.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            XFont font = new XFont("Verdana", 20, XFontStyle.Bold);
            graph.DrawString("Prescription" + prescription.PrescriptionID, font, XBrushes.Black, new XRect(0, 0, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            graph.DrawString(prescription.StartDate.ToString(), font, XBrushes.Black, new XRect(0, 0, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.Center);
            graph.DrawString("This is my first PDF document", font, XBrushes.Black, new XRect(0, 0, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.Center);
            string pdfFilename = "prescription_" + prescription.PrescriptionID + ".pdf";
            pdf.Save(pdfFilename);
            Process.Start(pdfFilename);
        }
    }
}
