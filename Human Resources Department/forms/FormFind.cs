using System;
using System.Windows.Forms;

using Human_Resources_Department.classes;
using Human_Resources_Department.classes.helplers;
using Human_Resources_Department.classes.employees.main;

namespace Human_Resources_Department.forms
{
    public partial class FormFind : Form
    {
        private bool isSearch;

        public FormFind(bool isSearch)
        {
            InitializeComponent();

            this.isSearch = isSearch;

            if (isSearch)
            {
                title.Text = "ПОШУК";
                button1.Text = "Знайти";
                Text = Config.PROJECT_NAME + " - Пошук";
            }
            else
            {
                title.Text = "Фільтри";
                button1.Text = "Відфільтрувати";
                Text = Config.PROJECT_NAME + " - Фільтри";
            }

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (isSearch)
            {
                Search();
            }
            else
            {
                Filter();
            }
        }
        
        private void Search()
        {
            int cur = EmployeesLV.IsSelected() ? EmployeesLV.GetSelectedIndex() + 1 : 0;
            int count = EmployeesLV.GetCountItems();

            for (int i = cur; i < cur + count; i++)
            {
                int index = i % count;

                if (   HEquals.E(textBox11, index, EmployeesLV.I_FNAME)
                    && HEquals.E(textBox7, index, EmployeesLV.I_LNAME)
                    && HEquals.E(textBox4, index, EmployeesLV.I_MNAME)
                    && HEquals.E(textBox5, index, EmployeesLV.I_JOB_ID)
                    && HEquals.E(textBox10, index, EmployeesLV.I_TEL_WORK)
                    && HEquals.E(textBox8, index, EmployeesLV.I_EMAIL)
                    && HEquals.E(comboBox1, checkBox6, index, EmployeesLV.I_IS_ACTIVITY)
                    && HEquals.E(comboBox2, checkBox1, index, EmployeesLV.I_SEX)
                    && HEquals.E(dateTimePicker1, checkBox2, index, EmployeesLV.I_EMPLOYMENT_DATE)
                    && HEquals.E(dateTimePicker2, checkBox3, index, EmployeesLV.I_UPDATE_AT)
                ) {
                    EmployeesLV.SetSelected(index, true);
                    return;
                }
            }
        }

        private void Filter()
        {
            for (int i = 0; i < EmployeesLV.GetCountItems(); i++)
            {
                if (   !HEquals.E(textBox11, i, EmployeesLV.I_FNAME)
                    || !HEquals.E(textBox7, i, EmployeesLV.I_LNAME)
                    || !HEquals.E(textBox4, i, EmployeesLV.I_MNAME)
                    || !HEquals.E(textBox5, i, EmployeesLV.I_JOB_ID)
                    || !HEquals.E(textBox10, i, EmployeesLV.I_TEL_WORK)
                    || !HEquals.E(textBox8, i, EmployeesLV.I_EMAIL)
                    || !HEquals.E(comboBox1, checkBox6, i, EmployeesLV.I_IS_ACTIVITY)
                    || !HEquals.E(comboBox2, checkBox1, i, EmployeesLV.I_SEX)
                    || !HEquals.E(dateTimePicker1, checkBox2, i, EmployeesLV.I_EMPLOYMENT_DATE)
                    || !HEquals.E(dateTimePicker2, checkBox3, i, EmployeesLV.I_UPDATE_AT)
                ) {
                    EmployeesLV.Delete(i--);
                }
            }
        }
    }
}
