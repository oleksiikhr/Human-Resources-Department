using System;
using System.Linq;
using System.Windows.Forms;

using Human_Resources_Department.classes;
using Human_Resources_Department.classes.db.jobs;
using Human_Resources_Department.classes.employees.db;

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

            Text = Config.PROJECT_NAME + " - Додавання нового працівника: #" + id;
        }

        public void ExistsEmployee(int id)
        {
            this.id = id;
            Text = Config.PROJECT_NAME + " - Картка працівника: #" + id;

            try
            {
                var data = MainModel.GetOneData(id).First();
                string job = JobsModel.GetJobs(data.JobsId).First().Title;

                MessageBox.Show(job);
                
                textBox2.Text = data.FName;
                comboBox1.Text = job;
            }
            catch { }
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            if (isNew)
            {
                int jobID = JobsModel.GetJobs(comboBox1.Text).First().Id;

                MessageBox.Show(jobID.ToString());

                MainModel.Insert(new MainTable
                {
                    FName = textBox2.Text,
                    MName = textBox3.Text,
                    LName = textBox1.Text,
                    JobsId = jobID
                });
                return;
            }

            MainModel.Update(new MainTable {
                Id = id,
                FName = textBox2.Text
            });
        }
    }
}
