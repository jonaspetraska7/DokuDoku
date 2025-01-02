using NAPS2.Images;
using NAPS2.Images.Gdi;
using NAPS2.ImportExport;
using NAPS2.Ocr;
using NAPS2.Pdf;
using NAPS2.Scan;

namespace DokuDoku.PDF
{
    public static class PDFConverter
    {
        public enum PDFConverterOcrLanguage
        {
            ENG,
            RUS
        }

        public static async Task<MemoryStream> ConvertPictureToPdf(string filePath, PDFConverterOcrLanguage lang = PDFConverterOcrLanguage.ENG)
        {
            using var scanningContext = new ScanningContext(new GdiImageContext());
            scanningContext.OcrEngine = TesseractOcrEngine.Bundled(@"_tessdata");

            var imageImporter = new ImageImporter(scanningContext);
            var images = new List<ProcessedImage>();

            await foreach (var image in imageImporter.Import(filePath))
            {
                images.Add(image);
            }

            var pdfExporter = new PdfExporter(scanningContext);

            var pdfFile = new MemoryStream();
            await pdfExporter.Export(pdfFile, images, ocrParams: new OcrParams(Enum.GetName(lang)));

            return pdfFile;
        }

        public static async Task<MemoryStream> ConvertPictureToPdf(MemoryStream fileStream, PDFConverterOcrLanguage lang = PDFConverterOcrLanguage.ENG)
        {
            var filePath = "temporaryFileThatIsDeletedAfterwards";
            File.WriteAllBytes("temporaryFileThatIsDeletedAfterwards", fileStream.ToArray());

            using var scanningContext = new ScanningContext(new GdiImageContext());
            scanningContext.OcrEngine = TesseractOcrEngine.Bundled(@"_tessdata");

            var imageImporter = new ImageImporter(scanningContext);
            var images = new List<ProcessedImage>();

            await foreach (var image in imageImporter.Import(filePath))
            {
                images.Add(image);
            }

            var pdfExporter = new PdfExporter(scanningContext);

            var pdfFile = new MemoryStream();
            await pdfExporter.Export(pdfFile, images, ocrParams: new OcrParams(Enum.GetName(lang)));

            File.Delete(filePath);

            return pdfFile;
        }
    }
}
