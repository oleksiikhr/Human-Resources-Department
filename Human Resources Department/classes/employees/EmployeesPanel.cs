using System;
using System.Windows.Forms;

using Human_Resources_Department.classes.employees.db;

namespace Human_Resources_Department.classes.employees
{
    class EmployeesPanel
    {
        private Panel p;

        public EmployeesPanel(Panel p)
        {
            this.p = p;
        }

        public void AddInfo(Control c, object val)
        {
            if (val == null)
                return;
            
            if ( c.GetType() == typeof(TextBox) )
                (c as TextBox).Text = val.ToString();
            else if ( c.GetType() == typeof(DateTimePicker) )
                (c as DateTimePicker).Value = DateTime.Parse( val.ToString() );
            else if ( c.GetType() == typeof(CheckBox) )
                (c as CheckBox).Checked = Boolean.Parse( val.ToString() );
            // For PictureBox
        }

        public void ClearAllData()
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
                    (c as PictureBox).Image = null; // Not working..
            }
        }

        public void Enabled(bool toggle = false)
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

        public void UpdateData(object[] args)
        {
            new EmployeesModel(Config.currentFolder + "\\" + EmployeesModel.nameFile)
                .Update(
                    "UPDATE " + typeof(EmployeesTable).Name
                    + " SET FName = ?, MName = ?, LName = ?, Job = ?, City = ?, Email = ?,"
                    + " Tel = ?, Family = ?, Salary = ?, IsFulltime = ?, Birthday = ?,"
                    + " SetCompany = ?, UpdateAt = ? WHERE id = ?", args
                );
        }
    }
}
