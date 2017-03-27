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
            // SelectProject();

            // Test
            DataTable dtSales = new DataTable();
            dtSales.Columns.Add("Ім'я");
            dtSales.Columns.Add("По-батькові");
            dtSales.Columns.Add("Прізвище");
            dtSales.Columns.Add("Посада");
            dtSales.Columns.Add("Місто");
            dtSales.Columns.Add("Email");
            dtSales.Columns.Add("Телефон");
            dtSales.Columns.Add("Сімейний стан");
            dtSales.Columns.Add("Зарплата");
            dtSales.Columns.Add("Робочий день");
            dtSales.Columns.Add("День народження");
            dtSales.Columns.Add("Працює");
            dtSales.Columns.Add("Прийнятий/звільнений");
            
            dtSales.Rows.Add(new object[] { "Alexey", "ASD", "FAS", "Developer",
                "City123", "asd@asd.asd", "+38012351", "Неодружений", 1000, "Повний", "11.11.11", "Так", "27.03.2017"});
            dtSales.Rows.Add(new object[] { "Belgium", "greh" });
            dtSales.Rows.Add(new object[] { "User123", null, "asd" });
            dataGridView1.DataSource = dtSales;

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

                if (f.IsOpen())
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
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            // ...
        }
    }
}
