using System;
using System.Windows.Forms;

using Human_Resources_Department.classes;
using Human_Resources_Department.classes.helplers;
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
            //int count = EmployeesLV.IsSelected() ? EmployeesLV.GetSelectedIndex() + 1 : 0;

            //for (int i = count; i < EmployeesLV.GetCountItems() + count; i++)
            //{
            //    int index = i % EmployeesLV.GetCountItems();
                
            //    if (   HEquals.E(textBox1,  index, EmployeesLV.I_FNAME) 
            //        && HEquals.E(textBox2,  index, EmployeesLV.I_LNAME)
            //        && HEquals.E(textBox3,  index, EmployeesLV.I_MNAME)
            //        && HEquals.E(textBox4,  index, EmployeesLV.I_CITY)
            //        && HEquals.E(textBox5,  index, EmployeesLV.I_JOB)
            //        && HEquals.E(textBox9,  index, EmployeesLV.I_FAMILY)
            //        && HEquals.E(textBox10, index, EmployeesLV.I_TEL)
            //        && HEquals.E(textBox12, index, EmployeesLV.I_SALARY)
            //        && HEquals.E(checkBox4, checkBox6, index, EmployeesLV.I_IS_ACTIVITY)
            //        && HEquals.E(checkBox1, checkBox5, index, EmployeesLV.I_IS_FULLTIME)
            //        && HEquals.E(dateTimePicker1, checkBox2, index, EmployeesLV.I_BIRTHDAY)
            //        && HEquals.E(dateTimePicker2, checkBox3, index, EmployeesLV.I_SETCOMPANY)
            //    ) {
            //        EmployeesLV.SetSelected(index, true);
            //        return;
            //    }
            //}
        }
    }
}
