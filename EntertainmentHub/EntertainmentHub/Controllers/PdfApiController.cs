using EntertainmentHub.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OfficeOpenXml;

namespace EntertainmentHub.Controllers
{
    public class PdfApiController : ApiController
    {
        PDFclass db = new PDFclass();


        [System.Web.Http.HttpGet]
        public IHttpActionResult GetData()
        {
            var file = new FileInfo(@"C:\Users\a881881\Downloads\PDFS.xlsx");
            var package = new ExcelPackage(file);
            var worksheet = package.Workbook.Worksheets.First();
            var rowCount = worksheet.Dimension.Rows;
            var list = new List<PDFclass>();
            for (int row = 2; row <= rowCount; row++)
            {
                var item = new PDFclass
                {
                    Name = worksheet.Cells[row, 2].Value.ToString(),
                    Links = worksheet.Cells[row, 3].Value.ToString(),
                };
                list.Add(item);
            }
            return Ok(list);
        }
    }
}
