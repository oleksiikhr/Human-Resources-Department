using System;
using System.Windows.Forms;

using Human_Resources_Department.classes;

namespace Human_Resources_Department
{
    public partial class FormMain : Form
    {
        const string TEXT_SEARCH = "Пошук по ПІБ";

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //
            Employees em = new Employees();
            em.Load("1");
        }

        private void FindField_TextChanged(object sender, EventArgs e)
        {
            // Search
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

        private void SaveFileToolStripMenuItem_click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            //
        }

        private void NewFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Сохранить|нет текущие данные в файл и очистить программу
        }

        private void LoadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Файлы sqlite|*.sqlite";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                if ( new Employees().Load(opf.FileName) )
                {
                    this.Text += " - " + opf.SafeFileName;

                    MessageBox.Show("Завантажено");
                }
            }
        }
    }
}
