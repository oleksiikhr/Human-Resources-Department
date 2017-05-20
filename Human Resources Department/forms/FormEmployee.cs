using System;
using System.Windows.Forms;

using Human_Resources_Department.classes;
using Human_Resources_Department.classes.employees.db;

namespace Human_Resources_Department.forms
{
    public partial class FormEmployee : Form
    {
        private int id;
        private bool isNew;
        private object[] data;

        public FormEmployee(int id = 0)
        {
            InitializeComponent();

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

            Text = Config.PROJECT_NAME + " - Додавання нового працівника: #" + id;
        }

        public void ExistsEmployee(int id)
        {
            this.id = id;
            Text = Config.PROJECT_NAME + " - Картка працівника: #" + id;

            try
            {
                var data = MainModel.GetOneData(id);

                foreach (var one in data)
                {
                    textBox2.Text = one.FName;
                }
            }
            catch { }
        }
    }
}
