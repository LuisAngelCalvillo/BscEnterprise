using DataAccess.Entities;
using DataAccess.Interfaces;
using Logic.Interfaces;
using Shared.DTOs;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;
using Document = iTextSharp.text.Document;

namespace Logic.Services
{
    public class ReportService(IProductRepository productRepository) : IReportService
    {
        private readonly IProductRepository _productRepository = productRepository;
        public async Task<ResponseDataDto<byte[]>> GetInformationForProductsReport()
        {
            ResponseDataDto<byte[]> response = new();
            var products = await _productRepository.GetAllProducts();
            byte[] reportData = GenerateProductReport(products);
            response.Data = reportData;
            response.Completed = true;
            return response;
        }
        private static byte[] GenerateProductReport(List<Product> products)
        {
            using MemoryStream ms = new MemoryStream();
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, ms);
            document.Open();

            Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK);

            Paragraph title = new("PRODUCT REPORT", titleFont)
            {
                Alignment = Element.ALIGN_CENTER
            };
            document.Add(title);

            document.Add(new Paragraph(" "));

            Font normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);
            Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.WHITE);

            PdfPTable table = new(3)
            {
                WidthPercentage = 100
            };

            float headerPadding = 8f;

            PdfPCell headerCell2 = new PdfPCell(new Phrase("PRODUCT KEY", headerFont));
            headerCell2.BackgroundColor = BaseColor.DARK_GRAY;
            headerCell2.Padding = headerPadding;
            table.AddCell(headerCell2);

            PdfPCell headerCell3 = new PdfPCell(new Phrase("NAME", headerFont));
            headerCell3.BackgroundColor = BaseColor.DARK_GRAY;
            headerCell3.Padding = headerPadding;
            table.AddCell(headerCell3);

            PdfPCell headerCell4 = new PdfPCell(new Phrase("STOCK", headerFont));
            headerCell4.BackgroundColor = BaseColor.DARK_GRAY;
            headerCell4.Padding = headerPadding;
            table.AddCell(headerCell4);

            float dataPadding = 5f;

            foreach (var product in products)
            {
                PdfPCell cell2 = new(new Phrase(product.ProductKey, normalFont));
                cell2.Padding = dataPadding;
                table.AddCell(cell2);

                PdfPCell cell3 = new(new Phrase(product.Name, normalFont));
                cell3.Padding = dataPadding;
                table.AddCell(cell3);

                PdfPCell cell4 = new(new Phrase(product.Stock.ToString(), normalFont));
                cell4.Padding = dataPadding;
                table.AddCell(cell4);
            }

            document.Add(table);
            document.Close();

            return ms.ToArray();
        }
    }
}
