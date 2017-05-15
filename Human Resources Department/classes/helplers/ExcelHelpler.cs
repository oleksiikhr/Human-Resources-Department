using System;
using Excel = Microsoft.Office.Interop.Excel;

namespace Human_Resources_Department.classes.helplers
{
    class ExcelHelpler
    {
        Excel.Application ObjExcel;
        Excel.Workbook ObjWorkBook;
        Excel.Worksheet ObjWorkSheet;

        public ExcelHelpler()
        {
            ObjExcel = new Excel.Application();
            ObjWorkBook = ObjExcel.Workbooks.Add(Type.Missing);
            ObjWorkSheet = ObjWorkBook.Sheets[1];
        }

        public void SetValue(int row, int col, object val)
        {
            if (row < 1 || col < 1)
                return;

            ObjWorkSheet.Cells[row, col] = val;
        }

        public void SetVisible(bool toggle = true)
        {
            ObjExcel.Visible = toggle;
            ObjExcel.UserControl = toggle;
        }
    }
}
