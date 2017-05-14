using System;
using System.Drawing;
using System.Windows.Forms;

using Human_Resources_Department.classes.employees.db;
using Human_Resources_Department.classes.helplers;

namespace Human_Resources_Department.classes.employees
{
    class EmployeesLV : LV
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

        public static void SetListBox(ListView listView)
        {
            l = listView;

            LV.Normillize(listView);
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
                    LV.T(one.Id), LV.T(one.FName), LV.T(one.LName), LV.T(one.MName), LV.T(one.Job), LV.T(one.City),
                    LV.T(one.Email), LV.T(one.Tel), LV.T(one.Family), LV.T(one.Salary), LV.T(one.IsActivity),
                    LV.T(one.IsFulltime), LV.T(one.Birthday), LV.T(one.SetCompany), LV.T(one.UpdateAt)
                }));

                if (!one.IsActivity)
                    l.Items[GetCountItems() - 1].BackColor = Color.FromArgb(255, 205, 210);
            }
        }
        
        public static void UpdateSelectedData()
        {
            int index = GetSelectedIndex();

            var data = new EmployeesModel(Config.currentFolder + "\\" + EmployeesModel.nameFile)
                    .GetOneData(Convert.ToInt32( l.Items[GetSelectedIndex()].SubItems[I_ID].Text) );

            foreach (var one in data)
            {
                l.Items[index].SubItems[I_FNAME].Text       = LV.T(one.FName);
                l.Items[index].SubItems[I_LNAME].Text       = LV.T(one.LName);
                l.Items[index].SubItems[I_MNAME].Text       = LV.T(one.MName);
                l.Items[index].SubItems[I_JOB].Text         = LV.T(one.Job);
                l.Items[index].SubItems[I_CITY].Text        = LV.T(one.City);
                l.Items[index].SubItems[I_EMAIL].Text       = LV.T(one.Email);
                l.Items[index].SubItems[I_TEL].Text         = LV.T(one.Tel);
                l.Items[index].SubItems[I_FAMILY].Text      = LV.T(one.Family);
                l.Items[index].SubItems[I_SALARY].Text      = LV.T(one.Salary);
                l.Items[index].SubItems[I_IS_ACTIVITY].Text = LV.T(one.IsActivity);
                l.Items[index].SubItems[I_IS_FULLTIME].Text = LV.T(one.IsFulltime);
                l.Items[index].SubItems[I_BIRTHDAY].Text    = LV.T(one.Birthday);
                l.Items[index].SubItems[I_SETCOMPANY].Text  = LV.T(one.SetCompany);
                l.Items[index].SubItems[I_UPDATE_AT].Text   = LV.T(one.UpdateAt);
                
                if (!one.IsActivity)
                    l.Items[index].BackColor = Color.FromArgb(255, 205, 210);
            }
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
                    LV.T(one.Id), LV.T(one.FName), LV.T(one.LName), LV.T(one.MName), LV.T(one.Job),
                    LV.T(one.City), LV.T(one.Email), LV.T(one.Tel), LV.T(one.Family), LV.T(one.Salary),
                    LV.T(one.IsActivity), LV.T(one.IsFulltime), LV.T(one.Birthday), LV.T(one.SetCompany),
                    LV.T(one.UpdateAt)
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

        // |---------------------------------------
        // | Basic info for ListBox.
        // |---------------------------------------
        // |
        // | dismissed - Количество уволенных сотрудников.
        // | salary    - Сумма всех зарплат сотрудников.
        // | countEdit - Количество редактирований за сегодня.
        // | countFull - Количество работников на полный рабочий день.
        // |
        public static object[] GetBasicInfo()
        {
            int dismissed = 0;
            double salary = 0;
            int countEdit = 0;
            int countFull = 0;
            
            for (int i = 0; i < GetCountItems(); i++)
            {
                if ( ! l.Items[i].SubItems[I_IS_ACTIVITY].Text.Equals("Так") )
                    dismissed++;

                if (l.Items[i].SubItems[I_UPDATE_AT].Text.Equals(DateTime.Today.ToShortDateString()))
                    countEdit++;

                if ( l.Items[i].SubItems[I_IS_FULLTIME].Text.Equals("Так") )
                    countFull++;

                salary += Double.Parse( l.Items[i].SubItems[I_SALARY].Text );
            }

            return new object[] { dismissed, salary, countEdit, countFull };
        }
    }
}
