using System;
using System.Windows.Forms;

using Human_Resources_Department.classes;
using Human_Resources_Department.classes.employees;
using Human_Resources_Department.classes.employees.main;

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
                if (   !EmployeesIsEq.TextBox(textBox1,  i, EmployeesLV.I_FNAME)
                    || !EmployeesIsEq.TextBox(textBox2,  i, EmployeesLV.I_LNAME)
                    || !EmployeesIsEq.TextBox(textBox3,  i, EmployeesLV.I_MNAME)
                    || !EmployeesIsEq.TextBox(textBox4,  i, EmployeesLV.I_MNAME)
                    || !EmployeesIsEq.TextBox(textBox5,  i, EmployeesLV.I_JOB)
                    || !EmployeesIsEq.TextBox(textBox9,  i, EmployeesLV.I_FAMILY)
                    || !EmployeesIsEq.TextBox(textBox8,  i, EmployeesLV.I_EMAIL)
                    || !EmployeesIsEq.TextBox(textBox10, i, EmployeesLV.I_TEL)
                    || !EmployeesIsEq.TextBox(textBox12, i, EmployeesLV.I_SALARY)
                    || !EmployeesIsEq.CheckBox(checkBox4, checkBox6, i, EmployeesLV.I_IS_ACTIVITY)
                    || !EmployeesIsEq.CheckBox(checkBox1, checkBox5, i, EmployeesLV.I_IS_FULLTIME)
                    || !EmployeesIsEq.DateTime(dateTimePicker1, checkBox2, i, EmployeesLV.I_BIRTHDAY)
                    || !EmployeesIsEq.DateTime(dateTimePicker2, checkBox3, i, EmployeesLV.I_SETCOMPANY)
                ) {
                    EmployeesLV.Delete(i--);
                }
            }
        }
    }
}
