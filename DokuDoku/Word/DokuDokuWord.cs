using MigraDoc.DocumentObjectModel;

namespace DokuDoku.Word
{
    public class DokuDokuWord
    {
        #region Generation

        /// <summary>
        /// Generate Word file to a MemoryStream
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="DocumentConfig"></param>
        /// <returns></returns>
        public MemoryStream Generate(string fileName, Action<Document> DocumentConfig)
        {
            var ms = WordGenerator.GenerateWord(fileName, DocumentConfig);

            return ms;
        }

        /// <summary>
        /// Generate Word file to a Path
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="savePath"></param>
        /// <param name="DocumentConfig"></param>
        public void Generate(string fileName, string savePath, Action<Document> DocumentConfig)
        {
            WordGenerator.GenerateWord(fileName, savePath, DocumentConfig);
        }

        #endregion
    }
}
