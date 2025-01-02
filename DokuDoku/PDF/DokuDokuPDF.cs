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

        #region Convert

        public async Task<MemoryStream> ConvertPictureToPDF(MemoryStream pictureFile)
        {
            var ms = await PDFConverter.ConvertPictureToPdf(pictureFile);

            return ms;
        }

        public async Task ConvertPictureToPDF(MemoryStream pictureFile, string savePath)
        {
            var ms = await PDFConverter.ConvertPictureToPdf(pictureFile);
            File.WriteAllBytes(savePath, ms.ToArray());
        }

        public async Task<MemoryStream> ConvertPictureToPDF(string pictureFilePath)
        {
            var ms = await PDFConverter.ConvertPictureToPdf(pictureFilePath);

            return ms;
        }

        public async Task ConvertPictureToPDF(string pictureFilePath, string savePath)
        {
            var ms = await PDFConverter.ConvertPictureToPdf(pictureFilePath);

            File.WriteAllBytes(savePath, ms.ToArray());
        }

        #endregion

    }
}
