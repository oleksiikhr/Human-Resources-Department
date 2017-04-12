using System;
using System.Drawing;
using System.Windows.Forms;

using Human_Resources_Department.classes.employees.db;

namespace Human_Resources_Department.classes.employees
{
    class EmployeesDGV
    {
        private static DataGridView d;

        private static int[] ids;
        private static int len = 0;

        public const int CELL_ID           = 0;
        public const int CELL_FNAME        = 1;
        public const int CELL_LNAME        = 2;
        public const int CELL_MNAME        = 3;
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
        
        public static void SetDataGridView(DataGridView dataGridView)
        {
            d = dataGridView;
        }

        // !!!
        public static void SetID(int id)
        {
            ids[len] = id;
        }

        public static void RenameColumns()
        {
            if (d.Columns.Count == 0)
                return;

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
            d.Columns[CELL_BIRTHDAY].HeaderText     = "Народився";
            d.Columns[CELL_SETCOMPANY].HeaderText   = "Назначений";
            d.Columns[CELL_UPDATE_AT].HeaderText    = "Оновлення";
        }

        public static bool EmployeeIsActivity()
        {
            return Boolean.Parse( d.SelectedRows[0].Cells[CELL_IS_ACTIVITY].Value.ToString() );
        }

        public static void SetColorRows()
        {
            DataGridViewCellStyle color = new DataGridViewCellStyle()
            {
                BackColor = Color.FromArgb(255, 205, 210)
            };

            foreach (DataGridViewRow row in d.Rows)
            {
                if ( ! Boolean.Parse( row.Cells[CELL_IS_ACTIVITY].Value.ToString() ) )
                    row.DefaultCellStyle = color;
            }
        }

        public static bool UpdateDataSource()
        {
            try
            {
                // If active filter => ????
                d.DataSource = new EmployeesModel(Config.currentFolder + "\\" + EmployeesModel.nameFile)
                    .GetAllData();

                d.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void FindCellAndSetFocus(string text, int cell, bool isLower = false)
        {
            int count = (d.SelectedRows.Count > 0) ? d.SelectedRows[0].Index + 1 : 0;
            
            text = isLower ? text.ToLower() : text;
            
            for (int i = count; i < d.Rows.Count + count; i++)
            {
                if ( text.Equals(d.Rows[i % d.Rows.Count].Cells[cell].Value.ToString().ToLower()) )
                {
                    d.Rows[i % d.Rows.Count].Cells[cell].Selected = true;
                    break;
                }
            }
        }

        public static void SetVisible(int index, bool toggle)
        {
            d.Rows[index].Visible = toggle;
        }

        public static int GetSelectedIndex()
        {
            return d.SelectedRows[0].Index;
        }

        public static void ClearSelected()
        {
            d.ClearSelection();
        }

        public static void LostCurrentCell()
        {
            d.CurrentCell = null;
        }

        public static object GetSelectedCell(int cell)
        {
            return d.SelectedRows[0].Cells[cell].Value;
        }

        public static int GetCountSelectedRows()
        {
            return d.SelectedRows.Count;
        }

        public static int GetIndexSelectedRow()
        {
            return d.SelectedRows[0].Index;
        }

        public static void SetSelected(int index, bool toggle)
        {
            d.Rows[index].Selected = true;
        }

        public static int GetCountRows()
        {
            return d.Rows.Count;
        }

        public static object GetValueCell(int row, int cell)
        {
            return d.Rows[row].Cells[cell].Value;
        }

        public static bool IsVisibleRow(int row)
        {
            return d.Rows[row].Visible;
        }

        public static bool IsNull()
        {
            return d == null;
        }

        public static void Close()
        {
            d = null;
            ids = null;
            len = 0;
        }
    }
}
