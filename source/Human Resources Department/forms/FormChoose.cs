using System;
using System.IO;
using System.Windows.Forms;

using Human_Resources_Department.classes;
using Human_Resources_Department.classes.db;
using Human_Resources_Department.classes.db.tables;

namespace Human_Resources_Department
{
    public partial class FormChoose : Form
    {
        private bool is_open;

        Config cfg = new Config();
        Files fls = new Files();

        public FormChoose()
        {
            InitializeComponent();

            // For new Data. Simple
            //new Database(cfg.projectFolder + "\\users.sqlite").Insert<EmployeesTable>(new EmployeesTable
            //{
            //    FName = "Alexey"
            //});

            this.Text = Config.PROJECT_NAME + " - Вибір фірми";
        }

        private void InitialForm_Load(object sender, EventArgs e)
        {
            try
            {
                Directory.CreateDirectory(cfg.projectFolder);
                GetFolders();
            }
            catch (Exception ex)
            {
                fls.WriteToFile(ex.ToString(), fls.errorFile);
                MessageBox.Show("Неможливо створити папку для збережень", "Помилка");
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
                "Фірма: " + textBox1.Text,
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {
                string folder = cfg.projectFolder + "\\" + textBox1.Text;

                if ( Directory.Exists(folder) )
                {
                    MessageBox.Show("Фірма вже існує");
                    return;
                }

                try
                {
                    Directory.CreateDirectory(folder);
                    Directory.CreateDirectory(folder + "\\img");

                    new Database(folder + "\\employees.sqlite").CreateTable<EmployeesTable>();

                    cfg.CurrentFolder = folder;
                }
                catch (Exception ex)
                {
                    fls.WriteToFile(ex.ToString(), fls.errorFile);
                    MessageBox.Show("Не вдалося створити нову фірму", "Помилка");
                    return;
                }

                listBox1.Items.Add(textBox1.Text);
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
            
            DirectoryInfo dir = new DirectoryInfo(cfg.projectFolder);

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
                this.Text = Config.PROJECT_NAME + " - " + listBox1.SelectedItem;
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
                DirectoryInfo dir = new DirectoryInfo(cfg.projectFolder + "\\" + listBox1.SelectedItem);
                dir.Delete(true);
                listBox1.Items.Remove(listBox1.Text);

                button3.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.is_open = true;
            this.Close();
        }

        public string GetURI()
        {
            return cfg.projectFolder + "\\" + listBox1.SelectedItem;
        }

        public string GetNameFolder()
        {
            return (listBox1.SelectedIndex > -1) ? listBox1.SelectedItem.ToString() : "";
        }

        public bool IsOpen()
        {
            return this.is_open;
        }
    }
}
