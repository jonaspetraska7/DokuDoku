using DokuDoku.PDF;
using MigraDoc.DocumentObjectModel;

namespace DokuDoku.Word
{
    public static class WordGenerator
    {
        /// <summary>
        /// Generate Word file to MemoryStream
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="DocumentConfig"></param>
        /// <returns></returns>
        public static MemoryStream GenerateWord(string fileName, Action<Document> DocumentConfig)
        {
            var ms = PDFGenerator.GenerateDocx(fileName, DocumentConfig);

            return ms;
        }

        /// <summary>
        /// Generate Word file to a Path
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="savePath"></param>
        /// <param name="DocumentConfig"></param>
        public static void GenerateWord(string fileName, string savePath, Action<Document> DocumentConfig)
        {
            PDFGenerator.GenerateDocx(fileName, savePath, DocumentConfig);
        }
    }
}
