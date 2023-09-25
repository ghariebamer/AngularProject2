using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using SelectPdf;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExporterController : ControllerBase
    {
        [HttpGet("GeneratePDF")]

        public async Task<IActionResult> GeneratePDF(string INfoPage)
        {
            HtmlToPdf converter = new HtmlToPdf();
            //var Document = new PdfDocument();
            string HtmlContent = "<h1> test Pdf Service</h1>";
            //PdfGenerator.AddPdfPages(Document, HtmlContent, PdfSharpCore.PageSize.A4);
            SelectPdf.PdfDocument document = converter.ConvertHtmlString(HtmlContent);
            byte[]? response = null;
            using (MemoryStream ms = new MemoryStream())
            {
                document.Save(ms);
                response = ms.ToArray();
            }
            string FileName = INfoPage + new Guid() + ".PDF";
            return File(response, "application/pdf", FileName);
        }
    }
}
