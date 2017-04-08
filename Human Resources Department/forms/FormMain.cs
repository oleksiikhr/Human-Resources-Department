using System;
using System.Drawing;
using System.Windows.Forms;

using Human_Resources_Department.classes;
using Human_Resources_Department.classes.employees;

namespace Human_Resources_Department.forms
{
    public partial class FormMain : Form
    {
        private const string TEXT_SEARCH = "Швидкий пошук по Прізвищу";

        EmployeesDataGridView d;

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if ( ! SelectProject() )
            {
                Application.ExitThread();
            }

            this.WindowState = FormWindowState.Maximized;
            this.AcceptButton = button4;
        }
        
        private void FindField_Enter(object sender, EventArgs e)
        {
            if ( findField.Text.Equals(TEXT_SEARCH) )
                findField.Text = string.Empty;
        }
        
        private void FindField_Leave(object sender, EventArgs e)
        {
            if ( string.IsNullOrWhiteSpace(findField.Text) )
                findField.Text = TEXT_SEARCH;
        }

        private void FormChooseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectProject();
        }

        private bool SelectProject()
        {
            using ( FormChoose f = new FormChoose() )
            {
                f.ShowDialog();

                if ( f.IsOpen() )
                {
                    this.Text = Config.PROJECT_NAME + " - " + f.GetNameFolder();

                    SetNewDataGridView1();

                    return true;
                }
            }

            return false;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if ( string.IsNullOrEmpty(findField.Text) || findField.Text.Equals(TEXT_SEARCH) )
                return;

            d.FindCellAndSetFocus(findField.Text, EmployeesDataGridView.CELL_LNAME, true);
        }

        private void DataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || d == null)
                return;
            
            d.AddInfoOnDetailStaff(fieldFName,       EmployeesDataGridView.CELL_FNAME);
            d.AddInfoOnDetailStaff(fieldMName,       EmployeesDataGridView.CELL_MNAME);
            d.AddInfoOnDetailStaff(fieldLName,       EmployeesDataGridView.CELL_LNAME);
            d.AddInfoOnDetailStaff(fieldJob,         EmployeesDataGridView.CELL_JOB);
            d.AddInfoOnDetailStaff(fieldCity,        EmployeesDataGridView.CELL_CITY);
            d.AddInfoOnDetailStaff(fieldEmail,       EmployeesDataGridView.CELL_EMAIL);
            d.AddInfoOnDetailStaff(fieldTel,         EmployeesDataGridView.CELL_TEL);
            d.AddInfoOnDetailStaff(fieldFamily,      EmployeesDataGridView.CELL_FAMILY);
            d.AddInfoOnDetailStaff(fieldSalary,      EmployeesDataGridView.CELL_SALARY);
            d.AddInfoOnDetailStaff(fieldIsFulltime,  EmployeesDataGridView.CELL_IS_FULLTIME);
            d.AddInfoOnDetailStaff(fieldBirthday,    EmployeesDataGridView.CELL_BIRTHDAY);
            d.AddInfoOnDetailStaff(fieldSetCompany,  EmployeesDataGridView.CELL_SETCOMPANY);
            d.AddInfoOnDetailStaff(fieldUpdateAt,    EmployeesDataGridView.CELL_UPDATE_AT);
            
            if ( d.GetCellIsActivity() )
            {
                button5.BackColor = Color.Brown; // Rename..
                button5.Text = "Звільнити";
            }
            else
            {
                button5.BackColor = Color.FromArgb(84, 110, 122);
                button5.Text = "Поновити";
            }
        }

        private void AddNewEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using ( FormInsert f = new FormInsert(dataGridView1) )
            {
                f.ShowDialog();

                if (f.isChanged)
                    SetNewDataGridView1();
            }
        }

        private void SetNewDataGridView1()
        {
            d = new EmployeesDataGridView(dataGridView1);
            d.NewDataSource();
            d.SetNameColumns();
            d.SetColorIsActivity();

            /*
             *  Set Visible from config.
             */

            // Test
            dataGridView1.Columns[0].visible = false;
            datagridview1.columns[5].visible = false;
            datagridview1.columns[8].visible = false;
            datagridview1.columns[10].visible = false;
            datagridview1.columns[11].visible = false;
            datagridview1.columns[12].visible = false;
            datagridview1.columns[13].visible = false;
            datagridview1.Columns[14].Visible = false;
            // End Test
        }
    }
}
