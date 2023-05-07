using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using Document = iTextSharp.text.Document;

namespace TraversalCoreProject.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfReports/" + "dosya1.pdf");
            var stream = new FileStream(path, FileMode.Create);
            string Arial_TFF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Arial.ttf");
            BaseFont bf = BaseFont.CreateFont(Arial_TFF, BaseFont.IDENTITY_H, true);
            Font f = new Font(bf, 12, Font.NORMAL);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();
            PdfPTable pdfPTable = new PdfPTable(3);
            pdfPTable.AddCell(new Phrase("Müşteri Adı", f));
            pdfPTable.AddCell(new Phrase("Müşteri Soyadı", f));
            pdfPTable.AddCell(new Phrase("Cinsiyet", f));

            pdfPTable.AddCell(new Phrase("Samet", f));
            pdfPTable.AddCell(new Phrase("Yılmaz", f));
            pdfPTable.AddCell(new Phrase("Erkek", f));

            pdfPTable.AddCell(new Phrase("Hakan", f));
            pdfPTable.AddCell(new Phrase("Işık", f));
            pdfPTable.AddCell(new Phrase("Erkek", f));

            document.Add(pdfPTable);

            document.Close();
            return File("/pdfReports/dosya1.pdf", "application/pdf", "dosya1.pdf");
        }
    }
}
