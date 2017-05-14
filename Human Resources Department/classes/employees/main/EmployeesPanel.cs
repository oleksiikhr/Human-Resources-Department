using System;
using System.Drawing;
using System.Windows.Forms;

using Human_Resources_Department.classes.employees.db;

namespace Human_Resources_Department.classes.employees.main
{
    class EmployeesPanel
    {
        private static Panel p;

        public static void SetPanel(Panel panel)
        {
            p = panel;
        }

        public static void AddInfo(Control c, object val)
        {
            if ( c.GetType() == typeof(TextBox) )
                (c as TextBox).Text = val.ToString();
            else if ( c.GetType() == typeof(DateTimePicker) )
                (c as DateTimePicker).Value = DateTime.Parse( val.ToString() );
            else if ( c.GetType() == typeof(CheckBox) )
                (c as CheckBox).Checked = Boolean.Parse( val.ToString() );
            else if ( c.GetType() == typeof(PictureBox) )
                (c as PictureBox).Image = (val as Image);
        }

        public static void ClearAllData()
        {
            foreach (Control c in p.Controls)
            {
                if ( c.GetType() == typeof(TextBox) )
                    (c as TextBox).Text = string.Empty;
                else if ( c.GetType() == typeof(DateTimePicker) )
                    (c as DateTimePicker).Value = DateTime.Today;
                else if ( c.GetType() == typeof(CheckBox) )
                    (c as CheckBox).Checked = false;
                else if ( c.GetType() == typeof(PictureBox) )
                    (c as PictureBox).Image = null;
            }
        }

        public static void Enabled(bool toggle = false)
        {
            foreach (Control c in p.Controls)
            {
                if ( c.GetType() == typeof(TextBox) )
                    (c as TextBox).ReadOnly = !toggle;
                else if ( c.GetType() == typeof(DateTimePicker) )
                    (c as DateTimePicker).Enabled = toggle;
                else if ( c.GetType() == typeof(CheckBox) )
                    (c as CheckBox).Enabled = toggle;
                else if ( c.GetType() == typeof(Button) )
                    (c as Button).Enabled = toggle;
            }
        }

        public static int UpdateData(object[] args)
        {
            return new EmployeesModel(Config.currentFolder + "\\" + EmployeesModel.nameFile)
                .Update(
                    "UPDATE " + typeof(EmployeesTable).Name
                    + " SET FName = ?, LName = ?, MName = ?, Job = ?, City = ?, Email = ?,"
                    + " Tel = ?, Family = ?, Salary = ?, IsFulltime = ?, Birthday = ?,"
                    + " SetCompany = ?, UpdateAt = ? WHERE id = ?", args
                );
        }

        public static int UpdateActivity(bool isActivity, int id)
        {
            return new EmployeesModel(Config.currentFolder + "\\" + EmployeesModel.nameFile).Update(
                "UPDATE " + typeof(EmployeesTable).Name + " SET IsActivity = ?, UpdateAt = ? WHERE id = ?",
                    new object[] { isActivity, DateTime.Today, id }
            );
        }

        public static bool IsNull()
        {
            return p == null;
        }

        public static void Close()
        {
            p = null;
        }
    }
}
