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
            int count = EmployeesLV.IsSelected() ? EmployeesLV.GetSelectedIndex() + 1 : 0;

            for (int i = count; i < EmployeesLV.GetCountItems() + count; i++)
            {
                int index = i % EmployeesLV.GetCountItems();
                
                if (   EmployeesSearch.IsEqualsTextBox(textBox1,  index, EmployeesLV.I_FNAME) 
                    && EmployeesSearch.IsEqualsTextBox(textBox2,  index, EmployeesLV.I_LNAME)
                    && EmployeesSearch.IsEqualsTextBox(textBox3,  index, EmployeesLV.I_MNAME)
                    && EmployeesSearch.IsEqualsTextBox(textBox4,  index, EmployeesLV.I_CITY)
                    && EmployeesSearch.IsEqualsTextBox(textBox5,  index, EmployeesLV.I_JOB)
                    && EmployeesSearch.IsEqualsTextBox(textBox9,  index, EmployeesLV.I_FAMILY)
                    && EmployeesSearch.IsEqualsTextBox(textBox8,  index, EmployeesLV.I_EMAIL)
                    && EmployeesSearch.IsEqualsTextBox(textBox10, index, EmployeesLV.I_TEL)
                    && EmployeesSearch.IsEqualsTextBox(textBox12, index, EmployeesLV.I_SALARY)
                    && EmployeesSearch.IsEqualsCheckBox(checkBox4, checkBox6, index, EmployeesLV.I_IS_ACTIVITY)
                    && EmployeesSearch.IsEqualsCheckBox(checkBox1, checkBox5, index, EmployeesLV.I_IS_FULLTIME)
                    && EmployeesSearch.IsEqualsDateTime(dateTimePicker1, checkBox2, index, EmployeesLV.I_BIRTHDAY)
                    && EmployeesSearch.IsEqualsDateTime(dateTimePicker2, checkBox3, index, EmployeesLV.I_SETCOMPANY)
                ) {
                    EmployeesLV.SetSelected(index, true);
                    return;
                }
            }
        }
    }
}
