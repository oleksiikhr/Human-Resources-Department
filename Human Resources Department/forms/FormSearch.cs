using System;
using System.Windows.Forms;

using Human_Resources_Department.classes;
using Human_Resources_Department.classes.employees;

namespace Human_Resources_Department.forms
{
    public partial class FormSearch : Form
    {
        private DataGridView d;

        public FormSearch(DataGridView d)
        {
            InitializeComponent();

            this.d = d;
            this.Text = Config.PROJECT_NAME + " - Пошук";
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            int count = (d.SelectedRows.Count > 0) ? d.SelectedRows[0].Index + 1 : 0;

            for (int i = count; i < d.Rows.Count + count; i++)
            {
                int index = i % d.Rows.Count;

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
                ) {
                    d.Rows[index].Selected = true;
                    return;
                }
            }
        }

        private bool IsEqualsTextBox(TextBox t, int iRow, int iCell)
        {
            if ( string.IsNullOrWhiteSpace(t.Text) )
                return true;

            return string.Equals(t.Text.Trim(), d.Rows[iRow].Cells[iCell].Value.ToString(), StringComparison.OrdinalIgnoreCase);
        }
        
        private bool IsEqualsCheckBox(CheckBox c, CheckBox isActive, int iRow, int iCell)
        {
            if (isActive.Checked)
                return c.Checked == Boolean.Parse( d.Rows[iRow].Cells[iCell].Value.ToString() );

            return true;
        }

        private bool IsEqualsDateTimePicker(DateTimePicker dtp, CheckBox isActive, int iRow, int iCell)
        {
            if (isActive.Checked)
                if ( ! dtp.Value.Date.Equals(d.Rows[iRow].Cells[iCell].Value) )
                    return false;

            return true;
        }
    }
}
