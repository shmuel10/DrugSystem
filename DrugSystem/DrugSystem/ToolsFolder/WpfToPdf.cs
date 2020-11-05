using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BLL;
using BLL.BE;
using ControlzEx.Standard;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace DrugSystem
{
    public class WpfToPdf
    { 
        public WpfToPdf(Prescription prescription)
        {
            IBll BL = new BllImplementation();
            Patient patient = BL.GetPatient(prescription.PatientID);
            Doctor doctor = BL.GetDoctor(prescription.DoctorID);
            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = "Prescription" + prescription.PrescriptionID;
            PdfPage pdfPage = pdf.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            XFont font1 = new XFont("Verdana", 20, XFontStyle.Bold);
            XFont font2 = new XFont("Verdana", 16, XFontStyle.Regular);
            XFont font3 = new XFont("Verdana", 10, XFontStyle.Italic);
            string str = Assembly.GetExecutingAssembly().Location;
            string localPath = Path.GetDirectoryName(str);
            for (int i = 0; i < 2; i++)
            {
                localPath = Path.GetDirectoryName(localPath);
            }
            XImage xImage = XImage.FromFile(localPath + @"\Icons\med.jpg");
            graph.DrawImage(xImage, 100, 20, 40, 40);
            graph.DrawString("Prescription Number: " + prescription.PrescriptionID, font1, XBrushes.Black, 150, 40);
            graph.DrawLine(XPens.DarkRed, 20, 70, pdfPage.Width - 20, 70);
            graph.DrawString("Patient ID: " + prescription.PatientID, font2, XBrushes.Black, 100, 100);
            graph.DrawString("Patient Name: " + patient.FirstName + " " + patient.LastName, font2, XBrushes.Black, 100, 125);
            graph.DrawLine(XPens.DeepSkyBlue, 70, 150, pdfPage.Width - 70, 150);
            graph.DrawString("Doctor ID: " + doctor.LicenceNumber, font2, XBrushes.Black, 100, 175);
            graph.DrawString("Doctor Name: " + doctor.FirstName + " " + doctor.LastName, font2, XBrushes.Black, 100, 200);
            graph.DrawLine(XPens.DeepSkyBlue, 70, 225, pdfPage.Width - 70, 225);
            graph.DrawString("Medicine Code: " + prescription.MedicineCode, font2, XBrushes.Black, 100, 250);
            graph.DrawString("Instructions: " + prescription.Instructions, font2, XBrushes.Black, 100, 275);
            graph.DrawLine(XPens.DeepSkyBlue, 70, 300, pdfPage.Width - 70, 300);
            graph.DrawString("Start Date: " + prescription.StartDate, font2, XBrushes.Black, 100, 325);
            graph.DrawString("Expire Date: " + prescription.ExpireDate, font2, XBrushes.Black, 100, 350);
            graph.DrawLine(XPens.DeepSkyBlue, 70, 375, pdfPage.Width - 70, 375);
            graph.DrawLine(XPens.DarkRed, 20, pdfPage.Height - 70, pdfPage.Width - 20, pdfPage.Height - 70);
            graph.DrawString("Created By Shmuel Vazana's & Simcha Podolsky's Drug System", font3, XBrushes.Green, 130, pdfPage.Height - 40);

            string pdfFilename = localPath + @"\PrescriptionsPdf\" + "prescription_" + prescription.PatientID+ "_" + prescription.PrescriptionID + ".pdf";
            pdf.Save(pdfFilename);
            //Process.Start(pdfFilename);
        }
    }
}
