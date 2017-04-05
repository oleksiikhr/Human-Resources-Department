using System;
using System.Windows.Forms;

using Human_Resources_Department.classes;
using Human_Resources_Department.classes.db;
using Human_Resources_Department.classes.db.tables;

namespace Human_Resources_Department.forms
{
    public partial class FormMain : Form
    {
        private string path;
        private string nameFolder;

        private const string TEXT_SEARCH = "Швидкий пошук по Прізвищу";

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if ( ! SelectProject() )
            {
                Close();
            }
        }
        
        private void FindField_Enter(object sender, EventArgs e)
        {
            if ( findField.Text.Equals(TEXT_SEARCH) )
            {
                findField.Text = "";
            }
        }
        
        private void FindField_Leave(object sender, EventArgs e)
        {
            if ( string.IsNullOrWhiteSpace(findField.Text) )
            {
                findField.Text = TEXT_SEARCH;
            }
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
                    ClearAllTextBox();

                    path = f.GetURI();
                    nameFolder = Config.PROJECT_NAME + " - " + f.GetNameFolder();
                    this.Text = nameFolder;
                    
                    dataGridView1.DataSource = new Database(path + "\\" + EmployeesTable.nameFile)
                        .QueryEmployees("SELECT * FROM EmployeesTable");
                    SetNameColumnsEmployeesTable();

                    dataGridView1.Columns[10].Visible = false;

                    return true;
                }

                return false;
            }
        }

        private void SetNameColumnsEmployeesTable()
        {
            dataGridView1.Columns[0].HeaderText  = "#";
            dataGridView1.Columns[1].HeaderText  = "Ім'я";
            dataGridView1.Columns[2].HeaderText  = "Прізвище";
            dataGridView1.Columns[3].HeaderText  = "По-батькові";
            dataGridView1.Columns[4].HeaderText  = "Посада";
            dataGridView1.Columns[5].HeaderText  = "Місто";
            dataGridView1.Columns[6].HeaderText  = "Email";
            dataGridView1.Columns[7].HeaderText  = "Телефон";
            dataGridView1.Columns[8].HeaderText  = "Сімейний стан";
            dataGridView1.Columns[9].HeaderText  = "Зарплата";
            dataGridView1.Columns[10].HeaderText = "Активний";
            dataGridView1.Columns[11].HeaderText = "Повна зайнятість";
            dataGridView1.Columns[12].HeaderText = "День народження";
            dataGridView1.Columns[13].HeaderText = "Назначений";
            dataGridView1.Columns[14].HeaderText = "Оновлення";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            // Search - btn find
        }

        private void DataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }
            
            AddInfoOnDetailStaff(textBox1,  1);
            AddInfoOnDetailStaff(textBox2,  2);
            AddInfoOnDetailStaff(textBox10, 3);
            AddInfoOnDetailStaff(textBox6,  4);
            AddInfoOnDetailStaff(textBox12, 5);
            AddInfoOnDetailStaff(textBox5,  6);
            AddInfoOnDetailStaff(textBox8,  7);
            AddInfoOnDetailStaff(textBox11, 8);
            AddInfoOnDetailStaff(textBox3,  9);
            AddInfoOnDetailStaff(textBox13, 10);
            AddInfoOnDetailStaff(textBox4,  12);
            AddInfoOnDetailStaff(textBox7,  13);
            AddInfoOnDetailStaff(textBox9,  14);
        }

        private void AddInfoOnDetailStaff(TextBox t, int cell)
        {
            var value = dataGridView1.CurrentRow.Cells[cell].Value;

            if (value == null)
            {
                return;
            }

            if ( DateTime.TryParse(value.ToString(), out DateTime d) )
            {
                t.Text = d.ToString("dd.MM.yyyy");
            }
            else
            {
                t.Text = value.ToString();
            }
        }

        private void AddNewEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormInsert().Show();
        }

        private void ClearAllTextBox()
        {
            foreach (Control c in Controls)
            {
                if ( c.GetType() == typeof(Panel) )
                {
                    foreach (Control d in c.Controls)
                    {
                        if ( d.GetType() == typeof(TextBox) )
                        {
                            d.Text = string.Empty;
                        }
                    }
                }

                if ( c.GetType() == typeof(TextBox) )
                {
                    c.Text = string.Empty;
                }
            }
        }
    }
}
