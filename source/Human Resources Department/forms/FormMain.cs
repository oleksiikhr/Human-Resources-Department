using System;
using System.Windows.Forms;

using Human_Resources_Department.classes;

namespace Human_Resources_Department
{
    public partial class FormMain : Form
    {
        private string path;
        private string nameFolder;

        private const string TEXT_SEARCH = "Пошук по ПІБ";

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SelectProject();
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

                    // Fill DataGridView
                }
            }
        }
    }
}
