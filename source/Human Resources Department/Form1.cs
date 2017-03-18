using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Human_Resources_Department
{
    public partial class Form1 : Form
    {
        const string TEXT_SEARCH = "Пошук по ПІБ";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textData();
        }

        private void findField_TextChanged(object sender, EventArgs e)
        {
            // Работать с данными Employee
            if ( ! String.IsNullOrEmpty(findField.Text) && findField.Text != TEXT_SEARCH )
            {
                for (int i = listStaff.Items.Count - 1; i >= 0; i--)
                {
                    var item = listStaff.Items[i].SubItems[1];

                    if ( item.Text.ToLower().Contains( findField.Text.ToLower() ) )
                    {
                        listStaff.Items[i].ForeColor = SystemColors.Highlight;
                    }
                    else
                    {
                        listStaff.Items.RemoveAt(i);
                    }
                }

                if (listStaff.Items.Count == 1)
                {
                    // listStaff.Focus();
                }
            }
            else
            {
                // Вернуть данные
            }
        }

        private void textData()
        {
            listStaff.Items.Add(new ListViewItem(new string[] { "", "Petr", "15" }));
            listStaff.Items.Add(new ListViewItem(new string[] { "-", "Sergey", "24" }));
            listStaff.Items.Add(new ListViewItem(new string[] { "-", "Alexandr", "12" }));
            listStaff.Items.Add(new ListViewItem(new string[] { "-", "Fedr", "65" }));
            listStaff.Items.Add(new ListViewItem(new string[] { "-", "Ket", "32" }));
            listStaff.Items.Add(new ListViewItem(new string[] { "-", "Petrenko", "25" }));
        }
        
        private void findField_Enter(object sender, EventArgs e)
        {
            if ( findField.Text.Equals(TEXT_SEARCH) )
            {
                findField.Text = "";
            }
        }
        
        private void findField_Leave(object sender, EventArgs e)
        {
            if ( string.IsNullOrWhiteSpace(findField.Text) )
            {
                findField.Text = TEXT_SEARCH;
            }
        }

        private void saveFileToolStripMenuItem_click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Файлы sqlite|*.sqlite";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("ok");
                //
            }
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Сохранить текущие данные в файл и удалить с программы
        }

        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Файлы sqlite|*.sqlite";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                if ( new DB().load(opf.FileName) )
                {
                    MessageBox.Show("Завантажено");
                }
            }
        }
    }
}
