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
        private const int I_ID     = 0;
        private const int I_FNAME  = 1;
        private const int I_LNAME  = 2;
        private const int I_SALARY = 3;
        private const int I_NDFL   = 4;
        private const int I_VZ     = 5;
        private const int I_ESV    = 6;
        private const int I_CLEAR  = 7;

        public FormSalary()
        {
            InitializeComponent();

            Text = Config.PROJECT_NAME + " - Зарплата";

            HListView.Normillize(listView1);
            HPanel.ActivateToggle(panel1);

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
            listView1.Columns.Add("Чиста зарплата");
        }

        private void FillData()
        {
            //try
            //{
            //    var data = new EmployeesModel(Config.currentFolder + "\\" + EmployeesModel.nameFile)
            //        .GetAllData(true);

            //    foreach (var one in data)
            //    {
            //        var salary = new HSalary(one.Salary);

            //        listView1.Items.Add( new ListViewItem( new[] {
            //            HListView.T(one.Id), HListView.T(one.FName), HListView.T(one.LName), HListView.T(one.Salary),
            //            salary.GetNDFL().ToString(), salary.GetVZ().ToString(),
            //            salary.GetESV().ToString(), salary.GetClearSalary().ToString()
            //        }));
            //    }
            //}
            //catch
            //{
            //    Close();
            //}
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

            pictureBox1.Image = Employees.GetImageUrl( GetSelectedID() );
            textBox1.Text = GetSelectedItem(I_FNAME).ToString();
            textBox5.Text = GetSelectedItem(I_LNAME).ToString();
            textBox2.Text = GetSelectedItem(I_SALARY).ToString();
            textBox3.Text = GetSelectedItem(I_NDFL).ToString();
            textBox4.Text = GetSelectedItem(I_VZ).ToString();
            textBox6.Text = GetSelectedItem(I_ESV).ToString();
            textBox7.Text = GetSelectedItem(I_CLEAR).ToString();
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

        private object GetItem(int row, int cell)
        {
            return listView1.Items[row].SubItems[cell].Text;
        }

        private int GetSelectedID()
        {
            if ( ! IsSelected() )
                return 0;

            return Convert.ToInt32( listView1.SelectedItems[0].SubItems[I_ID].Text );
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if ( listView1.Items.Count == 0 )
                return;

            HScreenshot.CreateWithDialog(panel1);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if ( listView1.Items.Count == 0 )
                return;

            HExcel excel = new HExcel();

            if ( ! excel.ExportExcel() )
                return;

            int row = 0;

            excel.SetValue(row, I_ID,     "#");
            excel.SetValue(row, I_FNAME,  "Ім'я");
            excel.SetValue(row, I_LNAME,  "Прізвище");
            excel.SetValue(row, I_SALARY, "Зарплата");
            excel.SetValue(row, I_NDFL,   "НДФЛ");
            excel.SetValue(row, I_VZ,     "ВЗ");
            excel.SetValue(row, I_ESV,    "ЄСВ");
            excel.SetValue(row, I_CLEAR,  "Чиста зарплата");

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                row = i + 1;

                excel.SetValue(row, I_ID,     GetItem(i, I_ID));
                excel.SetValue(row, I_FNAME,  GetItem(i, I_FNAME));
                excel.SetValue(row, I_LNAME,  GetItem(i, I_LNAME));
                excel.SetValue(row, I_SALARY, ReplaceComma(GetItem(i, I_SALARY).ToString()));
                excel.SetValue(row, I_NDFL,   ReplaceComma(GetItem(i, I_NDFL).ToString()));
                excel.SetValue(row, I_VZ,     ReplaceComma(GetItem(i, I_VZ).ToString()));
                excel.SetValue(row, I_ESV,    ReplaceComma(GetItem(i, I_ESV).ToString()));
                excel.SetValue(row, I_CLEAR,  ReplaceComma(GetItem(i, I_CLEAR).ToString()));
            }

            excel.SetValue(row++, I_SALARY, "=SUM(D2:D" + row + ")", true);
            excel.SetValue(row, I_NDFL, "=SUM(E2:E" + row + ")", true);
            excel.SetValue(row, I_VZ, "=SUM(F2:F" + row + ")", true);
            excel.SetValue(row, I_ESV, "=SUM(G2:G" + row + ")", true);
            excel.SetValue(row, I_CLEAR, "=SUM(H2:H" + row + ")", true);

            excel.SetVisible();
        }

        private string ReplaceComma(string text)
        {
            return text.Replace(",", ".");
        }
    }
}
