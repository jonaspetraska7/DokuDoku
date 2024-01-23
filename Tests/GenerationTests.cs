using DokuDoku;
using DokuDoku.PDF;

namespace Tests
{
    public class GenerationTests
    {
        [Fact]
        public void PDFGeneratesInPath()
        {
            Doku.PDF.Generate("Hello", ".", x =>
            {
                x.AddText("Hello");
                x.AddTable("Table1", x =>
                {
                    x.Config(true, 100, 100);
                    x.Property("Dokudoku", "IsCool");
                });
            });
        }

        [Fact]
        public void PDFGeneratesInMemoryStream()
        {
            Doku.PDF.Generate("Hello", x =>
            {
                x.AddText("Hello");
                x.AddTable("Table1", x =>
                {
                    x.Config(true, 100, 100);
                    x.Property("Dokudoku", "IsCool");
                });
            });
        }

        [Fact]
        public void RTFGeneratesInPath()
        {
            Doku.Word.Generate("Hello", ".", x =>
            {
                x.AddText("Hello");
                x.AddTable("Table1", x =>
                {
                    x.Config(true, 100, 100);
                    x.Property("Dokudoku", "IsCool");
                });
            });
        }

        [Fact]
        public void RTFGeneratesInMemoryStream()
        {
            Doku.Word.Generate("Hello", x =>
            {
                x.AddText("Hello");
                x.AddTable("Table1", x =>
                {
                    x.Config(true, 100, 100);
                    x.Property("Dokudoku", "IsCool");
                });
            });
        }

        [Fact]
        public void ExcelGeneratesInPath()
        {
            Doku.Excel.Generate("Hello", ".", x =>
            {
                x.AddText("Hello");
                x.AddTable("Table1", x =>
                {
                    x.Config(true, 100, 100);
                    x.Property("Dokudoku", "IsCool");
                });
            });
        }

        [Fact]
        public void ExcelGeneratesInMemoryStream()
        {
            Doku.Excel.Generate("Hello", x =>
            {
                x.AddText("Hello");
                x.AddTable("Table1", x =>
                {
                    x.Config(true, 100, 100);
                    x.Property("Dokudoku", "IsCool");
                });
            });
        }
    }
}