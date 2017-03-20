using System;
using System.IO;
using System.Windows.Forms;

namespace Human_Resources_Department
{
    public partial class InitialForm : Form
    {
        public InitialForm()
        {
            InitializeComponent();
        }

        private void InitialForm_Load(object sender, EventArgs e)
        {
            DirectoryInfo dir;

            try
            {
                Directory.CreateDirectory("saves");

                dir = new DirectoryInfo( Directory.GetCurrentDirectory() + "\\saves" );

                foreach (var item in dir.GetDirectories())
                {
                    listBox1.Items.Add(item.Name);
                }
            }
            catch
            {
                MessageBox.Show("Помилка доступу до папки");
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateNewProject();
        }

        private void CreateNewProject()
        {
            DialogResult result = MessageBox.Show(
                "Створити новий файл с іменем: " + textBox1.Text + "?",
                "Файл: " + textBox1.Text,
                MessageBoxButtons.YesNo
            );

            if (DialogResult.Yes == result)
            {
                //
            }
            else
            {
                //
            }
        }
    }
}
