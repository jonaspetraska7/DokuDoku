using DokuDoku.PDF;

namespace Tests
{
    public class GenerationTests
    {
        [Fact]
        public void PDFGeneratesInPath()
        {
            DokuDoku.DokuDoku.PDF.Generate("Hello", ".", x =>
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
            DokuDoku.DokuDoku.PDF.Generate("Hello", x =>
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
            DokuDoku.DokuDoku.Word.Generate("Hello", ".", x =>
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
            DokuDoku.DokuDoku.Word.Generate("Hello", x =>
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
            DokuDoku.DokuDoku.Excel.Generate("Hello", ".", x =>
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
            DokuDoku.DokuDoku.Excel.Generate("Hello", x =>
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