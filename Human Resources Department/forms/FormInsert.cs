using System;
using System.IO;
using System.Windows.Forms;

using Human_Resources_Department.classes;
using Human_Resources_Department.classes.employees.db;
using Human_Resources_Department.classes.employees;

namespace Human_Resources_Department.forms
{
    public partial class FormInsert : Form
    {
        public bool isChanged;

        private DataGridView d;

        public FormInsert(DataGridView d)
        {
            InitializeComponent();

            this.d = d;
            this.Text = Config.PROJECT_NAME + " - Додати працівника";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if ( ! File.Exists( Config.currentFolder + "\\" + EmployeesModel.nameFile ) )
            {
                MessageBox.Show("Файл не знайдено", "Помилка");
                return;
            }

            EmployeesModel db = new EmployeesModel(Config.currentFolder + "\\" + EmployeesModel.nameFile);
            
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
            
            int isInsert = db.Insert( new EmployeesTable
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

            if (isInsert == 1)
            {
                UpdateDataGridView();
                label9.Visible = true;
                timer1.Enabled = true;
                isChanged = true;
            }
        }

        private void UpdateDataGridView()
        {
            EmployeesDGV e = new EmployeesDGV(this.d);
            e.SetDataSource();
            e.SetColorRows();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label9.Visible = false;
            timer1.Enabled = false;
        }
    }
}
