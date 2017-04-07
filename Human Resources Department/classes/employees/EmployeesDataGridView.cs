using System;
using System.Drawing;
using System.Windows.Forms;

using Human_Resources_Department.classes.employees.db;

namespace Human_Resources_Department.classes.employees
{
    class EmployeesDataGridView
    {
        private DataGridView d;

        public const int CELL_ID           = 0;
        public const int CELL_FNAME        = 1;
        public const int CELL_MNAME        = 2;
        public const int CELL_LNAME        = 3;
        public const int CELL_JOB          = 4;
        public const int CELL_CITY         = 5;
        public const int CELL_EMAIL        = 6;
        public const int CELL_TEL          = 7;
        public const int CELL_FAMILY       = 8;
        public const int CELL_SALARY       = 9;
        public const int CELL_IS_ACTIVITY  = 10;
        public const int CELL_IS_FULLTIME  = 11;
        public const int CELL_BIRTHDAY     = 12;
        public const int CELL_SETCOMPANY   = 13;
        public const int CELL_UPDATE_AT    = 14;

        public EmployeesDataGridView(DataGridView d)
        {
            this.d = d;
        }

        public void SetNameColumns()
        {
            d.Columns[CELL_ID].HeaderText           = "#";
            d.Columns[CELL_FNAME].HeaderText        = "Ім'я";
            d.Columns[CELL_LNAME].HeaderText        = "Прізвище";
            d.Columns[CELL_MNAME].HeaderText        = "По-батькові";
            d.Columns[CELL_JOB].HeaderText          = "Посада";
            d.Columns[CELL_CITY].HeaderText         = "Місто";
            d.Columns[CELL_EMAIL].HeaderText        = "Email";
            d.Columns[CELL_TEL].HeaderText          = "Телефон";
            d.Columns[CELL_FAMILY].HeaderText       = "Сімейний стан";
            d.Columns[CELL_SALARY].HeaderText       = "Зарплата";
            d.Columns[CELL_IS_ACTIVITY].HeaderText  = "Активний";
            d.Columns[CELL_IS_FULLTIME].HeaderText  = "Зайнятість";
            d.Columns[CELL_BIRTHDAY].HeaderText     = "Народження";
            d.Columns[CELL_SETCOMPANY].HeaderText   = "Назначений";
            d.Columns[CELL_UPDATE_AT].HeaderText    = "Оновлення";
        }

        public void AddInfoOnDetailStaff(TextBox t, int cell)
        {
            var val = d.CurrentRow.Cells[cell].Value;

            if (val == null)
                return;

            t.Text = DateTime.TryParse(val.ToString(), out DateTime dt)
                ? t.Text = dt.ToString("dd.MM.yyyy")
                : val.ToString();
        }

        public bool GetCellIsActivity()
        {
            return Boolean.Parse( d.CurrentRow.Cells[CELL_IS_ACTIVITY].Value.ToString() );
        }

        public void SetColorIsActivity()
        {
            DataGridViewCellStyle color = new DataGridViewCellStyle()
            {
                BackColor = Color.FromArgb(255, 205, 210)
            };

            foreach (DataGridViewRow row in d.Rows)
            {
                if ( ! Boolean.Parse( row.Cells[CELL_IS_ACTIVITY].Value.ToString() ) )
                {
                    row.DefaultCellStyle = color;
                }
            }
        }

        public void NewDataSource()
        {
            d.DataSource = new EmployeesModel(Config.currentFolder + "\\" + EmployeesModel.nameFile)
                .GetAllData();
            d.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void FindCellAndSetFocus(string text, int cell, bool isLower = false)
        {
            int count = (d.CurrentRow != null) ? d.CurrentRow.Index + 1 : 0;

            if (isLower)
            {
                text = text.ToLower();
            }
            
            for (int i = count; i < d.Rows.Count + count; i++)
            {
                if ( text.Equals(d.Rows[i % d.Rows.Count].Cells[cell].Value.ToString().ToLower()) )
                {
                    d.Rows[i % d.Rows.Count].Cells[cell].Selected = true;
                    break;
                }
            }
        }
    }
}
