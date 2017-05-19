using System;
using System.Windows.Forms;

using Human_Resources_Department.classes;
using Human_Resources_Department.classes.helplers;
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
                if (   !HEquals.E(textBox1,  i, EmployeesLV.I_FNAME)
                    || !HEquals.E(textBox2,  i, EmployeesLV.I_LNAME)
                    || !HEquals.E(textBox3,  i, EmployeesLV.I_MNAME)
                    || !HEquals.E(textBox4,  i, EmployeesLV.I_MNAME)
                    || !HEquals.E(textBox5,  i, EmployeesLV.I_JOB)
                    || !HEquals.E(textBox9,  i, EmployeesLV.I_FAMILY)
                    || !HEquals.E(textBox8,  i, EmployeesLV.I_EMAIL)
                    || !HEquals.E(textBox10, i, EmployeesLV.I_TEL)
                    || !HEquals.E(textBox12, i, EmployeesLV.I_SALARY)
                    || !HEquals.E(checkBox4, checkBox6, i, EmployeesLV.I_IS_ACTIVITY)
                    || !HEquals.E(checkBox1, checkBox5, i, EmployeesLV.I_IS_FULLTIME)
                    || !HEquals.E(dateTimePicker1, checkBox2, i, EmployeesLV.I_BIRTHDAY)
                    || !HEquals.E(dateTimePicker2, checkBox3, i, EmployeesLV.I_SETCOMPANY)
                ) {
                    EmployeesLV.Delete(i--);
                }
            }
        }
    }
}
