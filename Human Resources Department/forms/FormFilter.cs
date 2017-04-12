using System;
using System.Windows.Forms;

using Human_Resources_Department.classes;
using Human_Resources_Department.classes.employees;

namespace Human_Resources_Department.forms
{
    public partial class FormFilter : Form
    {
        public FormFilter()
        {
            InitializeComponent();
            
            Text = Config.PROJECT_NAME + " - Фільтри";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < EmployeesDGV.GetCountRows(); i++)
            {
                // !!!
                if (   IsEqualsTextBox(textBox1,  i, EmployeesDGV.CELL_FNAME)
                    && IsEqualsTextBox(textBox2,  i, EmployeesDGV.CELL_LNAME)
                    && IsEqualsTextBox(textBox3,  i, EmployeesDGV.CELL_MNAME)
                    && IsEqualsTextBox(textBox4,  i, EmployeesDGV.CELL_CITY)
                    && IsEqualsTextBox(textBox5,  i, EmployeesDGV.CELL_JOB)
                    && IsEqualsTextBox(textBox9,  i, EmployeesDGV.CELL_FAMILY)
                    && IsEqualsTextBox(textBox8,  i, EmployeesDGV.CELL_EMAIL)
                    && IsEqualsTextBox(textBox10, i, EmployeesDGV.CELL_TEL)
                    && IsEqualsTextBox(textBox12, i, EmployeesDGV.CELL_SALARY))
                {
                    EmployeesDGV.SetVisible(i, true);
                }
                else
                {
                    if ( EmployeesDGV.GetCountSelectedRows() > 0 && EmployeesDGV.GetSelectedIndex().Equals(i) )
                    {
                        EmployeesDGV.LostCurrentCell();
                        EmployeesDGV.ClearSelected();
                        EmployeesPanel.ClearAllData();
                    }

                    EmployeesDGV.SetVisible(i, false);
                }
            }
        }

        private bool IsEqualsTextBox(TextBox t, int iRow, int iCell)
        {
            if ( string.IsNullOrWhiteSpace(t.Text) )
                return true;

            return string.Equals(t.Text.Trim(),
                EmployeesDGV.GetValueCell(iRow, iCell).ToString(),
                StringComparison.OrdinalIgnoreCase);
        }
    }
}
