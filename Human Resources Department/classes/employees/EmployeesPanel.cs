using System;
using System.Windows.Forms;

namespace Human_Resources_Department.classes.employees
{
    class EmployeesPanel
    {
        private bool readOnly;
        private bool toggle;

        private Panel p;

        public EmployeesPanel(Panel p)
        {
            this.p = p;
        }

        public void AddInfo(TextBox t, object value)
        {
            if (value == null)
                return;

            t.Text = DateTime.TryParse(value.ToString(), out DateTime dt)
                ? t.Text = dt.ToString("dd.MM.yyyy")
                : value.ToString();
        }

        public void ChangeAllTextBox(string command, bool toggle = false)
        {
            foreach (Control c in p.Controls)
            {
                if ( c.GetType() == typeof(TextBox) )
                {
                    if ( command.ToLower().Equals("clear") )
                        c.Text = string.Empty;
                    else if ( command.ToLower().Equals("readonly") )
                    {
                        (c as TextBox).ReadOnly = toggle;
                        readOnly = toggle;
                    }
                }
            }
        }

        public void ToggleButton(bool toggle = false)
        {
            if (this.toggle == toggle)
                return;

            foreach (Control c in p.Controls)
            {
                if ( c.GetType() == typeof(Button) )
                {
                    c.Enabled = !c.Enabled;
                }
            }

            this.toggle = !this.toggle;
        }

        public bool IsReadOnly()
        {
            return readOnly;
        }
    }
}
