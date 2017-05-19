using System.Windows.Forms;

namespace Human_Resources_Department.classes.helplers
{
    class HPanel
    {
        public static void ActivateToggle(Panel p, bool toggle = false)
        {
            foreach (Control c in p.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                    (c as TextBox).ReadOnly = !toggle;
                else if (c.GetType() == typeof(DateTimePicker))
                    (c as DateTimePicker).Enabled = toggle;
                else if (c.GetType() == typeof(CheckBox))
                    (c as CheckBox).Enabled = toggle;
                else if (c.GetType() == typeof(Button))
                    (c as Button).Enabled = toggle;
            }
        }
    }
}
