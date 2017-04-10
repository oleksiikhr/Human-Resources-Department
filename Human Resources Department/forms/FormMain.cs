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

        EmployeesDGV d;
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

            d.FindCellAndSetFocus(findField.Text, EmployeesDGV.CELL_LNAME, true);
        }

        private void FillPanelEmployee()
        {
            p.AddInfo(fieldFName,      d.GetSelectedCell(EmployeesDGV.CELL_FNAME));
            p.AddInfo(fieldMName,      d.GetSelectedCell(EmployeesDGV.CELL_MNAME));
            p.AddInfo(fieldLName,      d.GetSelectedCell(EmployeesDGV.CELL_LNAME));
            p.AddInfo(fieldJob,        d.GetSelectedCell(EmployeesDGV.CELL_JOB));
            p.AddInfo(fieldCity,       d.GetSelectedCell(EmployeesDGV.CELL_CITY));
            p.AddInfo(fieldEmail,      d.GetSelectedCell(EmployeesDGV.CELL_EMAIL));
            p.AddInfo(fieldTel,        d.GetSelectedCell(EmployeesDGV.CELL_TEL));
            p.AddInfo(fieldFamily,     d.GetSelectedCell(EmployeesDGV.CELL_FAMILY));
            p.AddInfo(fieldSalary,     d.GetSelectedCell(EmployeesDGV.CELL_SALARY));
            p.AddInfo(fieldBirthday,   d.GetSelectedCell(EmployeesDGV.CELL_BIRTHDAY));
            p.AddInfo(fieldIsFulltime, d.GetSelectedCell(EmployeesDGV.CELL_IS_FULLTIME));
            p.AddInfo(fieldSetCompany, d.GetSelectedCell(EmployeesDGV.CELL_SETCOMPANY));
            p.AddInfo(fieldUpdateAt,   d.GetSelectedCell(EmployeesDGV.CELL_UPDATE_AT));

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
        }

        private void UpdatePlace()
        {
            panelEmployee.Enabled = false;

            p = new EmployeesPanel(panelEmployee);
            d = new EmployeesDGV(dataGridView1);

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
                if ( countRows == d.GetCountRows() )
                    dataGridView1.Rows[selectedRow].Selected = true;
                else
                    dataGridView1.Rows[0].Selected = true;

                FillPanelEmployee();
            }
            else
            {
                p.ClearAllData();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (d.GetCountSelectedRows() < 0)
            {
                MessageBox.Show("Оберіть працівника");
                return;
            }
            
            fieldUpdateAt.Enabled = false;
            panelEmployee.Enabled = true;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if ( d.EmployeeIsActivity() )
            {
                DialogResult result = MessageBox.Show(
                    "Ви дійсно хочете звільнити " + fieldFName.Text + " " + fieldLName.Text + "?",
                    "Видалення працівника",
                    MessageBoxButtons.YesNo
                );

                if (result == DialogResult.No)
                    return;
            }

            new EmployeesModel(Config.currentFolder + "\\" + EmployeesModel.nameFile)
                .UpdateActivity(
                    Convert.ToInt32( d.GetSelectedCell(EmployeesDGV.CELL_ID) ),
                    (Boolean.Parse(d.GetSelectedCell(EmployeesDGV.CELL_IS_ACTIVITY).ToString())
                    ? false : true)
                );

             UpdatePlace();
        }
        
        private void FormChooseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectProject();
        }

        private void FormInsertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelEmployee.Enabled = false;

            FormInsert f = new FormInsert(dataGridView1);
            f.Show(this);
        }

        private void FormSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSearch f = new FormSearch(dataGridView1);
            f.Show(this);
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (d.GetCountSelectedRows() < 1 || d == null || p == null)
                return;

            FillPanelEmployee();
            panelEmployee.Enabled = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            new EmployeesModel(Config.currentFolder + "\\" + EmployeesModel.nameFile)
                .UpdateFromPanelTextBox(new object[] { fieldFName.Text, fieldMName.Text,
                    fieldLName.Text, fieldJob.Text, fieldCity.Text, fieldEmail.Text,
                    fieldTel.Text, fieldFamily.Text, fieldSalary.Text, fieldIsFulltime.Text,
                    fieldBirthday.Text, fieldSetCompany.Text, DateTime.Today,
                    d.GetSelectedCell(EmployeesDGV.CELL_ID)});

            UpdatePlace();
        }
    }
}
