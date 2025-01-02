using DokuDoku;

namespace Tests
{/*
    public class PDFConversionTests
    {
        [Theory]
        [InlineData("Picture1")]
        [InlineData("Picture2")]
        [InlineData("Picture3")]
        [InlineData("Picture4")]
        public async Task PDFConvertsFromPathToMemoryStreamAsync(string fileName)
        {
            var path = @$"../../../TestData/{fileName}.png";
            await Doku.PDF.ConvertPictureToPDF(path);
        }

        [Theory]
        [InlineData("Picture1")]
        [InlineData("Picture2")]
        [InlineData("Picture3")]
        [InlineData("Picture4")]
        public async Task PDFConvertsFromMemoryStreamToMemoryStreamAsync(string fileName)
        {
            var file = new MemoryStream(File.ReadAllBytes(@$"../../../TestData/{fileName}.png"));
            await Doku.PDF.ConvertPictureToPDF(file);
        }

        [Theory]
        [InlineData("Picture1")]
        [InlineData("Picture2")]
        [InlineData("Picture3")]
        [InlineData("Picture4")]
        public async Task PDFConvertsFromMemoryStreamToPathAsync(string fileName)
        {
            var file = new MemoryStream(File.ReadAllBytes(@$"../../../TestData/{fileName}.png"));
            await Doku.PDF.ConvertPictureToPDF(file, $"{fileName}.pdf");
        }

        [Theory]
        [InlineData("Picture1")]
        [InlineData("Picture2")]
        [InlineData("Picture3")]
        [InlineData("Picture4")]
        public async Task PDFConvertsFromPathToPathAsync(string fileName)
        {
            var path = @$"../../../TestData/{fileName}.png";
            await Doku.PDF.ConvertPictureToPDF(path, $"{fileName}.pdf");
        }
    }
    */
}