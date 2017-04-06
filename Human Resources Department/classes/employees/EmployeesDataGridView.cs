using Human_Resources_Department.classes.employees.db;
using System;
using System.Windows.Forms;

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
        public const int CELLS_UPDATE_AT   = 14;

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
            d.Columns[CELLS_UPDATE_AT].HeaderText   = "Оновлення";
        }

        public void AddInfoOnDetailStaff(TextBox t, int cell)
        {
            var value = d.CurrentRow.Cells[cell].Value;

            if (value == null)
                return;

            t.Text = DateTime.TryParse(value.ToString(), out DateTime dt)
                ? t.Text = dt.ToString("dd.MM.yyyy")
                : value.ToString();
        }

        public bool GetCellIsActivity()
        {
            return Boolean.Parse( d.CurrentRow.Cells[CELL_IS_ACTIVITY].Value.ToString() );
        }

        public void SetColorIsActivity()
        {
            foreach (DataGridViewRow row in d.Rows)
            {
                // IF NO_ACTIVE => COLOR CHANGE
            }
        }

        public void NewDataSource()
        {
            d.DataSource = new EmployeesModel(Config.currentFolder + "\\" + EmployeesModel.nameFile)
                .GetAllData();
            d.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void FindCellAndSetFocus(string text, int cell)
        {
            for (int i = 0; i < d.Rows.Count; i++)
            {
                if ( text.ToLower().Equals(d.Rows[i].Cells[cell].Value.ToString().ToLower()) )
                {
                    d.Rows[i].Cells[cell].Selected = true;
                    break;
                }
            }
        }
    }
}
