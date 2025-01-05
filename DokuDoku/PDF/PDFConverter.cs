using NAPS2.Images;
using NAPS2.Images.Gdi;
using NAPS2.ImportExport;
using NAPS2.Ocr;
using NAPS2.Pdf;
using NAPS2.Scan;
using NTwain.Data;
using System.Collections.Immutable;
using System.Text;

namespace DokuDoku.PDF
{
    public static class PDFConverter
    {
        public const string DefaultLanguageCode = "ENG";
        public static async Task<string> ConvertPdfOrPictureToText(string filePath, string languageCode = DefaultLanguageCode)
        {
            using var scanningContext = new ScanningContext(new GdiImageContext());
            scanningContext.OcrEngine = TesseractOcrEngine.Bundled(@"_tessdata");

            var imageImporter = new FileImporter(scanningContext);
            var images = new List<ProcessedImage>();
            var text = new StringBuilder();

            var result = await scanningContext.OcrEngine.ProcessImage(scanningContext, filePath, ocrParams: new OcrParams(languageCode), new CancellationToken());

            for (int i = 0; i < result?.Lines.Count; i++)
            {
                text.AppendLine(result.Lines[i].Text);
            }

            var plainText = text.ToString();

            return plainText;
        }

        public static async Task<string> ConvertPdfOrPictureToText(MemoryStream fileStream, string languageCode = DefaultLanguageCode)
        {
            var filePath = "temporaryFileThatIsDeletedAfterwards";
            File.WriteAllBytes("temporaryFileThatIsDeletedAfterwards", fileStream.ToArray());

            using var scanningContext = new ScanningContext(new GdiImageContext());
            scanningContext.OcrEngine = TesseractOcrEngine.Bundled(@"_tessdata");

            var imageImporter = new FileImporter(scanningContext);
            var images = new List<ProcessedImage>();
            var text = new StringBuilder();

            var result = await scanningContext.OcrEngine.ProcessImage(scanningContext, filePath, ocrParams: new OcrParams(languageCode), new CancellationToken());

            for (int i = 0; i < result?.Lines.Count; i++)
            {
                text.AppendLine(result.Lines[i].Text);
            }

            File.Delete(filePath);

            var plainText = text.ToString();

            return plainText;
        }

        public static async Task<MemoryStream> ConvertPictureToPdf(string filePath, string languageCode = DefaultLanguageCode)
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
            await pdfExporter.Export(pdfFile, images, ocrParams: new OcrParams(languageCode));

            return pdfFile;
        }

        public static async Task<MemoryStream> ConvertPictureToPdf(MemoryStream fileStream, string languageCode = DefaultLanguageCode)
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
            await pdfExporter.Export(pdfFile, images, ocrParams: new OcrParams(languageCode));

            File.Delete(filePath);

            return pdfFile;
        }
    }
}
