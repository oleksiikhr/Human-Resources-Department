using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Human_Resources_Department.classes.helplers
{
    class HExcel
    {
        private Excel.Application excel;
        private Excel.Workbook workBook;
        private Excel.Worksheet worksSheet;

        public HExcel()
        {
            excel = new Excel.Application();
        }

        public bool ExportExcel()
        {
            try
            {
                workBook = excel.Workbooks.Add(Type.Missing);
                worksSheet = workBook.Sheets[1];
                return true;
            }
            catch
            {
                MessageBox.Show("Помилка");
                return false;
            }
        }

        public bool OpenExcel()
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    workBook = excel.Workbooks.Open(dialog.FileName);
                    worksSheet = workBook.Sheets[1];
                    return true;
                }
                catch
                {
                    MessageBox.Show("Помилка");
                    return false;
                }
            }

            return false;
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
        
        public void CloseExcel()
        {
            workBook.Close();
        }
    }
}
