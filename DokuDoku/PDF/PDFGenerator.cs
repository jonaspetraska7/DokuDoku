using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MigraDoc.RtfRendering;
using Newtonsoft.Json.Linq;
using PdfSharp.Fonts;
using PdfSharp.Snippets.Font;

namespace DokuDoku.PDF
{
    public static class PDFGenerator
    {
        private static Document _document;
        private static Section _section;
        private static bool _fontResolverRan;

        /// <summary>
        /// Resolve PDF fonts and remake document
        /// </summary>
        private static void SetupPdf()
        {
            _document = new Document();
            _section = _document.AddSection();

            if (!_fontResolverRan)
            {
                if (PdfSharp.Capabilities.Build.IsCoreBuild)
                    GlobalFontSettings.FontResolver = new FailsafeFontResolver();
                _fontResolverRan = true;
            }
        }

        #region Main methods

        #region Generate 
        
        #region PDF
        
        /// <summary>
        /// Generate PDF to a MemoryStream
        /// </summary>
        /// <param name="pdfName"></param>
        /// <param name="DocumentConfig"></param>
        /// <returns></returns>
        public static MemoryStream GeneratePdf(string pdfName, Action<Document> DocumentConfig)
        {
            SetupPdf();

            DocumentConfig(_document);

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer();
            pdfRenderer.Document = _document;
            pdfRenderer.RenderDocument();
            var ms = new MemoryStream();
            pdfRenderer.PdfDocument.Save(ms);

            return ms;
        }

        /// <summary>
        /// Generate PDF to a Path
        /// </summary>
        /// <param name="pdfName"></param>
        /// <param name="savePath"></param>
        /// <param name="DocumentConfig"></param>
        public static void GeneratePdf(string pdfName, string savePath, Action<Document> DocumentConfig)
        {
            SetupPdf();

            DocumentConfig(_document);

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer();
            pdfRenderer.Document = _document;
            pdfRenderer.RenderDocument();
            pdfRenderer.PdfDocument.Save($"{savePath}\\{pdfName}.pdf");
        }
        
        #endregion
        
        #region XLSX

        /// <summary>
        /// Generate XLSX to a MemoryStream
        /// </summary>
        /// <param name="pdfName"></param>
        /// <param name="DocumentConfig"></param>
        /// <returns></returns>
        public static MemoryStream GenerateXlsx(string pdfName, Action<Document> DocumentConfig)
        {
            SetupPdf();

            DocumentConfig(_document);

            RtfDocumentRenderer rtfDocumentRenderer = new RtfDocumentRenderer();
            var ms = new MemoryStream();
            rtfDocumentRenderer.Render(_document, ms, false, null);

            return ms;
        }

        /// <summary>
        /// Generate XLSX to a Path
        /// </summary>
        /// <param name="pdfName"></param>
        /// <param name="savePath"></param>
        /// <param name="DocumentConfig"></param>
        public static void GenerateXlsx(string pdfName, string savePath, Action<Document> DocumentConfig)
        {
            SetupPdf();

            DocumentConfig(_document);

            RtfDocumentRenderer rtfDocumentRenderer = new RtfDocumentRenderer();
            var ms = new MemoryStream();
            rtfDocumentRenderer.Render(_document, ms, false, null);

            using (var fileStream = File.Create($"{savePath}\\{pdfName}.xlsx"))
            {
                ms.Seek(0, SeekOrigin.Begin);
                ms.CopyTo(fileStream);
            }
        }

        #endregion

        #region RTF

        /// <summary>
        /// Generate RTF to a MemoryStream
        /// </summary>
        /// <param name="pdfName"></param>
        /// <param name="DocumentConfig"></param>
        /// <returns></returns>
        public static MemoryStream GenerateDocx(string pdfName, Action<Document> DocumentConfig)
        {
            SetupPdf();

            DocumentConfig(_document);

            RtfDocumentRenderer rtfDocumentRenderer= new RtfDocumentRenderer();
            var ms = new MemoryStream();
            rtfDocumentRenderer.Render(_document, ms, false, null);

            return ms;
        }

        /// <summary>
        /// Generate RTF to a Path
        /// </summary>
        /// <param name="pdfName"></param>
        /// <param name="savePath"></param>
        /// <param name="DocumentConfig"></param>
        public static void GenerateDocx(string pdfName, string savePath, Action<Document> DocumentConfig)
        {
            SetupPdf();

            DocumentConfig(_document);

            RtfDocumentRenderer rtfDocumentRenderer = new RtfDocumentRenderer();
            var ms = new MemoryStream();
            rtfDocumentRenderer.Render(_document, ms, false, null);

            using (var fileStream = File.Create($"{savePath}\\{pdfName}.docx"))
            {
                ms.Seek(0, SeekOrigin.Begin);
                ms.CopyTo(fileStream);
            }
        }

        #endregion

        #endregion

        #endregion

        #region Section layer

        /// <summary>
        /// Add Text
        /// </summary>
        /// <param name="document"></param>
        /// <param name="tableName"></param>
        /// <param name="TableConfig"></param>
        public static void AddText(this Document document, string text)
        {
            var section = document.LastSection;
            section.AddParagraph(" ");
            section.AddParagraph(text);
        }

        /// <summary>
        /// Add Table
        /// </summary>
        /// <param name="document"></param>
        /// <param name="tableName"></param>
        /// <param name="TableConfig"></param>
        public static void AddTable(this Document document, string? tableName, Action<Table> TableConfig,
            bool renderOnCondition = true)
        {
            if (renderOnCondition)
            {
                var section = document.LastSection;
                section.AddParagraph(" ");
                section.AddParagraph(tableName).Format.Font.Bold = true;
                var table = section.AddTable();

                TableConfig(table);
            }
        }

        #endregion

        #region Table configuration and properties

        /// <summary>
        /// Table configuration
        /// </summary>
        /// <param name="table"></param>
        /// <param name="useBorders"></param>
        /// <param name="columns"></param>
        public static void Config(this Table table, bool useBorders = true, params int[] columns)
        {
            table.Borders.Visible = useBorders;
            table.LeftPadding = 0;
            table.Format.LeftIndent = 3;
            foreach (var c in columns)
            {
                var col = table.AddColumn();
                col.Width = c;
            }
        }

        /// <summary>
        /// Single Property
        /// </summary>
        /// <param name="table"></param>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue"></param>
        public static void Property(this Table table, string? propertyName, string? propertyValue)
        {
            var row = table.AddRow();
            row.Cells[0].AddParagraph(propertyName ?? string.Empty);
            row.Cells[1].AddParagraph(propertyValue ?? string.Empty);
        }

        /// <summary>
        /// Rows
        /// </summary>
        /// <param name="table"></param>
        /// <param name="values"></param>
        public static void Property(this Table table, params string?[] values)
        {
            var row = table.AddRow();
            for (int i = 0; i < values.Length; i++)
            {
                row.Cells[i].AddParagraph(values[i] ?? string.Empty);
            }
        }

        /// <summary>
        /// Complex Property
        /// </summary>
        /// <param name="table"></param>
        /// <param name="propertyName"></param>
        /// <param name="TableConfig"></param>
        public static void Property(this Table table, string? propertyName, Action<Table> TableConfig)
        {
            var row = table.AddRow();
            row.Cells[0].AddParagraph(propertyName ?? string.Empty);
            var innerTable = row.Cells[1].Elements.AddTable();

            TableConfig(innerTable);
        }
        
        /// <summary>
        /// Table Property
        /// </summary>
        /// <param name="table"></param>
        /// <param name="propertyName"></param>
        /// <param name="TableConfig"></param>
        public static void Property(this Table table, Action<Table> TableConfig)
        {
            var row = table.AddRow();
            var innerTable = row.Cells[0].Elements.AddTable();

            TableConfig(innerTable);
        }

        #endregion

        #region Automatic table generation

        public static void ConvertToTable(this Document document, object x, string tableName = "", 
            bool renderOnCondition = true)
        {
            if (x == null)
            {
                return;
            }
            if (renderOnCondition)
            {
                var section = document.LastSection;
                section.AddParagraph(" ");
                section.AddParagraph(tableName).Format.Font.Bold = true;
                var table = section.AddTable();
                
                table.ConvertToTable(x);
            }
        }

        /// <summary>
        /// Automatic table generation
        /// </summary>
        /// <param name="innerTable"></param>
        /// <param name="x"></param>
        /// <param name="isInnerTable"></param>
        private static void ConvertToTable(this Table innerTable, object x, params int[] columns)
        {
            var jObject = JObject.FromObject(x);

            if (jObject == null)
            {
                return;
            }

            Table table = innerTable;

            int w = 500;

            if (columns.Length == 0)
            {
                columns = new[] { w/4, w-(w/4) };
            }
            
            table.Config(true, columns);

            foreach (var prop in jObject.Properties())
            {
                if ((!prop.Value?.GetType().ToString().Contains("JArray") ?? false) && (prop.Value?.HasValues ?? false))
                {
                    table.Property(prop.Name, x =>
                    {
                        x.ConvertToTable(prop.Value, columns[1]/4, columns[1]-(columns[1]/4));
                    });
                }
                else
                {
                    if (prop.Value?.GetType().ToString().Contains("JArray") ?? false)
                    {
                        table.Property(prop.Name, x =>
                        {
                            x.ConvertToTableArray(prop.Value as JArray, columns[1]);
                        });
                    }
                    else
                    {
                        table.Property(prop.Name, prop.Value?.ToString());
                    }
                }
            }
        }
        
        /// <summary>
        /// Automatic table generation
        /// </summary>
        /// <param name="innerTable"></param>
        /// <param name="x"></param>
        /// <param name="isInnerTable"></param>
        private static void ConvertToTableArray(this Table innerTable, object x, params int[] columns)
        {
            var jArray = JArray.FromObject(x);

            if (jArray == null)
            {
                return;
            }

            Table table = innerTable;

            table.Config(true, columns);

            foreach (var prop in jArray)
            {
                if ((!prop?.GetType().ToString().Contains("JArray") ?? false) && (prop?.HasValues ?? false))
                {
                    table.Property(x =>
                    {
                        x.ConvertToTable(prop, columns[0]/4, columns[0]-(columns[0]/4));
                    });
                }
                else
                {
                    if (prop?.GetType().ToString().Contains("JArray") ?? false)
                    {
                        table.Property(x =>
                        {
                            x.ConvertToTableArray(prop as JArray, columns[0]);
                        });
                    }
                    else
                    {
                        table.Property(prop?.ToString());
                    }
                }
            }
        }

        #endregion
    
    }
}
