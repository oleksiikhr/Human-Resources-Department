using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

using Human_Resources_Department.classes.helplers;
using Human_Resources_Department.classes.employees.db;
using Human_Resources_Department.classes.db.jobs;

namespace Human_Resources_Department.classes.employees.main
{
    class EmployeesLV : HListView
    {
        private static ListView l;

        public const int I_ID              = 0;
        public const int I_FNAME           = 1;
        public const int I_LNAME           = 2;
        public const int I_MNAME           = 3;
        public const int I_JOB_ID          = 4;
        public const int I_EMAIL           = 5;
        public const int I_TEL_WORK        = 6;
        public const int I_TEL_HOME        = 7;
        public const int I_SEX             = 8;
        public const int I_IS_ACTIVITY     = 9;
        public const int I_EMPLOYMENT_DATE = 10;
        public const int I_UPDATE_AT       = 11;

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
            l.Columns.Insert(I_JOB_ID,          "Посада");
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
            var job = JobsModel.GetOneJobs(mt.JobId);
            string JobTitle = job.Count() > 0 ? job.First().Title : "";

            l.Items.Add(new ListViewItem(new[] {
                T(mt.Id), T(mt.FName), T(mt.LName), T(mt.MName), JobTitle, T(mt.Email),
                T(mt.TelWork), T(mt.TelHome), mt.Sex ? "Чоловік" : "Жінка", T(mt.IsActivity),
                T(mt.EmploymentDate), T(mt.UpdateAt)
            }));

            ColorRows(GetCountItems() - 1, mt);
        }

        public static void UpdateItems(int i, MainTable mt)
        {
            var job = JobsModel.GetOneJobs(mt.JobId);
            string JobTitle = job.Count() > 0 ? job.First().Title : "";

            l.Items[i].SubItems[I_FNAME].Text           = T(mt.FName);
            l.Items[i].SubItems[I_MNAME].Text           = T(mt.MName);
            l.Items[i].SubItems[I_LNAME].Text           = T(mt.LName);
            l.Items[i].SubItems[I_JOB_ID].Text          = JobTitle;
            l.Items[i].SubItems[I_SEX].Text             = mt.Sex ? "Чоловік" : "Жінка";
            l.Items[i].SubItems[I_EMAIL].Text           = T(mt.Email);
            l.Items[i].SubItems[I_TEL_WORK].Text        = T(mt.TelWork);
            l.Items[i].SubItems[I_TEL_HOME].Text        = T(mt.TelHome);
            l.Items[i].SubItems[I_IS_ACTIVITY].Text     = T(mt.IsActivity);
            l.Items[i].SubItems[I_EMPLOYMENT_DATE].Text = T(mt.EmploymentDate);
            l.Items[i].SubItems[I_UPDATE_AT].Text       = T(mt.UpdateAt);
            
            ColorRows(i, mt);
        }

        private static void ColorRows(int i, MainTable mt)
        {
            if (!mt.IsActivity)
                l.Items[i].BackColor = Color.FromArgb(255, 205, 210);
            else if (mt.UpdateAt == DateTime.Today)
                l.Items[i].BackColor = Color.FromArgb(192, 192, 192);
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
        
        public static int GetSelectedID()
        {
            return Convert.ToInt32(l.SelectedItems[0].SubItems[0].Text);
        }

        public static void UpdateSelected()
        {
            if ( IsSelected() )
            {
                int index = GetSelectedIndex();
                l.Items[index].Selected = false;
                l.Items[index].Selected = true;
            }
            else
            {
                l.Items[GetCountItems() - 1].Selected = true;
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
