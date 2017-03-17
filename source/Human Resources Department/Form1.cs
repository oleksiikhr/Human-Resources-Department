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
        Staff staff;

        public Form1()
        {
            InitializeComponent();

            listStaff.View = View.Details;
            listStaff.GridLines = true;
            listStaff.FullRowSelect = true;

            textData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            staff = new Staff();

            staff.add();
        }

        private void findField_TextChanged(object sender, EventArgs e)
        {
            // Данные получать с класса Staff
            // Реализовать поиск по 1-му индексу
            if (findField.Text != "" && findField.Text != "Пошук по ПІБ")
            {
                for (int i = listStaff.Items.Count - 1; i >= 0; i--)
                {
                    var item = listStaff.Items[i].SubItems[1];

                    if (item.Text.ToLower().Contains(findField.Text.ToLower()))
                    {
                        listStaff.Items[i].ForeColor = SystemColors.Highlight;
                        // listStaff.Items[i].ForeColor = SystemColors.HighlightText;
                    }
                    else
                    {
                        // listStaff.Items.Remove(item);
                    }
                }

                if (listStaff.SelectedItems.Count == 1)
                {
                    listStaff.Focus();
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
        }

        /**
         * Set focus on Search.
         */
        private void findField_Enter(object sender, EventArgs e)
        {
            if (findField.Text.Equals("Пошук по ПІБ"))
            {
                findField.Text = "";
            }
        }

        /**
         * Lose focus on Search.
         */
        private void findField_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(findField.Text))
            {
                findField.Text = "Пошук по ПІБ";
            }
        }
    }
}
