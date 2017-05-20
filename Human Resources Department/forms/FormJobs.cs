using System;
using System.Windows.Forms;
using System.Collections.Generic;


using Human_Resources_Department.classes;
using Human_Resources_Department.classes.db.jobs;
namespace Human_Resources_Department.forms
{
    public partial class FormJobs : Form
    {
        public FormJobs()
        {
            InitializeComponent();

            IEnumerable<JobsTable> jobs = JobsModel.GetAllJobs();
            
            foreach (var job in jobs)
            {
                MessageBox.Show(job.Id.ToString());
                listBox1.Items.Add(job.Title);
            }

            Text = Config.PROJECT_NAME + " - Посади";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if ( string.IsNullOrWhiteSpace(textBox1.Text) )
                return;

            int isInsert = JobsModel.Insert(new JobsTable
            {
                Title = textBox1.Text
            });
            
            if (isInsert == 1)
                listBox1.Items.Add(textBox1.Text);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 0)
                return;

            int id = 0;
            var jobs = JobsModel.GetJobsByTitle(listBox1.SelectedItem.ToString());
            foreach (var job in jobs)
            {
                id = job.Id;
                break;
            }

            if (id == 0)
                return;

            int isDeleted = JobsModel.DeleteObject<JobsTable>(id);
            if (isDeleted == 1)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }
    }
}
