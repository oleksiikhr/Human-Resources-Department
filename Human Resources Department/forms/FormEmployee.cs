using Human_Resources_Department.classes;
using System;
using System.Windows.Forms;

namespace Human_Resources_Department.forms
{
    public partial class FormEmployee : Form
    {
        private int id;
        private object[] data;

        public FormEmployee(int id)
        {
            InitializeComponent();

            this.id = id;

            try
            {

            }
            catch
            {
                return;
            }

            Text = Config.PROJECT_NAME + " - Картка працівника: #" + (id + 1);
        }
    }
}
