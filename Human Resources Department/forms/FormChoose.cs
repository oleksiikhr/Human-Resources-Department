using System;
using System.IO;
using System.Windows.Forms;

using Human_Resources_Department.classes;
using Human_Resources_Department.classes.db;

namespace Human_Resources_Department.forms
{
    public partial class FormChoose : Form
    {
        private bool is_open;
        private static bool initialOpen = true;

        public FormChoose()
        {
            InitializeComponent();

            Text = Config.PROJECT_NAME + " - Вибір філіала";
        }

        private void InitialForm_Load(object sender, EventArgs e)
        {
            try
            {
                Directory.CreateDirectory(Config.projectFolder);
                GetFolders();
            }
            catch
            {
                MessageBox.Show("Неможливо створити папку для збережень", "Помилка");
                Close();
            }

            if (!initialOpen || listBox1.Items.Count != 1)
                return;

            listBox1.SelectedItem = listBox1.Items[0];
            initialOpen = false;

            Config.currentFolder = Config.projectFolder + "\\" + listBox1.SelectedItem;
            is_open = true;
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if ( String.IsNullOrWhiteSpace(textBox1.Text) )
            {
                MessageBox.Show("Введіть ім'я нового філіала", "Помилка");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Створити нову фірму з назвою: " + textBox1.Text + "?",
                "Фірма: " + textBox1.Text,
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {
                string folder = Config.projectFolder + "\\" + textBox1.Text;

                if ( Directory.Exists(folder) )
                {
                    MessageBox.Show("Фірма вже існує");
                    return;
                }

                try
                {
                    Directory.CreateDirectory(folder);
                    Directory.CreateDirectory(folder + "\\img");
                    Database.CreateDatabases(folder + "\\" + Database.FILE_NAME);
                }
                catch
                {
                    MessageBox.Show("Не вдалося створити нову фірму", "Помилка");
                    return;
                }

                listBox1.Items.Add(textBox1.Text);
                listBox1.SelectedItem = textBox1.Text;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            GetFolders();
            label3.Visible = true;
            timer1.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void GetFolders()
        {
            listBox1.Items.Clear();
            
            DirectoryInfo dir = new DirectoryInfo(Config.projectFolder);

            foreach ( var item in dir.GetDirectories() )
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
            if (listBox1.SelectedIndex > -1)
            {
                button3.Enabled = true;
                button4.Enabled = true;

                Text = Config.PROJECT_NAME + " - " + listBox1.SelectedItem;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Видалити фірму з назвою: " + listBox1.Text + "?",
                "Фірма: " + listBox1.Text,
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    new DirectoryInfo(Config.projectFolder + "\\" + listBox1.SelectedItem).Delete(true);
                }
                catch
                {
                    MessageBox.Show("Не можливо видалити філіал, так як він відкритий", "Помилка");
                    return;
                }

                listBox1.Items.Remove(listBox1.Text);

                button3.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Config.currentFolder = Config.projectFolder + "\\" + listBox1.SelectedItem;
            is_open = true;
            initialOpen = false;
            Close();
        }

        public string GetURI()
        {
            return Config.projectFolder + "\\" + listBox1.SelectedItem;
        }

        public string GetNameFolder()
        {
            return (listBox1.SelectedIndex > -1) ? listBox1.SelectedItem.ToString() : "";
        }

        public bool IsOpen()
        {
            return is_open;
        }
    }
}
