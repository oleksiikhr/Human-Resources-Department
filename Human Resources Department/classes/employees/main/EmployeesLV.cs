using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

using Human_Resources_Department.classes.helplers;
using Human_Resources_Department.classes.employees.db;

namespace Human_Resources_Department.classes.employees.main
{
    class EmployeesLV : HListView
    {
        private static ListView l;

        public const int I_ID              = 0;
        public const int I_FNAME           = 1;
        public const int I_LNAME           = 2;
        public const int I_MNAME           = 3;
        public const int I_EMAIL           = 4;
        public const int I_TEL_WORK        = 5;
        public const int I_TEL_HOME        = 6;
        public const int I_SEX             = 7;
        public const int I_IS_ACTIVITY     = 8;
        public const int I_EMPLOYMENT_DATE = 9;
        public const int I_UPDATE_AT       = 10;

        public static void SetListBox(ListView listView)
        {
            l = listView;

            Normillize(listView);
        }

        public static void SetNameColumns()
        {
            l.Columns.Insert(I_ID,              "#");
            l.Columns.Insert(I_FNAME,           "Ім'я");
            l.Columns.Insert(I_LNAME,           "Прізвище");
            l.Columns.Insert(I_MNAME,           "По-батькові");
            l.Columns.Insert(I_EMAIL,           "Email");
            l.Columns.Insert(I_TEL_WORK,        "Телефон роб.");
            l.Columns.Insert(I_TEL_HOME,        "Телефон дом.");
            l.Columns.Insert(I_SEX,             "Стать");
            l.Columns.Insert(I_IS_ACTIVITY,     "Працює");
            l.Columns.Insert(I_EMPLOYMENT_DATE, "Прийнятий на работу");
            l.Columns.Insert(I_UPDATE_AT,       "Останнє оновлення");
        }

        public static void GetAllData(bool allEmployees = false)
        {
            var data = MainModel.GetAllData(allEmployees);            

            foreach (var one in data)
            {
                AddItems(one);
            }
        }

        public static void AddOneData(int id)
        {
            var employee = MainModel.GetOneByID(id).First();

            AddItems(employee);
        }

        public static void UpdateOneData(int id)
        {
            if ( ! IsSelected() )
                return;

            var employee = MainModel.GetOneByID(id).First();
            int index = GetSelectedIndex();

            UpdateItems(index, employee);
        }

        public static void AddItems(MainTable mt)
        {
            l.Items.Add(new ListViewItem(new[] {
                T(mt.Id), T(mt.FName), T(mt.LName), T(mt.MName), T(mt.Email), T(mt.TelWork),
                T(mt.TelHome), mt.Sex ? "Чоловік" : "Жінка", T(mt.IsActivity),
                T(mt.EmploymentDate), T(mt.UpdateAt)
            }));

            if (!mt.IsActivity)
                l.Items[GetCountItems() - 1].BackColor = Color.FromArgb(255, 205, 210);
        }

        public static void UpdateItems(int index, MainTable mt)
        {
            l.Items[index].SubItems[I_FNAME].Text = T(mt.FName);
        }

        public static void UpdateSelectedData()
        {
            int index = GetSelectedIndex();

            //var data = new EmployeesModel(Config.currentFolder + "\\" + EmployeesModel.nameFile)
            //        .GetOneData(Convert.ToInt32( l.Items[GetSelectedIndex()].SubItems[I_ID].Text) );

            //foreach (var one in data)
            //{
            //    l.Items[index].SubItems[I_FNAME].Text       = T(one.FName);
            //    l.Items[index].SubItems[I_LNAME].Text       = T(one.LName);
            //    l.Items[index].SubItems[I_MNAME].Text       = T(one.MName);
            //    l.Items[index].SubItems[I_JOB].Text         = T(one.Job);
            //    l.Items[index].SubItems[I_CITY].Text        = T(one.City);
            //    l.Items[index].SubItems[I_EMAIL].Text       = T(one.Email);
            //    l.Items[index].SubItems[I_TEL].Text         = T(one.Tel);
            //    l.Items[index].SubItems[I_FAMILY].Text      = T(one.Family);
            //    l.Items[index].SubItems[I_SALARY].Text      = T(one.Salary);
            //    l.Items[index].SubItems[I_IS_ACTIVITY].Text = T(one.IsActivity);
            //    l.Items[index].SubItems[I_IS_FULLTIME].Text = T(one.IsFulltime);
            //    l.Items[index].SubItems[I_BIRTHDAY].Text    = T(one.Birthday);
            //    l.Items[index].SubItems[I_SETCOMPANY].Text  = T(one.SetCompany);
            //    l.Items[index].SubItems[I_UPDATE_AT].Text   = T(one.UpdateAt);
                
            //    if (!one.IsActivity)
            //        l.Items[index].BackColor = Color.FromArgb(255, 205, 210);
            //}
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

        public static void AddNewToBDAndToLV()
        {
            var data = MainModel.GetOneByID(GetCountItems() + 1);

            foreach (var one in data)
            {
                l.Items.Add( new ListViewItem( new[] {
                    T(one.Id), T(one.FName) // ..
                }));
            }
        }

        public static int GetSelectedID()
        {
            return Convert.ToInt32(l.SelectedItems[0].SubItems[0].Text);
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
            return new object[] { "" };
            //int dismissed = 0;
            //double salary = 0;
            //int countEdit = 0;
            //int countFull = 0;
            //int birthdayToday = 0;
            //int birthdayTomorrow = 0;

            //for (int i = 0; i < GetCountItems(); i++)
            //{
            //    if ( ! l.Items[i].SubItems[I_IS_ACTIVITY].Text.Equals("Так") )
            //        dismissed++;

            //    if (l.Items[i].SubItems[I_UPDATE_AT].Text.Equals(DateTime.Today.ToShortDateString()))
            //        countEdit++;

            //    if ( l.Items[i].SubItems[I_IS_FULLTIME].Text.Equals("Так") )
            //        countFull++;

            //    salary += Double.Parse( l.Items[i].SubItems[I_SALARY].Text );

            //    if (l.Items[i].SubItems[I_BIRTHDAY].Text.Equals(DateTime.Today.ToShortDateString()))
            //        birthdayToday++;

            //    if (l.Items[i].SubItems[I_BIRTHDAY].Text.Equals(DateTime.Today.AddDays(1).ToShortDateString()))
            //        birthdayTomorrow++;
            //}

            //return new object[] {
            //    dismissed, salary, countEdit, countFull, birthdayToday, birthdayTomorrow
            //};
        }
    }
}
