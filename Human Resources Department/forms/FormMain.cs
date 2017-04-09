using System;
using System.Drawing;
using System.Windows.Forms;

using Human_Resources_Department.classes;
using Human_Resources_Department.classes.employees;
using Human_Resources_Department.classes.employees.db;

namespace Human_Resources_Department.forms
{
    public partial class FormMain : Form
    {
        private const string TEXT_SEARCH = "Швидкий пошук по Прізвищу";

        EmployeesDataGridView d;
        EmployeesPanel p;

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if ( ! SelectProject() )
                Application.ExitThread();

            Files.DeleteFile(Config.currentFolder + "\\" + Files.errorFile);

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
            this.Visible = false;

            using ( FormChoose f = new FormChoose() )
            {
                f.ShowDialog();

                if ( f.IsOpen() )
                {
                    this.Text = Config.PROJECT_NAME + " - " + f.GetNameFolder();

                    UpdatePlace();

                    this.Visible = true;
                    return true;
                }
            }

            this.Visible = true;
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
            if (d.GetCountSelectedRows() < 1 || d == null || p == null)
                return;

            FillDetailStaff();
            p.ToggleButton();
        }

        private void FillDetailStaff()
        {
            p.AddInfo(fieldFName,      d.GetSelectedRowValueCell(EmployeesDataGridView.CELL_FNAME));
            p.AddInfo(fieldMName,      d.GetSelectedRowValueCell(EmployeesDataGridView.CELL_MNAME));
            p.AddInfo(fieldLName,      d.GetSelectedRowValueCell(EmployeesDataGridView.CELL_LNAME));
            p.AddInfo(fieldJob,        d.GetSelectedRowValueCell(EmployeesDataGridView.CELL_JOB));
            p.AddInfo(fieldCity,       d.GetSelectedRowValueCell(EmployeesDataGridView.CELL_CITY));
            p.AddInfo(fieldEmail,      d.GetSelectedRowValueCell(EmployeesDataGridView.CELL_EMAIL));
            p.AddInfo(fieldTel,        d.GetSelectedRowValueCell(EmployeesDataGridView.CELL_TEL));
            p.AddInfo(fieldFamily,     d.GetSelectedRowValueCell(EmployeesDataGridView.CELL_FAMILY));
            p.AddInfo(fieldSalary,     d.GetSelectedRowValueCell(EmployeesDataGridView.CELL_SALARY));
            p.AddInfo(fieldIsFulltime, d.GetSelectedRowValueCell(EmployeesDataGridView.CELL_IS_FULLTIME));
            p.AddInfo(fieldBirthday,   d.GetSelectedRowValueCell(EmployeesDataGridView.CELL_BIRTHDAY));
            p.AddInfo(fieldSetCompany, d.GetSelectedRowValueCell(EmployeesDataGridView.CELL_SETCOMPANY));
            p.AddInfo(fieldUpdateAt,   d.GetSelectedRowValueCell(EmployeesDataGridView.CELL_UPDATE_AT));

            if ( d.EmployeeIsActivity() )
            {
                button5.BackColor = Color.Brown;
                button5.Text = "Звільнити";
            }
            else
            {
                button5.BackColor = Color.FromArgb(84, 110, 122);
                button5.Text = "Поновити";
            }

            if ( ! p.IsReadOnly() )
                p.ChangeAllTextBox("readonly", true);
        }

        private void AddNewEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p.ToggleButton();
            using ( FormInsert f = new FormInsert(dataGridView1) )
            {
                f.ShowDialog();

                if (f.isChanged)
                {
                    UpdatePlace();
                }
            }
        }

        private void UpdatePlace()
        {
            if (p != null)
                p.ToggleButton();

            p = new EmployeesPanel(panelEmployee);
            d = new EmployeesDataGridView(dataGridView1);

            int selectedRow = (d.GetCountSelectedRows() > 0) ? d.GetIndexSelectedRow() : 0;
            int countRows = d.GetCountRows();

            if ( ! d.SetDataSource() )
            {
                MessageBox.Show("Файл не знайдений або пошкоджений", "Помилка");

                if ( ! SelectProject() )
                    Application.ExitThread();

                return;
            }

            d.RenameColumns();
            d.SetColorRows();

            if (dataGridView1.Rows.Count > 0)
            {
                if (countRows == d.GetCountRows())
                    dataGridView1.Rows[selectedRow].Selected = true;
                else
                    dataGridView1.Rows[0].Selected = true;

                FillDetailStaff();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (d.GetCountSelectedRows() < 0)
            {
                MessageBox.Show("Оберіть працівника");
                return;
            }

            p.ChangeAllTextBox("readonly");
            
            p.ToggleButton(true);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            new EmployeesModel(Config.currentFolder + "\\" + EmployeesModel.nameFile)
                .UpdateActivity(
                    Convert.ToInt32( d.GetSelectedRowValueCell(EmployeesDataGridView.CELL_ID) ),
                    (Boolean.Parse(d.GetSelectedRowValueCell(EmployeesDataGridView.CELL_IS_ACTIVITY).ToString()) ? false : true)
                );

            UpdatePlace();
        }
    }
}
