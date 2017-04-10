using System;
using System.Windows.Forms;

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
            }
        }
    }
}
