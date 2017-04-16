using System;
using System.Drawing;
using System.Windows.Forms;

using Human_Resources_Department.classes.employees.db;

namespace Human_Resources_Department.classes.employees
{
    class EmployeesLV
    {
        private static ListView l;

        public const int I_ID           = 0;
        public const int I_FNAME        = 1;
        public const int I_LNAME        = 2;
        public const int I_MNAME        = 3;
        public const int I_JOB          = 4;
        public const int I_CITY         = 5;
        public const int I_EMAIL        = 6;
        public const int I_TEL          = 7;
        public const int I_FAMILY       = 8;
        public const int I_SALARY       = 9;
        public const int I_IS_ACTIVITY  = 10;
        public const int I_IS_FULLTIME  = 11;
        public const int I_BIRTHDAY     = 12;
        public const int I_SETCOMPANY   = 13;
        public const int I_UPDATE_AT    = 14;

        public static void SetListBox(ListView listBox)
        {
            l = listBox;

            l.View = View.Details;
            l.MultiSelect = false;
            l.FullRowSelect = true;
            l.AllowColumnReorder = true;
            l.HideSelection = false;
            l.GridLines = true;
        }

        public static void SetNameColumns()
        {
            l.Columns.Insert(I_ID,           "#");
            l.Columns.Insert(I_FNAME,        "Ім'я");
            l.Columns.Insert(I_LNAME,        "Прізвище");
            l.Columns.Insert(I_MNAME,        "По-батькові");
            l.Columns.Insert(I_JOB,          "Посада");
            l.Columns.Insert(I_CITY,         "Місто");
            l.Columns.Insert(I_EMAIL,        "Email");
            l.Columns.Insert(I_TEL,          "Телефон");
            l.Columns.Insert(I_FAMILY,       "Сімейний стан");
            l.Columns.Insert(I_SALARY,       "Зарплата");
            l.Columns.Insert(I_IS_ACTIVITY,  "Активний");
            l.Columns.Insert(I_IS_FULLTIME,  "Зайнятість");
            l.Columns.Insert(I_BIRTHDAY,     "Народився");
            l.Columns.Insert(I_SETCOMPANY,   "Назначений");
            l.Columns.Insert(I_UPDATE_AT,    "Оновлення");
        }

        public static void GetAllData()
        {
            var data = new EmployeesModel(Config.currentFolder + "\\" + EmployeesModel.nameFile)
                    .GetAllData();

            foreach (var one in data)
            {
                l.Items.Add( new ListViewItem( new[] {
                    T(one.Id), T(one.FName), T(one.LName), T(one.MName), T(one.Job), T(one.City),
                    T(one.Email), T(one.Tel), T(one.Family), T(one.Salary), T(one.IsActivity),
                    T(one.IsFulltime), T(one.Birthday), T(one.SetCompany), T(one.UpdateAt)
                }));

                if (!one.IsActivity)
                    l.Items[GetCountItems() - 1].BackColor = Color.FromArgb(255, 205, 210);
            }
        }

        public static void UpdateSelectedData()
        {
            int index = GetSelectedIndex();

            var data = new EmployeesModel(Config.currentFolder + "\\" + EmployeesModel.nameFile)
                    .GetOneData(index + 1);
            
            foreach (var one in data)
            {
                l.Items.Insert(index, new ListViewItem(new[] {
                    T(one.Id), T(one.FName), T(one.LName), T(one.MName), T(one.Job), T(one.City),
                    T(one.Email), T(one.Tel), T(one.Family), T(one.Salary), T(one.IsActivity),
                    T(one.IsFulltime), T(one.Birthday), T(one.SetCompany), T(one.UpdateAt)
                }));

                if (!one.IsActivity)
                    l.Items[index].BackColor = Color.FromArgb(255, 205, 210);
            }

            l.Items[index].Selected = true;
            l.Items[index + 1].Remove();
        }

        private static string T(object ob)
        {
            if ( ob.GetType() == typeof(bool) )
                return ((bool) ob) ? "Так" : "Ні";
            else if ( ob.GetType() == typeof(DateTime) )
                return ((DateTime) ob).ToShortDateString();
            else if ( ob.GetType() == typeof(string) )
                return ((string) ob);
            else
                return ob.ToString();
        }

        public static void FindCellAndSetFocus(string text, int cell, bool isLower = false)
        {
            int count = IsSelected() ? GetSelectedIndex() + 1 : 0;

            text = isLower ? text.ToLower() : text;

            for (int i = count; i < GetCountItems() + count; i++)
            {
                if ( text.Equals(l.Items[i % GetCountItems()].SubItems[cell].Text.ToString().ToLower()) )
                {
                    l.Items[i % GetCountItems()].Selected = true;
                    break;
                }
            }
        }

        public static void AddNew()
        {
            var data = new EmployeesModel(Config.currentFolder + "\\" + EmployeesModel.nameFile)
                    .GetOneData(GetCountItems() + 1);

            foreach (var one in data)
            {
                l.Items.Add( new ListViewItem( new[] {
                    T(one.Id), T(one.FName), T(one.LName), T(one.MName), T(one.Job), T(one.City),
                    T(one.Email), T(one.Tel), T(one.Family), T(one.Salary), T(one.IsActivity),
                    T(one.IsFulltime), T(one.Birthday), T(one.SetCompany), T(one.UpdateAt)
                }));
            }
        }

        public static void Delete(int index)
        {
            l.Items[index].Remove();
        }

        public static bool EmployeeIsActivity()
        {
            return GetSelectedCell(I_IS_ACTIVITY).Equals("Так");
        }

        public static object GetSelectedCell(int subItem)
        {
            if ( ! IsSelected() )
                return null;

            return l.SelectedItems[0].SubItems[subItem].Text;
        }

        public static void SetSelectedText(int subItem, string text)
        {
            l.SelectedItems[0].SubItems[subItem].Text = text;
        }

        public static void SetSelected(int item, bool toggle)
        {
            l.Items[item].Selected = toggle;
        }

        public static object GetValueItem(int row, int cell)
        {
            return l.Items[row].SubItems[cell].Text;
        }

        public static bool IsSelected()
        {
            return l.SelectedItems.Count != 0;
        }

        public static int GetSelectedIndex()
        {
            return l.SelectedItems[0].Index;
        }

        public static int GetCountItems()
        {
            return l.Items.Count;
        }

        public static void ClearAllData()
        {
            l.Clear();
        }

        public static void Close()
        {
            l = null;
        }
    }
}
