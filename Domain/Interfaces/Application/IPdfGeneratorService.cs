namespace Domain.Interfaces.Application
{
    public interface IPdfGeneratorService
    {
       object GerarPdf(string html, string contratoNome);

        
    }
}
