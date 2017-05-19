using System;
using System.IO;
using System.Windows.Forms;

using Human_Resources_Department.classes;
using Human_Resources_Department.classes.db;
using Human_Resources_Department.classes.employees.db;
using Human_Resources_Department.classes.employees.main;

namespace Human_Resources_Department.forms
{
    public partial class FormInsert : Form
    {
        private string pathImage = null;

        public FormInsert()
        {
            InitializeComponent();
            
            Text = Config.PROJECT_NAME + " - Додати працівника";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bool isCorrectSalary = double.TryParse(textBox12.Text, out double salary);
            if ( !isCorrectSalary && !string.IsNullOrWhiteSpace(textBox12.Text) )
            {
                MessageBox.Show("В зарплаті повинні бути тільки числа", "Помилка");
                return;
            }

            if ( string.IsNullOrWhiteSpace(textBox1.Text) )
            {
                MessageBox.Show("Повинно бути вказано ім'я", "Помилка");
                return;
            }
            
            int isInsert = Database.Insert(new MainTable
            {
                FName = textBox1.Text,
                LName = textBox2.Text,
                MName = textBox3.Text,
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
                EmployeesLV.AddNewToBDAndToLV();

                label9.Visible = true;
                timer1.Enabled = true;

                if (pathImage == null)
                    return;

                try
                {
                    int count = (EmployeesLV.GetCountItems() > 0) ? EmployeesLV.GetCountItems() : 1;

                    Directory.CreateDirectory(Config.currentFolder + "\\img");

                    File.Copy(
                        pathImage,
                        Config.currentFolder + "\\img\\" + count + Path.GetExtension(pathImage)
                    );
                }
                catch
                {
                    MessageBox.Show("Файл не зберігся", "Помилка");
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "Image Files(*.JPG, *.PNG) | *.JPG; *.PNG"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pathImage = dialog.FileName;
                label14.Text = "Файл: " + pathImage;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label9.Visible = false;
            timer1.Enabled = false;
        }

        private void Label15_Click(object sender, EventArgs e)
        {
            label14.Text = "Файл не вибран";
            pathImage = null;
        }
    }
}
