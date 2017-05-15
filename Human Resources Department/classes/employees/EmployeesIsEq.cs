using System;
using System.Windows.Forms;

using Human_Resources_Department.classes.employees.main;

namespace Human_Resources_Department.classes.employees
{
    class EmployeesIsEq
    {
        public static bool TextBox(TextBox t, int iRow, int iCell)
        {
            if ( string.IsNullOrWhiteSpace(t.Text) )
                return true;

            return string.Equals(t.Text.Trim(),
                EmployeesLV.GetValueItem(iRow, iCell).ToString(),
                StringComparison.OrdinalIgnoreCase);
        }

        public static bool CheckBox(CheckBox c, CheckBox isActive, int iRow, int iCell)
        {
            if (isActive.Checked)
                return c.Checked == EmployeesLV.GetValueItem(iRow, iCell).Equals("Так");

            return true;
        }

        public static bool DateTime(DateTimePicker dtp, CheckBox isActive, int iRow, int iCell)
        {
            if (isActive.Checked)
                if (!dtp.Value.Date.ToShortDateString().Equals(
                    EmployeesLV.GetValueItem(iRow, iCell).ToString()))
                    return false;

            return true;
        }
    }
}
