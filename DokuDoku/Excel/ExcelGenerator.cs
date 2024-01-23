using DokuDoku.PDF;
using MigraDoc.DocumentObjectModel;

namespace DokuDoku.Excel
{
    public static class ExcelGenerator
    {
        /// <summary>
        /// Generate Excel file to MemoryStream
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="DocumentConfig"></param>
        /// <returns></returns>
        public static MemoryStream GenerateExcel(string fileName, Action<Document> DocumentConfig)
        {
            var ms = PDFGenerator.GenerateXlsx(fileName, DocumentConfig);

            return ms;
        }

        /// <summary>
        /// Generate Excel file to a Path
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="savePath"></param>
        /// <param name="DocumentConfig"></param>
        public static void GenerateExcel(string fileName, string savePath, Action<Document> DocumentConfig)
        {
            PDFGenerator.GenerateXlsx(fileName, savePath, DocumentConfig);
        }
    }
}
