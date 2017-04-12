using System;
using System.IO;
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
            using ( FormChoose f = new FormChoose() )
            {
                f.ShowDialog();

                if ( f.IsOpen() )
                {
                    this.Text = Config.PROJECT_NAME + " - " + f.GetNameFolder();
                    UpdatePlace();

                    return true;
                }
            }
            
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
            p.AddInfo(pictureBox1,     GetImageUrl());

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

        private Image GetImageUrl()
        {
            Image img = null;
            int index = dataGridView1.SelectedRows[0].Index;

            if ( File.Exists(Config.currentFolder + "\\img\\" + index + ".jpg") )
                img = Image.FromFile( Config.currentFolder + "\\img\\" + index + ".jpg" );
            else if ( File.Exists(Config.currentFolder + "\\img\\" + index + ".png") )
                img = Image.FromFile( Config.currentFolder + "\\img\\" + index + ".png" );

            return img;
        }

        private void UpdatePlace()
        {
            if (p != null)
                p.Enabled();

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
                p.ClearAllData();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (d.GetCountSelectedRows() <= 0)
            {
                MessageBox.Show("Оберіть працівника");
                return;
            }
            
            p.Enabled(true);
            fieldUpdateAt.Enabled = false;
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
            p.Enabled();

            FormInsert f = new FormInsert(dataGridView1);
            f.Show(this);
        }

        private void FormSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSearch f = new FormSearch(dataGridView1);
            f.Show(this);
        }

        private void FormFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFilter f = new FormFilter(dataGridView1, panelEmployee);
            f.Show(this);
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (d.GetCountSelectedRows() < 1 || d == null || p == null)
                return;

            FillPanelEmployee();
            p.Enabled();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            bool isCorrectSalary = Double.TryParse(fieldSalary.Text, out double salary);

            if (!isCorrectSalary)
            {
                MessageBox.Show("Зарплата вказана невірно", "Помилка");
                return;
            }
            
            p.UpdateData( new object[] {
                fieldFName.Text, fieldLName.Text, fieldMName.Text, fieldJob.Text,
                fieldCity.Text, fieldEmail.Text, fieldTel.Text, fieldFamily.Text,
                salary, fieldIsFulltime.Checked, fieldBirthday.Text, fieldSetCompany.Text,
                DateTime.Today, d.GetSelectedCell(EmployeesDGV.CELL_ID)
            } );

            UpdatePlace();
        }
    }
}
