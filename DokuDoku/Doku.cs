using DokuDoku.Excel;
using DokuDoku.PDF;
using DokuDoku.Word;

namespace DokuDoku
{
    public static class Doku
    {
        public static DokuDokuPDF PDF { get; set; } = new();
        public static DokuDokuWord Word { get; set; } = new();
        public static DokuDokuExcel Excel { get; set; } = new();

    }
}
