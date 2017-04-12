using System;
using System.Windows.Forms;

using Human_Resources_Department.classes;
using Human_Resources_Department.classes.employees;

namespace Human_Resources_Department.forms
{
    public partial class FormSearch : Form
    {
        public FormSearch()
        {
            InitializeComponent();
            
            Text = Config.PROJECT_NAME + " - Пошук";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int count = (EmployeesDGV.GetCountSelectedRows() > 0)
                ? EmployeesDGV.GetSelectedIndex() + 1
                : 0;

            MessageBox.Show(EmployeesDGV.GetSelectedIndex().ToString());

            for (int i = count; i < EmployeesDGV.GetCountRows() + count; i++)
            {
                int index = i % EmployeesDGV.GetCountRows();

                if (   IsEqualsTextBox(textBox1,   index, EmployeesDGV.CELL_FNAME) 
                    && IsEqualsTextBox(textBox2,   index, EmployeesDGV.CELL_LNAME)
                    && IsEqualsTextBox(textBox3,   index, EmployeesDGV.CELL_MNAME)
                    && IsEqualsTextBox(textBox4,   index, EmployeesDGV.CELL_CITY)
                    && IsEqualsTextBox(textBox5,   index, EmployeesDGV.CELL_JOB)
                    && IsEqualsTextBox(textBox9,   index, EmployeesDGV.CELL_FAMILY)
                    && IsEqualsTextBox(textBox8,   index, EmployeesDGV.CELL_EMAIL)
                    && IsEqualsTextBox(textBox10,  index, EmployeesDGV.CELL_TEL)
                    && IsEqualsTextBox(textBox12,  index, EmployeesDGV.CELL_SALARY)
                    && IsEqualsCheckBox(checkBox4, checkBox6, index, EmployeesDGV.CELL_IS_ACTIVITY)
                    && IsEqualsCheckBox(checkBox1, checkBox5, index, EmployeesDGV.CELL_IS_FULLTIME)
                    && IsEqualsDateTimePicker(dateTimePicker1, checkBox2, index, EmployeesDGV.CELL_BIRTHDAY)
                    && IsEqualsDateTimePicker(dateTimePicker2, checkBox3, index, EmployeesDGV.CELL_SETCOMPANY)
                    && EmployeesDGV.IsVisibleRow(index)
                )
                {
                    EmployeesDGV.SetSelected(i, true);
                    return;
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
        
        private bool IsEqualsCheckBox(CheckBox c, CheckBox isActive, int iRow, int iCell)
        {
            if (isActive.Checked)
                return c.Checked == Boolean.Parse( EmployeesDGV.GetValueCell(iRow, iCell).ToString() );

            return true;
        }

        private bool IsEqualsDateTimePicker(DateTimePicker dtp, CheckBox isActive, int iRow, int iCell)
        {
            if (isActive.Checked)
                if ( ! dtp.Value.Date.Equals( EmployeesDGV.GetValueCell(iRow, iCell) ) )
                    return false;

            return true;
        }
    }
}
