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
            for (int i = 0; i < EmployeesLV.GetCountItems(); i++)
            {
                if (   !EmployeesSearch.IsEqualsTextBox(textBox1,  i, EmployeesLV.I_FNAME)
                    || !EmployeesSearch.IsEqualsTextBox(textBox2,  i, EmployeesLV.I_LNAME)
                    || !EmployeesSearch.IsEqualsTextBox(textBox3,  i, EmployeesLV.I_MNAME)
                    || !EmployeesSearch.IsEqualsTextBox(textBox4,  i, EmployeesLV.I_MNAME)
                    || !EmployeesSearch.IsEqualsTextBox(textBox5,  i, EmployeesLV.I_JOB)
                    || !EmployeesSearch.IsEqualsTextBox(textBox9,  i, EmployeesLV.I_FAMILY)
                    || !EmployeesSearch.IsEqualsTextBox(textBox8,  i, EmployeesLV.I_EMAIL)
                    || !EmployeesSearch.IsEqualsTextBox(textBox10, i, EmployeesLV.I_TEL)
                    || !EmployeesSearch.IsEqualsTextBox(textBox12, i, EmployeesLV.I_SALARY)
                    || !EmployeesSearch.IsEqualsCheckBox(checkBox4, checkBox6, i, EmployeesLV.I_IS_ACTIVITY)
                    || !EmployeesSearch.IsEqualsCheckBox(checkBox1, checkBox5, i, EmployeesLV.I_IS_FULLTIME)
                    || !EmployeesSearch.IsEqualsDateTime(dateTimePicker1, checkBox2, i, EmployeesLV.I_BIRTHDAY)
                    || !EmployeesSearch.IsEqualsDateTime(dateTimePicker2, checkBox3, i, EmployeesLV.I_SETCOMPANY)
                ) {
                    EmployeesLV.Delete(i--);
                }
            }
        }
    }
}
