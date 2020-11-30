using Domain.Interfaces.Application;
using SelectPdf;
using System.IO;

namespace Service.ReportService
{
    public class PdfGeneratorService : IPdfGeneratorService
    {
        public byte[] GerarBytePdf(PdfDocument pdf)
        {
            MemoryStream stream = new MemoryStream();
            pdf.Save(stream);

            byte[] docBytes = stream.ToArray();

            return docBytes;
        }

        public PdfDocument GerarPdf(string html, string contratoNome)
        {
            var htmlToPdf = new HtmlToPdf();
            var pdf = htmlToPdf.ConvertHtmlString(html);

            return pdf;
        }
    }
}
