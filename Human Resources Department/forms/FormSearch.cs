using System;
using System.Windows.Forms;

using Human_Resources_Department.classes;
using Human_Resources_Department.classes.employees;
using Human_Resources_Department.classes.employees.main;

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
            int count = EmployeesLV.IsSelected() ? EmployeesLV.GetSelectedIndex() + 1 : 0;

            for (int i = count; i < EmployeesLV.GetCountItems() + count; i++)
            {
                int index = i % EmployeesLV.GetCountItems();
                
                if (   EmployeesIsEq.TextBox(textBox1,  index, EmployeesLV.I_FNAME) 
                    && EmployeesIsEq.TextBox(textBox2,  index, EmployeesLV.I_LNAME)
                    && EmployeesIsEq.TextBox(textBox3,  index, EmployeesLV.I_MNAME)
                    && EmployeesIsEq.TextBox(textBox4,  index, EmployeesLV.I_CITY)
                    && EmployeesIsEq.TextBox(textBox5,  index, EmployeesLV.I_JOB)
                    && EmployeesIsEq.TextBox(textBox9,  index, EmployeesLV.I_FAMILY)
                    && EmployeesIsEq.TextBox(textBox8,  index, EmployeesLV.I_EMAIL)
                    && EmployeesIsEq.TextBox(textBox10, index, EmployeesLV.I_TEL)
                    && EmployeesIsEq.TextBox(textBox12, index, EmployeesLV.I_SALARY)
                    && EmployeesIsEq.CheckBox(checkBox4, checkBox6, index, EmployeesLV.I_IS_ACTIVITY)
                    && EmployeesIsEq.CheckBox(checkBox1, checkBox5, index, EmployeesLV.I_IS_FULLTIME)
                    && EmployeesIsEq.DateTime(dateTimePicker1, checkBox2, index, EmployeesLV.I_BIRTHDAY)
                    && EmployeesIsEq.DateTime(dateTimePicker2, checkBox3, index, EmployeesLV.I_SETCOMPANY)
                ) {
                    EmployeesLV.SetSelected(index, true);
                    return;
                }
            }
        }
    }
}
