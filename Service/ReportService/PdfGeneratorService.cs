using System;
using System.IO;
using Domain.Interfaces.Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

namespace Service.ReportService
{
    public class PdfGeneratorService : IPdfGeneratorService
    {
        public readonly IHostingEnvironment _hosting;

        public PdfGeneratorService(IHostingEnvironment host){
            _hosting= host;
        }
        public object GerarPdf(string html, string contratoNome)
        {
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
            WebKitConverterSettings settings = new WebKitConverterSettings();
            //Set WebKit path
            settings.WebKitPath = Path.Combine(_hosting.ContentRootPath, "QtBinariesLinux");
            //Assign WebKit settings to HTML converter
            htmlConverter.ConverterSettings = settings;
            //Convert URL to PDF
            try{
                var x = htmlConverter.Convert(html);
            }catch(Exception ex){

            }
        
            PdfDocument document = new PdfDocument();
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            return new FileContentResult(stream.ToArray(), System.Net.Mime.MediaTypeNames.Application.Pdf);
 
            //var htmlToPdf = new HtmlToPdf();
            //var pdf = htmlToPdf.ConvertHtmlString(html);

            //return pdf;
        }
    }
}
