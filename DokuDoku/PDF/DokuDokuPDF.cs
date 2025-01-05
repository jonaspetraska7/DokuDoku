using MigraDoc.DocumentObjectModel;

namespace DokuDoku.PDF
{
    public class DokuDokuPDF
    {

        #region Generation

        /// <summary>
        /// Generate PDF to a MemoryStream
        /// </summary>
        /// <param name="pdfName"></param>
        /// <param name="DocumentConfig"></param>
        /// <returns></returns>
        public MemoryStream Generate(string pdfName, Action<Document> DocumentConfig)
        {
            var ms = PDFGenerator.GeneratePdf(pdfName, DocumentConfig);

            return ms;
        }

        /// <summary>
        /// Generate PDF to a Path
        /// </summary>
        /// <param name="pdfName"></param>
        /// <param name="savePath"></param>
        /// <param name="DocumentConfig"></param>
        public void Generate(string pdfName, string savePath, Action<Document> DocumentConfig)
        {
            PDFGenerator.GeneratePdf(pdfName, savePath, DocumentConfig);
        }

        #endregion

        #region Convert PictureToPDF

        public async Task<MemoryStream> ConvertPictureToPDF(MemoryStream pictureFile, string languageCode = PDFConverter.DefaultLanguageCode)
        {
            var ms = await PDFConverter.ConvertPictureToPdf(pictureFile, languageCode);

            return ms;
        }

        public async Task ConvertPictureToPDF(MemoryStream pictureFile, string savePath, string languageCode = PDFConverter.DefaultLanguageCode)
        {
            var ms = await PDFConverter.ConvertPictureToPdf(pictureFile, languageCode);
            File.WriteAllBytes(savePath, ms.ToArray());
        }

        public async Task<MemoryStream> ConvertPictureToPDF(string pictureFilePath, string languageCode = PDFConverter.DefaultLanguageCode)
        {
            var ms = await PDFConverter.ConvertPictureToPdf(pictureFilePath, languageCode);

            return ms;
        }

        public async Task ConvertPictureToPDF(string pictureFilePath, string savePath, string languageCode = PDFConverter.DefaultLanguageCode)
        {
            var ms = await PDFConverter.ConvertPictureToPdf(pictureFilePath, languageCode);

            File.WriteAllBytes(savePath, ms.ToArray());
        }

        #endregion

        #region Convert PictureToText

        public async Task<string> ConvertPictureToText(MemoryStream pictureFile, string languageCode = PDFConverter.DefaultLanguageCode)
        {
            var text = await PDFConverter.ConvertPdfOrPictureToText(pictureFile, languageCode);

            return text;
        }

        public async Task<string> ConvertPictureToText(string pictureFilePath, string languageCode = PDFConverter.DefaultLanguageCode)
        {
            var text = await PDFConverter.ConvertPdfOrPictureToText(pictureFilePath, languageCode);

            return text;
        }

        #endregion

        #region Convert PDFToText

        public async Task<string> ConvertPdfToText(MemoryStream pictureFile, string languageCode = PDFConverter.DefaultLanguageCode)
        {
            var text = await PDFConverter.ConvertPdfOrPictureToText(pictureFile, languageCode);

            return text;
        }

        public async Task<string> ConvertPdfToText(string pictureFilePath, string languageCode = PDFConverter.DefaultLanguageCode)
        {
            var text = await PDFConverter.ConvertPdfOrPictureToText(pictureFilePath, languageCode);

            return text;
        }

        #endregion
    }
}
