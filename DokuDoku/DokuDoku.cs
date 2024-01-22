using DokuDoku.Excel;
using DokuDoku.PDF;
using DokuDoku.Word;

namespace DokuDoku
{
    public static class DokuDoku
    {
        public static DokuDokuPDF PDF { get; set; } = new DokuDokuPDF();
        public static DokuDokuWord Word { get; set; } = new DokuDokuWord();
        public static DokuDokuExcel Excel { get; set; } = new DokuDokuExcel();

    }
}
