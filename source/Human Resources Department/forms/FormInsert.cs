using System;
using System.Windows.Forms;

using Human_Resources_Department.classes;
using Human_Resources_Department.classes.db;
using Human_Resources_Department.classes.db.tables;

namespace Human_Resources_Department.forms
{
    public partial class FormInsert : Form
    {
        public FormInsert()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Database db = new Database(Config.currentFolder + "\\" + EmployeesTable.nameFile);

            bool isCorrectSalary = double.TryParse(textBox12.Text, out double salary);

            if (!isCorrectSalary && !string.IsNullOrWhiteSpace(textBox12.Text))
            {
                MessageBox.Show("В зарплаті повинні бути тільки числа", "Помилка");
                return;
            }

            // Test
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
                IsActivity = checkBox1.Checked,
                IsFulltime = true,
                Birthday = dateTimePicker1.Value.Date,
                SetCompany = dateTimePicker2.Value.Date,
                UpdateAt = DateTime.Now,
            });
        }
    }
}
