using System;
using System.Linq;
using System.Windows.Forms;

using Human_Resources_Department.classes;
using Human_Resources_Department.classes.db.jobs;
using Human_Resources_Department.classes.employees.db;

namespace Human_Resources_Department.forms
{
    public partial class FormJobs : Form
    {
        private bool isEdit;
        private int editIndex;

        public FormJobs()
        {
            InitializeComponent();

            var jobs = JobsModel.GetAllJobs();
            
            foreach (var job in jobs)
            {
                listBox1.Items.Add(job.Title);
            }

            Text = Config.PROJECT_NAME + " - Посади";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if ( string.IsNullOrWhiteSpace(textBox1.Text) )
                return;

            if (isEdit)
            {
                int isUpdate = JobsModel.Update( new JobsTable {
                    Id = JobsModel.GetOneJobs(listBox1.SelectedItem.ToString()).First().Id,
                    Title = textBox1.Text
                });

                if (isUpdate == 1)
                {
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    listBox1.Items.Add(textBox1.Text);
                    textBox1.Text = string.Empty;
                }

                return;
            }

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

            int id = JobsModel.GetOneJobs(listBox1.SelectedItem.ToString()).First().Id;
            
            if (id == 0)
                return;

            var employeeByID = MainModel.GetByJobsID(id);

            // Если пользователь привязан к этому ID
            if (employeeByID.Count() != 0)
            {
                MessageBox.Show(
                    "Працівник: " + employeeByID.First().LName + " " + employeeByID.First().FName
                    + " [#" + employeeByID.First().Id + "] - займає цю посаду",
                    "Помилка"
                );
                return;
            }

            int isDeleted = JobsModel.DeleteObject<JobsTable>(id);
            if (isDeleted == 1)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                isEdit = false;
                button1.Text = "Додати";
                return;
            }

            isEdit = true;
            button1.Text = "Оновити";
            editIndex = listBox1.SelectedIndex;
            textBox1.Text = listBox1.SelectedItem.ToString();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            isEdit = false;
            button1.Text = "Додати";
            textBox1.Text = string.Empty;
            listBox1.SelectedItem = null;
        }
    }
}
