using System;
using System.Windows.Forms;

using Human_Resources_Department.classes;

using System.Data; // Test

namespace Human_Resources_Department
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
            SelectProject();

            // Test
            DataTable dtSales = new DataTable();
            dtSales.Columns.Add("id");
            dtSales.Columns.Add("Ім'я");
            dtSales.Columns.Add("По-батькові");
            dtSales.Columns.Add("Прізвище");
            dtSales.Columns.Add("Посада");
            dtSales.Columns.Add("Місто");
            dtSales.Columns.Add("Email");
            dtSales.Columns.Add("Телефон");
            dtSales.Columns.Add("Сімейний стан");
            dtSales.Columns.Add("Зарплата");
            dtSales.Columns.Add("Зайнятість");
            dtSales.Columns.Add("День народження");
            dtSales.Columns.Add("Працює");
            dtSales.Columns.Add("Прийнятий/звільнений");
            dtSales.Columns.Add("Останнє оновлення");

            dtSales.Rows.Add(new object[] { 0, "Alexey", "ASD", "FAS", "Developer",
                "City123", "asd@asd.asd", "+38012351", "Неодружений", 1000, "Повний",
                "11.11.11", "Так", "27.03.2017", "27.03.2017"});
            dtSales.Rows.Add(new object[] { 1, "Belgium", "greh" });
            dtSales.Rows.Add(new object[] { 2, "User123", null, "asd" });
            dataGridView1.DataSource = dtSales;

            dataGridView1.Columns[12].Visible = false;

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

        private void SelectProject()
        {
            using ( FormChoose f = new FormChoose() )
            {
                f.ShowDialog();

                if ( f.IsOpen() )
                {
                    path = f.GetURI();
                    nameFolder = Config.PROJECT_NAME + " - " + f.GetNameFolder();
                    this.Text = nameFolder;

                    // Clear current project, add new
                    // Fill DataGridView
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            // Search - find
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }

            label15.Text = "Співробітник: №" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox12.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox13.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
        }
    }
}
