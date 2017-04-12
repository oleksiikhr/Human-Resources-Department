using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

using Human_Resources_Department.classes;
using Human_Resources_Department.classes.employees;

namespace Human_Resources_Department.forms
{
    public partial class FormMain : Form
    {
        private const string TEXT_SEARCH = "Швидкий пошук по Прізвищу";

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // If the project is not selected - finish the application.
            if ( ! SelectProject() )
                Application.ExitThread();

            WindowState = FormWindowState.Maximized;
            AcceptButton = button4;
        }

        /// <summary>
        /// Event when the selected employee is changed.
        /// </summary>
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (EmployeesDGV.GetCountSelectedRows() < 1 || EmployeesDGV.IsNull() || EmployeesPanel.IsNull())
                return;

            FillPanelEmployee();
            EmployeesPanel.Enabled();
        }

        /// <summary>
        /// Quick search bar. Focus set.
        /// </summary>
        private void FindField_Enter(object sender, EventArgs e)
        {
            if ( findField.Text.Equals(TEXT_SEARCH) )
                findField.Text = string.Empty;
        }

        /// <summary>
        /// Quick search bar. Focus lost.
        /// </summary>
        private void FindField_Leave(object sender, EventArgs e)
        {
            if ( string.IsNullOrWhiteSpace(findField.Text) )
                findField.Text = TEXT_SEARCH;
        }

        /// <summary>
        /// Edit mode for panelEmployee.
        /// </summary>
        private void Button1_Click(object sender, EventArgs e)
        {
            // If an employee is not selected => return.
            if ( EmployeesDGV.GetCountSelectedRows() <= 0 )
            {
                MessageBox.Show("Оберіть працівника");
                return;
            }

            EmployeesPanel.Enabled(true);
            fieldUpdateAt.Enabled = false;
        }

        /// <summary>
        /// Save changes and update the DB in the Panel.
        /// </summary>
        private void Button2_Click(object sender, EventArgs e)
        {
            bool isCorrectSalary = Double.TryParse(fieldSalary.Text, out double salary);

            if ( ! isCorrectSalary )
            {
                MessageBox.Show("Зарплата вказана невірно", "Помилка");
                return;
            }

            // Updating the database with new data from the Panel.
            EmployeesPanel.UpdateData( new object[] {
                fieldFName.Text, fieldLName.Text, fieldMName.Text, fieldJob.Text,
                fieldCity.Text, fieldEmail.Text, fieldTel.Text, fieldFamily.Text,
                salary, fieldIsFulltime.Checked, fieldBirthday.Text, fieldSetCompany.Text,
                DateTime.Today, EmployeesDGV.GetSelectedCell(EmployeesDGV.CELL_ID)
            });

            UpdatePlace();
        }

        /// <summary>
        /// Undo actions and close edit mode.
        /// </summary>
        private void Button3_Click(object sender, EventArgs e)
        {
            EmployeesPanel.Enabled();
        }

        /// <summary>
        /// Quick search button.
        /// </summary>
        private void Button4_Click(object sender, EventArgs e)
        {
            // If empty or the string is constant TEXT_SEARCH => return.
            if ( string.IsNullOrEmpty(findField.Text) || findField.Text.Equals(TEXT_SEARCH) )
                return;

            EmployeesDGV.FindCellAndSetFocus(findField.Text, EmployeesDGV.CELL_LNAME, true);
        }

        /// <summary>
        /// Dismiss employee and update DB.
        /// </summary>
        private void Button5_Click(object sender, EventArgs e)
        {
            // If the employee is working, we confirm the action.
            if ( EmployeesDGV.EmployeeIsActivity() )
            {
                DialogResult result = MessageBox.Show(
                    "Ви дійсно хочете звільнити " + fieldFName.Text + " " + fieldLName.Text + "?",
                    "Видалення працівника",
                    MessageBoxButtons.YesNo
                );

                if (result == DialogResult.No)
                    return;
            }

            // Update the DB.
            EmployeesPanel.UpdateActivity(
                (EmployeesDGV.EmployeeIsActivity() ? false : true),
                Convert.ToInt32(EmployeesDGV.GetSelectedCell(EmployeesDGV.CELL_ID))
            );

            UpdatePlace();
        }
        
        private void FormChooseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Ви точно хочете залишити поточний проект?",
                Text,
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.No)
                return;

            // Close and clear all data.
            EmployeesDGV.ClearSelected();
            EmployeesPanel.ClearAllData();

            EmployeesDGV.Close();
            EmployeesPanel.Close();

            Hide();
            SelectProject();
            Show();
        }

        private void FormInsertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeesPanel.Enabled();

            FormInsert f = new FormInsert();
            f.Show(this);
        }

        private void FormSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSearch f = new FormSearch();
            f.Show(this);
        }

        private void FormFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFilter f = new FormFilter();
            f.Show(this);
        }

        /// <summary>
        /// Project selection.
        /// </summary>
        private bool SelectProject()
        {
            using ( FormChoose f = new FormChoose() )
            {
                f.ShowDialog();

                if ( f.IsOpen() )
                {
                    EmployeesDGV.SetDataGridView(dataGridView1);
                    EmployeesPanel.SetPanel(panelEmployee);

                    Text = Config.PROJECT_NAME + " - " + f.GetNameFolder();
                    UpdatePlace();

                    return true;
                }
            }
            
            return false;
        }

        /// <summary>
        /// Fill the panel with data from dataGridView.
        /// </summary>
        private void FillPanelEmployee()
        {
            EmployeesPanel.AddInfo(fieldFName,       EmployeesDGV.GetSelectedCell(EmployeesDGV.CELL_FNAME));
            EmployeesPanel.AddInfo(fieldLName,       EmployeesDGV.GetSelectedCell(EmployeesDGV.CELL_LNAME));
            EmployeesPanel.AddInfo(fieldMName,       EmployeesDGV.GetSelectedCell(EmployeesDGV.CELL_MNAME));
            EmployeesPanel.AddInfo(fieldJob,         EmployeesDGV.GetSelectedCell(EmployeesDGV.CELL_JOB));
            EmployeesPanel.AddInfo(fieldCity,        EmployeesDGV.GetSelectedCell(EmployeesDGV.CELL_CITY));
            EmployeesPanel.AddInfo(fieldEmail,       EmployeesDGV.GetSelectedCell(EmployeesDGV.CELL_EMAIL));
            EmployeesPanel.AddInfo(fieldTel,         EmployeesDGV.GetSelectedCell(EmployeesDGV.CELL_TEL));
            EmployeesPanel.AddInfo(fieldFamily,      EmployeesDGV.GetSelectedCell(EmployeesDGV.CELL_FAMILY));
            EmployeesPanel.AddInfo(fieldSalary,      EmployeesDGV.GetSelectedCell(EmployeesDGV.CELL_SALARY));
            EmployeesPanel.AddInfo(fieldBirthday,    EmployeesDGV.GetSelectedCell(EmployeesDGV.CELL_BIRTHDAY));
            EmployeesPanel.AddInfo(fieldIsFulltime,  EmployeesDGV.GetSelectedCell(EmployeesDGV.CELL_IS_FULLTIME));
            EmployeesPanel.AddInfo(fieldSetCompany,  EmployeesDGV.GetSelectedCell(EmployeesDGV.CELL_SETCOMPANY));
            EmployeesPanel.AddInfo(fieldUpdateAt,    EmployeesDGV.GetSelectedCell(EmployeesDGV.CELL_UPDATE_AT));
            EmployeesPanel.AddInfo(pictureBox1,      GetImageUrl());

            if ( EmployeesDGV.EmployeeIsActivity() )
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

        /// <summary>
        /// Get the picture of the active employee from the folder in the format (JPG|PNG).
        /// </summary>
        private Image GetImageUrl()
        {
            Image img = null;
            int index = EmployeesDGV.GetSelectedIndex() + 1;

            if ( File.Exists(Config.currentFolder + "\\img\\" + index + ".jpg") )
                img = Image.FromFile( Config.currentFolder + "\\img\\" + index + ".jpg" );
            else if ( File.Exists(Config.currentFolder + "\\img\\" + index + ".png") )
                img = Image.FromFile( Config.currentFolder + "\\img\\" + index + ".png" );

            return img;
        }

        /// <summary>
        /// Updating / setting up a new environment.
        /// </summary>
        private void UpdatePlace()
        {
            if ( ! EmployeesPanel.IsNull() )
                EmployeesPanel.Enabled();

            int selectedRow = (EmployeesDGV.GetCountSelectedRows() > 0) ? EmployeesDGV.GetIndexSelectedRow() : 0;
            int countRows = EmployeesDGV.GetCountRows();

            EmployeesDGV.UpdateDataSource();

            // If the file is damaged / no access => return | exit.
            if ( ! EmployeesDGV.UpdateDataSource() )
            {
                MessageBox.Show("Файл не знайдений або пошкоджений", "Помилка");

                if ( ! SelectProject() )
                    Application.ExitThread();

                return;
            }

            // Rename the columns and set the colors.
            EmployeesDGV.RenameColumns();
            EmployeesDGV.SetColorRows();

            // Clean / update the panel.
            if (EmployeesDGV.GetCountRows() > 0)
            {
                if ( countRows == EmployeesDGV.GetCountRows() )
                    EmployeesDGV.SetSelected(selectedRow, true);
                else
                    EmployeesDGV.SetSelected(0, true);

                FillPanelEmployee();
            }
            else
                EmployeesPanel.ClearAllData();
        }
    }
}
