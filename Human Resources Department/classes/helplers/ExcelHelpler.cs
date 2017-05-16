using System;
using Excel = Microsoft.Office.Interop.Excel;

namespace Human_Resources_Department.classes.helplers
{
    class ExcelHelpler
    {
        private Excel.Application excel;
        private Excel.Workbook workBook;
        private Excel.Worksheet worksSheet;

        public ExcelHelpler()
        {
            excel = new Excel.Application();
            workBook = excel.Workbooks.Add(Type.Missing);
            worksSheet = workBook.Sheets[1];
        }

        public void SetValue(int row, int col, object val, bool isFormula = false)
        {
            row++; col++;

            if (isFormula)
                worksSheet.Cells[row, col].Formula = val;
            else
                worksSheet.Cells[row, col] = val;
        }

        public void SetVisible(bool toggle = true)
        {
            excel.Visible = toggle;
            excel.UserControl = toggle;
        }
    }
}
