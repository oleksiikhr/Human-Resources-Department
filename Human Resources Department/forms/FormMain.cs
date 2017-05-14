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
        /// Event when the selected employee is changed.
        /// </summary>
        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If the focus is lost, delete the panel.
            if ( ! EmployeesLV.IsSelected() )
            {
                EmployeesPanel.ClearAllData();
                return;
            }

            FillPanelEmployee();
        }

        /// <summary>
        /// Edit mode for panelEmployee.
        /// </summary>
        private void Button1_Click(object sender, EventArgs e)
        {
            // If an employee is not selected => return.
            if ( ! EmployeesLV.IsSelected() )
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
            double salary = 0;

            if ( ! string.IsNullOrEmpty(fieldSalary.Text) )
            {
                bool isCorrectSalary = Double.TryParse(fieldSalary.Text, out salary);

                if (!isCorrectSalary)
                {
                    MessageBox.Show("Зарплата вказана невірно", "Помилка");
                    return;
                }
            }

            // Updating the database with new data from the Panel.
            int isUpdated = EmployeesPanel.UpdateData( new object[] {
                fieldFName.Text, fieldLName.Text, fieldMName.Text, fieldJob.Text,
                fieldCity.Text, fieldEmail.Text, fieldTel.Text, fieldFamily.Text,
                salary, fieldIsFulltime.Checked, fieldBirthday.Text, fieldSetCompany.Text,
                DateTime.Today, EmployeesLV.GetSelectedCell(EmployeesLV.I_ID)
            });

            if (isUpdated == 1)
            {
                EmployeesLV.UpdateSelectedData();
                EmployeesPanel.Enabled();
            }
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

            EmployeesLV.FindCellAndSetFocus(findField.Text, EmployeesLV.I_LNAME, true);
        }

        /// <summary>
        /// Dismiss employee and update DB.
        /// </summary>
        private void Button5_Click(object sender, EventArgs e)
        {
            // If the employee is working, we confirm the action.
            if ( EmployeesLV.EmployeeIsActivity() )
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
            int isUpdated = EmployeesPanel.UpdateActivity(
                !EmployeesLV.EmployeeIsActivity(),
                Convert.ToInt32(EmployeesLV.GetSelectedCell(EmployeesLV.I_ID))
            );

            if (isUpdated == 1)
            {
                EmployeesLV.UpdateSelectedData();
                FillPanelEmployee();
            }
        }
        
        private void FormChooseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете залишити поточний проект?",
                Text,
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.No)
                return;

            Hide();

            // Close and clear all data.
            EmployeesLV.ClearAllData();
            EmployeesPanel.ClearAllData();

            EmployeesLV.Close();
            EmployeesPanel.Close();

            if ( ! SelectProject() )
                Application.ExitThread();

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

        private void SalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using ( FormSalary f = new FormSalary() )
            {
                f.ShowDialog();
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using ( BoxAbout b = new BoxAbout() )
            {
                b.ShowDialog();
            }
        }

        /// <summary>
        /// Project selection. Setting up a new environment.
        /// </summary>
        private bool SelectProject()
        {
            using ( FormChoose f = new FormChoose() )
            {
                f.ShowDialog();

                if ( f.IsOpen() )
                {
                    try
                    {
                        EmployeesLV.SetListBox(listView1);
                        EmployeesLV.SetNameColumns();
                        EmployeesLV.GetAllData();

                        EmployeesPanel.SetPanel(panelEmployee);
                        EmployeesPanel.Enabled();

                        Text = Config.PROJECT_NAME + " - " + f.GetNameFolder();
                        listBox1.Items.Clear();
                    }
                    catch
                    {
                        MessageBox.Show("Файл пошкоджений");
                        return false;
                    }

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
            EmployeesPanel.Enabled();

            EmployeesPanel.AddInfo(fieldFName,       EmployeesLV.GetSelectedCell(EmployeesLV.I_FNAME));
            EmployeesPanel.AddInfo(fieldLName,       EmployeesLV.GetSelectedCell(EmployeesLV.I_LNAME));
            EmployeesPanel.AddInfo(fieldMName,       EmployeesLV.GetSelectedCell(EmployeesLV.I_MNAME));
            EmployeesPanel.AddInfo(fieldJob,         EmployeesLV.GetSelectedCell(EmployeesLV.I_JOB));
            EmployeesPanel.AddInfo(fieldCity,        EmployeesLV.GetSelectedCell(EmployeesLV.I_CITY));
            EmployeesPanel.AddInfo(fieldEmail,       EmployeesLV.GetSelectedCell(EmployeesLV.I_EMAIL));
            EmployeesPanel.AddInfo(fieldTel,         EmployeesLV.GetSelectedCell(EmployeesLV.I_TEL));
            EmployeesPanel.AddInfo(fieldFamily,      EmployeesLV.GetSelectedCell(EmployeesLV.I_FAMILY));
            EmployeesPanel.AddInfo(fieldSalary,      EmployeesLV.GetSelectedCell(EmployeesLV.I_SALARY));
            EmployeesPanel.AddInfo(fieldIsFulltime,  EmployeesLV.GetSelectedCell(EmployeesLV.I_IS_FULLTIME).Equals("Так"));
            EmployeesPanel.AddInfo(fieldBirthday,    EmployeesLV.GetSelectedCell(EmployeesLV.I_BIRTHDAY));
            EmployeesPanel.AddInfo(fieldSetCompany,  EmployeesLV.GetSelectedCell(EmployeesLV.I_SETCOMPANY));
            EmployeesPanel.AddInfo(fieldUpdateAt,    EmployeesLV.GetSelectedCell(EmployeesLV.I_UPDATE_AT));
            EmployeesPanel.AddInfo(pictureBox1,      Employees.GetImageUrl(EmployeesLV.GetSelectedIndex() + 1));

            if ( EmployeesLV.EmployeeIsActivity() )
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
        /// Reset filters.
        /// </summary>
        private void Button6_Click(object sender, EventArgs e)
        {
            EmployeesPanel.ClearAllData();
            EmployeesLV.ClearAllData();
            EmployeesLV.SetNameColumns();
            EmployeesLV.GetAllData();
        }

        /// <summary>
        /// Update stats.
        /// </summary>
        private void Button7_Click(object sender, EventArgs e)
        {
            if (EmployeesLV.GetCountItems() <= 0)
                return;

            listBox1.Items.Clear();

            var data = EmployeesLV.GetBasicInfo();

            listBox1.Items.Add("Працівників: "            + EmployeesLV.GetCountItems());
            listBox1.Items.Add("Звільнених: "             + data[0]);
            listBox1.Items.Add("Зарплата: "               + data[1]);
            listBox1.Items.Add("Редагувань сьоогдні: "    + data[2]);
            listBox1.Items.Add("На повний робочий день: " + data[3]);
            // Other..
        }
    }
}
