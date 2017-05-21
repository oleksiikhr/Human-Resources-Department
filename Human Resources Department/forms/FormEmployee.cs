using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

using Human_Resources_Department.classes;
using Human_Resources_Department.classes.db.jobs;
using Human_Resources_Department.classes.employees;
using Human_Resources_Department.classes.employees.db;
using Human_Resources_Department.classes.employees.main;

namespace Human_Resources_Department.forms
{
    public partial class FormEmployee : Form
    {
        private int id;
        private bool isNew;
        
        public FormEmployee(int id = 0)
        {
            InitializeComponent();

            var jobs = JobsModel.GetAllJobs();
            foreach (var job in jobs)
            {
                comboBox1.Items.Add(job.Title);
            }

            if (id == 0)
            {
                NewEmployee();
                return;
            }

            ExistsEmployee(id);
        }

        public void NewEmployee()
        {
            isNew = true;
            id = MainModel.GetCountRecords() + 1;

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;

            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;

            Text = Config.PROJECT_NAME + " - Додати нового працівника: #" + id;
        }

        public void ExistsEmployee(int id)
        {
            this.id = id;
            Text = Config.PROJECT_NAME + " - Картка працівника: #" + id;

            MainTable main;

            try
            {
                main = MainModel.GetOneByID(id).First();
            }
            catch { return; }

            var employeesJobID = JobsModel.GetOneJobs(main.JobId);

            // Top
            textBox2.Text = main.FName;
            textBox1.Text = main.LName;
            textBox3.Text = main.MName;
            comboBox1.Text = employeesJobID.Count() != 0 ? employeesJobID.First().Title : "";

            // Middle Main
            textBox9.Text = main.TimeTableNum.ToString();
            textBox8.Text = main.IndividualTaxNum.ToString();
            comboBox3.Text = main.Sex ? "Чоловік" : "Жінка";

            textBox5.Text = main.Email;
            textBox6.Text = main.TelWork;
            textBox7.Text = main.TelHome;

            dateTimePicker2.Value = main.EmploymentDate;
            dateTimePicker3.Value = main.DateDismissal;
            dateTimePicker1.Value = main.UpdateAt;

            textBox4.Text = main.About;

            // Bottom
            comboBox2.Text = main.IsActivity ? "Працює" : "Звільнений";

            // Img
            pictureBox1.Image = Employees.GetImage(id);
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            int jobID = string.IsNullOrWhiteSpace(comboBox1.Text)
                ? 0
                : JobsModel.GetOneJobs(comboBox1.Text).First().Id;

            var main = new MainTable
            {
                Id = id,
                FName = textBox2.Text, // Top
                MName = textBox3.Text,
                LName = textBox1.Text,
                JobId = jobID,
                TimeTableNum = textBox9.Text, // Middle Main
                IndividualTaxNum = textBox8.Text,
                Sex = comboBox3.Text.Equals("Чоловік"),
                EmploymentDate = dateTimePicker2.Value.Date,
                DateDismissal = dateTimePicker3.Value.Date,
                UpdateAt = DateTime.Today,
                Email = textBox5.Text,
                TelWork = textBox6.Text,
                TelHome = textBox7.Text,
                About = textBox4.Text,
                IsActivity = comboBox2.Text.Equals("Працює") // Bottom
            };

            int isUpdated = isNew ? MainModel.Insert(main) : MainModel.Update(main);

            if (isUpdated == 1)
            {
                if (isNew)
                    EmployeesLV.AddOneData(id);
                else
                    EmployeesLV.UpdateOneData(id);

                EmployeesLV.UpdateSelected();
                label19.BackColor = Color.DarkSlateGray;
                label19.Text = "Збережено";
            }
            else
            {
                label19.BackColor = Color.FromArgb(185, 46, 59);
                label19.Text = "Не збережено";
            }

            label19.Visible = true;
            timer1.Enabled = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label19.Visible = false;
            timer1.Enabled = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Label16_Click(object sender, EventArgs e)
        {
            DeleteImage();
        }

        private void Label18_Click(object sender, EventArgs e)
        {
            DeleteImage();
            Employees.AddImage(id);
            pictureBox1.Image = Employees.GetImage(id);
        }

        private void DeleteImage()
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = null;
                Employees.CloseImage(id);
                Employees.DeleteImage(id);
            }
        }
    }
}
