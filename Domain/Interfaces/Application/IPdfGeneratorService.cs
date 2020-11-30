using SelectPdf;

namespace Domain.Interfaces.Application
{
    public interface IPdfGeneratorService
    {
        PdfDocument GerarPdf(string html, string contratoNome);

        byte[] GerarBytePdf(PdfDocument pdf);
    }
}
