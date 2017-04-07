using System;
using System.Windows.Forms;

using Human_Resources_Department.classes;
using Human_Resources_Department.classes.employees.db;

namespace Human_Resources_Department.forms
{
    public partial class FormInsert : Form
    {
        public bool isChanged;

        private DataGridView dg;

        public FormInsert(DataGridView dg)
        {
            this.dg = dg;

            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Database db = new EmployeesModel(Config.currentFolder + "\\" + EmployeesModel.nameFile);
            
            bool isCorrectSalary = double.TryParse(textBox12.Text, out double salary);
            if ( ! isCorrectSalary && ! string.IsNullOrWhiteSpace(textBox12.Text) )
            {
                MessageBox.Show("В зарплаті повинні бути тільки числа", "Помилка");
                return;
            }

            if ( string.IsNullOrWhiteSpace(textBox1.Text) )
            {
                MessageBox.Show("Повинно бути вказано ім'я", "Помилка");
                return;
            }
            
            db.Insert(new EmployeesTable
            {
                FName = textBox1.Text,
                MName = textBox3.Text,
                LName = textBox2.Text,
                Job = textBox5.Text,
                City = textBox4.Text,
                Family = textBox9.Text,
                Email = textBox8.Text,
                Tel = textBox10.Text,
                Salary = salary,
                IsActivity = true,
                IsFulltime = checkBox1.Checked,
                Birthday = dateTimePicker1.Value.Date,
                SetCompany = dateTimePicker2.Value.Date,
                UpdateAt = DateTime.Today,
            });

            label9.Visible = true;
            timer1.Enabled = true;
            isChanged = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label9.Visible = false;
            timer1.Enabled = false;
        }
    }
}
