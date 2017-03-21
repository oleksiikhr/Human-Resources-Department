using System;
using System.IO;
using System.Windows.Forms;

namespace Human_Resources_Department
{
    public partial class FormChoose : Form
    {
        string my_doc = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        const string FOLDER = "HRD";

        public FormChoose()
        {
            InitializeComponent();
        }

        private void InitialForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(this.my_doc + "\\" + FOLDER) == false)
                {
                    Directory.CreateDirectory(this.my_doc + "\\" + FOLDER);
                }

                GetFolders();
            }
            catch
            {
                MessageBox.Show("Неможливо створити папку для фірм", "Помилка");
                this.Close();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if ( String.IsNullOrWhiteSpace(textBox1.Text) )
            {
                MessageBox.Show("Введіть ім'я нової фірми", "Помилка");
                return;
            }

            CreateNewProject();
        }

        private void CreateNewProject()
        {
            DialogResult result = MessageBox.Show(
                "Створити нову фірму з назвою: " + textBox1.Text + "?",
                "Папка: " + textBox1.Text,
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {
                CloseForm();
                //
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            GetFolders();
            label3.Visible = true;
            timer1.Enabled = true;
        }

        private void GetFolders()
        {
            listBox1.Items.Clear();
            
            DirectoryInfo dir = new DirectoryInfo(this.my_doc + "\\" + FOLDER);

            foreach (var item in dir.GetDirectories())
            {
                listBox1.Items.Add(item.Name);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label3.Visible = false;
            timer1.Enabled = false;
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
            button4.Enabled = true;
            this.Text = "HRD - " + listBox1.SelectedItem;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(this.my_doc + "\\" + FOLDER + "\\" + listBox1.SelectedItem);
            dir.Delete(true);
            GetFolders();
        }

        private void CloseForm()
        {
            FormMain f = new FormMain();
        }
    }
}
