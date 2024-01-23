using MigraDoc.DocumentObjectModel;

namespace DokuDoku.Excel
{
    public class DokuDokuExcel
    {
        #region Generation

        /// <summary>
        /// Generate Excel file to a MemoryStream
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="DocumentConfig"></param>
        /// <returns></returns>
        public MemoryStream Generate(string fileName, Action<Document> DocumentConfig)
        {
            var ms = ExcelGenerator.GenerateExcel(fileName, DocumentConfig);

            return ms;
        }

        /// <summary>
        /// Generate Excel file to a Path
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="savePath"></param>
        /// <param name="DocumentConfig"></param>
        public void Generate(string fileName, string savePath, Action<Document> DocumentConfig)
        {
            ExcelGenerator.GenerateExcel(fileName, savePath, DocumentConfig);
        }

        #endregion
    }
}
