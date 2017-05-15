using System;
using System.Windows.Forms;

using Human_Resources_Department.classes;
using Human_Resources_Department.classes.helplers;
using Human_Resources_Department.classes.employees;
using Human_Resources_Department.classes.employees.db;

namespace Human_Resources_Department.forms
{
    public partial class FormSalary : Form
    {
        public FormSalary()
        {
            InitializeComponent();

            LVHelpler.Normillize(listView1);
            SetColumns();
            FillData();
            PanelHelpler.ActivateToggle(panel1);
        }

        private void SetColumns()
        {
            listView1.Columns.Add("#");
            listView1.Columns.Add("Ім'я");
            listView1.Columns.Add("Прізвище");
            listView1.Columns.Add("Зарплата");
            listView1.Columns.Add("НДФЛ");
            listView1.Columns.Add("ВЗ");
            listView1.Columns.Add("ЄСВ");
            listView1.Columns.Add("Чиста Зарплата");
        }

        private void FillData()
        {
            try
            {
                var data = new EmployeesModel(Config.currentFolder + "\\" + EmployeesModel.nameFile)
                    .GetAllData(true);

                foreach (var one in data)
                {
                    var salary = new Salary(one.Salary);

                    listView1.Items.Add( new ListViewItem( new[] {
                        LVHelpler.T(one.Id), LVHelpler.T(one.FName), LVHelpler.T(one.LName), LVHelpler.T(one.Salary),
                        salary.GetNDFL().ToString(), salary.GetVZ().ToString(),
                        salary.GetESV().ToString(), salary.GetClearSalary().ToString()
                    }));
                }
            }
            catch
            {
                Close();
            }
        }

        private double GetSalary()
        {
            if ( ! IsSelected() )
                return 0;
            
            if ( Double.TryParse(GetSelectedItem(3).ToString(), out double salary) )
                return salary;

            return 0;
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( ! IsSelected() )
                return;

            MessageBox.Show(GetSelectedID() + "\n" + Employees.GetImageUrl(GetSelectedID()));

            pictureBox1.Image = Employees.GetImageUrl( GetSelectedID() );
            textBox1.Text = GetSelectedItem(1).ToString();
            textBox2.Text = GetSelectedItem(2).ToString();
            textBox3.Text = GetSelectedItem(3).ToString();
            textBox4.Text = GetSelectedItem(4).ToString();
            textBox5.Text = GetSelectedItem(5).ToString();
            textBox6.Text = GetSelectedItem(6).ToString();
            textBox7.Text = GetSelectedItem(7).ToString();
        }

        private bool IsSelected()
        {
            return listView1.SelectedItems.Count != 0;
        }

        private object GetSelectedItem(int cell)
        {
            if ( ! IsSelected() )
                return 0;

            return listView1.SelectedItems[0].SubItems[cell].Text;
        }

        private int GetSelectedID()
        {
            if ( ! IsSelected() )
                return 0;

            return Convert.ToInt32( listView1.SelectedItems[0].SubItems[0].Text );
        }
    }
}
