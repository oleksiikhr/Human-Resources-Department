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

            // Test
            db.Insert(new EmployeesTable
            {
                FName = textBox1.Text,
                LName = textBox2.Text
            });
        }
    }
}
