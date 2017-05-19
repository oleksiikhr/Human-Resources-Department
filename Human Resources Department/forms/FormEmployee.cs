using System;
using System.Windows.Forms;

namespace Human_Resources_Department.forms
{
    public partial class FormEmployee : Form
    {
        private int id;
        private object[] data;

        public FormEmployee()
        {
            InitializeComponent();
        }

        public FormEmployee(int id)
        {
            this.id = id;

            try
            {

            }
            catch
            {
                return;
            }
        }
    }
}
