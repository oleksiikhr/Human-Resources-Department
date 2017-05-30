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
        private const int I_PIB    = 1;
        private const int I_SALARY = 2;
        private const int I_NDFL   = 3;
        private const int I_VZ     = 4;
        private const int I_ESV    = 5;
        private const int I_CLEAR  = 6;

        private const string I_ID_STR     = "#";
        private const string I_PIB_STR    = "ПІБ";
        private const string I_SALARY_STR = "Зарплата";
        private const string I_NDFL_STR   = "НДФЛ";
        private const string I_VZ_STR     = "ВЗ";
        private const string I_ESV_STR    = "ЄСВ";
        private const string I_CLEAR_STR  = "Чиста зарплата";

        public FormSalary()
        {
            InitializeComponent();

            Text = Config.PROJECT_NAME + " - Зарплата";

            HListView.Normillize(listView1);
            HPanel.ActivateToggle(panel1);

            SetColumns();
            FillListView();
        }

        private void SetColumns()
        {
            listView1.Columns.Add(I_ID_STR);
            listView1.Columns.Add(I_PIB_STR);
            listView1.Columns.Add(I_SALARY_STR);
            listView1.Columns.Add(I_NDFL_STR);
            listView1.Columns.Add(I_VZ_STR);
            listView1.Columns.Add(I_ESV_STR);
            listView1.Columns.Add(I_CLEAR_STR);
        }

        private void FillListView()
        {
            try
            {
                var data = MainModel.GetAllData(true);
                
                foreach (var one in data)
                {
                    var salary = new HSalary(one.Salary);
                    string name = HListView.T(one.LName) + " "
                        + Employees.GetInitial(one.FName) + ". "
                        + Employees.GetInitial(one.MName) + ".";

                    listView1.Items.Add(new ListViewItem(new[] {
                        HListView.T(one.Id), name, HListView.T(one.Salary),
                        HListView.T(salary.GetNDFL()), HListView.T(salary.GetVZ()),
                        HListView.T(salary.GetESV()), HListView.T(salary.GetClearSalary())
                    }));
                }
            }
            catch
            {
                Dispose();
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

            pictureBox1.Image = Employees.GetImage( GetSelectedID() );
            textBox1.Text = GetSelectedItem(I_PIB).ToString();
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

        private void Button2_Click(object sender, EventArgs e)
        {
            if ( listView1.Items.Count == 0 )
                return;

            HExcel excel = new HExcel();

            if ( ! excel.ExportExcel() )
                return;

            int row = 0;
            int count = listView1.Items.Count;

            excel.SetValue(row, I_ID,     I_ID_STR);
            excel.SetValue(row, I_PIB,    I_PIB_STR);
            excel.SetValue(row, I_SALARY, I_SALARY_STR);
            excel.SetValue(row, I_NDFL,   I_NDFL_STR);
            excel.SetValue(row, I_VZ,     I_VZ_STR);
            excel.SetValue(row, I_ESV,    I_ESV_STR);
            excel.SetValue(row, I_CLEAR,  I_CLEAR_STR);

            for (int i = 0; i < count; i++)
            {
                row = i + 1;

                excel.SetValue(row, I_ID,     GetItem(i, I_ID));
                excel.SetValue(row, I_PIB,    GetItem(i, I_PIB));
                excel.SetValue(row, I_SALARY, ReplaceComma(GetItem(i, I_SALARY).ToString()));
                excel.SetValue(row, I_NDFL,   ReplaceComma(GetItem(i, I_NDFL).ToString()));
                excel.SetValue(row, I_VZ,     ReplaceComma(GetItem(i, I_VZ).ToString()));
                excel.SetValue(row, I_ESV,    ReplaceComma(GetItem(i, I_ESV).ToString()));
                excel.SetValue(row, I_CLEAR,  ReplaceComma(GetItem(i, I_CLEAR).ToString()));
            }

            excel.SetValue(++row, I_SALARY, "=SUM(C2:C" + row + ")", true);
            excel.SetValue(row, I_NDFL, "=SUM(D2:D" + row + ")", true);
            excel.SetValue(row, I_VZ, "=SUM(E2:E" + row + ")", true);
            excel.SetValue(row, I_ESV, "=SUM(F2:F" + row + ")", true);
            excel.SetValue(row, I_CLEAR, "=SUM(G2:G" + row + ")", true);

            excel.SetVisible();
        }

        private string ReplaceComma(string text)
        {
            return text.Replace(",", ".");
        }
    }
}
