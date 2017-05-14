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

            LV.Normillize(listView1);
            SetColumns();
            FillData();
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
        }

        private void FillData()
        {
            try
            {
                var data = new EmployeesModel(Config.currentFolder + "\\" + EmployeesModel.nameFile)
                    .GetAllData(true);

                foreach (var one in data)
                {
                    listView1.Items.Add( new ListViewItem( new[] {
                        LV.T(one.Id), LV.T(one.FName), LV.T(one.LName), LV.T(one.Salary)
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
            
            if ( Double.TryParse(listView1.SelectedItems[0].SubItems[3].Text, out double salary) )
                return salary;

            return 0;
        }

        private void Test()
        {
            if ( GetSalary() == 0 )
                return;

            MessageBox.Show( Salary.GetClearSalary( GetSalary() ).ToString() );
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( ! IsSelected() )
                return;

            Test();
        }

        private bool IsSelected()
        {
            return listView1.SelectedItems.Count != 0;
        }
    }
}
